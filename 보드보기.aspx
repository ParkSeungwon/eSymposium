<%@ Register TagPrefix="cc1" Namespace="StrengthControls.Scrolling" Assembly="StrengthControls.Scrolling" %>
<%@ Page language="c#" Codebehind="���庸��.aspx.cs" AutoEventWireup="false" Inherits="startpage.���庸��" validateRequest="false" smartNavigation="False" enableViewStateMac="False"%>
<%@ Register TagPrefix="uc1" TagName="left" Src="left.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>��аԽ���</title>
	</HEAD>
	<BODY language="javascript" onscroll="return window_onscroll()">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<FONT face="����">
			<FORM id="�Խ��ǻ���" method="post" runat="server">
				<table style="HEIGHT: 42px" width="100%">
					<TBODY>
						<tr>
							<td width="130" rowSpan="2"><uc1:left id="Left1" runat="server" DESIGNTIMEDRAGDROP="1235"></uc1:left></td>
							<td><asp:imagebutton id="image" runat="server" Width="80px" Height="80px"></asp:imagebutton></td>
							<td>
								<P><FONT size="2">�۾���</FONT>
									<asp:textbox id="id" runat="server" Width="93px" BackColor="WhiteSmoke" ReadOnly="True"></asp:textbox><FONT size="2">&nbsp;
										<asp:checkbox id="read" runat="server" Enabled="False" Text="����"></asp:checkbox><asp:checkbox id="write" runat="server" Enabled="False" Text="����"></asp:checkbox><asp:checkbox id="vote" runat="server" Enabled="False" Text="��ǥ"></asp:checkbox><FONT size="2"></FONT>
										<asp:checkbox id="inturn" runat="server" Enabled="False" Text="���ʷ�" AutoPostBack="True"></asp:checkbox>&nbsp; 
										ȸ�űⰣ</FONT>
		</FONT>
		<asp:dropdownlist id="term" runat="server" BackColor="WhiteSmoke">
			<asp:ListItem Value="1">1</asp:ListItem>
			<asp:ListItem Value="2">2</asp:ListItem>
			<asp:ListItem Value="3">3</asp:ListItem>
			<asp:ListItem Value="4">4</asp:ListItem>
			<asp:ListItem Value="5">5</asp:ListItem>
			<asp:ListItem Value="6">6</asp:ListItem>
			<asp:ListItem Value="7">7</asp:ListItem>
			<asp:ListItem Value="8">8</asp:ListItem>
			<asp:ListItem Value="9">9</asp:ListItem>
			<asp:ListItem Value="10">10</asp:ListItem>
			<asp:ListItem Value="11">11</asp:ListItem>
			<asp:ListItem Value="12">12</asp:ListItem>
			<asp:ListItem Value="13">13</asp:ListItem>
			<asp:ListItem Value="14">14</asp:ListItem>
			<asp:ListItem Value="15">15</asp:ListItem>
			<asp:ListItem Value="16">16</asp:ListItem>
			<asp:ListItem Value="17">17</asp:ListItem>
			<asp:ListItem Value="18">18</asp:ListItem>
			<asp:ListItem Value="19">19</asp:ListItem>
			<asp:ListItem Value="20">20</asp:ListItem>
			<asp:ListItem Value="21">21</asp:ListItem>
			<asp:ListItem Value="22">22</asp:ListItem>
			<asp:ListItem Value="23">23</asp:ListItem>
			<asp:ListItem Value="24">24</asp:ListItem>
			<asp:ListItem Value="25">25</asp:ListItem>
			<asp:ListItem Value="26">26</asp:ListItem>
			<asp:ListItem Value="27">27</asp:ListItem>
			<asp:ListItem Value="28">28</asp:ListItem>
			<asp:ListItem Value="29">29</asp:ListItem>
			<asp:ListItem Value="30">30</asp:ListItem>
		</asp:dropdownlist><FONT size="2">��&nbsp;&nbsp;�ۼ���:</FONT>
		<asp:label id="date" runat="server"></asp:label><FONT size="2">&nbsp;</FONT> </FONT></P>
		<P><FONT size="2">����&nbsp;&nbsp; </FONT>
			<asp:textbox id="title" runat="server" Width="382px" BackColor="WhiteSmoke" Font-Size="Small"></asp:textbox><FONT size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
				&nbsp;
				<asp:dropdownlist id="ids" runat="server" Width="110px" BackColor="WhiteSmoke"></asp:dropdownlist><asp:label id="yourturn" runat="server"></asp:label><FONT size="2">&nbsp;&nbsp;&nbsp;</FONT></FONT></P>
		</TD></TR>
		<tr>
			<td colSpan="2">
				<P><asp:textbox id="contents" runat="server" Width="769px" Height="439px" BackColor="WhiteSmoke"
						TextMode="MultiLine" BorderColor="White" Font-Size="Small"></asp:textbox><asp:listbox id="topage" runat="server" Width="56px" Height="440px" BackColor="Gainsboro" AutoPostBack="True"
						Font-Size="Small"></asp:listbox></FONT></FONT></P>
				<P><FONT face="����">&nbsp;&nbsp;</FONT><FONT face="����">&nbsp;&nbsp;</FONT><FONT face="����">&nbsp;
						<asp:button id="lt" runat="server" Text="��������"></asp:button>&nbsp;
						<asp:button id="rewind" runat="server" Text="<<" ToolTip="���� ������"></asp:button><asp:button id="ff" runat="server" Text=">>" ToolTip="����������"></asp:button>&nbsp;
						<asp:button id="tolist" runat="server" Text="�������"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="vote_button" runat="server" Text="��ǥ"></asp:button>&nbsp;
						<asp:button id="earn" runat="server" Text="��ǥ������"></asp:button>
						&nbsp;&nbsp;&nbsp; <INPUT id="print" onclick="window.open('print.htm', '_blank')" type="button" value="����Ʈ">&nbsp;
						<asp:Button id="file" runat="server" Text="����"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="save" runat="server" Text="����"></asp:button>&nbsp;
						<asp:button id="continues" runat="server" Enabled="False" Text="�̾����"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Button id="del" runat="server" Text="����" Enabled="False"></asp:Button>
						<asp:Panel id="file_panel" runat="server" Visible="False"></P>
				<P>&nbsp;&nbsp;&nbsp;���ε�� ���ϸ� :
					<asp:HyperLink id="file_link" runat="server" Target="_blank"></asp:HyperLink>&nbsp;</P>
				<P>&nbsp;&nbsp; <INPUT id="fileup" style="WIDTH: 536px; HEIGHT: 22px" type="file" size="70" runat="server">
					<asp:Button id="up" runat="server" Text="���ε�"></asp:Button>&nbsp;&nbsp;
					<asp:Button id="file_delete" runat="server" Text="����"></asp:Button></P>
				<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				</P>
				</asp:Panel></FONT><FONT face="����"></FONT>
				<P><asp:panel id="Panel2" runat="server" Width="817px" Height="111px">
						<asp:DataGrid id="grid" runat="server" Height="63px" Width="804px"></asp:DataGrid>
					</asp:panel></P>
				<P><FONT face="����"><asp:datalist id="Datalist1" runat="server" Width="828px" BackColor="White" BorderColor="White"
							BorderStyle="Ridge" CellSpacing="1" CellPadding="3" BorderWidth="2px" Font-Size="Smaller">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
							<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
							<ItemTemplate>
								<P>
									<asp:Label id=comment runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.���๮��") %>'>
									</asp:Label></P>
								<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�۾��� :
									<asp:Label id=writer runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.�۾���") %>'>
									</asp:Label>&nbsp;&nbsp; �ۼ��� :
									<asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.�ۼ���") %>'>
									</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:Button id=com_edit runat="server" Enabled='<%# DataBinder.Eval(Container.DataItem, "��ưȰ��ȭ") %>' Text="����" CommandName="edit">
									</asp:Button>
									<asp:Button id=com_del runat="server" Enabled='<%# DataBinder.Eval(Container.DataItem, "��ưȰ��ȭ") %>' Text="����" CommandName="delete">
									</asp:Button></P>
							</ItemTemplate>
							<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
							<SeparatorTemplate>
								<IMG height="3" alt="" src="data/line2.bmp" width="800">
							</SeparatorTemplate>
							<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
							<EditItemTemplate>
								<P>
									<asp:TextBox id=edittext runat="server" Width="729px" Height="96px" Text='<%# DataBinder.Eval(Container, "DataItem.����") %>' TextMode="MultiLine">
									</asp:TextBox>
									<asp:Button id="ok" runat="server" Text="Ȯ��" CommandName="update"></asp:Button></P>
							</EditItemTemplate>
						</asp:datalist></FONT><FONT face="����"><cc1:smartscroller id="SmartScroller1" runat="server"></cc1:smartscroller>
						<asp:button id="attach_comment" runat="server" Text="���۴ޱ�"></asp:button>
				</P>
				</FONT></FORM></FONT></td>
		</tr>
		</TBODY></TABLE></FONT></FORM></FORM>
	</BODY>
</HTML>
