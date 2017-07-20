 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' storehelp.vb
'
' This file contains the implementations of the storehelp class.
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


Namespace UIProcessQuickstarts_Store.WinUI
    ' <summary>
    ' Summary description for storehelp.
    ' </summary>
   
   Public Class storehelp
      Inherits WindowsFormView
      Private label1 As System.Windows.Forms.Label
        ' <summary>
        ' Required designer variable.
        ' </summary>
      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()
      End Sub 'New
       
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
        End Sub 'Dispose

#Region "Windows Form Designer generated code"

        '/ <summary>
        '/ Required method for Designer support - do not modify
        '/ the contents of this method with the code editor.
        '/ </summary>
        Private Sub InitializeComponent()
            Me.label1 = New System.Windows.Forms.Label
            Me.SuspendLayout()
            ' 
            ' label1
            ' 
            Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, System.Byte))
            Me.label1.Location = New System.Drawing.Point(8, 8)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(280, 104)
            Me.label1.TabIndex = 0
            Me.label1.Text = "This is the help for the store application. Currently this view is set up as a sh" + "ared transition at the global level, so that it is accessible from any navigatio" + "n graph."
            ' 
            ' storehelp
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(292, 117)
            Me.Controls.Add(label1)
            Me.Name = "storehelp"
            Me.Text = "Store Sample Help"
            Me.ResumeLayout(False)
        End Sub 'InitializeComponent 
#End Region

#Region "UIPManager Plumbing"

        Private ReadOnly Property StoreControllerHostedControl() As StoreControllerHostedControl
            Get
                Return CType(Me.Controller, StoreControllerHostedControl)
            End Get
        End Property
#End Region
    End Class 'storehelp
End Namespace 'UIProcessQuickstarts_Store.WinUI