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
      Inherits WindowsFormControlView
      Private cartGrid As System.Windows.Forms.DataGrid
      Private cartLabel As System.Windows.Forms.Label
      Private WithEvents catalogButton As System.Windows.Forms.Button
      Private WithEvents checkoutButton As System.Windows.Forms.Button
      Private WithEvents continueButton As System.Windows.Forms.Button
      Private WithEvents lnkShowHelp As System.Windows.Forms.LinkLabel
      Private buttonPanel As System.Windows.Forms.Panel
        Private cartDS As CartDS
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
            Me.catalogButton = New System.Windows.Forms.Button
            Me.cartGrid = New System.Windows.Forms.DataGrid
            Me.cartLabel = New System.Windows.Forms.Label
            Me.checkoutButton = New System.Windows.Forms.Button
            Me.continueButton = New System.Windows.Forms.Button
            Me.lnkShowHelp = New System.Windows.Forms.LinkLabel
            Me.buttonPanel = New System.Windows.Forms.Panel
            CType(Me.cartGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.buttonPanel.SuspendLayout()
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
            Me.cartGrid.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cartGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.cartGrid.Location = New System.Drawing.Point(0, 64)
            Me.cartGrid.Name = "cartGrid"
            Me.cartGrid.Size = New System.Drawing.Size(488, 205)
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
            ' lnkShowHelp
            '
            Me.lnkShowHelp.Location = New System.Drawing.Point(8, 0)
            Me.lnkShowHelp.Name = "lnkShowHelp"
            Me.lnkShowHelp.Size = New System.Drawing.Size(56, 16)
            Me.lnkShowHelp.TabIndex = 6
            Me.lnkShowHelp.TabStop = True
            Me.lnkShowHelp.Text = "Help"
            Me.lnkShowHelp.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            ' buttonPanel
            '
            Me.buttonPanel.Controls.Add(Me.lnkShowHelp)
            Me.buttonPanel.Controls.Add(Me.continueButton)
            Me.buttonPanel.Controls.Add(Me.checkoutButton)
            Me.buttonPanel.Controls.Add(Me.catalogButton)
            Me.buttonPanel.Dock = System.Windows.Forms.DockStyle.Top
            Me.buttonPanel.Location = New System.Drawing.Point(0, 0)
            Me.buttonPanel.Name = "buttonPanel"
            Me.buttonPanel.Size = New System.Drawing.Size(488, 64)
            Me.buttonPanel.TabIndex = 7
            '
            ' cart
            '
            Me.Controls.Add(cartGrid)
            Me.Controls.Add(buttonPanel)
            Me.Name = "cart"
            Me.Size = New System.Drawing.Size(488, 269)
            CType(Me.cartGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.buttonPanel.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub 'InitializeComponent 
#End Region


        Private Sub browseCatalogButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles catalogButton.Click
            StoreControllerHostedControl.ResumeShopping()
        End Sub 'browseCatalogButton_Click


        Private Sub checkoutButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles checkoutButton.Click
            StoreControllerHostedControl.CheckoutOrder()
        End Sub 'checkoutButton_Click


        Private Sub continueButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles continueButton.Click
            StoreControllerHostedControl.StopShopping()
            Application.Exit()
        End Sub 'continueButton_Click


        Private Sub lnkShowHelp_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkShowHelp.LinkClicked
            StoreControllerHostedControl.ShowStoreHelp()
        End Sub 'lnkShowHelp_LinkClicked

#Region "UIPManager Plumbing"

        Private ReadOnly Property StoreControllerHostedControl() As StoreControllerHostedControl
            Get
                Return CType(Me.Controller, StoreControllerHostedControl)
            End Get
        End Property

        Public Overloads Overrides Sub Initialize(ByVal args As TaskArgumentsHolder, ByVal settings As ViewSettings)
            cartDS = StoreControllerHostedControl.GetCart()
            AddHandler cartDS.CartItems.RowChanging, AddressOf OnRowChanged
            AddHandler cartDS.CartItems.RowDeleted, AddressOf OnRowDeleted
            Dim view As DataView
            view = cartDS.CartItems.DefaultView
            view.AllowNew = False
            cartGrid.DataSource = cartDS
            cartGrid.DataMember = "cart_details"
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
#End Region
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


    End Class 'cart
End Namespace 'UIProcessQuickstarts_Store.WinUI