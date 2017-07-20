 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' PersonController.vb
'
' This file contains the implementations of the PersonController class.
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
Imports Microsoft.ApplicationBlocks.UIProcess

Namespace Client

    ' <summary>
    ' Controller for the Person Control
    ' </summary>
    ' 
    Public NotInheritable Class PersonController
        Inherits PersonControllerBase
        Private Const HOMEADDRESS_TYPE As String = "home"
        Private Const WORKADDRESS_TYPE As String = "work"

#Region """Constructors"""


        Public Sub New(ByVal navigator As Navigator)
            MyBase.New(navigator)
        End Sub 'New


#End Region

        ' <summary>
        ' Method used to return a particular address for a person
        ' </summary>
        ' <param name="person">Person whose address to search for</param>
        ' <param name="addressType">Type of address (work,home)</param>
        ' <returns></returns>
        Private Function GetAddress(ByVal person As Client.EmployeeData.PersonRow, ByVal addressType As String) As Client.EmployeeData.AddressRow
            Dim address As EmployeeData.AddressRow = Nothing

            Dim row As EmployeeData.PersonAddressRow
            For Each row In person.GetPersonAddressRows()
                If row.Type.ToUpper() = addressType.ToUpper() Then
                    address = row.AddressRow
                    Exit For
                End If
            Next row

            Return address
        End Function

        ' <summary>
        ' Method used to add a subscriber that is interested in knowing about changes that occure to a person's
        ' address.
        ' </summary>
        ' <param name="notifier">Delegate that will be invoked when a change in an employee's address occurs</param>	
        Public Sub SubscribeForChangesToAddressInformation(ByVal notifier As Client.EmployeeData.AddressRowChangeEventHandler)
            AddHandler Me.EmployeeData.Address.AddressRowChanged, notifier
        End Sub

        ' <summary>
        ' Method used to add a subscriber that is interested in knowing about changes that occure to a person's
        ' phone information.
        ' </summary>
        ' <param name="notifier">Delegate that will be invoked when a change in an employee's phone number occurs</param>
        Public Sub SubscribeForChangesToPhoneInformation(ByVal notifier As Client.EmployeeData.PhoneRowChangeEventHandler)
            AddHandler Me.EmployeeData.Phone.PhoneRowChanged, notifier
        End Sub

        ' <summary>
        ' Method used to rollback changes made to information in the dataset
        ' </summary>
        Public Sub RejectChangesToEmployeeInformation()
            Me.EmployeeData.RejectChanges()
        End Sub

        ' <summary>
        ' Method used to save changes made to the information in the dataset
        ' </summary>
        Public Sub SaveChangesToEmployeeInformation()
			Me.EmployeeData.AcceptChanges()
			MakeFileWriteable(DataFile)
			Me.EmployeeData.WriteXml(DataFile)
        End Sub

		' <summary>
		' Method used to ensure the file we are saving the data to is able to
		' be written to
		' </summary>
		Private Sub MakeFileWriteable(ByVal fileName As String)
			Dim file As New System.IO.FileInfo(fileName)
			file.Attributes = IO.FileAttributes.Normal			
		End Sub
		' <summary>
		' Method used to retrieve a persons's work address
		' </summary>
		' <param name="person"></param>
		' <returns></returns>
		Public Function GetWorkAddressForPerson(ByVal person As Client.EmployeeData.PersonRow) As Client.EmployeeData.AddressRow
			Return GetAddress(person, WORKADDRESS_TYPE)
		End Function

		' <summary>
		' Method used to retrieve a person's home address
		' </summary>
		' <param name="person"></param>
		' <returns></returns>
		Public Function GetHomeAddressForPerson(ByVal person As Client.EmployeeData.PersonRow) As EmployeeData.AddressRow
			Return GetAddress(person, HOMEADDRESS_TYPE)
		End Function

		' <summary>
		' Method used to retrieve a person's phone number
		' </summary>
		' <param name="person"></param>
		' <returns></returns>
		Public Function GetPhoneNumberForPerson(ByVal person As Client.EmployeeData.PersonRow) As EmployeeData.PhoneRow
			Dim rows As EmployeeData.PhoneRow() = person.GetPhoneRows()
			Return rows(0)
		End Function

	End Class

End Namespace


