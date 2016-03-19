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
	/// 게시판생성에 대한 요약 설명입니다.
	/// </summary>
	public class 게시판생성 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox title;
		protected System.Web.UI.WebControls.TextBox contents;
		protected System.Web.UI.WebControls.TextBox id;
		protected System.Web.UI.WebControls.DropDownList term;
		protected System.Web.UI.WebControls.CheckBox turn;
		protected System.Web.UI.WebControls.CheckBox view;
		protected System.Web.UI.WebControls.CheckBox comment;
		protected System.Web.UI.WebControls.CheckBox vote;
		protected System.Web.UI.WebControls.Button idsearch;
		protected System.Web.UI.WebControls.ListBox invited;
		protected System.Web.UI.WebControls.Button Button1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 여기에 사용자 코드를 배치하여 페이지를 초기화합니다.
			id.Text = User.Identity.Name;
			invited.DataSource = 토론.invited_ids;
			invited.DataBind();
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
			this.idsearch.Click += new System.EventHandler(this.idsearch_Click);
			this.turn.CheckedChanged += new System.EventHandler(this.turn_CheckedChanged);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			fboard fb = new fboard(토론.invited_ids, term.SelectedIndex, view.Checked, comment.Checked, 
				vote.Checked, turn.Checked, title.Text, User.Identity.Name, contents.Text);
			fb.writeFile();
			Response.Redirect("boardlist.aspx");
		}

		private void turn_CheckedChanged(object sender, System.EventArgs e)
		{
			if(turn.Checked == true) term.Enabled = true;
			else term.Enabled = false;
		}

		private void idsearch_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("idsearch.aspx");
		}

		private void invite_TextChanged(object sender, System.EventArgs e)
		{
		
		}
		
	}
}
