 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' OrderDALC.vb
'
' This file contains the implementations of the OrderDALC class.
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
Imports System.Data.SqlClient

Imports Microsoft.ApplicationBlocks.Data


Namespace UIProcessQuickstarts_Store
   
   Public Class OrderDALC
      Inherits BaseDALC
      
      Public Sub New()
      End Sub 'New
      
      
        ' <summary>
        ' Creates a new order
        ' </summary>
        ' <param name="customerId"></param>
        ' <param name="orderDate"></param>
        ' <param name="shipDate"></param>
        ' <returns></returns>
      Public Function CreateOrder(customerId As Integer, orderDate As DateTime, shipDate As DateTime) As Integer
         Try
            Dim returnParam As New SqlParameter("@Return", SqlDbType.Int)
            returnParam.Direction = ParameterDirection.ReturnValue
            
            SqlHelper.ExecuteNonQuery(Me.connectionString, CommandType.StoredProcedure, "InsertOrder", New SqlParameter() {New SqlParameter("@CustomerID", customerId), New SqlParameter("@OrderDate", orderDate), New SqlParameter("@ShipDate", shipDate), returnParam})
            Return CInt(returnParam.Value)
         Catch e As Exception
            Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionCantCreateOrder"), e)
         End Try
      End Function 'CreateOrder
      
      
        ' <summary>
        ' Creates a new order item
        ' </summary>
        ' <param name="orderId"></param>
        ' <param name="productId"></param>
        ' <param name="unitCost"></param>
        ' <param name="quantity"></param>
      Public Sub CreateOrderItem(orderId As Integer, productId As Integer, unitCost As Decimal, quantity As Integer)
         Try
            SqlHelper.ExecuteNonQuery(Me.connectionString, CommandType.StoredProcedure, "InsertOrder_Details", New SqlParameter() {New SqlParameter("@OrderID", orderId), New SqlParameter("@ProductID", productId), New SqlParameter("@UnitCost", unitCost), New SqlParameter("@quantity", quantity)})
         Catch e As Exception
            Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionCantCreateOrderItem"), e)
         End Try
      End Sub 'CreateOrderItem
   End Class 'OrderDALC
End Namespace 'UIProcessQuickstarts_Store