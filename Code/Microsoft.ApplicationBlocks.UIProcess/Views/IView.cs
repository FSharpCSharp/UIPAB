//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// IView.cs
//
// This file contains the definitions of the IView interface.
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
using System.Xml;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// Represents a view used in Web and Windows applications.
	/// </summary>
	public interface IView
	{
		/// <summary>
		/// Gets the current view controller.
		/// </summary>
		ControllerBase Controller { get; }
        
		/// <summary>
		/// Gets the view name.
		/// </summary>
		string ViewName { get; }
        
		/// <summary>
		/// Gets the task identifier related to this view.
		/// </summary>
		Guid TaskId { get; }

		/// <summary>
		/// Gets the context in which the view is executing.
		/// </summary>
		Navigator Navigator { get; }

		/// <summary>
		/// Called when a WinFormControlView gains or loses focus.
		/// </summary>
		/// <param name="enabled">True if gaining focus. False otherwise.</param>
		void Enable(bool enabled);

		/// <summary>
		/// Called after the view manager instantiates the view, but before calling <code>Show().</code>
		/// </summary>
		/// <param name="args">Optional arguments passed in when starting the task.</param>
		/// <param name="settings">The ViewSettings.</param>
		void Initialize(TaskArgumentsHolder args, ViewSettings settings);
	}
}
