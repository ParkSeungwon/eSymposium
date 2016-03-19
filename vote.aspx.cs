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
	/// vote�� ���� ��� �����Դϴ�.
	/// </summary>
	public class vote : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid grid;
		protected System.Web.UI.WebControls.Button tomain;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// ���⿡ ����� �ڵ带 ��ġ�Ͽ� �������� �ʱ�ȭ�մϴ�.
			string num = Request.QueryString["num"];
			string field = Request.QueryString["field"];
			DirectoryInfo di = new DirectoryInfo(���.cur_dir + field + "/");
			FileInfo[] fi = di.GetFiles(num + "+*");
			DataTable dt = new DataTable("��ǥ");
			DataColumn id = new DataColumn("���̵�");
			DataColumn vote = new DataColumn("��ǥ��");
			dt.Columns.Add(id);
			dt.Columns.Add(vote);

			foreach(FileInfo f in fi)
			{
				StreamReader sr = File.OpenText(f.FullName);
				int i = 0;
				while(sr.ReadLine() != null) i++;
				DataRow r = dt.NewRow();
				r["���̵�"] = f.Name.Remove(0, num.Length+1);
				r["��ǥ��"] = i.ToString();
				dt.Rows.Add(r);
			}
			grid.DataSource = dt;
			grid.DataBind();
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �� ȣ���� ASP.NET Web Form �����̳ʿ� �ʿ��մϴ�.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����̳� ������ �ʿ��� �޼����Դϴ�.
		/// �� �޼����� ������ �ڵ� ������� �������� ���ʽÿ�.
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
