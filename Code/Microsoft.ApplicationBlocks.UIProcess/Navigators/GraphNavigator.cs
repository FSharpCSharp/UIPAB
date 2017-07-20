//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// GraphNavigator.cs
//
// This file contains the implementations of the GraphNavigator class.
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
	/// Navigator used when transitions are defined using a NavigationGraph.
	/// </summary>
	public class GraphNavigator : Navigator
	{
		private NavigationGraphSettings _settings;

		private ViewSettings _startView;

		/// <summary>
		/// Creates a graph navigator.
		/// </summary>
		/// <param name="name">The name of the graph navigator in the configuration file.</param>
		public GraphNavigator(string name)
		{
			Initialize(name);
			SetState(StateFactory.Create(name));
		}
		
		/// <summary>
		/// Creates a graph navigator that resumes a saved task.
		/// </summary>
		/// <param name="name">The name of the graph navigator in the configuration file.</param>
		/// <param name="taskId">The task ID of a previously saved task.</param>
		public GraphNavigator(string name, Guid taskId)
		{
			Initialize(name);
			SetState(StateFactory.Load(name, taskId));
		}

		private void Initialize(string name)
		{
			Name = name;
			_settings = UIPConfiguration.Config.GetNavigationGraphSettings(name);
			ViewManager = CreateViewManager(name);
			_startView = UIPConfiguration.Config.GetFirstViewSettings(name);
		}


		/// <summary>
		/// Creates the view manager for this navigator.
		/// </summary>
		/// <param name="name">Name of the view manager to create, as defined in the configuration file.</param>
		/// <returns>The view manager.</returns>
		protected virtual IViewManager CreateViewManager(string name)
		{
			return ViewManagerFactory.Create(name);
		}

		/// <summary>
		/// The NavigationSettings from the configuration file.
		/// </summary>
		protected NavigationGraphSettings NavigationSettings
		{
			get { return _settings; }
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
		/// The first view to show as specified in the configuration file.
		/// </summary>
		public ViewSettings StartView 
		{
			get { return _startView; }
		}


		/// <summary>
		/// Starts a new task on the first view.
		/// </summary>
		public void StartTask() 
		{
			StartTask(null, null);
		}

		/// <summary>
		/// Resumes an existing task or begins a new one, passing the TaskArgumentsHolder to the controller of the first view.
		/// </summary>
		/// <param name="task">The task to resume.</param>
		/// <param name="holder">The holder for any arguments to pass to the controller of the first view. Can be null.</param>
		public void StartTask(ITask task, TaskArgumentsHolder holder) 
		{
			SetState(GetState(task));
			StartTask(holder);
		}		

		/// <summary>
		/// Resumes an existing task, passing the TaskArgumentsHolder to the controller of the first view.
		/// </summary>
		/// <param name="taskId">The identifier of the task to resume.</param>
		/// <param name="holder">The holder for any arguments to pass to the controller of the first view. Can be null.</param>
		public void StartTask(Guid taskId, TaskArgumentsHolder holder) 
		{
			SetState(GetState(taskId));
			StartTask(holder);
		}

		private void StartTask(TaskArgumentsHolder holder) 
		{
			CurrentState.NavigationGraph = Name;
			if (CurrentState.CurrentView != null && CurrentState.CurrentView.Length > 0)
				_startView = UIPConfiguration.Config.GetViewSettingsFromName(CurrentState.CurrentView);
			ControllerBase firstController = ControllerFactory.Create(StartView.Name, this);
			firstController.EnterTask(holder);
			CurrentState.CurrentView = StartView.Name;
			CurrentState.NavigateValue = "";
			CurrentState.Save();
			
			try
			{
				ViewManager.ActivateView(null, StartView.Name, this);
			}
			catch(System.Threading.ThreadAbortException) {}
			catch( Exception ex )
			{
				throw new UIPException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionCantActivateView, StartView.Name )+UIPException.GetFirstExceptionMessage(ex), ex );
			}
		}

		/// <summary>
		/// Navigates to the next node in the navigation graph.
		/// </summary>
		/// <param name="nextNode">The next node.</param>
		public override void Navigate(string nextNode) 
		{
			string previousView = CurrentState.CurrentView;
			CurrentState.NavigateValue = nextNode;

			UIPManager.InvokeEventHandlers(CurrentState);

			ViewSettings nextView = UIPConfiguration.Config.GetNextViewSettings(
				Name, 
				CurrentState.CurrentView, 
				CurrentState.NavigateValue);

			CurrentState.CurrentView = nextView.Name;
			CurrentState.NavigateValue = "";
			CurrentState.Save();

			try
			{
				ActivateNextView( previousView, CurrentState.CurrentView);
			}
			catch(System.Threading.ThreadAbortException) {}
			catch( Exception ex )
			{
				throw new UIPException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionCantActivateView, nextView.Name )+UIPException.GetFirstExceptionMessage(ex), ex );
			}
		}

		/// <summary>
		/// Activates the next view.
		/// </summary>
		/// <param name="previousView">The view currently displayed.</param>
		/// <param name="currentView">The name of the view to be displayed next.</param>
		protected virtual void ActivateNextView(string previousView, string currentView)
		{
			ViewManager.ActivateView(previousView, CurrentState.CurrentView, this );
		}
	}
}
