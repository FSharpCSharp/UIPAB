 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' BannerForm.vb
'
' This file contains the implementations of the BannerForm class.
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

Namespace Client

    ' <summary>
    ' Summary description for BannerForm.
    ' </summary>
    Public Class BannerForm
        Inherits Microsoft.ApplicationBlocks.UIProcess.WindowsFormView
        Private WithEvents label1 As System.Windows.Forms.Label

        ' <summary>
        ' Required designer variable.
        ' </summary>
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
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
        Private Sub InitializeComponent()
            Me.label1 = New System.Windows.Forms.Label
            Me.SuspendLayout()
            ' 
            ' label1
            ' 
            Me.label1.Location = New System.Drawing.Point(104, 32)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(120, 16)
            Me.label1.TabIndex = 0
            Me.label1.Text = "Right Click To Hide!"
            ' 
            ' BannerForm
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(328, 86)
            Me.Controls.Add(label1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "BannerForm"
            Me.ShowInTaskbar = False
            Me.ResumeLayout(False)
        End Sub

#End Region

        Private Sub BannerForm_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles label1.MouseDown, MyBase.MouseDown
			If e.Button = MouseButtons.Right Then
				Me.Close()				
			End If
        End Sub

    End Class

End Namespace