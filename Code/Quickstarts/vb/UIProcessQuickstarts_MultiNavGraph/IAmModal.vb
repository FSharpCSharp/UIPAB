 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' IAmModal.vb
'
' This file contains the implementations of the IAmModal class.
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
    ' This class is a modal view sample
    ' </summary>
   
   Public Class IAmModal
      Inherits WindowsFormView
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private label1 As System.Windows.Forms.Label
      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         InitializeComponent()
         AddHandler Me.Load, AddressOf IAmModal_Load
      End Sub 'New
      
      
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
            Me.groupBox1.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' groupBox1
            ' 
            Me.groupBox1.Controls.Add(Me.label1)
            Me.groupBox1.Location = New System.Drawing.Point(16, 16)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New System.Drawing.Size(392, 112)
            Me.groupBox1.TabIndex = 11
            Me.groupBox1.TabStop = False
            ' 
            ' label1
            ' 
            Me.label1.Location = New System.Drawing.Point(16, 24)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(368, 80)
            Me.label1.TabIndex = 1
            Me.label1.Text = "label1"
            ' 
            ' IAmModal
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(424, 197)
            Me.Controls.Add(groupBox1)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "IAmModal"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "IAmModal"
            Me.groupBox1.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub 'InitializeComponent 
#End Region


        Private Sub IAmModal_Load(ByVal sender As Object, ByVal e As EventArgs)
            label1.Text = "State passed from navB: " + Environment.NewLine + Environment.NewLine + CStr(Controller.State("previousNavState"))
        End Sub 'IAmModal_Load
    End Class 'IAmModal
End Namespace 'UIProcessQuickstarts_MultiNavGraph