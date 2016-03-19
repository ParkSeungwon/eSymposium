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
using System.Data.SqlClient;
using System.Configuration;

namespace startpage
{
	/// <summary>
	/// 회원가입에 대한 요약 설명입니다.
	/// </summary>
	public class 회원가입 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox concern;
		protected System.Web.UI.WebControls.CheckBox concern_o;
		protected System.Web.UI.WebControls.TextBox history;
		protected System.Web.UI.WebControls.CheckBox history_o;
		protected System.Web.UI.WebControls.CheckBox email_o;
		protected System.Web.UI.WebControls.TextBox email;
		protected System.Web.UI.WebControls.TextBox mobile;
		protected System.Web.UI.WebControls.TextBox tel;
		protected System.Web.UI.WebControls.TextBox addressback;
		protected System.Web.UI.WebControls.CheckBox addressfore_o;
		protected System.Web.UI.WebControls.TextBox addressfore;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.TextBox numback;
		protected System.Web.UI.WebControls.TextBox numfore;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.CheckBox name_o;
		protected System.Web.UI.WebControls.TextBox name;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.TextBox password2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox password1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox id2;
		protected System.Web.UI.WebControls.TextBox id;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.WebControls.Button ok;
		protected System.Web.UI.WebControls.Button pass_change;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 여기에 사용자 코드를 배치하여 페이지를 초기화합니다.

			
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 이 호출은 ASP.NET Web Form 디자이너에 필요합니다.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.ok.Click += new System.EventHandler(this.ok_Click);
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			if(member_access.return_pass(id2.Text) == null)
			{
				id.Text = id2.Text;
				show("사용가능합니다.");
			}
			else show("이미 사용되고 있는 아이디입니다.");
		}
		public void show(string str)
		{
			//
			// 자바스크립트 메시지 박스
			//
			Response.Write("<script>");
			Response.Write("alert('" + str + "');");
			Response.Write("</script>");
		}

		private void ok_Click(object sender, System.EventArgs e)
		{
			SqlConnection Con = new SqlConnection(ConfigurationSettings.AppSettings["connstr"]);
			SqlCommand Cmd = new SqlCommand();
			SqlCommand Cmd2 = new SqlCommand();
			Cmd.Connection = Con;
			Cmd2.Connection = Con;
			Cmd.CommandText = "INSERT INTO 로그인정보 (아이디, 패스워드, 레벨) VALUES (@ID, @PWD, @LEVEL)";
			Cmd2.CommandText = "INSERT INTO 회원정보 (아이디, 이름, 이름공개, 주민번호, 주소앞, 주소공개, 주소뒤, 전화번호, 휴대폰번호, 이메일주소, 이메일공개, 약력, 약력공개, 관심분야, 관심분야공개) "
				+ "VALUES (@ID, @NAME, @NAMEO, @NUM, @ADDRF, @ADDRO, @ADDRB, @TEL, @MOBILE, @EMAIL, @EMAILO, @HISTORY, @HISTORYO, @CONCERN, @CONCERNO)";

			
			Cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
			Cmd.Parameters.Add("@PWD", SqlDbType.VarChar, 20);
			Cmd.Parameters.Add("@LEVEL", SqlDbType.TinyInt, 1);

			Cmd.Parameters["@ID"].Value = id.Text;
			Cmd.Parameters["@PWD"].Value = password1.Text;
			Cmd.Parameters["@LEVEL"].Value = Level.free;

			Cmd2.Parameters.Add("@ID", SqlDbType.VarChar, 20);
			Cmd2.Parameters.Add("@NAME", SqlDbType.VarChar, 20);
			Cmd2.Parameters.Add("@NAMEO", SqlDbType.Bit);
			Cmd2.Parameters.Add("@NUM", SqlDbType.VarChar, 13);
			Cmd2.Parameters.Add("@ADDRF", SqlDbType.VarChar, 50);
			Cmd2.Parameters.Add("@ADDRB", SqlDbType.VarChar, 50);
			Cmd2.Parameters.Add("@ADDRO", SqlDbType.Bit);
			Cmd2.Parameters.Add("@TEL", SqlDbType.VarChar, 20);
			Cmd2.Parameters.Add("@MOBILE", SqlDbType.VarChar, 20);
			Cmd2.Parameters.Add("@EMAIL", SqlDbType.VarChar, 30);
			Cmd2.Parameters.Add("@EMAILO", SqlDbType.Bit);
			Cmd2.Parameters.Add("@HISTORY", SqlDbType.Text);
			Cmd2.Parameters.Add("@HISTORYO", SqlDbType.Bit);
			Cmd2.Parameters.Add("@CONCERN", SqlDbType.Text);
			Cmd2.Parameters.Add("@CONCERNO", SqlDbType.Bit);

			Cmd2.Parameters["@ID"].Value = id.Text;
			Cmd2.Parameters["@NAME"].Value = name.Text;
			Cmd2.Parameters["@NAMEO"].Value = name_o.Checked;
			Cmd2.Parameters["@NUM"].Value = numfore.Text + numback.Text;
			Cmd2.Parameters["@ADDRF"].Value = addressfore.Text;
			Cmd2.Parameters["@ADDRB"].Value = addressback.Text;
			Cmd2.Parameters["@ADDRO"].Value = addressfore_o.Checked;
			Cmd2.Parameters["@TEL"].Value = tel.Text;
			Cmd2.Parameters["@MOBILE"].Value = mobile.Text;
			Cmd2.Parameters["@EMAIL"].Value = email.Text;
			Cmd2.Parameters["@EMAILO"].Value = email_o.Checked;
			Cmd2.Parameters["@HISTORY"].Value = history.Text;
			Cmd2.Parameters["@HISTORYO"].Value = history_o.Checked;
			Cmd2.Parameters["@CONCERN"].Value = concern.Text;
			Cmd2.Parameters["@CONCERNO"].Value = concern_o.Checked;

			try
			{
				Con.Open();
				Cmd.ExecuteNonQuery();
				Cmd2.ExecuteNonQuery();
				show("정보가 변경되었습니다.");
			}
			catch(Exception ex)
			{
				show(ex.Message);
			}
			finally
			{
				Con.Close();
				tools t = new tools("group", "모든 가입자");
				t.appendline(id.Text);
				Response.Redirect("가입축하.aspx");
			}
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("index.aspx");
		}

	}
}
