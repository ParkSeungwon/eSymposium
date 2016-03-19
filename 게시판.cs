using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;


namespace startpage
{
	/// <summary>
	/// �Խ��ǿ� ���� ��� �����Դϴ�.
	/// </summary>
	public class �Խ���
	{
		public �Խ���()
		{
			//
			// TODO: ���⿡ ������ ���� �߰��մϴ�.
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
			this.id = id;								//�۾���
			this.text = text;		//����
			this.date = DateTime.Now;		//�ۼ�����
		}
	/*	public bool check_him()						//���Ѱ˻�. �������̵��
		{
			if( == id) return true;
			else return false;
		}*/
		public void change(string text)				//�����޼ҵ�
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
		public ArrayList subcomment;			//�ڸ�Ʈ �迭
		protected int hit = 0;							//��ȸ��
		public int page_index;
		public string title;							//����
		//public string field;
		//protected string filename;						//1-0, 1-1, 1-12, 1+id������ ���ϸ��� ���Ѵ�.1-0�� ������

		public board(string title, string id, string text) : base(id, text)
		{
			this.title = title;
			//this.filename = filename;
			//page_index = ���.page_index;
			//filename = ���.fb_index.ToString() + "-" + page_index.ToString();
			subcomment = new ArrayList();
		}
		/*public bool check_logged()
		{
			if(���.cur_id == null || ���.cur_id == "") return false;
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
			FileStream fs = File.Create(���.cur_dir + field + "/" + index);
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(fs, this);
			fs.Close();
		}
		public static board readFile(string field, string index)
		{
			board b;
			FileStream fs = File.OpenRead(���.cur_dir + field + "/" + index);
			BinaryFormatter bf = new BinaryFormatter();
			b = (board)bf.Deserialize(fs);
			fs.Close();
			return b;
		}
		public void show()			//�׸��忡 ǥ��
		{
			hit++;
		}
			
		public virtual int get_hit() {return hit;}
	}

	[Serializable]
	public class fboard : board
	{
		public int response_term;		//ȸ�� �Ⱓ
		public int fb_index;
		public ArrayList ids = new ArrayList();				//���� �շ��� ���̵��
		public bool inturn = true;		//���ʷ� �Ұ�����
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
			this.fb_index = tools.get_largest("���");
			//fb_index = this.filenum();
			//this.filename = fb_index.ToString() + "-0"; //filenum�� �ѹ��� ����
		}

		public int get_fb_index() {return this.fb_index;}
		//public bool get_started() {return this.started;}
		/*public int get_totalhit()			//�� �Ķ󺸵��� ��ȸ���� ���Ͽ� ������.
		{
			ArrayList al = new ArrayList();
			DirectoryInfo dir = new DirectoryInfo(���.cur_dir + "fboard/");
			FileInfo[] boardfiles = dir.GetFiles(filename + "-*");
			BinaryFormatter bf = new BinaryFormatter();
			int i = 0;
			foreach (FileInfo f in boardfiles)	
			{
				FileStream fs = File.OpenRead(���.cur_dir + "fboard/" + f.Name);
				i += ((board)bf.Deserialize(fs)).get_hit();
				fs.Close();
			}
			return i;
		}*/
		public bool get_intern(){return this.inturn;}
		public bool check_writable(){return this.write;}
		public bool check_readable(){return this.read;}
		public bool check_votable(){return this.vote;}
		
		public void writeFile()			//���Ͽ� ����
		{
			string file = "/" + this.fb_index.ToString() + "-" + this.page_index.ToString();
			file = ���.cur_dir + this.field + file;
			FileStream fs = File.Create(file);
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(fs, this);
			fs.Close();
		}
		public void deleteFile()
		{
			string file = "/" + this.fb_index.ToString() + "-" + this.page_index.ToString();
			file = ���.cur_dir + this.field + file;
            File.Delete(file);
		}
		public void writewait()
		{
			string file = "/" + this.fb_index.ToString() + "-" + this.page_index.ToString();
			file = ���.cur_dir + "���" + file;
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
				File.Delete(���.cur_dir + "���/" + old_index.ToString() + "-0");
		//	}
		}
		/*public static fboard readFile(string field, int fb_index)			//���Ͽ��� �о�� *-0
		{
			fboard fb;
			string filename = field + "/" + fb_index.ToString() + "-0";
			string file = ���.cur_dir + "fboard/" + filename;
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
			FileStream fs = File.OpenRead(���.cur_dir + filename);
			BinaryFormatter bf = new BinaryFormatter();
			fb = (fboard)bf.Deserialize(fs);
			fs.Close();
			return fb;
		}

	}

}
