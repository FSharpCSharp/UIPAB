 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' DemoContoller2.vb
'
' This file contains the implementations of the DemoController2 class.
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
    ' This class represents the controller used by the navigation graph B
    ' </summary>
   
   Public Class DemoController2
      Inherits ControllerBase
      
        ' <summary>
        ' Constructor
        ' </summary>
        ' <param name="state">Controller state</param>
      Public Sub New(navigator As Navigator)
         MyBase.New(navigator)
      End Sub 'New
       
        ' <summary>
        ' This method is used an initialization by Controllers.  
        ' It is passed Task Arguments, with which it can do anything.
        ' </summary>
        ' <param name="taskArguments">A holder for originating navgraph and taskid, and an object for other "stuff" that
        ' will be used by the controller to get state information from the previous nav graph</param>
      Public Overrides Sub EnterTask(taskArguments As TaskArgumentsHolder)
         MyBase.EnterTask(taskArguments)
            If Not (taskArguments Is Nothing) Then
                ' Store the previous navgraph and task id into our State
                MyState.PreviousNavGraph = taskArguments.OriginatingNavGraphName
                MyState.PreviousTaskID = taskArguments.OriginatingTaskID
            End If
      End Sub 'EnterTask
      
        ' <summary>
        ' Gets a specialized state object valid for this controller
        ' </summary>
      
      Private ReadOnly Property MyState() As State2
         Get
            Return CType(State, State2)
         End Get
      End Property
       
        ' <summary>
        ' Handles the next button click event on form4 class
        ' </summary>
        ' <param name="someState">some info wich will be store into the state</param>
      Public Sub Form4btnNext(someState As String)
         ' Update the task entry
         TaskLog.MakeTaskEntry(State.TaskId, State.NavigationGraph, State.CurrentView, DateTime.Now)
         
         ' Store the info into the state
         State("Form4btnNext") = someState
         
         ' Navigate to the next view
         State.NavigateValue = "next"
         Navigate()
      End Sub 'Form4btnNext
      
      
        ' <summary>
        ' Handles the next button click event on form5 class
        ' </summary>
        ' <param name="someState">some info, wich will be passed to the next navigation graph</param>
      Public Sub Form5btnNext(someState As String)
         ' Update the task entry
         TaskLog.MakeTaskEntry(State.TaskId, State.NavigationGraph, State.CurrentView, DateTime.Now)
         
            SuspendTask()
         
         ' Navigate to the previous navigation graph
         OnStartTask(MyState.PreviousNavGraph, New TaskArgumentsHolder(State.TaskId, State.NavigationGraph, someState), New Task(MyState.PreviousTaskID))
      End Sub 'Form5btnNext
      
      
        ' <summary>
        ' Handles the previous button click event on form5 class
        ' </summary>
      Public Sub Form5btnPrevious()
         ' Update the task entry
         TaskLog.MakeTaskEntry(State.TaskId, State.NavigationGraph, State.CurrentView, DateTime.Now)
         
         ' Navigate to the next view
         State.NavigateValue = "previous"
         Navigate()
        End Sub 'Form5btnPrevious
        ' <summary>
        ' Completes the task. Remove the TaskLog
        ' </summary>
        Public Overrides Sub CompleteTask()
            MyBase.CompleteTask()
            TaskLog.RemoveTaskEntry(State.TaskId)
            TaskLog.RemoveTaskEntry(MyState.PreviousTaskID)
        End Sub
    End Class 'DemoController2
End Namespace 'UIProcessQuickstarts_MultiNavGraph