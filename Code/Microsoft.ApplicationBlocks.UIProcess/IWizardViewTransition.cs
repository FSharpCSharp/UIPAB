//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// IWizardViewTransition.cs
//
// This file contains the definition of the IWizardViewTransition interface.
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
	/// Provides method definitions for wizard transitions.
	/// </summary>
	public interface IWizardViewTransition
	{
		/// <summary>
		/// Transitions to the next view.
		/// </summary>
		/// <returns></returns>
		bool DoNext();

		/// <summary>
		/// Transitions to the previous view.
		/// </summary>
		/// <returns></returns>
		bool DoBack();

		/// <summary>
		/// Cancels the wizard task.
		/// </summary>
		/// <returns></returns>
		bool DoCancel();


		/// <summary>
		/// Jumps to the finish view.
		/// </summary>
		/// <returns></returns>
		bool DoFinish();

		/// <summary>
		/// Indicates that the wizard view supports cancel behavior.
		/// </summary>
		bool SupportsCancel{get;}

		/// <summary>
		/// Indicates that the wizard view supports finish behavior.
		/// </summary>
		bool SupportsFinish{get;}


		/// <summary>
		/// Called when the wizard view is activated.
		/// </summary>
		void WizardActivated();
	}
}
