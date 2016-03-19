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
	/// creategroup에 대한 요약 설명입니다.
	/// </summary>
	public class creategroup : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button open;
		protected System.Web.UI.WebControls.TextBox explain;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Button tomain;
		protected System.Web.UI.WebControls.TextBox name;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 여기에 사용자 코드를 배치하여 페이지를 초기화합니다.
			if(!IsPostBack)
			{
				if(User.Identity.IsAuthenticated) open.Enabled = true;
				else open.Enabled = false;
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
			this.open.Click += new System.EventHandler(this.open_Click);
			this.tomain.Click += new System.EventHandler(this.tomain_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void open_Click(object sender, System.EventArgs e)
		{
			if(File.Exists(토론.cur_dir + "group/" + name.Text)) show("그룹명이 이미 존재합니다.");
			else 
			{
				StreamWriter sw = File.CreateText(토론.cur_dir + "group/" + name.Text);
				sw.WriteLine(explain.Text);
				sw.WriteLine(User.Identity.Name);
				sw.Close();
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

		private void tomain_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("index.aspx");
		}
	}
}
