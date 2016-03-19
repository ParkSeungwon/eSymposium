<%@ Register TagPrefix="uc1" TagName="left" Src="left.ascx" %>
<%@ Page language="c#" Codebehind="쪽지읽기.aspx.cs" AutoEventWireup="false" Inherits="startpage.쪽지읽기" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>쪽지읽기</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<FONT face="굴림">
			<FORM id="쪽지보내기" method="post" runat="server">
				<P><FONT face="굴림">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TBODY>
								<TR>
									<TD width="130">
										<uc1:left id="Left1" runat="server"></uc1:left></TD>
									<TD valign=top>
										<P><FONT face="굴림" size="6"><STRONG>쪽지읽기</STRONG></FONT></P>
										<P><FONT face="굴림">&nbsp;
												<asp:Label id="id" runat="server"></asp:Label></P>
										<P>
											<asp:TextBox id="mail" runat="server" Height="350px" Width="650px" TextMode="MultiLine" BackColor="WhiteSmoke"></asp:TextBox></P>
										<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
											&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:Button id="delete" runat="server" Text="삭제"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:Button id="ok" runat="server" Text="확인"></asp:Button></P>
					</FONT>
			</TD></TR></TBODY></TABLE> </FONT></P></FORM></FONT>
	</body>
</HTML>
