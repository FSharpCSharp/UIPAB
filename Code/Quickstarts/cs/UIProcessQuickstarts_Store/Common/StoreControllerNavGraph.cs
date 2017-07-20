//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// StoreControllerNavGraph.cs
//
// This file contains the implementations of the StoreControllerNavGraph class.
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
	public class StoreControllerNavGraph : StoreControllerBase
	{        
		public StoreControllerNavGraph(Navigator navigator):base(navigator){}

		public override void AddToCart(int productId, int quantity) 
		{
			base.AddToCart(productId,quantity);
			Navigate();
		}

		/// <summary>
		/// Resumes the shopping task
		/// </summary>
		public override void ResumeShopping() 
		{
			//  proceed to next View
			State.NavigateValue = "resume";
			Navigate();
		}		
	}
}
