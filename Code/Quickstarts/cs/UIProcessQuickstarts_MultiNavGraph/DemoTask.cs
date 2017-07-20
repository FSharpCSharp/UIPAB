//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// DemoTask.cs
//
// This file contains the implementations of the DemoTask class.
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
using System.Xml;
using Microsoft.ApplicationBlocks.UIProcess;

namespace UIProcessQuickstarts_MultiNavGraph
{
	/// <summary>
	/// A Task sample wich will be passed to UIPManager
	/// </summary>
	public class DemoTask : ITask
	{
		public DemoTask(){}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="taskID">Task identifier</param>
		public DemoTask( Guid taskID ) 
		{
			_taskID = taskID;
		}

		private Guid _taskID = Guid.Empty;

		#region ITask Members

		///<summary>Create a new task identifier</summary>
		///<param name="taskId">task identifier</param>
		public void Create(Guid taskId)
		{
			TaskLog.MakeTaskEntry( taskId );
		}

		///<summary>Get the taskid related to this Task object</summary>
		public Guid Get()
		{
			return _taskID;
		}

		#endregion
	}
}
