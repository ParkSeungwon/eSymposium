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
	/// �����б⿡ ���� ��� �����Դϴ�.
	/// </summary>
	public class �����б� : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox mail;
		protected System.Web.UI.WebControls.Label id;
		protected System.Web.UI.WebControls.Button ok;
		protected System.Web.UI.WebControls.Button delete;
		protected System.Web.UI.HtmlControls.HtmlForm ����������;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				id.Text = User.Identity.Name + "�Կ��� �� �����Դϴ�.";
				if(File.Exists(���.cur_dir + "mail/" + User.Identity.Name))
				{
					StreamReader sw = File.OpenText(���.cur_dir + "mail/" + User.Identity.Name);
					mail.Text = sw.ReadToEnd();
					sw.Close();
				}
				else delete.Enabled = false;
			}
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
			this.delete.Click += new System.EventHandler(this.delete_Click);
			this.ok.Click += new System.EventHandler(this.ok_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void delete_Click(object sender, System.EventArgs e)
		{
			File.Delete(���.cur_dir + "mail/" + User.Identity.Name);
			Response.Redirect("index.aspx");
		}

		private void ok_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("index.aspx");
		}
	}
}
