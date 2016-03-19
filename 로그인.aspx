<%@ Page language="c#" Codebehind="로그인.aspx.cs" AutoEventWireup="false" Inherits="startpage.로그인" %>
<%@ Register TagPrefix="uc1" TagName="left" Src="left.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>로그인</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="로그인" method="post" runat="server">
			<CENTER>
				<H3>
					<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
						<TR>
							<TD width="130">
								<uc1:left id="Left1" runat="server" DESIGNTIMEDRAGDROP="85"></uc1:left></TD>
							<TD><FONT face="굴림">&nbsp;&nbsp;&nbsp;
									<H3 align="center">LOG IN(로그인)</H3>
									<P align="center">&nbsp;</P>
									<P align="center">
									<P align="center"></P>
									<DIV align="center">
										<HR width="300" SIZE="1">
									</DIV>
									<P align="center">&nbsp;아이디&nbsp;:
										<asp:TextBox id="id" runat="server" BorderWidth="1px" BorderStyle="Solid"></asp:TextBox></P>
									<P align="center">패스워드&nbsp;:
										<asp:TextBox id="password" runat="server" BorderWidth="1px" BorderStyle="Solid" TextMode="Password"></asp:TextBox></P>
									<P align="center">
										<asp:Button id="btnAuth" runat="server" BorderWidth="1px" BorderStyle="Solid" Width="118px"
											Text="확인"></asp:Button>
										<asp:Button id="cancel" runat="server" BorderWidth="1px" BorderStyle="Solid" Width="118px" Text="취소"></asp:Button></P>
									<P align="center">
										<DIV align="center">
											<HR width="300" SIZE="1">
										</DIV>
									<P align="center">
										<asp:Label id="lblMsg" runat="server" ForeColor="Red"></asp:Label></P>
									<P align="center">
									&nbsp;&nbsp; </FONT></P>
							</TD>
						</TR>
					</TABLE>
				</H3>
			</CENTER>
		</form>
	</body>
</HTML>
