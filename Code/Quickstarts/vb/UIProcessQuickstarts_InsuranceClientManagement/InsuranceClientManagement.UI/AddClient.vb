 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' AddClient.vb
'
' This file contains the implementations of the AddClient class.
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

    Public Class AddClient
        Inherits Microsoft.ApplicationBlocks.UIProcess.WindowsFormView
        Private WithEvents btnAddClient As System.Windows.Forms.Button
        Private WithEvents btnThrowException As System.Windows.Forms.Button
        Private txtName As System.Windows.Forms.TextBox
        Private txtAddress As System.Windows.Forms.TextBox
        Private txtPhoneNumber As System.Windows.Forms.TextBox
        Private label1 As System.Windows.Forms.Label
        Private label2 As System.Windows.Forms.Label
        Private label3 As System.Windows.Forms.Label
        Private txtCountry As System.Windows.Forms.TextBox
        Private label4 As System.Windows.Forms.Label
        Private errorProvider As System.Windows.Forms.ErrorProvider
        Private label5 As System.Windows.Forms.Label
        Private components As System.ComponentModel.Container = Nothing


        Public Sub New()
            MyBase.New()
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
        End Sub

#Region "Windows Form Designer generated code"

        ' <summary>
        ' Required method for Designer support - do not modify
        ' the contents of this method with the code editor.
        ' </summary>
        Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
        Private Sub InitializeComponent()
            Me.btnAddClient = New System.Windows.Forms.Button
            Me.btnThrowException = New System.Windows.Forms.Button
            Me.txtName = New System.Windows.Forms.TextBox
            Me.txtAddress = New System.Windows.Forms.TextBox
            Me.txtPhoneNumber = New System.Windows.Forms.TextBox
            Me.txtCountry = New System.Windows.Forms.TextBox
            Me.label1 = New System.Windows.Forms.Label
            Me.label2 = New System.Windows.Forms.Label
            Me.label3 = New System.Windows.Forms.Label
            Me.label4 = New System.Windows.Forms.Label
            Me.errorProvider = New System.Windows.Forms.ErrorProvider
            Me.label5 = New System.Windows.Forms.Label
            Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
            Me.SuspendLayout()
            '
            'btnAddClient
            '
            Me.btnAddClient.Location = New System.Drawing.Point(24, 232)
            Me.btnAddClient.Name = "btnAddClient"
            Me.btnAddClient.Size = New System.Drawing.Size(112, 40)
            Me.btnAddClient.TabIndex = 8
            Me.btnAddClient.Text = "Add Client"
            '
            'btnThrowException
            '
            Me.btnThrowException.Location = New System.Drawing.Point(160, 232)
            Me.btnThrowException.Name = "btnThrowException"
            Me.btnThrowException.Size = New System.Drawing.Size(120, 40)
            Me.btnThrowException.TabIndex = 9
            Me.btnThrowException.Text = "Search For Client (Throws Exception)"
            '
            'txtName
            '
            Me.txtName.Location = New System.Drawing.Point(152, 56)
            Me.txtName.Name = "txtName"
            Me.txtName.Size = New System.Drawing.Size(128, 20)
            Me.txtName.TabIndex = 1
            Me.txtName.Text = ""
            '
            'txtAddress
            '
            Me.txtAddress.Location = New System.Drawing.Point(152, 96)
            Me.txtAddress.Multiline = True
            Me.txtAddress.Name = "txtAddress"
            Me.txtAddress.Size = New System.Drawing.Size(128, 40)
            Me.txtAddress.TabIndex = 3
            Me.txtAddress.Text = ""
            '
            'txtPhoneNumber
            '
            Me.txtPhoneNumber.Location = New System.Drawing.Point(152, 192)
            Me.txtPhoneNumber.Name = "txtPhoneNumber"
            Me.txtPhoneNumber.Size = New System.Drawing.Size(128, 20)
            Me.txtPhoneNumber.TabIndex = 7
            Me.txtPhoneNumber.Text = ""
            '
            'txtCountry
            '
            Me.txtCountry.Location = New System.Drawing.Point(152, 152)
            Me.txtCountry.Name = "txtCountry"
            Me.txtCountry.Size = New System.Drawing.Size(128, 20)
            Me.txtCountry.TabIndex = 5
            Me.txtCountry.Text = ""
            '
            'label1
            '
            Me.label1.Location = New System.Drawing.Point(32, 56)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(80, 23)
            Me.label1.TabIndex = 0
            Me.label1.Text = "Name"
            '
            'label2
            '
            Me.label2.Location = New System.Drawing.Point(32, 96)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(80, 23)
            Me.label2.TabIndex = 2
            Me.label2.Text = "Address"
            '
            'label3
            '
            Me.label3.Location = New System.Drawing.Point(32, 192)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(80, 23)
            Me.label3.TabIndex = 6
            Me.label3.Text = "Phone Number"
            '
            'label4
            '
            Me.label4.Location = New System.Drawing.Point(32, 152)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(72, 23)
            Me.label4.TabIndex = 4
            Me.label4.Text = "Country"
            '
            'errorProvider
            '
            Me.errorProvider.ContainerControl = Me
            '
            'label5
            '
            Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label5.Location = New System.Drawing.Point(32, 8)
            Me.label5.Name = "label5"
            Me.label5.Size = New System.Drawing.Size(232, 32)
            Me.label5.TabIndex = 10
            Me.label5.Text = "Add Client Information"
            Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'LinkLabel1
            '
            Me.LinkLabel1.Location = New System.Drawing.Point(80, 304)
            Me.LinkLabel1.Name = "LinkLabel1"
            Me.LinkLabel1.TabIndex = 11
            Me.LinkLabel1.TabStop = True
            Me.LinkLabel1.Text = "Help"
            '
            'AddClient
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(304, 349)
            Me.Controls.Add(Me.LinkLabel1)
            Me.Controls.Add(Me.label5)
            Me.Controls.Add(Me.label4)
            Me.Controls.Add(Me.label3)
            Me.Controls.Add(Me.label2)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.txtCountry)
            Me.Controls.Add(Me.txtPhoneNumber)
            Me.Controls.Add(Me.txtAddress)
            Me.Controls.Add(Me.txtName)
            Me.Controls.Add(Me.btnThrowException)
            Me.Controls.Add(Me.btnAddClient)
            Me.Name = "AddClient"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Add Client to System"
            Me.ResumeLayout(False)

        End Sub
