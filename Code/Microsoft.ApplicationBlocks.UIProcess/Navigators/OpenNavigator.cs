//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// OpenNavigator.cs
//
// This file contains the implementations of the OpenNavigator class.
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
	/// Navigator used when transitions between views are made. To use this navigator, specify the view names 
	/// to transition to.
	/// </summary>
	public class OpenNavigator : Navigator
	{
		private ViewSettings _startView;
		private CacheConfiguration  _cacheConfiguration;

		/// <summary>
		/// Overrides. Initializes a new OpenNavigator.
		/// </summary>
		/// <param name="name">The name of the navigation graph to which open navigation applies.</param>
		public OpenNavigator(string name) 
		{
			Name = name;
			ViewManager = ViewManagerFactory.Create();
			SetState(StateFactory.Create());
			_cacheConfiguration = UIPConfiguration.Config.GetCacheConfiguration();

		}

		/// <summary>
		/// Overloaded. Initializes a new OpenNavigator.
		/// </summary>
		/// <param name="name">The name of the navigation graph to which open navigation applies.</param>
		/// <param name="taskId">The task identifier (a GUID associated with the task).</param>
		public OpenNavigator(string name, Guid taskId)
		{
			Name = name;
			ViewManager = ViewManagerFactory.Create();
			SetState(StateFactory.Load(name, taskId));
			_cacheConfiguration = UIPConfiguration.Config.GetCacheConfiguration();
		}

		/// <summary>
		/// Gets the Timespan object that represents the life span of the OpenNavigator.
		/// </summary>
		public override TimeSpan CacheExpirationInterval
		{
			get
			{
				return _cacheConfiguration.Interval;
			}
		}

		/// <summary>
		/// Gets the <see cref="Microsoft.ApplicationBlocks.UIProcess.CacheExpirationMode"/> for the OpenNavigator.
		/// </summary>
		public override CacheExpirationMode CacheExpirationMode
		{
			get
			{
				return _cacheConfiguration.Mode;
			}
		}

		/// <summary>
		/// Activates the next view.
		/// </summary>
		/// <param name="nextView">The name of the next view to be activated.</param>
		public override void Navigate(string nextView) 
		{
			string previousView = CurrentState.CurrentView;
			CurrentState.CurrentView = nextView;
			CurrentState.NavigateValue = "";
			
			UIPManager.InvokeEventHandlers(CurrentState);
			CurrentState.Save();
			try
			{
				ViewManager.ActivateView( previousView, CurrentState.CurrentView, this );
			}
			catch(System.Threading.ThreadAbortException) {}
			catch( Exception ex )
			{
				throw new UIPException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionCantActivateView, nextView )+UIPException.GetFirstExceptionMessage(ex), ex );
			}
		}

		/// <summary>
		/// Overloaded. Starts open navigation, beginning with specified first view.
		/// </summary>
		/// <param name="firstView">The name of the first view.</param>
		public void StartTask(string firstView) 
		{
		    StartTask(firstView, null, null);
		}

		/// <summary>
		/// Overloaded. Starts open navigation for a specified task.
		/// </summary>
		/// <param name="task">The name of the task.</param>
		public void StartTask(ITask task)
		{
			StartTask(null, task, null);
		}

		/// <summary>
		/// Overloaded. Starts open navigation beginning with the specified first view for the specified task.
		/// </summary>
		/// <param name="firstView">The name of the first view.</param>
		/// <param name="task">The name of the task.</param>
		public void StartTask(string firstView, ITask task)
		{
			StartTask(firstView, task, null);
		}

		/// <summary>
		/// Overloaded. Starts open navigation for the specified task.
		/// </summary>
		/// <param name="task">The name of the task.</param>
		/// <param name="args">Additional navigation arguments.</param>
		public void StartTask(ITask task, TaskArgumentsHolder args) 
		{
			StartTask(null, task, args);
		}

		/// <summary>
		/// Overloaded. Starts open navigation, beginning with the first view for the specified task.
		/// </summary>
		/// <param name="firstView">The name of the first view.</param>
		/// <param name="task">The name of the task.</param>
		/// <param name="args">Additional navigation arguments.</param>
		public void StartTask(string firstView, ITask task, TaskArgumentsHolder args) 
		{
			SetState(GetState(task));
			StartTask(firstView, args);
		}

		/// <summary>
		/// Overloaded. Starts open navigation for the specified task identifier.
		/// </summary>
		/// <param name="taskId">The task identifier (a GUID associated with the task).</param>
		public void StartTask(Guid taskId) 
		{
			StartTask(taskId, null);
		}

		/// <summary>
		/// Overloaded. Starts open navigation for the specified task identifier.
		/// </summary>
		/// <param name="taskId">The task identifier (a GUID associated with the task).</param>
		/// <param name="args">Additional navigation arguments.</param>
		public void StartTask(Guid taskId, TaskArgumentsHolder args) 
		{
			SetState(GetState(taskId));
			StartTask(string.Empty, args);
		}

		/// <summary>
		/// Overloaded. Starts open navigation beginning with the first view.
		/// </summary>
		/// <param name="firstView">The name of the first view.</param>
		/// <param name="args">Additional navigation arguments.</param>
		public void StartTask(string firstView, TaskArgumentsHolder args) 
		{
			string startViewName = null;
			if (CurrentState.CurrentView != null && CurrentState.CurrentView.Length > 0) 
			{
				startViewName = CurrentState.CurrentView;
				_startView = UIPConfiguration.Config.GetViewSettingsFromName(CurrentState.CurrentView);
			} 
			else if (firstView != null && firstView.Length > 0) 
			{
				startViewName = firstView;
				_startView = UIPConfiguration.Config.GetViewSettingsFromName(firstView);
			}
			if (_startView == null)
				throw new UIPException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionViewConfigNotFound, startViewName ) );

			StartTask(args);
		}

		private void StartTask(TaskArgumentsHolder args) 
		{
			ControllerBase firstController = ControllerFactory.Create(_startView.Name,this);
			firstController.EnterTask(null);
			CurrentState.CurrentView = _startView.Name;
			CurrentState.Save();
			try
			{
				ViewManager.ActivateView(null, _startView.Name, this, args);
			}
			catch(System.Threading.ThreadAbortException) {}
			catch( Exception ex )
			{
				throw new UIPException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionCantActivateView, _startView.Name )+UIPException.GetFirstExceptionMessage(ex), ex );
			}
			
		}

		/// <summary>
		/// Overrides. Creates a new <see cref="Microsoft.ApplicationBlocks.UIProcess.State"/> for OpenNavigation.
		/// </summary>
		/// <returns></returns>
		protected override State CreateState()
		{
			return StateFactory.Create();
		}

		/// <summary>
		/// Overrides. Loads the <see cref="Microsoft.ApplicationBlocks.UIProcess.State"/> of the OpenNavigator for the given task ID.
		/// </summary>
		/// <param name="taskId">The task identifier (a GUID associated with the task).</param>
		/// <returns>The loaded state.</returns>
		protected override State LoadState(Guid taskId)
		{
			return StateFactory.Load(taskId);
		}
	}
}
