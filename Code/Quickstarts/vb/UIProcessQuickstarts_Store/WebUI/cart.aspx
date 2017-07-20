<%@ OutputCache location="none" %>
<%@ Page language="vb" Codebehind="cart.aspx.vb" AutoEventWireup="false" Inherits="UIProcessQuickstarts_Store.WebUI.cart" %>
<%@ Register TagPrefix="uc1" TagName="BackButtonNotifier" Src="BackButtonNotifier.ascx" %>
<HTML>
	<HEAD>
		<title>cart</title>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<TABLE height="856" cellSpacing="0" cellPadding="0" width="201" border="0" ms_2d_layout="TRUE">
			<TR vAlign="top">
				<TD width="201" height="856">
					<form id="Form1" method="post" runat="server">
						<TABLE height="184" cellSpacing="0" cellPadding="0" width="844" border="0" ms_2d_layout="TRUE">
							<TR vAlign="top">
								<TD width="10" height="15"></TD>
								<TD width="834"></TD>
							</TR>
							<TR vAlign="top">
								<TD height="24"></TD>
								<TD>
									<uc1:BackButtonNotifier id="BackButtonNotifier1" runat="server"></uc1:BackButtonNotifier></TD>
							</TR>
							<TR vAlign="top">
								<TD height="145"></TD>
								<TD>
									<TABLE border="1" height="144" width="833">
										<TR>
											<TD height="10%">
												here's what's in your cart:
											</TD>
										</TR>
										<TR>
											<TD>
												<TABLE id="Table1" border="0">
													<TR>
														<TD>Name</TD>
														<TD>Price</TD>
														<TD>Quantity</TD>
													</TR>
													<TR>
														<TD colSpan="3">
															<asp:Repeater id="cartRepeater" runat="server">
																<ItemTemplate>
																	<tr>
																		<td><%# DataBinder.Eval(Container.DataItem, "ModelName") %></td>
																		<td><%# DataBinder.Eval(Container.DataItem, "UnitCost") %></td>
																		<td><%# DataBinder.Eval(Container.DataItem, "quantity") %></td>
																	</tr>
																</ItemTemplate>
															</asp:Repeater></TD>
													</TR>
													<tr>
														<td colspan="3">
															<asp:LinkButton Runat="server" id="browseCatalog">Browse catalog</asp:LinkButton>
															&nbsp;&nbsp;<asp:LinkButton ID="checkoutButton" Runat="server">Checkout order</asp:LinkButton>
															&nbsp;&nbsp;<asp:LinkButton ID="endButton" Runat="server">Continue later</asp:LinkButton>
														</td>
													</tr>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
	</body>
</HTML>
