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
			<FONT face="����">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%">
					<TBODY>
						<TR>
							<TD width="135" hi="100%"><uc1:left id="Left1" runat="server"></uc1:left></TD>
							<TD valign="top">
								<P><STRONG><FONT size="6">��аԽ���</FONT></STRONG></P>
								<P><FONT size="4"> </FONT>
									<asp:radiobuttonlist id="fieldselect" runat="server" Width="400px" AutoPostBack="True" RepeatDirection="Horizontal">
										<asp:ListItem Value="��ġ,����,�û�">��ġ,����,�û�</asp:ListItem>
										<asp:ListItem Value="�м�">�м�</asp:ListItem>
										<asp:ListItem Value="ģ��">ģ��</asp:ListItem>
										<asp:ListItem Value="���">���</asp:ListItem>
									</asp:radiobuttonlist><asp:datagrid id="grid" runat="server" PageSize="20" AutoGenerateColumns="False" CellPadding="3"
										BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CCCCCC" AllowSorting="True" AllowPaging="True"
										Font-Size="Smaller">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
										<ItemStyle ForeColor="#000066"></ItemStyle>
										<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
										<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="�Խù���ȣ" SortExpression="�Խù���ȣ" HeaderText="�Խù���ȣ"></asp:BoundColumn>
											<asp:ButtonColumn DataTextField="���̵�" SortExpression="���̵�" HeaderText="���̵�" CommandName="mail"></asp:ButtonColumn>
											<asp:ButtonColumn DataTextField="����" SortExpression="����" HeaderText="����" CommandName="go"></asp:ButtonColumn>
											<asp:BoundColumn DataField="�ۼ���" SortExpression="�ۼ���" HeaderText="�ۼ���"></asp:BoundColumn>
											<asp:BoundColumn DataField="����" SortExpression="����" HeaderText="����"></asp:BoundColumn>
											<asp:BoundColumn DataField="����" SortExpression="����" HeaderText="����"></asp:BoundColumn>
											<asp:BoundColumn DataField="��ǥ" SortExpression="��ǥ" HeaderText="��ǥ"></asp:BoundColumn>
											<asp:BoundColumn DataField="���ʷ�" SortExpression="���ʷ�" HeaderText="���ʷ�"></asp:BoundColumn>
											<asp:BoundColumn DataField="������" SortExpression="������" HeaderText="������"></asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></P>
			</FONT>
			<P><FONT face="����"></FONT></P>
			<P><FONT face="����">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:dropdownlist id="drop" runat="server">
						<asp:ListItem Value="���̵�">���̵�</asp:ListItem>
						<asp:ListItem Value="����" Selected="True">����</asp:ListItem>
					</asp:dropdownlist>&nbsp;&nbsp;
					<asp:textbox id="search_text" runat="server" Width="442px" BackColor="AliceBlue"></asp:textbox>&nbsp;
					<asp:button id="search" runat="server" Text="�˻�"></asp:button></FONT></P>
			<P><FONT face="����">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
					<asp:button id="Button1" runat="server" Text="���ο� �Խ��� ����"></asp:button></P>
			</FONT></FONT></TD></TR></TBODY></TABLE>&nbsp;</FONT><FONT face="����">&nbsp;&nbsp;&nbsp;</FONT></form>
	</body>
</HTML>
