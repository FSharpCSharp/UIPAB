//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// StoreControllerHostedControl.cs
//
// This file contains the implementations of the StoreControllerHostedControl class.
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
using System.Resources;
using System.Reflection;

using UIProcessQuickstarts_Store;
using Microsoft.ApplicationBlocks.UIProcess;


namespace UIProcessQuickstarts_Store
{
	/// <summary>
	/// The controller used by the store application
	/// </summary>
	public class StoreControllerHostedControl : StoreControllerBase
	{        
		public StoreControllerHostedControl(Navigator navigator):base(navigator){}		

		/// <summary>
		/// Resumes the shopping task
		/// </summary>
		public override void ResumeShopping() 
		{			
			State.NavigateValue = "StoreForm";
			Navigate();
		}				

		public override void StopShopping()
		{				
		}
	}
}
