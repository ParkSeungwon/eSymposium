<%@ Page language="c#" Codebehind="��ȣ����.aspx.cs" AutoEventWireup="false" Inherits="startpage.��ȣ����" %>
<%@ Register TagPrefix="uc1" TagName="left" Src="left.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>��ȣ����</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="��ȣ����" method="post" runat="server">
			<FONT face="����">
				<CENTER>
					<H3>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD width="130">
									<uc1:left id="Left1" runat="server"></uc1:left>&nbsp;&nbsp;&nbsp;&nbsp;
								</TD>
								<TD>
									<P align="center">&nbsp;PASSWORD ����
									</P>
									<P align="center">
										<DIV align="center">
											<HR width="300" SIZE="1">
										</DIV>
									<P align="center"></P>
									<P align="center">���� �н�����&nbsp;:
										<asp:TextBox id="pre_pass" runat="server" TextMode="Password" BorderWidth="1px" BorderStyle="Solid"></asp:TextBox></P>
									<P align="center">�н�����&nbsp;:
										<asp:TextBox id="pass1" runat="server" TextMode="Password" BorderWidth="1px" BorderStyle="Solid"></asp:TextBox></P>
									<P align="center">�н�����Ȯ��&nbsp;:
										<asp:TextBox id="pass2" runat="server" TextMode="Password" BorderWidth="1px" BorderStyle="Solid"></asp:TextBox></P>
									<P align="center">
										<asp:Button id="btnAuth" runat="server" BorderWidth="1px" BorderStyle="Solid" Width="118px" Text="Ȯ��"></asp:Button>
										<asp:Button id="cancel" runat="server" BorderWidth="1px" BorderStyle="Solid" Width="118px" Text="���"></asp:Button></P>
									<P align="center">
										<DIV align="center">
											<HR width="300" SIZE="1">
										</DIV>
									<P align="center">
										<asp:Label id="lblMsg" runat="server" ForeColor="Red"></asp:Label>
										<asp:CompareValidator id="CompareValidator1" runat="server" ControlToValidate="pass2" ControlToCompare="pass1" ErrorMessage="���ο� �н����尡  ��ġ���� �ʽ��ϴ�."></asp:CompareValidator></P>
									&nbsp;&nbsp;
								</TD>
							</TR>
						</TABLE>
			</FONT></H3></CENTER>
		</form>
	</body>
</HTML>
