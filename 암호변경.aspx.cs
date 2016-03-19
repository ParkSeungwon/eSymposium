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
	/// 암호변경에 대한 요약 설명입니다.
	/// </summary>
	public class 암호변경 : System.Web.UI.Page
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
			// 여기에 사용자 코드를 배치하여 페이지를 초기화합니다.
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 이 호출은 ASP.NET Web Form 디자이너에 필요합니다.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
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
				lblMsg.Text = "패스워드가 변경되었습니다.";
			}
			else lblMsg.Text = "패스워드가 틀립니다.";

		}

		private void cancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("회원정보변경.aspx");
		}

	
	}
}
