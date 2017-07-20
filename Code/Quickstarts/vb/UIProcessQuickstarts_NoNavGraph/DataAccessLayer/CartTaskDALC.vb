 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' CartTaskDAL.vb
'
' This file contains the implementations of the CartTaskDAL class.
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

    Public Class CartTaskDALC
        Inherits BaseDALC

        Public Sub New()
        End Sub

        ' <summary>
        ' Gets the customer task id
        ' </summary>
        ' <param name="customerId">a existing customer id</param>
        ' <returns></returns>
        Public Function GetTask(ByVal customerId As Integer) As Guid
            Dim taskId As Guid = Guid.Empty

            Try
                Dim reader As SqlDataReader = Nothing
                Try
                    reader = SqlHelper.ExecuteReader(Me.ConnectionString, CommandType.StoredProcedure, "SelectCartTaskByCustomerId", New SqlParameter() {New SqlParameter("@CustomerID", customerId)})

                    If reader.Read() Then
                        taskId = CType(reader("TaskID"), Guid)
                    End If
                    Return taskId
                Finally
                    If Not (reader Is Nothing) Then
                        CType(reader, IDisposable).Dispose()
                    End If
                End Try
            Catch e As Exception
                Throw New ApplicationException(String.Format(ResourceManager.GetString("RES_ExceptionCantGetTaskByCustomerID"), customerId), e)
            End Try
        End Function

        ' <summary>
        ' Gets the identifier of the task ownwer 
        ' </summary>
        ' <param name="taskId">task id</param>
        ' <returns>customer id</returns>
        Public Function GetCustomerFromTask(ByVal taskId As Guid) As Integer
            Dim customerId As Integer = 0
            Try
                Dim reader As SqlDataReader = Nothing

                Try
                    reader = SqlHelper.ExecuteReader(Me.ConnectionString, CommandType.StoredProcedure, "SelectCartTaskByTaskId", New SqlParameter() {New SqlParameter("@TaskID", taskId)})

                    If reader.Read() Then
                        customerId = CInt(reader("CustomerID"))
                    End If
                    Return customerId

                Finally
                    If Not (reader Is Nothing) Then
                        CType(reader, IDisposable).Dispose()
                    End If
                End Try
            Catch e As Exception
                Throw New ApplicationException(String.Format(ResourceManager.GetString("RES_ExceptionCantGetTaskByTaskID"), taskId), e)
            End Try
        End Function

        ' <summary>
        ' Creates a new task
        ' </summary>
        ' <param name="taskId">task id</param>
        ' <param name="customerId">customer id</param>
        Public Sub CreateTask(ByVal taskId As Guid, ByVal customerId As Integer)
            Try
                SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "InsertCartTask", New SqlParameter() {New SqlParameter("@CustomerID", customerId), New SqlParameter("@TaskID", taskId)})
            Catch e As Exception
                Throw New ApplicationException(String.Format(ResourceManager.GetString("RES_ExceptionCantCreateTask"), customerId, taskId), e)
            End Try
        End Sub

    End Class

End Namespace