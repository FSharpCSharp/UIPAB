//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// Task.cs
//
// This file contains the implementations of the Task class.
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

namespace UIProcessQuickstarts_MultiNavGraph
{
	/// <summary>
	/// Summary description for Task.
	/// </summary>
	public class Task : ITask
	{
		Guid _taskId = Guid.Empty;

		public Task()
		{
		}

		public Task(Guid taskId) 
		{
			_taskId = taskId;
		}

		#region ITask Members

		public void Create(Guid taskId)
		{
			_taskId = taskId;
		}

		public Guid Get()
		{
			return _taskId;
		}

		#endregion
	}
}
