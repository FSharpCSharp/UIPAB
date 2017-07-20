//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// WinFormView.cs
//
// This file contains the implementations of the WinFormView class
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
    #region WinFormView class definition
    /// <summary>
    /// Represents a view used in Windows applications.
    /// </summary>
	public class WindowsFormView : Form, IView
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
		public WindowsFormView()
		{
			this.Load += new EventHandler(WinFormViewOnLoad);
		}

		#region IView implementation
        
		/// <summary> 
		/// Gets the task identifier related to this view.
		/// </summary>
		public Guid TaskId { get { return _taskId; } }

		/// <summary>
		/// Gets the view name.
		/// </summary>
		public string ViewName { get { return _viewName; } }

		/// <summary>
		/// Gets the view controller.
		/// </summary>
		public ControllerBase Controller
		{
			get 
			{ 
				return _controller;
			}
		}

		/// <summary>
		/// Gets the <see cref="Microsoft.ApplicationBlocks.UIProcess.Navigator"/> associated with this WinFormView.
		/// </summary>
		public Navigator Navigator 
		{
			get { return _navigator; }
		}

		/// <summary>
		/// True enables the WinFormView. False disables the WinFormView.
		/// </summary>
		/// <param name="enabled"></param>
		public virtual void Enable(bool enabled) 
		{
		}

		/// <summary>
		/// Initializes the WinFormView.
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
			set { _navigationGraph = value; }
			get { return _navigationGraph; }
		}

		/// <summary>
		/// Gets the view name.
		/// </summary>
		public string InternalViewName
		{
			get { return _viewName; }
			set {_viewName = value; }
		}


		internal Navigator InternalNavigator
		{
			set {_navigator = value; }
			get { return _navigator; }
		}


		internal ControllerBase InternalController
		{
			set { _controller = value; }
			get { return _controller; }
		}
		
		#endregion

		/// <summary>
		/// Occurs when the WinFormView loads.
		/// </summary>
		/// <param name="source">The source of the event.</param>
		/// <param name="e">The event arguments.</param>
		public virtual void WinFormViewOnLoad( object source, EventArgs e )
		{
			//  because all WinForms in UIP apps inherit from this, 
			//  we have to be conscious of design-time problems.
			//  The full UIP can't be invoked when designing the form, so short-circuit here to avoid design time exceptions.
			if ( this.DesignMode == true ) 
			{
				_controller = null;
			}
			else
			{
				if (_navigator != null) 
				{
					_controller = _navigator.GetController(this);
				} 
			}
		}
        
		/// <summary>
		/// Attaches this WinFormView to a parent form.
		/// </summary>
		public void JoinParent()
		{
			Form formerOwner = this.Owner;
			if(formerOwner == null)
				return;
			TopLevel = false;
			Owner = null;
			formerOwner.Controls.Add(this);
		}
	 
		/// <summary>
		/// Detaches this WinFormView from its parent form.
		/// </summary>
		public void LeaveParent()
		{
			Form parent = (Form)Parent;
			if(parent == null)
				return;
			Parent.Controls.Remove(this);
			TopLevel = true;
			Owner = parent;
		}

	}
    #endregion
}
