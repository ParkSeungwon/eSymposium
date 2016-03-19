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

namespace startpage
{
	/// <summary>
	/// ȸ�����Կ� ���� ��� �����Դϴ�.
	/// </summary>
	public class ȸ������ : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox concern;
		protected System.Web.UI.WebControls.CheckBox concern_o;
		protected System.Web.UI.WebControls.TextBox history;
		protected System.Web.UI.WebControls.CheckBox history_o;
		protected System.Web.UI.WebControls.CheckBox email_o;
		protected System.Web.UI.WebControls.TextBox email;
		protected System.Web.UI.WebControls.TextBox mobile;
		protected System.Web.UI.WebControls.TextBox tel;
		protected System.Web.UI.WebControls.TextBox addressback;
		protected System.Web.UI.WebControls.CheckBox addressfore_o;
		protected System.Web.UI.WebControls.TextBox addressfore;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.TextBox numback;
		protected System.Web.UI.WebControls.TextBox numfore;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.CheckBox name_o;
		protected System.Web.UI.WebControls.TextBox name;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.TextBox password2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox password1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox id2;
		protected System.Web.UI.WebControls.TextBox id;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.WebControls.Button ok;
		protected System.Web.UI.WebControls.Button pass_change;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// ���⿡ ����� �ڵ带 ��ġ�Ͽ� �������� �ʱ�ȭ�մϴ�.

			
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.ok.Click += new System.EventHandler(this.ok_Click);
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			if(member_access.return_pass(id2.Text) == null)
			{
				id.Text = id2.Text;
				show("��밡���մϴ�.");
			}
			else show("�̹� ���ǰ� �ִ� ���̵��Դϴ�.");
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

		private void ok_Click(object sender, System.EventArgs e)
		{
			SqlConnection Con = new SqlConnection(ConfigurationSettings.AppSettings["connstr"]);
			SqlCommand Cmd = new SqlCommand();
			SqlCommand Cmd2 = new SqlCommand();
			Cmd.Connection = Con;
			Cmd2.Connection = Con;
			Cmd.CommandText = "INSERT INTO �α������� (���̵�, �н�����, ����) VALUES (@ID, @PWD, @LEVEL)";
			Cmd2.CommandText = "INSERT INTO ȸ������ (���̵�, �̸�, �̸�����, �ֹι�ȣ, �ּҾ�, �ּҰ���, �ּҵ�, ��ȭ��ȣ, �޴�����ȣ, �̸����ּ�, �̸��ϰ���, ���, ��°���, ���ɺо�, ���ɺо߰���) "
				+ "VALUES (@ID, @NAME, @NAMEO, @NUM, @ADDRF, @ADDRO, @ADDRB, @TEL, @MOBILE, @EMAIL, @EMAILO, @HISTORY, @HISTORYO, @CONCERN, @CONCERNO)";

			
			Cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
			Cmd.Parameters.Add("@PWD", SqlDbType.VarChar, 20);
			Cmd.Parameters.Add("@LEVEL", SqlDbType.TinyInt, 1);

			Cmd.Parameters["@ID"].Value = id.Text;
			Cmd.Parameters["@PWD"].Value = password1.Text;
			Cmd.Parameters["@LEVEL"].Value = Level.free;

			Cmd2.Parameters.Add("@ID", SqlDbType.VarChar, 20);
			Cmd2.Parameters.Add("@NAME", SqlDbType.VarChar, 20);
			Cmd2.Parameters.Add("@NAMEO", SqlDbType.Bit);
			Cmd2.Parameters.Add("@NUM", SqlDbType.VarChar, 13);
			Cmd2.Parameters.Add("@ADDRF", SqlDbType.VarChar, 50);
			Cmd2.Parameters.Add("@ADDRB", SqlDbType.VarChar, 50);
			Cmd2.Parameters.Add("@ADDRO", SqlDbType.Bit);
			Cmd2.Parameters.Add("@TEL", SqlDbType.VarChar, 20);
			Cmd2.Parameters.Add("@MOBILE", SqlDbType.VarChar, 20);
			Cmd2.Parameters.Add("@EMAIL", SqlDbType.VarChar, 30);
			Cmd2.Parameters.Add("@EMAILO", SqlDbType.Bit);
			Cmd2.Parameters.Add("@HISTORY", SqlDbType.Text);
			Cmd2.Parameters.Add("@HISTORYO", SqlDbType.Bit);
			Cmd2.Parameters.Add("@CONCERN", SqlDbType.Text);
			Cmd2.Parameters.Add("@CONCERNO", SqlDbType.Bit);

			Cmd2.Parameters["@ID"].Value = id.Text;
			Cmd2.Parameters["@NAME"].Value = name.Text;
			Cmd2.Parameters["@NAMEO"].Value = name_o.Checked;
			Cmd2.Parameters["@NUM"].Value = numfore.Text + numback.Text;
			Cmd2.Parameters["@ADDRF"].Value = addressfore.Text;
			Cmd2.Parameters["@ADDRB"].Value = addressback.Text;
			Cmd2.Parameters["@ADDRO"].Value = addressfore_o.Checked;
			Cmd2.Parameters["@TEL"].Value = tel.Text;
			Cmd2.Parameters["@MOBILE"].Value = mobile.Text;
			Cmd2.Parameters["@EMAIL"].Value = email.Text;
			Cmd2.Parameters["@EMAILO"].Value = email_o.Checked;
			Cmd2.Parameters["@HISTORY"].Value = history.Text;
			Cmd2.Parameters["@HISTORYO"].Value = history_o.Checked;
			Cmd2.Parameters["@CONCERN"].Value = concern.Text;
			Cmd2.Parameters["@CONCERNO"].Value = concern_o.Checked;

			try
			{
				Con.Open();
				Cmd.ExecuteNonQuery();
				Cmd2.ExecuteNonQuery();
				show("������ ����Ǿ����ϴ�.");
			}
			catch(Exception ex)
			{
				show(ex.Message);
			}
			finally
			{
				Con.Close();
				tools t = new tools("group", "��� ������");
				t.appendline(id.Text);
				Response.Redirect("��������.aspx");
			}
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("index.aspx");
		}

	}
}
