'===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' Help.vb
'
' This file contains the implementations of the Help class.
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
    Public Class Help
        Inherits Microsoft.ApplicationBlocks.UIProcess.WindowsFormView

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Private Sub InitializeComponent()
            Me.Label1 = New System.Windows.Forms.Label
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(32, 32)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(464, 32)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "This is a Help Form for  InsuranceClientManagerment (View defined as Shared Trans" & _
            "iton)"
            '
            'Help
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(504, 77)
            Me.Controls.Add(Me.Label1)
            Me.Name = "Help"
            Me.Text = "Help"
            Me.ResumeLayout(False)

        End Sub

#End Region

    End Class
End Namespace