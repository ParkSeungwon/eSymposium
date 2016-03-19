<%@ Page language="c#" Codebehind="vote.aspx.cs" AutoEventWireup="false" Inherits="startpage.vote" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>vote</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="vote" method="post" runat="server">
			<FONT face="굴림">
				<P>
					<asp:Button id="tomain" runat="server" Text="메인페이지로"></asp:Button></P>
				<P>
					<asp:DataGrid id="grid" runat="server"></asp:DataGrid></P>
			</FONT>
		</form>
	</body>
</HTML>
