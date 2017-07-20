 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' HomeInfo.vb
'
' This file contains the implementations of the HomeInfo class.
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

    ' <summary>
    ' Summary description for HomeInfo.
    ' </summary>
    Public Class HomeInfo
        Inherits WindowsFormView
        Implements IWizardViewTransition
        Private label1 As System.Windows.Forms.Label
        Private label3 As System.Windows.Forms.Label
        Private label4 As System.Windows.Forms.Label
        Private label5 As System.Windows.Forms.Label
        Private txtHomeStreetAddress As System.Windows.Forms.TextBox
        Private txtHomeFloorSpace As System.Windows.Forms.TextBox
        Private dtpHomeBuildDate As System.Windows.Forms.DateTimePicker

        Private errNotifier As System.Windows.Forms.ErrorProvider
        Private cboHomeType As System.Windows.Forms.ComboBox

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
            Me.txtHomeStreetAddress = New System.Windows.Forms.TextBox
            Me.txtHomeFloorSpace = New System.Windows.Forms.TextBox
            Me.label1 = New System.Windows.Forms.Label
            Me.label3 = New System.Windows.Forms.Label
            Me.label4 = New System.Windows.Forms.Label
            Me.label5 = New System.Windows.Forms.Label
            Me.cboHomeType = New System.Windows.Forms.ComboBox
            Me.dtpHomeBuildDate = New System.Windows.Forms.DateTimePicker
            Me.errNotifier = New System.Windows.Forms.ErrorProvider
            Me.SuspendLayout()
            ' 
            ' txtHomeStreetAddress
            ' 
            Me.txtHomeStreetAddress.Location = New System.Drawing.Point(136, 144)
            Me.txtHomeStreetAddress.Multiline = True
            Me.txtHomeStreetAddress.Name = "txtHomeStreetAddress"
            Me.txtHomeStreetAddress.Size = New System.Drawing.Size(208, 80)
            Me.txtHomeStreetAddress.TabIndex = 7
            Me.txtHomeStreetAddress.Text = ""
            ' 
            ' txtHomeFloorSpace
            ' 
            Me.txtHomeFloorSpace.Location = New System.Drawing.Point(136, 104)
            Me.txtHomeFloorSpace.Name = "txtHomeFloorSpace"
            Me.txtHomeFloorSpace.Size = New System.Drawing.Size(208, 20)
            Me.txtHomeFloorSpace.TabIndex = 5
            Me.txtHomeFloorSpace.Text = ""
            ' 
            ' label1
            ' 
            Me.label1.Location = New System.Drawing.Point(16, 152)
            Me.label1.Name = "label1"
            Me.label1.TabIndex = 6
            Me.label1.Text = "Street Address"
            ' 
            ' label3
            ' 
            Me.label3.Location = New System.Drawing.Point(16, 24)
            Me.label3.Name = "label3"
            Me.label3.TabIndex = 0
            Me.label3.Text = "Home Type"
            ' 
            ' label4
            ' 
            Me.label4.Location = New System.Drawing.Point(16, 64)
            Me.label4.Name = "label4"
            Me.label4.TabIndex = 2
            Me.label4.Text = "Date Built"
            ' 
            ' label5
            ' 
            Me.label5.Location = New System.Drawing.Point(16, 104)
            Me.label5.Name = "label5"
            Me.label5.TabIndex = 4
            Me.label5.Text = "Floor Space (sqft)"
            ' 
            ' cboHomeType
            ' 
            Me.cboHomeType.Items.AddRange(New Object() {"Duplex", "Townhouse", "Condo"})
            Me.cboHomeType.Location = New System.Drawing.Point(136, 24)
            Me.cboHomeType.Name = "cboHomeType"
            Me.cboHomeType.Size = New System.Drawing.Size(208, 21)
            Me.cboHomeType.TabIndex = 1
            ' 
            ' dtpHomeBuildDate
            ' 
            Me.dtpHomeBuildDate.CustomFormat = "MM/yyyy"
            Me.dtpHomeBuildDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpHomeBuildDate.Location = New System.Drawing.Point(136, 64)
            Me.dtpHomeBuildDate.Name = "dtpHomeBuildDate"
            Me.dtpHomeBuildDate.Size = New System.Drawing.Size(208, 20)
            Me.dtpHomeBuildDate.TabIndex = 3
            Me.dtpHomeBuildDate.Value = New System.DateTime(2004, 1, 20, 14, 42, 22, 75)
            ' 
            ' errNotifier
            ' 
            Me.errNotifier.ContainerControl = Me
            ' 
            ' HomeInfo
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(392, 261)
            Me.Controls.Add(cboHomeType)
            Me.Controls.Add(dtpHomeBuildDate)
            Me.Controls.Add(label5)
            Me.Controls.Add(label4)
            Me.Controls.Add(label3)
            Me.Controls.Add(label1)
            Me.Controls.Add(txtHomeFloorSpace)
            Me.Controls.Add(txtHomeStreetAddress)
            Me.Name = "HomeInfo"
            Me.Text = "HomeInfo"
            Me.ResumeLayout(False)
        End Sub
