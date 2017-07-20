 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' uipError.aspx.vb
'
' This file contains the implementations of the uipError code behind class.
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

Imports Microsoft.ApplicationBlocks.UIProcess


Namespace UIProcessQuickstarts_Store.WebUI
   
   Public Class uipError
      Inherits WebFormView
      Protected errorLabel As System.Web.UI.WebControls.Label
      Protected WithEvents backButton As System.Web.UI.WebControls.LinkButton
      
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         If Not Page.IsPostBack Then
            Dim exception As Exception = StoreControllerNavGraph.GetLastError()
            
            Dim errMessage As String = ""
            Dim tempException As Exception
            
            While Not (tempException Is Nothing)
               errMessage += tempException.Message + "<br><br>"
               tempException = tempException.InnerException
            End While
            
            errorLabel.Text = errMessage + "<br>" + "You should be sure UIP database scripts was executed over the sql server"
         End If
      End Sub 'Page_Load
       
      
      Private Sub backButton_Click(sender As Object, e As System.EventArgs) Handles backButton.Click
         StoreControllerNavGraph.ClearError()
      End Sub 'backButton_Click
      
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

		End Sub	   'InitializeComponent
      
      #End Region
      
      #Region "UIPManager Plumbing"
      
      Private ReadOnly Property StoreControllerNavGraph() As StoreControllerNavGraph
         Get
            Return CType(Controller, StoreControllerNavGraph)
         End Get
      End Property
      #End Region
   End Class 'uipError
End Namespace 'UIProcessQuickstarts_Store.WebUI