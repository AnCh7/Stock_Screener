<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="StockScreener._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
	<asp:Button ID="btnFill" runat="server" Text="Fill" OnClick="btnFill_Click" />
	<script type="text/javascript" src="Scripts/boxover.js"></script>
	<table style="width: 100%;">
		<tr>
			<td align="center">
				<asp:Calendar ID="cldrDate" runat="server" BackColor="White" BorderColor="Black"
					OnSelectionChanged="ControlsEvent_Click" Font-Names="Verdana" Font-Size="9pt"
					ForeColor="Black" Height="150px" NextPrevFormat="ShortMonth" Width="600px" BorderStyle="Solid"
					CellSpacing="1">
					<DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
					<DayStyle BackColor="#CCCCCC" />
					<NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
					<OtherMonthDayStyle ForeColor="#999999" />
					<SelectedDayStyle BackColor="#333399" ForeColor="White" />
					<TitleStyle BackColor="#333399" Font-Bold="True" Font-Size="12pt" ForeColor="White"
						BorderStyle="Solid" Height="12pt" />
					<TodayDayStyle BackColor="#999999" ForeColor="White" />
				</asp:Calendar>
			</td>
		</tr>
		<tr>
			<td align="center">
				<table>
					<tr>
						<td>
							<a href="http://www.forexpf.ru/" style="text-decoration: none">Exchange</a>:
						</td>
						<td>
							<span style="cursor: pointer" onmousedown="document.getElementById('begstr2').setAttribute('scrollAmount',6);document.getElementById('begstr2').setAttribute('direction','left') "
								onmouseup="document.getElementById('begstr2').setAttribute('scrollAmount',1)"><<</span>
						</td>
						<td>
							<marquee width="1000" id="begstr2" truespeed="1" scrollamount="1" scrolldelay="30"
								behavior="right" style="color: " bgcolor="">
                             <script src="http://www.forexpf.ru/ajaxnews/eurusdrub.php?src=269ABC"></script></marquee>
						</td>
						<td>
							<span style="cursor: pointer" onmousedown="document.getElementById('begstr2').setAttribute('scrollAmount',6);document.getElementById('begstr2').setAttribute('direction','right') "
								onmouseup="document.getElementById('begstr2').setAttribute('scrollAmount',1)">>></span>
						</td>
					</tr>
				</table>
			</td>
			<tr>
				<td align="center">
					<table>
						<tr>
							<td>
								<a href="http://www.forexpf.ru/" style="text-decoration: none">News</a>:
							</td>
							<td>
								<span style="cursor: pointer" onmousedown="document.getElementById('begstr').setAttribute('scrollAmount',6);document.getElementById('begstr').setAttribute('direction','left') "
									onmouseup="document.getElementById('begstr').setAttribute('scrollAmount',1)"><<</span>
							</td>
							<td>
								<marquee width="1000" id="begstr" truespeed="1" scrollamount="1" scrolldelay="30"
									behavior="right" style="color: " bgcolor="">
                                 <script src="http://www.forexpf.ru/ajaxnews/newses.php?src=5"></script></marquee>
							</td>
							<td>
								<span style="cursor: pointer" onmousedown="document.getElementById('begstr').setAttribute('scrollAmount',6);document.getElementById('begstr').setAttribute('direction','right') "
									onmouseup="document.getElementById('begstr').setAttribute('scrollAmount',1)">>></span>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</tr>
	</table>
	<table style="width: 100%;">
		<tr>
			<td>
				<asp:Label ID="lblCountry" runat="server" Text="Country" Width="120"></asp:Label>
				<asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ControlsEvent_Click"
					AutoPostBack="true" Width="120">
				</asp:DropDownList>
			</td>
			<td>
				<asp:Label ID="lblIndustry" runat="server" Text="Industry" Width="120"></asp:Label>
				<asp:DropDownList ID="ddlIndustry" runat="server" OnSelectedIndexChanged="ControlsEvent_Click"
					AutoPostBack="true" Width="120">
				</asp:DropDownList>
			</td>
			<td>
				<asp:Label ID="lblSector" runat="server" Text="Sector" Width="120"></asp:Label>
				<asp:DropDownList ID="ddlSector" runat="server" OnSelectedIndexChanged="ControlsEvent_Click"
					AutoPostBack="true" Width="120">
				</asp:DropDownList>
			</td>
			<td>
				<asp:Label ID="LblMC" runat="server" Text="Market Cap" Width="120"></asp:Label>
				<asp:DropDownList ID="ddlMarketCap" runat="server" OnSelectedIndexChanged="ControlsEvent_Click"
					AutoPostBack="true" Width="120">
				</asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="lblDY" runat="server" Text="Divident Yeild" Width="120"></asp:Label>
				<asp:DropDownList ID="ddlDividentYeild" runat="server" OnSelectedIndexChanged="ControlsEvent_Click"
					AutoPostBack="true" Width="120">
				</asp:DropDownList>
			</td>
			<td>
				<asp:Label ID="lbl52WH" runat="server" Text="52-Week High" Width="120"></asp:Label>
				<asp:DropDownList ID="ddlFilter52WeekHigh" runat="server" OnSelectedIndexChanged="ControlsEvent_Click"
					AutoPostBack="true" Width="120">
				</asp:DropDownList>
			</td>
			<td>
				<asp:Label ID="lbl52WL" runat="server" Text="52-Week Low" Width="120"></asp:Label>
				<asp:DropDownList ID="ddlFilter52WeekLow" runat="server" OnSelectedIndexChanged="ControlsEvent_Click"
					AutoPostBack="true" Width="120">
				</asp:DropDownList>
			</td>
			<td>
				<asp:Label ID="lblBeta" runat="server" Text="Beta" Width="120"></asp:Label>
				<asp:DropDownList ID="ddlFilterBeta" runat="server" OnSelectedIndexChanged="ControlsEvent_Click"
					AutoPostBack="true" Width="120">
				</asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="lblPW" runat="server" Text="Performance Week" Width="120"></asp:Label>
				<asp:DropDownList ID="ddlPerformanceWeek" runat="server" OnSelectedIndexChanged="ControlsEvent_Click"
					AutoPostBack="true" Width="120">
				</asp:DropDownList>
			</td>
			<td>
				<asp:Label ID="lblPM" runat="server" Text="Performance Month" Width="120"></asp:Label>
				<asp:DropDownList ID="ddlPerformanceMonth" runat="server" OnSelectedIndexChanged="ControlsEvent_Click"
					AutoPostBack="true" Width="120">
				</asp:DropDownList>
			</td>
			<td>
				<asp:Label ID="lblPY" runat="server" Text="Performance Year" Width="120"></asp:Label>
				<asp:DropDownList ID="ddlPerformanceYear" runat="server" OnSelectedIndexChanged="ControlsEvent_Click"
					AutoPostBack="true" Width="120">
				</asp:DropDownList>
			</td>
			<td>
				<asp:Label ID="lblATR" runat="server" Text="Average True Range" Width="120"></asp:Label>
				<asp:DropDownList ID="ddlFilterAverageTrueRange" runat="server" OnSelectedIndexChanged="ControlsEvent_Click"
					AutoPostBack="true" Width="120">
				</asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="lblChange" runat="server" Text="Change" Width="120"></asp:Label>
				<asp:DropDownList ID="ddlFilterChange" runat="server" OnSelectedIndexChanged="ControlsEvent_Click"
					AutoPostBack="true" Width="120">
				</asp:DropDownList>
			</td>
			<td>
				<asp:Label ID="lblVolume" runat="server" Text="Volume" Width="120"></asp:Label>
				<asp:DropDownList ID="ddlFilterVolume" runat="server" OnSelectedIndexChanged="ControlsEvent_Click"
					AutoPostBack="true" Width="120">
				</asp:DropDownList>
			</td>
			<td>
				<asp:Label ID="lblPrice" runat="server" Text="Price" Width="120"></asp:Label>
				<asp:DropDownList ID="ddlFilterPrice" runat="server" OnSelectedIndexChanged="ControlsEvent_Click"
					AutoPostBack="true" Width="120">
				</asp:DropDownList>
			</td>
			<td>
				<asp:Label ID="lblFind" runat="server" Text="Enter Ticker" Width="120"></asp:Label>
				<asp:TextBox ID="tbFind" runat="server" Width="115"></asp:TextBox>
				&nbsp;
                <asp:Button ID="btnFind" runat="server" Text="Find" Width="50"
					OnClick="btnFind_Click" />
			</td>
		</tr>
		<tr>
			<td height="50" align="center">
				<asp:Label ID="lblCaption" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label>
			</td>
		</tr>
	</table>
	<asp:GridView ID="gvMain" runat="server" AllowPaging="True" OnPageIndexChanging="gvMain_PageIndexChanging"
		OnSorting="gvMain_OnSorting" AutoGenerateColumns="False" OnRowDataBound="gvMain_OnRowDataBound"
		AutoGenerateSelectButton="False" HeaderStyle-BackColor="#9FDE92" HeaderStyle-ForeColor="Black"
		HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" AllowSorting="True"
		ForeColor="Black" Font-Size="Small" PageSize="20">
		<Columns>
			<asp:BoundField DataField="ID" HeaderText="ID" HeaderStyle-HorizontalAlign="Center"
				ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20">
				<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="20px"></ItemStyle>
			</asp:BoundField>
			<asp:BoundField DataField="Ticker" HeaderText="Ticker" HeaderStyle-HorizontalAlign="Center"
				ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40" SortExpression="Company" ItemStyle-ForeColor="Blue" ItemStyle-BorderColor="Black">
				<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
				<ControlStyle ForeColor="#0033CC"></ControlStyle>
			</asp:BoundField>
			<asp:BoundField DataField="Company" HeaderText="Company" HeaderStyle-HorizontalAlign="Center"
				ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200" SortExpression="Ticker">
				<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
			</asp:BoundField>
			<asp:BoundField DataField="Sector" HeaderText="Sector" HeaderStyle-HorizontalAlign="Center"
				ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80" SortExpression="Sector">
				<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
			</asp:BoundField>
			<asp:BoundField DataField="Industry" HeaderText="Industry" HeaderStyle-HorizontalAlign="Center"
				ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200" SortExpression="Industry">
				<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
			</asp:BoundField>
			<asp:BoundField DataField="Country" HeaderText="Country" HeaderStyle-HorizontalAlign="Center"
				ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50" SortExpression="Country">
				<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
			</asp:BoundField>
			<asp:BoundField DataField="Market Cap" HeaderText="Market Cap" HeaderStyle-HorizontalAlign="Center"
				ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50" SortExpression="Market Cap">
				<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
			</asp:BoundField>
			<asp:BoundField DataField="Dividend Yield" HeaderText="Dividend Yield" HeaderStyle-HorizontalAlign="Center"
				ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30" DataFormatString="{0}%"
				SortExpression="Dividend Yield">
				<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
			</asp:BoundField>
			<asp:BoundField DataField="Performance (Week)" HeaderText="Performance (Week)" HeaderStyle-HorizontalAlign="Center"
				ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50" DataFormatString="{0}%"
				SortExpression="Performance (Week)">
				<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
			</asp:BoundField>
			<asp:BoundField DataField="Performance (Month)" HeaderText="Performance (Month)"
				HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50"
				DataFormatString="{0}%" SortExpression="Performance (Month)">
				<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
			</asp:BoundField>
			<asp:BoundField DataField="Performance (Year)" HeaderText="Performance (Year)" HeaderStyle-HorizontalAlign="Center"
				SortExpression="Performance (Year)" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50"
				DataFormatString="{0}%">
				<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
			</asp:BoundField>
			<asp:BoundField DataField="Beta" HeaderText="Beta" HeaderStyle-HorizontalAlign="Center"
				SortExpression="Beta" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30">
				<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
			</asp:BoundField>
			<asp:BoundField DataField="Average True Range" HeaderText="Average True Range" HeaderStyle-HorizontalAlign="Center"
				SortExpression="Average True Range" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50">
				<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
			</asp:BoundField>
			<asp:BoundField DataField="52-Week High" HeaderText="52-Week High" HeaderStyle-HorizontalAlign="Center"
				SortExpression="52-Week High" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50">
				<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
			</asp:BoundField>
			<asp:BoundField DataField="52-Week Low" HeaderText="52-Week Low" HeaderStyle-HorizontalAlign="Center"
				SortExpression="52-Week Low" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50"
				DataFormatString="{0}%">
				<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
			</asp:BoundField>
			<asp:BoundField DataField="Price" HeaderText="Price" HeaderStyle-HorizontalAlign="Center"
				SortExpression="Price" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40">
				<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
			</asp:BoundField>
			<asp:BoundField DataField="Change" HeaderText="Change" HeaderStyle-HorizontalAlign="Center"
				SortExpression="Change" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50"
				DataFormatString="{0}%">
				<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
			</asp:BoundField>
			<asp:BoundField DataField="Volume" HeaderText="Volume" HeaderStyle-HorizontalAlign="Center"
				SortExpression="Volume" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50">
				<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
			</asp:BoundField>
		</Columns>
		<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#9FDE92"
			ForeColor="Black"></HeaderStyle>
		<PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
		<PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Center" Font-Size="Medium" />
	</asp:GridView>
</asp:Content>
