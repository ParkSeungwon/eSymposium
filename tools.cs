using System;
using System.IO;
using System.Data;

namespace startpage
{
	/// <summary>
	/// txtinfo에 대한 요약 설명입니다.
	/// </summary>
	public class tools
	{
		private string file;
		private string tmp = 토론.cur_dir + "data/temp.txt";
		public tools(string dir, string file)
		{
			//
			// TODO: 여기에 생성자 논리를 추가합니다.
			//
			this.file = 토론.cur_dir + dir + "/" + file;
		}
		public void appendline(string toappend)		//filenotfound = -1,  실행시 줄번호리턴
		{
			StreamWriter sw = File.AppendText(this.file);
			sw.WriteLine(toappend);
			sw.Close();
		}
		public void deleteline(int line)
		{
			StreamReader sr = File.OpenText(this.file);
			StreamWriter sw = File.CreateText(tmp);
			for(int i = 1; i < line; i++) sw.WriteLine(sr.ReadLine());
			sr.ReadLine();
			string str;
			while ((str = sr.ReadLine()) != null) sw.WriteLine(str);
			sr.Close();
			sw.Close();
			File.Copy(tmp, file, true);
			File.Delete(tmp);
		}
		public string readline(int line)
		{
			StreamReader sr = File.OpenText(this.file);
			for(int i = 1; i < line; i++) sr.ReadLine();
			string str = sr.ReadLine();
			sr.Close();
			return str;
		}
		public void replaceline(int line, string toreplace)
		{
			StreamReader sr = File.OpenText(this.file);
			StreamWriter sw = File.CreateText(tmp);
			for(int i = 1; i < line; i++) sw.WriteLine(sr.ReadLine());
			sr.ReadLine();
			sw.WriteLine(toreplace);
			string str;
			while ((str = sr.ReadLine()) != null) sw.WriteLine(str);
			sr.Close();
			sw.Close();
			File.Copy(tmp, file, true);
			File.Delete(tmp);
		}
		public int existline(string tofind)
		{
			StreamReader sr = File.OpenText(file);
			string str;// = sr.ReadLine();
			int line = 0;
			while((str = sr.ReadLine()) != null)
			{
				line++;
				if(str == tofind) 
				{
					sr.Close();
					return line;
				}
			}
			sr.Close();
			return 0;					
		}
		public static void mail(string id, string content)
		{
			tools t = new tools("mail", id);
			t.appendline(content);
		}
		public static int str2int(string str)
		{
			int x = str.Length;
			int sum = 0;
			if(x != 0) for(int i = 1; i<=x; i++) sum += (int)Math.Pow(10,(x-i))*(str[i-1]-'0');
			return sum;
		}
		public static int get_largest(string dir)
		{
			DirectoryInfo di = new DirectoryInfo(토론.cur_dir + dir + "/");
			FileInfo[] fi = di.GetFiles("*-0");
			int i = 0;
			foreach(FileInfo f in fi)
			{
				int j = tools.str2int(f.Name.Remove(f.Name.Length-2, 2));
				if(j > i) i = j;
			}
			return i+1;
		}
		public static int get_largest_b(string dir)
		{
			DirectoryInfo di = new DirectoryInfo(토론.cur_dir + dir + "/");
			FileInfo[] fi = di.GetFiles("*");
			int i = 0;
			foreach(FileInfo f in fi)
			{
				int j = tools.str2int(f.Name);
				if(j > i) i = j;
			}
			return i+1;
		}

	}
}
