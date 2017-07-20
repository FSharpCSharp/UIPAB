 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' Form5.vb
'
' This file contains the implementations of the From5 class.
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


Namespace UIProcessQuickstarts_MultiNavGraph
    ' <summary>
    ' This class is a view sample
    ' </summary>
   
   Public Class Form5
      Inherits WindowsFormView
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private label1 As System.Windows.Forms.Label
      Private txtState As System.Windows.Forms.TextBox
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private WithEvents btnPrevious As System.Windows.Forms.Button
      Private WithEvents btnNext As System.Windows.Forms.Button
      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         InitializeComponent()
         AddHandler Me.Load, AddressOf Form5_Load
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

        ' <summary>
        ' Required method for Designer support - do not modify
        ' the contents of this method with the code editor.
        ' </summary>
        Private Sub InitializeComponent()
            Me.groupBox1 = New System.Windows.Forms.GroupBox
            Me.label1 = New System.Windows.Forms.Label
            Me.txtState = New System.Windows.Forms.TextBox
            Me.groupBox2 = New System.Windows.Forms.GroupBox
            Me.btnPrevious = New System.Windows.Forms.Button
            Me.btnNext = New System.Windows.Forms.Button
            Me.groupBox1.SuspendLayout()
            Me.groupBox2.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' groupBox1
            ' 
            Me.groupBox1.Controls.Add(Me.label1)
            Me.groupBox1.Controls.Add(Me.txtState)
            Me.groupBox1.Location = New System.Drawing.Point(16, 16)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New System.Drawing.Size(392, 112)
            Me.groupBox1.TabIndex = 10
            Me.groupBox1.TabStop = False
            ' 
            ' label1
            ' 
            Me.label1.Location = New System.Drawing.Point(24, 48)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(128, 16)
            Me.label1.TabIndex = 8
            Me.label1.Text = "Enter some state info:"
            ' 
            ' txtState
            ' 
            Me.txtState.Location = New System.Drawing.Point(152, 48)
            Me.txtState.Name = "txtState"
            Me.txtState.Size = New System.Drawing.Size(200, 20)
            Me.txtState.TabIndex = 7
            Me.txtState.Text = "Put Some State Here."
            ' 
            ' groupBox2
            ' 
            Me.groupBox2.Controls.Add(Me.btnPrevious)
            Me.groupBox2.Controls.Add(Me.btnNext)
            Me.groupBox2.Location = New System.Drawing.Point(16, 136)
            Me.groupBox2.Name = "groupBox2"
            Me.groupBox2.Size = New System.Drawing.Size(392, 48)
            Me.groupBox2.TabIndex = 12
            Me.groupBox2.TabStop = False
            ' 
            ' btnPrevious
            ' 
            Me.btnPrevious.Location = New System.Drawing.Point(184, 16)
            Me.btnPrevious.Name = "btnPrevious"
            Me.btnPrevious.Size = New System.Drawing.Size(96, 23)
            Me.btnPrevious.TabIndex = 6
            Me.btnPrevious.Text = "goto form4"
            ' 
            ' btnNext
            ' 
            Me.btnNext.Location = New System.Drawing.Point(288, 16)
            Me.btnNext.Name = "btnNext"
            Me.btnNext.Size = New System.Drawing.Size(96, 23)
            Me.btnNext.TabIndex = 5
            Me.btnNext.Text = "return to navA"
            ' 
            ' Form5
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(424, 197)
            Me.ControlBox = False
            Me.Controls.Add(groupBox2)
            Me.Controls.Add(groupBox1)
            Me.Name = "Form5"
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Form5, NavGraph B"
            Me.groupBox1.ResumeLayout(False)
            Me.groupBox2.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub 'InitializeComponent 
#End Region


        Private Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
            CType(Controller, DemoController2).Form5btnNext(txtState.Text)
            Close()
        End Sub 'btnNext_Click

        Private Sub btnPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
            CType(Controller, DemoController2).Form5btnPrevious()
        End Sub 'btnPrevious_Click


        Private Sub txtState_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            ' Store the entered info into our state
            If Not (Controller Is Nothing) Then
                Controller.State("someState") = txtState.Text
            End If
        End Sub 'txtState_TextChanged

        Private Sub Form5_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' Restore the textbox value with the value stored into the state
            txtState.Text = CStr(Controller.State("someState"))
        End Sub 'Form5_Load
    End Class 'Form5
End Namespace 'UIProcessQuickstarts_MultiNavGraph