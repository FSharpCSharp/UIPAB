//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// Authorization.cs
//
// This file contains the implementations of the Authorization class.
//
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

using Microsoft.ApplicationBlocks.UIProcess;

namespace InsuranceClientManagement.UI
{
	/// <summary>
	/// Class that ensures that only authorized users are allowed access to certain views in the application. This class
	/// demonstrates the ability for components to be able to alter the flow of navigation based on custom business rules/
	/// requirements
	/// </summary>
	public class Authorization
	{
		/// <summary>
		/// Property that returns an instance of the authorization object, implemented using the sigleton pattern
		/// </summary>
		public static readonly Authorization INSTANCE = new Authorization();
		
		public void Init()
		{

		}

		private Authorization()
		{
			// add a handler for the NavigateEvent of the UIPManager class
			UIPManager.NavigateEvent += new Microsoft.ApplicationBlocks.UIProcess.UIPManager.NavigateEventHandler(UIPManager_NavigateEvent);
		}

		/// <summary>
		/// Method that gets called whenever a navigation is about to occur in UIP, this is where the custom logic is placed to 
		/// ensure that a user is allowed access to a particular view.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UIPManager_NavigateEvent(object sender, NavigateEventArgs e)
		{
			string nextView =UIPConfiguration.Config.GetNextViewSettings(e.State.NavigationGraph,e.State.CurrentView,e.State.NavigateValue).Name;

			//ensure that the user is allowed to access the view they are trying to get to
			if (!UserIsAllowed((string)e.State[Constants.UserId], e.State.NavigateValue, (string)e.State[Constants.AfterLoginNavigationValue]))
			{
				// redirect the user back to the logon page.
				e.State["error"] = "You must be logged in to access this functionality";
				e.State["afterlogin"] = e.State.NavigateValue;
				e.State.NavigateValue = "login";
			}
		}

		private bool UserIsAllowed(string username, string navigateValue, string afterLoginNavigationValue) 
		{
			// if user is defined then they can go anywhere
			if (username != null) return true;
			// otherwise, they can not go to the add screen
			return (navigateValue != "add" && afterLoginNavigationValue != "add");
		}
	}
}
