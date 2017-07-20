//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// ILayoutManager.cs
//
// This file contains definitions for the ILayoutManager interface.
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
using System.Windows.Forms;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// The interface used to hook a layout manager into the UIP block.
	/// The view manager calls the LayoutControls method after instantiating a view, but before calling <code>Show()</code>.
	/// </summary>
	public interface ILayoutManager
	{
		/// <summary>
		/// Performs layout functions on any child control of the parent control.
		/// </summary>
		/// <param name="parentControl">The container on which to perform layout.</param>
		void LayoutControls(Control parentControl);
	}
}
