//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// ControllerBase.cs
//
// This file contains the implementations of the ControllerBase class.
//
// For more information see the User Interface Process Application Block Implementation Overview. 
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


namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// This class coordinates the user process.
	/// It represents the controller in a Model-View-Controller pattern.
	/// </summary>
	public abstract class ControllerBase
	{
		private Navigator _navigator;

		/// <summary>
		/// Creates a controller.
		/// </summary>
		/// <param name="navigator">Provides navigation services for the controller.</param>
		protected ControllerBase(Navigator navigator) 
		{
			this._navigator = navigator;
		}

		/// <summary>
		/// Event raised when a task is being started.
		/// </summary>
		internal event StartTaskEventHandler StartTask;
        
		/// <summary>
		/// Gets the controller state.
		/// </summary>
		public State State 
		{
			get { return _navigator.CurrentState; }
		}
		
		/// <summary>
		/// Allows for a default Next button that causes the manager to navigate to the next page.
		/// </summary>
		protected virtual void Navigate() 
		{
			Navigate(_navigator.CurrentState.NavigateValue);
		}

		/// <summary>
		/// Navigates to the specified view or node.
		/// </summary>
		/// <param name="navigateValue">Name of the node or view to navigate to.</param>
		protected virtual void Navigate(string navigateValue) 
		{
			if (_navigator != null)
				_navigator.Navigate(navigateValue);
		}

		/// <summary>
		/// Ends or suspends the current task.
		/// </summary>
		protected virtual void SuspendTask ()
		{
			StateCache.RemoveFromCache(State.TaskId);
			State.Clear();
		}

		/// <summary>
		/// Navigates to the next navigation graph.
		/// </summary>
		/// <param name="nextNavigator">Name of the next navigationGraph.</param>
		protected void OnStartTask(string nextNavigator)
		{
			if(null != StartTask)
			{
				StartTask(this, new StartTaskEventArgs(nextNavigator));
			}
		}
		
		/// <summary>		
		/// Navigates to the next navigation graph.
		/// </summary>		
		/// <param name="nextNavigatorName">Name of the next navigation graph.</param>
		/// <param name="taskArguments">A holder for originating the navigation graph and task ID, and an object that
		/// the controller can use to get state information from the previous navigation graph.</param>
		/// <param name="nextTask">Task to be started.</param>
		protected void OnStartTask(string nextNavigatorName, TaskArgumentsHolder taskArguments, ITask nextTask)
		{
			if(null != StartTask)
			{
				StartTask(this, new StartTaskEventArgs(nextNavigatorName, taskArguments, nextTask));
			}
		}
				
		/// <summary>
		/// The UIPManager calls this method when a new task starts.
		/// </summary>
		/// <param name="taskArguments">A holder for originating the navigation graph and task ID, and an object that
		/// the controller can use to get state information from the previous navigation graph.</param>
		public virtual void EnterTask(TaskArgumentsHolder taskArguments)
		{
		}

		/// <summary>
		/// The navigator for this task.
		/// </summary>
		public Navigator Navigator 
		{
			get { return _navigator; }
		}

		/// <summary>
		/// Completes the task. Completing a task permanently removes any state data for the task.
		/// A completed task cannot be restarted.
		/// </summary>
		public virtual void CompleteTask() 
		{
			StateCache.RemoveFromCache(State.TaskId);
			State.Delete();
		}
	}
}
