//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// StartTaskEventArgs.cs
//
// This file contains the implementations StartTaskEventArgs and StartTaskEventHandler classes.
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
	/// Represents the method that will handle the StartTask event.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">A StartTaskEventArgs object that contains the event data.</param>
	public delegate void StartTaskEventHandler(object sender, StartTaskEventArgs e);
    
	/// <summary>
	/// Provides data for the StartTask event.
	/// </summary>
	public class StartTaskEventArgs : EventArgs
	{
		private string _nextNavGraphName = "";
		private TaskArgumentsHolder _taskArguments = null;
		private ITask _nextTask = null;

		/// <summary>
		/// Overloaded. Initializes a new StartTaskEventArgs class that assumes chaining of the navigation graphs.
		/// </summary>
		/// <param name="nextNavigationGraphName">The next navigation graph.</param>
		public StartTaskEventArgs(string nextNavigationGraphName) 
			: this(nextNavigationGraphName, null, null) {}
		
		/// <summary>
		/// Overloaded. Initializes a new StartTaskEventArgs class that assumes chaining of the navigation graphs, and 
		/// the need for all information relevant to having a return pointer on a stack.
		/// </summary>
		/// <param name="nextNavigationGraphName">The next navigation graph.</param>
		/// <param name="taskArguments">The task arguments.</param>
		/// <param name="nextTask">A known point in a previously used navigation graph.</param>
		public StartTaskEventArgs(string nextNavigationGraphName, TaskArgumentsHolder taskArguments, ITask nextTask) 
		{
			_nextNavGraphName = nextNavigationGraphName;
			_taskArguments = taskArguments;
			_nextTask = nextTask;
		}
        
		/// <summary>
		/// Gets the next navigation graph name.
		/// </summary>
		public string NextNavigationGraph
		{
			get { return _nextNavGraphName; }
		}

		/// <summary>
		/// Gets the the task arguments.
		/// </summary>
		public TaskArgumentsHolder TaskArguments
		{
			get { return _taskArguments; }
		}

		/// <summary>
		/// Gets the next task.
		/// </summary>
		public ITask NextTask
		{
			get { return _nextTask; }
		}

	}
}
