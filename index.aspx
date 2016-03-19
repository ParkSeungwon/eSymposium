<%@ Register TagPrefix="uc1" TagName="left" Src="left.ascx" %>
<%@ Page language="c#" Codebehind="index.aspx.cs" AutoEventWireup="false" Inherits="startpage.index2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>e심포지움</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="index2" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD width="130" rowSpan="3"><uc1:left id="Left1" runat="server"></uc1:left></TD>
					<TD bgColor="gainsboro" colSpan="2"><asp:imagebutton id="log" runat="server" ImageUrl="data/login.gif"></asp:imagebutton><asp:imagebutton id="logout" runat="server" ImageUrl="data/logout.gif"></asp:imagebutton><asp:imagebutton id="sign" runat="server" ImageUrl="data/sign.gif"></asp:imagebutton><asp:imagebutton id="change" runat="server" ImageUrl="data/infochange.gif"></asp:imagebutton><A href="board.aspx?field=notice"><IMG height="30" alt="" src="data/notice.gif"></A>
						<A href="board.aspx?field=board"><IMG height="30" src="data/board.gif" width="100"></A>
						<A href="boardlist.aspx"><IMG height="30" alt="" src="data/sympo.gif"></A> <A href="group.aspx">
							<IMG alt="" src="data/group.gif"></A> <A href="쪽지읽기.aspx"><IMG height="30" alt="" src="data/em3.bmp" width="30"></A>
						<A href="쪽지보내기.aspx"><IMG height="30" alt="" src="data/em2.bmp" width="30"></A> <A href="쪽지보내기.aspx?id=webmaster">
							<IMG height="30" alt="" src="data/mail2.gif"></A>
					</TD>
				</TR>
				<tr>
					<TD style="WIDTH: 419px" colSpan="2"><asp:adrotator id="ad" runat="server" Target="_blank" AdvertisementFile="data/ad.xml" Height="120px"
							Width="800px"></asp:adrotator></TD>
				</tr>
				<tr>
					<td style="WIDTH: 352px" width="352" valign="top">
						<P><IMG alt="" src="data/hot.bmp" align="top">&nbsp;</P>
						<P><asp:listbox id="direct" runat="server" Width="400px" ForeColor="Black" AutoPostBack="True" Rows="5"
								Font-Bold="True" BackColor="AliceBlue" Font-Size="Small" Height="400px"></asp:listbox></P>
					</td>
					<td valign="top"><asp:datalist id="books" runat="server" Width="390px" ShowHeader="False" ShowFooter="False">
							<HeaderTemplate>
								<FONT face="고딕">발간된 책들</FONT>
							</HeaderTemplate>
							<SeparatorStyle BorderStyle="None" BorderColor="White" BackColor="Transparent"></SeparatorStyle>
							<FooterTemplate>
							</FooterTemplate>
							<ItemStyle Font-Names="궁서" HorizontalAlign="Left" CssClass="sty.css" VerticalAlign="Middle"></ItemStyle>
							<ItemTemplate>
								<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="300" border="0">
									<TR>
										<TD width="60" height="100">
											<asp:Image id=img runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "이미지경로") %>' Width="90px" Height="90px" ImageAlign="Left">
											</asp:Image></TD>
										<TD>
											<P>서명 :
												<%# DataBinder.Eval(Container.DataItem, "제목") %>
											</P>
											<P><FONT style="LINE-HEIGHT: 20%; LIST-STYLE-TYPE: disc" face="굴림">저자 :
													<%# DataBinder.Eval(Container.DataItem, "저자") %>
											</P>
											<P>출판사 :
												<%# DataBinder.Eval(Container.DataItem, "출판사") %>
											</P>
											<P>출판일 :
												<%# DataBinder.Eval(Container.DataItem, "출판일") %>
												</FONT></P>
										</TD>
									</TR>
								</TABLE>
							</ItemTemplate>
							<SeparatorTemplate>
								<IMG height="3" alt="" src="data/line2.bmp" width="390">
							</SeparatorTemplate>
							<HeaderStyle Font-Names="휴먼매직체"></HeaderStyle>
						</asp:datalist></td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
