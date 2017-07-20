 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' CustomerBusinessObject.vb
'
' This file contains the implementations of the CustomerBusinessObject class.
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
    ' This class contains all the customer related business rules
    ' </summary>
    Public Class CustomerBusinessObject
        Inherits BaseBusinessObject

        Public Sub New()
        End Sub

        ' <summary>
        ' Gets customer information
        ' </summary>
        ' <param name="logon">customer logon</param>
        Public Function GetCustomerByLogon(ByVal logon As String) As CustomerDS
            Dim McustomerDS As New CustomerDS
            Dim McustomerDALC As New CustomerDALC

            McustomerDALC.GetCustomerByEmail(McustomerDS, logon)

            Return McustomerDS
        End Function

        ' <summary>
        ' Authenticates a specified user
        ' </summary>
        ' <returns>Customer id</returns>
        Public Function Logon(ByVal email As String, ByVal password As String) As Integer
            Try
                Dim customerId As Integer = 0

                Dim McustomerDS As New CustomerDS
                Dim McustomerDALC As New CustomerDALC

                McustomerDALC.GetCustomerByEmail(McustomerDS, email)

                If McustomerDS.Customers.Rows.Count > 0 Then
                    If CStr(McustomerDS.Customers(0).Password) = password Then
                        customerId = CInt(McustomerDS.Customers(0).CustomerId)
                    End If
                End If
                Return customerId
            Catch e As Exception
                Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionCantAuthenticateCustomer"), e)
            End Try
        End Function

    End Class

End Namespace