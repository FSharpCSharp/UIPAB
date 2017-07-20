 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' CarPurchaseInfo.vb
'
' This file contains the implementations of the CarPurchaseInfo class.
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

Namespace InsurancePurchaseWizard.UI

    ' <summary>
    ' Class that provides information about a car
    ' </summary>
    <Serializable()> _
    Public Class CarPurchaseInfo
        Implements IInsuranceInfo
        Private Mmake As String
        Private Mmodel As String
        Private Myear As Integer
        Private Mcolor As String

        Public Sub New()
        End Sub

        ' <summary>
        ' Color of the car
        ' </summary>
        Public Property Color() As String
            Get
                Return Mcolor
            End Get
            Set(ByVal Value As String)
                Mcolor = Value
            End Set
        End Property

        ' <summary>
        ' Year the car was made
        ' </summary>
        Public Property Year() As Integer
            Get
                Return Myear
            End Get
            Set(ByVal Value As Integer)
                Myear = Value
            End Set
        End Property

        ' <summary>
        ' Model of the car
        ' </summary>
        Public Property Model() As String
            Get
                Return Mmodel
            End Get
            Set(ByVal Value As String)
                Mmodel = Value
            End Set
        End Property

        ' <summary>
        ' Make of car
        ' </summary>
        Public Property Make() As String
            Get
                Return Mmake
            End Get
            Set(ByVal Value As String)
                Mmake = Value
            End Set
        End Property

        ' <summary>
        ' Returns insurance information related to a car
        ' </summary>
        ' <returns></returns>
        Public Function GetInsuranceInfo() As String Implements IInsuranceInfo.GetInsuranceInfo
            Return String.Format("Make: {0} " + ControlChars.Lf + "Model: {1} " + ControlChars.Lf + "Year: {2} " + ControlChars.Lf + "Color: {3} " + ControlChars.Lf, Me.Make, Me.Model, Me.Year, Me.Color)
        End Function

    End Class

End Namespace
