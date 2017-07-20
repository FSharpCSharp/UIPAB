 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' ClientInfo.vb
'
' This file contains the implementations of the ClientInfo class.
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

    Public Class ClientInfo
        Inherits WindowsFormView
        Implements IWizardViewTransition
        Private txtName As System.Windows.Forms.TextBox
        Private label1 As System.Windows.Forms.Label
        Private label2 As System.Windows.Forms.Label
        Private label3 As System.Windows.Forms.Label
        Private label4 As System.Windows.Forms.Label
        Private label5 As System.Windows.Forms.Label
        Private cboCountry As System.Windows.Forms.ComboBox
        Private label6 As System.Windows.Forms.Label
        Private txtEmailAddress As System.Windows.Forms.TextBox
        Private txtPhoneNumber As System.Windows.Forms.TextBox
        Private txtMailingAddress As System.Windows.Forms.TextBox

        Private components As System.ComponentModel.Container = Nothing
        Private dtpDateOfBirth As System.Windows.Forms.DateTimePicker
        Private errNotifier As System.Windows.Forms.ErrorProvider

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

#Region "Windows Form Designer generated code	"

        Private Sub InitializeComponent()
            Me.txtName = New System.Windows.Forms.TextBox
            Me.txtPhoneNumber = New System.Windows.Forms.TextBox
            Me.txtMailingAddress = New System.Windows.Forms.TextBox
            Me.label1 = New System.Windows.Forms.Label
            Me.label2 = New System.Windows.Forms.Label
            Me.label3 = New System.Windows.Forms.Label
            Me.label4 = New System.Windows.Forms.Label
            Me.dtpDateOfBirth = New System.Windows.Forms.DateTimePicker
            Me.label5 = New System.Windows.Forms.Label
            Me.cboCountry = New System.Windows.Forms.ComboBox
            Me.label6 = New System.Windows.Forms.Label
            Me.txtEmailAddress = New System.Windows.Forms.TextBox
            Me.errNotifier = New System.Windows.Forms.ErrorProvider
            Me.SuspendLayout()
            ' 
            ' txtName
            ' 
            Me.txtName.Location = New System.Drawing.Point(136, 24)
            Me.txtName.Name = "txtName"
            Me.txtName.Size = New System.Drawing.Size(216, 20)
            Me.txtName.TabIndex = 1
            Me.txtName.Text = ""
            ' 
            ' txtPhoneNumber
            ' 
            Me.txtPhoneNumber.Location = New System.Drawing.Point(136, 104)
            Me.txtPhoneNumber.Name = "txtPhoneNumber"
            Me.txtPhoneNumber.Size = New System.Drawing.Size(216, 20)
            Me.txtPhoneNumber.TabIndex = 5
            Me.txtPhoneNumber.Text = ""
            ' 
            ' txtMailingAddress
            ' 
            Me.txtMailingAddress.Location = New System.Drawing.Point(136, 184)
            Me.txtMailingAddress.Multiline = True
            Me.txtMailingAddress.Name = "txtMailingAddress"
            Me.txtMailingAddress.Size = New System.Drawing.Size(216, 88)
            Me.txtMailingAddress.TabIndex = 9
            Me.txtMailingAddress.Text = ""
            ' 
            ' label1
            ' 
            Me.label1.Location = New System.Drawing.Point(16, 24)
            Me.label1.Name = "label1"
            Me.label1.TabIndex = 0
            Me.label1.Text = "Name"
            ' 
            ' label2
            ' 
            Me.label2.Location = New System.Drawing.Point(16, 104)
            Me.label2.Name = "label2"
            Me.label2.TabIndex = 4
            Me.label2.Text = "Phone Number"
            ' 
            ' label3
            ' 
            Me.label3.Location = New System.Drawing.Point(16, 184)
            Me.label3.Name = "label3"
            Me.label3.TabIndex = 8
            Me.label3.Text = "Mailing Address"
            ' 
            ' label4
            ' 
            Me.label4.Location = New System.Drawing.Point(16, 64)
            Me.label4.Name = "label4"
            Me.label4.TabIndex = 2
            Me.label4.Text = "Date Of Birth"
            ' 
            ' dtpDateOfBirth
            ' 
            Me.dtpDateOfBirth.Location = New System.Drawing.Point(136, 64)
            Me.dtpDateOfBirth.Name = "dtpDateOfBirth"
            Me.dtpDateOfBirth.Size = New System.Drawing.Size(216, 20)
            Me.dtpDateOfBirth.TabIndex = 3
            ' 
            ' label5
            ' 
            Me.label5.Location = New System.Drawing.Point(16, 288)
            Me.label5.Name = "label5"
            Me.label5.TabIndex = 10
            Me.label5.Text = "Country"
            ' 
            ' cboCountry
            ' 
            Me.cboCountry.Items.AddRange(New Object() {"Canada", "United States", "Mexico"})
            Me.cboCountry.Location = New System.Drawing.Point(136, 288)
            Me.cboCountry.Name = "cboCountry"
            Me.cboCountry.Size = New System.Drawing.Size(216, 21)
            Me.cboCountry.TabIndex = 11
            ' 
            ' label6
            ' 
            Me.label6.Location = New System.Drawing.Point(16, 144)
            Me.label6.Name = "label6"
            Me.label6.TabIndex = 6
            Me.label6.Text = "Email Address"
            ' 
            ' txtEmailAddress
            ' 
            Me.txtEmailAddress.Location = New System.Drawing.Point(136, 144)
            Me.txtEmailAddress.Name = "txtEmailAddress"
            Me.txtEmailAddress.Size = New System.Drawing.Size(216, 20)
            Me.txtEmailAddress.TabIndex = 7
            Me.txtEmailAddress.Text = ""
            ' 
            ' errNotifier
            ' 
            Me.errNotifier.ContainerControl = Me
            ' 
            ' ClientInfo
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(376, 341)
            Me.Controls.Add(label6)
            Me.Controls.Add(txtEmailAddress)
            Me.Controls.Add(txtMailingAddress)
            Me.Controls.Add(txtPhoneNumber)
            Me.Controls.Add(txtName)
            Me.Controls.Add(cboCountry)
            Me.Controls.Add(label5)
            Me.Controls.Add(dtpDateOfBirth)
            Me.Controls.Add(label4)
            Me.Controls.Add(label3)
            Me.Controls.Add(label2)
            Me.Controls.Add(label1)
            Me.Name = "ClientInfo"
            Me.Text = "ClientInfo"
            Me.ResumeLayout(False)
        End Sub

