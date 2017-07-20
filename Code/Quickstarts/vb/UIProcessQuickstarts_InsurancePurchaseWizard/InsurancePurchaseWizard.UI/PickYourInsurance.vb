 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' PickYouInsurance.vb
'
' This file contains the implementations of the PickYourInsurance class.
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
    ' Summary description for PickYourInsurance.
    ' </summary>
    Public Class PickYourInsurance
        Inherits WindowsFormView
        Implements IWizardViewTransition
        Private label1 As System.Windows.Forms.Label
        Private radCar As System.Windows.Forms.RadioButton
        Private radHome As System.Windows.Forms.RadioButton

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
            Me.radCar = New System.Windows.Forms.RadioButton
            Me.radHome = New System.Windows.Forms.RadioButton
            Me.label1 = New System.Windows.Forms.Label
            Me.SuspendLayout()
            ' 
            ' radCar
            ' 
            Me.radCar.Checked = True
            Me.radCar.Location = New System.Drawing.Point(32, 96)
            Me.radCar.Name = "radCar"
            Me.radCar.TabIndex = 1
            Me.radCar.TabStop = True
            Me.radCar.Text = "Car"
            ' 
            ' radHome
            ' 
            Me.radHome.Location = New System.Drawing.Point(32, 144)
            Me.radHome.Name = "radHome"
            Me.radHome.TabIndex = 2
            Me.radHome.Text = "Home"
            ' 
            ' label1
            ' 
            Me.label1.Location = New System.Drawing.Point(40, 40)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(136, 23)
            Me.label1.TabIndex = 0
            Me.label1.Text = "Choose Your Insurance:"
            ' 
            ' PickYourInsurance
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(248, 229)
            Me.Controls.Add(label1)
            Me.Controls.Add(radHome)
            Me.Controls.Add(radCar)
            Me.Name = "PickYourInsurance"
            Me.Text = "PickYourInsurance"
            Me.ResumeLayout(False)
        End Sub
#End Region

#Region "IWizardViewTransition Members"

        Public Function DoFinish() As Boolean Implements IWizardViewTransition.DoFinish
            ' TODO:  Add PickYourInsurance.DoFinish implementation
            Return False
        End Function

        Public Function DoCancel() As Boolean Implements IWizardViewTransition.DoCancel
            ' TODO:  Add PickYourInsurance.DoCancel implementation
            Return False
        End Function

        Public Function DoNext() As Boolean Implements IWizardViewTransition.DoNext
            ' A custom check is performed to determine which path of the wizard the user
            ' should go down, a method is called on the controller that will change the state
            ' navigate value to the equivalent view that should be activated
            If radHome.Checked Then
                MyController.PurchaseHomeInsurance()
            Else
                MyController.PurchaseCarInsurance()
            End If
            Return True
        End Function

        Public Function DoBack() As Boolean Implements IWizardViewTransition.DoBack
            Return True
        End Function

        Public ReadOnly Property SupportsCancel() As Boolean Implements IWizardViewTransition.SupportsCancel
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property SupportsFinish() As Boolean Implements IWizardViewTransition.SupportsFinish
            Get
                Return False
            End Get
        End Property


        Public Sub WizardActivated() Implements IWizardViewTransition.WizardActivated
        End Sub

#End Region

#Region """UIP Plumbing"""

        Private ReadOnly Property MyController() As InsurancePurchaseController
            Get
                Return CType(Controller, InsurancePurchaseController)
            End Get
        End Property
#End Region

    End Class

End Namespace