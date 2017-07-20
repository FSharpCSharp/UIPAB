 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' ClientSearch.vb
'
' This file contains the implementations of the ClientSearch class.
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
    ' Summary description for ClientSearch.
    ' </summary>
    Public Class ClientSearch
        Inherits Microsoft.ApplicationBlocks.UIProcess.WindowsFormView
        Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel

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

            Throw New ApplicationException("This has not been implemented yet!")
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
            Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
            Me.SuspendLayout()
            '
            'LinkLabel1
            '
            Me.LinkLabel1.Location = New System.Drawing.Point(88, 208)
            Me.LinkLabel1.Name = "LinkLabel1"
            Me.LinkLabel1.TabIndex = 0
            Me.LinkLabel1.TabStop = True
            Me.LinkLabel1.Text = "Help"
            '
            'ClientSearch
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(292, 273)
            Me.Controls.Add(Me.LinkLabel1)
            Me.Name = "ClientSearch"
            Me.Text = "ClientSearch"
            Me.ResumeLayout(False)

        End Sub
#End Region

        Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
            CType(Controller, InsuranceClientManagementController).ShowHelp()
        End Sub
    End Class

End Namespace