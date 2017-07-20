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

Namespace InsuranceClientManagement.UI

    ' <summary>
    ' Class that provides information about a client
    ' </summary>
    <Serializable()> _
    Public Class Client
        Private Mname As String

        ' <summary>
        ' Client name
        ' </summary>
        Public Property Name() As String
            Get
                Return Mname
            End Get
            Set(ByVal Value As String)
                Mname = Value
            End Set
        End Property

        Private Maddress As String

        ' <summary>
        ' Client address
        ' </summary>
        Public Property Address() As String
            Get
                Return Maddress
            End Get
            Set(ByVal Value As String)
                Maddress = Value
            End Set
        End Property

        Private Mcountry As String

        ' <summary>
        ' Client country
        ' </summary>
        Public Property Country() As String
            Get
                Return Mcountry
            End Get
            Set(ByVal Value As String)
                Mcountry = Value
            End Set
        End Property

        Private MphoneNumber As String

        ' <summary>
        ' Client phone number
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
        ' Returns a string that summarizes the information about a client
        ' </summary>
        ' <returns></returns>
        Public Function GenerateSummary() As String
            Return String.Format("Name: {0} " + ControlChars.Lf + "Address: {1} " + ControlChars.Lf + "Country: {2} " + ControlChars.Lf + "Phone Number: {3}", Me.Name, Me.Address, Me.Country, Me.PhoneNumber)
        End Function

        Public Sub New()
        End Sub

    End Class

End Namespace