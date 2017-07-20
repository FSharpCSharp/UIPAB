 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' Login.vb
'
' This file contains the implementations of the Login class.
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

Namespace InsuranceClientManagement.UI

    ' <summary>
    ' Summary description for Login.
    ' </summary>
    Public Class Login
        Inherits Microsoft.ApplicationBlocks.UIProcess.WindowsFormView
        Private txtUsername As System.Windows.Forms.TextBox
        Private txtPassword As System.Windows.Forms.TextBox
        Private WithEvents btnNoLogin As System.Windows.Forms.Button
        Private label1 As System.Windows.Forms.Label
        Private label2 As System.Windows.Forms.Label
        Private WithEvents btnLogin As System.Windows.Forms.Button
        Private label3 As System.Windows.Forms.Label
        Private errorProvider As System.Windows.Forms.ErrorProvider
        Private label4 As System.Windows.Forms.Label
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

        ' <summary>
        ' Required method for Designer support - do not modify
        ' the contents of this method with the code editor.
        ' </summary>
        Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
        Private Sub InitializeComponent()
            Me.txtUsername = New System.Windows.Forms.TextBox
            Me.txtPassword = New System.Windows.Forms.TextBox
            Me.btnNoLogin = New System.Windows.Forms.Button
            Me.label1 = New System.Windows.Forms.Label
            Me.label2 = New System.Windows.Forms.Label
            Me.btnLogin = New System.Windows.Forms.Button
            Me.label3 = New System.Windows.Forms.Label
            Me.errorProvider = New System.Windows.Forms.ErrorProvider
            Me.label4 = New System.Windows.Forms.Label
            Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
            Me.SuspendLayout()
            '
            'txtUsername
            '
            Me.txtUsername.Location = New System.Drawing.Point(152, 96)
            Me.txtUsername.Name = "txtUsername"
            Me.txtUsername.TabIndex = 1
            Me.txtUsername.Text = ""
            '
            'txtPassword
            '
            Me.txtPassword.Location = New System.Drawing.Point(152, 144)
            Me.txtPassword.Name = "txtPassword"
            Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
            Me.txtPassword.TabIndex = 3
            Me.txtPassword.Text = ""
            '
            'btnNoLogin
            '
            Me.btnNoLogin.Location = New System.Drawing.Point(152, 192)
            Me.btnNoLogin.Name = "btnNoLogin"
            Me.btnNoLogin.Size = New System.Drawing.Size(112, 40)
            Me.btnNoLogin.TabIndex = 7
            Me.btnNoLogin.Text = "Enter Anonymously (no login)"
            '
            'label1
            '
            Me.label1.Location = New System.Drawing.Point(32, 144)
            Me.label1.Name = "label1"
            Me.label1.TabIndex = 9
            Me.label1.Text = "password"
            '
            'label2
            '
            Me.label2.Location = New System.Drawing.Point(32, 96)
            Me.label2.Name = "label2"
            Me.label2.TabIndex = 10
            Me.label2.Text = "username"
            '
            'btnLogin
            '
            Me.btnLogin.Location = New System.Drawing.Point(24, 192)
            Me.btnLogin.Name = "btnLogin"
            Me.btnLogin.Size = New System.Drawing.Size(112, 40)
            Me.btnLogin.TabIndex = 11
            Me.btnLogin.Text = "Login"
            '
            'label3
            '
            Me.label3.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
            Me.label3.Location = New System.Drawing.Point(8, 8)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(272, 32)
            Me.label3.TabIndex = 12
            Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'errorProvider
            '
            Me.errorProvider.ContainerControl = Me
            '
            'label4
            '
            Me.label4.Location = New System.Drawing.Point(24, 48)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(240, 24)
            Me.label4.TabIndex = 13
            Me.label4.Text = "Username = 'manager' Password= 'manager'"
            '
            'LinkLabel1
            '
            Me.LinkLabel1.Location = New System.Drawing.Point(24, 248)
            Me.LinkLabel1.Name = "LinkLabel1"
            Me.LinkLabel1.TabIndex = 14
            Me.LinkLabel1.TabStop = True
            Me.LinkLabel1.Text = "Help"
            '
            'Login
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(292, 277)
            Me.Controls.Add(Me.LinkLabel1)
            Me.Controls.Add(Me.label4)
            Me.Controls.Add(Me.label3)
            Me.Controls.Add(Me.btnLogin)
            Me.Controls.Add(Me.label2)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.btnNoLogin)
            Me.Controls.Add(Me.txtPassword)
            Me.Controls.Add(Me.txtUsername)
            Me.Name = "Login"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Login"
            Me.ResumeLayout(False)

        End Sub
#End Region

        Private Sub btnLogin_Click_1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
            If CheckUsernameAndPassword() Then
                CType(Controller, InsuranceClientManagementController).LogMeIn(txtUsername.Text.Trim(), txtPassword.Text.Trim())
            End If
        End Sub

		Private Function CheckUsernameAndPassword() As Boolean
			ClearErrors()

			Dim isValid As Boolean = CheckControlHasText(txtUsername, "Must Enter Username") And CheckControlHasText(txtPassword, "Must Enter Password")

			If (isValid) Then
				If Not (MyController.IsManager(txtUsername.Text, txtPassword.Text)) Then
					errorProvider.SetError(txtUsername, "The login information provided is invalid.")
					isValid = False
				End If
			End If

			Return isValid
		End Function

		Private Sub ClearErrors()
			For Each _textBox As Control In Me.Controls
				If (TypeOf _textBox Is TextBox) Then
					errorProvider.SetError(_textBox, "")
				End If
			Next
		End Sub
		Private Function CheckControlHasText(ByVal control As Control, ByVal errorMessage As String) As Boolean
			If control.Text.Trim().Length > 0 Then
				errorProvider.SetError(control, "")
				Return True
			End If
			errorProvider.SetError(control, errorMessage)
			Return False
		End Function

		Private Sub btnNoLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNoLogin.Click
			CType(Controller, InsuranceClientManagementController).DoNotLogMeIn()
		End Sub

		Private Sub Login_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If Not (Me.Navigator.CurrentState(Constants.Error) Is Nothing) Then
				label3.Text = CStr(Me.Navigator.CurrentState(Constants.Error))
				btnNoLogin.Enabled = False
			End If
		End Sub

		Private ReadOnly Property MyController() As InsuranceClientManagementController
			Get
				Return DirectCast(Controller, InsuranceClientManagementController)
			End Get
		End Property

        Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
            CType(Controller, InsuranceClientManagementController).ShowHelp()
        End Sub
    End Class

End Namespace