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
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace startpage
{
	/// <summary>
	/// idsearch에 대한 요약 설명입니다.
	/// </summary>
	public class idsearch : System.Web.UI.Page
	{
		private static ArrayList invited = new ArrayList();
		
		private static bool flag = false;
		protected System.Web.UI.WebControls.TextBox id;
		protected System.Web.UI.WebControls.CheckBox read;
		protected System.Web.UI.WebControls.CheckBox write;
		protected System.Web.UI.WebControls.CheckBox vote;
		protected System.Web.UI.WebControls.CheckBox inturn;
		protected System.Web.UI.WebControls.DropDownList term;
		protected System.Web.UI.WebControls.DropDownList field;
		protected System.Web.UI.WebControls.TextBox title;
		protected System.Web.UI.WebControls.Button up;
		protected System.Web.UI.WebControls.Button down;
		protected System.Web.UI.WebControls.Button del;
		protected System.Web.UI.WebControls.Button clear;
		protected System.Web.UI.WebControls.TextBox contents;
		protected System.Web.UI.WebControls.ListBox invited_ids;
		protected System.Web.UI.WebControls.Button tolist;
		protected System.Web.UI.WebControls.Button save;
		protected System.Web.UI.WebControls.Button start;
		protected System.Web.UI.WebControls.DropDownList addgroup;
		protected System.Web.UI.WebControls.Button add_g;
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Web.UI.WebControls.TextBox id2;
		protected System.Web.UI.WebControls.TextBox name;
		protected System.Web.UI.WebControls.TextBox address;
		protected System.Web.UI.WebControls.TextBox history;
		protected System.Web.UI.WebControls.TextBox concern;
		protected System.Web.UI.WebControls.Button search;
		protected System.Web.UI.WebControls.DataGrid result;
		protected StrengthControls.Scrolling.SmartScroller SmartScroller1;
		protected System.Web.UI.WebControls.Button attach_comment;						//덧글달기 창을 생성할 플래그, 다른방식으로 하면 버그

		private static fboard fb;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//토론.cur_dir = Server.MapPath("")+"/";
			// 여기에 사용자 코드를 배치하여 페이지를 초기화합니다.
			if(!IsPostBack)
			{
				string num = Request.QueryString["num"];
				if( num == "0")	//get으로 받기		생성
				{
					fb = null;
					id.Text = User.Identity.Name;
					if(!invited.Contains(User.Identity.Name)) invited.Add(User.Identity.Name);
					attach_comment.Enabled = false;
				}
				else		//읽기
				{
					if(User.Identity.IsAuthenticated) attach_comment.Enabled = true;
					else attach_comment.Enabled = false;

					fb = fboard.readFile("대기", tools.str2int(num), 0);
					goin();

					id.Text = fb.id;
					title.Text = fb.title;
					contents.Text = fb.get_text();
					invited = fb.ids;
					read.Checked = fb.read;
					write.Checked = fb.write;
					vote.Checked = fb.vote;
					inturn.Checked = fb.inturn;
					term.SelectedIndex = fb.response_term-1;
					switch (fb.field) 
					{
						case "정치,경제,시사" :
							field.SelectedIndex = 0;
							break;
						case "학술" :
							field.SelectedIndex = 1;
							break;
						case "친목" :
							field.SelectedIndex = 2;
							break;
					}
					listBind();
				}
				invited_ids.DataSource = invited;
				invited_ids.DataBind();
				addgroupBind();
			}
			if(User.Identity.Name == id.Text) 
			{
				//start.Enabled = true;
				save.Enabled = true;
				//add_g.Enabled = true;
			}
			else 
			{
				//start.Enabled = false;
				save.Enabled = false;
				//add_g.Enabled = false;
			}
			if(inturn.Checked == true) term.Enabled = true;
			else term.Enabled = false;

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
			this.inturn.CheckedChanged += new System.EventHandler(this.inturn_CheckedChanged);
			this.up.Click += new System.EventHandler(this.up_Click);
			this.down.Click += new System.EventHandler(this.down_Click);
			this.del.Click += new System.EventHandler(this.del_Click);
			this.clear.Click += new System.EventHandler(this.clear_Click);
			this.tolist.Click += new System.EventHandler(this.tolist_Click);
			this.save.Click += new System.EventHandler(this.save_Click);
			this.start.Click += new System.EventHandler(this.start_Click);
			this.add_g.Click += new System.EventHandler(this.add_g_Click);
			this.DataList1.ItemCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DataList1_ItemCommand);
			this.DataList1.EditCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DataList1_EditCommand);
			this.DataList1.UpdateCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DataList1_UpdateCommand);
			this.DataList1.DeleteCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DataList1_DeleteCommand);
			this.search.Click += new System.EventHandler(this.search_Click);
			this.result.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.result_ItemCommand);
			this.attach_comment.Click += new System.EventHandler(this.attach_comment_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void goin()
		{
			if(fb.read == false && !fb.ids.Contains(User.Identity.Name)) 
			{
				bool inflag = false;
				foreach(string s in fb.ids)
				{
					if(s.IndexOf(":그룹이름입니다.") != -1)
					{
						tools t = new tools("group", s.Remove(s.Length - ":그룹이름입니다.".Length, ":그룹이름입니다.".Length));
						if(t.existline(User.Identity.Name) >= 2) inflag = true;
					}
				}
				if(inflag == false)
				{
					show("읽기 권한이 없습니다.");
					Response.Redirect("boardlist.aspx?field=대기");
				}
			}
		}

		private void search_Click(object sender, System.EventArgs e)
		{
			string[] query = new string[5];
			query[0]= "select * from 회원정보 ";
			string cmd;

			int i = 0;
			if(id2.Text != "") cmd = "select * from 회원정보 where 아이디 like '%" + id2.Text + "%'";		//코맨드 생성
			else 
			{
				if(name.Text != "") query[++i] += "이름 like '%" + name.Text + "%' and 이름공개=1";
				//if(false) query[++i] += "그룹 like '%" +  "%'";
				if(address.Text != "") query[++i] += "주소앞 like '%" +address.Text + "%' and 주소공개=1";
				if(history.Text != "") query[++i] += "약력 like '%" + history.Text + "%' and 약력공개=1";
				if(concern.Text != "") query[++i] += "관심분야 like '%" + concern.Text +"%' and 관심분야공개=1";
			
				switch (i)
				{
					case 0 :
						cmd = query[0];
						break;
					case 1 :
						cmd = query[0] + "where " + query[1];
						break;
					default :
						cmd = query[0] + "where " + query[1];
						int j;
						for(j=2; j<=i; j++) cmd += " and " + query[j];
						break;
				}
			}

			DataTable search_result = new DataTable("검색결과");				//테이블생성
			DataColumn ids = new DataColumn("아이디");
			DataColumn info = new DataColumn("공개된 회원정보");
			search_result.Columns.Add(ids);
			search_result.Columns.Add(info);
			
			SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connstr"]);	//데이터접속
			SqlCommand com = new SqlCommand(cmd,con);
			con.Open();
			SqlDataReader dr = com.ExecuteReader();
			while(dr.Read())
			{
				string open = null;
				if((bool)dr["이름공개"]) open += "이름: " + dr["이름"].ToString();
				if((bool)dr["주소공개"]) open += ",주소: " + dr["주소앞"].ToString();
				if((bool)dr["이메일공개"]) open += ",이메일: " + dr["이메일주소"].ToString();
				if((bool)dr["관심분야공개"]) open += ",관심분야: " + dr["관심분야"].ToString();
				if((bool)dr["약력공개"]) open += ",약력: " + dr["약력"].ToString();

				DataRow row;
				row = search_result.NewRow();
				row["아이디"] = dr["아이디"];
				row["공개된 회원정보"] = open;
				search_result.Rows.Add(row);
			}
			dr.Close();
			con.Close();

			result.DataSource = search_result;
			result.DataBind();
		}
		private void addgroupBind()
		{
			DirectoryInfo di = new DirectoryInfo(토론.cur_dir + "group/");
			FileInfo[] fi = di.GetFiles("*");
			ArrayList al = new ArrayList();
			foreach(FileInfo f in fi) al.Add(f.Name);
			addgroup.DataSource = al;
			addgroup.DataBind();
		}
		private void listBind()
		{
			DataTable dt = new DataTable("덧글");
			DataColumn text = new DataColumn("내용");
			DataColumn writer = new DataColumn("글쓴이");
			DataColumn date = new DataColumn("작성일");
			DataColumn enable = new DataColumn("버튼활성화");
			enable.DataType = System.Type.GetType("System.Boolean");
			DataColumn addid = new DataColumn("추가버튼");
			addid.DataType = System.Type.GetType("System.Boolean");
			dt.Columns.Add(text);
			dt.Columns.Add(writer);
			dt.Columns.Add(date);
			dt.Columns.Add(enable);
			dt.Columns.Add(addid);

			if(fb != null) 
			{
				foreach(comment c in fb.subcomment)
				{
					DataRow dr;
					dr = dt.NewRow();
					dr["내용"] = c.get_text();
					dr["글쓴이"] = c.get_id();
					dr["작성일"] = c.get_date();
					dr["버튼활성화"] = (c.get_id() == User.Identity.Name);
                    dr["추가버튼"] = (fb.get_id() == User.Identity.Name);					
					dt.Rows.Add(dr);
				}
				DataList1.DataSource = dt;
				DataList1.DataBind();				 
			}
		}
	

		private void result_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string id = e.Item.Cells[0].Text;
			if(!invited.Contains(id)) invited.Add(id);
			//else invited.Remove(id);
			//result.SelectedIndex = e.Item.ItemIndex;
			invited_ids.DataSource = invited;
			invited_ids.DataBind();
		}

		private void up_Click(object sender, System.EventArgs e)
		{
			if(invited_ids.SelectedIndex > 0)
			{
				int i = invited_ids.SelectedIndex;
				invited.Insert(i-1, invited_ids.SelectedItem.Text);
				invited.RemoveAt(i+1);
				invited_ids.DataSource = invited;
				invited_ids.DataBind();
				invited_ids.SelectedIndex = i-1;
			}
		}

		private void down_Click(object sender, System.EventArgs e)
		{
			if(invited_ids.SelectedIndex < invited.Count-1 && invited_ids.SelectedIndex >= 0)
			{
				int i = invited_ids.SelectedIndex;
				invited.Insert(i+2, invited_ids.SelectedItem.Text);
				invited.RemoveAt(i);
				invited_ids.DataSource = invited;
				invited_ids.DataBind();
				invited_ids.SelectedIndex = i+1;
			}
		}

		private void del_Click(object sender, System.EventArgs e)
		{
			if(invited_ids.SelectedIndex >= 0)
			{
				invited.RemoveAt(invited_ids.SelectedIndex);
				invited_ids.DataSource = invited;
				invited_ids.DataBind();
			}
		}

		private void save_Click(object sender, System.EventArgs e)
		{
			if(title.Text == "") show("제목이 비었습니다.");
			//else if(ids.Items.Count == 0) show("초대할 아이디가 비었습니다.");
			else 
			{
				if(fb == null) 
				{
					fb = new fboard(invited, 1, true, true, true, true, "", User.Identity.Name, "");
					fb.fb_index = tools.get_largest("대기");
				}
				fb.ids = invited;
				fb.id = id.Text;
				fb.response_term = term.SelectedIndex+1;
				fb.read = read.Checked;
				fb.write = write.Checked;
				fb.vote = vote.Checked;
				fb.inturn = inturn.Checked;
				fb.title = title.Text;
				fb.field = field.SelectedItem.Text;
				fb.change(contents.Text);
				fb.writewait();
				attach_comment.Enabled = true;
				start.Enabled = true;
			}
		}

		private void tolist_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("boardlist.aspx");
		}

		private void start_Click(object sender, System.EventArgs e)
		{
			show("이 토론의 셋팅은 토론 종료시까지 바꿀수 없습니다.");

			string str = "토론개설자 : " + id.Text + "     토론시작 : " + DateTime.Now.ToString();
			str += "\n주제 : " + title.Text;
			str += "\n분야 : " + field.SelectedItem.Text;
			str += "\n귀하께서 참석하신 상기의 토론이 개시되었습니다.";
			str += "\n-------------------------------------------------------";
			foreach(string s in invited)
			{
				if(s.IndexOf(":그룹이름입니다.") == -1)
				{
					tools t = new tools("mail", s);
					t.appendline(str);
				}
				else
				{
					StreamReader sr = File.OpenText(토론.cur_dir + "group/" + s.Remove(s.Length - ":그룹이름입니다.".Length,
						"그룹이름입니다.".Length));
					string idname;
					sr.ReadLine();
					while((idname = sr.ReadLine()) != null)
					{
						tools t = new tools("mail", idname);
						t.appendline(str);
					}
					fb.inturn = false;
				}
			}
			fb.start();
			Response.Redirect("boardlist.aspx");
		}

		private void inturn_CheckedChanged(object sender, System.EventArgs e)
		{
			if(inturn.Checked == true) term.Enabled = true;
			else term.Enabled = false;
			Page_Load(this, EventArgs.Empty);
		}

		private void attach_comment_Click(object sender, System.EventArgs e)
		{
			comment c = new comment(User.Identity.Name, "");
			fb.subcomment.Add(c);
			DataList1.EditItemIndex = fb.subcomment.Count-1;
			listBind();
		}

		private void DataList1_EditCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			DataList1.EditItemIndex = e.Item.ItemIndex;
			listBind();
		}

		private void DataList1_DeleteCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			fb.subcomment.RemoveAt(e.Item.ItemIndex);
			fb.writewait();
			listBind();
		}

		private void DataList1_UpdateCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			comment c = new comment(User.Identity.Name, ((TextBox)e.Item.FindControl("edittext")).Text);
			fb.subcomment.RemoveAt(e.Item.ItemIndex);
			fb.subcomment.Insert(e.Item.ItemIndex, c);
			fb.writewait();
			DataList1.EditItemIndex = -1;
			listBind();
		}

		private void DataList1_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			if(e.CommandName == "add")
			{
				string id = ((Label)e.Item.FindControl("writer")).Text;
				if(!invited.Contains(id)) invited.Add(id);
				//else invited.Remove(id);
				//result.SelectedIndex = e.Item.ItemIndex;
				invited_ids.DataSource = invited;
				invited_ids.DataBind();
			}
		}

		private void add_g_Click(object sender, System.EventArgs e)
		{
			/*StreamReader sr = File.OpenText(토론.cur_dir + "group/" + addgroup.SelectedItem.Text);
			sr.ReadLine();
			string str = null;
			while((str = sr.ReadLine()) != null) if(!invited.Contains(str))*/
			invited.Add(addgroup.SelectedItem.Text + ":그룹이름입니다.");
			//sr.Close();
			invited_ids.DataSource = invited;
			invited_ids.DataBind();
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

		private void clear_Click(object sender, System.EventArgs e)
		{
			invited.Clear();
			invited_ids.DataSource = invited;
			invited_ids.DataBind();
		}
	
	}
}
