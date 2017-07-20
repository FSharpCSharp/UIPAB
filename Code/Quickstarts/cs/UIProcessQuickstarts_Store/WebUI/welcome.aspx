<%@ Page language="c#" Codebehind="welcome.aspx.cs" AutoEventWireup="false" Inherits="UIProcessQuickstarts_Store.WebUI.welcome" %>
<%@ OutputCache location="none" %>
<HTML>
    <HEAD>
    </HEAD>
    <body>
        <form id="welcome" method="post" runat="server">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="center">
                        <FONT face="Arial" color="#993366" size="6"><STRONG>Welcome to store application</STRONG></FONT>
                    </td>
                </tr>
                <tr>
                    <td align="center"><br>
                        <br>
                        <asp:LinkButton Runat="server" ID="startButton">Start a new process</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
