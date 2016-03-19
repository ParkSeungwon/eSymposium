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
	/// group에 대한 요약 설명입니다.
	/// </summary>
	public class group : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid grid;
		protected System.Web.UI.WebControls.Button list;
		protected System.Web.UI.WebControls.TextBox search_text;
		protected System.Web.UI.WebControls.Button open;
		protected System.Web.UI.WebControls.TextBox explain;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox name;
		protected System.Web.UI.WebControls.DropDownList ddl;
	
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
			this.list.Click += new System.EventHandler(this.list_Click);
			this.grid.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.grid_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void list_Click(object sender, System.EventArgs e)
		{
			DirectoryInfo dir = new DirectoryInfo(토론.cur_dir + "group/");
			FileInfo[] fbfiles = dir.GetFiles("*");
			FileInfo[] search;
			int i = 0;
			foreach(FileInfo f in fbfiles)
			{
				if(ddl.SelectedIndex == 0)
				{
					if(f.Name.IndexOf(search_text.Text) != -1) fbfiles[i++] = f;
				}
				else
				{
					StreamReader sr = new StreamReader(f.FullName);
                    if(sr.ReadLine().IndexOf(search_text.Text) != -1) fbfiles[i++] = f;
					sr.Close();
				}
			}
			search = new FileInfo[i];
			string[] explain = new string[i];
			string[] opener = new string[i];
			for(int j=0; j<i; j++) search[j] = fbfiles[j];
			for(int j=0; j<i; j++) 
			{
				StreamReader sr = new StreamReader(search[j].FullName);
				explain[j] = sr.ReadLine();
				opener[j] = sr.ReadLine();
				sr.Close();
			}

			DataTable dt = new DataTable("그룹");
			DataColumn name = new DataColumn("그룹명");
			DataColumn expl = new DataColumn("설명");
			DataColumn openid = new DataColumn("개설자");
			dt.Columns.Add(name);
			dt.Columns.Add(expl);
			dt.Columns.Add(openid);
			for(int j=0; j<i; j++)
			{
				DataRow row = dt.NewRow();
				row["그룹명"] = search[j].Name;
				row["설명"] = explain[j];
				row["개설자"] = opener[j];
				dt.Rows.Add(row);
			}
			grid.DataSource = dt;
			grid.DataBind();
		}

		private void grid_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Response.Redirect("ingroup.aspx?group=" + e.Item.Cells[0].Text);
		}

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
	}
}
