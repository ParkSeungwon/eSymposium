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
	/// 관리자페이지에 대한 요약 설명입니다.
	/// </summary>
	public class 관리자페이지 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox title;
		protected System.Web.UI.WebControls.TextBox field;
		protected System.Web.UI.WebControls.TextBox num;
		protected System.Web.UI.WebControls.Label Label;
		protected System.Web.UI.WebControls.Button totop;
	
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
			this.totop.Click += new System.EventHandler(this.totop_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void totop_Click(object sender, System.EventArgs e)
		{
			StreamWriter sr = File.AppendText(토론.cur_dir + "data/top.txt");
			sr.WriteLine(title.Text);
			sr.WriteLine(field.Text);
			sr.WriteLine(num.Text);
			sr.Close();
			Label.Text = "등록이 되었습니다.";
			title.Text = "";
			field.Text = "";
			num.Text = "";
		}
	}
}
