 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' Welcome.vb
'
' This file contains the implementations of the Welcome class.
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

Namespace InsurancePurchaseWizard.UI

    ' <summary>
    ' Summary description for Welcome.
    ' </summary>
    Public Class Welcome
        Inherits System.Windows.Forms.Form
        Private label1 As System.Windows.Forms.Label
        Private WithEvents btnCarAndHome As System.Windows.Forms.Button
        Private WithEvents btnCars As System.Windows.Forms.Button
        Private WithEvents btnHome As System.Windows.Forms.Button

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
        Private Sub InitializeComponent()
            Me.label1 = New System.Windows.Forms.Label
            Me.btnCarAndHome = New System.Windows.Forms.Button
            Me.btnCars = New System.Windows.Forms.Button
            Me.btnHome = New System.Windows.Forms.Button
            Me.SuspendLayout()
            ' 
            ' label1
            ' 
            Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, System.Byte))
            Me.label1.Location = New System.Drawing.Point(40, 24)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(208, 80)
            Me.label1.TabIndex = 0
            Me.label1.Text = "Welcome to the Insurance Purchase System"
            ' 
            ' btnCarAndHome
            ' 
            Me.btnCarAndHome.Location = New System.Drawing.Point(56, 128)
            Me.btnCarAndHome.Name = "btnCarAndHome"
            Me.btnCarAndHome.Size = New System.Drawing.Size(168, 23)
            Me.btnCarAndHome.TabIndex = 1
            Me.btnCarAndHome.Text = "Car && Home Insurance"
            ' 
            ' btnCars
            ' 
            Me.btnCars.Location = New System.Drawing.Point(56, 168)
            Me.btnCars.Name = "btnCars"
            Me.btnCars.Size = New System.Drawing.Size(168, 23)
            Me.btnCars.TabIndex = 2
            Me.btnCars.Text = "Car Insurance"
            ' 
            ' btnHome
            ' 
            Me.btnHome.Location = New System.Drawing.Point(56, 208)
            Me.btnHome.Name = "btnHome"
            Me.btnHome.Size = New System.Drawing.Size(168, 23)
            Me.btnHome.TabIndex = 3
            Me.btnHome.Text = "Home Insurance"
            ' 
            ' Welcome
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(292, 273)
            Me.Controls.Add(btnHome)
            Me.Controls.Add(btnCars)
            Me.Controls.Add(btnCarAndHome)
            Me.Controls.Add(label1)
            Me.Name = "Welcome"
            Me.Text = "Welcome"
            Me.ResumeLayout(False)
        End Sub

#End Region

        Private Sub btnCarAndHome_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCarAndHome.Click
            UIPManager.StartNavigationTask("InsurancePurchaseWizard")
        End Sub

        Private Sub btnCars_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCars.Click
            UIPManager.StartNavigationTask("CarWizard")
        End Sub

        Private Sub btnHome_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHome.Click
            UIPManager.StartNavigationTask("HomeWizard")
        End Sub

    End Class

End Namespace