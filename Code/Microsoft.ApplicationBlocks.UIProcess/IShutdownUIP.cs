//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// IShutdownUIP.cs
//
// This file contains definitions for the IShutdownUIP interface.
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
	/// All classes that implement IShutdownUIP can be registered with the 
	/// UIPManager. Upon closure of all UIP forms, the Shutdown method will
	/// be called.
	/// </summary>
	public interface IShutdownUIP
	{
		/// <summary>
		/// Called when UIP shuts down.
		/// </summary>
		void Shutdown();	
	}
}
