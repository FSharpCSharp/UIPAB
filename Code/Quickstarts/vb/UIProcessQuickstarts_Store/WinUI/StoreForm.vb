 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' StoreForm.vb
'
' This file contains the implementations of the StoreForm class.
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
    ' <summary>
    ' Summary description for StoreForm.
    ' </summary>
   
   Public Class StoreForm
      Inherits WindowsFormView
        ' <summary>
        ' Required designer variable.
        ' </summary>
      Private components As System.ComponentModel.Container = Nothing
      Private catalog As browsecatalog
      Private panel1 As System.Windows.Forms.Panel
      Private panel2 As System.Windows.Forms.Panel
      Private splitter1 As System.Windows.Forms.Splitter
      Private shoppingCart As cart
      
      
      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()
      End Sub 'New
       
      '
      ' TODO: Add any constructor code after InitializeComponent call
      '
      
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
            Me.catalog = New UIProcessQuickstarts_Store.WinUI.browsecatalog
            Me.shoppingCart = New UIProcessQuickstarts_Store.WinUI.cart
            Me.panel1 = New System.Windows.Forms.Panel
            Me.panel2 = New System.Windows.Forms.Panel
            Me.splitter1 = New System.Windows.Forms.Splitter
            Me.panel1.SuspendLayout()
            Me.panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'catalog
            '
            Me.catalog.Dock = System.Windows.Forms.DockStyle.Fill
            Me.catalog.InternalController = Nothing
            Me.catalog.InternalNavigator = Nothing
            Me.catalog.InternalViewName = Nothing
            Me.catalog.Location = New System.Drawing.Point(0, 0)
            Me.catalog.Name = "catalog"
            Me.catalog.Size = New System.Drawing.Size(500, 486)
            Me.catalog.TabIndex = 0
            '
            'shoppingCart
            '
            Me.shoppingCart.Dock = System.Windows.Forms.DockStyle.Fill
            Me.shoppingCart.InternalController = Nothing
            Me.shoppingCart.InternalNavigator = Nothing
            Me.shoppingCart.InternalViewName = Nothing
            Me.shoppingCart.Location = New System.Drawing.Point(0, 0)
            Me.shoppingCart.Name = "shoppingCart"
            Me.shoppingCart.Size = New System.Drawing.Size(516, 486)
            Me.shoppingCart.TabIndex = 1
            '
            'panel1
            '
            Me.panel1.Controls.Add(Me.catalog)
            Me.panel1.Dock = System.Windows.Forms.DockStyle.Left
            Me.panel1.Location = New System.Drawing.Point(0, 0)
            Me.panel1.Name = "panel1"
            Me.panel1.Size = New System.Drawing.Size(500, 486)
            Me.panel1.TabIndex = 2
            '
            'panel2
            '
            Me.panel2.Controls.Add(Me.shoppingCart)
            Me.panel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.panel2.Location = New System.Drawing.Point(500, 0)
            Me.panel2.Name = "panel2"
            Me.panel2.Size = New System.Drawing.Size(516, 486)
            Me.panel2.TabIndex = 3
            '
            'splitter1
            '
            Me.splitter1.Location = New System.Drawing.Point(500, 0)
            Me.splitter1.Name = "splitter1"
            Me.splitter1.Size = New System.Drawing.Size(8, 486)
            Me.splitter1.TabIndex = 4
            Me.splitter1.TabStop = False
            '
            'StoreForm
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(1016, 486)
            Me.Controls.Add(Me.splitter1)
            Me.Controls.Add(Me.panel2)
            Me.Controls.Add(Me.panel1)
            Me.Name = "StoreForm"
            Me.Text = "Store"
            Me.panel1.ResumeLayout(False)
            Me.panel2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub 'InitializeComponent 
#End Region
    End Class 'StoreForm
End Namespace 'UIProcessQuickstarts_Store.WinUI