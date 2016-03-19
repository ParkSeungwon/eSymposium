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
	/// ������Ͽ� ���� ��� �����Դϴ�.
	/// </summary>
	public class ������� : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button upimage;
		protected System.Web.UI.WebControls.Image image;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileup;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// ���⿡ ����� �ڵ带 ��ġ�Ͽ� �������� �ʱ�ȭ�մϴ�.
			if(User.Identity.IsAuthenticated)
			{
				tools t = new tools("data", "image.txt");
				int i = t.existline(User.Identity.Name);
				if((i%2) == 1) image.ImageUrl = "image/" + t.readline(i+1);
				else image.ImageUrl = "data/default.gif";
			}
			else Response.Redirect("index.aspx");
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
			this.upimage.Click += new System.EventHandler(this.upimage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void upimage_Click(object sender, System.EventArgs e)
		{
			if(fileup.PostedFile != null && fileup.PostedFile.ContentLength < 100000)
			{
				string dir = ���.cur_dir + "image/";
				string id = User.Identity.Name;
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
					fileup.PostedFile.SaveAs(unique);
					tools t = new tools("data", "image.txt");
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
		public void show(string str)
		{
			//
			// �ڹٽ�ũ��Ʈ �޽��� �ڽ�
			//
			Response.Write("<script>");
			Response.Write("alert('" + str + "');");
			Response.Write("</script>");
		}

	
	}
}
