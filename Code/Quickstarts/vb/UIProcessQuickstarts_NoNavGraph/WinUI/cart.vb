 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' cart.vb
'
' This file contains the implementations of the cart class.
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
Imports System.Data
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.ApplicationBlocks.UIProcess

Namespace UIProcessQuickstarts_Store.WinUI

    Public Class cart
        Inherits WindowsFormView
        Private cartGrid As System.Windows.Forms.DataGrid
        Private cartLabel As System.Windows.Forms.Label
        Private WithEvents catalogButton As System.Windows.Forms.Button
        Private WithEvents checkoutButton As System.Windows.Forms.Button
        Private WithEvents continueButton As System.Windows.Forms.Button
        Private cartDS As CartDS

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
            Me.catalogButton = New System.Windows.Forms.Button
            Me.cartGrid = New System.Windows.Forms.DataGrid
            Me.cartLabel = New System.Windows.Forms.Label
            Me.checkoutButton = New System.Windows.Forms.Button
            Me.continueButton = New System.Windows.Forms.Button
            CType(Me.cartGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' catalogButton
            ' 
            Me.catalogButton.Location = New System.Drawing.Point(384, 16)
            Me.catalogButton.Name = "catalogButton"
            Me.catalogButton.Size = New System.Drawing.Size(96, 24)
            Me.catalogButton.TabIndex = 1
            Me.catalogButton.Text = "Browse catalog"
            ' 
            ' cartGrid
            ' 
            Me.cartGrid.DataMember = ""
            Me.cartGrid.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.cartGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.cartGrid.Location = New System.Drawing.Point(0, 61)
            Me.cartGrid.Name = "cartGrid"
            Me.cartGrid.Size = New System.Drawing.Size(488, 208)
            Me.cartGrid.TabIndex = 2
            ' 
            ' cartLabel
            ' 
            Me.cartLabel.Location = New System.Drawing.Point(8, 32)
            Me.cartLabel.Name = "cartLabel"
            Me.cartLabel.Size = New System.Drawing.Size(72, 16)
            Me.cartLabel.TabIndex = 3
            Me.cartLabel.Text = "Your cart:"
            ' 
            ' checkoutButton
            ' 
            Me.checkoutButton.Location = New System.Drawing.Point(272, 16)
            Me.checkoutButton.Name = "checkoutButton"
            Me.checkoutButton.Size = New System.Drawing.Size(96, 24)
            Me.checkoutButton.TabIndex = 4
            Me.checkoutButton.Text = "Checkout order"
            ' 
            ' continueButton
            ' 
            Me.continueButton.Location = New System.Drawing.Point(160, 16)
            Me.continueButton.Name = "continueButton"
            Me.continueButton.Size = New System.Drawing.Size(96, 24)
            Me.continueButton.TabIndex = 5
            Me.continueButton.Text = "Continue later"
            ' 
            ' cart
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(488, 269)
            Me.ControlBox = False
            Me.Controls.Add(continueButton)
            Me.Controls.Add(checkoutButton)
            Me.Controls.Add(cartLabel)
            Me.Controls.Add(cartGrid)
            Me.Controls.Add(catalogButton)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.Name = "cart"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "My cart"
            CType(Me.cartGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

#End Region

        Private Sub cart_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        End Sub

        Private Sub cart_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
            If (Me.Controller.State.Count = 0) Then
                Me.Bind()
            End If
        End Sub

        Private Sub browseCatalogButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles catalogButton.Click
            StoreController.ResumeShopping()
        End Sub

        Private Sub cart_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        End Sub

        Private Sub checkoutButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles checkoutButton.Click
            StoreController.CheckoutOrder()
        End Sub

        Private Sub continueButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles continueButton.Click
            StoreController.StopShopping()
            Application.Exit()
        End Sub

#Region "UIPManager Plumbing"

        Private ReadOnly Property StoreController() As StoreController
            Get
                Return CType(Me.Controller, StoreController)
            End Get
        End Property

#End Region

        Private Sub Bind()
            cartDS = StoreController.GetCart()
            AddHandler cartDS.CartItems.RowChanging, AddressOf OnRowChanged
            AddHandler cartDS.CartItems.RowDeleted, AddressOf OnRowDeleted
            Dim view As DataView
            view = cartDS.CartItems.DefaultView
            view.AllowNew = False
            cartGrid.DataSource = cartDS
            cartGrid.DataMember = "cart_details"
        End Sub

        Public Overloads Overrides Sub Initialize(ByVal args As TaskArgumentsHolder, ByVal settings As ViewSettings)
            Me.Bind()
            AddHandler Me.Controller.State.StateChanged, AddressOf OnStateChanged
            Dim tableStyle As DataGridTableStyle
            tableStyle = New DataGridTableStyle
            tableStyle.MappingName = "cart_details"

            Dim descriptors As PropertyDescriptorCollection
            descriptors = BindingContext(cartDS, "cart_details").GetItemProperties()

            Dim quantity As DataGridColumnStyle
            quantity = New DataGridTextBoxColumn(descriptors("Quantity"))
            quantity.MappingName = "Quantity"
            quantity.ReadOnly = False
            quantity.HeaderText = "Quantity"
            tableStyle.GridColumnStyles.Add(quantity)

            Dim productId As DataGridColumnStyle
            productId = New DataGridTextBoxColumn(descriptors("ProductID"))
            productId.MappingName = "ProductID"
            productId.HeaderText = "Product ID"
            productId.ReadOnly = True
            tableStyle.GridColumnStyles.Add(productId)

            Dim modelName As DataGridColumnStyle
            modelName = New DataGridTextBoxColumn(descriptors("ModelName"))
            modelName.MappingName = "ModelName"
            modelName.HeaderText = "Model Name"
            modelName.ReadOnly = True
            tableStyle.GridColumnStyles.Add(modelName)

            Dim unitCost As DataGridColumnStyle
            unitCost = New DataGridTextBoxColumn(descriptors("UnitCost"), "c")
            unitCost.MappingName = "UnitCost"
            unitCost.HeaderText = "Unit Cost"
            unitCost.ReadOnly = True
            tableStyle.GridColumnStyles.Add(unitCost)

            cartGrid.TableStyles.Add(tableStyle)
            checkoutButton.Enabled = ItemCount > 0
        End Sub

        Private ReadOnly Property ItemCount() As Integer
            Get
                Return cartDS.CartItems.Rows.Count
            End Get
        End Property

        Private Sub OnRowChanged(ByVal sender As Object, ByVal args As DataRowChangeEventArgs)
            If (args.Action = DataRowAction.Add) Then
                checkoutButton.Enabled = True
            End If
        End Sub

        Private Sub OnRowDeleted(ByVal sender As Object, ByVal args As DataRowChangeEventArgs)
            If (args.Action = DataRowAction.Delete And ItemCount = 0) Then
                checkoutButton.Enabled = False
            End If
        End Sub

        Private Sub OnStateChanged(ByVal sender As Object, ByVal args As StateChangedEventArgs)
            If (Me.Controller.State.Count = 0) Then
                checkoutButton.Enabled = False
            End If
        End Sub
    End Class

End Namespace