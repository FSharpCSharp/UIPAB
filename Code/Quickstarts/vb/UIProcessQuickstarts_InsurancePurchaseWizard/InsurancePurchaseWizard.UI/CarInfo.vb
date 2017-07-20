 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' CarInfo.vb
'
' This file contains the implementations of the CarInfo class.
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
Imports System.Globalization
Imports System.Windows.Forms
Imports Microsoft.ApplicationBlocks.UIProcess

Namespace InsurancePurchaseWizard.UI

    Public Class CarInfo
        Inherits WindowsFormView
        Implements IWizardViewTransition
        Private label1 As System.Windows.Forms.Label
        Private label2 As System.Windows.Forms.Label
        Private label3 As System.Windows.Forms.Label
        Private label4 As System.Windows.Forms.Label
        Private txtCarMake As System.Windows.Forms.TextBox
        Private txtCarYear As System.Windows.Forms.TextBox
        Private txtCarModel As System.Windows.Forms.TextBox
        Private txtCarColor As System.Windows.Forms.TextBox
        Private errNotifier As System.Windows.Forms.ErrorProvider



        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            MyBase.New()
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()

            HookupKeyPressHandlers()
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
            Me.label2 = New System.Windows.Forms.Label
            Me.label3 = New System.Windows.Forms.Label
            Me.label4 = New System.Windows.Forms.Label
            Me.txtCarMake = New System.Windows.Forms.TextBox
            Me.txtCarColor = New System.Windows.Forms.TextBox
            Me.txtCarYear = New System.Windows.Forms.TextBox
            Me.txtCarModel = New System.Windows.Forms.TextBox
            Me.errNotifier = New System.Windows.Forms.ErrorProvider
            Me.SuspendLayout()
            ' 
            ' label1
            ' 
            Me.label1.Location = New System.Drawing.Point(32, 24)
            Me.label1.Name = "label1"
            Me.label1.TabIndex = 0
            Me.label1.Text = "Make"
            ' 
            ' label2
            ' 
            Me.label2.Location = New System.Drawing.Point(32, 64)
            Me.label2.Name = "label2"
            Me.label2.TabIndex = 2
            Me.label2.Text = "Model"
            ' 
            ' label3
            ' 
            Me.label3.Location = New System.Drawing.Point(32, 104)
            Me.label3.Name = "label3"
            Me.label3.TabIndex = 4
            Me.label3.Text = "Year"
            ' 
            ' label4
            ' 
            Me.label4.Location = New System.Drawing.Point(32, 144)
            Me.label4.Name = "label4"
            Me.label4.TabIndex = 6
            Me.label4.Text = "Color"
            ' 
            ' txtCarMake
            ' 
            Me.txtCarMake.Location = New System.Drawing.Point(152, 24)
            Me.txtCarMake.Name = "txtCarMake"
            Me.txtCarMake.TabIndex = 1
            Me.txtCarMake.Text = ""
            ' 
            ' txtCarColor
            ' 
            Me.txtCarColor.Location = New System.Drawing.Point(152, 144)
            Me.txtCarColor.Name = "txtCarColor"
            Me.txtCarColor.TabIndex = 7
            Me.txtCarColor.Text = ""
            ' 
            ' txtCarYear
            ' 
            Me.txtCarYear.Location = New System.Drawing.Point(152, 104)
            Me.txtCarYear.Name = "txtCarYear"
            Me.txtCarYear.TabIndex = 5
            Me.txtCarYear.Text = ""
            ' 
            ' txtCarModel
            ' 
            Me.txtCarModel.Location = New System.Drawing.Point(152, 64)
            Me.txtCarModel.Name = "txtCarModel"
            Me.txtCarModel.TabIndex = 3
            Me.txtCarModel.Text = ""
            ' 
            ' errNotifier
            ' 
            Me.errNotifier.ContainerControl = Me
            ' 
            ' CarInfo
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(304, 213)
            Me.Controls.Add(txtCarModel)
            Me.Controls.Add(txtCarYear)
            Me.Controls.Add(txtCarColor)
            Me.Controls.Add(txtCarMake)
            Me.Controls.Add(label4)
            Me.Controls.Add(label3)
            Me.Controls.Add(label2)
            Me.Controls.Add(label1)
            Me.Name = "CarInfo"
            Me.Text = "CarInfo"
            Me.ResumeLayout(False)
        End Sub
#End Region

#Region "IWizardViewTransition Members"

        Public Function DoFinish() As Boolean Implements IWizardViewTransition.DoFinish
            ' TODO:  Add CarInfo.DoFinish implementation
            Return False
        End Function

        Public Function DoCancel() As Boolean Implements IWizardViewTransition.DoCancel
            ' TODO:  Add CarInfo.DoCancel implementation
            Return False
        End Function

        Public Function DoNext() As Boolean Implements IWizardViewTransition.DoNext
            Dim isValid As Boolean = CarInfoIsValid()
            If isValid Then
                SaveInsurancePurchaseInfo()
            End If
            Return isValid
        End Function

        Public Function DoBack() As Boolean Implements IWizardViewTransition.DoBack
            ' TODO:  Add CarInfo.DoBack implementation
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

        Private Sub HookupKeyPressHandlers()
            AddHandler Me.txtCarYear.KeyPress, AddressOf KeyPressHandlers.NumericKeyPress
        End Sub

        Public Function CarInfoIsValid() As Boolean
            Dim validator As New FormValidator.ControlValidator(AddressOf FormValidator.HasTextValidator)

			Return FormValidator.FieldIsValid(Me.errNotifier, txtCarColor, "You must enter a color", validator) And _
		 FormValidator.FieldIsValid(Me.errNotifier, txtCarMake, "You must enter a make", validator) And _
		 FormValidator.FieldIsValid(Me.errNotifier, txtCarModel, "You must enter a model", validator) And _
		 FormValidator.FieldIsValid(Me.errNotifier, txtCarYear, "You must enter a year", validator)
        End Function

        Private Sub SaveInsurancePurchaseInfo()
            MyController.CreateNewCarInsurancePurchase()
            Dim purchaseInfo As CarPurchaseInfo = CType(MyController.PurchaseInfo, CarPurchaseInfo)
            purchaseInfo.Color = txtCarColor.Text.Trim()
            purchaseInfo.Make = txtCarMake.Text.Trim()
            purchaseInfo.Model = txtCarModel.Text.Trim()
            purchaseInfo.Year = Convert.ToInt32(txtCarYear.Text.Trim(), CultureInfo.CurrentUICulture)
        End Sub

        Private ReadOnly Property MyController() As InsurancePurchaseController
            Get
                Return CType(Controller, InsurancePurchaseController)
            End Get
        End Property
    End Class

End Namespace