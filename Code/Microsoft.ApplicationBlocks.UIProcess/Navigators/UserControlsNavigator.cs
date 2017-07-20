//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// HostedControlsNavigator.cs
//
// This file contains the implementations of the HostedControlsNavigator class.
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
	/// Provides navigation services for Windows Forms applications with UserControls.
	/// </summary>
	public class UserControlsNavigator : Navigator
	{
		private UserControlsSettings _settings;

		/// <summary>
		/// Creates a HostedControlsNavigator.
		/// </summary>
		/// <param name="name">The name of the navigator from the configuration file.</param>
		public UserControlsNavigator(string name)
		{
			Name = name;
			_settings = UIPConfiguration.Config.GetHostedControlsSettings(name);
			ViewManager = ViewManagerFactory.Create(name);
			SetState(StateFactory.Create(name));
		}

		/// <summary>
		/// The expiration mode of the state cache for this task.
		/// <see cref="CacheExpirationMode"/>
		/// </summary>
		public override CacheExpirationMode CacheExpirationMode 
		{
			get { return _settings.CacheExpirationMode; }
		}

		/// <summary>
		/// The interval used to expire entries in the state cache.
		/// </summary>
		public override TimeSpan CacheExpirationInterval 
		{
			get { return _settings.CacheExpirationInterval; }
		}

		/// <summary>
		/// Navigates to the next node or view.
		/// </summary>
		/// <param name="nextNode">The node or view to navigate to.</param>
		public override void Navigate(string nextNode) 
		{
			string previousView = CurrentState.CurrentView;
			CurrentState.NavigateValue = nextNode;

			UIPManager.InvokeEventHandlers(CurrentState);
			CurrentState.CurrentView = CurrentState.NavigateValue;
			CurrentState.NavigateValue = "";
			CurrentState.Save();

			try
			{
				ViewManager.ActivateView( previousView, CurrentState.CurrentView, this );
			}
			catch( Exception ex )
			{
				throw new UIPException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionCantActivateView, nextNode )+UIPException.GetFirstExceptionMessage(ex), ex );
			}
		}

		/// <summary>
		/// Starts or resumes a task.
		/// </summary>
		/// <param name="task">The task to start or resume.</param>
		public void StartTask(ITask task) 
		{
			StartTask(task, null);
		}

		/// <summary>
		/// Starts or resumes a task, and passes optional arguments to the first view.
		/// </summary>
		/// <param name="task">The task to start or resume.</param>
		/// <param name="args">Optional arguments to pass to the first view.</param>
		public void StartTask(ITask task, TaskArgumentsHolder args) 
		{
			SetState(GetState(task));
			StartTask(args);
		}

		/// <summary>
		/// Resumes a saved task and passes optional arguments to the first view.
		/// </summary>
		/// <param name="taskId">The task identifier of the task to resume.</param>
		/// <param name="args">Optional arguments to pass to the first view.</param>
		public void StartTask(Guid taskId, TaskArgumentsHolder args) 
		{
			SetState(GetState(taskId));
			StartTask(args);
		}

		private void StartTask(TaskArgumentsHolder args) 
		{
			FormSettings hostSettings = _settings[_settings.StartFormName];
			ViewSettings startFormSettings = UIPConfiguration.Config.GetViewSettingsFromName(hostSettings.Name);
			CurrentState.CurrentView = startFormSettings.Name;
			
			try
			{
				ViewManager.ActivateView(null, startFormSettings.Name, this, args);
			}
			catch(System.Threading.ThreadAbortException) {}
			catch( Exception ex )
			{
				throw new UIPException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionCantActivateView, startFormSettings.Name )+UIPException.GetFirstExceptionMessage(ex), ex );
			}
			CurrentState.Save();
			if (hostSettings.InitialView != null) 
			{
				Navigate(hostSettings.InitialView);
			}
		}

		/// <summary>
		/// Returns the name of a child view from the name of a node.
		/// </summary>
		/// <param name="nodeName"></param>
		/// <returns></returns>
		public override string GetViewNameFromNodeName(string nodeName)
		{
			FormSettings formSettings = _settings[CurrentState.CurrentView];
			ChildViewSettings childSettings = formSettings[nodeName];
			return childSettings.ViewName;
		}
	}
}
