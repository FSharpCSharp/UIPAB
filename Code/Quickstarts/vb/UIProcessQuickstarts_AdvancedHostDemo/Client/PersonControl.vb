 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' PersonControl.vb
'
' This file contains the implementations of the PersonControl class.
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
Imports Microsoft.ApplicationBlocks.UIProcess

Namespace Client

    ' <summary>
    ' Control that encapsulates displaying/modifying data about a client
    ' </summary>
    Public Class PersonControl
        Inherits WindowsFormControlView
        Private tabControl1 As System.Windows.Forms.TabControl
        Private InfoTab As System.Windows.Forms.TabPage
        Private AddressTab As System.Windows.Forms.TabPage
        Private PhoneTab As System.Windows.Forms.TabPage

        Private objPerson As EmployeeData.PersonRow
        Private label1 As System.Windows.Forms.Label
        Private label2 As System.Windows.Forms.Label
        Private FirstName As System.Windows.Forms.TextBox
        Private LastName As System.Windows.Forms.TextBox
        Private WorkAddress As Client.AddressControl
        Private HomeAddress As Client.AddressControl
        Private Phone As Client.PhoneControl

        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            ' This call is required by the Windows.Forms Form Designer.
			InitializeComponent()
			Enable(False)
        End Sub

        ' <summary>
        ' Method to enable/disable the control and its nested controls
        ' </summary>
        ' <param name="enabled"></param>
        Public Overrides Sub Enable(ByVal enabled As Boolean)
            label1.Enabled = enabled
            label2.Enabled = enabled
            FirstName.Enabled = enabled
            LastName.Enabled = enabled
            WorkAddress.Enabled = enabled
            HomeAddress.Enabled = enabled
            Phone.Enabled = enabled
        End Sub

        ' <summary>
        ' Property that exposes the person that is currently being viewed in the control
        ' </summary>
        Public Property Person() As EmployeeData.PersonRow
            Get
                Return objPerson
            End Get
            Set(ByVal value As EmployeeData.PersonRow)
                objPerson = value
                If Not (objPerson Is Nothing) Then
                    RefreshData()
                    ProcessAddressInformation()
                    ProcessPhoneInformation()
                End If
            End Set
        End Property

        ' <summary>
        ' Method used to load the address information for a person
        ' </summary>
        Private Sub ProcessAddressInformation()
            WorkAddress.Address = MyController.GetWorkAddressForPerson(Person)
            HomeAddress.Address = MyController.GetHomeAddressForPerson(Person)
        End Sub

        ' <summary>
        ' Method used to load the phone information for a person
        ' </summary>
        Private Sub ProcessPhoneInformation()
            Phone.PhoneNumber = MyController.GetPhoneNumberForPerson(Person)
        End Sub

        ' <summary>
        ' Refreshes the contents of the controls that are bound to a particular person
        ' </summary>
        Public Sub RefreshData()
            If Not (Person Is Nothing) Then
                FirstName.DataBindings.Clear()
                FirstName.DataBindings.Add("Text", Person, "FirstName")

                LastName.DataBindings.Clear()
                LastName.DataBindings.Add("Text", Person, "LastName")
                WorkAddress.RefreshData()
                HomeAddress.RefreshData()
                Phone.RefreshData()
            End If
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

