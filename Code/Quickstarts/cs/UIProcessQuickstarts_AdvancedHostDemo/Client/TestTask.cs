//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// TestTask.cs
//
// This file contains the implementations of the TestTask class.
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

namespace Client
{
	public class TestTask : ITask
	{
		private Guid taskId = Guid.Empty;

		public TestTask()
		{
		}

		#region ITask Members

		public void Create(Guid taskId)
		{
			this.taskId = taskId;
		}

		public Guid Get()
		{
			return taskId;
		}

		#endregion
	}
}