#End Region

#Region "IWizardViewTransition Members"

        Public Function DoFinish() As Boolean Implements IWizardViewTransition.DoFinish
            Return False
        End Function

        Public Function DoCancel() As Boolean Implements IWizardViewTransition.DoCancel
            Return False
        End Function

        Public Function DoNext() As Boolean Implements IWizardViewTransition.DoNext
            Dim MDoNext As Boolean = False

            MDoNext = ClientInfoIsValid()

            If MDoNext Then
                SaveClientInformation()
            End If
            Return MDoNext
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

        Public Function DoBack() As Boolean Implements IWizardViewTransition.DoBack
            Return True
        End Function

        Public Sub WizardActivated() Implements IWizardViewTransition.WizardActivated
        End Sub

#End Region

        Private Sub SaveClientInformation()
            Dim client As New client

            client.Name = txtName.Text.Trim()
            client.PhoneNumber = txtPhoneNumber.Text.Trim()
            client.MailingAddress = txtMailingAddress.Text.Trim()
            client.EmailAddress = txtEmailAddress.Text.Trim()
            client.Country = cboCountry.Text.Trim()
            client.DateOfBirth = dtpDateOfBirth.Value

            MyController.Client = client
        End Sub

		Private Function ClientIsElegible() As Boolean
			Dim result As ValidationResult = MyController.IsClientElegible(dtpDateOfBirth.Value)
			errNotifier.SetError(dtpDateOfBirth, result.ErrorMessage)
			Return result.IsValid
		End Function

		Private Function ClientInfoIsValid() As Boolean
			Dim validator As New FormValidator.ControlValidator(AddressOf FormValidator.HasTextValidator)

			Return FormValidator.FieldIsValid(Me.errNotifier, Me.txtName, "Please enter a valid name", validator) And _
			FormValidator.FieldIsValid(Me.errNotifier, Me.txtMailingAddress, "Please enter your address.", validator) And _
			FormValidator.FieldIsValid(Me.errNotifier, Me.txtEmailAddress, "Please enter your email address.", validator) And _
			FormValidator.FieldIsValid(Me.errNotifier, Me.txtPhoneNumber, "Please enter your phone number.", validator) And _
			ClientIsElegible()
		End Function

		Private ReadOnly Property MyController() As InsurancePurchaseController
			Get
				Return CType(Controller, InsurancePurchaseController)
			End Get
		End Property

	End Class

End Namespace