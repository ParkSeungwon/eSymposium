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
using System.Drawing.Printing;
using System.Data.SqlClient;
using System.Configuration;


namespace startpage
{
	/// <summary>
	/// ���庸�⿡ ���� ��� �����Դϴ�.
	/// </summary>
	public class ���庸�� : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm �Խ��ǻ���;
		
		private static fboard fb;
		//private static board b;
		private static int last_page;
		private static bool his_flag = false;
		private static bool lt_flag = false;
		private static string num; 
		private static string page;
		protected System.Web.UI.WebControls.ImageButton image;
		protected System.Web.UI.WebControls.Label yourturn;
		protected System.Web.UI.WebControls.DropDownList ids;
		protected System.Web.UI.WebControls.TextBox title;
		protected System.Web.UI.WebControls.Label date;
		protected System.Web.UI.WebControls.DropDownList term;
		protected System.Web.UI.WebControls.CheckBox inturn;
		protected System.Web.UI.WebControls.CheckBox vote;
		protected System.Web.UI.WebControls.CheckBox write;
		protected System.Web.UI.WebControls.CheckBox read;
		protected System.Web.UI.WebControls.TextBox id;
		protected System.Web.UI.WebControls.Button continues;
		protected System.Web.UI.WebControls.Button save;
		protected System.Web.UI.WebControls.Button attach_comment;
		protected System.Web.UI.WebControls.Button earn;
		protected System.Web.UI.WebControls.Button vote_button;
		protected System.Web.UI.WebControls.Button tolist;
		protected System.Web.UI.WebControls.Button ff;
		protected System.Web.UI.WebControls.Button rewind;
		protected System.Web.UI.WebControls.ListBox topage;
		protected System.Web.UI.WebControls.TextBox contents;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.DataGrid grid;
		protected StrengthControls.Scrolling.SmartScroller SmartScroller1;
		protected System.Web.UI.WebControls.DataList Datalist1;
		protected System.Web.UI.WebControls.Button lt;
		protected System.Web.UI.WebControls.Button del;
		protected System.Web.UI.WebControls.Panel file_panel;
		protected System.Web.UI.WebControls.Button up;
		protected System.Web.UI.WebControls.Button file;
		protected System.Web.UI.WebControls.Button file_delete;
		protected System.Web.UI.WebControls.HyperLink file_link; 
		private static string field;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileup;
		private static int filen;
		//private StringReader sr2;


