<%@ Register TagPrefix="uc1" TagName="left" Src="left.ascx" %>
<%@ Page language="c#" Codebehind="index.aspx.cs" AutoEventWireup="false" Inherits="startpage.index2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>e��������</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="index2" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD width="130" rowSpan="3"><uc1:left id="Left1" runat="server"></uc1:left></TD>
					<TD bgColor="gainsboro" colSpan="2"><asp:imagebutton id="log" runat="server" ImageUrl="data/�α���2.gif"></asp:imagebutton><asp:imagebutton id="logout" runat="server" ImageUrl="data/�α׾ƿ�2.gif"></asp:imagebutton><asp:imagebutton id="sign" runat="server" ImageUrl="data/ȸ������2.gif"></asp:imagebutton><asp:imagebutton id="change" runat="server" ImageUrl="data/��������2.gif"></asp:imagebutton><A href="board.aspx?field=notice"><IMG height="30" alt="" src="data/��������2.gif"></A>
						<A href="board.aspx?field=board"><IMG height="30" src="data/�ϹݰԽ���2.gif" width="100"></A>
						<A href="boardlist.aspx"><IMG height="30" alt="" src="data/��аԽ���2.gif"></A> <A href="group.aspx">
							<IMG alt="" src="data/�׷�2.gif"></A> <A href="�����б�.aspx"><IMG height="30" alt="" src="data/em3.bmp" width="30"></A>
						<A href="����������.aspx"><IMG height="30" alt="" src="data/em2.bmp" width="30"></A> <A href="����������.aspx?id=webmaster">
							<IMG height="30" alt="" src="data/mail2.gif"></A>
					</TD>
				</TR>
				<tr>
					<TD style="WIDTH: 419px" colSpan="2"><asp:adrotator id="ad" runat="server" Target="_blank" AdvertisementFile="data/ad.xml" Height="120px"
							Width="800px"></asp:adrotator></TD>
				</tr>
				<tr>
					<td style="WIDTH: 352px" width="352" valign="top">
						<P><IMG alt="" src="data/hot.bmp" align="top">&nbsp;</P>
						<P><asp:listbox id="direct" runat="server" Width="400px" ForeColor="Black" AutoPostBack="True" Rows="5"
								Font-Bold="True" BackColor="AliceBlue" Font-Size="Small" Height="400px"></asp:listbox></P>
					</td>
					<td valign="top"><asp:datalist id="books" runat="server" Width="390px" ShowHeader="False" ShowFooter="False">
							<HeaderTemplate>
								<FONT face="���">�߰��� å��</FONT>
							</HeaderTemplate>
							<SeparatorStyle BorderStyle="None" BorderColor="White" BackColor="Transparent"></SeparatorStyle>
							<FooterTemplate>
							</FooterTemplate>
							<ItemStyle Font-Names="�ü�" HorizontalAlign="Left" CssClass="sty.css" VerticalAlign="Middle"></ItemStyle>
							<ItemTemplate>
								<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="300" border="0">
									<TR>
										<TD width="60" height="100">
											<asp:Image id=img runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "�̹������") %>' Width="90px" Height="90px" ImageAlign="Left">
											</asp:Image></TD>
										<TD>
											<P>���� :
												<%# DataBinder.Eval(Container.DataItem, "����") %>
											</P>
											<P><FONT style="LINE-HEIGHT: 20%; LIST-STYLE-TYPE: disc" face="����">���� :
													<%# DataBinder.Eval(Container.DataItem, "����") %>
											</P>
											<P>���ǻ� :
												<%# DataBinder.Eval(Container.DataItem, "���ǻ�") %>
											</P>
											<P>������ :
												<%# DataBinder.Eval(Container.DataItem, "������") %>
												</FONT></P>
										</TD>
									</TR>
								</TABLE>
							</ItemTemplate>
							<SeparatorTemplate>
								<IMG height="3" alt="" src="data/line2.bmp" width="390">
							</SeparatorTemplate>
							<HeaderStyle Font-Names="�޸ո���ü"></HeaderStyle>
						</asp:datalist></td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
