<%@ Register TagPrefix="uc1" TagName="left" Src="left.ascx" %>
<%@ Page language="c#" Codebehind="ȸ����������.aspx.cs" AutoEventWireup="false" Inherits="startpage.ȸ����������" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ȸ����������</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<FONT face="����">
			<FORM id="ȸ������" method="post" encType="multipart/form-data" runat="server">
				<FONT face="����">
					<P></P>
					<P>&nbsp;&nbsp;&nbsp;
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" border="0">
							<TR>
								<TD width="130">
									<uc1:left id="Left1" runat="server" DESIGNTIMEDRAGDROP="616"></uc1:left></TD>
								<TD valign="top">
									<P><FONT size="6"><STRONG>ȸ����������</STRONG></FONT></P>
									<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="737" border="1">
										<TR>
											<TD style="WIDTH: 212px">
												<DIV align="right">*���̵�</DIV>
											</TD>
											<TD>
												<P align="left">
													<asp:textbox id="id" runat="server" Width="104px" ReadOnly="True"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:Button id="picture" runat="server" Text="�������"></asp:Button></P>
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 212px">
												<DIV align="right">*�н�����</DIV>
											</TD>
											<TD>
												<asp:textbox id="password1" runat="server" Width="152px" TextMode="Password"></asp:textbox>
												<asp:button id="pass_change" runat="server" Text="�н����庯��"></asp:button></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 212px">
												<DIV align="right">*�̸�</DIV>
											</TD>
											<TD>
												<asp:textbox id="name" runat="server" Width="151px" ReadOnly="True"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:checkbox id="name_o" runat="server" Text="����"></asp:checkbox>&nbsp;&nbsp;&nbsp;&nbsp;
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 212px">
												<DIV align="right">*�ֹε�Ϲ�ȣ</DIV>
											</TD>
											<TD>
												<P>
													<asp:textbox id="numfore" runat="server" Width="84px" ReadOnly="True"></asp:textbox>&nbsp;-
													<asp:textbox id="numback" runat="server" Width="87px" ReadOnly="True"></asp:textbox>&nbsp;&nbsp;
												</P>
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 212px">
												<DIV align="right">�ּ�</DIV>
											</TD>
											<TD>
												<asp:textbox id="addressfore" runat="server" Width="282px" MaxLength="50"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
												&nbsp;
												<asp:checkbox id="addressfore_o" runat="server" Text="����" Checked="True"></asp:checkbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 212px">
												<P align="right">&nbsp;</P>
											</TD>
											<TD>
												<asp:textbox id="addressback" runat="server" Width="273px" MaxLength="50"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 212px">
												<DIV align="right">��ȭ��ȣ</DIV>
											</TD>
											<TD>
												<asp:textbox id="tel" runat="server" MaxLength="20"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 212px">
												<DIV align="right">�ڵ���</DIV>
											</TD>
											<TD>
												<asp:textbox id="mobile" runat="server" MaxLength="20"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 212px">
												<DIV align="right">�̸��� �ּ�</DIV>
											</TD>
											<TD>
												<asp:textbox id="email" runat="server" MaxLength="30"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:checkbox id="email_o" runat="server" Text="����"></asp:checkbox></TD>
										</TR>
										<TR>
											<TD colSpan="2">
												<DIV align="left">&nbsp;&nbsp; ���, 
													����&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:checkbox id="history_o" runat="server" Text="����" Checked="True"></asp:checkbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</DIV>
											</TD>
										</TR>
										<TR>
											<TD colSpan="2">
												<P align="left">
													<asp:textbox id="history" runat="server" Width="709px" TextMode="MultiLine" Height="102px"></asp:textbox></P>
											</TD>
										</TR>
										<TR>
											<TD colSpan="2">
												<DIV align="left">&nbsp;&nbsp; ���� 
													�о�&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:checkbox id="concern_o" runat="server" Text="����" Checked="True"></asp:checkbox></DIV>
											</TD>
										</TR>
										<TR>
											<TD colSpan="2">
												<P align="left">
													<asp:textbox id="concern" runat="server" Width="711px" TextMode="MultiLine" Height="79px"></asp:textbox></P>
											</TD>
										</TR>
									</TABLE>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									&nbsp;
									<asp:button id="ok" runat="server" Text="Ȯ��"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:button id="cancel" runat="server" Text="���" CausesValidation="False"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
				</FONT>
		</FONT></P></FORM>
	</body>
</HTML>
