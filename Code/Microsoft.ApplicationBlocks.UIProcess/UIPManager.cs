//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// UIPManager.cs
//
// This file contains the implementations of the UIPManager class
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
using System.Collections;


namespace Microsoft.ApplicationBlocks.UIProcess
{
	#region UIPManager class
	/// <summary>
	/// This class allows the UIPManager to dispense controllers to views, 
	/// sense when controllers have finished, spawn new views,
	/// and coordinate tasks.
	/// </summary>
	public sealed class UIPManager
	{
		#region Variable Declarations

		/// <summary>
		/// Delegates for the NavigateEvent.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">A NavigateEventArgs object that contains the event data.</param>
		public delegate void NavigateEventHandler(object sender, NavigateEventArgs e);

		/// <summary>
		/// Occurs when navigation occurs.
		/// </summary>
		public static event NavigateEventHandler NavigateEvent;

		private static ArrayList _registeredShutdownListeners;

		#endregion

		#region Constructors

		/// <summary>
		/// Static constructor.
		/// </summary>
		static UIPManager()
		{
			_registeredShutdownListeners = new ArrayList(1);
		}

		/// <summary>
		/// Adds a shutdown listener that is invoked when all views have been closed.
		/// </summary>
		/// <param name="shutdownListener">The shutdown listener.</param>
		public static void RegisterShutdown(IShutdownUIP shutdownListener)
		{
			_registeredShutdownListeners.Add(shutdownListener);
		}

		internal static void OnCompletion()
		{
			foreach (IViewManager view in ViewManagerFactory.GetViewManagers())
			{
				if(view.GetActiveViewCount() > 0)
				{
					return;
				}
			}
			NotifyShutdownListeners();
		}

		private static void NotifyShutdownListeners()
		{
			foreach(IShutdownUIP listener in _registeredShutdownListeners)
			{
				listener.Shutdown();
			}
		}

		#endregion

		#region Start Task overloads
		/// <summary>
		/// Starts a UIProcess for navigation.
		/// </summary>
		/// <param name="navGraph">The name of the navigationGraph element in app.config. </param>
		public static void StartNavigationTask(string navGraph)
		{
			NavigationGraphSettings navGraphSettings = UIPConfiguration.Config.GetNavigationGraphSettings(navGraph);
			GraphNavigator navigator = (navGraphSettings.RunInWizardMode) ? new WizardNavigator(navGraph) : new GraphNavigator(navGraph);
			navigator.StartTask();
		}

		/// <summary>
		/// Starts a UIProcess for navigation.
		/// </summary>
		/// <param name="navGraph">The name of the navigationGraph element in app.config.</param>
		/// <param name="task">The task name.</param>
		public static void StartNavigationTask(string navGraph, ITask task)
		{
			GraphNavigator navigator = new GraphNavigator(navGraph);
			navigator.StartTask(task, null);
		}

		/// <summary>
		/// Starts a UIProcess for navigation.
		/// </summary>
		/// <param name="navGraph">The name of the navigationGraph element in app.config. </param>
		/// <param name="taskId">The task identifier (a GUID associated with the task).</param>
		public static void StartNavigationTask(string navGraph, Guid taskId)
		{
			GraphNavigator navigator = new GraphNavigator(navGraph);
			navigator.StartTask(taskId, null);
		}

		/// <summary>
		/// Starts a UIProcess for open navigation.
		/// </summary>
		/// <param name="name">The name of the navigationGraph element in app.config.</param>
		/// <param name="task">The task name.</param>
		public static void StartOpenNavigationTask(string name, ITask task)
		{
			OpenNavigator navigator = new OpenNavigator(name);
			navigator.StartTask(task);
		}

		/// <summary>
		/// Starts a UIProcess for open navigation.
		/// </summary>
		/// <param name="name">The name of the navigationGraph element in app.config.</param>
		/// <param name="taskId">The task identifier (a GUID associated with the task).</param>
		public static void StartOpenNavigationTask(string name, Guid taskId)
		{
			OpenNavigator navigator = new OpenNavigator(name);
			navigator.StartTask(taskId);
		}

		/// <summary>
		/// Starts a UIProcess for open navigation.
		/// </summary>
		/// <param name="name">The name of the navigationGraph element in app.config. </param>
		/// <param name="firstViewName">The first view to be activated.</param>
		public static void StartOpenNavigationTask(string name, string firstViewName)
		{
			OpenNavigator navigator = new OpenNavigator(name);
			navigator.StartTask(firstViewName);
		}

		/// <summary>
		/// Starts a UIProcess for open navigation.
		/// </summary>
		/// <param name="name">The name of the navigationGraph element in app.config.</param>
		/// <param name="firstViewName">The first view to be activated.</param>
		/// <param name="task">The task name.</param>
		public static void StartOpenNavigationTask(string name, string firstViewName, ITask task)
		{
			OpenNavigator navigator = new OpenNavigator(name);
			navigator.StartTask(firstViewName, task);
		}

		/// <summary>
		/// Starts a UIProcess for hosted controls.
		/// </summary>
		/// <param name="name">The name of the hostedControl element in app.config.</param>
		public static void StartUserControlsTask(string name)
		{
		  StartUserControlsTask(name, null, null);
		}

		/// <summary>
		/// Starts a UIProcess for hosted controls.
		/// </summary>
		/// <param name="name">The name of the hostedControl element in app.config.</param>
		/// <param name="task">The task name.</param>
		public static void StartUserControlsTask(string name, ITask task)
		{
		  StartUserControlsTask(name, task, null);
		}

		/// <summary>
		/// Starts a UIProcess for hosted controls.
		/// </summary>
		/// <param name="name">The name of the hostedControl element in app.config.</param>
		/// <param name="taskId">The task identifier (a GUID associated with the task).</param>
		public static void StartUserControlsTask(string name, Guid taskId)
		{
		  StartUserControlsTask(name, taskId, null);
		}

		/// <summary>
		/// Starts a UIProcess for hosted controls.
		/// </summary>
		/// <param name="name">The name of the hostedControl element in app.config.</param>
		/// <param name="task">The task name.</param>
		/// <param name="args">Arguments to the view.</param>
		public static void StartUserControlsTask(string name, ITask task, TaskArgumentsHolder args)
		{
		  UserControlsNavigator navigator = new UserControlsNavigator(name);
			navigator.StartTask(task, args);
		}

		/// <summary>
		/// Starts a UIProcess for hosted controls.
		/// </summary>
		/// <param name="name">The name of the hostedControl element in app.config.</param>
		/// <param name="taskId">The task identifier (a GUID associated with the task).</param>
		/// <param name="args">Arguments to the view.</param>
		public static void StartUserControlsTask(string name, Guid taskId, TaskArgumentsHolder args)
		{
		  UserControlsNavigator navigator = new UserControlsNavigator(name);
			navigator.StartTask(taskId, args);
		}
		#endregion

		#region Navigation Code
		/// <summary>
		/// Called by all classes that wish to alert all listeners for NavigateEvent that navigation has occurred.
		/// </summary>
		/// <param name="state">The current state.</param>
		public static void InvokeEventHandlers(State state)
		{
			if(NavigateEvent != null)
			{
				NavigateEventArgs navigateArgs = new NavigateEventArgs(state);
				NavigateEvent(null, navigateArgs);
			}
		}
		#endregion
	}

	#endregion
}
