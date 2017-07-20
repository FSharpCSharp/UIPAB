 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' CartTaskBusinessObject.vb
'
' This file contains the implementations of the CartTaskBusinessObject class.
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
    ' This class contains all the operations to map a user with a specific task
    ' </summary>
   
   Public Class CartTaskBusinessObject
      Inherits BaseBusinessObject
      
      Public Sub New()
      End Sub 'New
      
      
      
        ' <summary>
        ' Gets the task related to the specified user
        ' </summary>
      Public Function GetTask(logon As String) As Guid
         Try
                Dim McustomerDS As New CustomerDS
                Dim McustomerDALC As New CustomerDALC
                McustomerDALC.GetCustomerByEmail(McustomerDS, logon)
            
                Dim customerId As Integer = McustomerDS.Customers(0).CustomerId
            
                Dim McartTaskDALC As New CartTaskDALC
                Return McartTaskDALC.GetTask(customerId)
         Catch e As Exception
            Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionGetTask"), e)
         End Try
      End Function 'GetTask
      
      
      
        ' <summary>
        ' Gets the customer related to the specified task
        ' </summary>
      Public Function GetCustomerFromTask(taskId As Guid) As Integer
         Try
                Dim McartTaskDALC As New CartTaskDALC
                Return McartTaskDALC.GetCustomerFromTask(taskId)
         Catch e As Exception
            Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionGetTask"), e)
         End Try
      End Function 'GetCustomerFromTask
      
      
      
        ' <summary>
        ' Creates a new task for the specified user
        ' </summary>
      Public Sub CreateTask(taskId As Guid, logon As String)
         Try
                Dim McustomerDS As New CustomerDS
                Dim McustomerDALC As New CustomerDALC
                McustomerDALC.GetCustomerByEmail(McustomerDS, logon)
            
                Dim customerId As Integer = McustomerDS.Customers(0).CustomerId
            
                Dim McartTaskDALC As New CartTaskDALC
                McartTaskDALC.CreateTask(taskId, customerId)
         Catch e As Exception
            Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionCreateTask"), e)
         End Try
      End Sub 'CreateTask
   End Class 'CartTaskBusinessObject
End Namespace 'UIProcessQuickstarts_Store