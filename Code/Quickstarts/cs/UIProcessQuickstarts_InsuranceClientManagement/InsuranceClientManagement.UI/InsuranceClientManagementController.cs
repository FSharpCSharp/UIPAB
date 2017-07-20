//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// InsuranceClientManagementController.cs
//
// This file contains the implementations of the InsuranceClientManagementController class.
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
	/// Controller that performs functionality common to all views in the InsuranceClientManagement sample
	/// </summary>
	public class InsuranceClientManagementController : ControllerBase
	{
		public InsuranceClientManagementController(Navigator context):base(context)
		{
		}

		/// <summary>
		/// Navigates to the view that allows  for adding of client information
		/// </summary>
		public void StartAddingClient() 
		{
			this.Navigator.CurrentState.NavigateValue="add";
			Navigate();
		}

		/// <summary>
		/// Stores the client information in the state
		/// </summary>
		/// <param name="client"></param>
		public void ExecuteAddClientRequest(Client client) 
		{
			Navigator.CurrentState[Constants.Client] = client;
			this.Navigator.CurrentState.NavigateValue="confirmation";
			Navigate();
		}

		/// <summary>
		/// Stores the username in the state, basically used to simulate the authentication process
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		public void LogMeIn(string username, string password) 
		{
			// don't actually do any authentication... just save the username in the state
			this.Navigator.CurrentState[Constants.UserId] = username;
			if (this.State[Constants.AfterLoginNavigationValue] != null) 
			{
				this.Navigator.CurrentState.NavigateValue=(string)this.State[Constants.AfterLoginNavigationValue];
				this.State[Constants.AfterLoginNavigationValue] = null;
			}
			else 
				this.Navigator.CurrentState.NavigateValue="welcome";
			Navigate();
		}

		public bool IsManager(string userName,string password)
		{
		  return (userName.ToLower() == "manager" && password.ToLower()=="manager");
		}

		/// <summary>
		/// Navigate to the welcome view, simulates unauthenticated logon
		/// </summary>
		public void DoNotLogMeIn() 
		{
			this.Navigator.CurrentState.NavigateValue="welcome";
			Navigate();			
		}


		public void ContinueManagement() 
		{
			this.Navigator.CurrentState.NavigateValue="welcome";
			Navigate();
		}

		/// <summary>
		/// Navigate to the view that will throw an exception that will demonstrate the functionality of rich debug exceptions
		/// </summary>
		public void ThrowException() 
		{
			this.Navigator.CurrentState.NavigateValue="clientsearch";
			Navigate();			
		}

		/// <summary>
		/// Navigate to Help page, which is defined in SharedTransition.
		/// </summary>
		public void ShowHelp()
		{
			this.Navigator.CurrentState.NavigateValue="help";
			Navigate();
		}
	}
}
