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
	/// 사진등록에 대한 요약 설명입니다.
	/// </summary>
	public class 사진등록 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button upimage;
		protected System.Web.UI.WebControls.Image image;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileup;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 여기에 사용자 코드를 배치하여 페이지를 초기화합니다.
			if(User.Identity.IsAuthenticated)
			{
				tools t = new tools("data", "image.txt");
				int i = t.existline(User.Identity.Name);
				if((i%2) == 1) image.ImageUrl = "image/" + t.readline(i+1);
				else image.ImageUrl = "data/default.gif";
			}
			else Response.Redirect("index.aspx");
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
			this.upimage.Click += new System.EventHandler(this.upimage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void upimage_Click(object sender, System.EventArgs e)
		{
			if(fileup.PostedFile != null && fileup.PostedFile.ContentLength < 100000)
			{
				string dir = 토론.cur_dir + "image/";
				string id = User.Identity.Name;
				try
				{
					string wholepath = fileup.PostedFile.FileName.ToString();
					string filename = Path.GetFileName(wholepath);
					string unique = dir + filename;
					int j = 0;
					while(File.Exists(unique)) 
					{
						j++;
						unique = dir + j.ToString() + filename;
					}
					fileup.PostedFile.SaveAs(unique);
					tools t = new tools("data", "image.txt");
					int i = t.existline(id);
					if((i%2) == 1) 
					{
						File.Delete(dir + t.readline(i+1));
						t.replaceline(i+1, unique.Remove(0, dir.Length));
					}
					else
					{
						t.appendline(id);
						t.appendline(j.ToString() + filename);
					}
						
				}
				catch(Exception err)
				{
					show("Error : " + err.Message);
				}
			}
			else show("파일이 없거나 크기가 100KB 이상입니다.");
			Page_Load(this, EventArgs.Empty);
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

	
	}
}
