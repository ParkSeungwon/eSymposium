<%@ Page language="c#" Codebehind="�������.aspx.cs" AutoEventWireup="false" Inherits="startpage.�������" %>
<%@ Register TagPrefix="uc1" TagName="left" Src="left.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�������</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="�������" method="post" runat="server">
			<SPAN>
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD width="130">
							<uc1:left id="Left1" runat="server"></uc1:left></TD>
						<TD valign=top>
							<P><FONT face="����" size="6"><STRONG>�������</STRONG></FONT></P>
							<P>
								<asp:image id="image" runat="server" Width="82px"></asp:image>80X80&nbsp;&nbsp; <INPUT id="fileup" style="WIDTH: 384px; HEIGHT: 22px" type="file" size="44" name="fileup" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:button id="upimage" runat="server" Text="�������ε�"></asp:button></P>
						</TD>
					</TR>
				</TABLE>
			</SPAN>
		</form>
	</body>
</HTML>
