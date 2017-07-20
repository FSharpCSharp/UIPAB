//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// WizardNavigator.cs
//
// This file contains the implementations of the WizardNavigator class.
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
	/// Determines navigation behavior for wizards.
	/// </summary>
	public class WizardNavigator : GraphNavigator
	{
		/// <summary>
		/// Initializes a new instance of WizardNavigator with the given name.
		/// </summary>
		/// <param name="name">The name of the wizard.</param>
		public WizardNavigator(string name):base(name)
		{
		}

		/// <summary>
		/// Creates the appropiate <see cref="Microsoft.ApplicationBlocks.UIProcess.IViewManager"/> for a wizard.
		/// <remarks>For the WizardNavigator, the IViewManager is always a <see cref="Microsoft.ApplicationBlocks.UIProcess.WizardViewManager"/></remarks>
		/// </summary>
		/// <param name="name">The name of the IViewManager to create.</param>
		/// <returns>A WizardViewManager.</returns>
		protected override IViewManager CreateViewManager(string name)
		{	
			IViewManager viewManager = ViewManagerFactory.Create(name,new object[]{this.NavigationSettings.Views()});
			if(!(viewManager is WizardViewManager))
				throw new UIPException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionWizardViewManagerIsRequired ));
			return viewManager;
		}

		/// <summary>
		/// Displays the next view in the wizard.
		/// </summary>
		/// <param name="previousView">The name of the previous view.</param>
		/// <param name="currentView">The name of the view to be navigated to (the next view).</param>
		protected override void ActivateNextView(string previousView, string currentView)
		{
			((WizardViewManager)ViewManager).ActivateView(previousView,currentView,this);
		}

		/// <summary>
		/// Returns the name of the last view in the wizard.
		/// </summary>
		public string LastViewName
		{
			get { return this.NavigationSettings.LastView.View; }
		}

	}
}
