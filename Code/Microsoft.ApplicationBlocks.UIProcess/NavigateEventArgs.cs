//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// NavigateEventArgs.cs
//
// This file contains the implementations of the NavigateEventArgs class.
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
	/// Arguments passed when the NavigateEvent on <code>UIPManager</code> occurs.
	/// </summary>
	public class NavigateEventArgs : EventArgs
	{
		private State _state;

		/// <summary>
		/// Creates a NavigateEventArgs object that contains the state.
		/// </summary>
		/// <param name="state">State of the task.</param>
		public NavigateEventArgs(State state) : base()
		{
			_state = state;
		}

		/// <summary>
		/// The state of the task when the navigate event occurred.
		/// </summary>
		public State State 
		{
			get { return _state; }
		}
	}
}
