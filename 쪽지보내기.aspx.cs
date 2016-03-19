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
using System.IO;

namespace startpage
{
	/// <summary>
	/// ���������⿡ ���� ��� �����Դϴ�.
	/// </summary>
	public class ���������� : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button ok;
		protected System.Web.UI.WebControls.TextBox mail;
		protected System.Web.UI.WebControls.TextBox id;
		protected System.Web.UI.WebControls.Button cancel;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// ���⿡ ����� �ڵ带 ��ġ�Ͽ� �������� �ʱ�ȭ�մϴ�.
			if(!IsPostBack)
			{
				id.Text = Request.QueryString["id"];
				if(User.Identity.IsAuthenticated) ok.Enabled = true;
				else ok.Enabled = false;
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
			this.mail.TextChanged += new System.EventHandler(this.mail_TextChanged);
			this.ok.Click += new System.EventHandler(this.ok_Click);
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ok_Click(object sender, System.EventArgs e)
		{
			if(member_access.return_pass(id.Text) == null) show("�׷� ���̵� �����ϴ�.");
			else
			{
				string file = ���.cur_dir + "mail/" + id.Text;
				StreamWriter sw;
				if(File.Exists(file)) sw = File.AppendText(file);
				else sw = File.CreateText(file);
				//sw.WriteLine(mail.Text);
				sw.WriteLine("������ : " + User.Identity.Name + "    �ۼ��� : " + DateTime.Now.ToString());
				sw.WriteLine(mail.Text);
				sw.WriteLine("--------------------------------------------------------------");
				sw.Close();
				Response.Redirect("index.aspx");
			}
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
		private void cancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("index.aspx");
		}

		private void mail_TextChanged(object sender, System.EventArgs e)
		{
		
		}

				 
	}
}
