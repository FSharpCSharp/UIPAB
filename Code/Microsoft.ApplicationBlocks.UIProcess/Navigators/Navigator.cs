//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// Navigator.cs
//
// This file contains the implementations of the Navigator class.
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
	/// Navigators provide navigation services to controllers, and start tasks.
	/// </summary>
	public abstract class Navigator
	{
		private IViewManager _viewManager;
		private string _name;
		private State _state;

		/// <summary>
		/// The view manager used. 
		/// </summary>
		public IViewManager ViewManager 
		{
			get { return _viewManager; }
			set { _viewManager = value; }
		}

		/// <summary>
		/// The name of the navigator.
		/// </summary>
		public string Name 
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// The current state of the navigator.
		/// </summary>
		public State CurrentState 
		{
			get { return _state; }
		}

		/// <summary>
		/// Used to set the state during construction of a navigator.
		/// </summary>
		/// <param name="state">State object for this navigator.</param>
		protected void SetState(State state)
		{
			_state = state;
		}

		/// <summary>
		/// The expiration mode of the state cache for this task.
		/// <see cref="CacheExpirationMode"/>
		/// </summary>
		public abstract CacheExpirationMode CacheExpirationMode 
		{
			get;
		}

		/// <summary>
		/// The interval used to expire entries in the state cache.
		/// </summary>
		public abstract TimeSpan CacheExpirationInterval 
		{
			get;
		}

		/// <summary>
		/// Navigates to the next node.
		/// </summary>
		/// <param name="nextNode">The node or view that will display next.</param>
		public abstract void Navigate(string nextNode); 

		/// <summary>
		/// Creates the controller for this view.
		/// </summary>
		/// <param name="view">The view that needs a controller.</param>
		/// <returns></returns>
		public ControllerBase GetController(IView view) 
		{						
			ActivateViewInStateIfNecessary(view);

			ControllerBase controller = GetControllerForView(view);
			controller.StartTask += new StartTaskEventHandler(OnStartTask);
			return controller;
		}

		
		private void ActivateViewInStateIfNecessary(IView view)
		{
			if (! _viewManager.IsRequestCurrentView(view,_state.CurrentView))
			{
				if (! UIPConfiguration.Config.AllowBackButton)
					_viewManager.ActivateView(null,_state.CurrentView,this);
				else
				{
					if (RunningInNavGraph)
					{
						if (! UIPConfiguration.Config.ViewExistsInNavigationGraph(_state.NavigationGraph,_viewManager.GetViewNameForCurrentRequest(view)))
							_viewManager.ActivateView(null,_state.CurrentView,this);
					}
				}
			}
		}


		private ControllerBase GetControllerForView(IView view)
		{
			string viewForController=view.ViewName;				
			
			if (! _viewManager.IsRequestCurrentView(view,_state.CurrentView))	
			{	
				if (UIPConfiguration.Config.AllowBackButton)								
				{
					viewForController = _viewManager.GetViewNameForCurrentRequest(view);
					if (RunningInNavGraph)
					{
						if (UIPConfiguration.Config.ViewExistsInNavigationGraph(_state.NavigationGraph,viewForController))						
							_state.CurrentView = viewForController;						
					}	
					else
					{
						_state.CurrentView = viewForController;
					}
				}					
			}

			return ControllerFactory.Create(viewForController,this);			
		}


		private bool RunningInNavGraph
		{
			get
			{
				return (_state.NavigationGraph != null && _state.NavigationGraph.Trim().Length> 0);
			}
		}				

		/// <summary>
		/// Handles any StartTask events raised by a controller.
		/// </summary>
		/// <param name="sender">Controller that raised the event.</param>
		/// <param name="e">Arguments used by the event handler.</param>
		public virtual void OnStartTask(object sender, StartTaskEventArgs e)
		{
			if (UIPConfiguration.Config.ContainsNavigationGraphSettings(e.NextNavigationGraph)) 
			{
				NavigationGraphSettings settings = UIPConfiguration.Config.GetNavigationGraphSettings(e.NextNavigationGraph);
				if (settings.RunInWizardMode)
				{
					WizardNavigator navigator = new WizardNavigator(e.NextNavigationGraph);
					navigator.StartTask(e.NextTask, e.TaskArguments);
				}
				else
				{
					GraphNavigator navigator = new GraphNavigator(e.NextNavigationGraph);
					navigator.StartTask(e.NextTask, e.TaskArguments);
				}
				
				
				return;
			} 
			else if (UIPConfiguration.Config.ContainsHostedControlsSettings(e.NextNavigationGraph)) 
			{
			  UserControlsNavigator navigator = new UserControlsNavigator(e.NextNavigationGraph);
				navigator.StartTask(e.NextTask);
				return;
			}
			OpenNavigator newNavigator = new OpenNavigator("new");
			newNavigator.StartTask(e.NextNavigationGraph, e.NextTask);
		}

		/// <summary>
		/// Creates or loads the state for this task.
		/// </summary>
		/// <param name="task">The task to create or load state for.</param>
		/// <returns></returns>
		protected State GetState(ITask task) 
		{
			State _state = null;
			Guid taskId = Guid.Empty;

			// THREE-WAY DECISION:
			// 1) no ITask object--assume new Task, create new TaskID, create new State
			// 2) ITask object, but no valid TaskID--assume new Task, create new State
			// 3) ITask object, valid TaskID--assume known Task, retrieve known State
			// 
			// CASE (1): 
			// if incoming ITask is null, we KNOW this is a new Task. Act appropriately--create new Task/State
			if ( null == task ) 
			{
				_state = CreateState();
				taskId = _state.TaskId;
			}
			else
			{
				// ask the incoming ITask if it has a TaskID already. 
				// this would mean the application has already hooked up a Task ID to whatever representation it uses...
				// for example, correlating TaskID to windows logon

				taskId = task.Get();
				_state = GetState(taskId);

				if ( Guid.Empty == taskId ) 
				{
					// tell the taskObject (which is our sink back into client application) about the new TaskID
					task.Create(_state.TaskId);
				}
			}

			return _state;
		}

		/// <summary>
		/// Creates or loads state for this task.
		/// </summary>
		/// <param name="taskId">The identifier of the task to load or create state for.</param>
		/// <returns></returns>
		protected State GetState(Guid taskId) 
		{
			State _state = null;

			if ( Guid.Empty == taskId ) 
			{
				// CASE (2) 
				// OK, the application has not pre-set a task. Therefore tell application what the new TaskId is, 
				// and internally the client app will use it...for example, by creating an entry 
				// in its DB lookup table to correlate logon with Task.

				// set up the new State object, since we know now that we're on a new Task so we need new State
				_state = CreateState();
				// new State now contains new TaskID, get it here
				taskId = _state.TaskId;
				// tell the taskObject (which is our sink back into client application) about the new TaskID
			}
			else
			{
				// CASE
				// in this case, ITask was not null, AND it returned a valid TaskID...
				// SO this is a known Task...and there is a State for it. Retrieve that State.
				_state = LoadState(taskId);
			}

			return _state;
		}

		/// <summary>
		/// Creates a State object using the type specified in the configuration file for this navigator.
		/// Navigators can override this if they need to create state in a different way.
		/// </summary>
		/// <returns>The state that was created.</returns>
		protected virtual State CreateState() 
		{
			return StateFactory.Create(Name);
		}

		/// <summary>
		/// Loads a State object using the type specified in the configuration file for this navigator and task ID.
		/// Navigators can override this if they need to load state in a different way.
		/// </summary>
		/// <param name="taskId">The identifier of the task to load the state for.</param>
		/// <returns>The state that was created.</returns>		
		protected virtual State LoadState(Guid taskId) 
		{
			return StateFactory.Load( Name, taskId );
		}

		/// <summary>
		/// Used to retrieve the name of a view from a particular node. Meant to be overriden by derived
		/// navigators that need to implement this functionality.
		/// </summary>
		/// <param name="nodeName"></param>
		/// <returns></returns>
		public virtual string GetViewNameFromNodeName(string nodeName)
		{
		  return null;
		}
	}
}
