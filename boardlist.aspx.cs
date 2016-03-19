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
	/// boardlist�� ���� ��� �����Դϴ�.
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
		private static string field = "���";
		private static bool on = false;
		private static DataView dv;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// ���⿡ ����� �ڵ带 ��ġ�Ͽ� �������� �ʱ�ȭ�մϴ�.
			if(!IsPostBack) 
			{
				string tmp = Request.QueryString["field"];
				if(tmp == null) field = "���";
				else field = tmp;
				
				MakeTable();
				DirectoryInfo dir = new DirectoryInfo(���.cur_dir + field + "/");
				FileInfo[] fbfiles = dir.GetFiles("*-0");
				BindData(fbfiles);
				dv = new DataView(fbtable);
				dv.Sort = "�Խù���ȣ DESC";
				grid.DataSource = dv;
				grid.DataBind();
				switch (field) 
				{
					case "��ġ,����,�û�" :
						fieldselect.SelectedIndex = 0;
						break;
					case "�м�" :
						fieldselect.SelectedIndex = 1;
						break;
					case "ģ��" :
						fieldselect.SelectedIndex = 2;
						break;
					case "���" :
						fieldselect.SelectedIndex = 3;
						break;
				}
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
		private void MakeTable()
		{	
			fbtable = new DataTable("�Խù� ���");
			fbtable.Columns.Clear();
			DataColumn num = new DataColumn("�Խù���ȣ");
			num.DataType = System.Type.GetType("System.Int32");
			DataColumn ids = new DataColumn("���̵�");
			DataColumn title = new DataColumn("����");
			DataColumn date = new DataColumn("�ۼ���");
			date.DataType = System.Type.GetType("System.DateTime");
			DataColumn read = new DataColumn("����");
			read.DataType = System.Type.GetType("System.Boolean");
			DataColumn write = new DataColumn("����");
			write.DataType = System.Type.GetType("System.Boolean");
			DataColumn vote = new DataColumn("��ǥ");
			vote.DataType = System.Type.GetType("System.Boolean");
			DataColumn inturn = new DataColumn("���ʷ�");
			inturn.DataType = System.Type.GetType("System.Boolean");
			DataColumn page = new DataColumn("������");
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
			DirectoryInfo dir = new DirectoryInfo(���.cur_dir + field + "/");
			foreach(FileInfo f in fbfiles) 
			{
				string s = f.Name;

				int i = tools.str2int(s.Remove(s.Length-2, 2));			//���ϸ��� -0�� ��
				fboard fb = fboard.readFile(f.DirectoryName.Remove(0, ���.cur_dir.Length), i, 0);
				DataRow row = fbtable.NewRow();
				row["�Խù���ȣ"] = i;
				row["���̵�"] = fb.get_id();
				row["����"] = fb.title;
				row["�ۼ���"] = fb.date;
				row["����"] = fb.check_readable();
				row["����"] = fb.check_writable();
				row["��ǥ"] = fb.check_votable();
				row["���ʷ�"] = fb.get_intern();
				row["������"] = dir.GetFiles(s.Remove(s.Length-2, 2) + "-*").Length;

				fbtable.Rows.Add(row);
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
			else show("������ �����ϴ�.");
		}
	
		
		private void grid_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName == "go")			//��������ȯ �̺�Ʈ ���ذ�
			{
				if(field == "���") Response.Redirect("create.aspx?num=" + e.Item.Cells[0].Text);
				else Response.Redirect("���庸��.aspx?num=" + e.Item.Cells[0].Text + "&page=0&field=" + field);
			}
			if(e.CommandName == "mail") 
			{
				fboard fb = fboard.readFile(field, tools.str2int(e.Item.Cells[0].Text), 0);
				Response.Redirect("����������.aspx?id=" + fb.id);
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
			if(drop.SelectedIndex == 0) dv.RowFilter = "���̵� LIKE '*" + search_text.Text + "*'";
			else dv.RowFilter = "���� LIKE '*" + search_text.Text + "*'";
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
			DirectoryInfo dir = new DirectoryInfo(���.cur_dir + field + "/");
			FileInfo[] fbfiles = dir.GetFiles("*-0");
			BindData(fbfiles);
			dv = new DataView(fbtable);
			dv.Sort = "�Խù���ȣ DESC";
			grid.DataSource = dv;
			grid.CurrentPageIndex = 0;
			grid.DataBind();
		}
	}
}
