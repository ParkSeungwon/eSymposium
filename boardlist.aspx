<%@ Page language="c#" Codebehind="boardlist.aspx.cs" AutoEventWireup="false" Inherits="startpage.boardlist" EnableSessionState="True"%>
<%@ Register TagPrefix="uc1" TagName="left" Src="left.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>boardlist</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="boardlist" method="post" runat="server">
			<FONT face="굴림">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%">
					<TBODY>
						<TR>
							<TD width="135" hi="100%"><uc1:left id="Left1" runat="server"></uc1:left></TD>
							<TD valign="top">
								<P><STRONG><FONT size="6">토론게시판</FONT></STRONG></P>
								<P><FONT size="4"> </FONT>
									<asp:radiobuttonlist id="fieldselect" runat="server" Width="400px" AutoPostBack="True" RepeatDirection="Horizontal">
										<asp:ListItem Value="정치,경제,시사">정치,경제,시사</asp:ListItem>
										<asp:ListItem Value="학술">학술</asp:ListItem>
										<asp:ListItem Value="친목">친목</asp:ListItem>
										<asp:ListItem Value="대기">대기</asp:ListItem>
									</asp:radiobuttonlist><asp:datagrid id="grid" runat="server" PageSize="20" AutoGenerateColumns="False" CellPadding="3"
										BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CCCCCC" AllowSorting="True" AllowPaging="True"
										Font-Size="Smaller">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
										<ItemStyle ForeColor="#000066"></ItemStyle>
										<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
										<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="게시물번호" SortExpression="게시물번호" HeaderText="게시물번호"></asp:BoundColumn>
											<asp:ButtonColumn DataTextField="아이디" SortExpression="아이디" HeaderText="아이디" CommandName="mail"></asp:ButtonColumn>
											<asp:ButtonColumn DataTextField="제목" SortExpression="제목" HeaderText="제목" CommandName="go"></asp:ButtonColumn>
											<asp:BoundColumn DataField="작성일" SortExpression="작성일" HeaderText="작성일"></asp:BoundColumn>
											<asp:BoundColumn DataField="열람" SortExpression="열람" HeaderText="열람"></asp:BoundColumn>
											<asp:BoundColumn DataField="덧글" SortExpression="덧글" HeaderText="덧글"></asp:BoundColumn>
											<asp:BoundColumn DataField="투표" SortExpression="투표" HeaderText="투표"></asp:BoundColumn>
											<asp:BoundColumn DataField="차례로" SortExpression="차례로" HeaderText="차례로"></asp:BoundColumn>
											<asp:BoundColumn DataField="페이지" SortExpression="페이지" HeaderText="페이지"></asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></P>
			</FONT>
			<P><FONT face="굴림"></FONT></P>
			<P><FONT face="굴림">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:dropdownlist id="drop" runat="server">
						<asp:ListItem Value="아이디">아이디</asp:ListItem>
						<asp:ListItem Value="제목" Selected="True">제목</asp:ListItem>
					</asp:dropdownlist>&nbsp;&nbsp;
					<asp:textbox id="search_text" runat="server" Width="442px" BackColor="AliceBlue"></asp:textbox>&nbsp;
					<asp:button id="search" runat="server" Text="검색"></asp:button></FONT></P>
			<P><FONT face="굴림">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
					<asp:button id="Button1" runat="server" Text="새로운 게시판 생성"></asp:button></P>
			</FONT></FONT></TD></TR></TBODY></TABLE>&nbsp;</FONT><FONT face="굴림">&nbsp;&nbsp;&nbsp;</FONT></form>
	</body>
</HTML>
