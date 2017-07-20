//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// WizardController.cs
//
// This file contains the implementations of the WizardController class.
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
	/// The controller used by all wizards.
	/// <param>This is used internally to control the wizard between transitions.</param>
	/// <param>Views within the wizard still have their own controllers.</param>
	/// </summary>
	public class WizardController : ControllerBase
	{
		private delegate int GetViewIndex();
		private delegate void RaiseEvent(EventArgs e);

		/// <summary>
		/// Initializes a new instance of WizardController with the given navigator.
		/// </summary>
		/// <param name="navigator">Navigator to associate with this controller.</param>
		public WizardController(Navigator navigator):base(navigator){}
	
		/// <summary>
		/// Invoked when the Next button on a wizard is pressed.
		/// Determines which view to display next.
		/// </summary>
		public void Next()
		{		
			string nextNavValue = "next";

			if (Navigator.CurrentState.NavigateValue != null && Navigator.CurrentState.NavigateValue.Trim().Length >0)
			{
				nextNavValue = Navigator.CurrentState.NavigateValue;
			}
			
			Navigator.CurrentState.NavigateValue = nextNavValue;		
			Navigate();
		}

	}
}
