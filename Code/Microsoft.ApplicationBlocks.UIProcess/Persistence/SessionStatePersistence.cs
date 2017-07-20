//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// SessionStatePersistence.cs
//
// This file contains the implementations of the SessionStatePersistence class
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
using System.Web;

using Microsoft.ApplicationBlocks.UIProcess;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// This class provides simple session-based state persistence for Web applications.  
	/// It pushes state directly to session variables keyed to the task GUID.
	/// It is useful for applications where state might be ephemeral and not worth saving in a SQL database. 
	/// It is also useful for Web farm applications, where multiple front-end servers need to see the same state.
	/// In this case, ASP Session would be used either as a state server OR in SQL session mode, and this 
	/// persistence provider would piggyback on ASP Session.
	/// By using this class, you can easily migrate applications to non-ASP by replacing the 
	/// state persistence provider (and by completing other normal, necessary changes).
	/// </summary>
	public class SessionStatePersistence : IStatePersistence
	{	
		/// <summary>
		/// Creates a new instance of a session state persistence provider.
		/// </summary>
		public SessionStatePersistence(){}
	
		#region IStatePersistence Members

		/// <summary>
		/// Initializes the state persistence provider.
		/// </summary>
		/// <param name="statePersistenceParameters">The provider settings.</param>
		public void Init(System.Collections.Specialized.NameValueCollection statePersistenceParameters){}

		/// <summary>
		/// Loads state from the Session object.
		/// </summary>
		/// <param name="taskId">The task identifier (a GUID associated with the task). The state of this task will be loaded.</param>
		/// <returns></returns>
		public State Load(Guid taskId)
		{
			//  pull State object directly out of Session
			return (State)HttpContext.Current.Session[ taskId.ToString() ];
		}

		/// <summary>
		/// Saves state to the Session object.
		/// </summary>
		/// <param name="inState">The state to save.</param>
		public void Save(State inState)
		{
			//  put State object directly into Session
			HttpContext.Current.Session[ inState.TaskId.ToString() ] = inState;
		}

		/// <summary>
		/// Removes (deletes) state from the Session object.
		/// </summary>
		/// <param name="taskId">The task identifier (a GUID associated with the task). The state of this task will be removed.</param>
		public void Remove(Guid taskId) 
		{
			HttpContext.Current.Session.Remove(taskId.ToString());
		}

		#endregion
	}
}