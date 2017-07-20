 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' ProductBusinessObject.vb
'
' This file contains the implementations of the ProductBusinessObject class.
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
    ' This class contains all the product related business rules
    ' </summary>
   
   Public Class ProductBusinessObject
      Inherits BaseBusinessObject
      
      Public Sub New()
      End Sub 'New
      
      
        ' <summary>
        ' Gets all products in the catalog
        ' </summary>
        Public Function GetAllProducts(ByVal MproductDS As ProductDS, ByVal from As Integer, ByVal count As Integer) As Boolean
            Try
                Dim MproductDALC As New ProductDALC
                Return MproductDALC.GetAllProducts(MproductDS, from, count)
            Catch e As Exception
                Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionGetCatalog"), e)
            End Try
        End Function 'GetAllProducts


        ' <summary>
        ' Gets the product with the specified identifier
        ' </summary>
        Public Sub GetProductById(ByVal MproductDS As ProductDS, ByVal productId As Integer)
            Try
                Dim MproductDALC As New ProductDALC
                MproductDALC.GetProductById(MproductDS, productId)
            Catch e As Exception
                Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionGetProduct"), e)
            End Try
        End Sub 'GetProductById


        ' <summary>
        ' Creates a new the product with the specified data
        ' </summary>
        Public Sub CreateProduct(ByVal categoryId As Integer, ByVal modelNumber As String, ByVal modelName As String, ByVal image As String, ByVal description As String, ByVal unitCost As Decimal)
            Try
                Dim MproductDALC As New ProductDALC
                MproductDALC.CreateProduct(categoryId, modelNumber, modelName, image, description, unitCost)
            Catch e As Exception
                Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionCantCreateProduct"), e)
            End Try
        End Sub 'CreateProduct


        ' <summary>
        ' Updates a existing product with the specified data
        ' </summary>
        Public Sub UpdateProduct(ByVal productId As Integer, ByVal categoryId As Integer, ByVal modelNumber As String, ByVal modelName As String, ByVal image As String, ByVal description As String, ByVal unitCost As Decimal)
            Try
                Dim MproductDALC As New ProductDALC
                MproductDALC.UpdateProduct(productId, categoryId, modelNumber, modelName, image, description, unitCost)
            Catch e As Exception
                Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionCantUpdateProduct"), e)
            End Try
        End Sub 'UpdateProduct


        ' <summary>
        ' Removes a existing product
        ' </summary>
        Public Sub DeleteProduct(ByVal productId As Integer)
            Try
                Dim MproductDALC As New ProductDALC
                MproductDALC.DeleteProduct(productId)
            Catch e As Exception
                Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionCantDeleteProduct"), e)
            End Try
        End Sub 'DeleteProduct
    End Class 'ProductBusinessObject
End Namespace 'UIProcessQuickstarts_Store