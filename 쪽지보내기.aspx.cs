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
	/// 쪽지보내기에 대한 요약 설명입니다.
	/// </summary>
	public class 쪽지보내기 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button ok;
		protected System.Web.UI.WebControls.TextBox mail;
		protected System.Web.UI.WebControls.TextBox id;
		protected System.Web.UI.WebControls.Button cancel;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 여기에 사용자 코드를 배치하여 페이지를 초기화합니다.
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
			this.mail.TextChanged += new System.EventHandler(this.mail_TextChanged);
			this.ok.Click += new System.EventHandler(this.ok_Click);
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ok_Click(object sender, System.EventArgs e)
		{
			if(member_access.return_pass(id.Text) == null) show("그런 아이디가 없습니다.");
			else
			{
				string file = 토론.cur_dir + "mail/" + id.Text;
				StreamWriter sw;
				if(File.Exists(file)) sw = File.AppendText(file);
				else sw = File.CreateText(file);
				//sw.WriteLine(mail.Text);
				sw.WriteLine("보낸이 : " + User.Identity.Name + "    작성일 : " + DateTime.Now.ToString());
				sw.WriteLine(mail.Text);
				sw.WriteLine("--------------------------------------------------------------");
				sw.Close();
				Response.Redirect("index.aspx");
			}
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

		private void mail_TextChanged(object sender, System.EventArgs e)
		{
		
		}

				 
	}
}