#End Region

        Private Sub btnAddClient_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddClient.Click
            Dim client As client = GetClientInfo()
            If CheckControls() Then
                CType(Controller, InsuranceClientManagementController).ExecuteAddClientRequest(client)
            End If
        End Sub

        Private Function CheckControls() As Boolean
            Return CheckControlHasText(txtAddress, "An Address Must Be Entered") And CheckControlHasText(txtCountry, "A Country Must Be Entered") And CheckControlHasText(txtName, "A Name Must Be Entered") And CheckControlHasText(txtPhoneNumber, "A Phone Number Must Be Entered")
        End Function

        Private Function CheckControlHasText(ByVal control As Control, ByVal errorMessage As String) As Boolean
            If control.Text.Trim().Length > 0 Then
                errorProvider.SetError(control, "")
                Return True
            End If
            errorProvider.SetError(control, errorMessage)
            Return False
        End Function

        Private Function GetClientInfo() As Client
            Dim client As New client
            client.Address = txtAddress.Text.Trim()
            client.Country = txtCountry.Text.Trim()
            client.Name = txtName.Text.Trim()
            client.PhoneNumber = txtPhoneNumber.Text.Trim()
            Return client
        End Function

        Private Sub btnThrowException_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThrowException.Click
            CType(Controller, InsuranceClientManagementController).ThrowException()
        End Sub

        Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
            CType(Controller, InsuranceClientManagementController).ShowHelp()
        End Sub
    End Class

End Namespace