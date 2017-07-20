 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' DemoTask.vb
'
' This file contains the implementations of the DemoTask class.
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
Imports System.Xml
Imports Microsoft.ApplicationBlocks.UIProcess


Namespace UIProcessQuickstarts_MultiNavGraph
    ' <summary>
    ' A Task sample wich will be passed to UIPManager
    ' </summary>
   
   Public Class DemoTask
      Implements ITask 'ToDo: Add Implements Clauses for implementation methods of these interface(s)
      
      Public Sub New()
      End Sub 'New
       
        ' <summary>
        ' Constructor
        ' </summary>
        ' <param name="taskID">Task identifier</param>
        Public Sub New(ByVal taskID As Guid)
            _taskID = taskID
        End Sub 'New

        Private _taskID As Guid = Guid.Empty

#Region "ITask Members"


        '<summary>Create a new task identifier</summary>
        '<param name="taskId">task identifier</param>
        Public Sub Create(ByVal taskId As Guid) Implements ITask.Create
            TaskLog.MakeTaskEntry(taskId)
        End Sub 'Create


        '<summary>Get the taskid related to this Task object</summary>
        Public Function [Get]() As Guid Implements ITask.Get
            Return _taskID
        End Function 'Get

#End Region
    End Class 'DemoTask
End Namespace 'UIProcessQuickstarts_MultiNavGraph