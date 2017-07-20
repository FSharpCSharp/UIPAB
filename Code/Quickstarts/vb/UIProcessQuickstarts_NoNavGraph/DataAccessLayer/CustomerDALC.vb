 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' CustomerDAL.vb
'
' This file contains the implementations of the CustomerDAL class.
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

    Public Class CustomerDALC
        Inherits BaseDALC

        Public Sub New()
        End Sub

        ' <summary>
        ' Gets the customer info
        ' </summary>
        ' <param name="customerDS">a dataset that will be used to store the customer info</param>
        ' <param name="email">customer email</param>
        Public Sub GetCustomerByEmail(ByVal McustomerDS As CustomerDS, ByVal email As String)
            Try
                Dim reader As SqlDataReader = Nothing
                Try
                    reader = SqlHelper.ExecuteReader(Me.ConnectionString, CommandType.StoredProcedure, "SelectCustomerByEmail", New SqlParameter() {New SqlParameter("@EmailAddress", email)})

                    SqlHelperExtension.Fill(reader, McustomerDS, McustomerDS.Customers.TableName, 0, 1)
                Finally
                    If Not (reader Is Nothing) Then
                        CType(reader, IDisposable).Dispose()
                    End If
                End Try
            Catch e As Exception
                Throw New ApplicationException(String.Format(ResourceManager.GetString("RES_ExceptionCantGetCustomer"), email), e)
            End Try
        End Sub

    End Class

End Namespace