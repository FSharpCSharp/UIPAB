 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' Address.vb
'
' This file contains the implementations of the Address class.
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
    ' Control that encapsulates capturing and displaying information about an address
    ' </summary>

    Public Class AddressControl
        Inherits System.Windows.Forms.UserControl
        Private streetLabel As System.Windows.Forms.Label
        Private cityLabel As System.Windows.Forms.Label
        Private stateLabel As System.Windows.Forms.Label
        Private zipLabel As System.Windows.Forms.Label
        Private street As System.Windows.Forms.TextBox
        Private city As System.Windows.Forms.TextBox
        Private state As System.Windows.Forms.TextBox
        Private zip As System.Windows.Forms.TextBox
        Private WithEvents ValidateButton As System.Windows.Forms.Button
        Private WithEvents mTitle As System.Windows.Forms.Label
        Private mAddress As EmployeeData.AddressRow
        Private errInvalid As System.Windows.Forms.ErrorProvider


        Delegate Sub ValidateAddressHandler(ByVal sender As Object, ByVal e As AddressValidatingEventArgs)
        Public Event ValidatingAddress As ValidateAddressHandler

        ' <summary> 
        ' Required designer variable.
        ' </summary>
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            ' This call is required by the Windows.Forms Form Designer.
            InitializeComponent()
        End Sub

        Private Sub OnValidatingAddress(ByVal e As AddressValidatingEventArgs)
            If Not (ValidatingAddressEvent Is Nothing) Then
                RaiseEvent ValidatingAddress(Me, e)
                errInvalid.SetError(Me.ValidateButton, e.ErrorMessage)
            End If
        End Sub

        ' <summary>
        ' Refreshes the contents of the controls that are bound to a particular address
        ' </summary>
        Public Sub RefreshData()
            errInvalid.SetError(Me.ValidateButton, "")
            If Not (Address Is Nothing) Then
                street.DataBindings.Clear()
                street.DataBindings.Add("Text", Address, "Street")
                city.DataBindings.Clear()
                city.DataBindings.Add("Text", Address, "City")
                state.DataBindings.Clear()
                state.DataBindings.Add("Text", Address, "State")
                zip.DataBindings.Clear()
                zip.DataBindings.Add("Text", Address, "Zip")
            End If
        End Sub

        Public ReadOnly Property AddressIsValid() As Boolean
            Get
                Dim e As New AddressValidatingEventArgs
                OnValidatingAddress(e)
                Return e.AddressIsValid
            End Get
        End Property

        ' <summary>
        ' Property to set the address that the control should display/modify
        ' </summary>
        Public Property Address() As EmployeeData.AddressRow
            Get
                Return mAddress
            End Get
            Set(ByVal value As EmployeeData.AddressRow)
                mAddress = value
                If Not (Address Is Nothing) Then
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
            Me.streetLabel = New System.Windows.Forms.Label
            Me.cityLabel = New System.Windows.Forms.Label
            Me.stateLabel = New System.Windows.Forms.Label
            Me.zipLabel = New System.Windows.Forms.Label
            Me.street = New System.Windows.Forms.TextBox
            Me.city = New System.Windows.Forms.TextBox
            Me.state = New System.Windows.Forms.TextBox
            Me.zip = New System.Windows.Forms.TextBox
            Me.ValidateButton = New System.Windows.Forms.Button
            Me.mTitle = New System.Windows.Forms.Label
            Me.errInvalid = New System.Windows.Forms.ErrorProvider
            Me.SuspendLayout()
            '
            'streetLabel
            '
            Me.streetLabel.Location = New System.Drawing.Point(24, 48)
            Me.streetLabel.Name = "streetLabel"
            Me.streetLabel.Size = New System.Drawing.Size(72, 23)
            Me.streetLabel.TabIndex = 0
            Me.streetLabel.Text = "Street"
            '
            'cityLabel
            '
            Me.cityLabel.Location = New System.Drawing.Point(24, 72)
            Me.cityLabel.Name = "cityLabel"
            Me.cityLabel.Size = New System.Drawing.Size(80, 23)
            Me.cityLabel.TabIndex = 1
            Me.cityLabel.Text = "City"
            '
            'stateLabel
            '
            Me.stateLabel.Location = New System.Drawing.Point(24, 104)
            Me.stateLabel.Name = "stateLabel"
            Me.stateLabel.Size = New System.Drawing.Size(80, 23)
            Me.stateLabel.TabIndex = 2
            Me.stateLabel.Text = "State/Province"
            '
            'zipLabel
            '
            Me.zipLabel.Location = New System.Drawing.Point(24, 136)
            Me.zipLabel.Name = "zipLabel"
            Me.zipLabel.Size = New System.Drawing.Size(80, 23)
            Me.zipLabel.TabIndex = 3
            Me.zipLabel.Text = "Zip/Post Code"
            '
            'street
            '
            Me.street.Location = New System.Drawing.Point(128, 48)
            Me.street.Name = "street"
            Me.street.TabIndex = 4
            Me.street.Text = ""
            '
            'city
            '
            Me.city.Location = New System.Drawing.Point(128, 72)
            Me.city.Name = "city"
            Me.city.TabIndex = 5
            Me.city.Text = ""
            '
            'state
            '
            Me.state.Location = New System.Drawing.Point(128, 104)
            Me.state.Name = "state"
            Me.state.TabIndex = 6
            Me.state.Text = ""
            '
            'zip
            '
            Me.zip.Location = New System.Drawing.Point(128, 136)
            Me.zip.Name = "zip"
            Me.zip.TabIndex = 7
            Me.zip.Text = ""
            '
            'ValidateButton
            '
            Me.ValidateButton.Location = New System.Drawing.Point(128, 168)
            Me.ValidateButton.Name = "ValidateButton"
            Me.ValidateButton.TabIndex = 8
            Me.ValidateButton.Text = "Validate"
            '
            'Mtitle
            '
            Me.mTitle.Location = New System.Drawing.Point(64, 16)
            Me.mTitle.Name = "Mtitle"
            Me.mTitle.TabIndex = 0
            Me.mTitle.Text = "Title"
            Me.mTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'errInvalid
            '
            Me.errInvalid.ContainerControl = Me
            '
            'AddressControl
            '
            Me.Controls.Add(Me.mTitle)
            Me.Controls.Add(Me.ValidateButton)
            Me.Controls.Add(Me.zip)
            Me.Controls.Add(Me.state)
            Me.Controls.Add(Me.city)
            Me.Controls.Add(Me.street)
            Me.Controls.Add(Me.zipLabel)
            Me.Controls.Add(Me.stateLabel)
            Me.Controls.Add(Me.cityLabel)
            Me.Controls.Add(Me.streetLabel)
            Me.Name = "AddressControl"
            Me.Size = New System.Drawing.Size(256, 200)
            Me.ResumeLayout(False)

        End Sub

