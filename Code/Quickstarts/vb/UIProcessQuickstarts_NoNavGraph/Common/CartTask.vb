 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' CartTask.vb
'
' This file contains the implementations of the CartTask class.
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
Imports Microsoft.ApplicationBlocks.UIProcess

Namespace UIProcessQuickstarts_Store

    ' <summary>
    ' Defines a Task Object which can be passed to UIPManager.  
    ' Used to correlate a existing Task Id with a logon
    ' </summary>
    Public Class CartTask
        Implements ITask

#Region "Constructors"

        Public Sub New()
        End Sub

        Public Sub New(ByVal userLogon As String)
            _userLogon = userLogon
            _taskId = StoreController.GetUserTaskId(_userLogon)
        End Sub
#End Region

#Region "Variable Declarations"

        Private _userLogon As String = ""
        Private _taskId As Guid = Guid.Empty

#End Region

#Region "ITask Members"

        '/ <summary>
        '/ Creates a new task for the specific logon
        '/ </summary>
        '/ <param name="taskId"></param>
        Public Sub Create(ByVal taskId As Guid) Implements ITask.Create
            '  this is app-specific.
            '  in the case of this shopping cart application, we want to 
            '  correlate logons with tasks.  We use a lookup table to do so.
            '  so here, we are given a TaskId...and we must correlate it with our Logon
            '  create the business object to be used
            Dim bo As New CartTaskBusinessObject

            '  cache task id given to us by UIPManager (or whatever entity)
            _taskId = taskId

            '  tell business object to create CartTask entry
            bo.CreateTask(_taskId, _userLogon)
        End Sub

        '/ <summary>
        '/ Gets the task id related to the specific logon
        '/ </summary>
        '/ <returns></returns>
        Public Function [Get]() As Guid Implements ITask.Get
            Return _taskId
        End Function

#End Region

    End Class

End Namespace