#End Region

#Region "IWizardViewTransition Members"

        Public Function DoFinish() As Boolean Implements IWizardViewTransition.DoFinish
            Return True
        End Function

        Public Function DoCancel() As Boolean Implements IWizardViewTransition.DoCancel
            Return True
        End Function

        Public Function DoNext() As Boolean Implements IWizardViewTransition.DoNext
            Dim isValid As Boolean = HomeInfoIsValid()
            If isValid Then
                SaveInsurancePurchaseInfo()
            End If
            Return isValid
        End Function

        Public Function DoBack() As Boolean Implements IWizardViewTransition.DoBack
            Return True
        End Function

        Public ReadOnly Property SupportsCancel() As Boolean Implements IWizardViewTransition.SupportsCancel
            Get
                Return True
            End Get
        End Property

        Public ReadOnly Property SupportsFinish() As Boolean Implements IWizardViewTransition.SupportsFinish
            Get
                Return True
            End Get
        End Property

        Public Sub WizardActivated() Implements IWizardViewTransition.WizardActivated
        End Sub

#End Region

        ' <summary>
        ' Method that performs validation against the fields on the form
        ' </summary>
        ' <returns>True if all of the controls contain valid information</returns>
        Private Function HomeInfoIsValid() As Boolean
            Dim validator As New FormValidator.ControlValidator(AddressOf FormValidator.HasTextValidator)
            Return FormValidator.FieldIsValid(Me.errNotifier, Me.txtHomeFloorSpace, "Please enter a valid number", validator) And FormValidator.FieldIsValid(Me.errNotifier, Me.txtHomeStreetAddress, "Please enter the Street Address of the Home to be insured", validator) And FormValidator.FieldIsValid(Me.errNotifier, Me.cboHomeType, "Please select a home type", validator) And HomeBuiltDateIsValid()
        End Function

        ' <summary>
        ' Method that returns whether the date the house was built is valid
        ' </summary>
        ' <returns></returns>
		Private Function HomeBuiltDateIsValid() As Boolean
			Dim result As ValidationResult = MyController.IsHomeBuildDateValid(dtpHomeBuildDate.Value)
			errNotifier.SetError(dtpHomeBuildDate, result.ErrorMessage)
			Return result.IsValid
		End Function

		' <summary>
		' Method used to hook up textboxes on the screen to customer keypress event handlers
		' </summary>
		Private Sub HookupKeyPressHandlers()
			AddHandler Me.txtHomeFloorSpace.KeyPress, AddressOf KeyPressHandlers.NumericKeyPress
		End Sub

		' <summary>
		' Method used to store the information about the home purchase
		' </summary>
		Private Sub SaveInsurancePurchaseInfo()
			MyController.CreateNewHomeInsurancePurchase()
			Dim purchaseInfo As HomePurchaseInfo = CType(MyController.PurchaseInfo, HomePurchaseInfo)
			purchaseInfo.DateBuilt = dtpHomeBuildDate.Value
			purchaseInfo.FloorSpace = Convert.ToDecimal(txtHomeFloorSpace.Text.Trim(), CultureInfo.CurrentUICulture)
			purchaseInfo.HomeType = cboHomeType.Text.Trim()
			purchaseInfo.StreetAddress = txtHomeStreetAddress.Text.Trim()
		End Sub

		Private ReadOnly Property MyController() As InsurancePurchaseController
			Get
				Return CType(Controller, InsurancePurchaseController)
			End Get
		End Property

	End Class

End Namespace