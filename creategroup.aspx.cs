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
	/// creategroup�� ���� ��� �����Դϴ�.
	/// </summary>
	public class creategroup : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button open;
		protected System.Web.UI.WebControls.TextBox explain;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Button tomain;
		protected System.Web.UI.WebControls.TextBox name;
	
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
			this.tomain.Click += new System.EventHandler(this.tomain_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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

		private void tomain_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("index.aspx");
		}
	}
}
