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

namespace startpage
{
	/// <summary>
	/// ��ȣ���濡 ���� ��� �����Դϴ�.
	/// </summary>
	public class ��ȣ���� : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.WebControls.Button btnAuth;
		protected System.Web.UI.WebControls.TextBox pass2;
		protected System.Web.UI.WebControls.TextBox pass1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.Button cancel;
		protected System.Web.UI.WebControls.TextBox pre_pass;
	
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
			if(member_access.return_pass(User.Identity.Name) == pre_pass.Text) 
			{
				member_access.set_pass(User.Identity.Name, pass1.Text);
				lblMsg.Text = "�н����尡 ����Ǿ����ϴ�.";
			}
			else lblMsg.Text = "�н����尡 Ʋ���ϴ�.";

		}

		private void cancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ȸ����������.aspx");
		}

	
	}
}
