<%@ Page language="c#" Codebehind="genericError.aspx.cs" AutoEventWireup="false" Inherits="UIProcessQuickstarts_Store.WebUI.genericError" %>
<%@ Register TagPrefix="uc1" TagName="BackButtonNotifier" Src="BackButtonNotifier.ascx" %>
<HTML>
	<HEAD>
		<title>Error</title>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<TABLE height="633" cellSpacing="0" cellPadding="0" width="363" border="0" ms_2d_layout="TRUE">
			<TR vAlign="top">
				<TD width="363" height="633">
					<form id="error" method="post" runat="server">
						<TABLE height="346" cellSpacing="0" cellPadding="0" width="621" border="0" ms_2d_layout="TRUE">
							<TR vAlign="top">
								<TD width="10" height="15"></TD>
								<TD width="611"></TD>
							</TR>
							<TR vAlign="top">
								<TD height="331"></TD>
								<TD>
									<table border="0" cellpadding="0" cellspacing="0" width="610" height="330">
										<tr>
											<td align="center" valign="middle">
												<P>
													Error page
													<br>
													<asp:Label id="errorLabel" Runat="server" ForeColor="red"></asp:Label>
													<br>
													<asp:LinkButton id="backButton" runat="server">Go back to logon page</asp:LinkButton></P>
												<P></P>
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
