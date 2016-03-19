using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


namespace startpage
{
	/// <summary>
	/// ȸ���������濡 ���� ��� �����Դϴ�.
	/// </summary>
	public class ȸ���������� : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox id;
		protected System.Web.UI.WebControls.TextBox password1;
		protected System.Web.UI.WebControls.Button pass_change;
		protected System.Web.UI.WebControls.TextBox name;
		protected System.Web.UI.WebControls.CheckBox name_o;
		protected System.Web.UI.WebControls.TextBox numfore;
		protected System.Web.UI.WebControls.TextBox numback;
		protected System.Web.UI.WebControls.TextBox addressfore;
		protected System.Web.UI.WebControls.CheckBox addressfore_o;
		protected System.Web.UI.WebControls.TextBox addressback;
		protected System.Web.UI.WebControls.TextBox tel;
		protected System.Web.UI.WebControls.TextBox mobile;
		protected System.Web.UI.WebControls.TextBox email;
		protected System.Web.UI.WebControls.CheckBox email_o;
		protected System.Web.UI.WebControls.CheckBox history_o;
		protected System.Web.UI.WebControls.TextBox history;
		protected System.Web.UI.WebControls.CheckBox concern_o;
		protected System.Web.UI.WebControls.TextBox concern;
		protected System.Web.UI.WebControls.Button ok;
		protected System.Web.UI.WebControls.Button cancel;
		protected System.Web.UI.WebControls.Button picture;
		protected System.Web.UI.HtmlControls.HtmlForm ȸ������;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// ���⿡ ����� �ڵ带 ��ġ�Ͽ� �������� �ʱ�ȭ�մϴ�.
			if(!IsPostBack) 
			{
				LoadUserInfo();
				
			}
		}
		

		private void LoadUserInfo()
		{
			string ID = User.Identity.Name;
			SqlConnection Con = new SqlConnection(ConfigurationSettings.AppSettings["connstr"]);
			SqlCommand Cmd = new SqlCommand();
			Cmd.Connection = Con;
			Cmd.CommandText = "SELECT * FROM ȸ������ WHERE ���̵� = @ID";
			Cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
			Cmd.Parameters["@ID"].Value = ID;

			try
			{
				Con.Open();
				SqlDataReader dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
				if(dr.Read())
				{
					id.Text = ID;
					name.Text = dr["�̸�"].ToString();
					name_o.Checked = (bool)dr["�̸�����"];
					numfore.Text = dr["�ֹι�ȣ"].ToString().Remove(6, 7);
					numback.Text = dr["�ֹι�ȣ"].ToString().Remove(0, 6);
					addressfore.Text = dr["�ּҾ�"].ToString();
					addressfore_o.Checked = (bool)dr["�ּҰ���"];
					addressback.Text = dr["�ּҵ�"].ToString();
					tel.Text = dr["��ȭ��ȣ"].ToString();
					mobile.Text = dr["�޴�����ȣ"].ToString();
					email.Text = dr["�̸����ּ�"].ToString();
					email_o.Checked = (bool)dr["�̸��ϰ���"];
					history.Text = dr["���"].ToString();
					history_o.Checked = (bool)dr["��°���"];
					concern.Text = dr["���ɺо�"].ToString();
					concern_o.Checked = (bool)dr["���ɺо߰���"];
				}
				dr.Close();
			}
			catch(Exception ex)	
			{
				show(ex.Message);
			}
			finally 
			{
				Con.Close();
			}
		}


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �� ȣ���� ASP.NET Web Form �����̳ʿ� �ʿ��մϴ�.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����̳� ������ �ʿ��� �޼����Դϴ�.
		/// �� �޼����� ������ �ڵ� ������� �������� ���ʽÿ�.
		/// </summary>
		private void InitializeComponent()
		{    
			this.picture.Click += new System.EventHandler(this.picture_Click);
			this.pass_change.Click += new System.EventHandler(this.pass_change_Click);
			this.ok.Click += new System.EventHandler(this.ok_Click);
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ok_Click(object sender, System.EventArgs e)
		{
			if(member_access.return_pass(User.Identity.Name) == password1.Text) update();
			else show("�н����尡 Ʋ���ϴ�.");
		}
		public void show(string str)
		{
			//
			// �ڹٽ�ũ��Ʈ �޽��� �ڽ�
			//
			Response.Write("<script>");
			Response.Write("alert('" + str + "');");
			Response.Write("</script>");
		}
		private void update()
		{
			string ID = User.Identity.Name;
			
			SqlConnection Con = new SqlConnection(ConfigurationSettings.AppSettings["connstr"]);
			SqlCommand Cmd = new SqlCommand();
			Cmd.Connection = Con;
			Cmd.CommandText = "Update ȸ������ SET �̸����� = @NAMEO, �ּҾ� = @ADDRF, �ּҵ� = @ADDRB, �ּҰ��� = @ADDRO, ��ȭ��ȣ = @TEL, �޴�����ȣ = @MOBILE, �̸����ּ� = @EMAIL,  �̸��ϰ���  = @EMAILO, ��� = @HISTORY, ��°���  = @HISTORYO, ���ɺо� = @CONCERN,  ���ɺо߰��� = @CONCERNO WHERE ���̵� = @ID";
			
			Cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
			Cmd.Parameters.Add("@NAMEO", SqlDbType.Bit);
			Cmd.Parameters.Add("@ADDRF", SqlDbType.VarChar, 50);
			Cmd.Parameters.Add("@ADDRB", SqlDbType.VarChar, 50);
			Cmd.Parameters.Add("@ADDRO", SqlDbType.Bit);
			Cmd.Parameters.Add("@TEL", SqlDbType.VarChar, 20);
			Cmd.Parameters.Add("@MOBILE", SqlDbType.VarChar, 20);
			Cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 30);
			Cmd.Parameters.Add("@EMAILO", SqlDbType.Bit);
			Cmd.Parameters.Add("@HISTORY", SqlDbType.Text);
			Cmd.Parameters.Add("@HISTORYO", SqlDbType.Bit);
			Cmd.Parameters.Add("@CONCERN", SqlDbType.Text);
			Cmd.Parameters.Add("@CONCERNO", SqlDbType.Bit);

			Cmd.Parameters["@ID"].Value = ID;
			Cmd.Parameters["@NAMEO"].Value = name_o.Checked;
			Cmd.Parameters["@ADDRF"].Value = addressfore.Text;
			Cmd.Parameters["@ADDRB"].Value = addressback.Text;
			Cmd.Parameters["@ADDRO"].Value = addressfore_o.Checked;
			Cmd.Parameters["@TEL"].Value = tel.Text;
			Cmd.Parameters["@MOBILE"].Value = mobile.Text;
			Cmd.Parameters["@EMAIL"].Value = email.Text;
			Cmd.Parameters["@EMAILO"].Value = email_o.Checked;
			Cmd.Parameters["@HISTORY"].Value = history.Text;
			Cmd.Parameters["@HISTORYO"].Value = history_o.Checked;
			Cmd.Parameters["@CONCERN"].Value = concern.Text;
			Cmd.Parameters["@CONCERNO"].Value = concern_o.Checked;

			try
			{
				Con.Open();
				Cmd.ExecuteNonQuery();
				show("������ ����Ǿ����ϴ�.");
			}
			catch(Exception ex)
			{
				show(ex.Message);
			}
			finally
			{
				Con.Close();
				Response.Redirect("��������.aspx");
			}
		}

		private void cancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("index.aspx");
		}

		private void pass_change_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("��ȣ����.aspx");
		}

		private void picture_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("�������.aspx");
		}

	


	}
	}