#Region "Component Designer generated code"

        ' <summary>
        ' Required method for Designer support - do not modify
        ' the contents of this method with the code editor.
        ' </summary>
        Private Sub InitializeComponent()
            Me.tabControl1 = New System.Windows.Forms.TabControl
            Me.InfoTab = New System.Windows.Forms.TabPage
            Me.LastName = New System.Windows.Forms.TextBox
            Me.FirstName = New System.Windows.Forms.TextBox
            Me.label2 = New System.Windows.Forms.Label
            Me.label1 = New System.Windows.Forms.Label
            Me.AddressTab = New System.Windows.Forms.TabPage
            Me.HomeAddress = New Client.AddressControl
            Me.WorkAddress = New Client.AddressControl
            Me.PhoneTab = New System.Windows.Forms.TabPage
            Me.Phone = New Client.PhoneControl
            Me.tabControl1.SuspendLayout()
            Me.InfoTab.SuspendLayout()
            Me.AddressTab.SuspendLayout()
            Me.PhoneTab.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' tabControl1
            ' 
            Me.tabControl1.Controls.Add(Me.InfoTab)
            Me.tabControl1.Controls.Add(Me.AddressTab)
            Me.tabControl1.Controls.Add(Me.PhoneTab)
            Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tabControl1.Location = New System.Drawing.Point(0, 0)
            Me.tabControl1.Name = "tabControl1"
            Me.tabControl1.SelectedIndex = 0
            Me.tabControl1.Size = New System.Drawing.Size(632, 360)
            Me.tabControl1.TabIndex = 0
            ' 
            ' InfoTab
            ' 
            Me.InfoTab.Controls.Add(Me.LastName)
            Me.InfoTab.Controls.Add(Me.FirstName)
            Me.InfoTab.Controls.Add(Me.label2)
            Me.InfoTab.Controls.Add(Me.label1)
            Me.InfoTab.Location = New System.Drawing.Point(4, 22)
            Me.InfoTab.Name = "InfoTab"
            Me.InfoTab.Size = New System.Drawing.Size(624, 334)
            Me.InfoTab.TabIndex = 0
            Me.InfoTab.Text = "Info"
            ' 
            ' LastName
            ' 
            Me.LastName.Location = New System.Drawing.Point(144, 56)
            Me.LastName.Name = "LastName"
            Me.LastName.TabIndex = 3
            Me.LastName.Text = ""
            ' 
            ' FirstName
            ' 
            Me.FirstName.Location = New System.Drawing.Point(144, 24)
            Me.FirstName.Name = "FirstName"
            Me.FirstName.TabIndex = 2
            Me.FirstName.Text = ""
            ' 
            ' label2
            ' 
            Me.label2.Location = New System.Drawing.Point(16, 56)
            Me.label2.Name = "label2"
            Me.label2.TabIndex = 1
            Me.label2.Text = "Last Name"
            ' 
            ' label1
            ' 
            Me.label1.Location = New System.Drawing.Point(16, 24)
            Me.label1.Name = "label1"
            Me.label1.TabIndex = 0
            Me.label1.Text = "First Name"
            ' 
            ' AddressTab
            ' 
            Me.AddressTab.Controls.Add(Me.HomeAddress)
            Me.AddressTab.Controls.Add(Me.WorkAddress)
            Me.AddressTab.Location = New System.Drawing.Point(4, 22)
            Me.AddressTab.Name = "AddressTab"
            Me.AddressTab.Size = New System.Drawing.Size(624, 334)
            Me.AddressTab.TabIndex = 1
            Me.AddressTab.Text = "Addresses"
            ' 
            ' HomeAddress
            ' 
            Me.HomeAddress.Address = Nothing
            Me.HomeAddress.Location = New System.Drawing.Point(256, 8)
            Me.HomeAddress.Name = "HomeAddress"
            Me.HomeAddress.Size = New System.Drawing.Size(248, 200)
            Me.HomeAddress.TabIndex = 1
            Me.HomeAddress.Title = "Home Address"
            ' 
            ' WorkAddress
            ' 
            Me.WorkAddress.Address = Nothing
            Me.WorkAddress.Location = New System.Drawing.Point(8, 8)
            Me.WorkAddress.Name = "WorkAddress"
            Me.WorkAddress.Size = New System.Drawing.Size(240, 200)
            Me.WorkAddress.TabIndex = 0
            Me.WorkAddress.Title = "Work Address"
            ' 
            ' PhoneTab
            ' 
            Me.PhoneTab.Controls.Add(Me.Phone)
            Me.PhoneTab.Location = New System.Drawing.Point(4, 22)
            Me.PhoneTab.Name = "PhoneTab"
            Me.PhoneTab.Size = New System.Drawing.Size(624, 334)
            Me.PhoneTab.TabIndex = 2
            Me.PhoneTab.Text = "Phone Number"
            ' 
            ' Phone
            ' 
            Me.Phone.Location = New System.Drawing.Point(8, 8)
            Me.Phone.Name = "Phone"
            Me.Phone.Size = New System.Drawing.Size(216, 136)
            Me.Phone.TabIndex = 0
            ' 
            ' PersonControl
            ' 
            Me.Controls.Add(tabControl1)
            Me.Name = "PersonControl"
            Me.Size = New System.Drawing.Size(632, 360)
            Me.tabControl1.ResumeLayout(False)
            Me.InfoTab.ResumeLayout(False)
            Me.AddressTab.ResumeLayout(False)
            Me.PhoneTab.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub 'InitializeComponent 
