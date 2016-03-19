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
	/// group�� ���� ��� �����Դϴ�.
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
			// ���⿡ ����� �ڵ带 ��ġ�Ͽ� �������� �ʱ�ȭ�մϴ�.
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
			this.open.Click += new System.EventHandler(this.open_Click);
			this.list.Click += new System.EventHandler(this.list_Click);
			this.grid.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.grid_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void list_Click(object sender, System.EventArgs e)
		{
			DirectoryInfo dir = new DirectoryInfo(���.cur_dir + "group/");
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

			DataTable dt = new DataTable("�׷�");
			DataColumn name = new DataColumn("�׷��");
			DataColumn expl = new DataColumn("����");
			DataColumn openid = new DataColumn("������");
			dt.Columns.Add(name);
			dt.Columns.Add(expl);
			dt.Columns.Add(openid);
			for(int j=0; j<i; j++)
			{
				DataRow row = dt.NewRow();
				row["�׷��"] = search[j].Name;
				row["����"] = explain[j];
				row["������"] = opener[j];
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
			if(File.Exists(���.cur_dir + "group/" + name.Text)) show("�׷���� �̹� �����մϴ�.");
			else 
			{
				StreamWriter sw = File.CreateText(���.cur_dir + "group/" + name.Text);
				sw.WriteLine(explain.Text);
				sw.WriteLine(User.Identity.Name);
				sw.Close();
			}
		}
		public void show(string str)
		{
			//
			// �ڹٽ�ũ��Ʈ �޽��� �ڽ�
			//
			Response.Write("<script>");
			Response.Write("alert('" + str + "');");
			Response.Write("</script>");
		}
	}
}
