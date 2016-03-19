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
using System.Runtime.Serialization.Formatters.Binary;

namespace startpage
{
	/// <summary>
	/// igroup�� ���� ��� �����Դϴ�.
	/// </summary>
	public class igroup : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataList list;
		protected System.Web.UI.WebControls.Label member;
		protected System.Web.UI.WebControls.TextBox text;
		protected System.Web.UI.WebControls.Button send;
		protected System.Web.UI.WebControls.Button close;
		protected System.Web.UI.WebControls.Button viewmember;
		protected System.Web.UI.WebControls.Button retire;
		protected System.Web.UI.WebControls.Button attach;
		protected System.Web.UI.WebControls.Label expl;
		protected System.Web.UI.WebControls.Label opener;
		protected System.Web.UI.WebControls.Label group;
		protected static ArrayList al = new ArrayList();

		private void Page_Load(object sender, System.EventArgs e)
		{
			// ���⿡ ����� �ڵ带 ��ġ�Ͽ� �������� �ʱ�ȭ�մϴ�.
			if(!IsPostBack)
			{
				group.Text = Request.QueryString["group"];
				StreamReader sr = File.OpenText(���.cur_dir + "group/" + group.Text);
				expl.Text = sr.ReadLine();
				opener.Text = sr.ReadLine();
				sr.Close();
				listBind();
				if(User.Identity.IsAuthenticated) 
				{
					attach.Enabled = true;
					retire.Enabled = true;
				}
				else
				{
					attach.Enabled = false;
					retire.Enabled = false;
				}
				if(User.Identity.Name == opener.Text) 
				{
					close.Visible = true;
					send.Visible = true;
					text.Visible = true;
					retire.Visible = false;
				}
				else 
				{
					close.Visible = false;
					send.Visible = false;
					text.Visible = false;
					retire.Visible = true;
				}
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
			this.retire.Click += new System.EventHandler(this.retire_Click);
			this.close.Click += new System.EventHandler(this.close_Click);
			this.send.Click += new System.EventHandler(this.send_Click);
			this.viewmember.Click += new System.EventHandler(this.viewmember_Click);
			this.list.ItemCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.list_ItemCommand);
			this.list.EditCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.list_EditCommand);
			this.list.UpdateCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.list_UpdateCommand);
			this.list.DeleteCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.list_DeleteCommand);
			this.attach.Click += new System.EventHandler(this.attach_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void attach_Click(object sender, System.EventArgs e)
		{
			tools t = new tools("group", group.Text);
			bool flag = false;
			foreach (comment c in al) if(c.id == User.Identity.Name) flag = true;
			if(flag == true) show("�̹� ���Խ�û�� �� �����Դϴ�.");
			else if(t.existline(User.Identity.Name) < 2) 
			{
				comment c = new comment(User.Identity.Name, "");
				al.Add(c);
				list.EditItemIndex = al.Count-1;
				listBind();
			}
			else show("������ �Ǿ� �ֽ��ϴ�.");
		}

		private void retire_Click(object sender, System.EventArgs e)
		{
			tools t = new tools("group", group.Text);
			int i = t.existline(User.Identity.Name);
			if(i>2) 
			{
				t.deleteline(i);
				show("Ż��Ǿ����ϴ�.");
			}
			//else if(i==2) show("�����ڴ� Ż���Ҽ� �����ϴ�.");
			else show("���ԵǾ����� �ʽ��ϴ�.");
		}

		private void viewmember_Click(object sender, System.EventArgs e)
		{
			member.Text = null;
			StreamReader sr = File.OpenText(���.cur_dir + "group/" + group.Text);
			sr.ReadLine();
			sr.ReadLine();
			string str = "";
			while((str = sr.ReadLine()) != null) member.Text += " " + str;
			sr.Close();
		}

		private void close_Click(object sender, System.EventArgs e)
		{
			File.Delete(���.cur_dir + "group/" + group.Text);
			Response.Redirect("index.aspx");
		}

		private void send_Click(object sender, System.EventArgs e)
		{
			StreamReader sr = File.OpenText(���.cur_dir + "group/" + group.Text);
			sr.ReadLine();
			string str = "";
			string tosend = "�߽ű׷� :" + group.Text + "        �߽��� :" + DateTime.Now.ToString() + "\n";
			tosend += text.Text;
			tosend += "\n-----------------------------------------------------------\n";
			while((str = sr.ReadLine()) != null) 
			{
				tools t = new tools("mail", str);
				t.appendline(tosend);
			}
			sr.Close();
		}

		private void listBind()
		{
			DataTable dt = new DataTable("����");
			DataColumn text = new DataColumn("����");
			DataColumn writer = new DataColumn("�۾���");
			DataColumn date = new DataColumn("�ۼ���");
			DataColumn enable = new DataColumn("��ưȰ��ȭ");
			enable.DataType = System.Type.GetType("System.Boolean");
			DataColumn addid = new DataColumn("�߰���ư");
			addid.DataType = System.Type.GetType("System.Boolean");
			dt.Columns.Add(text);
			dt.Columns.Add(writer);
			dt.Columns.Add(date);
			dt.Columns.Add(enable);
			dt.Columns.Add(addid);

			if(File.Exists(���.cur_dir + "groupboard/" + group.Text))
			{
				FileStream fs = File.OpenRead(���.cur_dir + "groupboard/" + group.Text);
				BinaryFormatter bf = new BinaryFormatter();
				al = (ArrayList)bf.Deserialize(fs);
				fs.Close();
			}
			if(al != null) 
			{
				foreach(comment c in al)
				{
					DataRow dr;
					dr = dt.NewRow();
					dr["����"] = c.get_text();
					dr["�۾���"] = c.get_id();
					dr["�ۼ���"] = c.get_date();
					dr["��ưȰ��ȭ"] = (c.get_id() == User.Identity.Name);
					dr["�߰���ư"] = (opener.Text == User.Identity.Name);					
					dt.Rows.Add(dr);
				}
				list.DataSource = dt;
				list.DataBind();				 
			}
		}
		private void show(string str)
		{
			//
			// �ڹٽ�ũ��Ʈ �޽��� �ڽ�
			//
			Response.Write("<script>");
			Response.Write("alert('" + str + "');");
			Response.Write("</script>");
		}
		private void save()
		{
			FileStream fs = File.Create(���.cur_dir + "groupboard/" + group.Text);
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(fs, al);
			fs.Close();
		}
		private void list_DeleteCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			al.RemoveAt(e.Item.ItemIndex);
			save();
			listBind();
		}

		private void list_EditCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			list.EditItemIndex = e.Item.ItemIndex;
			listBind();
		}

		private void list_UpdateCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			comment c = new comment(User.Identity.Name, ((TextBox)e.Item.FindControl("edittext")).Text);
			al.RemoveAt(e.Item.ItemIndex);
			al.Insert(e.Item.ItemIndex, c);
			list.EditItemIndex = -1;
			save();
			listBind();
		}
		private void list_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			if(e.CommandName == "add")
			{
				tools t = new tools("group", group.Text);
				t.appendline(((Label)e.Item.FindControl("writer")).Text);
				al.RemoveAt(e.Item.ItemIndex);
				save();
				listBind();
			}
		}


		
	}
}
