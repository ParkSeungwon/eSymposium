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
	/// test�� ���� ��� �����Դϴ�.
	/// </summary>
	/// 
	
	public class test : System.Web.UI.Page
	{
		protected sc.WebCustomControl1 WebCustomControl11;
		protected System.Web.UI.WebControls.Button Button1;

	
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	
		public void show(string str)
		{
			//
			// �ڹٽ�ũ��Ʈ �޽��� �ڽ�
			//
			Response.Write("<script>");
			Response.Write("alert('" + str + "');");
			Response.Write("</script>");
			
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			
		}

	
	}
}
