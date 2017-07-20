 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' cart.aspx.vb
'
' This file contains the implementations of the cart code behind class.
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
Imports System.Web.Security

Imports Microsoft.ApplicationBlocks.UIProcess


Namespace UIProcessQuickstarts_Store.WebUI
    ' <summary>
    ' Summary description for cart1.
    ' </summary>
   
   Public Class cart
      Inherits WebFormView
      Protected WithEvents checkoutButton As System.Web.UI.WebControls.LinkButton
      Protected WithEvents browseCatalog As System.Web.UI.WebControls.LinkButton
      Protected WithEvents endButton As System.Web.UI.WebControls.LinkButton
      Protected cartRepeater As System.Web.UI.WebControls.Repeater
      
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         If Not Page.IsPostBack Then
            FillCartRepeater() ' Populate Cart repeater
         End If
      End Sub 'Page_Load
      
      
      Private Sub FillCartRepeater()
            cartRepeater.DataSource = StoreControllerNavGraph.GetCart()
            cartRepeater.DataMember = "cart_details"
         cartRepeater.DataBind()
      End Sub 'FillCartRepeater
      
      
      Private Sub checkoutButton_Click(sender As Object, e As System.EventArgs) Handles checkoutButton.Click
         StoreControllerNavGraph.CheckoutOrder()
      End Sub 'checkoutButton_Click
      
      #Region "Web Form Designer generated code"
      
      Protected Overrides Sub OnInit(e As EventArgs)
         '
         ' CODEGEN: This call is required by the ASP.NET Web Form Designer.
         '
         InitializeComponent()
         MyBase.OnInit(e)
      End Sub 'OnInit
      
      
      '/		Required method for Designer support - do not modify
      '/		the contents of this method with the code editor.
      '/ </summary>
      Private Sub InitializeComponent()

		End Sub	   'InitializeComponent
      
      #End Region
      
      
      Private Sub browseCatalog_Click(sender As Object, e As System.EventArgs) Handles browseCatalog.Click
         StoreControllerNavGraph.ResumeShopping()
      End Sub 'browseCatalog_Click
      
      
      Private Sub endButton_Click(sender As Object, e As System.EventArgs) Handles endButton.Click
         FormsAuthentication.SignOut()
         StoreControllerNavGraph.StopShopping()
      End Sub 'endButton_Click
      
      #Region "UIPManager Plumbing"
      
      Private ReadOnly Property StoreControllerNavGraph() As StoreControllerNavGraph
         Get
            Return CType(Me.Controller, StoreControllerNavGraph)
         End Get
      End Property
      #End Region
   End Class 'cart
End Namespace 'UIProcessQuickstarts_Store.WebUI