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
			<FONT face="����">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TBODY>
						<TR>
							<TD width="130"><uc1:left id="Left1" runat="server"></uc1:left></TD>
							<TD valign="top">
								<P><asp:panel id="panel" runat="server" Width="754px" Height="334px">
										<P><FONT size="2">�۾���</FONT>
											<asp:textbox id="id" runat="server" Width="93px" BackColor="AliceBlue" ReadOnly="True"></asp:textbox><FONT size="2">&nbsp;&nbsp;</FONT><FONT size="2">&nbsp;�ۼ���:</FONT>
											<asp:label id="date" runat="server"></asp:label><FONT size="2">&nbsp;</FONT>
			</FONT></P>
			<P><FONT size="2">����&nbsp;&nbsp; </FONT>
				<asp:textbox id="title" runat="server" Width="382px" BackColor="AliceBlue"></asp:textbox><FONT size="2">&nbsp;&nbsp;&nbsp;<FONT size="2">&nbsp;</FONT>&nbsp;<FONT size="2">&nbsp;&nbsp;&nbsp;</FONT></FONT></P>
			<P><asp:textbox id="contents" runat="server" Width="719px" Height="439px" BackColor="AliceBlue"
					TextMode="MultiLine" BorderColor="White"></asp:textbox><asp:button id="save" runat="server" Text="����"></asp:button><asp:button id="del" runat="server" Text="����"></asp:button><asp:datalist id="Datalist1" runat="server" Width="742px" Height="0px" BackColor="White" BorderColor="White"
					BorderStyle="Ridge" CellSpacing="1" CellPadding="3" BorderWidth="2px" Font-Size="Smaller">
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
					<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
					<ItemTemplate>
						<P>
							<asp:Label id=comment runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.����") %>'>
							</asp:Label></P>
						<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�۾��� :
							<asp:Label id=writer runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.�۾���") %>'>
							</asp:Label>&nbsp;&nbsp; �ۼ��� :
							<asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.�ۼ���") %>'>
							</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Button id=com_edit runat="server" Text="����" CommandName="edit" Enabled='<%# DataBinder.Eval(Container.DataItem, "��ưȰ��ȭ") %>'>
							</asp:Button>
							<asp:Button id=com_del runat="server" Text="����" CommandName="delete" Enabled='<%# DataBinder.Eval(Container.DataItem, "��ưȰ��ȭ") %>'>
							</asp:Button></P>
					</ItemTemplate>
					<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
					<EditItemTemplate>
						<asp:TextBox id=edittext runat="server" Height="96px" Width="729px" TextMode="MultiLine" Text='<%# DataBinder.Eval(Container.DataItem, "����") %>'>
						</asp:TextBox>
						<asp:Button id="ok" runat="server" Text="Ȯ��" CommandName="update"></asp:Button>
					</EditItemTemplate>
				</asp:datalist></P>
			<asp:button id="attch" runat="server" Text="���۴ޱ�" DESIGNTIMEDRAGDROP="33"></asp:button></asp:panel><FONT face="����">
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
							<asp:BoundColumn DataField="�Խù���ȣ" SortExpression="�Խù���ȣ" HeaderText="�Խù���ȣ"></asp:BoundColumn>
							<asp:ButtonColumn DataTextField="���̵�" SortExpression="���̵�" HeaderText="���̵�" CommandName="mail"></asp:ButtonColumn>
							<asp:ButtonColumn DataTextField="����" SortExpression="����" HeaderText="����" CommandName="go"></asp:ButtonColumn>
							<asp:BoundColumn DataField="�ۼ���" SortExpression="�ۼ���" HeaderText="�ۼ���"></asp:BoundColumn>
						</Columns>
						<PagerStyle HorizontalAlign="Right" ForeColor="#4A3C8C" BackColor="#E7E7FF" Mode="NumericPages"></PagerStyle>
					</asp:datagrid>&nbsp;</P>
				<P>&nbsp;
					<asp:dropdownlist id="drop" runat="server">
						<asp:ListItem Value="���̵�">���̵�</asp:ListItem>
						<asp:ListItem Value="����" Selected="True">����</asp:ListItem>
					</asp:dropdownlist>&nbsp;&nbsp;
					<asp:textbox id="search_text" runat="server" Width="442px"></asp:textbox>&nbsp;
					<asp:button id="search" runat="server" Text="�˻�"></asp:button><asp:button id="write" runat="server" Text="�۾���"></asp:button></P>
			</FONT></FONT></TD></TR></TBODY></TABLE></FONT></form>
	</body>
</HTML>
