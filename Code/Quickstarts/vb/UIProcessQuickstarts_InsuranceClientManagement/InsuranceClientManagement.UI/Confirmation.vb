 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' Confirmation.vb
'
' This file contains the implementations of the Confirmation class.
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
    ' Summary description for Confirmation.
    ' </summary>
    Public Class Confirmation
        Inherits Microsoft.ApplicationBlocks.UIProcess.WindowsFormView
        Private label1 As System.Windows.Forms.Label
        Private WithEvents btnContinue As System.Windows.Forms.Button

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
			'
			' TODO: Add any constructor code after InitializeComponent call
			'
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
            Me.label1 = New System.Windows.Forms.Label
            Me.btnContinue = New System.Windows.Forms.Button
            Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
            Me.SuspendLayout()
            '
            'label1
            '
            Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label1.Location = New System.Drawing.Point(8, 8)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(280, 216)
            Me.label1.TabIndex = 0
            Me.label1.Text = "label1"
            '
            'btnContinue
            '
            Me.btnContinue.Location = New System.Drawing.Point(64, 240)
            Me.btnContinue.Name = "btnContinue"
            Me.btnContinue.Size = New System.Drawing.Size(160, 23)
            Me.btnContinue.TabIndex = 1
            Me.btnContinue.Text = "Continue Client Management"
            '
            'LinkLabel1
            '
            Me.LinkLabel1.Location = New System.Drawing.Point(64, 272)
            Me.LinkLabel1.Name = "LinkLabel1"
            Me.LinkLabel1.TabIndex = 2
            Me.LinkLabel1.TabStop = True
            Me.LinkLabel1.Text = "Help"
            '
            'Confirmation
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(296, 301)
            Me.Controls.Add(Me.LinkLabel1)
            Me.Controls.Add(Me.btnContinue)
            Me.Controls.Add(Me.label1)
            Me.Name = "Confirmation"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Confirmation"
            Me.TopMost = True
            Me.ResumeLayout(False)

        End Sub
#End Region

        Private Sub btnContinue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinue.Click
            CType(Controller, InsuranceClientManagementController).ContinueManagement()
        End Sub

        Private Sub Confirmation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim client As client = CType(Me.Navigator.CurrentState(Constants.Client), client)
            label1.Text = String.Format("Client Added by User '{0}'" + ControlChars.Lf + ControlChars.Lf + "{1}", CStr(Me.Navigator.CurrentState(Constants.UserId)), client.GenerateSummary())
        End Sub

        Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
            CType(Controller, InsuranceClientManagementController).ShowHelp()
        End Sub
    End Class

End Namespace