 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' Start.vb
'
' This file contains the implementations of the Start class.
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

Namespace InsuranceClientManagement.UI

    ' <summary>
    ' Summary description for Start.
    ' </summary>
    Public Class Start
        Inherits System.Windows.Forms.Form
        Private WithEvents btnStartMeUp As System.Windows.Forms.Button
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
            Authorization.INSTANCE.Init()
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
        Private Sub InitializeComponent()
            Me.btnStartMeUp = New System.Windows.Forms.Button
            Me.SuspendLayout()
            ' 
            ' btnStartMeUp
            ' 
            Me.btnStartMeUp.Location = New System.Drawing.Point(80, 88)
            Me.btnStartMeUp.Name = "btnStartMeUp"
            Me.btnStartMeUp.Size = New System.Drawing.Size(128, 80)
            Me.btnStartMeUp.TabIndex = 0
            Me.btnStartMeUp.Text = "Start Client Management System"
            ' 
            ' Start
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(292, 273)
            Me.Controls.Add(btnStartMeUp)
            Me.Name = "Start"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Start"
            Me.ResumeLayout(False)
        End Sub
#End Region

        Private Sub btnStartAuthenticated_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStartMeUp.Click
            UIPManager.StartNavigationTask("ManageInsuranceClients")
        End Sub

    End Class

End Namespace