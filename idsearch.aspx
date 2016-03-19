<%@ Page language="c#" Codebehind="idsearch.aspx.cs" AutoEventWireup="false" Inherits="startpage.idsearch" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>idsearch</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="idsearch" method="post" runat="server">
			<P><FONT face="굴림">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</FONT><FONT face="굴림">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="6">
						ID 찾기</FONT></FONT></P>
			<P><FONT face="굴림" size="5">ID :&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
					<asp:textbox id="id" runat="server"></asp:textbox></FONT></P>
			<P><FONT face="굴림" size="5">이름 :&nbsp;
					<asp:textbox id="name" runat="server"></asp:textbox></FONT></P>
			<P><FONT face="굴림" size="5">그룹 :&nbsp;
					<asp:textbox id="group" runat="server"></asp:textbox></P>
			</FONT>
			<P><FONT face="굴림" size="5">주소 :&nbsp;
					<asp:textbox id="address" runat="server"></asp:textbox></FONT></P>
			<P><FONT face="굴림" size="5">약력:&nbsp;&nbsp;
					<asp:textbox id="history" runat="server"></asp:textbox></FONT></P>
			<P><FONT face="굴림" size="5">관심분야:
					<asp:TextBox id="concern" runat="server"></asp:TextBox>
				</FONT>
			</P>
			<P><FONT face="굴림" size="5">&nbsp;&nbsp;&nbsp;&nbsp;</FONT><FONT face="굴림" size="5"><FONT size="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="Button1" runat="server" Text="검색"></asp:button></FONT></FONT></P>
			<P><FONT face="굴림" size="5"><FONT size="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:datagrid id="result" runat="server" AutoGenerateColumns="False">
							<Columns>
								<asp:BoundColumn DataField="아이디" ReadOnly="True" HeaderText="아이디"></asp:BoundColumn>
								<asp:BoundColumn DataField="공개된 회원정보" ReadOnly="True" HeaderText="공개된 회원정보"></asp:BoundColumn>
								<asp:ButtonColumn Text="선택" ButtonType="PushButton" HeaderText="선택,해제"></asp:ButtonColumn>
							</Columns>
						</asp:datagrid>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</FONT></FONT></P>
			<P><FONT face="굴림" size="5"><FONT size="3">&nbsp;선택된&nbsp;아이디 
						:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="selected" runat="server"></asp:label></P>
			</FONT></FONT>
			<P><FONT face="굴림" size="5"><FONT size="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<INPUT id="Submit1" type="submit" value="확인" name="Submit1" runat="server"></P>
			</FONT></FONT></form>
	</body>
</HTML>
