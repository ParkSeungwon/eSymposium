using System;
using System.IO;
using System.Collections;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Configuration;

namespace startpage 
{
	/// <summary>
	/// 토론에 대한 요약 설명입니다. 회원과 게시판 클래스
	/// </summary>
	/// 
	
	public enum Level {anony, free, payed, root}

	public class 토론				//전역변수 클래스
	{
		
		public static string cur_dir = @"D:\ftp\esymposium(500)\";  //@"C:\inetpub\wwwroot\startpage\";
		public static Level level;
		//public static int fb_index = 0, page_index = 0;		//현재보드의 위치표현
		//public static ArrayList invited_ids = new ArrayList();
		public static string msg;
      	private 토론() {}									//인스턴스 생성 불가
	}

	public class member 
	{
		public string id = "";
		public string password;
		public Level level;
		public string name;
		public bool name_o;					//공개,비공개
		public string addressfore, addressback;
		public bool addressfore_o;
		public string tel;
		public string mobile;
		public string email;
		public bool email_o;
		public string num;					//주민번호
		public string history;				//약력, 직업, 전공
		public bool history_o;				//공개, 비공개
		public string group;				//모임
		//public bool[] concern_b;// 정치, 경제, 사회, 문화, 종교, 컴퓨터, 건강, 과학,철학, 역사, 언어, 문학, 예술;	
		//관심분야,확장해야함
		public bool concern_o;
		public string concern;
	}
	
	public class member_access
	{
		private member mem = new member();					//조건식 멤버
		protected DataSet ds;
		private FileStream fs;

		public member_access(member m)
		{
//			read();				//파일을 읽어 데이타셋에 채움
			토론.msg += m.id;
			mem.id = m.id;
			mem.password = m.password;
			mem.level = m.level;
			mem.name = m.name;
			mem.name_o = m.name_o;
			mem.addressfore = m.addressfore;
			mem.addressback = m.addressback;
			mem.addressfore_o = m.addressfore_o;
			mem.tel = m.tel;
			mem.mobile = m.mobile;
			mem.email = m.email;
			mem.num = m.num;
			mem.group = m.group;
			mem.history = m.history;
			mem.history_o = m.history_o;
			mem.concern = m.concern;
			mem.concern_o = m.concern_o;
		}
		public static member return_member(string id)
		{
			member m = new member();
			SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connstr"]);
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = con;
			cmd.CommandText = "SELECT * FROM 회원정보 WHERE 아이디 = @ID";
			cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
			cmd.Parameters["@ID"].Value = id;
			SqlDataReader dr;
			try
			{
				con.Open();
				dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);//.SingleResult);
				if(dr.Read())
				{
					m.id = id;
					토론.msg += dr["이메일주소"].ToString();
					//m.password = dr["패스워드"].ToString();
					m.name = dr["이름"].ToString();
					m.name_o = (bool)dr["이름공개"];
					m.num = dr["주민번호"].ToString();
					m.addressfore = dr["주소앞"].ToString();
					m.addressfore_o = (bool)dr["주소공개"];
					m.addressback = dr["주소뒤"].ToString();
					m.email = dr["이메일주소"].ToString();
					m.email_o = (bool)dr["이메일주소공개"];
					m.concern_o = (bool)dr["관심분야공개"];
					m.concern = dr["관심분야"].ToString();
					m.group = dr["그룹"].ToString();
					m.tel = dr["전화번호"].ToString();
					m.mobile = dr["휴대폰번호"].ToString();
					m.history = dr["약력"].ToString();
					m.history_o = (bool)dr["약력공개"];
					m.level = (Level)dr["레벨"];
				}
				dr.Close();
			}
			catch(Exception ex) {}
			finally 
			{
				//dr.Close();
				con.Close();
			}	
			return m;
		}

		public static string return_pass(string id)
		{
			string pass;
			SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connstr"]);
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "select 패스워드 from 로그인정보 where 아이디 = @ID";
			cmd.Connection = con;
			cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
			cmd.Parameters["@ID"].Value = id;
			con.Open();
			pass = (string)cmd.ExecuteScalar();
			con.Close();
			토론.msg += "dn";
			토론.msg += pass;
			return pass;
		}
		public static string return_history(string id)
		{
			string pass;
			SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connstr"]);
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "select 약력 from 회원정보 where 아이디 = @ID";
			cmd.Connection = con;
			cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
			cmd.Parameters["@ID"].Value = id;
			con.Open();
			pass = (string)cmd.ExecuteScalar();
			con.Close();
			토론.msg += "dn";
			토론.msg += pass;
			return pass;
		}
		public static bool return_history_o(string id)
		{
			bool pass;
			SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connstr"]);
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "select 약력공개 from 회원정보 where 아이디 = @ID";
			cmd.Connection = con;
			cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
			cmd.Parameters["@ID"].Value = id;
			con.Open();
			pass = (bool)cmd.ExecuteScalar();
			con.Close();
			토론.msg += "dn";
			토론.msg += pass;
			return pass;
		}
		public static object return_level(string id)
		{
			SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connstr"]);
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = con;
			cmd.CommandText = "select 레벨 from 로그인정보 where 아이디 = @ID";
			cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
			cmd.Parameters["@ID"].Value = id;
			object o = 0;
			try
			{
				con.Open();
				o = cmd.ExecuteScalar();
			}
			catch(Exception ex) {}
			finally {con.Close();}	
			return o;
		}

		public static void set_pass(string id, string pass)
		{
			SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connstr"]);
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = con;
			cmd.CommandText = "update 로그인정보 set 패스워드 = @password where 아이디 = @ID";
			cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
			cmd.Parameters["@ID"].Value = id;
			cmd.Parameters.Add("@password", SqlDbType.VarChar, 20);
			cmd.Parameters["@password"].Value = pass;
			try
			{
				con.Open();
				cmd.ExecuteScalar();
			}
			catch(Exception ex) {}
			finally {con.Close();}	
		}
		public static void set_level(string id, Level lv)
		{
			SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connstr"]);
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = con;
			cmd.CommandText = "update 로그인정보 set 레벨 = @level where 아이디 = @ID";
			cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
			cmd.Parameters["@ID"].Value = id;
			cmd.Parameters.Add("@level", SqlDbType.TinyInt, 20);
			cmd.Parameters["@level"].Value = lv;
			try
			{
				con.Open();
				cmd.ExecuteScalar();
			}
			catch(Exception ex) {}
			finally {con.Close();}	
		}

	

	}
	
}