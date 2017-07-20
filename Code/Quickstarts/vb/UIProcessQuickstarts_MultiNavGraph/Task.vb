 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' Task.vb
'
' This file contains the implementations of the Task class.
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


Namespace UIProcessQuickstarts_MultiNavGraph
    ' <summary>
    ' Summary description for Task.
    ' </summary>
   
   Public Class Task
      Implements ITask 'ToDo: Add Implements Clauses for implementation methods of these interface(s)
      Private _taskId As Guid = Guid.Empty
      
      
      Public Sub New()
      End Sub 'New
      
      
      Public Sub New(taskId As Guid)
         _taskId = taskId
      End Sub 'New
      
      #Region "ITask Members"
      
      
        Public Sub Create(ByVal taskId As Guid) Implements ITask.Create
            _taskId = taskId
        End Sub 'Create


        Public Function [Get]() As Guid Implements ITask.Get
            Return _taskId
        End Function 'Get

#End Region
   End Class 'Task
End Namespace 'UIProcessQuickstarts_MultiNavGraph