 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' DemoController1.vb
'
' This file contains the implementations of the DemoContoller1 class.
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
    ' This class represents the controller used by the navigation graph A
    ' </summary>
   
   Public Class DemoController1
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
            
            ' Push whatever state they passed into our State
            MyState("previousNavState") = CStr(taskArguments.TaskArguments)
         End If
      End Sub 'EnterTask
      
        ' <summary>
        ' Gets a specialized state object valid for this controller
        ' </summary>
      
      Private ReadOnly Property MyState() As State1
         Get
            Return CType(State, State1)
         End Get
      End Property
       
        ' <summary>
        ' Handles the next button click event on form1 class
        ' </summary>
      Public Sub Form1btnNext()
         ' Update the task entry
         TaskLog.MakeTaskEntry(State.TaskId, State.NavigationGraph, State.CurrentView, DateTime.Now)
         
         ' Navigate to the next view
         State.NavigateValue = "next"
         Navigate()
      End Sub 'Form1btnNext
      
      
        ' <summary>
        ' Handles the next button click event on form2 class
        ' </summary>
      Public Sub Form2btnNext()
         ' Update the task entry
         TaskLog.MakeTaskEntry(State.TaskId, State.NavigationGraph, State.CurrentView, DateTime.Now)
         
         ' Navigate to the next view
         State.NavigateValue = "next"
         Navigate()
      End Sub 'Form2btnNext
      
        ' <summary>
        ' Complete the Task, thus the state will be cleaned out.
        ' </summary>
      Public Sub CompleteNavA()
         CompleteTask()
      End Sub 'CompleteNavA
      
      
        ' <summary>
        ' End the Task, but the state is still there
        ' </summary>
      Public Sub EndNavA()
            SuspendTask()
      End Sub 'EndNavA
      
        ' <summary>
        ' Handles the next button click event on form3 class
        ' </summary>
      Public Sub Form3btnNext()
         ' Update the task entry
            TaskLog.MakeTaskEntry(State.TaskId, State.NavigationGraph, State.CurrentView, DateTime.Now)

            If MyState.PreviousNavGraph.Length <> 0 AndAlso Not (MyState.PreviousTaskID.Equals(Guid.Empty)) Then
                OnStartTask(MyState.PreviousNavGraph, New TaskArgumentsHolder(MyState.TaskId, "navA", "From A"), New Task(MyState.PreviousTaskID)) ' Continue the existing task
            Else
                OnStartTask("navB", New TaskArgumentsHolder(MyState.TaskId, "navA", "From A"), Nothing) ' Start a new task
            End If
      End Sub 'Form3btnNext
       
        ' <summary>
        ' Handles the previous button click event on form2 class
        ' </summary>
      Public Sub Form2btnPrevious()
         ' Update the task entry
         TaskLog.MakeTaskEntry(State.TaskId, State.NavigationGraph, State.CurrentView, DateTime.Now)
         
         ' Navigate to the next view
         State.NavigateValue = "previous"
         Navigate()
      End Sub 'Form2btnPrevious
      
      
        ' <summary>
        ' Handles the previous button click event on form3 class
        ' </summary>
      Public Sub Form3btnPrevious()
         ' Update the task entry
         TaskLog.MakeTaskEntry(State.TaskId, State.NavigationGraph, State.CurrentView, DateTime.Now)
         
         ' Navigate to the next view
         State.NavigateValue = "previous"
         Navigate()
      End Sub 'Form3btnPrevious
      
      
        ' <summary>
        ' Show the state obtained from the previous navigation graph
        ' </summary>
      Public Sub Form3ShowPreviousNavState()
         State.NavigateValue = "showPreviousNavState"
         Navigate()
        End Sub 'Form3ShowPreviousNavState
        ' <summary>
        ' Completes the task. Remove the TaskLog
        ' </summary>
        Public Overrides Sub CompleteTask()
            MyBase.CompleteTask()

            ' Have to get NavB's state and clean it up.
            Try
                Dim navBState As State = StateFactory.Load("navB", MyState.PreviousTaskID)
                navBState.Delete()
            Catch
            End Try

            TaskLog.RemoveTaskEntry(State.TaskId)
            TaskLog.RemoveTaskEntry(MyState.PreviousTaskID)

        End Sub

    End Class 'DemoController1
End Namespace 'UIProcessQuickstarts_MultiNavGraph