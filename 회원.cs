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
	/// ��п� ���� ��� �����Դϴ�. ȸ���� �Խ��� Ŭ����
	/// </summary>
	/// 
	
	public enum Level {anony, free, payed, root}

	public class ���				//�������� Ŭ����
	{
		
		public static string cur_dir = @"D:\ftp\esymposium(500)\";  //@"C:\inetpub\wwwroot\startpage\";
		public static Level level;
		//public static int fb_index = 0, page_index = 0;		//���纸���� ��ġǥ��
		//public static ArrayList invited_ids = new ArrayList();
		public static string msg;
      	private ���() {}									//�ν��Ͻ� ���� �Ұ�
	}

	public class member 
	{
		public string id = "";
		public string password;
		public Level level;
		public string name;
		public bool name_o;					//����,�����
		public string addressfore, addressback;
		public bool addressfore_o;
		public string tel;
		public string mobile;
		public string email;
		public bool email_o;
		public string num;					//�ֹι�ȣ
		public string history;				//���, ����, ����
		public bool history_o;				//����, �����
		public string group;				//����
		//public bool[] concern_b;// ��ġ, ����, ��ȸ, ��ȭ, ����, ��ǻ��, �ǰ�, ����,ö��, ����, ���, ����, ����;	
		//���ɺо�,Ȯ���ؾ���
		public bool concern_o;
		public string concern;
	}
	
	public class member_access
	{
		private member mem = new member();					//���ǽ� ���
		protected DataSet ds;
		private FileStream fs;

		public member_access(member m)
		{
//			read();				//������ �о� ����Ÿ�¿� ä��
			���.msg += m.id;
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
			cmd.CommandText = "SELECT * FROM ȸ������ WHERE ���̵� = @ID";
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
					���.msg += dr["�̸����ּ�"].ToString();
					//m.password = dr["�н�����"].ToString();
					m.name = dr["�̸�"].ToString();
					m.name_o = (bool)dr["�̸�����"];
					m.num = dr["�ֹι�ȣ"].ToString();
					m.addressfore = dr["�ּҾ�"].ToString();
					m.addressfore_o = (bool)dr["�ּҰ���"];
					m.addressback = dr["�ּҵ�"].ToString();
					m.email = dr["�̸����ּ�"].ToString();
					m.email_o = (bool)dr["�̸����ּҰ���"];
					m.concern_o = (bool)dr["���ɺо߰���"];
					m.concern = dr["���ɺо�"].ToString();
					m.group = dr["�׷�"].ToString();
					m.tel = dr["��ȭ��ȣ"].ToString();
					m.mobile = dr["�޴�����ȣ"].ToString();
					m.history = dr["���"].ToString();
					m.history_o = (bool)dr["��°���"];
					m.level = (Level)dr["����"];
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
			cmd.CommandText = "select �н����� from �α������� where ���̵� = @ID";
			cmd.Connection = con;
			cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
			cmd.Parameters["@ID"].Value = id;
			con.Open();
			pass = (string)cmd.ExecuteScalar();
			con.Close();
			���.msg += "dn";
			���.msg += pass;
			return pass;
		}
		public static string return_history(string id)
		{
			string pass;
			SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connstr"]);
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "select ��� from ȸ������ where ���̵� = @ID";
			cmd.Connection = con;
			cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
			cmd.Parameters["@ID"].Value = id;
			con.Open();
			pass = (string)cmd.ExecuteScalar();
			con.Close();
			���.msg += "dn";
			���.msg += pass;
			return pass;
		}
		public static bool return_history_o(string id)
		{
			bool pass;
			SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connstr"]);
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "select ��°��� from ȸ������ where ���̵� = @ID";
			cmd.Connection = con;
			cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
			cmd.Parameters["@ID"].Value = id;
			con.Open();
			pass = (bool)cmd.ExecuteScalar();
			con.Close();
			���.msg += "dn";
			���.msg += pass;
			return pass;
		}
		public static object return_level(string id)
		{
			SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connstr"]);
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = con;
			cmd.CommandText = "select ���� from �α������� where ���̵� = @ID";
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
			cmd.CommandText = "update �α������� set �н����� = @password where ���̵� = @ID";
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
			cmd.CommandText = "update �α������� set ���� = @level where ���̵� = @ID";
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