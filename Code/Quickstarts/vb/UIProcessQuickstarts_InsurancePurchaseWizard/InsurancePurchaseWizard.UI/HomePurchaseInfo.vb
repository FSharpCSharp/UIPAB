 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' HomePurchaseInfo.vb
'
' This file contains the implementations of the HomePurchaseInfo class.
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

Namespace InsurancePurchaseWizard.UI

    ' <summary>
    ' Class that provides information about a house
    ' </summary>
    <Serializable()> _
    Public Class HomePurchaseInfo
        Implements IInsuranceInfo
        Private MhomeType As String
        Private MstreetAddress As String
        Private MdateBuilt As DateTime
        Private MfloorSpace As Decimal

        Public Sub New()
        End Sub

        ' <summary>
        ' Amount of floorspace in the home
        ' </summary>
        Public Property FloorSpace() As Decimal
            Get
                Return MfloorSpace
            End Get
            Set(ByVal Value As Decimal)
                MfloorSpace = Value
            End Set
        End Property

        ' <summary>
        ' Date the house was built
        ' </summary>
        Public Property DateBuilt() As DateTime
            Get
                Return MdateBuilt
            End Get
            Set(ByVal Value As DateTime)
                MdateBuilt = Value
            End Set
        End Property

        ' <summary>
        ' Street address
        ' </summary>
        Public Property StreetAddress() As String
            Get
                Return MstreetAddress
            End Get
            Set(ByVal Value As String)
                MstreetAddress = Value
            End Set
        End Property

        ' <summary>
        ' Type of home
        ' </summary>
        Public Property HomeType() As String
            Get
                Return MhomeType
            End Get
            Set(ByVal Value As String)
                MhomeType = Value
            End Set
        End Property

        ' <summary>
        ' Returns insurance information about the house
        ' </summary>
        ' <returns></returns>
        Public Function GetInsuranceInfo() As String Implements IInsuranceInfo.GetInsuranceInfo
            Return String.Format("Home Type: {0} " + ControlChars.Lf + "Street Address: {1} " + ControlChars.Lf + "Floor Space (sqft.): {2} " + ControlChars.Lf + "Month-Year Built: {3} " + ControlChars.Lf, Me.HomeType, Me.StreetAddress, Me.FloorSpace, Me.DateBuilt.ToString(CultureInfo.CurrentUICulture.DateTimeFormat.YearMonthPattern))
        End Function

    End Class

End Namespace
