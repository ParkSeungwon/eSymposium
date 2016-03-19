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
	/// idsearch�� ���� ��� �����Դϴ�.
	/// </summary>
	public class idsearch : System.Web.UI.Page
	{
		public void show(string str)
		{
			//
			// �ڹٽ�ũ��Ʈ �޽��� �ڽ�
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
			//���.cur_dir = Server.MapPath("")+"/";
			// ���⿡ ����� �ڵ带 ��ġ�Ͽ� �������� �ʱ�ȭ�մϴ�.
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.result.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.result_ItemCommand);
			this.result.SelectedIndexChanged += new System.EventHandler(this.result_SelectedIndexChanged);
			this.Submit1.ServerClick += new System.EventHandler(this.Submit1_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			string query = "select ���̵� from ȸ������ where ";
			ArrayList arrM = new ArrayList();
			member m = new member();
			if(id.Text != "") m = member_access.return_member(id.Text);
			else 
			{
				if(name.Text != "") query += "�̸� like '%" + name.Text + "%'";
				if(group.Text != "") query += " AND �׷� like '%" + group.Text + "%'";
				if(address.Text != "") query += " AND �ּҾ� like '%" +address.Text + "%'";
				if(history.Text != "") query += " AND ��� like '%" + history.Text + "%'";
				if(concern.Text != "") query += " AND ���ɺо� like '%" + concern.Text +"%'";
			//	exec(query);
			//	DataTable dt = ;
			//		dt.DefaultView = 
			}
			member_access ms = new member_access(m);
			//arrM = ms.find();							//���ǿ� �´� ���̵��� �迭
			
			DataTable search_result = new DataTable("�˻����");
			DataColumn ids = new DataColumn("���̵�");
			DataColumn info = new DataColumn("������ ȸ������");
			search_result.Columns.Add(ids);
			search_result.Columns.Add(info);
			
			foreach (member mem in arrM) 
			{
				DataRow row;
				row = search_result.NewRow();
				row["���̵�"] = mem.id;
				row["������ ȸ������"] = member_access.show(mem);
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
			���.invited_ids = ids;
			Response.Redirect("�Խ��ǻ���.aspx");
		}
		
	}
}
