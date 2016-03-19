using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;


namespace startpage
{
	/// <summary>
	/// 게시판에 대한 요약 설명입니다.
	/// </summary>
	public class 게시판
	{
		public 게시판()
		{
			//
			// TODO: 여기에 생성자 논리를 추가합니다.
			//
		}
	}

	[Serializable]
	public class comment
	{
		public string id;
		protected string text;
		public DateTime date;

		public comment(string id, string text)
		{
			this.id = id;								//글쓴이
			this.text = text;		//내용
			this.date = DateTime.Now;		//작성일자
		}
	/*	public bool check_him()						//권한검사. 오버라이드됨
		{
			if( == id) return true;
			else return false;
		}*/
		public void change(string text)				//수정메소드
		{
			this.text = text;
			this.date = DateTime.Now;
		}
		public string get_id() {return id;}
		public string get_date() {return date.ToString();}
		public string get_shortdate() {return date.ToShortDateString();}
		public string get_text() {return text;}
	}

	[Serializable]
	public class board : comment
	{
		public ArrayList subcomment;			//코멘트 배열
		protected int hit = 0;							//조회수
		public int page_index;
		public string title;							//제목
		//public string field;
		//protected string filename;						//1-0, 1-1, 1-12, 1+id식으로 파일명을 정한다.1-0은 대주제

		public board(string title, string id, string text) : base(id, text)
		{
			this.title = title;
			//this.filename = filename;
			//page_index = 토론.page_index;
			//filename = 토론.fb_index.ToString() + "-" + page_index.ToString();
			subcomment = new ArrayList();
		}
		/*public bool check_logged()
		{
			if(토론.cur_id == null || 토론.cur_id == "") return false;
			else return true;
		}*/
		public int get_page_index() {return this.page_index;}
		public void attach_comment(comment c)
		{
			subcomment.Add(c);
		}	
		public void delete_comment(comment c)
		{
			subcomment.Remove(c);
		}
		public virtual void writeFile(string field, string index)
		{
			FileStream fs = File.Create(토론.cur_dir + field + "/" + index);
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(fs, this);
			fs.Close();
		}
		public static board readFile(string field, string index)
		{
			board b;
			FileStream fs = File.OpenRead(토론.cur_dir + field + "/" + index);
			BinaryFormatter bf = new BinaryFormatter();
			b = (board)bf.Deserialize(fs);
			fs.Close();
			return b;
		}
		public void show()			//그리드에 표현
		{
			hit++;
		}
			
		public virtual int get_hit() {return hit;}
	}

	[Serializable]
	public class fboard : board
	{
		public int response_term;		//회신 기간
		public int fb_index;
		public ArrayList ids = new ArrayList();				//서신 왕래할 아이디들
		public bool inturn = true;		//차례로 할것인지
		public bool read = true, write = true, vote = true;
		//public bool started = false, ended = false;
		public string field;
		public fboard(ArrayList ids, int response_term, bool read, bool write, bool vote, bool inturn, string title, string id, string text) : base(title, id, text)
		{
			this.ids = ids;
			this.response_term = response_term;
			this.read = read;
			this.write = write;
			this.vote = vote;
			this.inturn = inturn;
			this.fb_index = tools.get_largest("대기");
			//fb_index = this.filenum();
			//this.filename = fb_index.ToString() + "-0"; //filenum이 한번만 쓰임
		}

		public int get_fb_index() {return this.fb_index;}
		//public bool get_started() {return this.started;}
		/*public int get_totalhit()			//각 파라보드의 조회수를 합하여 가져옴.
		{
			ArrayList al = new ArrayList();
			DirectoryInfo dir = new DirectoryInfo(토론.cur_dir + "fboard/");
			FileInfo[] boardfiles = dir.GetFiles(filename + "-*");
			BinaryFormatter bf = new BinaryFormatter();
			int i = 0;
			foreach (FileInfo f in boardfiles)	
			{
				FileStream fs = File.OpenRead(토론.cur_dir + "fboard/" + f.Name);
				i += ((board)bf.Deserialize(fs)).get_hit();
				fs.Close();
			}
			return i;
		}*/
		public bool get_intern(){return this.inturn;}
		public bool check_writable(){return this.write;}
		public bool check_readable(){return this.read;}
		public bool check_votable(){return this.vote;}
		
		public void writeFile()			//파일에 저장
		{
			string file = "/" + this.fb_index.ToString() + "-" + this.page_index.ToString();
			file = 토론.cur_dir + this.field + file;
			FileStream fs = File.Create(file);
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(fs, this);
			fs.Close();
		}
		public void deleteFile()
		{
			string file = "/" + this.fb_index.ToString() + "-" + this.page_index.ToString();
			file = 토론.cur_dir + this.field + file;
            File.Delete(file);
		}
		public void writewait()
		{
			string file = "/" + this.fb_index.ToString() + "-" + this.page_index.ToString();
			file = 토론.cur_dir + "대기" + file;
			FileStream fs = File.Create(file);
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(fs, this);
			fs.Close();
		}
		
		public void start()
		{
		//	if(this.started == false)
		//	{
				//this.started = true;
				int old_index = this.fb_index;
				this.fb_index = tools.get_largest(this.field);
				this.writeFile();
				File.Delete(토론.cur_dir + "대기/" + old_index.ToString() + "-0");
		//	}
		}
		/*public static fboard readFile(string field, int fb_index)			//파일에서 읽어옴 *-0
		{
			fboard fb;
			string filename = field + "/" + fb_index.ToString() + "-0";
			string file = 토론.cur_dir + "fboard/" + filename;
			FileStream fs = File.OpenRead(file);
			BinaryFormatter bf = new BinaryFormatter();
			fb = (fboard)bf.Deserialize(fs);
			fs.Close();
			return fb;
		}*/
		public static fboard readFile(string field, int fb_index, int page_index)
		{
			fboard fb;
			string filename = field + "/" + fb_index.ToString() + "-" + page_index.ToString();
			FileStream fs = File.OpenRead(토론.cur_dir + filename);
			BinaryFormatter bf = new BinaryFormatter();
			fb = (fboard)bf.Deserialize(fs);
			fs.Close();
			return fb;
		}

	}

}
