//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// ITask.cs
//
// This file contains the definitions of the ITask interface.
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
	/// Defines a Task object that can be passed to UIPManager. This object is used by applications that 
	/// must get the task ID for their internal use. For example, if a user logs on and has an associated 
	/// shopping cart, when the application redirects to another page, it must retain the task ID to correlate 
	/// with the logon.
	/// </summary>
	public interface ITask
	{
		///<summary>Gets the task ID for the logon.</summary>
		Guid Get();
		
		///<summary>Creates a task ID for the logon. </summary>
		///<param name="taskId">The task identifier (a GUID associated with the task).</param>
		void Create(Guid taskId);
	}
}
