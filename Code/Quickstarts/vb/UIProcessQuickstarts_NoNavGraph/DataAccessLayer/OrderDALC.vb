 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' OrderDAL.vb
'
' This file contains the implementations of the OrderDAL class.
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
        End Sub

        ' <summary>
        ' Creates a new order
        ' </summary>
        ' <param name="customerId"></param>
        ' <param name="orderDate"></param>
        ' <param name="shipDate"></param>
        ' <returns></returns>
        Public Function CreateOrder(ByVal customerId As Integer, ByVal orderDate As DateTime, ByVal shipDate As DateTime) As Integer
            Try
                Dim returnParam As New SqlParameter("@Return", SqlDbType.Int)
                returnParam.Direction = ParameterDirection.ReturnValue

                SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "InsertOrder", New SqlParameter() {New SqlParameter("@CustomerID", customerId), New SqlParameter("@OrderDate", orderDate), New SqlParameter("@ShipDate", shipDate), returnParam})
                Return CInt(returnParam.Value)
            Catch e As Exception
                Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionCantCreateOrder"), e)
            End Try
        End Function

        ' <summary>
        ' Creates a new order item
        ' </summary>
        ' <param name="orderId"></param>
        ' <param name="productId"></param>
        ' <param name="unitCost"></param>
        ' <param name="quantity"></param>
        Public Sub CreateOrderItem(ByVal orderId As Integer, ByVal productId As Integer, ByVal unitCost As Decimal, ByVal quantity As Integer)
            Try
                SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "InsertOrder_Details", New SqlParameter() {New SqlParameter("@OrderID", orderId), New SqlParameter("@ProductID", productId), New SqlParameter("@UnitCost", unitCost), New SqlParameter("@quantity", quantity)})
            Catch e As Exception
                Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionCantCreateOrderItem"), e)
            End Try
        End Sub

    End Class

End Namespace