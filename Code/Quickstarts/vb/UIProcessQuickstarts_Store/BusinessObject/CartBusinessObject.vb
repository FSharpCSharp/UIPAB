 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' CartBusinessObject.vb
'
' This file contains the implementations of the CartBusinessObject class.
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
Imports System.Data


Namespace UIProcessQuickstarts_Store
    ' <summary>
    ' This class contains all the cart related business rules that are utilized in the store
    ' </summary>
   
   Public Class CartBusinessObject
      Inherits BaseBusinessObject
      
      Public Sub New()
      End Sub 'New
      
      
      
        ' <summary>
        ' Gets a cart with the specified cart identifier
        ' </summary>
      Public Function GetDetailedCart(cartItems As CartDS.CartItemsDataTable) As CartDS.CartItemsDataTable
            Return cartItems
      End Function 'GetDetailedCart

        ' <summary>
        ' Adds a new item to a existing cart
        ' </summary>
        ' <remarks>If the item alredy exists in the cart, then only its quantity
        '	is updated</remarks>
      Public Sub AddToCart(cartItems As CartDS.CartItemsDataTable, productId As Integer, quantity As Integer)
         Try
            Dim productBO As New ProductBusinessObject()
                Dim products As New ProductDS
                productBO.GetProductById(products, productId)
            If cartItems.Rows.Count > 0 Then
                    Dim selectedItems As DataRow() = cartItems.Select(("productID=" + productId.ToString()))
               If selectedItems.Length > 0 Then
                  CType(selectedItems(0), CartDS.CartItem).Quantity += quantity
               Else
                        cartItems.AddCartItem(quantity, productId, products.Products(0).ModelName, products.Products(0).UnitCost)
               End If
            Else
                    cartItems.AddCartItem(quantity, productId, products.Products(0).ModelName, products.Products(0).UnitCost)
            End If
         Catch e As Exception
            Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionCantAddCartItem"), e)
         End Try
      End Sub 'AddToCart
   End Class 'CartBusinessObject
End Namespace 'UIProcessQuickstarts_Store