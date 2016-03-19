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
	/// 로그인에 대한 요약 설명입니다.
	/// </summary>
	public class 로그인 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.WebControls.Button btnAuth;
		protected System.Web.UI.WebControls.TextBox password;
		protected System.Web.UI.WebControls.Button cancel;
		protected System.Web.UI.WebControls.TextBox id;
	
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
			if(member_access.return_pass(id.Text) == password.Text) 
			{
				FormsAuthentication.SetAuthCookie(id.Text, false);
				lblMsg.Text = "로그인에 성공했습니다.";
				if(File.Exists(토론.cur_dir + "mail/" + id.Text))
				{
					show("쪽지가 도착했습니다.");
					Response.Redirect("쪽지읽기.aspx");
				}
				Response.Redirect("index.aspx");
			}
			else lblMsg.Text = "로그인에 실패하였습니다.";
		}

	
		public void show(string str)
		{
			//
			// 자바스크립트 메시지 박스
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
