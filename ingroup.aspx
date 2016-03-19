<%@ Page language="c#" Codebehind="ingroup.aspx.cs" AutoEventWireup="false" Inherits="startpage.igroup" %>
<%@ Register TagPrefix="uc1" TagName="left" Src="left.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>igroup</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="igroup" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD width="135"><uc1:left id="Left1" runat="server"></uc1:left></TD>
					<TD valign="top">
						<P><FONT face="굴림" size="6"><STRONG>그룹관리</STRONG></FONT></P>
						<P>그룹명 :
							<asp:label id="group" runat="server">Label</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							개설자 :
							<asp:label id="opener" runat="server">Label</asp:label></FONT></P>
						<P></P>
						<P><FONT face="굴림">설명 :
								<asp:label id="expl" runat="server">Label</asp:label></FONT></P>
						<FONT face="굴림">
							<P><asp:button id="retire" runat="server" Text="탈퇴하기"></asp:button><asp:button id="close" runat="server" Text="그룹폐쇄"></asp:button></P>
							<P><asp:textbox id="text" runat="server" Width="589px" Height="80px"></asp:textbox><asp:button id="send" runat="server" Text="가입자 전원에게 쪽지보내기"></asp:button></P>
							<P><asp:button id="viewmember" runat="server" Text="가입자리스트보기"></asp:button><asp:label id="member" runat="server"></asp:label></P>
							<P>
						</FONT><FONT face="굴림">
							<asp:datalist id="list" runat="server" Width="764px" BorderWidth="2px" CellPadding="3" BackColor="White"
								CellSpacing="1" BorderStyle="Ridge" BorderColor="White">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
								<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
								<ItemTemplate>
									<P>
										<asp:Label id=comment runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.내용") %>'>
										</asp:Label></P>
									<P>&nbsp;&nbsp;글쓴이 :
										<asp:Label id=writer runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.글쓴이") %>'>
										</asp:Label>&nbsp;&nbsp; 작성일 :
										<asp:Label id=date runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.작성일") %>'>
										</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:Button id=com_edit runat="server" Text="수정" Enabled='<%# DataBinder.Eval(Container.DataItem, "버튼활성화") %>' CommandName="edit">
										</asp:Button>
										<asp:Button id=com_del runat="server" Text="삭제" Enabled='<%# DataBinder.Eval(Container.DataItem, "버튼활성화") %>' CommandName="delete">
										</asp:Button>
										<asp:Button id=add runat="server" Text="가입처리" Enabled='<%# DataBinder.Eval(Container.DataItem, "추가버튼") %>' CommandName="add">
										</asp:Button></P>
								</ItemTemplate>
								<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
								<EditItemTemplate>
									<P>
										<asp:TextBox id=edittext runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "내용") %>' Height="92px" Width="648px" TextMode="MultiLine">
										</asp:TextBox>
										<asp:Button id="edit_ok" runat="server" Text="확인" CommandName="update"></asp:Button></P>
								</EditItemTemplate>
							</asp:datalist><asp:button id="attach" runat="server" Text="가입신청" DESIGNTIMEDRAGDROP="110"></asp:button></P></FONT></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
