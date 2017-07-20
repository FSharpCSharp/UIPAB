 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' Welcome.vb
'
' This file contains the implementations of the Welcome class.
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
    ' Summary description for Welcome.
    ' </summary>
    Public Class Welcome
        Inherits Microsoft.ApplicationBlocks.UIProcess.WindowsFormView
        Private WithEvents btnAddClient As System.Windows.Forms.Button
        Private label1 As System.Windows.Forms.Label
        Private btnDeleteClient As System.Windows.Forms.Button
        Private btnSellCarInsurance As System.Windows.Forms.Button
        Private btnSellHomeInsurance As System.Windows.Forms.Button
        Private btnUpdateUserInfo As System.Windows.Forms.Button
        Private btnSearchForUser As System.Windows.Forms.Button
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
        End Sub

#Region "Windows Form Designer generated code"

        ' <summary>
        ' Required method for Designer support - do not modify
        ' the contents of this method with the code editor.
        ' </summary>
        Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
        Private Sub InitializeComponent()
            Me.btnAddClient = New System.Windows.Forms.Button
            Me.label1 = New System.Windows.Forms.Label
            Me.btnDeleteClient = New System.Windows.Forms.Button
            Me.btnSellCarInsurance = New System.Windows.Forms.Button
            Me.btnSellHomeInsurance = New System.Windows.Forms.Button
            Me.btnUpdateUserInfo = New System.Windows.Forms.Button
            Me.btnSearchForUser = New System.Windows.Forms.Button
            Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
            Me.SuspendLayout()
            '
            'btnAddClient
            '
            Me.btnAddClient.Location = New System.Drawing.Point(24, 88)
            Me.btnAddClient.Name = "btnAddClient"
            Me.btnAddClient.Size = New System.Drawing.Size(96, 23)
            Me.btnAddClient.TabIndex = 0
            Me.btnAddClient.Text = "Add Client"
            '
            'label1
            '
            Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label1.Location = New System.Drawing.Point(24, 16)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(232, 48)
            Me.label1.TabIndex = 1
            Me.label1.Text = "Welcome to Client Management"
            Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnDeleteClient
            '
            Me.btnDeleteClient.Enabled = False
            Me.btnDeleteClient.Location = New System.Drawing.Point(160, 88)
            Me.btnDeleteClient.Name = "btnDeleteClient"
            Me.btnDeleteClient.Size = New System.Drawing.Size(96, 23)
            Me.btnDeleteClient.TabIndex = 2
            Me.btnDeleteClient.Text = "Delete Client"
            '
            'btnSellCarInsurance
            '
            Me.btnSellCarInsurance.Enabled = False
            Me.btnSellCarInsurance.Location = New System.Drawing.Point(24, 144)
            Me.btnSellCarInsurance.Name = "btnSellCarInsurance"
            Me.btnSellCarInsurance.Size = New System.Drawing.Size(96, 32)
            Me.btnSellCarInsurance.TabIndex = 3
            Me.btnSellCarInsurance.Text = "Sell Car Insurance"
            '
            'btnSellHomeInsurance
            '
            Me.btnSellHomeInsurance.Enabled = False
            Me.btnSellHomeInsurance.Location = New System.Drawing.Point(160, 144)
            Me.btnSellHomeInsurance.Name = "btnSellHomeInsurance"
            Me.btnSellHomeInsurance.Size = New System.Drawing.Size(96, 32)
            Me.btnSellHomeInsurance.TabIndex = 4
            Me.btnSellHomeInsurance.Text = "Sell Home Insurance"
            '
            'btnUpdateUserInfo
            '
            Me.btnUpdateUserInfo.Enabled = False
            Me.btnUpdateUserInfo.Location = New System.Drawing.Point(24, 208)
            Me.btnUpdateUserInfo.Name = "btnUpdateUserInfo"
            Me.btnUpdateUserInfo.Size = New System.Drawing.Size(96, 40)
            Me.btnUpdateUserInfo.TabIndex = 5
            Me.btnUpdateUserInfo.Text = "Update User Information"
            '
            'btnSearchForUser
            '
            Me.btnSearchForUser.Enabled = False
            Me.btnSearchForUser.Location = New System.Drawing.Point(160, 208)
            Me.btnSearchForUser.Name = "btnSearchForUser"
            Me.btnSearchForUser.Size = New System.Drawing.Size(96, 40)
            Me.btnSearchForUser.TabIndex = 6
            Me.btnSearchForUser.Text = "Search For Users"
            '
            'LinkLabel1
            '
            Me.LinkLabel1.Location = New System.Drawing.Point(24, 264)
            Me.LinkLabel1.Name = "LinkLabel1"
            Me.LinkLabel1.TabIndex = 7
            Me.LinkLabel1.TabStop = True
            Me.LinkLabel1.Text = "Help"
            '
            'Welcome
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(288, 301)
            Me.Controls.Add(Me.LinkLabel1)
            Me.Controls.Add(Me.btnSearchForUser)
            Me.Controls.Add(Me.btnUpdateUserInfo)
            Me.Controls.Add(Me.btnSellHomeInsurance)
            Me.Controls.Add(Me.btnSellCarInsurance)
            Me.Controls.Add(Me.btnDeleteClient)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.btnAddClient)
            Me.Name = "Welcome"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Welcome"
            Me.ResumeLayout(False)

        End Sub
#End Region

        Private Sub btnAddClient_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddClient.Click
            CType(Me.Controller, InsuranceClientManagementController).StartAddingClient()
        End Sub

        Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
            CType(Controller, InsuranceClientManagementController).ShowHelp()
        End Sub
    End Class

End Namespace