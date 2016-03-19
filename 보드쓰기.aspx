<%@ Page language="c#" Codebehind="보드쓰기.aspx.cs" AutoEventWireup="false" validateRequest="false" Inherits="startpage.보드쓰기" %>
<%@ Register TagPrefix="uc1" TagName="left" Src="left.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>보드쓰기</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="보드쓰기" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%">
				<TBODY>
					<TR>
						<TD width="130">
							<uc1:left id="Left1" runat="server"></uc1:left></TD>
						<TD><FONT face="굴림">
								<P><FONT face="굴림" size="6"><STRONG>보드쓰기</STRONG></FONT></P>
								<P><FONT face="굴림">글쓴이
										<asp:textbox id="id" runat="server" ReadOnly="True" BackColor="WhiteSmoke"></asp:textbox></FONT></P>
								<P>
									<FONT face="굴림">제목&nbsp;&nbsp;&nbsp;
										<asp:textbox id="title" runat="server" Width="469px" BackColor="WhiteSmoke"></asp:textbox>&nbsp;&nbsp;&nbsp;
								</P>
								<P>
							</FONT><FONT face="굴림">
								<asp:textbox id="contents" runat="server" Width="769px" Height="439px" TextMode="MultiLine" BackColor="WhiteSmoke"
									Font-Size="Small"></asp:textbox></FONT></P>
							<P><FONT face="굴림">&nbsp;&nbsp;</FONT><FONT face="굴림">&nbsp;&nbsp;</FONT><FONT face="굴림">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:button id="write" runat="server" Text="확인"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:Button id="cancel" runat="server" Text="취소"></asp:Button></FONT></P>
							</FONT>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			</FONT></FONT>
		</form>
	</body>
</HTML>
