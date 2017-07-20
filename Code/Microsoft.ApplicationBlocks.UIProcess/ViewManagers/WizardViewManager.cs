//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// WizardViewManager.cs
//
// This file contains the implementations of the  class.
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

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// The WizardViewManager is intended to provide an implementation of the 
	/// <see cref="Microsoft.ApplicationBlocks.UIProcess.IViewManager"/> interface
	/// specifically for wizard functionality. It provides methods for control navigation between <see cref="Microsoft.ApplicationBlocks.UIProcess.IView"/>
	/// implementations loaded in the <see cref="Microsoft.ApplicationBlocks.UIProcess.WizardContainer"/>.
	/// </summary>
	public class WizardViewManager : IViewManager
	{	
		private Hashtable _activeWizardContainers = Hashtable.Synchronized(new Hashtable());
		private NodeSettings[] _nodeSettings;

		/// <summary>
		/// Initializes a new instance of WizardViewManager.
		/// </summary>
		/// <param name="settings">The array of NodeSettings that will be used to construct the 
		/// <see cref="Microsoft.ApplicationBlocks.UIProcess.WindowsFormView"/> that will make up the forms within the wizard.</param>
		public WizardViewManager(NodeSettings[] settings)
		{
			_nodeSettings = settings;
		}
	
		/// <summary>
		/// Required by interface contract, but implementation is not required for the WizardViewManager.
		/// </summary>
		/// <remarks>The property storage is a view manager responsibility.</remarks>
		/// <param name="taskId">The task identifier (a GUID associated with the task).</param>
		/// <param name="name">The property name.</param>
		/// <param name="value">The property value.</param>
		public void StoreProperty(Guid taskId, string name, object value)
		{
			// no implementation
		}

		private WizardContainer GetWizardContainer(Guid taskId,Navigator navigator)
		{
			WizardContainer result = (WizardContainer)_activeWizardContainers[taskId];
			if(result == null)
			{
				result = new WizardContainer(CreateViews(navigator),navigator);
				_activeWizardContainers[taskId] = result;
				result.Closed += new EventHandler(ContainerClosed);
			}
			return result;
		}

		/// <summary>
		/// This method applies only to the <see cref="Microsoft.ApplicationBlocks.UIProcess.WebFormViewManager"/>
		/// and is not implemented for this class.
		/// </summary>
		/// <param name="currentView"></param>
		/// <returns></returns>
		public string GetViewNameForCurrentRequest(IView currentView) 
		{
			return null;
		}

		/// <summary>
		/// Activates a specific view.
		/// </summary>
		/// <param name="previousView">The view that is currently active.</param>
		/// <param name="viewName">The view name to be activated.</param>
		/// <param name="navigator">The navigator.</param>
		public void ActivateView(string previousView, string viewName, Navigator navigator) 
		{
			ActivateView(previousView, viewName, navigator, null);
		}

		/// <summary>
		/// Activates a specific view with activation arguments.
		/// </summary>
		/// <param name="previousView">The view that is currently active.</param>
		/// <param name="viewName">The view name to be activated.</param>
		/// <param name="navigator">The navigator.</param>
		/// <param name="args">The arguments for the next view.</param>
		public void ActivateView(string previousView, string viewName, Navigator navigator, TaskArgumentsHolder args) 
		{
			Guid taskId = navigator.CurrentState.TaskId;
			WizardContainer currentWizardContainer= GetWizardContainer(taskId,navigator);
			currentWizardContainer.Activate(viewName);
		}

		private  IView[] CreateViews(Navigator navigator)
		{
			IView[] results = new IView[_nodeSettings.Length];
			int i = 0;
			foreach (NodeSettings node in _nodeSettings)
			{
				ViewSettings viewSettings = UIPConfiguration.Config.GetViewSettingsFromName(node.View);

				if( viewSettings == null )
					throw new UIPException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionViewConfigNotFound, node.View ) );

				IView view  = (IView)GenericFactory.Create(viewSettings);
				SetWinFormControlInternals(view as WindowsFormControlView, viewSettings, navigator);
				SetWinFormInternals(view as WindowsFormView, viewSettings, navigator);			
				results[i++] = view;
			}
			return results;
		}

		private void SetWinFormControlInternals(WindowsFormControlView control,ViewSettings viewSettings,Navigator navigator)
		{
			if(control != null) 
			{
				control.InternalNavigator = navigator;
				control.InternalNavigationGraph = navigator.Name;
				control.InternalViewName = viewSettings.Name;
			}
		}

		private void SetWinFormInternals(WindowsFormView view,ViewSettings viewSettings,Navigator navigator)
		{
			if(view != null) 
			{
				view.InternalNavigator = navigator;
				view.InternalNavigationGraph = navigator.Name;
				view.InternalViewName = viewSettings.Name;
			}
		}

		/// <summary>
		/// Required for Web applications only.
		/// </summary>
		/// <param name="view">The next view.</param>
		/// <param name="stateViewName">The view saved in the state.</param>
		/// <returns></returns>
		public bool IsRequestCurrentView(IView view, string stateViewName)
		{
			return true;
		}

		/// <summary>
		/// The managed tasks running as wizards.
		/// </summary>
		/// <returns></returns>
		public Guid[] GetCurrentTasks()
		{
			Guid[] results = new Guid[_activeWizardContainers.Count];
			_activeWizardContainers.Keys.CopyTo(results,0);
			return results;
		}

		/// <summary>
		/// The number of wizards that are currently active.
		/// </summary>
		/// <returns></returns>
		public int GetActiveViewCount()
		{
			int count = 0;
			foreach (WizardContainer container in _activeWizardContainers.Values)
			{
				count += container.Count;
			}
			return count;
		}

		/// <summary>
		/// The IView currently displayed in the wizard for a given task.
		/// </summary>
		/// <param name="taskId">A task identifier (a GUID associated with the task).</param>
		/// <returns></returns>
		public IView GetActiveView(Guid taskId)
		{
			WizardContainer container = (WizardContainer)_activeWizardContainers[taskId];
			return (container == null) ? null : container.GetActiveView();
		}

		private void ContainerClosed(object sender, EventArgs e)
		{
			_activeWizardContainers.Remove(((WizardContainer)sender).TaskId);
		}
	}
}
