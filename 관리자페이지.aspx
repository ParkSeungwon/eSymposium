<%@ Page language="c#" Codebehind="관리자페이지.aspx.cs" AutoEventWireup="false" Inherits="startpage.관리자페이지" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>관리자페이지</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="관리자페이지" method="post" runat="server">
			<FONT face="굴림">
				<P>제목
					<asp:TextBox id="title" runat="server" Width="385px"></asp:TextBox></P>
				<P>필드
					<asp:TextBox id="field" runat="server" Width="377px"></asp:TextBox></P>
				<P>게시물번호
					<asp:TextBox id="num" runat="server"></asp:TextBox>
					<asp:Button id="totop" runat="server" Text="메인으로 올림"></asp:Button>
					<asp:Label id="Label" runat="server"></asp:Label></P>
				<P>&nbsp;</P>
			</FONT>
		</form>
	</body>
</HTML>
