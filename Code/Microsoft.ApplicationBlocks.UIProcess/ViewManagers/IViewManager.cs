//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// IViewManager.cs
//
// This file contains the definitions of the IViewManager interface.
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
	/// Represents a view manager. 
	/// Each type of application has an associated view manager, making it 
	/// easier to add application types.
	/// </summary>
	public interface IViewManager
	{
		/// <summary>
		/// Stores a property in the view manager. 
		/// Each task has its own properties.
		/// </summary>
		/// <remarks>Property storage is a view manager responsibility.</remarks>
		/// <param name="name">The property name.</param>
		/// <param name="taskId">The task identifier (a GUID associated with the task).</param>
		/// <param name="value">The property value.</param>
		void StoreProperty(Guid taskId, string name, object value);
        
		/// <summary>
		/// Activates the specified view.
		/// </summary>
		/// <param name="previousView">The view currently displayed.</param>
		/// <param name="view">The name of the view to be displayed next.</param>
		/// <param name="context">The context in which the view is activated.</param>
		void ActivateView(string previousView, string view, Navigator context);

		/// <summary>
		/// Activates the specified view.
		/// </summary>
		/// <param name="previousView">The view currently displayed.</param>
		/// <param name="view">The name of the view to be displayed next.</param>
		/// <param name="context">The context in which the view is activated.</param>
		/// <param name="args">Optional arguments passed to the <code>Initialize</code> method on the view.</param>
		void ActivateView(string previousView, string view, Navigator context, TaskArgumentsHolder args);

		///<summary>
		/// Utility method that checks requests to ensure that the requested view and current view match.
		/// </summary>
		/// <param name="view">The IView requested.</param>
		/// <param name="stateViewName">The view name saved in the state.</param>
		bool IsRequestCurrentView(IView view, string stateViewName);

		/// <summary>
		/// Utility method that checks the request and gets the view name that corresponds with the request.
		/// This is used primarily to enable Back button support.
		/// </summary>
		/// <param name="currentView"></param>
		/// <returns></returns>
		string GetViewNameForCurrentRequest(IView currentView);


		/// <summary>
		/// Gets the running tasks in the manager.
		/// </summary>
		/// <returns>An array with the task identifiers.</returns>
		Guid[] GetCurrentTasks();

		/// <summary>
		/// Gets the number of active views in the manager.
		/// </summary>
		/// <returns>The count.</returns>
		int GetActiveViewCount();
	}
}
