 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' InsuranceClientManagementController.vb
'
' This file contains the implementations of the InsuranceClientManagementController class.
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

Namespace InsuranceClientManagement.UI

    ' <summary>
    ' Controller that performs functionality common to all views in the InsuranceClientManagement sample
    ' </summary>
    Public Class InsuranceClientManagementController
        Inherits ControllerBase

        Public Sub New(ByVal context As Navigator)
            MyBase.New(context)
        End Sub

        ' <summary>
        ' Navigates to the view that allows  for adding of client information
        ' </summary>
        Public Sub StartAddingClient()
            Me.Navigator.CurrentState.NavigateValue = "add"
            Navigate()
        End Sub

        ' <summary>
        ' Stores the client information in the state
        ' </summary>
        ' <param name="client"></param>
        Public Sub ExecuteAddClientRequest(ByVal client As Client)
            Navigator.CurrentState(Constants.Client) = client
            Me.Navigator.CurrentState.NavigateValue = "confirmation"
            Navigate()
        End Sub

        ' <summary>
        ' Stores the username in the state, basically used to simulate the authentication process
        ' </summary>
        ' <param name="username"></param>
        ' <param name="password"></param>
        Public Sub LogMeIn(ByVal username As String, ByVal password As String)
            ' don't actually do any authentication... just save the username in the state
            Me.Navigator.CurrentState(Constants.UserId) = username
            If Not (Me.State(Constants.AfterLoginNavigationValue) Is Nothing) Then
                Me.Navigator.CurrentState.NavigateValue = CStr(Me.State(Constants.AfterLoginNavigationValue))
                Me.State(Constants.AfterLoginNavigationValue) = Nothing
            Else
                Me.Navigator.CurrentState.NavigateValue = "welcome"
            End If
            Navigate()
        End Sub

		'<summary>
		'Determines whether a username/password pair represent a manager
		'</summary>
		Public Function IsManager(ByVal userName As String, ByVal password As String) As Boolean
			Return (userName.ToLower() = "manager" AndAlso password.ToLower() = "manager")
		End Function
		' <summary>
		' Navigate to the welcome view, simulates unauthenticated logon
		' </summary>
		Public Sub DoNotLogMeIn()
			Me.Navigator.CurrentState.NavigateValue = "welcome"
			Navigate()
		End Sub

		Public Sub ContinueManagement()
			Me.Navigator.CurrentState.NavigateValue = "welcome"
			Navigate()
		End Sub

		' <summary>
		' Navigate to the view that will throw an exception that will demonstrate the functionality of rich debug exceptions
		' </summary>
		Public Sub ThrowException()
			Me.Navigator.CurrentState.NavigateValue = "clientsearch"
			Navigate()
        End Sub
        ' <summary>
        ' Navigate to Help page, which is defined in SharedTransition.
        ' </summary>
        Public Sub ShowHelp()
            Me.Navigator.CurrentState.NavigateValue = "help"
            Navigate()
        End Sub


    End Class

End Namespace