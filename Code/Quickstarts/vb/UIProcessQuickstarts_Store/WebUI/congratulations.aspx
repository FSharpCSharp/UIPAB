<%@ OutputCache location="none" %>
<%@ Page language="vb" Codebehind="congratulations.aspx.vb" AutoEventWireup="false" Inherits="UIProcessQuickstarts_Store.WebUI.congratulations" %>
<%@ Register TagPrefix="uc1" TagName="BackButtonNotifier" Src="BackButtonNotifier.ascx" %>
<HTML>
	<HEAD>
		<title>Congratulations</title>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<TABLE height="633" cellSpacing="0" cellPadding="0" width="363" border="0" ms_2d_layout="TRUE">
			<TR vAlign="top">
				<TD width="363" height="633">
					<form id="congratulations" method="post" runat="server">
						<TABLE height="346" cellSpacing="0" cellPadding="0" width="621" border="0" ms_2d_layout="TRUE">
							<TR vAlign="top">
								<TD width="10" height="15"></TD>
								<TD width="611"></TD>
							</TR>
							<TR vAlign="top">
								<TD height="331"></TD>
								<TD>
									<table height="330" cellSpacing="0" cellPadding="0" width="610" border="0">
										<tr>
											<td vAlign="middle" align="center">
												<P>Congratulations.
													<BR>
													Your order has been created sucessfully.<BR>
													<BR>
													<asp:linkbutton id="catalogButton" runat="server">Return to the cart</asp:linkbutton>&nbsp;&nbsp;
													<asp:linkbutton id="logOffButton" runat="server">Log Off</asp:linkbutton>&nbsp;&nbsp;</P>
											</td>
										</tr>
									</table>
								</TD>
							</TR>
							<uc1:BackButtonNotifier id="BackButtonNotifier1" runat="server"></uc1:BackButtonNotifier></TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
	</body>
</HTML>
