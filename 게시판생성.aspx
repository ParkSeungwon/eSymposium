<%@ Page language="c#" Codebehind="�Խ��ǻ���.aspx.cs" AutoEventWireup="false" Inherits="startpage.�Խ��ǻ���" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�Խ��ǻ���</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="�Խ��ǻ���" method="post" runat="server">
			<P><FONT face="����">�۾���
					<asp:TextBox id="id" runat="server" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="����">&nbsp; 
						�ʴ��� ID&nbsp;&nbsp;&nbsp;
						<asp:ListBox id="invited" runat="server"></asp:ListBox>&nbsp;&nbsp; &nbsp;
						<asp:Button id="idsearch" runat="server" Text="ID�˻�"></asp:Button></FONT></P>
			</FONT>
			<P><FONT face="����">����&nbsp;&nbsp;&nbsp;
					<asp:TextBox id="title" runat="server" Width="469px"></asp:TextBox></FONT></P>
			<FONT face="����">
				<P><FONT face="����">&nbsp;&nbsp;</FONT>
			</FONT><FONT face="����">&nbsp;
				<asp:TextBox id="contents" runat="server" Width="589px" Height="392px" TextMode="MultiLine"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</FONT></P>
			<P><FONT face="����">&nbsp;&nbsp;</FONT><FONT face="����">
					<asp:CheckBox id="view" runat="server" Text="��������" Checked="True"></asp:CheckBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:CheckBox id="comment" runat="server" Text="���۴ޱⰡ��" Checked="True"></asp:CheckBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:CheckBox id="vote" runat="server" Text="��ǥ����" Checked="True"></asp:CheckBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:CheckBox id="turn" runat="server" Text="���ʷ�" AutoPostBack="True"></asp:CheckBox>&nbsp;&nbsp;&nbsp;ȸ�űⰣ
					<asp:DropDownList id="term" runat="server" Enabled="False">
						<asp:ListItem Value="1">1</asp:ListItem>
						<asp:ListItem Value="2">2</asp:ListItem>
						<asp:ListItem Value="3">3</asp:ListItem>
						<asp:ListItem Value="4">4</asp:ListItem>
						<asp:ListItem Value="5">5</asp:ListItem>
						<asp:ListItem Value="6">6</asp:ListItem>
						<asp:ListItem Value="7">7</asp:ListItem>
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
					</asp:DropDownList>��</FONT></P>
			<P><FONT face="����"></FONT>&nbsp;</P>
			<P><FONT face="����"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Button id="Button1" runat="server" Width="47px" Text="Ȯ��"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<INPUT style="WIDTH: 45px; HEIGHT: 24px" type="reset" value="���"></P>
			</FONT>
		</form>
	</body>
</HTML>
