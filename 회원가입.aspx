<%@ Page language="c#" Codebehind="ȸ������.aspx.cs" AutoEventWireup="false" Inherits="startpage.ȸ������" %>
<%@ Register TagPrefix="uc1" TagName="left" Src="left.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ȸ������</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" id="clientEventHandlersJS">
<!--

function �ߺ�Ȯ��_onclick() {

}

//-->
		</script>
	</HEAD>
	<body>
		<form id="���̵�" method="post">
			<FONT face="����"></FONT>
		</form>
		<form id="ȸ������" method="post" runat="server">
			<FONT face="����">
				<P></P>
				<P>
					<TABLE id="Table2" width="100%">
						<TR>
							<TD width="135">
								<uc1:left id="Left1" runat="server"></uc1:left></TD>
							<TD valign="top">
								<P><FONT size="6"><STRONG>ȸ������</STRONG></FONT></P>
								<TABLE id="Table1" style="WIDTH: 737px; HEIGHT: 282px" cellSpacing="1" cellPadding="1"
									width="737" border="1">
									<TR>
										<TD style="WIDTH: 212px">
											<DIV align="right">*���̵�</DIV>
										</TD>
										<TD>
											<P align="left">
												<asp:TextBox id="id" runat="server" ReadOnly="True" Width="104px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:textbox id="id2" runat="server" Width="109px" MaxLength="12"></asp:textbox>
												<asp:button id="Button1" runat="server" CausesValidation="False" Text="�ߺ�Ȯ��"></asp:button>&nbsp;&nbsp;&nbsp;
												<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="���̵� �ʿ��մϴ�." ControlToValidate="id"></asp:RequiredFieldValidator></P>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 212px">
											<DIV align="right">*�н�����</DIV>
										</TD>
										<TD>
											<asp:textbox id="password1" runat="server" Width="152px" TextMode="Password" MaxLength="12"></asp:textbox>&nbsp;&nbsp;
											<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="�н����尡 �ʿ��մϴ�." ControlToValidate="password1"></asp:requiredfieldvalidator></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 212px">
											<DIV align="right">*�н����� Ȯ��</DIV>
										</TD>
										<TD>
											<asp:textbox id="password2" runat="server" Width="152px" TextMode="Password" MaxLength="12"></asp:textbox>&nbsp;&nbsp;
											<asp:comparevalidator id="CompareValidator1" runat="server" ErrorMessage="�н����尡 ��ġ���� �ʽ��ϴ�." ControlToValidate="password2"
												ControlToCompare="password1"></asp:comparevalidator></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 212px">
											<DIV align="right">*�̸�</DIV>
										</TD>
										<TD>
											<asp:textbox id="name" runat="server" Width="151px" MaxLength="10"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:checkbox id="name_o" runat="server" Text="����"></asp:checkbox>&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="�̸��� �ʿ��մϴ�." ControlToValidate="name"></asp:RequiredFieldValidator></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 212px">
											<DIV align="right">*�ֹε�Ϲ�ȣ</DIV>
										</TD>
										<TD>
											<P>
												<asp:textbox id="numfore" runat="server" Width="84px"></asp:textbox>&nbsp;-
												<asp:textbox id="numback" runat="server" Width="87px"></asp:textbox>&nbsp;&nbsp;
												<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="���ڸ����߸���" ControlToValidate="numfore"
													ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
												<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="���ڸ����߸��Ǿ���" ControlToValidate="numback"
													ValidationExpression="\d{7}"></asp:RegularExpressionValidator></P>
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
											<asp:textbox id="email" runat="server" MaxLength="30"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:CheckBox id="email_o" runat="server" Text="����"></asp:CheckBox></TD>
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
												<asp:TextBox id="concern" runat="server" Width="710px" TextMode="MultiLine" Height="75px"></asp:TextBox></P>
										</TD>
									</TR>
								</TABLE>
								<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:button id="ok" runat="server" Text="Ȯ��"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:button id="Button3" runat="server" CausesValidation="False" Text="���"></asp:button>&nbsp;&nbsp;</P>
							</TD>
						</TR>
					</TABLE>
				</P>
				<P></P>
				<P></P>
				<P></P>
				<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</P>
			</FONT>
		</form>
	</body>
</HTML>
