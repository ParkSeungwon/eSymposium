<%@ Register TagPrefix="uc1" TagName="left" Src="left.ascx" %>
<%@ Page language="c#" Codebehind="����������.aspx.cs" AutoEventWireup="false" Inherits="startpage.����������" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>����������</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="����������" method="post" runat="server">
			<P><FONT face="����">
					<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
						<TBODY>
							<TR>
								<TD width="130">
									<uc1:left id="Left1" runat="server"></uc1:left></TD>
								<TD valign="top">
									<P><FONT face="����" size="6"><STRONG>����������</STRONG></FONT></P>
									<P><FONT face="����">To&nbsp;
											<asp:TextBox id="id" runat="server" DESIGNTIMEDRAGDROP="44" BackColor="Gainsboro"></asp:TextBox></P>
									<P>
										<asp:TextBox id="mail" runat="server" Height="350px" Width="650px" TextMode="MultiLine" BackColor="WhiteSmoke"></asp:TextBox></P>
									<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:Button id="ok" runat="server" Text="Ȯ��" ToolTip="�α����� ����"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:Button id="cancel" runat="server" Text="���"></asp:Button></P>
				</FONT></TD></TR></TBODY></TABLE></FONT></P>
		</form>
	</body>
</HTML>
