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
using System.Web.Security;



namespace startpage
{
	/// <summary>
	/// index2에 대한 요약 설명입니다.
	/// </summary>
	public class index2 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton log;
		protected System.Web.UI.WebControls.ImageButton logout;
		protected System.Web.UI.WebControls.ImageButton sign;
		protected System.Web.UI.WebControls.ListBox direct;
		protected System.Web.UI.WebControls.ImageButton change;
		private static ArrayList title = new ArrayList();
		private static ArrayList field = new ArrayList();
		private static ArrayList num = new ArrayList();
		protected System.Web.UI.WebControls.AdRotator ad;
		protected System.Web.UI.WebControls.DataList books;
		private static ArrayList page = new ArrayList();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 여기에 사용자 코드를 배치하여 페이지를 초기화합니다.
			if(User.Identity.IsAuthenticated)				//페이지 로드시 로그인되었는지 확인하고 단추명 바꿈
			{
				logout.Visible = true;
				log.Visible = false;
				sign.Visible = false;
				change.Visible = true;
			}
			else
			{
				logout.Visible = false;
				log.Visible = true;
				sign.Visible = true;
				change.Visible = false;
			}
			if(!IsPostBack)
			{
				title.Clear();
				field.Clear();
				num.Clear();
				page.Clear();
				StreamReader sr = File.OpenText(토론.cur_dir + "data/top.txt");
				string str;
				while((str = sr.ReadLine()) != null)
				{
					title.Add(str);
					field.Add(sr.ReadLine());
					num.Add(sr.ReadLine());
					page.Add(sr.ReadLine());
				}
				sr.Close();
				direct.DataSource = title;
				direct.DataBind();
				direct.SelectedIndex = -1;
				
				DataTable dt = new DataTable("books");
				DataColumn imgsrc = new DataColumn("이미지경로");
				DataColumn bookname = new DataColumn("제목");
				bookname.DataType = System.Type.GetType("System.String");
				DataColumn author = new DataColumn("저자");
				DataColumn publish = new DataColumn("출판사");
				DataColumn pubdate = new DataColumn("출판일");
				dt.Columns.Add(imgsrc);
				dt.Columns.Add(author);
				dt.Columns.Add(bookname);
				dt.Columns.Add(publish);
				dt.Columns.Add(pubdate);
				sr = File.OpenText(토론.cur_dir + "data/books.txt");
				while((str = sr.ReadLine()) != null)
				{
					DataRow dr = dt.NewRow();
					dr["이미지경로"] = "data/" + str;
					dr["제목"] = sr.ReadLine();
					dr["저자"] = sr.ReadLine();
					dr["출판사"] = sr.ReadLine();
					dr["출판일"] = sr.ReadLine();
					dt.Rows.Add(dr);
				}
				sr.Close();
				books.DataSource = dt;
				books.DataBind();
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
			this.log.Click += new System.Web.UI.ImageClickEventHandler(this.log_Click);
			this.logout.Click += new System.Web.UI.ImageClickEventHandler(this.logout_Click);
			this.sign.Click += new System.Web.UI.ImageClickEventHandler(this.sign_Click);
			this.change.Click += new System.Web.UI.ImageClickEventHandler(this.change_Click);
			this.direct.SelectedIndexChanged += new System.EventHandler(this.direct_SelectedIndexChanged);
			this.books.SelectedIndexChanged += new System.EventHandler(this.books_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		
		private void logout_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			FormsAuthentication.SignOut();
			logout.Visible = false;
			log.Visible = true;
			sign.Visible = true;
			change.Visible = false;
		}

		private void sign_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("회원가입.aspx");
		}

		private void change_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("회원정보변경.aspx");
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

		private void log_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("로그인.aspx");
		}

		private void direct_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int i = direct.SelectedIndex;
			if(field[i].ToString() == "대기") Response.Redirect("create.aspx?num=" + num[i].ToString());
			else Response.Redirect("보드보기.aspx?num=" + num[i].ToString() + "&field=" + field[i].ToString() + "&page=" + 
					 page[i].ToString());
		}

		private void books_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		
	}
}
