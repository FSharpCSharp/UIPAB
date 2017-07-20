//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// WinFormViewManager.cs
//
// This file contains the implementations of the WindowsFormViewManager class
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
using System.Windows.Forms;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	#region WindowsFormViewManager class definition
	/// <summary>
	/// Provides methods to manipulate Windows Form views. 
	/// </summary>
	public class WindowsFormViewManager : IViewManager
	{
		#region Declares variables
		private const string CommaSeparator = ",";
		private const string ParentFormKey = "ParentForm";

		//Stores active forms 
		private static Hashtable _activeForms = new Hashtable();
        
		//Stores active views
		private static Hashtable _activeViews = new Hashtable();

		//Stores active views
		private static Hashtable _properties  = new Hashtable(); 

		//Stores active controls
		private static Hashtable _activeControls = new Hashtable();

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor.
		/// </summary>
		public WindowsFormViewManager( )
		{
		}

		#endregion

		#region IViewManager Members

		private object GetProperty( Guid taskId, string name )
		{
			Hashtable taskProperties  = (Hashtable)_properties [taskId];
			if( taskProperties  != null )
				return taskProperties [name];
			else return null;
		}

		/// <summary>
		/// Stores a property in the view manager. 
		/// Each task has its own properties.
		/// </summary>
		/// <remarks>Property storage is a view manager responsibility.</remarks>
		/// <param name="taskId">The task identifier (a GUID associated with the task).</param>
		/// <param name="name">The property name.</param>
		/// <param name="value">The property value.</param>
		public void StoreProperty( Guid taskId, string name, object value )
		{
			if( _properties [taskId] == null )
				_properties [taskId] = new Hashtable();

			((Hashtable)_properties [taskId])[name] = value;
		}

		/// <summary>
		/// Activates a specific view.
		/// </summary>
		/// <param name="previousView">The view currently displayed.</param>
		/// <param name="view">The name of the view to be displayed next.</param>
		/// <param name="navigator">The navigator.</param>
		public void ActivateView( string previousView, string view, Navigator navigator ) 
		{
			ActivateView(previousView, view, navigator, null);
		}

		/// <summary>
		/// Activates a specific view with activation arguments.
		/// </summary>
		/// <param name="previousView">The view currently displayed.</param>
		/// <param name="view">The name of the view to be displayed next.</param>
		/// <param name="navigator">The navigator.</param>
		/// <param name="args">The arguments for the next view.</param>
		public void ActivateView( string previousView, string view, Navigator navigator, TaskArgumentsHolder args )
		{
			Guid taskId = navigator.CurrentState.TaskId;
			InitiailizeFormAndViews(taskId);

			WindowsFormView winFormView = GetActiveForm(taskId, view);
			WindowsFormControlView controlView = GetActiveControl(taskId, view);

			ViewSettings viewSettings = null;
			if (winFormView != null)
			{
				winFormView.Activate();
				winFormView.Visible = true;
				viewSettings = UIPConfiguration.Config.GetViewSettingsFromName(winFormView.ViewName);
				ClosePreviousFormIfNecessary(winFormView, previousView, taskId, viewSettings);
			}
			else if(controlView != null) 
			{
				ActivateControl(controlView, previousView);
				viewSettings = UIPConfiguration.Config.GetViewSettingsFromName(controlView.ViewName);

			}
			else 
			{
				viewSettings = CreateNewView(view, navigator, taskId, args);
				ClosePreviousFormIfNecessary(null, previousView, taskId, viewSettings);
			}
       
			
		}

		private void ActivateControl(WindowsFormControlView control, string previousView)
		{
			IView previous = GetActiveControl(control.TaskId, previousView);
			if(previous == null)
			{
				foreach(WindowsFormControlView ctrl in GetActiveControls(control.TaskId).Values)
				{
					ctrl.Enable(false);
				}
			}
			else
			{
				previous.Enable(false);
			}
			control.Enable(true);
			if (control.CanFocus) 
			{
				control.Focus();
			}
		}

		private void ClosePreviousFormIfNecessary(WindowsFormView currentForm, string previousView, Guid taskId, ViewSettings currentViewSettings)
		{
		  if (!currentViewSettings.IsFloatable)
		  {
		    if (null != previousView && 0 != previousView.Length)
		    {
		      //Get the current form
		      ViewSettings previousViewSettings = UIPConfiguration.Config.GetViewSettingsFromName (previousView);
		      if (previousViewSettings == null)
		        throw new UIPException (Resource.ResourceManager.FormatMessage (Resource.Exceptions.RES_ExceptionViewConfigNotFound, previousView));

		      WindowsFormView previousForm = (WindowsFormView) GetActiveForms (taskId)[previousView];
				//if we end up staying with same form, we should not close it
			  if(currentForm != null && previousForm != null && previousForm == currentForm)
				return;
				//if the current one is modal, we don't want to close the preivous view
			  if(currentViewSettings.IsOpenModal && !previousViewSettings.IsOpenModal)
				  return;
		      if (previousForm != null && !previousViewSettings.IsStayOpen)
		      {
		        //The current window must be closed
		        previousForm.Close ();
		      }
		    }
		  }
		}

		private WindowsFormView ActivateForm(WindowsFormView winFormView, ViewSettings viewSettings, Navigator navigator, Guid taskId, string previousView, TaskArgumentsHolder args)
		{
			winFormView.InternalTaskId = taskId;
			winFormView.InternalNavigationGraph = navigator.Name;
			winFormView.InternalViewName = viewSettings.Name;
			winFormView.InternalNavigator = navigator;
			ControllerBase controller = navigator.GetController(winFormView);
			winFormView.InternalController = controller;

			InitializeChildren(winFormView, navigator, taskId);
			winFormView.Initialize(args, viewSettings);

			AddActiveForm(taskId, viewSettings.Name, winFormView);
			AddActiveView(taskId, winFormView, viewSettings.Name);

			LayoutControlsIfRequired(viewSettings, winFormView);

			winFormView.Activated += new EventHandler(Form_Activated);
			winFormView.Closed += new EventHandler(Form_Closed); 

			//Get the parent form
			Form parentForm = (Form)GetProperty( taskId, ParentFormKey );

			if (winFormView.IsMdiContainer || viewSettings.CanHaveFloatingWindows)
				StoreProperty(taskId, ParentFormKey, winFormView);
			else if (parentForm != null)
			{
				if( parentForm.IsMdiContainer )
					winFormView.MdiParent = parentForm;
				else if(viewSettings.IsFloatable) 
				{
					winFormView.TopLevel = true;
					parentForm.AddOwnedForm(winFormView);
					winFormView.Show();
				}
			}

			if(viewSettings.IsOpenModal)
			{
				ShowModal(winFormView, previousView, taskId, parentForm);
			}
			else
			{
				winFormView.Show();
			}

			return winFormView;
		}

		private ViewSettings CreateNewView(string viewName, Navigator navigator, Guid taskId, TaskArgumentsHolder args) 
		{
			//Create a new instance
			ViewSettings viewSettings = UIPConfiguration.Config.GetViewSettingsFromName(viewName);
			if( viewSettings == null )
				throw new UIPException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionViewConfigNotFound, viewName ) );

			IView view = (IView)GenericFactory.Create(viewSettings);
			
			if (view is WindowsFormView) 
			{
				WindowsFormView form = (WindowsFormView) view;
				ActivateForm(form, viewSettings, navigator, taskId, null, args);
			} 
			else 
			{
				WindowsFormControlView ctrl = (WindowsFormControlView)view;
				AddActiveControl(taskId, viewName, ctrl);
				ctrl.Disposed+=new EventHandler(ControlDisposed);
				ActivateControl(ctrl, viewSettings, navigator, taskId, args);
				ctrl.Show();
			}

			return viewSettings;
		}

		private void ActivateControl(WindowsFormControlView control, ViewSettings viewSettings, Navigator navigator, Guid taskId, TaskArgumentsHolder args) 
		{
			control.InternalViewName = viewSettings.Name;
			control.InternalTaskId = taskId;
			ControllerBase controller = navigator.GetController(control);				   	
			control.InternalNavigator = navigator;
			control.InternalController = controller;
			control.Initialize(args, viewSettings);
		}

      private void InitializeChildren(Control container, Navigator navigator, Guid taskId) 
      {
         foreach (Control control in container.Controls) 
         {
            if (control is WindowsFormControlView) 
            {
               WindowsFormControlView child = (WindowsFormControlView) control;
               child.InternalNavigator = navigator;
               child.InternalTaskId = taskId;
               string viewName = navigator.GetViewNameFromNodeName(child.Name);
               child.InternalViewName = viewName;
               ViewSettings viewSettings = UIPConfiguration.Config.GetViewSettingsFromName(viewName);
               AddActiveControl(taskId,child.Name, child);
               child.InternalController = navigator.GetController(child);
               child.Initialize(null, viewSettings);
            }

            if (control.Controls.Count > 0) 
            {
               InitializeChildren(control, navigator, taskId);
            }
         }
      }



		private void ShowModal(WindowsFormView winFormView, string previousView, Guid taskId, object parentForm) 
		{
			if( previousView != null )
			{
				//Get the current form
				ViewSettings previousViewSettings = UIPConfiguration.Config.GetViewSettingsFromName(previousView);
				if( previousViewSettings == null )
					throw new UIPException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionViewConfigNotFound, previousView ) );
                
				WindowsFormView previousForm = GetActiveForm(taskId, previousView);
				winFormView.ShowDialog((IWin32Window)previousForm );
			}
			else
			{
				//the previous view is unknown, so the first view of the navgraph is modal, 
				// as a last resort we try to get the parentForm from our _properties.
				winFormView.ShowDialog((IWin32Window)parentForm);
			}
		}

		private void LayoutControlsIfRequired(ViewSettings viewSettings, WindowsFormView winFormView)
		{
			ILayoutManager layoutManager = LayoutManagerFactory.Create(viewSettings.Name);
			if (layoutManager != null)
				layoutManager.LayoutControls(winFormView);
		}

		private void InitiailizeFormAndViews(Guid taskId)
		{
			if( _activeForms[ taskId ] == null )
			{
				_activeForms[ taskId ] = new Hashtable();
				_activeViews[ taskId ] = new Hashtable();

			}
			if(!_activeControls.Contains(taskId))
			{
				_activeControls.Add(taskId, new Hashtable());
			}
		}

		private Hashtable GetActiveForms(Guid taskId)
		{
			return (Hashtable)_activeForms[taskId];
		}

		private WindowsFormView GetActiveForm(Guid taskId, string viewName)
		{
			Hashtable tmp = GetActiveForms(taskId);
			return (tmp == null || viewName == null)? null : (WindowsFormView)tmp[viewName];
		}

		private void AddActiveForm(Guid taskId, string viewName, WindowsFormView view)
		{
			GetActiveForms(taskId)[viewName] = view;
		}

		private Hashtable GetActiveControls(Guid taskId)
		{
			return (Hashtable)_activeControls[taskId];
		}

		private WindowsFormControlView GetActiveControl(Guid taskId, string viewName)
		{
			Hashtable tmp = GetActiveControls(taskId);
			return (tmp == null || viewName == null) ? null : (WindowsFormControlView)tmp[viewName];
		}

		private void AddActiveControl(Guid taskId, string viewName, WindowsFormControlView ctrl)
		{
			GetActiveControls(taskId)[viewName] = ctrl;
		}

		private Hashtable GetActiveViews(Guid taskId)
		{
			return (Hashtable)_activeViews[taskId];
		}

		private void AddActiveView(Guid taskId, WindowsFormView view, string viewName)
		{
			GetActiveViews(taskId)[view] = viewName;
		}
        
		/// <summary>
		/// Required for Web applications only.		
		/// <remark>Not implemented in WinFormViewManager.</remark>
		/// </summary>
		/// <param name="view"></param>
		/// <param name="stateViewName"></param>
		/// <returns></returns>
		public bool IsRequestCurrentView( IView view, string stateViewName )
		{
			// Not implemented. In Windows Forms applications it is not necessary. 
			return true;
		}

		/// <summary>
		/// Required for Web applications only.
		/// <remark>Not implemented in WinFomViewManager.</remark>
		/// </summary>
		/// <param name="currentView">The current view.</param>
		/// <returns></returns>
		public string GetViewNameForCurrentRequest( IView currentView ) 
		{
			return null;
		}

        
		/// <summary>
		/// Gets the running tasks in the manager.
		/// </summary>
		/// <returns>An array with the task identifiers.</returns>
		public Guid[] GetCurrentTasks()
		{
			ArrayList tasks = new ArrayList(); 
			foreach( Guid key in _activeViews.Keys )
			{
				tasks.Add( key );
			}

			return (Guid[]) tasks.ToArray( typeof(Guid) );
		}
		
		/// <summary>
		/// For a given task, returns a hash table composed of WinFormViews keyed by name.
		/// </summary>
		/// <param name="taskId">The task identifier (a GUID associated with the task).</param>
		/// <returns>A collection of IViews.</returns>
		public static Hashtable GetCurrentViews(Guid taskId) 
		{
		    return (Hashtable)_activeForms[taskId];
		}
        
		#endregion

		#region WinForm Event Handlers

		/// <summary>
		/// Updates the current view.
		/// </summary>
		private void Form_Activated( object source, EventArgs e)
		{
			WindowsFormView winFormView = (WindowsFormView)source;
			State state = winFormView.Controller.State;
            
			//Get the views related to the current task
			Hashtable taskActiveViews = (Hashtable)_activeViews[state.TaskId];
            
			//Get the view related to the form that fires this event
			string currentView = (string)taskActiveViews[source];
            
			//Update the state current view
			if( currentView != null )
				state.CurrentView = currentView;
		}
		
		/// <summary>
		/// Removes the closed form from the collection of active forms.
		/// </summary>
		private void Form_Closed( object source, EventArgs e)
		{
			IView winFormView = (IView)source;
                        
			//Get the views related to the current task
			Hashtable taskActiveViews = (Hashtable)_activeViews[winFormView.TaskId];
			Hashtable taskActiveForms = (Hashtable)_activeForms[winFormView.TaskId];
            
			//Get the view related to the form that fires this event
			string currentView = (string)taskActiveViews[source];
            
			//Remove the view and its form
			if( currentView != null )
			{
				CleanUpChildWindows((WindowsFormView) source);
				taskActiveForms.Remove( currentView );
				if (taskActiveForms.Count == 0) 
				{
					_activeForms.Remove(winFormView.TaskId);
					CleanUpControls(winFormView.TaskId);
				}

				taskActiveViews.Remove( source );
				if (taskActiveViews.Count == 0)
					_activeViews.Remove(winFormView.TaskId);
			}

			if(GetActiveViewCount() == 0) 
			{
				UIPManager.OnCompletion();
			}
		}

		private void CleanUpChildWindows(WindowsFormView parent)
		{
			foreach(Form form in parent.OwnedForms)
			{
				form.Close();
			}
		}

		private void CleanUpControls(Guid taskId)
		{
			Hashtable tbl = (Hashtable)_activeControls[taskId];
			tbl.Clear();
			_activeControls.Remove(taskId);
		}

		private void ControlDisposed(object sender, EventArgs e)
		{
			IView source = (IView) sender;
			Hashtable controls = GetActiveControls(source.Navigator.CurrentState.TaskId);
			if(controls != null) 
				controls.Remove(source.ViewName);
		}

		/// <summary>
		/// For a given task, returns a hash table composed of WinFormControlViews keyed by name.
		/// </summary>
		/// <param name="taskId">The task identifier (a GUID associated with the task).</param>
		/// <returns>A collection of IViews.</returns>
		public static Hashtable GetCurrentControls(Guid taskId)
		{
			return (Hashtable) _activeControls[taskId];
		}
       
		/// <summary>
		/// The number of currently active views.
		/// </summary>
		/// <returns>The view count.</returns>
		public int GetActiveViewCount()
		{
			if(_activeViews.Count == 0)
			{
				return 0;
			}

			int count = 0;
			foreach(Hashtable table in _activeViews.Values) 
			{
				count += table.Count;
			}
			return count;
		}
		
		#endregion

	}
	#endregion
}
