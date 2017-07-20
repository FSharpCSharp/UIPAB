 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' Authorization.vb
'
' This file contains the implementations of the Authorization class.
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
    ' Class that ensures that only authorized users are allowed access to certain views in the application. This class
    ' demonstrates the ability for components to be able to alter the flow of navigation based on custom business rules/
    ' requirements
    ' </summary>
    Public Class Authorization

        ' <summary>
        ' Property that returns an instance of the authorization object, implemented using the sigleton pattern
        ' </summary>
        Public Shared INSTANCE As New Authorization

        Public Sub Init()
        End Sub

        Private Sub New()
            ' add a handler for the NavigateEvent of the UIPManager class
            AddHandler UIPManager.NavigateEvent, AddressOf UIPManager_NavigateEvent
        End Sub

        ' <summary>
        ' Method that gets called whenever a navigation is about to occur in UIP, this is where the custom logic is placed to 
        ' ensure that a user is allowed access to a particular view.
        ' </summary>
        ' <param name="sender"></param>
        ' <param name="e"></param>
        Private Sub UIPManager_NavigateEvent(ByVal sender As Object, ByVal e As NavigateEventArgs)
            Dim nextView As String = UIPConfiguration.Config.GetNextViewSettings(e.State.NavigationGraph, e.State.CurrentView, e.State.NavigateValue).Name

            'ensure that the user is allowed to access the view they are trying to get to
            If Not UserIsAllowed(CStr(e.State(Constants.UserId)), e.State.NavigateValue, CStr(e.State(Constants.AfterLoginNavigationValue))) Then
                ' redirect the user back to the logon page.
                e.State("error") = "You must be logged in to access this functionality"
                e.State("afterlogin") = e.State.NavigateValue
                e.State.NavigateValue = "login"
            End If
        End Sub

        Private Function UserIsAllowed(ByVal username As String, ByVal navigateValue As String, ByVal afterLoginNavigationValue As String) As Boolean
            ' if user is defined then they can go anywhere
            If Not (username Is Nothing) Then
                Return True
            End If ' otherwise, they can not go to the add screen
            Return navigateValue <> "add" AndAlso afterLoginNavigationValue <> "add"
        End Function

    End Class

End Namespace