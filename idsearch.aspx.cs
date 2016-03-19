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
	/// idsearch에 대한 요약 설명입니다.
	/// </summary>
	public class idsearch : System.Web.UI.Page
	{
		public void show(string str)
		{
			//
			// 자바스크립트 메시지 박스
			//
			Response.Write("<script>");
			Response.Write("alert('" + str + "');");
			Response.Write("</script>");
		}
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox id;
		protected System.Web.UI.WebControls.TextBox name;
		protected System.Web.UI.WebControls.TextBox address;
		protected System.Web.UI.WebControls.TextBox history;
		protected System.Web.UI.WebControls.TextBox group;
		protected System.Web.UI.WebControls.DataGrid result;
		protected System.Web.UI.HtmlControls.HtmlInputButton Submit1;
		protected System.Web.UI.WebControls.TextBox concern;
		protected System.Web.UI.WebControls.Label selected;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//토론.cur_dir = Server.MapPath("")+"/";
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.result.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.result_ItemCommand);
			this.result.SelectedIndexChanged += new System.EventHandler(this.result_SelectedIndexChanged);
			this.Submit1.ServerClick += new System.EventHandler(this.Submit1_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			string query = "select 아이디 from 회원정보 where ";
			ArrayList arrM = new ArrayList();
			member m = new member();
			if(id.Text != "") m = member_access.return_member(id.Text);
			else 
			{
				if(name.Text != "") query += "이름 like '%" + name.Text + "%'";
				if(group.Text != "") query += " AND 그룹 like '%" + group.Text + "%'";
				if(address.Text != "") query += " AND 주소앞 like '%" +address.Text + "%'";
				if(history.Text != "") query += " AND 약력 like '%" + history.Text + "%'";
				if(concern.Text != "") query += " AND 관심분야 like '%" + concern.Text +"%'";
			//	exec(query);
			//	DataTable dt = ;
			//		dt.DefaultView = 
			}
			member_access ms = new member_access(m);
			//arrM = ms.find();							//조건에 맞는 아이디의 배열
			
			DataTable search_result = new DataTable("검색결과");
			DataColumn ids = new DataColumn("아이디");
			DataColumn info = new DataColumn("공개된 회원정보");
			search_result.Columns.Add(ids);
			search_result.Columns.Add(info);
			
			foreach (member mem in arrM) 
			{
				DataRow row;
				row = search_result.NewRow();
				row["아이디"] = mem.id;
				row["공개된 회원정보"] = member_access.show(mem);
				search_result.Rows.Add(row);
			}
			result.DataSource = search_result;
			result.DataBind();
	
		}

		private void result_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		protected static string str	= null;
		protected static ArrayList ids = new ArrayList();
		

		private void result_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string id = e.Item.Cells[0].Text;
			if(!ids.Contains(id)) ids.Add(id);
			else ids.Remove(id);
			string id_str = null;
			foreach (string s in ids) id_str += s + " ";
			selected.Text = id_str;
		}

		private void Submit1_ServerClick(object sender, System.EventArgs e)
		{
			토론.invited_ids = ids;
			Response.Redirect("게시판생성.aspx");
		}
		
	}
}
