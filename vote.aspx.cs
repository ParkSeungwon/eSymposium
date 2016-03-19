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
	/// vote에 대한 요약 설명입니다.
	/// </summary>
	public class vote : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid grid;
		protected System.Web.UI.WebControls.Button tomain;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 여기에 사용자 코드를 배치하여 페이지를 초기화합니다.
			string num = Request.QueryString["num"];
			string field = Request.QueryString["field"];
			DirectoryInfo di = new DirectoryInfo(토론.cur_dir + field + "/");
			FileInfo[] fi = di.GetFiles(num + "+*");
			DataTable dt = new DataTable("투표");
			DataColumn id = new DataColumn("아이디");
			DataColumn vote = new DataColumn("득표수");
			dt.Columns.Add(id);
			dt.Columns.Add(vote);

			foreach(FileInfo f in fi)
			{
				StreamReader sr = File.OpenText(f.FullName);
				int i = 0;
				while(sr.ReadLine() != null) i++;
				DataRow r = dt.NewRow();
				r["아이디"] = f.Name.Remove(0, num.Length+1);
				r["득표수"] = i.ToString();
				dt.Rows.Add(r);
			}
			grid.DataSource = dt;
			grid.DataBind();
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
			this.tomain.Click += new System.EventHandler(this.tomain_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void tomain_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("index.aspx");
		}
	}
}
