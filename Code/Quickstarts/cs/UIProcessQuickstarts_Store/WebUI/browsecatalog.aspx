<%@ OutputCache location="none" %>
<%@ Page language="c#" Codebehind="browsecatalog.aspx.cs" AutoEventWireup="false" Inherits="UIProcessQuickstarts_Store.WebUI.browsecatalog1" %>
<%@ Register TagPrefix="uc1" TagName="BackButtonNotifier" Src="BackButtonNotifier.ascx" %>
<HTML>
	<HEAD>
		<title>Browse Catalog</title>
	</HEAD>
	<body>
		<form id="browsecatalog" method="post" runat="server">
			<TABLE height="100%" width="100%" border="0">
				<TR vAlign="top">
					<TD></TD>
					<TD>
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="left" border="1">
							<TR>
								<TD vAlign="top" align="left">
									<uc1:BackButtonNotifier id="BackButtonNotifier1" runat="server"></uc1:BackButtonNotifier></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="left">
									<span>Catalog Stuff</span>
									<br>
									<br>
									<asp:DataGrid DataKeyField="ProductID" ID="catalogGrid" Runat="server" GridLines="None" AutoGenerateColumns="False">
										<Columns>
											<asp:BoundColumn DataField="ModelName"></asp:BoundColumn>
											<asp:BoundColumn DataField="UnitCost"></asp:BoundColumn>
											<asp:TemplateColumn>
												<ItemTemplate>
													<asp:LinkButton Runat="server" CommandName="AddItem">Add to cart</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:DataGrid><br>
									<br>
									<span>End Catalog Stuff</span>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
