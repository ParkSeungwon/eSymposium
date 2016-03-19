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
using System.IO;


namespace startpage
{
	/// <summary>
	/// 회원정보변경에 대한 요약 설명입니다.
	/// </summary>
	public class 회원정보변경 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox id;
		protected System.Web.UI.WebControls.TextBox password1;
		protected System.Web.UI.WebControls.Button pass_change;
		protected System.Web.UI.WebControls.TextBox name;
		protected System.Web.UI.WebControls.CheckBox name_o;
		protected System.Web.UI.WebControls.TextBox numfore;
		protected System.Web.UI.WebControls.TextBox numback;
		protected System.Web.UI.WebControls.TextBox addressfore;
		protected System.Web.UI.WebControls.CheckBox addressfore_o;
		protected System.Web.UI.WebControls.TextBox addressback;
		protected System.Web.UI.WebControls.TextBox tel;
		protected System.Web.UI.WebControls.TextBox mobile;
		protected System.Web.UI.WebControls.TextBox email;
		protected System.Web.UI.WebControls.CheckBox email_o;
		protected System.Web.UI.WebControls.CheckBox history_o;
		protected System.Web.UI.WebControls.TextBox history;
		protected System.Web.UI.WebControls.CheckBox concern_o;
		protected System.Web.UI.WebControls.TextBox concern;
		protected System.Web.UI.WebControls.Button ok;
		protected System.Web.UI.WebControls.Button cancel;
		protected System.Web.UI.WebControls.Button picture;
		protected System.Web.UI.HtmlControls.HtmlForm 회원정보;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 여기에 사용자 코드를 배치하여 페이지를 초기화합니다.
			if(!IsPostBack) 
			{
				LoadUserInfo();
				
			}
		}
		

		private void LoadUserInfo()
		{
			string ID = User.Identity.Name;
			SqlConnection Con = new SqlConnection(ConfigurationSettings.AppSettings["connstr"]);
			SqlCommand Cmd = new SqlCommand();
			Cmd.Connection = Con;
			Cmd.CommandText = "SELECT * FROM 회원정보 WHERE 아이디 = @ID";
			Cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
			Cmd.Parameters["@ID"].Value = ID;

			try
			{
				Con.Open();
				SqlDataReader dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
				if(dr.Read())
				{
					id.Text = ID;
					name.Text = dr["이름"].ToString();
					name_o.Checked = (bool)dr["이름공개"];
					numfore.Text = dr["주민번호"].ToString().Remove(6, 7);
					numback.Text = dr["주민번호"].ToString().Remove(0, 6);
					addressfore.Text = dr["주소앞"].ToString();
					addressfore_o.Checked = (bool)dr["주소공개"];
					addressback.Text = dr["주소뒤"].ToString();
					tel.Text = dr["전화번호"].ToString();
					mobile.Text = dr["휴대폰번호"].ToString();
					email.Text = dr["이메일주소"].ToString();
					email_o.Checked = (bool)dr["이메일공개"];
					history.Text = dr["약력"].ToString();
					history_o.Checked = (bool)dr["약력공개"];
					concern.Text = dr["관심분야"].ToString();
					concern_o.Checked = (bool)dr["관심분야공개"];
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
			this.picture.Click += new System.EventHandler(this.picture_Click);
			this.pass_change.Click += new System.EventHandler(this.pass_change_Click);
			this.ok.Click += new System.EventHandler(this.ok_Click);
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ok_Click(object sender, System.EventArgs e)
		{
			if(member_access.return_pass(User.Identity.Name) == password1.Text) update();
			else show("패스워드가 틀립니다.");
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
		private void update()
		{
			string ID = User.Identity.Name;
			
			SqlConnection Con = new SqlConnection(ConfigurationSettings.AppSettings["connstr"]);
			SqlCommand Cmd = new SqlCommand();
			Cmd.Connection = Con;
			Cmd.CommandText = "Update 회원정보 SET 이름공개 = @NAMEO, 주소앞 = @ADDRF, 주소뒤 = @ADDRB, 주소공개 = @ADDRO, 전화번호 = @TEL, 휴대폰번호 = @MOBILE, 이메일주소 = @EMAIL,  이메일공개  = @EMAILO, 약력 = @HISTORY, 약력공개  = @HISTORYO, 관심분야 = @CONCERN,  관심분야공개 = @CONCERNO WHERE 아이디 = @ID";
			
			Cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
			Cmd.Parameters.Add("@NAMEO", SqlDbType.Bit);
			Cmd.Parameters.Add("@ADDRF", SqlDbType.VarChar, 50);
			Cmd.Parameters.Add("@ADDRB", SqlDbType.VarChar, 50);
			Cmd.Parameters.Add("@ADDRO", SqlDbType.Bit);
			Cmd.Parameters.Add("@TEL", SqlDbType.VarChar, 20);
			Cmd.Parameters.Add("@MOBILE", SqlDbType.VarChar, 20);
			Cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 30);
			Cmd.Parameters.Add("@EMAILO", SqlDbType.Bit);
			Cmd.Parameters.Add("@HISTORY", SqlDbType.Text);
			Cmd.Parameters.Add("@HISTORYO", SqlDbType.Bit);
			Cmd.Parameters.Add("@CONCERN", SqlDbType.Text);
			Cmd.Parameters.Add("@CONCERNO", SqlDbType.Bit);

			Cmd.Parameters["@ID"].Value = ID;
			Cmd.Parameters["@NAMEO"].Value = name_o.Checked;
			Cmd.Parameters["@ADDRF"].Value = addressfore.Text;
			Cmd.Parameters["@ADDRB"].Value = addressback.Text;
			Cmd.Parameters["@ADDRO"].Value = addressfore_o.Checked;
			Cmd.Parameters["@TEL"].Value = tel.Text;
			Cmd.Parameters["@MOBILE"].Value = mobile.Text;
			Cmd.Parameters["@EMAIL"].Value = email.Text;
			Cmd.Parameters["@EMAILO"].Value = email_o.Checked;
			Cmd.Parameters["@HISTORY"].Value = history.Text;
			Cmd.Parameters["@HISTORYO"].Value = history_o.Checked;
			Cmd.Parameters["@CONCERN"].Value = concern.Text;
			Cmd.Parameters["@CONCERNO"].Value = concern_o.Checked;

			try
			{
				Con.Open();
				Cmd.ExecuteNonQuery();
				show("정보가 변경되었습니다.");
			}
			catch(Exception ex)
			{
				show(ex.Message);
			}
			finally
			{
				Con.Close();
				Response.Redirect("가입축하.aspx");
			}
		}

		private void cancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("index.aspx");
		}

		private void pass_change_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("암호변경.aspx");
		}

		private void picture_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("사진등록.aspx");
		}

	


	}
	}

