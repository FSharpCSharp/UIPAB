 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' browsecatalog.vb
'
' This file contains the implementations of the browsecatalog class.
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
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.ApplicationBlocks.UIProcess


Namespace UIProcessQuickstarts_Store.WinUI
   
   Public Class browsecatalog
      Inherits WindowsFormControlView
      Private cartLabel As System.Windows.Forms.Label
      Private catalogGrid As System.Windows.Forms.DataGrid
      Private WithEvents addButton As System.Windows.Forms.Button
      Private WithEvents lnkShowHelp As System.Windows.Forms.LinkLabel
      Private buttonPanel As System.Windows.Forms.Panel
      
      
        ' <summary>
        ' Required designer variable.
        ' </summary>
      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()
      End Sub 'New
      
      
      
        ' <summary>
        ' Clean up any resources being used.
        ' </summary>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub 'Dispose


#Region "Windows Form Designer generated code"

        '/ <summary>
        '/ Required method for Designer support - do not modify
        '/ the contents of this method with the code editor.
        '/ </summary>
        Private Sub InitializeComponent()
            Me.addButton = New System.Windows.Forms.Button
            Me.catalogGrid = New System.Windows.Forms.DataGrid
            Me.cartLabel = New System.Windows.Forms.Label
            Me.lnkShowHelp = New System.Windows.Forms.LinkLabel
            Me.buttonPanel = New System.Windows.Forms.Panel
            CType(Me.catalogGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.buttonPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' addButton
            ' 
            Me.addButton.Location = New System.Drawing.Point(384, 16)
            Me.addButton.Name = "addButton"
            Me.addButton.Size = New System.Drawing.Size(96, 24)
            Me.addButton.TabIndex = 1
            Me.addButton.Text = "Add to cart"
            ' 
            ' catalogGrid
            ' 
            Me.catalogGrid.DataMember = ""
            Me.catalogGrid.Dock = System.Windows.Forms.DockStyle.Fill
            Me.catalogGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.catalogGrid.Location = New System.Drawing.Point(0, 64)
            Me.catalogGrid.Name = "catalogGrid"
            Me.catalogGrid.Size = New System.Drawing.Size(488, 205)
            Me.catalogGrid.TabIndex = 2
            ' 
            ' cartLabel
            ' 
            Me.cartLabel.Location = New System.Drawing.Point(8, 32)
            Me.cartLabel.Name = "cartLabel"
            Me.cartLabel.Size = New System.Drawing.Size(72, 16)
            Me.cartLabel.TabIndex = 3
            Me.cartLabel.Text = "Catalog:"
            ' 
            ' lnkShowHelp
            ' 
            Me.lnkShowHelp.Location = New System.Drawing.Point(8, 8)
            Me.lnkShowHelp.Name = "lnkShowHelp"
            Me.lnkShowHelp.Size = New System.Drawing.Size(56, 16)
            Me.lnkShowHelp.TabIndex = 7
            Me.lnkShowHelp.TabStop = True
            Me.lnkShowHelp.Text = "Help"
            Me.lnkShowHelp.TextAlign = System.Drawing.ContentAlignment.TopCenter
            ' 
            ' buttonPanel
            ' 
            Me.buttonPanel.Controls.Add(Me.lnkShowHelp)
            Me.buttonPanel.Controls.Add(Me.cartLabel)
            Me.buttonPanel.Controls.Add(Me.addButton)
            Me.buttonPanel.Dock = System.Windows.Forms.DockStyle.Top
            Me.buttonPanel.Location = New System.Drawing.Point(0, 0)
            Me.buttonPanel.Name = "buttonPanel"
            Me.buttonPanel.Size = New System.Drawing.Size(488, 64)
            Me.buttonPanel.TabIndex = 8
            ' 
            ' browsecatalog
            ' 
            Me.Controls.Add(catalogGrid)
            Me.Controls.Add(buttonPanel)
            Me.Name = "browsecatalog"
            Me.Size = New System.Drawing.Size(488, 269)
            CType(Me.catalogGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.buttonPanel.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub 'InitializeComponent 
#End Region


        Private Sub addButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles addButton.Click
            StoreControllerHostedControl.AddToCart(CInt(catalogGrid(catalogGrid.CurrentRowIndex, 0)), 1)
        End Sub 'addButton_Click



        Private Sub lnkShowHelp_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkShowHelp.LinkClicked
            StoreControllerHostedControl.ShowShoppingHelp()
        End Sub 'lnkShowHelp_LinkClicked

#Region "UIPManager Plumbing"

        Private ReadOnly Property StoreControllerHostedControl() As StoreControllerHostedControl
            Get
                Return CType(Me.Controller, StoreControllerHostedControl)
            End Get
        End Property
#End Region

        Public Overloads Overrides Sub Initialize(ByVal args As TaskArgumentsHolder, ByVal settings As ViewSettings)
            Dim products As ProductDS
            products = StoreControllerHostedControl.GetCatalogProducts()
            catalogGrid.DataSource = products
            catalogGrid.DataMember = "product"
            Dim style As DataGridTableStyle
            style = New DataGridTableStyle
            style.ReadOnly = True
            style.MappingName = "product"

            Dim descriptors As PropertyDescriptorCollection
            descriptors = Me.BindingContext(products, "product").GetItemProperties()

            Dim productId As DataGridColumnStyle
            productId = New DataGridTextBoxColumn(descriptors("ProductId"))
            productId.MappingName = "ProductID"
            productId.HeaderText = "Product ID"
            productId.ReadOnly = True
            style.GridColumnStyles.Add(productId)

            Dim categoryId As DataGridColumnStyle
            categoryId = New DataGridTextBoxColumn(descriptors("CategoryID"))
            categoryId.MappingName = "CategoryID"
            categoryId.HeaderText = "Category ID"
            categoryId.ReadOnly = True
            style.GridColumnStyles.Add(categoryId)

            Dim modelNumber As DataGridColumnStyle
            modelNumber = New DataGridTextBoxColumn(descriptors("ModelNumber"))
            modelNumber.MappingName = "ModelNumber"
            modelNumber.HeaderText = "Model Number"
            modelNumber.ReadOnly = True
            style.GridColumnStyles.Add(modelNumber)

            Dim modelName As DataGridColumnStyle
            modelName = New DataGridTextBoxColumn(descriptors("ModelName"))
            modelName.MappingName = "ModelName"
            modelName.HeaderText = "Model Name"
            modelName.ReadOnly = True
            style.GridColumnStyles.Add(modelName)

            Dim unitCost As DataGridColumnStyle
            unitCost = New DataGridTextBoxColumn(descriptors("UnitCost"), "c")
            unitCost.MappingName = "UnitCost"
            unitCost.HeaderText = "Unit Cost"
            unitCost.ReadOnly = True
            style.GridColumnStyles.Add(unitCost)

            Dim description As DataGridColumnStyle
            description = New DataGridTextBoxColumn(descriptors("Description"))
            description.MappingName = "Description"
            description.HeaderText = "Description"
            description.ReadOnly = True
            style.GridColumnStyles.Add(description)

            catalogGrid.TableStyles.Add(style)
        End Sub
    End Class 'browsecatalog
End Namespace 'UIProcessQuickstarts_Store.WinUI