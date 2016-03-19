using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Runtime.Serialization.Formatters.Binary;


namespace startpage
{
	/// <summary>
	/// boardlist에 대한 요약 설명입니다.
	/// </summary>
	public class boardlist : System.Web.UI.Page
	{
		private static DataTable fbtable; 
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button search;
		protected System.Web.UI.WebControls.TextBox search_text;
		protected System.Web.UI.WebControls.DropDownList drop;
		protected System.Web.UI.WebControls.DataGrid grid;
		protected System.Web.UI.WebControls.RadioButtonList fieldselect;
		private static string field = "대기";
		private static bool on = false;
		private static DataView dv;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 여기에 사용자 코드를 배치하여 페이지를 초기화합니다.
			if(!IsPostBack) 
			{
				string tmp = Request.QueryString["field"];
				if(tmp == null) field = "대기";
				else field = tmp;
				
				MakeTable();
				DirectoryInfo dir = new DirectoryInfo(토론.cur_dir + field + "/");
				FileInfo[] fbfiles = dir.GetFiles("*-0");
				BindData(fbfiles);
				dv = new DataView(fbtable);
				dv.Sort = "게시물번호 DESC";
				grid.DataSource = dv;
				grid.DataBind();
				switch (field) 
				{
					case "정치,경제,시사" :
						fieldselect.SelectedIndex = 0;
						break;
					case "학술" :
						fieldselect.SelectedIndex = 1;
						break;
					case "친목" :
						fieldselect.SelectedIndex = 2;
						break;
					case "대기" :
						fieldselect.SelectedIndex = 3;
						break;
				}
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
		private void MakeTable()
		{	
			fbtable = new DataTable("게시물 목록");
			fbtable.Columns.Clear();
			DataColumn num = new DataColumn("게시물번호");
			num.DataType = System.Type.GetType("System.Int32");
			DataColumn ids = new DataColumn("아이디");
			DataColumn title = new DataColumn("제목");
			DataColumn date = new DataColumn("작성일");
			date.DataType = System.Type.GetType("System.DateTime");
			DataColumn read = new DataColumn("열람");
			read.DataType = System.Type.GetType("System.Boolean");
			DataColumn write = new DataColumn("덧글");
			write.DataType = System.Type.GetType("System.Boolean");
			DataColumn vote = new DataColumn("투표");
			vote.DataType = System.Type.GetType("System.Boolean");
			DataColumn inturn = new DataColumn("차례로");
			inturn.DataType = System.Type.GetType("System.Boolean");
			DataColumn page = new DataColumn("페이지");
			page.DataType = System.Type.GetType("System.Int32");

			fbtable.Columns.Add(num);
			fbtable.Columns.Add(ids);
			fbtable.Columns.Add(title);
			fbtable.Columns.Add(date);
			fbtable.Columns.Add(read);
			fbtable.Columns.Add(write);
			fbtable.Columns.Add(vote);
			fbtable.Columns.Add(inturn);
			fbtable.Columns.Add(page);
		}
		private void BindData(FileInfo[] fbfiles)
		{
			fbtable.Clear();
			DirectoryInfo dir = new DirectoryInfo(토론.cur_dir + field + "/");
			foreach(FileInfo f in fbfiles) 
			{
				string s = f.Name;

				int i = tools.str2int(s.Remove(s.Length-2, 2));			//파일명에서 -0을 뺌
				fboard fb = fboard.readFile(f.DirectoryName.Remove(0, 토론.cur_dir.Length), i, 0);
				DataRow row = fbtable.NewRow();
				row["게시물번호"] = i;
				row["아이디"] = fb.get_id();
				row["제목"] = fb.title;
				row["작성일"] = fb.date;
				row["열람"] = fb.check_readable();
				row["덧글"] = fb.check_writable();
				row["투표"] = fb.check_votable();
				row["차례로"] = fb.get_intern();
				row["페이지"] = dir.GetFiles(s.Remove(s.Length-2, 2) + "-*").Length;

				fbtable.Rows.Add(row);
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
			this.fieldselect.SelectedIndexChanged += new System.EventHandler(this.fieldselect_SelectedIndexChanged);
			this.grid.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.grid_ItemCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.search.Click += new System.EventHandler(this.search_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{
				Response.Redirect("create.aspx?num=0");
			}
			else show("권한이 없습니다.");
		}
	
		
		private void grid_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName == "go")			//페이지변환 이벤트 피해감
			{
				if(field == "대기") Response.Redirect("create.aspx?num=" + e.Item.Cells[0].Text);
				else Response.Redirect("보드보기.aspx?num=" + e.Item.Cells[0].Text + "&page=0&field=" + field);
			}
			if(e.CommandName == "mail") 
			{
				fboard fb = fboard.readFile(field, tools.str2int(e.Item.Cells[0].Text), 0);
				Response.Redirect("쪽지보내기.aspx?id=" + fb.id);
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex = e.NewPageIndex;
			grid.DataSource = dv;
			grid.DataBind();
		}

		private void search_Click(object sender, System.EventArgs e)
		{
			if(drop.SelectedIndex == 0) dv.RowFilter = "아이디 LIKE '*" + search_text.Text + "*'";
			else dv.RowFilter = "제목 LIKE '*" + search_text.Text + "*'";
			grid.DataSource = dv;
			grid.CurrentPageIndex = 0;
			grid.DataBind();
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			if(on) 
			{
				dv.Sort = e.SortExpression;
				on = false;
			}
			else 
			{
				dv.Sort = e.SortExpression + " DESC";
				on = true;
			}
			grid.DataSource = dv;
			grid.DataBind();
		}	

		private void fieldselect_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			field = fieldselect.SelectedItem.Text;
			DirectoryInfo dir = new DirectoryInfo(토론.cur_dir + field + "/");
			FileInfo[] fbfiles = dir.GetFiles("*-0");
			BindData(fbfiles);
			dv = new DataView(fbtable);
			dv.Sort = "게시물번호 DESC";
			grid.DataSource = dv;
			grid.CurrentPageIndex = 0;
			grid.DataBind();
		}
	}
}
