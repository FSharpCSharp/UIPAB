 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' welcome.aspx.vb
'
' This file contains the implementations of the welcome code behind class.
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
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports Microsoft.ApplicationBlocks.UIProcess


Namespace UIProcessQuickstarts_Store.WebUI
    ' <summary>
    ' Summary description for welcome.
    ' </summary>
   
   Public Class welcome
      Inherits System.Web.UI.Page
      Protected resumeButton As System.Web.UI.WebControls.LinkButton
      Protected WithEvents startButton As System.Web.UI.WebControls.LinkButton
      
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         If Not Page.IsPostBack Then
            '  create a CartTask object; Task object allow us to package
            '  the Task-Logon correlation code 
            Dim task As New CartTask(Page.User.Identity.Name)
            
                If task.Get().Equals(Guid.Empty) Then
                    startButton.Text = "Start to a new buy process"
                Else
                    startButton.Text = "Continue the existing buy process"
                End If
            End If
      End Sub 'Page_Load 
      #Region "Web Form Designer generated code"
      
      Protected Overrides Sub OnInit(e As EventArgs)
         '
         ' CODEGEN: This call is required by the ASP.NET Web Form Designer.
         '
         InitializeComponent()
         MyBase.OnInit(e)
      End Sub 'OnInit
      
      
      '/ <summary>
      '/ Required method for Designer support - do not modify
      '/ the contents of this method with the code editor.
      '/ </summary>
      Private Sub InitializeComponent()
      End Sub 'InitializeComponent
      
      #End Region
      
      
      Private Sub startButton_Click(sender As Object, e As System.EventArgs) Handles startButton.Click
         '  create a CartTask object; Task object allow us to package
         '  the Task-Logon correlation code 
         Dim task As New CartTask(Page.User.Identity.Name)
         
         '  ask UIPManager to Start Task--that is, 
         '  Send us to a new NavGraph and initiate a new Task...or use a known Task..in that new NavGraph
         UIPManager.StartNavigationTask("Shopping", task)
      End Sub 'startButton_Click
   End Class 'welcome
End Namespace 'UIProcessQuickstarts_Store.WebUI