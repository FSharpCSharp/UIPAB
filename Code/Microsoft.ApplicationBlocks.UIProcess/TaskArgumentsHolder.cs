//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// TaskArgumentsHolder.cs
//
// This file contains the implementations TaskArgumentsHolder class.
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
	/// This class hold the arguments that can be passed from one navigation graph to another when chaining use cases.
	/// The data includes a return pointer (the originating graph and task ID) and an object that can be used
	/// to encapsulate data that is passed from one navigation graph to another.
	/// </summary>
	public class TaskArgumentsHolder
	{
		private Guid _originatingTaskID;
		private string _originatingNavGraphName ;
		private object _taskArguments;

		/// <summary>
		/// Initializes a new instance of TaskArgumentsHolder with a task ID, a navigation graph name, and arguments.
		/// </summary>
		/// <param name="originatingTaskID">The originating task identifier (a GUID associated with the task).</param>
		/// <param name="originatingNavGraphName">The originating navigation graph name.</param>
		/// <param name="taskArguments">An object with generic data.</param>
		public TaskArgumentsHolder( Guid originatingTaskID, string originatingNavGraphName, object taskArguments )
		{
			_originatingTaskID = originatingTaskID;
			_originatingNavGraphName = originatingNavGraphName;
			_taskArguments = taskArguments;
		}
		
		/// <summary>
		/// Gets or sets an object that can be used
		/// to encapsulate data that is passed from one navigation graph to another.
		/// </summary>
		public object TaskArguments
		{
			get	{ return _taskArguments; }
		}
		
		/// <summary>
		/// Gets or sets the originating task ID.
		/// </summary>
		public Guid OriginatingTaskID
		{
			get	{ return _originatingTaskID; }
		}

		/// <summary>
		/// Gets or sets the originating navigation graph name.
		/// </summary>
		public string OriginatingNavGraphName
		{
			get	{ return _originatingNavGraphName; }
		}
	}
}
