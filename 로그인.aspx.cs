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
using System.Web.Security;
using System.IO;

namespace startpage
{
	/// <summary>
	/// �α��ο� ���� ��� �����Դϴ�.
	/// </summary>
	public class �α��� : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.WebControls.Button btnAuth;
		protected System.Web.UI.WebControls.TextBox password;
		protected System.Web.UI.WebControls.Button cancel;
		protected System.Web.UI.WebControls.TextBox id;
	
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
			this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAuth_Click(object sender, System.EventArgs e)
		{
			if(member_access.return_pass(id.Text) == password.Text) 
			{
				FormsAuthentication.SetAuthCookie(id.Text, false);
				lblMsg.Text = "�α��ο� �����߽��ϴ�.";
				if(File.Exists(���.cur_dir + "mail/" + id.Text))
				{
					show("������ �����߽��ϴ�.");
					Response.Redirect("�����б�.aspx");
				}
				Response.Redirect("index.aspx");
			}
			else lblMsg.Text = "�α��ο� �����Ͽ����ϴ�.";
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
	}
}
