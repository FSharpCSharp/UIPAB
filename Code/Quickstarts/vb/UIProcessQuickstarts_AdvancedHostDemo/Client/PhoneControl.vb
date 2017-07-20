 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' PhoneControl.vb
'
' This file contains the implementations of the PhoneControl class.
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
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Namespace Client

    ' <summary>
    ' Summary description for PhoneControl.
    ' </summary>
    Public Class PhoneControl
        Inherits System.Windows.Forms.UserControl
        Private label1 As System.Windows.Forms.Label
        Private label2 As System.Windows.Forms.Label
        Private areaCodeTxt As System.Windows.Forms.TextBox
        Private phoneNumTxt As System.Windows.Forms.TextBox

        Private phone As EmployeeData.PhoneRow

        ' <summary> 
        ' Required designer variable.
        ' </summary>
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            ' This call is required by the Windows.Forms Form Designer.
            InitializeComponent()
            ' TODO: Add any initialization after the InitializeComponent call
        End Sub

        Public Sub RefreshData()
            If Not (phone Is Nothing) Then
                areaCodeTxt.DataBindings.Clear()
                areaCodeTxt.DataBindings.Add("Text", phone, "AreaCode")
                phoneNumTxt.DataBindings.Clear()
                phoneNumTxt.DataBindings.Add("Text", phone, "PhoneNumber")
            End If
        End Sub

        Public WriteOnly Property PhoneNumber() As EmployeeData.PhoneRow
            Set(ByVal value As EmployeeData.PhoneRow)
                phone = value
                If Not (phone Is Nothing) Then
                    RefreshData()
                End If
            End Set
        End Property

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

#Region "Component Designer generated code"

        ' <summary> 
        ' Required method for Designer support - do not modify 
        ' the contents of this method with the code editor.
        ' </summary>
        Private Sub InitializeComponent()
            Me.label1 = New System.Windows.Forms.Label
            Me.label2 = New System.Windows.Forms.Label
            Me.areaCodeTxt = New System.Windows.Forms.TextBox
            Me.phoneNumTxt = New System.Windows.Forms.TextBox
            Me.SuspendLayout()
            ' 
            ' label1
            ' 
            Me.label1.Location = New System.Drawing.Point(24, 24)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(64, 16)
            Me.label1.TabIndex = 0
            Me.label1.Text = "Area Code"
            ' 
            ' label2
            ' 
            Me.label2.Location = New System.Drawing.Point(24, 64)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(48, 16)
            Me.label2.TabIndex = 1
            Me.label2.Text = "Phone #"
            ' 
            ' areaCodeTxt
            ' 
            Me.areaCodeTxt.Location = New System.Drawing.Point(88, 24)
            Me.areaCodeTxt.MaxLength = 3
            Me.areaCodeTxt.Name = "areaCodeTxt"
            Me.areaCodeTxt.Size = New System.Drawing.Size(48, 20)
            Me.areaCodeTxt.TabIndex = 2
            Me.areaCodeTxt.Text = ""
            ' 
            ' phoneNumTxt
            ' 
            Me.phoneNumTxt.Location = New System.Drawing.Point(88, 64)
            Me.phoneNumTxt.MaxLength = 8
            Me.phoneNumTxt.Name = "phoneNumTxt"
            Me.phoneNumTxt.Size = New System.Drawing.Size(88, 20)
            Me.phoneNumTxt.TabIndex = 3
            Me.phoneNumTxt.Text = ""
            ' 
            ' PhoneControl
            ' 
            Me.Controls.Add(phoneNumTxt)
            Me.Controls.Add(areaCodeTxt)
            Me.Controls.Add(label2)
            Me.Controls.Add(label1)
            Me.Name = "PhoneControl"
            Me.Size = New System.Drawing.Size(216, 136)
            Me.ResumeLayout(False)
        End Sub

#End Region

    End Class

End Namespace