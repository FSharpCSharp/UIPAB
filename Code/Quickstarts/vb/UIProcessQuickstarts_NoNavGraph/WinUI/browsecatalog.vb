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
        Inherits WindowsFormView
        Private cartLabel As System.Windows.Forms.Label
        Private catalogGrid As System.Windows.Forms.DataGrid
        Private WithEvents addButton As System.Windows.Forms.Button

        ' <summary>
        ' Required designer variable.
        ' </summary>
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            MyBase.New()
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()
        End Sub

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
        End Sub

#Region "Windows Form Designer generated code"

        '/ <summary>
        '/ Required method for Designer support - do not modify
        '/ the contents of this method with the code editor.
        '/ </summary>
        Private Sub InitializeComponent()
            Me.addButton = New System.Windows.Forms.Button
            Me.catalogGrid = New System.Windows.Forms.DataGrid
            Me.cartLabel = New System.Windows.Forms.Label
            CType(Me.catalogGrid, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.catalogGrid.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.catalogGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.catalogGrid.Location = New System.Drawing.Point(0, 61)
            Me.catalogGrid.Name = "catalogGrid"
            Me.catalogGrid.Size = New System.Drawing.Size(488, 208)
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
            ' browsecatalog
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(488, 269)
            Me.ControlBox = False
            Me.Controls.Add(cartLabel)
            Me.Controls.Add(catalogGrid)
            Me.Controls.Add(addButton)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.Name = "browsecatalog"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Browse catalog"
            CType(Me.catalogGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

#End Region

        Private Sub addButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles addButton.Click
            StoreController.AddToCart(CInt(catalogGrid(catalogGrid.CurrentRowIndex, 0)), 1)
        End Sub

        Private Sub browsecatalog_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        End Sub

#Region "UIPManager Plumbing"

        Private ReadOnly Property StoreController() As StoreController
            Get
                Return CType(Me.Controller, StoreController)
            End Get
        End Property

#End Region

        Public Overloads Overrides Sub Initialize(ByVal args As TaskArgumentsHolder, ByVal settings As ViewSettings)
            Dim products As ProductDS
            products = StoreController.GetCatalogProducts()
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
    End Class

End Namespace