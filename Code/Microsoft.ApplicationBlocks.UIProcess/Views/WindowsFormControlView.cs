//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// WinFormControlView.cs
//
// This file contains the implementations of the WinFormControlView class.
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
using System.Windows.Forms;
using System.Xml;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// Represents a view used in a Windows applications.
	/// </summary>
	public class WindowsFormControlView : UserControl, IView
	{
		#region Declares variables
		private ControllerBase _controller;
		private Guid _taskId;
		private string _navigationGraph;
		private string _viewName;
		private Navigator _navigator;
		#endregion

		/// <summary>
		/// Constructor.
		/// </summary>
		public WindowsFormControlView()
		{
			this.Load += new EventHandler(WinFormControlLoad);
		}
		#region IView Members


		/// <summary>
		/// Gets the controller for this WinFormControlView.
		/// </summary>
		public ControllerBase Controller
		{
			get
			{
				return _controller;
			}
		}


		/// <summary>
		/// Gets the name of this WinFormControlView.
		/// </summary>
		public string ViewName
		{
			get
			{
				return _viewName;
			}
		}

		/// <summary>
		/// Gets the UIProcess initiating task that owns this WinFormControlView.
		/// </summary>
		public Guid TaskId
		{
			get
			{
				return _taskId;
			}
		}

		/// <summary>
		/// Gets the navigator used by the WinFormControlView.
		/// </summary>
		public Navigator Navigator 
		{
			get { return _navigator; }
		}

		/// <summary>
		/// True enables the WinFormControlView. False disables the WinFormView.
		/// </summary>
		/// <param name="enabled"></param>
		public virtual void Enable(bool enabled) 
		{
			//call normal enable
		}

		/// <summary>
		/// Initializes the WinFormControlView.
		/// </summary>
		/// <param name="args">The initialization arguments.</param>
		/// <param name="settings">The settings for the view.</param>
		public virtual void Initialize(TaskArgumentsHolder args, ViewSettings settings)
		{
		}

		#endregion

		#region Internal properties
		/// <summary>
		/// Gets the current task identifier.
		/// </summary>
		protected internal Guid InternalTaskId
		{
			set { _taskId = value; }
		}
        
		/// <summary>
		/// Gets the current navigation graph.
		/// </summary>
		protected internal string InternalNavigationGraph
		{
			set{ _navigationGraph = value; }
			get { return _navigationGraph; }
		}

		/// <summary>
		/// Gets the view name.
		/// </summary>
		public string InternalViewName
		{
			set {_viewName = value; }
			get { return _viewName; }
		}

		/// <summary>
		/// Gets the navigator used by the WinFormControlView.
		/// </summary>
		public Navigator InternalNavigator 
		{
			set { _navigator = value; }
			get { return _navigator; }
		}

		/// <summary>
		/// Gets the controller used by the WinFormControlView.
		/// </summary>
		public ControllerBase InternalController 
		{
			set { _controller = value; }
			get { return _controller; }
		}
		#endregion


		/// <summary>
		/// Occurs when the WinFormControl is loaded.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The arguments for the event.</param>
		protected virtual void WinFormControlLoad(object sender, EventArgs e)
		{
			if ( DesignMode) 
			{
				_controller = null;
			}
			else
			{
				_controller = _navigator.GetController(this);
			}
		}
	}
}
