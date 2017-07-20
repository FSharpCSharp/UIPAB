<%@ OutputCache location="none" %>
<%@ Page language="c#" Codebehind="logon.aspx.cs" AutoEventWireup="false" Inherits="UIProcessQuickstarts_Store.WebUI.Logon" %>
<HTML>
	<HEAD>
		<title>Logon</title>
	</HEAD>
	<body ms_positioning="GridLayout">
		<TABLE height="628" cellSpacing="0" cellPadding="0" width="438" border="0" ms_2d_layout="TRUE">
			<TR vAlign="top">
				<TD width="438" height="628">
					<form id="Logon" method="post" runat="server">
						<TABLE height="421" cellSpacing="0" cellPadding="0" width="616" border="0" ms_2d_layout="TRUE">
							<TR vAlign="top">
								<TD width="172" height="34"></TD>
								<TD width="4"></TD>
								<TD width="1"></TD>
								<TD width="1"></TD>
								<TD width="79"></TD>
								<TD width="1"></TD>
								<TD width="272"></TD>
								<TD width="86" rowSpan="3"></TD>
							</TR>
							<TR vAlign="top">
								<TD colSpan="3" height="36"></TD>
								<TD colSpan="4">
									<asp:Label id="errorLabel" runat="server" Width="328px" ForeColor="Red" Font-Bold="True" Visible="False">The user or password are incorrect</asp:Label></TD>
							</TR>
							<TR vAlign="top">
								<TD colSpan="4" height="71"></TD>
								<TD colSpan="3">
									<asp:Label id="Label1" runat="server" Width="325px" Height="49px">Log in as:<br />'user@UIP.rocks',<br />'password'</asp:Label></TD>
							</TR>
							<TR vAlign="top">
								<TD colSpan="7" height="2"></TD>
								<TD rowSpan="3">
									<asp:Button id="OkButton" runat="server" Text="Let's Roll!"></asp:Button></TD>
							</TR>
							<TR vAlign="top">
								<TD colSpan="5" height="1"></TD>
								<TD colSpan="2" rowSpan="2">
									<asp:TextBox id="emailText" runat="server" Width="253px"></asp:TextBox></TD>
							</TR>
							<TR vAlign="top">
								<TD height="36"></TD>
								<TD colSpan="4">
									<asp:Label id="emailLabel" runat="server" Width="70px" Font-Names="Georgia" ForeColor="#C04000"
										Height="16px">Email</asp:Label></TD>
							</TR>
							<TR vAlign="top">
								<TD colSpan="6" height="1"></TD>
								<TD rowSpan="2">
									<asp:TextBox id="passwordText" runat="server" Width="253px" TextMode="Password"></asp:TextBox></TD>
								<TD rowSpan="2"></TD>
							</TR>
							<TR vAlign="top">
								<TD height="52"></TD>
								<TD colSpan="4">
									<asp:Label id="passwordLabel" runat="server" Width="70px" ForeColor="#C04000" Font-Names="Georgia"
										Height="16px">Password</asp:Label></TD>
								<TD></TD>
							</TR>
							<TR vAlign="top">
								<TD colSpan="2" height="188"></TD>
								<TD colSpan="6">
									<asp:Label id="lblCookie" runat="server" Width="427px" Height="187px"></asp:Label></TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
	</body>
</HTML>
