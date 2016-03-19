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
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace startpage
{
	/// <summary>
	/// idsearch�� ���� ��� �����Դϴ�.
	/// </summary>
	public class idsearch : System.Web.UI.Page
	{
		private static ArrayList invited = new ArrayList();
		
		private static bool flag = false;
		protected System.Web.UI.WebControls.TextBox id;
		protected System.Web.UI.WebControls.CheckBox read;
		protected System.Web.UI.WebControls.CheckBox write;
		protected System.Web.UI.WebControls.CheckBox vote;
		protected System.Web.UI.WebControls.CheckBox inturn;
		protected System.Web.UI.WebControls.DropDownList term;
		protected System.Web.UI.WebControls.DropDownList field;
		protected System.Web.UI.WebControls.TextBox title;
		protected System.Web.UI.WebControls.Button up;
		protected System.Web.UI.WebControls.Button down;
		protected System.Web.UI.WebControls.Button del;
		protected System.Web.UI.WebControls.Button clear;
		protected System.Web.UI.WebControls.TextBox contents;
		protected System.Web.UI.WebControls.ListBox invited_ids;
		protected System.Web.UI.WebControls.Button tolist;
		protected System.Web.UI.WebControls.Button save;
		protected System.Web.UI.WebControls.Button start;
		protected System.Web.UI.WebControls.DropDownList addgroup;
		protected System.Web.UI.WebControls.Button add_g;
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Web.UI.WebControls.TextBox id2;
		protected System.Web.UI.WebControls.TextBox name;
		protected System.Web.UI.WebControls.TextBox address;
		protected System.Web.UI.WebControls.TextBox history;
		protected System.Web.UI.WebControls.TextBox concern;
		protected System.Web.UI.WebControls.Button search;
		protected System.Web.UI.WebControls.DataGrid result;
		protected StrengthControls.Scrolling.SmartScroller SmartScroller1;
		protected System.Web.UI.WebControls.Button attach_comment;						//���۴ޱ� â�� ������ �÷���, �ٸ�������� �ϸ� ����

		private static fboard fb;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//���.cur_dir = Server.MapPath("")+"/";
			// ���⿡ ����� �ڵ带 ��ġ�Ͽ� �������� �ʱ�ȭ�մϴ�.
			if(!IsPostBack)
			{
				string num = Request.QueryString["num"];
				if( num == "0")	//get���� �ޱ�		����
				{
					fb = null;
					id.Text = User.Identity.Name;
					if(!invited.Contains(User.Identity.Name)) invited.Add(User.Identity.Name);
					attach_comment.Enabled = false;
				}
				else		//�б�
				{
					if(User.Identity.IsAuthenticated) attach_comment.Enabled = true;
					else attach_comment.Enabled = false;

					fb = fboard.readFile("���", tools.str2int(num), 0);
					goin();

					id.Text = fb.id;
					title.Text = fb.title;
					contents.Text = fb.get_text();
					invited = fb.ids;
					read.Checked = fb.read;
					write.Checked = fb.write;
					vote.Checked = fb.vote;
					inturn.Checked = fb.inturn;
					term.SelectedIndex = fb.response_term-1;
					switch (fb.field) 
					{
						case "��ġ,����,�û�" :
							field.SelectedIndex = 0;
							break;
						case "�м�" :
							field.SelectedIndex = 1;
							break;
						case "ģ��" :
							field.SelectedIndex = 2;
							break;
					}
					listBind();
				}
				invited_ids.DataSource = invited;
				invited_ids.DataBind();
				addgroupBind();
			}
			if(User.Identity.Name == id.Text) 
			{
				//start.Enabled = true;
				save.Enabled = true;
				//add_g.Enabled = true;
			}
			else 
			{
				//start.Enabled = false;
				save.Enabled = false;
				//add_g.Enabled = false;
			}
			if(inturn.Checked == true) term.Enabled = true;
			else term.Enabled = false;

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
			this.inturn.CheckedChanged += new System.EventHandler(this.inturn_CheckedChanged);
			this.up.Click += new System.EventHandler(this.up_Click);
			this.down.Click += new System.EventHandler(this.down_Click);
			this.del.Click += new System.EventHandler(this.del_Click);
			this.clear.Click += new System.EventHandler(this.clear_Click);
			this.tolist.Click += new System.EventHandler(this.tolist_Click);
			this.save.Click += new System.EventHandler(this.save_Click);
			this.start.Click += new System.EventHandler(this.start_Click);
			this.add_g.Click += new System.EventHandler(this.add_g_Click);
			this.DataList1.ItemCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DataList1_ItemCommand);
			this.DataList1.EditCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DataList1_EditCommand);
			this.DataList1.UpdateCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DataList1_UpdateCommand);
			this.DataList1.DeleteCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DataList1_DeleteCommand);
			this.search.Click += new System.EventHandler(this.search_Click);
			this.result.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.result_ItemCommand);
			this.attach_comment.Click += new System.EventHandler(this.attach_comment_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void goin()
		{
			if(fb.read == false && !fb.ids.Contains(User.Identity.Name)) 
			{
				bool inflag = false;
				foreach(string s in fb.ids)
				{
					if(s.IndexOf(":�׷��̸��Դϴ�.") != -1)
					{
						tools t = new tools("group", s.Remove(s.Length - ":�׷��̸��Դϴ�.".Length, ":�׷��̸��Դϴ�.".Length));
						if(t.existline(User.Identity.Name) >= 2) inflag = true;
					}
				}
				if(inflag == false)
				{
					show("�б� ������ �����ϴ�.");
					Response.Redirect("boardlist.aspx?field=���");
				}
			}
		}

		private void search_Click(object sender, System.EventArgs e)
		{
			string[] query = new string[5];
			query[0]= "select * from ȸ������ ";
			string cmd;

			int i = 0;
			if(id2.Text != "") cmd = "select * from ȸ������ where ���̵� like '%" + id2.Text + "%'";		//�ڸǵ� ����
			else 
			{
				if(name.Text != "") query[++i] += "�̸� like '%" + name.Text + "%' and �̸�����=1";
				//if(false) query[++i] += "�׷� like '%" +  "%'";
				if(address.Text != "") query[++i] += "�ּҾ� like '%" +address.Text + "%' and �ּҰ���=1";
				if(history.Text != "") query[++i] += "��� like '%" + history.Text + "%' and ��°���=1";
				if(concern.Text != "") query[++i] += "���ɺо� like '%" + concern.Text +"%' and ���ɺо߰���=1";
			
				switch (i)
				{
					case 0 :
						cmd = query[0];
						break;
					case 1 :
						cmd = query[0] + "where " + query[1];
						break;
					default :
						cmd = query[0] + "where " + query[1];
						int j;
						for(j=2; j<=i; j++) cmd += " and " + query[j];
						break;
				}
			}

			DataTable search_result = new DataTable("�˻����");				//���̺����
			DataColumn ids = new DataColumn("���̵�");
			DataColumn info = new DataColumn("������ ȸ������");
			search_result.Columns.Add(ids);
			search_result.Columns.Add(info);
			
			SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connstr"]);	//����������
			SqlCommand com = new SqlCommand(cmd,con);
			con.Open();
			SqlDataReader dr = com.ExecuteReader();
			while(dr.Read())
			{
				string open = null;
				if((bool)dr["�̸�����"]) open += "�̸�: " + dr["�̸�"].ToString();
				if((bool)dr["�ּҰ���"]) open += ",�ּ�: " + dr["�ּҾ�"].ToString();
				if((bool)dr["�̸��ϰ���"]) open += ",�̸���: " + dr["�̸����ּ�"].ToString();
				if((bool)dr["���ɺо߰���"]) open += ",���ɺо�: " + dr["���ɺо�"].ToString();
				if((bool)dr["��°���"]) open += ",���: " + dr["���"].ToString();

				DataRow row;
				row = search_result.NewRow();
				row["���̵�"] = dr["���̵�"];
				row["������ ȸ������"] = open;
				search_result.Rows.Add(row);
			}
			dr.Close();
			con.Close();

			result.DataSource = search_result;
			result.DataBind();
		}
		private void addgroupBind()
		{
			DirectoryInfo di = new DirectoryInfo(���.cur_dir + "group/");
			FileInfo[] fi = di.GetFiles("*");
			ArrayList al = new ArrayList();
			foreach(FileInfo f in fi) al.Add(f.Name);
			addgroup.DataSource = al;
			addgroup.DataBind();
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

			if(fb != null) 
			{
				foreach(comment c in fb.subcomment)
				{
					DataRow dr;
					dr = dt.NewRow();
					dr["����"] = c.get_text();
					dr["�۾���"] = c.get_id();
					dr["�ۼ���"] = c.get_date();
					dr["��ưȰ��ȭ"] = (c.get_id() == User.Identity.Name);
                    dr["�߰���ư"] = (fb.get_id() == User.Identity.Name);					
					dt.Rows.Add(dr);
				}
				DataList1.DataSource = dt;
				DataList1.DataBind();				 
			}
		}
	

		private void result_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string id = e.Item.Cells[0].Text;
			if(!invited.Contains(id)) invited.Add(id);
			//else invited.Remove(id);
			//result.SelectedIndex = e.Item.ItemIndex;
			invited_ids.DataSource = invited;
			invited_ids.DataBind();
		}

		private void up_Click(object sender, System.EventArgs e)
		{
			if(invited_ids.SelectedIndex > 0)
			{
				int i = invited_ids.SelectedIndex;
				invited.Insert(i-1, invited_ids.SelectedItem.Text);
				invited.RemoveAt(i+1);
				invited_ids.DataSource = invited;
				invited_ids.DataBind();
				invited_ids.SelectedIndex = i-1;
			}
		}

		private void down_Click(object sender, System.EventArgs e)
		{
			if(invited_ids.SelectedIndex < invited.Count-1 && invited_ids.SelectedIndex >= 0)
			{
				int i = invited_ids.SelectedIndex;
				invited.Insert(i+2, invited_ids.SelectedItem.Text);
				invited.RemoveAt(i);
				invited_ids.DataSource = invited;
				invited_ids.DataBind();
				invited_ids.SelectedIndex = i+1;
			}
		}

		private void del_Click(object sender, System.EventArgs e)
		{
			if(invited_ids.SelectedIndex >= 0)
			{
				invited.RemoveAt(invited_ids.SelectedIndex);
				invited_ids.DataSource = invited;
				invited_ids.DataBind();
			}
		}

		private void save_Click(object sender, System.EventArgs e)
		{
			if(title.Text == "") show("������ ������ϴ�.");
			//else if(ids.Items.Count == 0) show("�ʴ��� ���̵� ������ϴ�.");
			else 
			{
				if(fb == null) 
				{
					fb = new fboard(invited, 1, true, true, true, true, "", User.Identity.Name, "");
					fb.fb_index = tools.get_largest("���");
				}
				fb.ids = invited;
				fb.id = id.Text;
				fb.response_term = term.SelectedIndex+1;
				fb.read = read.Checked;
				fb.write = write.Checked;
				fb.vote = vote.Checked;
				fb.inturn = inturn.Checked;
				fb.title = title.Text;
				fb.field = field.SelectedItem.Text;
				fb.change(contents.Text);
				fb.writewait();
				attach_comment.Enabled = true;
				start.Enabled = true;
			}
		}

		private void tolist_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("boardlist.aspx");
		}

		private void start_Click(object sender, System.EventArgs e)
		{
			show("�� ����� ������ ��� ����ñ��� �ٲܼ� �����ϴ�.");

			string str = "��а����� : " + id.Text + "     ��н��� : " + DateTime.Now.ToString();
			str += "\n���� : " + title.Text;
			str += "\n�о� : " + field.SelectedItem.Text;
			str += "\n���ϲ��� �����Ͻ� ����� ����� ���õǾ����ϴ�.";
			str += "\n-------------------------------------------------------";
			foreach(string s in invited)
			{
				if(s.IndexOf(":�׷��̸��Դϴ�.") == -1)
				{
					tools t = new tools("mail", s);
					t.appendline(str);
				}
				else
				{
					StreamReader sr = File.OpenText(���.cur_dir + "group/" + s.Remove(s.Length - ":�׷��̸��Դϴ�.".Length,
						"�׷��̸��Դϴ�.".Length));
					string idname;
					sr.ReadLine();
					while((idname = sr.ReadLine()) != null)
					{
						tools t = new tools("mail", idname);
						t.appendline(str);
					}
					fb.inturn = false;
				}
			}
			fb.start();
			Response.Redirect("boardlist.aspx");
		}

		private void inturn_CheckedChanged(object sender, System.EventArgs e)
		{
			if(inturn.Checked == true) term.Enabled = true;
			else term.Enabled = false;
			Page_Load(this, EventArgs.Empty);
		}

		private void attach_comment_Click(object sender, System.EventArgs e)
		{
			comment c = new comment(User.Identity.Name, "");
			fb.subcomment.Add(c);
			DataList1.EditItemIndex = fb.subcomment.Count-1;
			listBind();
		}

		private void DataList1_EditCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			DataList1.EditItemIndex = e.Item.ItemIndex;
			listBind();
		}

		private void DataList1_DeleteCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			fb.subcomment.RemoveAt(e.Item.ItemIndex);
			fb.writewait();
			listBind();
		}

		private void DataList1_UpdateCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			comment c = new comment(User.Identity.Name, ((TextBox)e.Item.FindControl("edittext")).Text);
			fb.subcomment.RemoveAt(e.Item.ItemIndex);
			fb.subcomment.Insert(e.Item.ItemIndex, c);
			fb.writewait();
			DataList1.EditItemIndex = -1;
			listBind();
		}

		private void DataList1_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			if(e.CommandName == "add")
			{
				string id = ((Label)e.Item.FindControl("writer")).Text;
				if(!invited.Contains(id)) invited.Add(id);
				//else invited.Remove(id);
				//result.SelectedIndex = e.Item.ItemIndex;
				invited_ids.DataSource = invited;
				invited_ids.DataBind();
			}
		}

		private void add_g_Click(object sender, System.EventArgs e)
		{
			/*StreamReader sr = File.OpenText(���.cur_dir + "group/" + addgroup.SelectedItem.Text);
			sr.ReadLine();
			string str = null;
			while((str = sr.ReadLine()) != null) if(!invited.Contains(str))*/
			invited.Add(addgroup.SelectedItem.Text + ":�׷��̸��Դϴ�.");
			//sr.Close();
			invited_ids.DataSource = invited;
			invited_ids.DataBind();
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

		private void clear_Click(object sender, System.EventArgs e)
		{
			invited.Clear();
			invited_ids.DataSource = invited;
			invited_ids.DataBind();
		}
	
	}
}
