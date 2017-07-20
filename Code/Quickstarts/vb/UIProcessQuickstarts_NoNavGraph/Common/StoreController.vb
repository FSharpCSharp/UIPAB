 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' StoreController.vb
'
' This file contains the implementations of the StoreController class.
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
Imports System.Resources
Imports System.Reflection
Imports UIProcessQuickstarts_Store
Imports Microsoft.ApplicationBlocks.UIProcess

Namespace UIProcessQuickstarts_Store

    ' <summary>
    ' The controller used by the store application
    ' </summary>
    Public Class StoreController
        Inherits ControllerBase

#Region "Declares variables"

        Private Const STATE_EXCEPTION As String = "Exception"
        Private Const STATE_CART As String = "CartDS"
        Private Shared ResourceManager As New ResourceManager("StoreText", [Assembly].GetAssembly(GetType(StoreController)))

#End Region

#Region "Constructor"

        Public Sub New(ByVal navigator As Navigator)
            MyBase.New(navigator)
        End Sub

#End Region

        Private Property Cart() As CartDS
            Get
                Dim cartDS As cartDS = CType(State(STATE_CART), cartDS)
                If cartDS Is Nothing Then
                    cartDS = New cartDS
                    State(STATE_CART) = cartDS
                End If

                Return cartDS
            End Get
            Set(ByVal Value As CartDS)
                State(STATE_CART) = Value
            End Set
        End Property

#Region "Static helper methods"

        '/ <summary>
        '/ Gets the task related to the specified user
        '/ </summary>
        '/ <param name="userName"></param>
        '/ <returns></returns>
        Public Shared Function GetUserTaskId(ByVal userName As String) As Guid
            '  Look up TaskID in APPLICATION DATABASE;
            '  Remember, correlating logon or other information with UIP's TaskID is
            '  the responsibility of the consuming application
            Dim taskId As Guid = Guid.Empty

            'Gets user task
            Dim cartBO As New CartTaskBusinessObject
            taskId = cartBO.GetTask(userName)

            Return taskId
        End Function

        '/ <summary>
        '/ Checks if the specified user name and password are valid
        '/ </summary>
        '/ <param name="userName">User name</param>
        '/ <param name="password"></param>
        '/ <returns></returns>
        Public Shared Function IsUserValid(ByVal userName As String, ByVal password As String) As Boolean
            Try
                'Lookup user in database
                Dim customerBO As New CustomerBusinessObject
                Dim customerId As Integer = customerBO.Logon(userName, password)

                If customerId <> 0 Then
                    Return True 'The user is valid
                Else
                    Return False 'The user isnt valid
                End If
            Catch
                Throw
            End Try
        End Function

#End Region

#Region "Instance helper methods"

        '/ <summary>
        '/ Gets the last exception
        '/ </summary>
        Public Function GetLastError() As Exception
            Return CType(State(STATE_EXCEPTION), Exception)
        End Function

#End Region

#Region "Navigation methods"

        '/ <summary>
        '/ Navigates to the fail view
        '/ </summary>
        Public Sub BrowseFail()
            Me.State.NavigateValue = "error"
            Navigate()
        End Sub

        '/ <summary>
        '/ Clears all existing errors
        '/ </summary>
        Public Sub ClearError()
            Me.State.NavigateValue = "cart"
            Navigate()
        End Sub

        '/ <summary>
        '/ Adds a product to the customer cart
        '/ </summary>
        Public Sub AddToCart(ByVal productId As Integer, ByVal quantity As Integer)
            If Me.State Is Nothing Then
                Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionStateRequired"))
            End If
            Try
                Dim cartBO As New CartBusinessObject
                cartBO.AddToCart(CType(Cart.CartItems, CartDS.CartItemsDataTable), productId, quantity)

                Me.State.NavigateValue = "cart"
            Catch e As Exception
                State(STATE_EXCEPTION) = e
                State.NavigateValue = "error"
            End Try

            Navigate()
        End Sub

        '/ <summary>
        '/ Creates a new order
        '/ </summary>
        Public Sub CheckoutOrder()
            If Me.State Is Nothing Then
                Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionStateRequired"))
            End If
            Try
                Dim cartBO As New CartTaskBusinessObject
                Dim customerId As Integer = cartBO.GetCustomerFromTask(State.TaskId)

                Dim orderBO As New OrderBusinessObject
                orderBO.CreateOrderFromCart(customerId, Cart.CartItems)

                State.NavigateValue = "checkout"
            Catch e As Exception
                State(STATE_EXCEPTION) = e
                State.NavigateValue = "error"
            End Try

            Navigate()
        End Sub

        '/ <summary>
        '/ Resumes the shopping task
        '/ </summary>
        Public Sub ResumeShopping()
            '  proceed to next View
            State.NavigateValue = "browsecatalog"
            Navigate()
        End Sub

        '/ <summary>
        '/ Quits the current task and stores the state
        '/ </summary>
        Public Sub StopShopping()
            '  proceed to next View
            State.NavigateValue = "cart"
            Navigate()
        End Sub

        Public Sub StartNewShoppingSession()
            State.Clear()
            State.NavigateValue = "cart"
            Navigate()
        End Sub

        '/ <summary>
        '/ Used to execute the checkout operation
        '/ </summary>
        '/ <param name="name"></param>
        '/ <param name="addr"></param>
        '/ <param name="ccnum"></param>
        Public Sub CompleteCheckout(ByVal name As String, ByVal addr As String, ByVal ccnum As String)
            '  do some checkout stuff

            If "1111-1111-1111-1111" <> ccnum Then
                State.NavigateValue = "checkout"
            Else
                'resets the state
                Cart.CartItems.Clear()

                State.NavigateValue = "congratulations"
            End If

            Navigate()
        End Sub

        '/ <summary>
        '/ Gets all products in the catalog
        '/ </summary>
        Public Function GetCatalogProducts() As ProductDS
            Dim MproductDS As New ProductDS
            Try
                Dim MproductBO As New ProductBusinessObject
                MproductBO.GetAllProducts(MproductDS, 0, 0)
            Catch e As Exception
                State(STATE_EXCEPTION) = e
                State.NavigateValue = "error"
                Navigate()
            End Try

            Return MproductDS
        End Function

        '/ <summary>
        '/ Gets customer cart
        '/ </summary>
        Public Function GetCart() As CartDS
            If Me.State Is Nothing Then
                Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionStateRequired"))
            End If
            Try
                Return Cart
            Catch e As Exception
                State(STATE_EXCEPTION) = e
                State.NavigateValue = "error"
                Navigate()
            End Try

            Return Nothing
        End Function

        '/ <summary>
        '/ Gets the customer info
        '/ </summary>
        '/ <param name="logon">customer logon</param>
        '/ <returns>customer info</returns>
        Public Function GetCustomerByLogon(ByVal logon As String) As CustomerDS.Customer
            Dim bo As New CustomerBusinessObject
            Return bo.GetCustomerByLogon(logon).Customers(0)
        End Function

#End Region

    End Class

End Namespace