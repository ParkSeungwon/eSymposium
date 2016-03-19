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
	/// 쪽지읽기에 대한 요약 설명입니다.
	/// </summary>
	public class 쪽지읽기 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox mail;
		protected System.Web.UI.WebControls.Label id;
		protected System.Web.UI.WebControls.Button ok;
		protected System.Web.UI.WebControls.Button delete;
		protected System.Web.UI.HtmlControls.HtmlForm 쪽지보내기;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				id.Text = User.Identity.Name + "님에게 온 쪽지입니다.";
				if(File.Exists(토론.cur_dir + "mail/" + User.Identity.Name))
				{
					StreamReader sw = File.OpenText(토론.cur_dir + "mail/" + User.Identity.Name);
					mail.Text = sw.ReadToEnd();
					sw.Close();
				}
				else delete.Enabled = false;
			}
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
			this.delete.Click += new System.EventHandler(this.delete_Click);
			this.ok.Click += new System.EventHandler(this.ok_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void delete_Click(object sender, System.EventArgs e)
		{
			File.Delete(토론.cur_dir + "mail/" + User.Identity.Name);
			Response.Redirect("index.aspx");
		}

		private void ok_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("index.aspx");
		}
	}
}
