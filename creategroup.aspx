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
			<FONT face="굴림">
				<P>그룹명
					<asp:textbox id="name" runat="server"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="그룹명이 필요합니다." ControlToValidate="name"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="설명이 필요합니다." ControlToValidate="explain"></asp:requiredfieldvalidator></P>
				<P>설명
					<asp:textbox id="explain" runat="server" Width="550px"></asp:textbox><asp:button id="open" runat="server" Text="그룹개설"></asp:button>
					<asp:Button id="tomain" runat="server" Text="메인페이지로" CausesValidation="False"></asp:Button></P>
			</FONT>
		</form>
	</body>
</HTML>