#End Region

		Public Overrides Sub Initialize(ByVal args As TaskArgumentsHolder, ByVal settings As ViewSettings)
			' subscribe to be notified for the changes that we are interested in
			AddHandler MyController.SelectedPersonChanged, AddressOf MyController_SelectedPersonChanged
			MyController.SubscribeForChangesToAddressInformation(New Client.EmployeeData.AddressRowChangeEventHandler(AddressOf Address_AddressRowChanged))
			MyController.SubscribeForChangesToPeople(New Client.EmployeeData.PersonRowChangeEventHandler(AddressOf Person_PersonRowChanged))
			MyController.SubscribeForChangesToPhoneInformation(New Client.EmployeeData.PhoneRowChangeEventHandler(AddressOf Phone_PhoneRowChanged))

			' monitor when the validating address events fires off so we can implement our own custom address validation
			AddHandler Me.WorkAddress.ValidatingAddress, AddressOf WorkAddress_ValidatingAddress
			AddHandler Me.HomeAddress.ValidatingAddress, AddressOf HomeAddress_ValidatingAddress

			Me.Enable(False)
		End Sub

#Region "UIP Plumbing"

		Private ReadOnly Property MyController() As PersonController
			Get
				Return DirectCast(Controller, PersonController)
			End Get
		End Property
#End Region

#Region "Change Notification handlers"

		Private Sub MyController_SelectedPersonChanged(ByVal sender As Object, ByVal e As PersonChangedEventArgs)
			Person = e.Person
		End Sub

		Private Sub Person_PersonRowChanged(ByVal sender As Object, ByVal e As Client.EmployeeData.PersonRowChangeEvent)
			RefreshData()
		End Sub

		Private Sub Address_AddressRowChanged(ByVal sender As Object, ByVal e As Client.EmployeeData.AddressRowChangeEvent)
			RefreshData()
		End Sub

		Private Sub Phone_PhoneRowChanged(ByVal sender As Object, ByVal e As Client.EmployeeData.PhoneRowChangeEvent)
			RefreshData()
		End Sub

#End Region

#Region "Address validating event handlers"

		Private Sub WorkAddress_ValidatingAddress(ByVal sender As Object, ByVal e As AddressValidatingEventArgs)
			' do some simple field validation, if there was more complex validation to be done we could
			' offload this work to the controller that could call some domain object to do some validation for us
			If WorkAddress.Address.Street.Trim().Length = 0 Then
				e.AddressIsValid = False
				e.ErrorMessage = "Please enter a valid work address"
			Else
				e.AddressIsValid = True
			End If
		End Sub

		Private Sub HomeAddress_ValidatingAddress(ByVal sender As Object, ByVal e As AddressValidatingEventArgs)
			' do some simple field validation, if there was more complex validation to be done we could
			' offload this work to the controller that could call some domain object to do some validation for us
			If HomeAddress.Address.Street.Trim().Length = 0 Then
				e.AddressIsValid = False
				e.ErrorMessage = "Please enter a valid home address"
			Else
				e.AddressIsValid = True
			End If
		End Sub

#End Region

	End Class

End Namespace