<%@ Page language="c#" Codebehind="ingroup.aspx.cs" AutoEventWireup="false" Inherits="startpage.igroup" %>
<%@ Register TagPrefix="uc1" TagName="left" Src="left.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>igroup</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="igroup" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD width="135"><uc1:left id="Left1" runat="server"></uc1:left></TD>
					<TD valign="top">
						<P><FONT face="����" size="6"><STRONG>�׷����</STRONG></FONT></P>
						<P>�׷�� :
							<asp:label id="group" runat="server">Label</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							������ :
							<asp:label id="opener" runat="server">Label</asp:label></FONT></P>
						<P></P>
						<P><FONT face="����">���� :
								<asp:label id="expl" runat="server">Label</asp:label></FONT></P>
						<FONT face="����">
							<P><asp:button id="retire" runat="server" Text="Ż���ϱ�"></asp:button><asp:button id="close" runat="server" Text="�׷����"></asp:button></P>
							<P><asp:textbox id="text" runat="server" Width="589px" Height="80px"></asp:textbox><asp:button id="send" runat="server" Text="������ �������� ����������"></asp:button></P>
							<P><asp:button id="viewmember" runat="server" Text="�����ڸ���Ʈ����"></asp:button><asp:label id="member" runat="server"></asp:label></P>
							<P>
						</FONT><FONT face="����">
							<asp:datalist id="list" runat="server" Width="764px" BorderWidth="2px" CellPadding="3" BackColor="White"
								CellSpacing="1" BorderStyle="Ridge" BorderColor="White">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
								<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
								<ItemTemplate>
									<P>
										<asp:Label id=comment runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.����") %>'>
										</asp:Label></P>
									<P>&nbsp;&nbsp;�۾��� :
										<asp:Label id=writer runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.�۾���") %>'>
										</asp:Label>&nbsp;&nbsp; �ۼ��� :
										<asp:Label id=date runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.�ۼ���") %>'>
										</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:Button id=com_edit runat="server" Text="����" Enabled='<%# DataBinder.Eval(Container.DataItem, "��ưȰ��ȭ") %>' CommandName="edit">
										</asp:Button>
										<asp:Button id=com_del runat="server" Text="����" Enabled='<%# DataBinder.Eval(Container.DataItem, "��ưȰ��ȭ") %>' CommandName="delete">
										</asp:Button>
										<asp:Button id=add runat="server" Text="����ó��" Enabled='<%# DataBinder.Eval(Container.DataItem, "�߰���ư") %>' CommandName="add">
										</asp:Button></P>
								</ItemTemplate>
								<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
								<EditItemTemplate>
									<P>
										<asp:TextBox id=edittext runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "����") %>' Height="92px" Width="648px" TextMode="MultiLine">
										</asp:TextBox>
										<asp:Button id="edit_ok" runat="server" Text="Ȯ��" CommandName="update"></asp:Button></P>
								</EditItemTemplate>
							</asp:datalist><asp:button id="attach" runat="server" Text="���Խ�û" DESIGNTIMEDRAGDROP="110"></asp:button></P></FONT></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
