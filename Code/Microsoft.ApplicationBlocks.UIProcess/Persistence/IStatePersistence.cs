//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// IStatePersistence.cs
//
// This file contains the definition of the IStatePersistence interface.
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

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// This interface defines how State and Task objects can be dehydrated or rehydrated by the Manager object.
	/// It allows you to abstract storage so that you can use SQL, file, binary, XML, or whatever.
	/// </summary>
	public interface IStatePersistence
	{
		/// <summary>
		/// Initializes the provider.
		/// </summary>
		/// <param name="statePersistenceParameters">The provider settings.</param>
		void Init(NameValueCollection statePersistenceParameters);

		/// <summary>
		/// Serializes and saves the state in a specific storage location.
		/// </summary>
		/// <param name="state">A valid State object.</param>
		void Save(State state);
	        
		/// <summary>
		/// Restores and deserializes the state from a specific storage location. 
		/// </summary>
		/// <param name="taskId">A task identifier (a GUID associated with the task). 
		/// This identifier is used to restore a saved state.
		/// </param>
		/// <remarks>If the task does not exist, then a null value is returned.</remarks>
		/// <returns>A valid State object.</returns>
		State Load(Guid taskId);

		/// <summary>
		/// Deletes a stored state object from a specific storage location. 
		/// </summary>
		/// <param name="taskId">A task identifier (a GUID associated with the task). 
		/// This identifier is used to remove a saved state.
		/// </param>
		void Remove(Guid taskId);
	}
}
