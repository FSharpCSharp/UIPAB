 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' StartMeUp.vb
'
' This file contains the implementations of the StartMeUp class.
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

Namespace Client

    ' <summary>
    ' Summary description for StartMeUp.
    ' </summary>
    Public Class StartMeUp
        Inherits System.Windows.Forms.Form
		Implements IShutdownUIP
        Private _startingTask As ITask
        Private WithEvents button1 As System.Windows.Forms.Button

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
            Me.button1 = New System.Windows.Forms.Button
            Me.SuspendLayout()
            ' 
            ' button1
            ' 
            Me.button1.Location = New System.Drawing.Point(64, 104)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(168, 24)
            Me.button1.TabIndex = 0
            Me.button1.Text = "Start Hosted Control Demo"
            ' 
            ' StartMeUp
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(292, 266)
            Me.Controls.Add(button1)
            Me.Name = "StartMeUp"
            Me.Text = "StartMeUp"
            Me.ResumeLayout(False)
        End Sub

#End Region

        Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
            UIPManager.RegisterShutdown(Me)
            Me.Visible = False
            _startingTask = New TestTask
			UIPManager.StartUserControlsTask("demo", _startingTask)
        End Sub


        Private Sub StartMeUp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        End Sub

        Private Sub StartMeUp_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        End Sub

        Public ReadOnly Property StartingTask() As ITask
            Get
                Return _startingTask
            End Get
        End Property

#Region "IShutdownUIP Members"

        Public Sub Shutdown() Implements IShutdownUIP.Shutdown
            Me.Visible = True
        End Sub

#End Region

    End Class

End Namespace