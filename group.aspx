<%@ Register TagPrefix="uc1" TagName="left" Src="left.ascx" %>
<%@ Page language="c#" Codebehind="group.aspx.cs" AutoEventWireup="false" Inherits="startpage.group" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>group</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="group" method="post" runat="server">
			<TABLE id="Table1" width="100%">
				<TBODY>
					<TR>
						<TD width="130">
							<uc1:left id="Left1" runat="server"></uc1:left></TD>
						<TD valign="top">
							<P><FONT size="6"><STRONG>�׷�</STRONG></FONT></P>
							<P>
								<FONT face="����">
							</P>
							<P>�׷��
								<asp:textbox id="name" runat="server"></asp:textbox>
								<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="�׷���� �ʿ��մϴ�." ControlToValidate="name"></asp:requiredfieldvalidator>
								<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="������ �ʿ��մϴ�." ControlToValidate="explain"></asp:requiredfieldvalidator></P>
							<P>����
								<asp:textbox id="explain" runat="server" Width="550px"></asp:textbox>
								<asp:button id="open" runat="server" Text="�׷찳��"></asp:button></P>
							<P></FONT>
								<asp:dropdownlist id="ddl" runat="server">
									<asp:ListItem Value="�׷��">�׷��</asp:ListItem>
									<asp:ListItem Value="����" Selected="True">����</asp:ListItem>
								</asp:dropdownlist>
								<asp:textbox id="search_text" runat="server" Width="330px"></asp:textbox>
								<asp:button id="list" runat="server" Text="�׷�˻�" CausesValidation="False"></asp:button></P>
							<P></P>
							<P>
								<asp:datagrid id="grid" runat="server" AutoGenerateColumns="False">
									<Columns>
										<asp:BoundColumn DataField="�׷��" HeaderText="�׷��"></asp:BoundColumn>
										<asp:BoundColumn DataField="����" HeaderText="����"></asp:BoundColumn>
										<asp:BoundColumn DataField="������" HeaderText="������"></asp:BoundColumn>
										<asp:ButtonColumn Text="�̵�" ButtonType="PushButton" HeaderText="---"></asp:ButtonColumn>
									</Columns>
								</asp:datagrid></P>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			</FONT>
			<P></P>
		</form>
	</body>
</HTML>
