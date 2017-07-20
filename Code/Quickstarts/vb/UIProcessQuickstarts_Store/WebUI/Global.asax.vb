
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web
Imports System.Web.SessionState
Imports Microsoft.ApplicationBlocks.UIProcess


Namespace UIProcessQuickstarts_Store
    ' <summary>
    ' Summary description for Global.
    ' </summary>
   
   Public Class Global
      Inherits System.Web.HttpApplication
      
      Public Sub New()
         InitializeComponent()
      End Sub 'New
      
      
      
      Protected Sub Application_Start(sender As [Object], e As EventArgs)
      End Sub 'Application_Start
      
      
      Protected Sub Session_SessionEnding(sender As Object, e As EventArgs)
      End Sub 'Session_SessionEnding
      
      
      
      Protected Sub Session_Start(sender As [Object], e As EventArgs)
      End Sub 'Session_Start
      
      
      
      Protected Sub Application_BeginRequest(sender As [Object], e As EventArgs)
      End Sub 'Application_BeginRequest
      
      
      
      
      Protected Sub Application_EndRequest(sender As [Object], e As EventArgs)
      End Sub 'Application_EndRequest
      
      
      
      
      Protected Sub Application_AuthenticateRequest(sender As [Object], e As EventArgs)
      End Sub 'Application_AuthenticateRequest
      
      
      
      
      Protected Sub Application_Error(sender As [Object], e As EventArgs)
         Session("UnhandledException") = Server.GetLastError()
         Server.ClearError()
         Response.Redirect("genericError.aspx")
      End Sub 'Application_Error
      
      
      
      Protected Sub Session_End(sender As [Object], e As EventArgs)
      End Sub 'Session_End
      
      
      
      Protected Sub Application_End(sender As [Object], e As EventArgs)
      End Sub 'Application_End
      
      
      
      #Region "Web Form Designer generated code"
      
      '/ <summary>
      '/ Required method for Designer support - do not modify
      '/ the contents of this method with the code editor.
      '/ </summary>
      Private Sub InitializeComponent()
      End Sub 'InitializeComponent
      #End Region
   End Class 'Global
End Namespace 'UIProcessQuickstarts_Store
