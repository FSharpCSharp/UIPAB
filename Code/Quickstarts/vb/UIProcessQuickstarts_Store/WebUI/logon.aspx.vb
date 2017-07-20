 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' logon.aspx.vb
'
' This file contains the implementations of the logon code behind class.
'
' 
'===============================================================================
' Copyright (C) 2000-2001 Microsoft Corporation
' All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
' FITNESS FOR A PARTICULAR PURPOSE.
'==============================================================================
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Web.Security

Imports Microsoft.ApplicationBlocks.UIProcess


Namespace UIProcessQuickstarts_Store.WebUI
   
   Public Class Logon
      Inherits System.Web.UI.Page
      Protected emailText As System.Web.UI.WebControls.TextBox
      Protected WithEvents OkButton As System.Web.UI.WebControls.Button
      Protected passwordLabel As System.Web.UI.WebControls.Label
      Protected passwordText As System.Web.UI.WebControls.TextBox
      Protected emailLabel As System.Web.UI.WebControls.Label
      Protected lblCookie As System.Web.UI.WebControls.Label
      Protected Label1 As System.Web.UI.WebControls.Label
      Protected errorLabel As System.Web.UI.WebControls.Label
      
      
      Private Sub Logon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      End Sub 'Logon_Load
      
      
      
      Private Sub OkButton_Click(sender As Object, e As System.EventArgs) Handles OkButton.Click
         errorLabel.Visible = False
         Dim email As String = emailText.Text
         Dim password As String = passwordText.Text
         Dim isUserValid As Boolean = False
         
         Try
            isUserValid = StoreControllerNavGraph.IsUserValid(email, password)
         Catch ex As Exception
            Dim err As String = "ERROR: " + ex.Message + "<br/>" + ex.StackTrace
            lblCookie.Text = err
         End Try
         
         'Ask controller if user is valid
         If isUserValid Then
            '  Logon was valid.
            FormsAuthentication.SetAuthCookie(email, False)
            
            Response.Redirect("welcome.aspx")
         Else
            errorLabel.Visible = True '  logon was not valid.
         End If
      End Sub 'OkButton_Click 
      
      #Region "Web Form Designer generated code"
      
      Protected Overrides Sub OnInit(e As EventArgs)
         '
         ' CODEGEN: This call is required by the ASP.NET Web Form Designer.
         '
         InitializeComponent()
         MyBase.OnInit(e)
      End Sub 'OnInit
      
      
        ' <summary>
        ' Required method for Designer support - do not modify
        ' the contents of this method with the code editor.
        ' </summary>
      Private Sub InitializeComponent()
      End Sub 'InitializeComponent
      
      #End Region
   End Class 'Logon 
End Namespace 'UIProcessQuickstarts_Store.WebUI