 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' ProductDAL.vb
'
' This file contains the implementations of the ProductDAL class.
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

    Public Class ProductDALC
        Inherits BaseDALC

        Public Sub New()
        End Sub

        ' <summary>
        ' Gets all products in the catalog
        ' </summary>
        Public Function GetAllProducts(ByVal MproductDS As ProductDS, ByVal from As Integer, ByVal count As Integer) As Boolean
            Try
                Dim reader As SqlDataReader = Nothing
                Try
                    reader = SqlHelper.ExecuteReader(Me.ConnectionString, CommandType.StoredProcedure, "SelectAllProducts")

                    SqlHelperExtension.Fill(reader, MproductDS, "product", from, count)
                    Dim ret As Boolean = reader.Read()
                    reader.Close()

                    Return ret
                Finally
                    If Not (reader Is Nothing) Then
                        CType(reader, IDisposable).Dispose()
                    End If
                End Try
            Catch e As Exception
                Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionCantGetCatalog"), e)
            End Try
        End Function 'GetAllProducts


        ' <summary>
        ' Gets the product with the specified identifier
        ' </summary>
        Public Sub GetProductById(ByVal MproductDS As ProductDS, ByVal productId As Integer)
            Try
                Dim reader As SqlDataReader = Nothing
                Try
                    reader = SqlHelper.ExecuteReader(Me.ConnectionString, CommandType.StoredProcedure, "SelectProductById", New SqlParameter() {New SqlParameter("@ProductID", productId)})


                    SqlHelperExtension.Fill(reader, MproductDS, "product", 0, 1)
                    reader.Close()
                Finally
                    If Not (reader Is Nothing) Then
                        CType(reader, IDisposable).Dispose()
                    End If
                End Try
            Catch e As Exception
                Throw New ApplicationException(String.Format(ResourceManager.GetString("RES_ExceptionCantGetProduct"), productId), e)
            End Try
        End Sub

        ' <summary>
        ' Creates a new product with the specified data
        ' </summary>
        Public Sub CreateProduct(ByVal categoryId As Integer, ByVal modelNumber As String, ByVal modelName As String, ByVal image As String, ByVal description As String, ByVal unitCost As Decimal)
            SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "InsertProduct", New SqlParameter() {New SqlParameter("@CategoryID", categoryId), New SqlParameter("@ModelNumber", modelNumber), New SqlParameter("@ModelName", modelName), New SqlParameter("@ProductImage", image), New SqlParameter("@Description", description), New SqlParameter("@UnitCost", unitCost)})
        End Sub

        ' <summary>
        ' Updates a existing product with the specified data
        ' </summary>
        Public Sub UpdateProduct(ByVal productId As Integer, ByVal categoryId As Integer, ByVal modelNumber As String, ByVal modelName As String, ByVal image As String, ByVal description As String, ByVal unitCost As Decimal)
            SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "UpdateProduct", New SqlParameter() {New SqlParameter("@ProductID", productId), New SqlParameter("@CategoryID", categoryId), New SqlParameter("@ModelNumber", modelNumber), New SqlParameter("@ModelName", modelName), New SqlParameter("@ProductImage", image), New SqlParameter("@Description", description), New SqlParameter("@UnitCost", unitCost)})
        End Sub

        ' <summary>
        ' Removes a existing product
        ' </summary>
        Public Sub DeleteProduct(ByVal productId As Integer)

            SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "DeleteProduct", New SqlParameter() {New SqlParameter("@ProductID", productId)})
        End Sub

    End Class

End Namespace
