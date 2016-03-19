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
	/// board1�� ���� ��� �����Դϴ�.
	/// </summary>
	public class board1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button search;
		protected System.Web.UI.WebControls.TextBox search_text;
		protected System.Web.UI.WebControls.DropDownList drop;
		protected System.Web.UI.WebControls.DataGrid grid;
		private static string field, numstr;
		protected System.Web.UI.WebControls.Button write;
		private static board b;
		//private static FileInfo[] fbfiles;
		private static DataTable fbtable;
		private static bool on;
		protected System.Web.UI.WebControls.Label label2;
		protected System.Web.UI.WebControls.Panel panel;
		protected System.Web.UI.WebControls.TextBox id;
		protected System.Web.UI.WebControls.Label date;
		protected System.Web.UI.WebControls.TextBox title;
		protected System.Web.UI.WebControls.TextBox contents;
		protected System.Web.UI.WebControls.Button save;
		protected System.Web.UI.WebControls.Button del;
		protected System.Web.UI.WebControls.Button attch;
		protected System.Web.UI.WebControls.DataList Datalist1;
		private static DataView dv;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// ���⿡ ����� �ڵ带 ��ġ�Ͽ� �������� �ʱ�ȭ�մϴ�.
			if(!IsPostBack)
			{
				if(field == "notice") 
				{
					if(User.Identity.Name == "webmaster") 
					{
						write.Visible = true;
						attch.Visible = true;
					}
					else 
					{
						write.Visible = false;
						attch.Visible = false;
					}
				}
				
				field = Request.QueryString["field"];
				if(User.Identity.IsAuthenticated) 
				{
					attch.Enabled = true;
					write.Enabled = true;
				}
				else 
				{
					attch.Enabled = false;
					write.Enabled =false;
				}
				if(id.Text == User.Identity.Name) 
				{
					save.Enabled= true;
					del.Enabled = true;
				}
				else 
				{
					save.Enabled = false;
					del.Enabled = false;
				}
				
				BindData();
				
				panel.Visible = false;
				if(field == "notice") label2.Text = "��������";
				if(field == "board") label2.Text = "�ϹݰԽ���";
				dv = new DataView(fbtable);
				dv.Sort = "�Խù���ȣ DESC";
				grid.DataSource = dv;
				grid.DataBind();
			}
			
		}
		private void BindData()
		{
			fbtable = new DataTable("�Խ���");
			fbtable.Columns.Clear();
			fbtable.Clear();
			//Array.Reverse(fbfiles);
			 
			DirectoryInfo dir = new DirectoryInfo(���.cur_dir + field + "/");
			FileInfo[] fbfiles = dir.GetFiles("*");
			DataColumn num = new DataColumn("�Խù���ȣ");
			num.DataType = System.Type.GetType("System.Int32");
			DataColumn ids = new DataColumn("���̵�");
			DataColumn title = new DataColumn("����");
			DataColumn hit = new DataColumn("��ȸ��");
			DataColumn date = new DataColumn("�ۼ���");
			date.DataType = System.Type.GetType("System.DateTime");

			fbtable.Columns.Add(num);
			fbtable.Columns.Add(ids);
			fbtable.Columns.Add(title);
			fbtable.Columns.Add(hit);
			fbtable.Columns.Add(date);
								
			//grid.CurrentPageIndex
			foreach(FileInfo f in fbfiles)
			{
				board bd = board.readFile(field, f.Name);
				DataRow row;
				row = fbtable.NewRow();
				row["�Խù���ȣ"] = tools.str2int(f.Name);
				row["���̵�"] = bd.get_id();
				row["����"] = bd.title;
				//row["��ȸ��"] = fb.get_totalhit();
				row["�ۼ���"] = bd.date;

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
			this.save.Click += new System.EventHandler(this.save_Click);
			this.del.Click += new System.EventHandler(this.del_Click);
			this.Datalist1.EditCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.Datalist1_EditCommand_1);
			this.Datalist1.UpdateCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.Datalist1_UpdateCommand);
			this.Datalist1.DeleteCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.Datalist1_DeleteCommand);
			this.attch.Click += new System.EventHandler(this.attch_Click);
			this.grid.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.grid_ItemCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand_1);
			this.search.Click += new System.EventHandler(this.search_Click);
			this.write.Click += new System.EventHandler(this.write_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void search_Click(object sender, System.EventArgs e)
		{
			if(drop.SelectedIndex == 1) dv.RowFilter = "���� LIKE '*" + search_text.Text + "*'";
			else dv.RowFilter = "���̵� LIKE '*" + search_text.Text + "*'";
			grid.DataSource = dv;
			grid.CurrentPageIndex = 0;
			grid.DataBind();
		}


		private void Datalist1_UpdateCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			comment c = new comment(User.Identity.Name, ((TextBox)e.Item.FindControl("edittext")).Text);
			b.subcomment.RemoveAt(e.Item.ItemIndex);
			b.subcomment.Insert(e.Item.ItemIndex, c);
			b.writeFile(field, numstr);
			Datalist1.EditItemIndex = -1;
			listBind();
		}
		private void listBind()
		{
			DataTable dt = new DataTable("����");
			DataColumn text = new DataColumn("����");
			DataColumn writer = new DataColumn("�۾���");
			DataColumn date = new DataColumn("�ۼ���");
			DataColumn enable = new DataColumn("��ưȰ��ȭ");
			enable.DataType = System.Type.GetType("System.Boolean");
			dt.Columns.Add(text);
			dt.Columns.Add(writer);
			dt.Columns.Add(date);
			dt.Columns.Add(enable);
	
			foreach(comment c in b.subcomment)
			{
				DataRow dr;
				dr = dt.NewRow();
				dr["����"] = c.get_text();
				dr["�۾���"] = c.get_id();
				dr["�ۼ���"] = c.get_date();
				dr["��ưȰ��ȭ"] = (c.get_id() == User.Identity.Name);
				dt.Rows.Add(dr);
			}
			Datalist1.DataSource = dt;
			Datalist1.DataBind();
		}

		private void grid_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName == "go")			//��������ȯ �̺�Ʈ ���ذ�
			{
				panel.Visible = true;
				numstr = e.Item.Cells[0].Text;
				b = board.readFile(field, numstr);
				id.Text = b.get_id();
				title.Text = b.title;
				contents.Text = b.get_text();
				date.Text = b.get_date();
				if(User.Identity.Name == id.Text) 
				{
					title.ReadOnly = false;
					contents.ReadOnly = false;
					save.Enabled = true;
					del.Enabled = true;
				}
				else
				{
					title.ReadOnly = true;
					contents.ReadOnly = true;
					save.Enabled = false;
					del.Enabled = false;
				}
				listBind();
			}
			if(e.CommandName == "mail")
			{
				board b = board.readFile(field, e.Item.Cells[0].Text);
				Response.Redirect("����������.aspx?id=" + b.id);
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex = e.NewPageIndex;
			//DirectoryInfo dir = new DirectoryInfo(���.cur_dir + field + "/");
			//fbfiles = dir.GetFiles("*");
			grid.DataSource = dv;
			grid.DataBind();
		}

		private void save_Click(object sender, System.EventArgs e)
		{
			if(title.Text == "") show("������ ������ϴ�.");
			else 
			{
				if(b == null) 
				{
					b = new board("", id.Text, "");
					numstr = tools.get_largest_b(field).ToString();
				}
				b.title = title.Text;
				b.change(contents.Text);
				b.writeFile(field, numstr);
				attch.Enabled = true;
			}
			BindData();
			dv = new DataView(fbtable);
			dv.Sort = "�Խù���ȣ DESC";
			grid.DataSource = dv;
			grid.DataBind();
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

		private void write_Click(object sender, System.EventArgs e)
		{
			panel.Visible = true;
			b = null;
			id.Text = User.Identity.Name;
			date.Text = DateTime.Now.ToString();
			contents.Text = "";
			title.Text = "";
			save.Enabled = true;
			attch.Enabled = false;
		}

		private void attch_Click(object sender, System.EventArgs e)
		{
			comment c = new comment(User.Identity.Name, "");
			b.subcomment.Add(c);
			Datalist1.EditItemIndex = b.subcomment.Count-1;
			listBind();
		}

		
		private void grid_SortCommand_1(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
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

		private void del_Click(object sender, System.EventArgs e)
		{
			File.Delete(���.cur_dir + field + "/" + numstr);
			panel.Visible = false;
			BindData();
			dv = new DataView(fbtable);
			grid.DataSource = dv;
			grid.DataBind();
		}

		private void Datalist1_DeleteCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			b.subcomment.RemoveAt(e.Item.ItemIndex);
			b.writeFile(field, numstr);
			listBind();
		}

		private void Datalist1_EditCommand_1(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			Datalist1.EditItemIndex = e.Item.ItemIndex;
			listBind();
		}
	}
}
