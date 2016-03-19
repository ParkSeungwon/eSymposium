<%@ Page language="c#" Codebehind="회원가입.aspx.cs" AutoEventWireup="false" Inherits="startpage.회원가입" %>
<%@ Register TagPrefix="uc1" TagName="left" Src="left.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>회원가입</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" id="clientEventHandlersJS">
<!--

function 중복확인_onclick() {

}

//-->
		</script>
	</HEAD>
	<body>
		<form id="아이디" method="post">
			<FONT face="굴림"></FONT>
		</form>
		<form id="회원정보" method="post" runat="server">
			<FONT face="굴림">
				<P></P>
				<P>
					<TABLE id="Table2" width="100%">
						<TR>
							<TD width="135">
								<uc1:left id="Left1" runat="server"></uc1:left></TD>
							<TD valign="top">
								<P><FONT size="6"><STRONG>회원가입</STRONG></FONT></P>
								<TABLE id="Table1" style="WIDTH: 737px; HEIGHT: 282px" cellSpacing="1" cellPadding="1"
									width="737" border="1">
									<TR>
										<TD style="WIDTH: 212px">
											<DIV align="right">*아이디</DIV>
										</TD>
										<TD>
											<P align="left">
												<asp:TextBox id="id" runat="server" ReadOnly="True" Width="104px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:textbox id="id2" runat="server" Width="109px" MaxLength="12"></asp:textbox>
												<asp:button id="Button1" runat="server" CausesValidation="False" Text="중복확인"></asp:button>&nbsp;&nbsp;&nbsp;
												<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="아이디가 필요합니다." ControlToValidate="id"></asp:RequiredFieldValidator></P>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 212px">
											<DIV align="right">*패스워드</DIV>
										</TD>
										<TD>
											<asp:textbox id="password1" runat="server" Width="152px" TextMode="Password" MaxLength="12"></asp:textbox>&nbsp;&nbsp;
											<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="패스워드가 필요합니다." ControlToValidate="password1"></asp:requiredfieldvalidator></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 212px">
											<DIV align="right">*패스워드 확인</DIV>
										</TD>
										<TD>
											<asp:textbox id="password2" runat="server" Width="152px" TextMode="Password" MaxLength="12"></asp:textbox>&nbsp;&nbsp;
											<asp:comparevalidator id="CompareValidator1" runat="server" ErrorMessage="패스워드가 일치하지 않습니다." ControlToValidate="password2"
												ControlToCompare="password1"></asp:comparevalidator></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 212px">
											<DIV align="right">*이름</DIV>
										</TD>
										<TD>
											<asp:textbox id="name" runat="server" Width="151px" MaxLength="10"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:checkbox id="name_o" runat="server" Text="공개"></asp:checkbox>&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="이름이 필요합니다." ControlToValidate="name"></asp:RequiredFieldValidator></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 212px">
											<DIV align="right">*주민등록번호</DIV>
										</TD>
										<TD>
											<P>
												<asp:textbox id="numfore" runat="server" Width="84px"></asp:textbox>&nbsp;-
												<asp:textbox id="numback" runat="server" Width="87px"></asp:textbox>&nbsp;&nbsp;
												<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="앞자리가잘못됨" ControlToValidate="numfore"
													ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
												<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="뒷자리가잘못되었음" ControlToValidate="numback"
													ValidationExpression="\d{7}"></asp:RegularExpressionValidator></P>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 212px">
											<DIV align="right">주소</DIV>
										</TD>
										<TD>
											<asp:textbox id="addressfore" runat="server" Width="282px" MaxLength="50"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
											&nbsp;
											<asp:checkbox id="addressfore_o" runat="server" Text="공개" Checked="True"></asp:checkbox></TD>
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
											<DIV align="right">전화번호</DIV>
										</TD>
										<TD>
											<asp:textbox id="tel" runat="server" MaxLength="20"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 212px">
											<DIV align="right">핸드폰</DIV>
										</TD>
										<TD>
											<asp:textbox id="mobile" runat="server" MaxLength="20"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 212px">
											<DIV align="right">이메일 주소</DIV>
										</TD>
										<TD>
											<asp:textbox id="email" runat="server" MaxLength="30"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:CheckBox id="email_o" runat="server" Text="공개"></asp:CheckBox></TD>
									</TR>
									<TR>
										<TD colSpan="2">
											<DIV align="left">&nbsp;&nbsp; 약력, 
												직업&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:checkbox id="history_o" runat="server" Text="공개" Checked="True"></asp:checkbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
											<DIV align="left">&nbsp;&nbsp; 관심 
												분야&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:checkbox id="concern_o" runat="server" Text="공개" Checked="True"></asp:checkbox></DIV>
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
									<asp:button id="ok" runat="server" Text="확인"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:button id="Button3" runat="server" CausesValidation="False" Text="취소"></asp:button>&nbsp;&nbsp;</P>
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
