 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' InsurancePurchaseController.vb
'
' This file contains the implementations of the InsurancePurchaseController class.
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
Imports System.Text
Imports Microsoft.ApplicationBlocks.UIProcess

Namespace InsurancePurchaseWizard.UI

    ' <summary>
    ' Controller object that services all requests from various views in the InsurancePurchase Quickstart
    ' </summary>
    Public Class InsurancePurchaseController
        Inherits ControllerBase

        Public Sub New(ByVal navigator As Navigator)
            MyBase.New(navigator)
        End Sub

        ' <summary>
        ' Navigates to the view that collects car information
        ' </summary>
        Public Sub PurchaseCarInsurance()
            Me.Navigator.CurrentState.NavigateValue = "car"
        End Sub

        ' <summary>
        ' Navigates to the view that collects home information
        ' </summary>
        Public Sub PurchaseHomeInsurance()
            Me.Navigator.CurrentState.NavigateValue = "home"
        End Sub

        ' <summary>
        ' Returns a client object that is currently stored in the state for the wizard
        ' </summary>
        Public Property Client() As Client
            Get
                Return CType(Me.Navigator.CurrentState("client"), Client)
            End Get
            Set(ByVal Value As Client)
                Me.Navigator.CurrentState("client") = Value
            End Set
        End Property

        ' <summary>
        ' Creates a new HomePurchaseInfo object and stores it in the state
        ' </summary>
        Public Sub CreateNewHomeInsurancePurchase()
            Me.Navigator.CurrentState("info") = New HomePurchaseInfo
        End Sub

        ' <summary>
        ' Creates a new CarPurchaseInfo object and stores it in the state
        ' </summary>
        Public Sub CreateNewCarInsurancePurchase()
            Me.Navigator.CurrentState("info") = New CarPurchaseInfo
        End Sub

        ' <summary>
        ' Returns an object that allows the client to get information about
        ' the insurance purchase
        ' </summary>
        Public ReadOnly Property PurchaseInfo() As IInsuranceInfo
            Get
                Return CType(Me.Navigator.CurrentState("info"), IInsuranceInfo)
            End Get
        End Property

        ' <summary>
        ' Returns a string that summarizes the insurance information
        ' collected by the wizard
        ' </summary>
        ' <returns></returns>
        Public Function GetPurchaseSummary() As String
            Dim summary As New System.Text.StringBuilder

            summary.Append(IIf(Client Is Nothing, "", Client.GetSummary()))
            summary.Append(IIf(PurchaseInfo Is Nothing, "", PurchaseInfo.GetInsuranceInfo()))

            Return summary.ToString()
		End Function


#Region "Validation Methods"
		Public Function IsHomeBuildDateValid(ByVal dateBuilt As DateTime)
			Dim isValid As Boolean = False
			Dim errorMessage As String = ""

			If (dateBuilt >= DateTime.Today) Then
				errorMessage = "The date built must be in the past."
			Else
				isValid = True
			End If

			Return New ValidationResult(isValid, errorMessage)
		End Function

		Public Function IsClientElegible(ByVal birthDate As DateTime)
			Dim isValid As Boolean = False
			Dim errorMessage As String = ""

			If (birthDate > DateTime.Today.AddYears(-18)) Then
				errorMessage = "You must be over 18 years of age."
			Else
				isValid = True
			End If

			Return New ValidationResult(isValid, errorMessage)
		End Function

#End Region

	End Class

End Namespace