		private void Page_Load(object sender, System.EventArgs e)
		{
			// ���⿡ ����� �ڵ带 ��ġ�Ͽ� �������� �ʱ�ȭ�մϴ�.
			//if(!IsPostBack)														//������ ���� ����
			//{
			num  = Request.QueryString["num"];
			page  = Request.QueryString["page"];
			field  = Request.QueryString["field"];

			if(!IsPostBack)
			{
				Panel2.Visible = false;
				//sr2 = null;
				his_flag = false;
				lt_flag = false;
				fb = fboard.readFile(field, tools.str2int(num), tools.str2int(page));
				goin();   //�� �б� �㰡����
				contents.Text = fb.get_text();
				title.Text = fb.title;
				id.Text = fb.get_id();
				read.Checked = fb.check_readable();
				write.Checked = fb.check_writable();
				vote.Checked = fb.check_votable();
				inturn.Checked = fb.get_intern();
				date.Text = fb.get_date();
				term.SelectedIndex = fb.response_term-1;
				//if(Request.QueryString["from"] == "idsearch") ids.DataSource = ���.invited_ids;
				ids.DataSource = fb.ids;
				ids.DataBind();
				loadImage();
				DirectoryInfo di = new DirectoryInfo(���.cur_dir + field + "/");			//�������ٷΰ����ε���
				FileInfo[] fi = di.GetFiles(num + "-*");
				int[] arri = new int[fi.Length];
				for(int i = 0; i<fi.Length; i++)
				{
					arri[i] = i;
				}
				last_page = fi.Length-1;
				//���.page_index = fi.Length-1;
				topage.DataSource = arri;
				topage.DataBind();
				topage.SelectedIndex = tools.str2int(page);
				listBind();											//����Ʈ ���ε�
			}
			filen = uploadedfilename(field, num, page);
			enable();

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
			this.image.Click += new System.Web.UI.ImageClickEventHandler(this.image_Click);
			this.topage.SelectedIndexChanged += new System.EventHandler(this.topage_SelectedIndexChanged);
			this.Datalist1.EditCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DataList1_EditCommand);
			this.Datalist1.UpdateCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DataList1_UpdateCommand);
			this.Datalist1.DeleteCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DataList1_DeleteCommand);
			this.attach_comment.Click += new System.EventHandler(this.attach_comment_Click);
			this.lt.Click += new System.EventHandler(this.lt_Click);
			this.rewind.Click += new System.EventHandler(this.rewind_Click);
			this.ff.Click += new System.EventHandler(this.ff_Click);
			this.tolist.Click += new System.EventHandler(this.tolist_Click);
			this.vote_button.Click += new System.EventHandler(this.vote_button_Click);
			this.earn.Click += new System.EventHandler(this.earn_Click);
			this.save.Click += new System.EventHandler(this.save_Click);
			this.continues.Click += new System.EventHandler(this.continues_Click);
			this.del.Click += new System.EventHandler(this.del_Click);
			this.up.Click += new System.EventHandler(this.up_Click);
			this.file_delete.Click += new System.EventHandler(this.file_delete_Click);
			this.file.Click += new System.EventHandler(this.file_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void loadImage()
		{
			tools t = new tools("data", "image.txt");
			int i = t.existline(id.Text);
			if((i%2) == 1) image.ImageUrl = "image/" + t.readline(i+1);
			else image.ImageUrl = "data/147475.wmf";
		}
		private int uploadedfilename(string field, string num, string page)
		{
			tools t = new tools("data", "file.txt");
			int line = t.existline(field + " " + num + " " + page);
			file_link.Text =  t.readline(line+1);
			return line;
		}
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
					if(User.Identity.IsAuthenticated == true) 
					{
						Response.Redirect("boardlist.aspx?field=" + field);
						show("�б� ������ �����ϴ�.");
					}
					else Response.Redirect("�α���.aspx");
				}
			}
		}
		/*private bool UrlIsValid(string smtpHost)
		{
			bool br = false;
			try 
			{
				IPHostEntry ipHost = Dns.Resolve(smtpHost);
				br = true;
			}
			catch (SocketException se) 
			{
				br = false;
			}
			return br;
		}*/

		private void enable()
		{
			int i = 0;

			if(User.Identity.IsAuthenticated && fb.vote == true) vote_button.Enabled = true;
			else vote_button.Enabled = false;
			if(fb.check_writable() && User.Identity.IsAuthenticated) attach_comment.Enabled = true;//��ư enabled ����
			else attach_comment.Enabled = false;
			if(tools.str2int(page) == last_page) 
			{
				if(User.Identity.Name == id.Text && fb.subcomment.Count == 0 && filen == 0) del.Enabled = true;
				else del.Enabled = false;
				if(fb.get_intern())
				{
					TimeSpan ts;// = new TimeSpan(fb.response_term, 0,0,0);
					DateTime dt = fb.date;	//ȸ�ű��� + ��
					while(DateTime.Compare(dt, DateTime.Now) < 0)
					{
						ts = new TimeSpan(fb.response_term * ++i, 0,0,0);
						dt = fb.date + ts;
					}
					if(fb.ids.Count != 0)
					{
						if	(tools.str2int(page) != 0) 
						{
							ids.SelectedIndex = (fb.ids.IndexOf(id.Text) + i) % fb.ids.Count; //�����ʰ���
						}
						else ids.SelectedIndex = (i-1) % fb.ids.Count;
						if(User.Identity.Name == ids.SelectedItem.Text) continues.Enabled = true;
						else continues.Enabled = false;
						yourturn.Text = "���� ���� �����Դϴ�.";
					}
				}
				else
				{
					continues.Enabled = false;
					if(fb.ids.Contains(User.Identity.Name)) continues.Enabled = true;
					else 
					{
						foreach(string s in fb.ids)
						{
							if(s.IndexOf(":�׷��̸��Դϴ�.") != -1)
							{
								tools t = new tools("group", s.Remove(s.Length - ":�׷��̸��Դϴ�.".Length, ":�׷��̸��Դϴ�.".Length));
								if(t.existline(User.Identity.Name) >= 2) continues.Enabled = true;
							}
						}
					}
				}
				ff.Enabled = false;
			}
			else 
			{
				continues.Enabled = false;
				ff.Enabled = true;
			}


			if(tools.str2int(page) == 0) rewind.Enabled = false;
			else rewind.Enabled = true;

			if(User.Identity.Name == id.Text) 
			{
				contents.ReadOnly = false;
				title.ReadOnly = false;
				save.Enabled = true;
				up.Enabled = true;
				if(filen != 0) file_delete.Enabled = true;
				else file_delete.Enabled = false;
				file.Enabled = true;
			}
			else
			{
				contents.ReadOnly = true;
				title.ReadOnly = true;
				save.Enabled = false;
				up.Enabled = false;
				file_delete.Enabled = false;
				if(filen == 0) file.Enabled = false;
				else file.Enabled = true;
			}
			//Panel1.Visible = false;

		}

		private void listBind()
		{
			DataTable dt = new DataTable("����");
			DataColumn text = new DataColumn("����");
			DataColumn text4view = new DataColumn("���๮��");
			DataColumn writer = new DataColumn("�۾���");
			DataColumn date = new DataColumn("�ۼ���");
			DataColumn enable = new DataColumn("��ưȰ��ȭ");
			enable.DataType = System.Type.GetType("System.Boolean");
			dt.Columns.Add(text);
			dt.Columns.Add(text4view);
			dt.Columns.Add(writer);
			dt.Columns.Add(date);
			dt.Columns.Add(enable);
	
			foreach(comment c in fb.subcomment)
			{
				DataRow dr;
				dr = dt.NewRow();
				dr["����"] = c.get_text();
				dr["���๮��"] = c.get_text().Replace("\n", "<br>");
				dr["�۾���"] = c.get_id();
				dr["�ۼ���"] = c.get_date();
				dr["��ưȰ��ȭ"] = (c.get_id() == User.Identity.Name);
				dt.Rows.Add(dr);
			}
			Datalist1.DataSource = dt;
			Datalist1.DataBind();
		}
		private void attach_comment_Click(object sender, System.EventArgs e)
		{
			comment c = new comment(User.Identity.Name, "");
			fb.subcomment.Add(c);
			Datalist1.EditItemIndex = fb.subcomment.Count-1;
			listBind();
		}
		
		private void ff_Click(object sender, System.EventArgs e)
		{
			int p = tools.str2int(page) + 1;
			string ps = p.ToString();
			//topage.SelectedIndex = topage.SelectedIndex+1;
			Response.Redirect("���庸��.aspx?page=" + ps + "&num=" + num + "&field=" + field);
		}

		private void rewind_Click(object sender, System.EventArgs e)
		{
			int p = tools.str2int(page) - 1;
			string ps = p.ToString();
			//topage.SelectedIndex--;
			Response.Redirect("���庸��.aspx?page=" + ps + "&num=" + num + "&field=" + field);
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


	/*	private void write_Click(object sender, System.EventArgs e)
		{
			fboard fb = fboard.readFile(���.fb_index);
			if(fb.check_turn()) ���.page_index++;
			Response.Redirect("���徲��.aspx");
		}*/

		private void topage_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int p = topage.SelectedIndex;
			string ps = p.ToString();
			//topage.SelectedIndex--;
			Response.Redirect("���庸��.aspx?page=" + ps + "&num=" + num + "&field=" + field);
			listBind();
		}

		private void continues_Click(object sender, System.EventArgs e)
		{
			int p = tools.str2int(page) + 1;
			string ps = p.ToString();
			Response.Redirect("���徲��.aspx?page=" + ps + "&num=" + num + "&field=" + field);
		}

		private void tolist_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("boardlist.aspx?field=" + fb.field);
		}

		private void DataList1_EditCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			Datalist1.EditItemIndex = e.Item.ItemIndex;
			listBind();
		}

		private void save_Click(object sender, System.EventArgs e)
		{
			if(title.Text == "") show("������ ������ϴ�.");
			else 
			{
				fb.title = title.Text;
				fb.change(contents.Text);
				fb.writeFile();
			}
		}

		private void inturn_CheckedChanged(object sender, System.EventArgs e)
		{
			if(inturn.Checked == true) term.Enabled = true;
			else term.Enabled = false;
		}

		private void DataList1_UpdateCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			comment c = new comment(User.Identity.Name, ((TextBox)e.Item.FindControl("edittext")).Text);
			fb.subcomment.RemoveAt(e.Item.ItemIndex);
			fb.subcomment.Insert(e.Item.ItemIndex, c);
			fb.writeFile();
			Datalist1.EditItemIndex = -1;
			listBind();
		}

		private void DataList1_DeleteCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			fb.subcomment.RemoveAt(e.Item.ItemIndex);
			fb.writeFile();
			listBind();
			enable();
		}

		private void image_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(his_flag == false)
			{
				contents.Text = LoadUserInfo();
				his_flag = true;
				lt_flag = false;
				save.Enabled = false;
			}
			else
			{
				contents.Text = fb.get_text();
				his_flag = false;
				if(User.Identity.Name == id.Text) save.Enabled = true;
			}
		}
		private string LoadUserInfo()
		{
			string ID = id.Text;
			SqlConnection Con = new SqlConnection(ConfigurationSettings.AppSettings["connstr"]);
			SqlCommand Cmd = new SqlCommand();
			Cmd.Connection = Con;
			Cmd.CommandText = "SELECT * FROM ȸ������ WHERE ���̵� = @ID";
			Cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
			Cmd.Parameters["@ID"].Value = ID;

			string result = null;
			string name  = null, addr = null, email = null, history = null, concern = null; 

			try
			{
				Con.Open();
				SqlDataReader dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
				if(dr.Read())
				{
					if((bool)dr["�̸�����"]) name = dr["�̸�"].ToString() + "\r\n";
					else name = "********\r\n";
					if((bool)dr["�ּҰ���"]) addr = dr["�ּҾ�"].ToString() + "\r\n";
					else addr = "*********************\r\n";
					if((bool)dr["�̸��ϰ���"]) email = dr["�̸����ּ�"].ToString() + "\r\n";
					else email = "*************\r\n";
					if((bool)dr["��°���"])history = dr["���"].ToString() + "\r\n";
					else history = "***********************************************\r\n";
					if((bool)dr["���ɺо߰���"]) concern = dr["���ɺо�"].ToString() + "\r\n";
					else concern = "*************************************\r\n";
				}
				dr.Close();
			}
			catch(Exception ex)	
			{
				show(ex.Message);
			}
			finally 
			{
				Con.Close();
			}
			result = "�̸� : " + name + "�ּ� : " + addr + "�̸��� : " + email + "\n��� : \n" + history + "\n���ɺо� : \n" + concern;
			return result;
		}


		private void vote_button_Click(object sender, System.EventArgs e)
		{
			string field = fb.field;
			string num = fb.fb_index.ToString();
			string idstr = id.Text;
			DirectoryInfo di = new DirectoryInfo(���.cur_dir + field + "/");
			FileInfo[] fi = di.GetFiles(num + "+*");
			tools t;
			foreach(FileInfo f in fi)
			{
				t = new tools(field, f.Name);
				int i = 0;
				if((i = t.existline(User.Identity.Name)) > 0) 
				{
					show("�����ڸ� �ٲټ̽��ϴ�.");
					t.deleteline(i);
					break;
				}
			}
			t = new tools(field, num + "+" + idstr);
			t.appendline(User.Identity.Name);
		}

		private void earn_Click(object sender, System.EventArgs e)
		{
			if(Panel2.Visible == false)
			{
				Panel2.Visible = true;
				string num = fb.fb_index.ToString();
				string field = fb.field;
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
					sr.Close();
				}
				grid.DataSource = dt;
				grid.DataBind();
			}
			else Panel2.Visible = false;
		}

		private void lt_Click(object sender, System.EventArgs e)
		{
			if(lt_flag == false)
			{
				contents.Text = LoadLt();
				lt_flag = true;
				his_flag = false;
				save.Enabled = false;
			}
			else
			{
				contents.Text = fb.get_text();
				lt_flag = false;
				if(User.Identity.Name == id.Text) save.Enabled = true;
			}
		}
		private string LoadLt()
		{
			string str = null;
			fboard fb;
			for(int i = 0; i < topage.Items.Count; i++)
			{
				fb = fboard.readFile(field, tools.str2int(num), i);
				str += i.ToString() + ". " + fb.title + "(" + fb.id + ")" + "\n";
			}
			return str;
		}

		private void del_Click(object sender, System.EventArgs e)
		{
			fb.deleteFile();
			if(tools.str2int(page) == 0) Response.Redirect("boardlist.aspx?field=" + fb.field);
			else
			{
				int p = tools.str2int(page) - 1;
				string ps = p.ToString();
				//topage.SelectedIndex--;
				Response.Redirect("���庸��.aspx?page=" + ps + "&num=" + num + "&field=" + field);
			}
		}

		private void file_delete_Click(object sender, System.EventArgs e)
		{
			tools t = new tools("data", "file.txt");
			t.deleteline(filen);
			t.deleteline(filen+1);
			File.Delete("file/" + file_link.Text);
			file_link.Text = "";
			filen = 0;
		}

		private void file_Click(object sender, System.EventArgs e)
		{
			if(file_panel.Visible == true) file_panel.Visible = false;
			else file_panel.Visible = true;
		}

		private void up_Click(object sender, System.EventArgs e)
		{
			if(fileup.PostedFile != null)//&& fileup.PostedFile.ContentLength < 100000)
			{
				string dir = ���.cur_dir + "file/";
				string id = field + " " + num + " " + page;
				try
				{
					string wholepath = fileup.PostedFile.FileName.ToString();
					string filename = Path.GetFileName(wholepath);
					string unique = dir + filename;
					int j = 0;
					while(File.Exists(unique)) 
					{
						j++;
						unique = dir + j.ToString() + filename;
					}
					file_link.Text = j.ToString() + filename;
					file_link.NavigateUrl = unique;
					fileup.PostedFile.SaveAs(unique);
					tools t = new tools("data", "file.txt");
					int i = t.existline(id);
					if((i%2) == 1) 
					{
						File.Delete(dir + t.readline(i+1));
						t.replaceline(i+1, unique.Remove(0, dir.Length));
					}
					else
					{
						t.appendline(id);
						t.appendline(j.ToString() + filename);
					}
						
				}
				catch(Exception err)
				{
					show("Error : " + err.Message);
				}
			}
			else show("������ ���ų� ũ�Ⱑ 100KB �̻��Դϴ�.");
			Page_Load(this, EventArgs.Empty);
		}

		
		/*private void print_Click(object sender, System.EventArgs e)
		{
			Panel1.Visible = true;
			printername.DataSource = PrinterSettings.InstalledPrinters;

			printername.DataBind();
		}

		private void print_ok_Click(object sender, System.EventArgs e)
		{
			PrintDocument pd = new PrintDocument();
			pd.PrintPage += new PrintPageEventHandler(this.printevent);
			pd.PrinterSettings.PrinterName = printername.SelectedItem.Text;
			pd.Print();
			Panel1.Visible = false;
		}
		private void printevent(object sender, PrintPageEventArgs ev) 
		{
			//ev.Graphics.DrawString (contents.Text, new Font("Arial Regular", 10), Brushes.Black,0,0);
			float linesPerPage = 0;
			float yPos = 0;
			int count = 0;
			float leftMargin = 20;//ev.MarginBounds.Left;
			float topMargin = 30;//ev.MarginBounds.Top;
			string line = null;
			Font printFont = new Font("Arial Regular", 10);

			// Calculate the number of lines per page.
			linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
			StringReader sr = new StringReader(contents.Text);
			string tmp;
			string str="����: " + title.Text +"            Page: " + topage.SelectedIndex.ToString() +"\r\n"
				+ "�۾���: " + id.Text + "         �ۼ���: "+ date.Text + "\r\n";
			const int cpl = 60;			//char per line
			while((tmp = sr.ReadLine()) != null) 
			{
				if(tmp.Length <= cpl) str += tmp + "\r\n";
				else 
				{
					while(tmp.Length > cpl)
					{
						for(int i=0; i<cpl; i++) str += tmp[i];
						tmp = tmp.Remove(0, cpl);
						str += "\r\n";
					}
				}
			}
			if (sr2 == null) sr2 = new StringReader(str);
			// Print each line of the file.
			while(count < linesPerPage && ((line=sr2.ReadLine()) != null)) 
			{
				yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
				ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
				count++;
			}

			// If more lines exist, print another page.
			if(line != null)
				ev.HasMorePages = true;
			else
				ev.HasMorePages = false;

		}

		private void print_cancel_Click(object sender, System.EventArgs e)
		{
			Panel1.Visible = false;
		}*/
			



	
	}
}
