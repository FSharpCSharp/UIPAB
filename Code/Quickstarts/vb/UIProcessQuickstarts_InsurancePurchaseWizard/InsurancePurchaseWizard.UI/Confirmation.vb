 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' Confirmation.vb
'
' This file contains the implementations of the Confirmation class.
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

    Public Class Confirmation
        Inherits WindowsFormView
        Implements IWizardViewTransition
        Private label1 As System.Windows.Forms.Label

        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            MyBase.New()
            InitializeComponent()
        End Sub

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
            Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, System.Byte))
            Me.label1.Location = New System.Drawing.Point(8, 8)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(280, 256)
            Me.label1.TabIndex = 0
            Me.label1.Text = "Confirmation"
            Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' Confirmation
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(292, 273)
            Me.Controls.Add(label1)
            Me.Name = "Confirmation"
            Me.Text = "Confirmation"
            Me.ResumeLayout(False)
        End Sub
#End Region

#Region "IWizardViewTransition Members"

        Public Function DoFinish() As Boolean Implements IWizardViewTransition.DoFinish
            Return True
        End Function

        Public Function DoCancel() As Boolean Implements IWizardViewTransition.DoCancel
            ' TODO:  Add Confirmation.DoCancel implementation
            Return False
        End Function

        Public Function DoNext() As Boolean Implements IWizardViewTransition.DoNext
            ' TODO:  Add Confirmation.DoNext implementation
            Return False
        End Function

        Public ReadOnly Property SupportsFinish() As Boolean Implements IWizardViewTransition.SupportsFinish
            Get
                Return True
            End Get
        End Property

        Public ReadOnly Property SupportsCancel() As Boolean Implements IWizardViewTransition.SupportsCancel
            Get
                ' TODO:  Add Confirmation.SupportsCancel getter implementation
                Return False
            End Get
        End Property

        Public Sub WizardActivated() Implements IWizardViewTransition.WizardActivated
            Dim summary As String = CType(Controller, InsurancePurchaseController).GetPurchaseSummary()
            Me.label1.Text = summary
        End Sub

        Public Function DoBack() As Boolean Implements IWizardViewTransition.DoBack
            Return True
        End Function

#End Region

    End Class

End Namespace