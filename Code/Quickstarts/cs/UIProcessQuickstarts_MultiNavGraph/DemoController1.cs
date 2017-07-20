//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// DemoController1.cs
//
// This file contains the implementations of the DemoContoller1 class.
//
// 
//===============================================================================
// Copyright (C) 2000-2001 Microsoft Corporation
// All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
// FITNESS FOR A PARTICULAR PURPOSE.
//==============================================================================

using System;

using Microsoft.ApplicationBlocks.UIProcess;

namespace UIProcessQuickstarts_MultiNavGraph
{
    /// <summary>
    /// This class represents the controller used by the navigation graph A
    /// </summary>
    public class DemoController1 : ControllerBase	
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="state">Controller state</param>
		public DemoController1( Navigator navigator ) : base( navigator ){}

        /// <summary>
        /// This method is used an initialization by Controllers.  
        /// It is passed Task Arguments, with which it can do anything.
        /// </summary>
        /// <param name="taskArguments">A holder for originating navgraph and taskid, and an object for other "stuff" that
        /// will be used by the controller to get state information from the previous nav graph</param>
        public override void EnterTask(TaskArgumentsHolder taskArguments)
		{
			base.EnterTask (taskArguments);
			if( taskArguments != null )
			{
				// Store the previous navgraph and task id into our State
                MyState.PreviousNavGraph = taskArguments.OriginatingNavGraphName;
				MyState.PreviousTaskID = taskArguments.OriginatingTaskID;

				// Push whatever state they passed into our State
				MyState[ "previousNavState" ] = (string)taskArguments.TaskArguments;
			}
		}

		/// <summary>
		/// Gets a specialized state object valid for this controller
		/// </summary>
        private State1 MyState
		{
			get { return (State1)State; }
		}

        /// <summary>
        /// Handles the next button click event on form1 class
        /// </summary>
		public void Form1btnNext()
		{
			// Update the task entry
            TaskLog.MakeTaskEntry( State.TaskId, State.NavigationGraph, State.CurrentView, DateTime.Now );

			// Navigate to the next view
            State.NavigateValue = "next";
			Navigate();
		}

        /// <summary>
        /// Handles the next button click event on form2 class
        /// </summary>
		public void Form2btnNext()
		{
			// Update the task entry
            TaskLog.MakeTaskEntry( State.TaskId, State.NavigationGraph, State.CurrentView, DateTime.Now );

			// Navigate to the next view
            State.NavigateValue = "next";
			Navigate();
		}
		/// <summary>
		/// Complete the Task, thus the state will be cleaned out.
		/// </summary>
		public void CompleteNavA()
		{
			CompleteTask();
		}

		/// <summary>
		/// End the Task, but the state is still there
		/// </summary>
		public void EndNavA()
		{
			SuspendTask();
		}
        /// <summary>
        /// Handles the next button click event on form3 class
        /// </summary>
		public void Form3btnNext()
		{
			// Update the task entry
            TaskLog.MakeTaskEntry( State.TaskId, State.NavigationGraph, State.CurrentView, DateTime.Now );

            if( MyState.PreviousNavGraph.Length != 0 && MyState.PreviousTaskID != Guid.Empty )
                OnStartTask( MyState.PreviousNavGraph, new TaskArgumentsHolder( MyState.TaskId, "navA", "From A" ), new Task(MyState.PreviousTaskID) ); // Continue the existing task
            else 
                OnStartTask( "navB", new TaskArgumentsHolder( MyState.TaskId, "navA", "From A" ), null ); // Start a new task
		}

        /// <summary>
        /// Handles the previous button click event on form2 class
        /// </summary>
        public void Form2btnPrevious()
		{
			// Update the task entry
            TaskLog.MakeTaskEntry( State.TaskId, State.NavigationGraph, State.CurrentView, DateTime.Now );

			// Navigate to the next view
			State.NavigateValue = "previous";
			Navigate();
		}

		/// <summary>
		/// Handles the previous button click event on form3 class
		/// </summary>
		public void Form3btnPrevious()
		{
			// Update the task entry
			TaskLog.MakeTaskEntry( State.TaskId, State.NavigationGraph, State.CurrentView, DateTime.Now );

			// Navigate to the next view
			State.NavigateValue = "previous";
			Navigate();
		}

		/// <summary>
		/// Show the state obtained from the previous navigation graph
		/// </summary>
		public void Form3ShowPreviousNavState()
		{
			State.NavigateValue = "showPreviousNavState";	
			Navigate();
		}

		/// <summary>
		/// Completes the task. Remove the TaskLog
		/// </summary>
		public override void CompleteTask() 
		{
			base.CompleteTask();
			//Have to get NavB's state and clean it up.
			try
			{
				State navBState = StateFactory.Load("navB",MyState.PreviousTaskID);
				navBState.Delete();
			}catch{}
			TaskLog.RemoveTaskEntry( State.TaskId );
			TaskLog.RemoveTaskEntry( MyState.PreviousTaskID);

		}
	}
}
