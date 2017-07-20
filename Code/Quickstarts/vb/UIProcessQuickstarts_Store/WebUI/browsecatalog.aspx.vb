 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' browsecatalog.aspx.vb
'
' This file contains the implementations of the browscatalog code behind class.
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
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports Microsoft.ApplicationBlocks.UIProcess


Namespace UIProcessQuickstarts_Store.WebUI
   
   Public Class browsecatalog1
      Inherits Microsoft.ApplicationBlocks.UIProcess.WebFormView
      Protected WithEvents catalogGrid As System.Web.UI.WebControls.DataGrid
      
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         If Not Page.IsPostBack Then
            FillCatalogRepeater() '  Populate Catalog repeater
         End If
      End Sub 'Page_Load
       
      Private Sub FillCatalogRepeater()
         catalogGrid.DataSource = StoreControllerNavGraph.GetCatalogProducts().Products
         catalogGrid.DataBind()
      End Sub 'FillCatalogRepeater
      
      
      
      Private Sub catalogGrid_ItemCommand([source] As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles catalogGrid.ItemCommand
         If e.CommandName = "AddItem" Then
            Dim productID As Integer = CInt(catalogGrid.DataKeys(e.Item.ItemIndex))
            
            '  OK, there's something there...add it to cart
            StoreControllerNavGraph.AddToCart(productID, 1)
         End If
      End Sub 'catalogGrid_ItemCommand 
      
      
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

		End Sub	   'InitializeComponent
      
      #End Region
      
      #Region "UIPManager Plumbing"
      
      Private ReadOnly Property StoreControllerNavGraph() As StoreControllerNavGraph
         Get
            Return CType(Me.Controller, StoreControllerNavGraph)
         End Get
      End Property
      #End Region
   End Class 'browsecatalog1
End Namespace 'UIProcessQuickstarts_Store.WebUI