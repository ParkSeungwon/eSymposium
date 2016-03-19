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
	/// ���徲�⿡ ���� ��� �����Դϴ�.
	/// </summary>
	public class ���徲�� : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button cancel;
		protected System.Web.UI.WebControls.Button write;
		protected System.Web.UI.WebControls.TextBox contents;
		protected System.Web.UI.WebControls.TextBox title;
		protected System.Web.UI.WebControls.TextBox id;
		private fboard fb;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// ���⿡ ����� �ڵ带 ��ġ�Ͽ� �������� �ʱ�ȭ�մϴ�.
			id.Text = User.Identity.Name;
			string page = Request.QueryString["page"];
			string num = Request.QueryString["num"];
			string field = Request.QueryString["field"];
			int pagei = tools.str2int(page);
			int numi = tools.str2int(num);
			fb = fboard.readFile(field, numi, pagei-1);
			if(id.Text == "") write.Enabled = false;
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
			this.write.Click += new System.EventHandler(this.write_Click);
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void write_Click(object sender, System.EventArgs e)
		{
			fb.change(contents.Text);
			fb.title = title.Text;
			fb.id = id.Text;
			fb.page_index = fb.page_index + 1;
			fb.subcomment.Clear();
			fb.writeFile();
			Response.Redirect("���庸��.aspx?field=" + fb.field + "&page=" 
				+ fb.page_index.ToString() + "&num=" + fb.fb_index.ToString());
		}

		private void cancel_Click(object sender, System.EventArgs e)
		{
			int i = fb.page_index;
			Response.Redirect("���庸��.aspx?field=" + fb.field + "&page=" 
					+ i.ToString() + "&num=" + fb.fb_index.ToString());
		}

	}
}
