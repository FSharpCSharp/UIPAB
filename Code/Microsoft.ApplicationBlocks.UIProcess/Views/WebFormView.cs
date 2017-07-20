//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// WebFormView.cs
//
// This file contains the implementations of the WebFormView class
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
using System.Web.UI; 
using System.Xml;

namespace Microsoft.ApplicationBlocks.UIProcess
{
    #region WebFormView class definition
    /// <summary>
	/// Represents a view used in Web applications.
	/// </summary>
	public class WebFormView : Page, IView
	{
		#region Declares variables
		private ControllerBase _controller;
		private SessionMoniker _sessionMoniker;
        
		/// <summary>
		/// The QueryString key used to get the current task identifier.
		/// </summary>
		public const string CurrentTaskKey = "CurrentTask";
		#endregion

		#region Constructor
		/// <summary>
		/// Default constructor.
		/// </summary>
		public WebFormView()
		{
			this.Load += new EventHandler(WebFormView_Load);
		}
		#endregion

		#region IView implementation 

		/// <summary>
		/// Gets the view controller.
		/// </summary>
		public ControllerBase Controller
		{
			get { return _controller; }
		}

		/// <summary>
		/// Gets the task identifier related to this view.
		/// </summary>
		public Guid TaskId 
		{
			get{ return _sessionMoniker.TaskId; }
		}


		/// <summary>
		/// Gets the view name.
		/// </summary>
		public string ViewName
		{
			get{ return _sessionMoniker.CurrentViewName; }
		}

		/// <summary>
		/// Gets the navigator used by this WebFormView.
		/// </summary>
		public Navigator Navigator
		{
			get { return null; }
		}

		/// <summary>
		/// No implementation for this in WebFormViews.
		/// </summary>
		/// <param name="enabled"></param>
		public void Enable(bool enabled) 
		{
		}
        
		/// <summary>
		/// Initializes the WebFormView.
		/// </summary>
		/// <param name="args">The initialization arguments.</param>
		/// <param name="settings">The settings for the view.</param>
		public virtual void Initialize(TaskArgumentsHolder args, ViewSettings settings)
		{
		}

		#endregion
        
		private void WebFormView_Load(object sender, System.EventArgs e)
		{         
			_sessionMoniker = GetSessionMoniker();			
			Navigator navigator = GetNavigator(_sessionMoniker.NavGraphName,_sessionMoniker.TaskId);
			_controller = navigator.GetController(this);
		}

		private SessionMoniker GetSessionMoniker()
		{			
			SessionMoniker sessionMoniker = SessionMoniker.GetFromSession( new Guid( Session[CurrentTaskKey].ToString() ) );
			return sessionMoniker;
		}

		private Navigator GetNavigator(string navigationGraphName,Guid taskId)
		{			
			Navigator navigator = null;

			try
			{
				navigator = new GraphNavigator(navigationGraphName,taskId);
			}
			catch (UIPException)
			{
				navigator = new OpenNavigator(navigationGraphName,taskId);
			}

			return navigator;
		}
	}
    #endregion
}