#End Region


        Private Sub ValidateButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ValidateButton.Click
            ValidateAddress()
        End Sub

        Private Sub ValidateAddress()
            OnValidatingAddress(New AddressValidatingEventArgs)
        End Sub

        ' <summary>
        ' Title that will be displayed at the top of the control
        ' </summary>
        Public Property Title() As String
            Get
                Return mTitle.Text
            End Get
            Set(ByVal value As String)
                mTitle.Text = value
            End Set
        End Property

    End Class

    Public Class AddressValidatingEventArgs
        Inherits EventArgs
        Private Const DEFAULT_ERROR_MESSAGE As String = "Please enter a valid address"
        Private isValid As Boolean
        Private mErrorMessage As String

        Public Sub New()
            isValid = False
            mErrorMessage = DEFAULT_ERROR_MESSAGE
        End Sub

        Public Property AddressIsValid() As Boolean
            Get
                Return isValid
            End Get
            Set(ByVal value As Boolean)
                isValid = value
            End Set
        End Property

        Public Property ErrorMessage() As String
            Get
                If Not isValid Then
                    If Not IsValidErrorMessage Then
                        mErrorMessage = DEFAULT_ERROR_MESSAGE
                    End If
                Else
                    mErrorMessage = ""
                End If
                Return mErrorMessage
            End Get
            Set(ByVal value As String)
                mErrorMessage = value
            End Set
        End Property

        Private ReadOnly Property IsValidErrorMessage() As Boolean
            Get
                Return Not (mErrorMessage Is Nothing) AndAlso mErrorMessage.Trim().Length > 0
            End Get
        End Property
    End Class

End Namespace