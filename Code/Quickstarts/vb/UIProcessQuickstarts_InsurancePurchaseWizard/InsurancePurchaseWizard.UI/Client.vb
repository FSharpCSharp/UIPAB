 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' Client.vb
'
' This file contains the implementations of the Client class.
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
Imports System.Globalization
Imports System.Text

Namespace InsurancePurchaseWizard.UI

    ' <summary>
    '	Class used to collect information about a client
    ' </summary>
    <Serializable()> _
    Public Class Client
        Private MdateOfBirth As DateTime
        Private Mname As String
        Private MphoneNumber As String
        Private MemailAddress As String
        Private MmailingAddress As String
        Private Mcountry As String

        ' <summary>
        ' Client's name
        ' </summary>
        Public Property Name() As String
            Get
                Return Mname
            End Get
            Set(ByVal Value As String)
                Mname = Value
            End Set
        End Property

        ' <summary>
        ' Client's birthday
        ' </summary>
        Public Property DateOfBirth() As DateTime
            Get
                Return MdateOfBirth
            End Get
            Set(ByVal Value As DateTime)
                MdateOfBirth = Value
            End Set
        End Property

        ' <summary>
        ' Client's phone number
        ' </summary>
        Public Property PhoneNumber() As String
            Get
                Return MphoneNumber
            End Get
            Set(ByVal Value As String)
                MphoneNumber = Value
            End Set
        End Property

        ' <summary>
        ' Client's email address
        ' </summary>
        Public Property EmailAddress() As String
            Get
                Return MemailAddress
            End Get
            Set(ByVal Value As String)
                MemailAddress = Value
            End Set
        End Property

        ' <summary>
        ' Client's mailing address
        ' </summary>
        Public Property MailingAddress() As String
            Get
                Return MmailingAddress
            End Get
            Set(ByVal Value As String)
                MmailingAddress = Value
            End Set
        End Property

        ' <summary>
        ' Client's country of residence
        ' </summary>
        Public Property Country() As String
            Get
                Return Mcountry
            End Get
            Set(ByVal Value As String)
                Mcountry = Value
            End Set
        End Property

        ' <summary>
        ' Get's a string that returns a summary of the client information
        ' </summary>
        ' <returns></returns>
        Public Function GetSummary() As String
            Return String.Format("Name: {0} " + ControlChars.Lf + "Date of Birth: {1} " + ControlChars.Lf + "e-mail address: {2} " + ControlChars.Lf + "Mailing Address: {3} " + ControlChars.Lf + "Country: {4} " + ControlChars.Lf, Me.Name, Me.DateOfBirth.ToString(CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern), Me.EmailAddress, Me.MailingAddress, Me.Country)
        End Function

    End Class

End Namespace
