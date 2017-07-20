 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' logon.vb
'
' This file contains the implementations of the logon class.
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
Imports System.Diagnostics

Imports Microsoft.ApplicationBlocks.UIProcess


Namespace UIProcessQuickstarts_Store.WinUI
   
   Public Class logon
        Inherits System.Windows.Forms.Form
        Implements IShutdownUIP
      Private _startingTask As ITask
      Private emailLabel As System.Windows.Forms.Label
      Private emailText As System.Windows.Forms.TextBox
      Private passwordText As System.Windows.Forms.TextBox
      Private passwordLabel As System.Windows.Forms.Label
      Private WithEvents okButton As System.Windows.Forms.Button
      
        ' <summary>
        ' Required designer variable.
        ' </summary>
      Private components As System.ComponentModel.Container = Nothing
      Private label1 As System.Windows.Forms.Label
      
      Private Shared User As String
      
      
      Public Shared ReadOnly Property UserName() As String
         Get
            Return User
         End Get
      End Property
       
      
      Public Sub New()
            UIPManager.RegisterShutdown(Me)
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
            Me.emailLabel = New System.Windows.Forms.Label
            Me.emailText = New System.Windows.Forms.TextBox
            Me.passwordText = New System.Windows.Forms.TextBox
            Me.passwordLabel = New System.Windows.Forms.Label
            Me.okButton = New System.Windows.Forms.Button
            Me.label1 = New System.Windows.Forms.Label
            Me.SuspendLayout()
            ' 
            ' emailLabel
            ' 
            Me.emailLabel.Location = New System.Drawing.Point(48, 80)
            Me.emailLabel.Name = "emailLabel"
            Me.emailLabel.Size = New System.Drawing.Size(48, 16)
            Me.emailLabel.TabIndex = 0
            Me.emailLabel.Text = "Email"
            ' 
            ' emailText
            ' 
            Me.emailText.Location = New System.Drawing.Point(112, 80)
            Me.emailText.Name = "emailText"
            Me.emailText.Size = New System.Drawing.Size(144, 20)
            Me.emailText.TabIndex = 1
            Me.emailText.Text = ""
            ' 
            ' passwordText
            ' 
            Me.passwordText.Location = New System.Drawing.Point(112, 112)
            Me.passwordText.Name = "passwordText"
            Me.passwordText.PasswordChar = "*"c
            Me.passwordText.Size = New System.Drawing.Size(144, 20)
            Me.passwordText.TabIndex = 3
            Me.passwordText.Text = ""
            ' 
            ' passwordLabel
            ' 
            Me.passwordLabel.Location = New System.Drawing.Point(48, 112)
            Me.passwordLabel.Name = "passwordLabel"
            Me.passwordLabel.Size = New System.Drawing.Size(64, 16)
            Me.passwordLabel.TabIndex = 2
            Me.passwordLabel.Text = "Password"
            ' 
            ' okButton
            ' 
            Me.okButton.Location = New System.Drawing.Point(176, 144)
            Me.okButton.Name = "okButton"
            Me.okButton.Size = New System.Drawing.Size(80, 24)
            Me.okButton.TabIndex = 4
            Me.okButton.Text = "Lets roll"
            ' 
            ' label1
            ' 
            Me.label1.Location = New System.Drawing.Point(48, 24)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(208, 32)
            Me.label1.TabIndex = 5
            Me.label1.Text = "Log On As: user@UIP.rocks, password"
            ' 
            ' logon
            ' 
            Me.AcceptButton = Me.okButton
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(328, 184)
            Me.Controls.Add(label1)
            Me.Controls.Add(okButton)
            Me.Controls.Add(passwordText)
            Me.Controls.Add(emailText)
            Me.Controls.Add(passwordLabel)
            Me.Controls.Add(emailLabel)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.Name = "logon"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Logon"
            Me.ResumeLayout(False)
        End Sub 'InitializeComponent 
#End Region


        Private Sub okButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles okButton.Click
            'Ask controller if user is valid
            If StoreControllerHostedControl.IsUserValid(emailText.Text, passwordText.Text) Then
                '  Logon was valid.
                User = emailText.Text
                _startingTask = New CartTask(emailText.Text)
                ' Start task with the previous task id
                UIPManager.StartUserControlsTask("Shop", _startingTask)

                'This view can be hidden because it started the task and its lifetime isnt controlled
                'by the UIPManager class
                Me.Visible = False
            Else
                MessageBox.Show("The user or password are incorrect")
            End If
        End Sub 'okButton_Click

        Public ReadOnly Property StartingTask() As ITask
            Get
                Return _startingTask
            End Get
        End Property

        Public Sub Shutdown() Implements IShutdownUIP.Shutdown
            Me.Close()
        End Sub
    End Class 'logon 
End Namespace 'UIProcessQuickstarts_Store.WinUI 