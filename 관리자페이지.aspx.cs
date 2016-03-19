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
	/// �������������� ���� ��� �����Դϴ�.
	/// </summary>
	public class ������������ : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox title;
		protected System.Web.UI.WebControls.TextBox field;
		protected System.Web.UI.WebControls.TextBox num;
		protected System.Web.UI.WebControls.Label Label;
		protected System.Web.UI.WebControls.Button totop;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
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
			this.totop.Click += new System.EventHandler(this.totop_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void totop_Click(object sender, System.EventArgs e)
		{
			StreamWriter sr = File.AppendText(���.cur_dir + "data/top.txt");
			sr.WriteLine(title.Text);
			sr.WriteLine(field.Text);
			sr.WriteLine(num.Text);
			sr.Close();
			Label.Text = "����� �Ǿ����ϴ�.";
			title.Text = "";
			field.Text = "";
			num.Text = "";
		}
	}
}
