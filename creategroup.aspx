<%@ Page language="c#" Codebehind="creategroup.aspx.cs" AutoEventWireup="false" Inherits="startpage.creategroup" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>creategroup</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="creategroup" method="post" runat="server">
			<FONT face="����">
				<P>�׷��
					<asp:textbox id="name" runat="server"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="�׷���� �ʿ��մϴ�." ControlToValidate="name"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="������ �ʿ��մϴ�." ControlToValidate="explain"></asp:requiredfieldvalidator></P>
				<P>����
					<asp:textbox id="explain" runat="server" Width="550px"></asp:textbox><asp:button id="open" runat="server" Text="�׷찳��"></asp:button>
					<asp:Button id="tomain" runat="server" Text="������������" CausesValidation="False"></asp:Button></P>
			</FONT>
		</form>
	</body>
</HTML>
