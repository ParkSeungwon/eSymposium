<%@ Register TagPrefix="cc1" Namespace="StrengthControls.Scrolling" Assembly="StrengthControls.Scrolling" %>
<%@ Page language="c#" Codebehind="create.aspx.cs" AutoEventWireup="false" Inherits="startpage.idsearch" smartNavigation="False"%>
<%@ Register TagPrefix="uc1" TagName="left" Src="left.ascx" %>
<HTML>
	<HEAD>
		<title>토론대기실</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="idsearch" method="post" runat="server">
			<P><FONT face="굴림" size="5"><FONT size="3"><FONT face="굴림">
							<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%">
								<TBODY>
									<TR>
										<TD width="130"><uc1:left id="Left1" runat="server"></uc1:left></TD>
										<TD>
											<P><FONT face="굴림"><FONT face="굴림" size="6"><STRONG>토론대기실</STRONG></FONT></FONT></P>
											<P><FONT face="굴림" size="5"><FONT size="3"><FONT face="굴림">개설자&nbsp;
															<asp:textbox id="id" runat="server" ReadOnly="True" Width="123px"></asp:textbox>&nbsp;<FONT face="굴림">
																<asp:checkbox id="read" runat="server" ToolTip="외부인이 이 토론을 볼수 있는지의 여부" Text="열람"></asp:checkbox>&nbsp;
																<asp:checkbox id="write" runat="server" ToolTip="덧글을 달 수 있는지의 여부" Text="덧글"></asp:checkbox>&nbsp;
																<asp:checkbox id="vote" runat="server" ToolTip="지지자에 대한 투표와 득표수를 볼수 있는지의 여부" Text="투표"></asp:checkbox>&nbsp; 
																&nbsp;
																<asp:checkbox id="inturn" runat="server" ToolTip="토론참가자들이 참가아이디의 순서대로 토론을 할지의 여부" Text="차례로" AutoPostBack="True"></asp:checkbox>&nbsp; 
																회신기간
																<asp:dropdownlist id="term" runat="server" Enabled="False">
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
																</asp:dropdownlist>일</FONT> &nbsp;&nbsp;&nbsp;분야&nbsp;
															<asp:dropdownlist id="field" runat="server">
																<asp:ListItem Value="정치,경제,시사">정치,경제,시사</asp:ListItem>
																<asp:ListItem Value="학술">학술</asp:ListItem>
																<asp:ListItem Value="친목">친목</asp:ListItem>
															</asp:dropdownlist></P>
						</FONT></FONT>
					<P><FONT face="굴림"><FONT size="3">제목&nbsp;</FONT>&nbsp;
							<asp:textbox id="title" runat="server" Width="469px"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="3">토론참여ID</FONT><FONT size="3">&nbsp;
								<asp:button id="up" runat="server" ToolTip="선택된 아이디의 순서를 위로" Text="^"></asp:button><asp:button id="down" runat="server" ToolTip="선택된 아이디의 순서를 아래로" Text="v"></asp:button><asp:button id="del" runat="server" ToolTip="선택된 아이디를 제거함" Text="del"></asp:button><asp:button id="clear" runat="server" ToolTip="초대 아이디를 비움" Text="clear"></asp:button></FONT>
							<P>
						</FONT><FONT face="굴림">
					</P>
					<FONT face="굴림"></FONT></FONT><FONT face="굴림"><FONT size="3"></FONT><FONT size="3"></FONT>
					<asp:textbox id="contents" runat="server" Width="640px" ToolTip="주토론창" Height="392px" TextMode="MultiLine"></asp:textbox><asp:listbox id="invited_ids" runat="server" Height="392px" Width="100px"></asp:listbox></FONT>
			<P></P>
			<FONT face="굴림">
				<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:button id="tolist" runat="server" Text="목록으로"></asp:button>&nbsp;&nbsp;
					<asp:button id="save" runat="server" Text="저장"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:button id="start" runat="server" ToolTip="먼저 저장하세요.토론이 시작되면 토론 참가자에게는 자동으로 토론 개시를 알리는 쪽지가 발송됩니다."
						Text="토론시작" Enabled="False"></asp:button>&nbsp;&nbsp;<FONT size="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						그룹 </FONT>
					<asp:dropdownlist id="addgroup" runat="server" DESIGNTIMEDRAGDROP="264" Width="100px"></asp:dropdownlist><asp:button id="add_g" runat="server" Text="추가"></asp:button></P>
				<P><FONT size="3"><FONT size="1"><FONT size="3"><FONT size="3"></P>
			</FONT></FONT></FONT></FONT></FONT><FONT face="굴림" size="5">
				<P><FONT face="굴림">
						<asp:datalist id="DataList1" runat="server" Width="769px" BorderWidth="2px" CellPadding="3" BackColor="White"
							CellSpacing="1" BorderStyle="Ridge" BorderColor="White" ShowFooter="False" ShowHeader="False">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
							<FooterTemplate>
								<P><FONT face="굴림" size="5"></FONT>&nbsp;</P>
							</FooterTemplate>
							<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
							<ItemTemplate>
								<P>
									<asp:Label id=comment runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.내용") %>'>
									</asp:Label></P>
								<P>&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;글쓴이 :
									<asp:Label id=writer runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.글쓴이") %>'>
									</asp:Label>&nbsp;&nbsp; 작성일 :
									<asp:Label id=date runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.작성일") %>'>
									</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:Button id=com_edit runat="server" Text="수정" Enabled='<%# DataBinder.Eval(Container.DataItem, "버튼활성화") %>' CommandName="edit">
									</asp:Button>
									<asp:Button id=com_del runat="server" Text="삭제" Enabled='<%# DataBinder.Eval(Container.DataItem, "버튼활성화") %>' CommandName="delete">
									</asp:Button>
									<asp:Button id=add runat="server" Text="추가" Enabled='<%# DataBinder.Eval(Container.DataItem, "추가버튼") %>' CommandName="add">
									</asp:Button></P>
							</ItemTemplate>
							<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
							<EditItemTemplate>
								<P>
									<asp:TextBox id=edittext runat="server" Width="667px" Text='<%# DataBinder.Eval(Container.DataItem,"내용") %>' TextMode="MultiLine" Height="84px">
									</asp:TextBox>
									<asp:Button id="ok" runat="server" Text="확인" CommandName="update"></asp:Button></P>
							</EditItemTemplate>
						</asp:datalist></FONT></P>
			</FONT><FONT face="굴림" size="5"><FONT size="3">
					<P><FONT face="굴림" size="5">
							<asp:button id="attach_comment" runat="server" Text="참가신청" CommandName="attc"></asp:button></FONT></P>
				</FONT>
				<TABLE id="Table1" style="WIDTH: 281px; HEIGHT: 177px" cellSpacing="1" cellPadding="1"
					width="281" border="1">
					<TR>
						<TD style="WIDTH: 76px">아이디</TD>
						<TD style="WIDTH: 197px"><asp:textbox id="id2" runat="server"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 76px">이름</TD>
						<TD style="WIDTH: 197px"><asp:textbox id="name" runat="server"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 76px">주소</TD>
						<TD style="WIDTH: 197px"><asp:textbox id="address" runat="server"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 76px">약력</TD>
						<TD style="WIDTH: 197px"><asp:textbox id="history" runat="server"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 76px">관심분야</TD>
						<TD style="WIDTH: 197px"><asp:textbox id="concern" runat="server"></asp:textbox></TD>
					</TR>
				</TABLE>
				<P><asp:button id="search" runat="server" Text="아이디 검색"></asp:button></P>
				<P><asp:datagrid id="result" runat="server" AutoGenerateColumns="False">
						<SelectedItemStyle ForeColor="White" BackColor="White"></SelectedItemStyle>
						<Columns>
							<asp:BoundColumn DataField="아이디" ReadOnly="True" HeaderText="아이디"></asp:BoundColumn>
							<asp:BoundColumn DataField="공개된 회원정보" ReadOnly="True" HeaderText="공개된 회원정보"></asp:BoundColumn>
							<asp:ButtonColumn Text="선택" ButtonType="PushButton" HeaderText="선택,해제"></asp:ButtonColumn>
						</Columns>
						<PagerStyle HorizontalAlign="Center" Mode="NumericPages"></PagerStyle>
					</asp:datagrid></P>
				<P><cc1:smartscroller id="SmartScroller1" runat="server"></cc1:smartscroller></P>
			</FONT></FONT></TD></TR></TBODY></TABLE></FONT></FONT></FONT><FONT face="굴림" size="5"><FONT face="굴림" size="5"></FONT></FONT></FONT></FONT></FONT></form>
		</P>
	</body>
</HTML>
