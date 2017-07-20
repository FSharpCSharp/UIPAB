//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// DemoContoller2.cs
//
// This file contains the implementations of the DemoController2 class.
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
using System.Xml;

using Microsoft.ApplicationBlocks.UIProcess;

namespace UIProcessQuickstarts_MultiNavGraph
{
	/// <summary>
	/// This class represents the controller used by the navigation graph B
	/// </summary>
	public class DemoController2 : ControllerBase	
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="state">Controller state</param>
		public DemoController2( Navigator navigator ) : base( navigator ) {}

		/// <summary>
		/// This method is used an initialization by Controllers.  
		/// It is passed Task Arguments, with which it can do anything.
		/// </summary>
		/// <param name="taskArguments">A holder for originating navgraph and taskid, and an object for other "stuff" that
		/// will be used by the controller to get state information from the previous nav graph</param>
		public override void EnterTask(TaskArgumentsHolder taskArguments)
		{
			base.EnterTask (taskArguments);
			if( null != taskArguments )
			{
				// Store the previous navgraph and task id into our State
				MyState.PreviousNavGraph = taskArguments.OriginatingNavGraphName;
				MyState.PreviousTaskID = taskArguments.OriginatingTaskID;
			}
		}

		/// <summary>
		/// Gets a specialized state object valid for this controller
		/// </summary>
		private State2 MyState
		{
			get { return (State2)State; }
		}

		/// <summary>
		/// Handles the next button click event on form4 class
		/// </summary>
		/// <param name="someState">some info wich will be store into the state</param>
		public void Form4btnNext( string someState )
		{
			// Update the task entry
			TaskLog.MakeTaskEntry( State.TaskId, State.NavigationGraph, State.CurrentView, DateTime.Now );

			// Store the info into the state
			State["Form4btnNext"] = someState;
			
			// Navigate to the next view
			State.NavigateValue = "next";
			Navigate();
		}

		/// <summary>
		/// Handles the next button click event on form5 class
		/// </summary>
		/// <param name="someState">some info, wich will be passed to the next navigation graph</param>
		public void Form5btnNext( string someState )
		{
			// Update the task entry
			TaskLog.MakeTaskEntry( State.TaskId, State.NavigationGraph,   State.CurrentView, DateTime.Now );
			
			SuspendTask();
			
			// Navigate to the previous navigation graph
			OnStartTask( MyState.PreviousNavGraph, 
				new TaskArgumentsHolder( State.TaskId, State.NavigationGraph, someState ), 
				new Task(MyState.PreviousTaskID) );
		}

		/// <summary>
		/// Handles the previous button click event on form5 class
		/// </summary>
		public void Form5btnPrevious()
		{
			// Update the task entry
			TaskLog.MakeTaskEntry( State.TaskId, State.NavigationGraph, State.CurrentView, DateTime.Now );

			// Navigate to the next view
			State.NavigateValue = "previous";
			Navigate();
		}

		/// <summary>
		/// Completes the task. Remove the TaskLog
		/// </summary>
		public override void CompleteTask() 
		{
			base.CompleteTask();
			TaskLog.RemoveTaskEntry( State.TaskId );
			TaskLog.RemoveTaskEntry( MyState.PreviousTaskID);

		}
	}
}
