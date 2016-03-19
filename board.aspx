<%@ Page language="c#" Codebehind="board.aspx.cs" AutoEventWireup="false" Inherits="startpage.board1" %>
<%@ Register TagPrefix="uc1" TagName="left" Src="left.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>board</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="board" method="post" runat="server">
			<FONT face="굴림">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TBODY>
						<TR>
							<TD width="130"><uc1:left id="Left1" runat="server"></uc1:left></TD>
							<TD valign="top">
								<P><asp:panel id="panel" runat="server" Width="754px" Height="334px">
										<P><FONT size="2">글쓴이</FONT>
											<asp:textbox id="id" runat="server" Width="93px" BackColor="AliceBlue" ReadOnly="True"></asp:textbox><FONT size="2">&nbsp;&nbsp;</FONT><FONT size="2">&nbsp;작성일:</FONT>
											<asp:label id="date" runat="server"></asp:label><FONT size="2">&nbsp;</FONT>
			</FONT></P>
			<P><FONT size="2">제목&nbsp;&nbsp; </FONT>
				<asp:textbox id="title" runat="server" Width="382px" BackColor="AliceBlue"></asp:textbox><FONT size="2">&nbsp;&nbsp;&nbsp;<FONT size="2">&nbsp;</FONT>&nbsp;<FONT size="2">&nbsp;&nbsp;&nbsp;</FONT></FONT></P>
			<P><asp:textbox id="contents" runat="server" Width="719px" Height="439px" BackColor="AliceBlue"
					TextMode="MultiLine" BorderColor="White"></asp:textbox><asp:button id="save" runat="server" Text="저장"></asp:button><asp:button id="del" runat="server" Text="삭제"></asp:button><asp:datalist id="Datalist1" runat="server" Width="742px" Height="0px" BackColor="White" BorderColor="White"
					BorderStyle="Ridge" CellSpacing="1" CellPadding="3" BorderWidth="2px" Font-Size="Smaller">
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
					<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
					<ItemTemplate>
						<P>
							<asp:Label id=comment runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.내용") %>'>
							</asp:Label></P>
						<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;글쓴이 :
							<asp:Label id=writer runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.글쓴이") %>'>
							</asp:Label>&nbsp;&nbsp; 작성일 :
							<asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.작성일") %>'>
							</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Button id=com_edit runat="server" Text="수정" CommandName="edit" Enabled='<%# DataBinder.Eval(Container.DataItem, "버튼활성화") %>'>
							</asp:Button>
							<asp:Button id=com_del runat="server" Text="삭제" CommandName="delete" Enabled='<%# DataBinder.Eval(Container.DataItem, "버튼활성화") %>'>
							</asp:Button></P>
					</ItemTemplate>
					<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
					<EditItemTemplate>
						<asp:TextBox id=edittext runat="server" Height="96px" Width="729px" TextMode="MultiLine" Text='<%# DataBinder.Eval(Container.DataItem, "내용") %>'>
						</asp:TextBox>
						<asp:Button id="ok" runat="server" Text="확인" CommandName="update"></asp:Button>
					</EditItemTemplate>
				</asp:datalist></P>
			<asp:button id="attch" runat="server" Text="덧글달기" DESIGNTIMEDRAGDROP="33"></asp:button></asp:panel><FONT face="굴림">
				<P><asp:label id="label2" runat="server" Width="537px" Height="35px" Font-Size="X-Large" Font-Bold="True"></asp:label></P>
				<P><asp:datagrid id="grid" runat="server" Width="742px" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None"
						CellPadding="3" BorderWidth="1px" GridLines="Horizontal" AllowSorting="True" AllowPaging="True"
						AutoGenerateColumns="False">
						<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
						<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
						<ItemStyle ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
						<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
						<Columns>
							<asp:BoundColumn DataField="게시물번호" SortExpression="게시물번호" HeaderText="게시물번호"></asp:BoundColumn>
							<asp:ButtonColumn DataTextField="아이디" SortExpression="아이디" HeaderText="아이디" CommandName="mail"></asp:ButtonColumn>
							<asp:ButtonColumn DataTextField="제목" SortExpression="제목" HeaderText="제목" CommandName="go"></asp:ButtonColumn>
							<asp:BoundColumn DataField="작성일" SortExpression="작성일" HeaderText="작성일"></asp:BoundColumn>
						</Columns>
						<PagerStyle HorizontalAlign="Right" ForeColor="#4A3C8C" BackColor="#E7E7FF" Mode="NumericPages"></PagerStyle>
					</asp:datagrid>&nbsp;</P>
				<P>&nbsp;
					<asp:dropdownlist id="drop" runat="server">
						<asp:ListItem Value="아이디">아이디</asp:ListItem>
						<asp:ListItem Value="제목" Selected="True">제목</asp:ListItem>
					</asp:dropdownlist>&nbsp;&nbsp;
					<asp:textbox id="search_text" runat="server" Width="442px"></asp:textbox>&nbsp;
					<asp:button id="search" runat="server" Text="검색"></asp:button><asp:button id="write" runat="server" Text="글쓰기"></asp:button></P>
			</FONT></FONT></TD></TR></TBODY></TABLE></FONT></form>
	</body>
</HTML>
