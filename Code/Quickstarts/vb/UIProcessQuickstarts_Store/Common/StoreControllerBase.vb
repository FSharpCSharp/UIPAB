 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' StoreControllerBase.vb
'
' This file contains the implementations of the StoreContollerBase class.
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
   
   Public Class StoreControllerBase
      Inherits ControllerBase
      #Region "Declares variables"
      Protected Const STATE_EXCEPTION As String = "Exception"
      Protected Const STATE_CART As String = "CartDS"
        Protected Shared ResourceManager As New ResourceManager("StoreText", [Assembly].GetAssembly(GetType(StoreControllerBase)))
      #End Region
      
      #Region "Constructor"
      
      Public Sub New(navigator As Navigator)
         MyBase.New(navigator)
      End Sub 'New
      #End Region
      
        ' <summary>
        ' Cart object that will store the items that the user purchases in a shopping session
        ' </summary>
      
      Protected Property Cart() As CartDS
         Get
            ' attempt to retrieve the cart from the state object
                Dim McartDS As CartDS = CType(State(STATE_CART), CartDS)
            If McartDS Is Nothing Then
               ' user is in a new shopping session so the cart needs to be initialized
                    McartDS = New CartDS
                    State(STATE_CART) = McartDS
            End If
            
                Return McartDS
         End Get
         Set
            State(STATE_CART) = value
         End Set
      End Property
      
      #Region "Static helper methods"
      
      '/ <summary>
      '/ Gets the task related to the specified user
      '/ </summary>
      '/ <param name="userName"></param>
      '/ <returns></returns>
      Public Shared Function GetUserTaskId(userName As String) As Guid
         '  Look up TaskID in APPLICATION DATABASE;
         '  Remember, correlating logon or other information with UIP's TaskID is
         '  the responsibility of the consuming application
         Dim taskId As Guid = Guid.Empty
         
         'Gets user task
         Dim cartBO As New CartTaskBusinessObject()
         taskId = cartBO.GetTask(userName)
         
         Return taskId
      End Function 'GetUserTaskId
      
      
      '/ <summary>
      '/ Checks if the specified user name and password are valid
      '/ </summary>
      '/ <param name="userName">User name</param>
      '/ <param name="password"></param>
      '/ <returns></returns>
      Public Shared Function IsUserValid(userName As String, password As String) As Boolean
         Try
            'Lookup user in database
            Dim customerBO As New CustomerBusinessObject()
            Dim customerId As Integer = customerBO.Logon(userName, password)
            
            If customerId <> 0 Then
               Return True 'The user is valid
            Else
               Return False 'The user isnt valid
            End If
            Catch
                Throw
            End Try
      End Function 'IsUserValid
      
      #End Region
      
      #Region "Instance helper methods"
      
      '/ <summary>
      '/ Gets the last exception
      '/ </summary>
      Public Function GetLastError() As Exception
         Return CType(State(STATE_EXCEPTION), Exception)
      End Function 'GetLastError
      #End Region
      
      #Region "Navigation methods"
      
      
      '/ <summary>
      '/ Navigates to the fail view
      '/ </summary>
      Public Sub BrowseFail()
         Me.State.NavigateValue = "fail"
         Navigate()
      End Sub 'BrowseFail
      
      
      
      '/ <summary>
      '/ Clears all existing errors
      '/ </summary>
      Public Sub ClearError()
         Me.State.NavigateValue = "resume"
         Navigate()
      End Sub 'ClearError
      
      
      '/ <summary>
      '/ Directs the user to the store help shared transition that is available to all
      '/ navigation graphs within the store
      '/ </summary>
      Public Sub ShowStoreHelp()
         Me.State.NavigateValue = "storehelp"
         Navigate()
      End Sub 'ShowStoreHelp
      
      
      '/ <summary>
      '/ Directs the user to the store help shared transition that is availavle to the
      '/ shopping navigation graph.
      '/ </summary>
      Public Sub ShowShoppingHelp()
         Me.State.NavigateValue = "shoppinghelp"
         Navigate()
      End Sub 'ShowShoppingHelp
      
      
      
      '/ <summary>
      '/ Adds a product to the customer cart
      '/ </summary>
      '/ <param name="productId">ID of the product to add to the cart</param>
      '/ <param name="quantity">Quantity of product to be added to the cart</param>
      Public Overridable Sub AddToCart(productId As Integer, quantity As Integer)
         
         If Me.State Is Nothing Then
            Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionStateRequired"))
         End If 
         Try
            Dim cartBO As New CartBusinessObject()
            cartBO.AddToCart(Cart.CartItems, productId, quantity)
            
				Me.State.NavigateValue = "addItem"
				Me.State.Save()
         Catch e As Exception
            State(STATE_EXCEPTION) = e
            State.NavigateValue = "fail"
         End Try
      End Sub 'AddToCart
       
          
      
      '/ <summary>
      '/ Creates a new order
      '/ </summary>
      Public Sub CheckoutOrder()
         If Me.State Is Nothing Then
            Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionStateRequired"))
         End If 
         Try
            Dim cartBO As New CartTaskBusinessObject()
            ' retrieve the customerID for the customer that is performing the current task
            Dim customerId As Integer = cartBO.GetCustomerFromTask(State.TaskId)
            
            ' create a new order object and fill it with orderdetail items
            Dim orderBO As New OrderBusinessObject()
            orderBO.CreateOrderFromCart(customerId, Cart.CartItems)
            
                State.NavigateValue = "checkout"
         Catch e As Exception
            State(STATE_EXCEPTION) = e
            State.NavigateValue = "fail"
         End Try
         
         Navigate()
      End Sub 'CheckoutOrder
      
      
      
      '/ <summary>
      '/ Resumes the shopping task
      '/ </summary>
      Public Overridable Sub ResumeShopping()
         '  proceed to next View
         State.NavigateValue = "shoppingCart"
         Navigate()
      End Sub 'ResumeShopping
      
      
      '/ <summary>
      '/ Quits the current task and stores the state
      '/ </summary>
      Public Overridable Sub StopShopping()
         '  proceed to next View
         State.NavigateValue = "stop"
         Navigate()
      End Sub 'StopShopping
      
      
      
      '/ <summary>
      '/ Used to execute the checkout operation
      '/ </summary>
      '/ <param name="name">Persons name</param>
      '/ <param name="addr">Persons address</param>
      '/ <param name="ccnum">Persons Credit card number</param>
      Public Sub CompleteCheckout(name As String, addr As String, ccnum As String)
         '  do some checkout stuff
         If "1111-1111-1111-1111" <> ccnum Then
            State.NavigateValue = "failCheckout"
            Else
                'resets the state
                Cart.CartItems.Clear()
                State.NavigateValue = "congratulations"
            End If
            Navigate()
      End Sub 'CompleteCheckout
      
      
      
      '/ <summary>
      '/ Gets all products in the catalog
      '/ </summary>
      Public Function GetCatalogProducts() As ProductDS
            Dim MproductDS As New ProductDS
         Try
            Dim productBO As New ProductBusinessObject()
            ' fill the products dataset will all of the products in the database
                productBO.GetAllProducts(MproductDS, 0, 0)
         Catch e As Exception
            State(STATE_EXCEPTION) = e
            State.NavigateValue = "fail"
            Navigate()
         End Try
         
            Return MproductDS
      End Function 'GetCatalogProducts
      
      
      '/ <summary>
      '/ Gets a cusotmers shopping cart
      '/ </summary>
        Public Function GetCart() As CartDS
            If Me.State Is Nothing Then
                Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionStateRequired"))
            End If

            Return Cart
        End Function 'GetCartItems


        '/ <summary>
        '/ Gets the customer info
        '/ </summary>
        '/ <param name="logon">customer logon</param>
        '/ <returns>customer info</returns>
        Public Function GetCustomerByLogon(ByVal logon As String) As CustomerDS.Customer
            Dim bo As New CustomerBusinessObject
            Return bo.GetCustomerByLogon(logon).Customers(0)
        End Function 'GetCustomerByLogon
#End Region
   End Class 'StoreControllerBase
End Namespace 'UIProcessQuickstarts_Store