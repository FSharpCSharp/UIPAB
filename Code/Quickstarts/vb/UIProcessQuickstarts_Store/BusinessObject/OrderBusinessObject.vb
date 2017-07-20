 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' OrderBusinessObject.vb
'
' This file contains the implementations of the OrderBusinessObject class.
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


Namespace UIProcessQuickstarts_Store
    ' <summary>
    ' This class contains all order related business rules
    ' </summary>
   
   Public Class OrderBusinessObject
      Inherits BaseBusinessObject
      
      Public Sub New()
      End Sub 'New
      
      
        ' <summary>
        ' Creates a new order with the specified params
        ' </summary>
      Public Function CreateOrderFromCart(customerId As Integer, items As CartDS.CartItemsDataTable) As Integer
            Dim MorderDALC As New OrderDALC
            Dim MproductDALC As New ProductDALC
         
            Dim orderId As Integer = MorderDALC.CreateOrder(customerId, DateTime.Now, DateTime.Now.AddDays(2))
         
         Dim item As CartDS.CartItem
         For Each item In  items
                Dim MproductDS As New ProductDS
                MproductDALC.GetProductById(MproductDS, item.ProductId)
            
                MorderDALC.CreateOrderItem(orderId, item.ProductId, MproductDS.Products(0).UnitCost, item.Quantity)
         Next item
         
         Return orderId
      End Function 'CreateOrderFromCart
   End Class 'OrderBusinessObject
End Namespace 'UIProcessQuickstarts_Store