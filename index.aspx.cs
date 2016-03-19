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
using System.Web.Security;



namespace startpage
{
	/// <summary>
	/// index2�� ���� ��� �����Դϴ�.
	/// </summary>
	public class index2 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton log;
		protected System.Web.UI.WebControls.ImageButton logout;
		protected System.Web.UI.WebControls.ImageButton sign;
		protected System.Web.UI.WebControls.ListBox direct;
		protected System.Web.UI.WebControls.ImageButton change;
		private static ArrayList title = new ArrayList();
		private static ArrayList field = new ArrayList();
		private static ArrayList num = new ArrayList();
		protected System.Web.UI.WebControls.AdRotator ad;
		protected System.Web.UI.WebControls.DataList books;
		private static ArrayList page = new ArrayList();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// ���⿡ ����� �ڵ带 ��ġ�Ͽ� �������� �ʱ�ȭ�մϴ�.
			if(User.Identity.IsAuthenticated)				//������ �ε�� �α��εǾ����� Ȯ���ϰ� ���߸� �ٲ�
			{
				logout.Visible = true;
				log.Visible = false;
				sign.Visible = false;
				change.Visible = true;
			}
			else
			{
				logout.Visible = false;
				log.Visible = true;
				sign.Visible = true;
				change.Visible = false;
			}
			if(!IsPostBack)
			{
				title.Clear();
				field.Clear();
				num.Clear();
				page.Clear();
				StreamReader sr = File.OpenText(���.cur_dir + "data/top.txt");
				string str;
				while((str = sr.ReadLine()) != null)
				{
					title.Add(str);
					field.Add(sr.ReadLine());
					num.Add(sr.ReadLine());
					page.Add(sr.ReadLine());
				}
				sr.Close();
				direct.DataSource = title;
				direct.DataBind();
				direct.SelectedIndex = -1;
				
				DataTable dt = new DataTable("books");
				DataColumn imgsrc = new DataColumn("�̹������");
				DataColumn bookname = new DataColumn("����");
				bookname.DataType = System.Type.GetType("System.String");
				DataColumn author = new DataColumn("����");
				DataColumn publish = new DataColumn("���ǻ�");
				DataColumn pubdate = new DataColumn("������");
				dt.Columns.Add(imgsrc);
				dt.Columns.Add(author);
				dt.Columns.Add(bookname);
				dt.Columns.Add(publish);
				dt.Columns.Add(pubdate);
				sr = File.OpenText(���.cur_dir + "data/books.txt");
				while((str = sr.ReadLine()) != null)
				{
					DataRow dr = dt.NewRow();
					dr["�̹������"] = "data/" + str;
					dr["����"] = sr.ReadLine();
					dr["����"] = sr.ReadLine();
					dr["���ǻ�"] = sr.ReadLine();
					dr["������"] = sr.ReadLine();
					dt.Rows.Add(dr);
				}
				sr.Close();
				books.DataSource = dt;
				books.DataBind();
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
			this.log.Click += new System.Web.UI.ImageClickEventHandler(this.log_Click);
			this.logout.Click += new System.Web.UI.ImageClickEventHandler(this.logout_Click);
			this.sign.Click += new System.Web.UI.ImageClickEventHandler(this.sign_Click);
			this.change.Click += new System.Web.UI.ImageClickEventHandler(this.change_Click);
			this.direct.SelectedIndexChanged += new System.EventHandler(this.direct_SelectedIndexChanged);
			this.books.SelectedIndexChanged += new System.EventHandler(this.books_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		
		private void logout_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			FormsAuthentication.SignOut();
			logout.Visible = false;
			log.Visible = true;
			sign.Visible = true;
			change.Visible = false;
		}

		private void sign_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ȸ������.aspx");
		}

		private void change_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ȸ����������.aspx");
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

		private void log_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("�α���.aspx");
		}

		private void direct_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int i = direct.SelectedIndex;
			if(field[i].ToString() == "���") Response.Redirect("create.aspx?num=" + num[i].ToString());
			else Response.Redirect("���庸��.aspx?num=" + num[i].ToString() + "&field=" + field[i].ToString() + "&page=" + 
					 page[i].ToString());
		}

		private void books_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		
	}
}
