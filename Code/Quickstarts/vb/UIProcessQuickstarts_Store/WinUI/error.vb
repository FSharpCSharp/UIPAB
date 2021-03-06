 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' error.cs
'
' This file contains the implementations of the error class.
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
   
   Public Class errorView
      Inherits WindowsFormView
      Private WithEvents returnButton As System.Windows.Forms.Button
      Private msgLabel As System.Windows.Forms.Label
      
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
            Me.msgLabel = New System.Windows.Forms.Label
            Me.returnButton = New System.Windows.Forms.Button
            Me.SuspendLayout()
            ' 
            ' msgLabel
            ' 
            Me.msgLabel.Location = New System.Drawing.Point(32, 24)
            Me.msgLabel.Name = "msgLabel"
            Me.msgLabel.Size = New System.Drawing.Size(264, 104)
            Me.msgLabel.TabIndex = 0
            Me.msgLabel.Text = "Error message"
            Me.msgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' returnButton
            ' 
            Me.returnButton.Location = New System.Drawing.Point(104, 152)
            Me.returnButton.Name = "returnButton"
            Me.returnButton.Size = New System.Drawing.Size(104, 24)
            Me.returnButton.TabIndex = 1
            Me.returnButton.Text = "Return"
            ' 
            ' errorView
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(314, 184)
            Me.ControlBox = False
            Me.Controls.Add(returnButton)
            Me.Controls.Add(msgLabel)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.Name = "errorView"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Error"
            Me.ResumeLayout(False)
        End Sub 'InitializeComponent 
#End Region


        Private Sub returnButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles returnButton.Click
            StoreControllerHostedControl.ClearError()
        End Sub 'returnButton_Click


        Private Sub error_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim errMessage As String = ""
            Dim tempException As Exception

            While Not (tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While
            msgLabel.Text = errMessage + Environment.NewLine + "You should be sure UIP database scripts was executed over the sql server"
        End Sub 'error_Load

#Region "UIPManager Plumbing"

        Private ReadOnly Property StoreControllerHostedControl() As StoreControllerHostedControl
            Get
                Return CType(Me.Controller, StoreControllerHostedControl)
            End Get
        End Property
#End Region
    End Class 'errorView
End Namespace 'UIProcessQuickstarts_Store.WinUI