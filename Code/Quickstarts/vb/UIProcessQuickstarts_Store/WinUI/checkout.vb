 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' checkout.vb
'
' This file contains the implementations of the checkout class.
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
    ' Summary description for checkout.
    ' </summary>
   
   Public Class checkout
      Inherits WindowsFormView
      Private label1 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private label4 As System.Windows.Forms.Label
      Private nameText As System.Windows.Forms.TextBox
      Private addressText As System.Windows.Forms.TextBox
      Private creditCardText As System.Windows.Forms.TextBox
      Private WithEvents finishButton As System.Windows.Forms.Button
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
        Friend WithEvents cancel As System.Windows.Forms.Button
        Private Sub InitializeComponent()
            Me.label1 = New System.Windows.Forms.Label
            Me.label2 = New System.Windows.Forms.Label
            Me.label3 = New System.Windows.Forms.Label
            Me.label4 = New System.Windows.Forms.Label
            Me.nameText = New System.Windows.Forms.TextBox
            Me.addressText = New System.Windows.Forms.TextBox
            Me.creditCardText = New System.Windows.Forms.TextBox
            Me.finishButton = New System.Windows.Forms.Button
            Me.cancel = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            'label1
            '
            Me.label1.Location = New System.Drawing.Point(56, 32)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(240, 24)
            Me.label1.TabIndex = 0
            Me.label1.Text = "Please, enter your checkout information here:"
            '
            'label2
            '
            Me.label2.Location = New System.Drawing.Point(56, 72)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(64, 16)
            Me.label2.TabIndex = 1
            Me.label2.Text = "Your name:"
            '
            'label3
            '
            Me.label3.Location = New System.Drawing.Point(56, 104)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(88, 16)
            Me.label3.TabIndex = 2
            Me.label3.Text = "Your address:"
            '
            'label4
            '
            Me.label4.Location = New System.Drawing.Point(56, 136)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(136, 16)
            Me.label4.TabIndex = 3
            Me.label4.Text = "Your credit card number:"
            '
            'nameText
            '
            Me.nameText.Enabled = False
            Me.nameText.Location = New System.Drawing.Point(192, 70)
            Me.nameText.Name = "nameText"
            Me.nameText.Size = New System.Drawing.Size(176, 20)
            Me.nameText.TabIndex = 4
            Me.nameText.Text = ""
            '
            'addressText
            '
            Me.addressText.Enabled = False
            Me.addressText.Location = New System.Drawing.Point(192, 102)
            Me.addressText.Name = "addressText"
            Me.addressText.Size = New System.Drawing.Size(176, 20)
            Me.addressText.TabIndex = 5
            Me.addressText.Text = ""
            '
            'creditCardText
            '
            Me.creditCardText.Enabled = False
            Me.creditCardText.Location = New System.Drawing.Point(192, 134)
            Me.creditCardText.Name = "creditCardText"
            Me.creditCardText.Size = New System.Drawing.Size(176, 20)
            Me.creditCardText.TabIndex = 6
            Me.creditCardText.Text = ""
            '
            'finishButton
            '
            Me.finishButton.Location = New System.Drawing.Point(56, 184)
            Me.finishButton.Name = "finishButton"
            Me.finishButton.Size = New System.Drawing.Size(128, 24)
            Me.finishButton.TabIndex = 7
            Me.finishButton.Text = "Finish order"
            '
            'cancel
            '
            Me.cancel.Location = New System.Drawing.Point(264, 184)
            Me.cancel.Name = "cancel"
            Me.cancel.TabIndex = 8
            Me.cancel.Text = "Cancel"
            '
            'checkout
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(408, 230)
            Me.ControlBox = False
            Me.Controls.Add(Me.cancel)
            Me.Controls.Add(Me.finishButton)
            Me.Controls.Add(Me.creditCardText)
            Me.Controls.Add(Me.addressText)
            Me.Controls.Add(Me.nameText)
            Me.Controls.Add(Me.label4)
            Me.Controls.Add(Me.label3)
            Me.Controls.Add(Me.label2)
            Me.Controls.Add(Me.label1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Name = "checkout"
            Me.Text = "Checkout"
            Me.ResumeLayout(False)

        End Sub 'InitializeComponent 
#End Region


        Private Sub finishButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles finishButton.Click
            StoreControllerHostedControl.CompleteCheckout(nameText.Text, addressText.Text, creditCardText.Text)
        End Sub 'finishButton_Click


        Private Sub checkout_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim cust As CustomerDS.Customer = StoreControllerHostedControl.GetCustomerByLogon(logon.UserName)
            nameText.Text = cust.FullName
            addressText.Text = cust.EmailAddress
            creditCardText.Text = "1111-1111-1111-1111"
        End Sub 'checkout_Load

#Region "UIPManager Plumbing"

        Private ReadOnly Property StoreControllerHostedControl() As StoreControllerHostedControl
            Get
                Return CType(Me.Controller, StoreControllerHostedControl)
            End Get
        End Property
#End Region

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel.Click
            StoreControllerHostedControl.ResumeShopping()
        End Sub
    End Class 'checkout
End Namespace 'UIProcessQuickstarts_Store.WinUI