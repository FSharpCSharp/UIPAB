<%@ OutputCache location="none" %>
<%@ Page language="c#" Codebehind="checkout.aspx.cs" AutoEventWireup="false" Inherits="UIProcessQuickstarts_Store.WebUI.checkout" %>
<%@ Register TagPrefix="uc1" TagName="BackButtonNotifier" Src="BackButtonNotifier.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Checkout</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:BackButtonNotifier id="BackButtonNotifier1" runat="server"></uc1:BackButtonNotifier>
			<TABLE id="Table1" cellSpacing="1" height="296" cellPadding="1" width="637" align="center"
				border="0" style="WIDTH: 637px; HEIGHT: 296px">
				<TR>
					<TD align="center" colSpan="2"><FONT face="Arial" color="#993366" size="4"><STRONG>Please 
								enter your Checkout Information Here:</STRONG></FONT></TD>
				</TR>
				<TR>
					<TD vAlign="top" style="HEIGHT: 36px"><FONT face="Arial" color="#cc3366">Your Name</FONT></TD>
					<TD align="left" vAlign="top" style="HEIGHT: 36px">
						<asp:TextBox id="txtName" runat="server" Width="291px"></asp:TextBox><FONT face="Arial" color="#cc3366"></FONT></TD>
				</TR>
				<TR>
					<TD vAlign="top" style="HEIGHT: 41px"><FONT face="Arial" color="#cc3366">Your Address</FONT></TD>
					<TD align="left" vAlign="top" style="HEIGHT: 41px">
						<asp:TextBox id="txtAddr" runat="server" Width="291px" tabIndex="1"></asp:TextBox><FONT face="Arial" color="#cc3366"></FONT></TD>
				</TR>
				<TR>
					<TD vAlign="top" style="HEIGHT: 43px"><FONT face="Arial" color="#cc3366">Your Credit 
							Card Number</FONT></TD>
					<TD align="left" vAlign="top" style="HEIGHT: 43px">
						<asp:TextBox id="txtCCNum" runat="server" Width="291px" tabIndex="2">1111-1111-1111-1111</asp:TextBox>
						<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"
							ControlToValidate="txtCCNum"></asp:RequiredFieldValidator></TD>
				</TR>
				<TR>
					<TD colSpan="2" style="HEIGHT: 63px"><FONT face="Arial" color="#993366"><STRONG>Thank You! 
								Hit the "Finish Order" Button to complete your order:</STRONG></FONT></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<asp:Button id="btnFinish" runat="server" Text="Finish Order" Font-Bold="True" Font-Size="Medium"
							tabIndex="3"></asp:Button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
