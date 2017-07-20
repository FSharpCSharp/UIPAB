//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// MemoryStatePersistence.cs
//
// This file contains the implementations of the MemoryStatePersistence class
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
using System.Collections.Specialized;
using Microsoft.ApplicationBlocks.UIProcess;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// This provides simple memory-based state persistence for Windows Forms applications. 
	/// DO NOT use it on the server; the locking mechanism will cause a bottleneck for
	/// busy Web applications.
	/// </summary>
	public class MemoryStatePersistence : IStatePersistence
	{
		private HybridDictionary _stateReferences = new HybridDictionary();	
	
		#region IStatePersistence Members

		/// <summary>
		/// UIP uses this method to pass extra configuration information to the persistence provider.
		/// </summary>
		/// <param name="statePersistenceParameters">Collection of configuration information to be used by
		/// the persistence provider.</param>
		public void Init(System.Collections.Specialized.NameValueCollection statePersistenceParameters){}

		/// <summary>
		/// Loads the saved state for this task.
		/// </summary>
		/// <param name="taskId">The task identifier (a GUID associated with the task).</param>
		/// <returns></returns>
		public State Load(Guid taskId)
		{
			return (State)_stateReferences[taskId];
		}

		/// <summary>
		/// Saves the State object in memory.
		/// </summary>
		/// <param name="state">A valid State object.</param>
		public void Save(State state)
		{
			//  lock on syncroot to prevent collisions
			lock( _stateReferences.SyncRoot )
			{
				_stateReferences[state.TaskId]= state;			
			}
		}

		/// <summary>
		/// Removes (deletes) the State object from memory.
		/// </summary>
		/// <param name="taskId">The task identifier (a GUID associated with the task). The State object for this task will be removed.</param>
		public void Remove(Guid taskId) 
		{
			lock (_stateReferences.SyncRoot) 
			{
				_stateReferences.Remove(taskId);
			}
		}
		#endregion
	}
}