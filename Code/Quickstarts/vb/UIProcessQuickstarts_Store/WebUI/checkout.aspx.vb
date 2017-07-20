 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' checkout.aspx.vb
'
' This file contains the implementations of the checkout code behind class.
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
   
   Public Class checkout
      Inherits WebFormView
      Protected txtName As System.Web.UI.WebControls.TextBox
      Protected txtAddr As System.Web.UI.WebControls.TextBox
      Protected txtCCNum As System.Web.UI.WebControls.TextBox
      Protected RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
      Protected WithEvents btnFinish As System.Web.UI.WebControls.Button
      
      
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         '  if known customer, try to retrieve cust info and pre-populate form fields
         If Not Page.IsPostBack Then
            ShowCustInfo()
         End If
      End Sub 'Page_Load
      
      
      Private Sub ShowCustInfo()
         Dim cust As CustomerDS.Customer = myController.GetCustomerByLogon(Page.User.Identity.Name)
         txtName.Text = cust.FullName
         txtAddr.Text = cust.EmailAddress
         txtCCNum.Text = "1111-1111-1111-1111"
      End Sub 'ShowCustInfo
      
      
      Private Sub btnFinish_Click(sender As Object, e As System.EventArgs) Handles btnFinish.Click
         myController.CompleteCheckout(txtName.Text, txtAddr.Text, txtCCNum.Text)
      End Sub 'btnFinish_Click
      
      
      Private ReadOnly Property myController() As StoreControllerNavGraph
         Get
            Return CType(Controller, StoreControllerNavGraph)
         End Get
      End Property 
      
      #Region "Web Form Designer generated code"
      
      
      Protected Overrides Sub OnInit(e As EventArgs)
         InitializeComponent()
         MyBase.OnInit(e)
      End Sub 'OnInit
      
      Private Sub InitializeComponent()

		End Sub	   'InitializeComponent
      
      #End Region
   End Class 'checkout
End Namespace 'UIProcessQuickstarts_Store.WebUI