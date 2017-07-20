 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' CategoryDALC.vb
'
' This file contains the implementations of the CustomerDALC class.
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
   
   Public Class CategoryDALC
      Inherits BaseDALC
      
      Public Sub New()
      End Sub 'New
      
      
        ' <summary>
        ' Gets all available product categories
        ' </summary>
        Public Function GetAllCategories(ByVal McategoryDS As CategoryDS, ByVal from As Integer, ByVal count As Integer) As Boolean
            Try
                Dim reader As SqlDataReader = Nothing
                Try
                    reader = SqlHelper.ExecuteReader(Me.connectionString, CommandType.StoredProcedure, "SelectAllCategories")

                    SqlHelperExtension.Fill(reader, McategoryDS, "category", from, count)
                    Dim ret As Boolean = reader.Read()
                    reader.Close()

                    Return ret
                Finally
                    If Not (reader Is Nothing) Then
                        CType(reader, IDisposable).Dispose()
                    End If
                End Try
            Catch e As Exception
                Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionCantGetCategories"), e)
            End Try
        End Function 'GetAllCategories
    End Class 'CategoryDALC
End Namespace 'UIProcessQuickstarts_Store