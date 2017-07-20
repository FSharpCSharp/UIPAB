//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// IsolatedStoregePersistence.cs
//
// This file contains the implementation of the IsolatedStoregePersistence class
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
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// IStatePersistence implementation for isolated storage.
	/// </summary>
	public class IsolatedStoragePersistence : IStatePersistence
	{
		/// <summary>
		/// Creates a new instance of an IsolatedStoragePersistence object.
		/// </summary>
		public IsolatedStoragePersistence()
		{
		}

		/// <summary>
		/// Used to pass extra parameters from the configuration file to this instance.
		/// </summary>
		/// <param name="statePersistenceParameters">Any extra attributes found in the configuration file.</param>
		public virtual void Init(System.Collections.Specialized.NameValueCollection statePersistenceParameters){}
		
		/// <summary>
		/// Saves the State object to isolated storage.
		/// </summary>
		/// <param name="state">A valid State object.</param>
		[IsolatedStorageFilePermission(System.Security.Permissions.SecurityAction.Demand)]
		public void Save(State state) 
		{
			using (IsolatedStorageFile isoFile =
					   IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
					   IsolatedStorageScope.Assembly |
					   IsolatedStorageScope.Domain ,
					   null,
					   null)) 
			{
				
				using (IsolatedStorageFileStream isoStream =
						   new IsolatedStorageFileStream( state.TaskId.ToString(),
						   FileMode.Create,
						   FileAccess.Write,
						   FileShare.None)) 
				{
					byte[] serializedObject = ToByteArray(state);
					isoStream.Write(serializedObject, 0, serializedObject.Length);
					isoStream.Close();
				}
				isoFile.Close();
			}

		}

		/// <summary>
		/// Loads the state from isolated storage. 
		/// </summary>
		/// <param name="taskId">The identifier of the task to load the state for.</param>
		/// <returns>A valid State object.</returns>
		[IsolatedStorageFilePermission(System.Security.Permissions.SecurityAction.Demand)]
		public State Load(Guid taskId) 
		{
			using (IsolatedStorageFile isoFile =
					   IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
					   IsolatedStorageScope.Assembly |
					   IsolatedStorageScope.Domain ,
					   null,
					   null)) 
			{
				string[] fileNames = isoFile.GetFileNames(taskId.ToString());
				
				if (fileNames.Length > 0) 
				{
					using (IsolatedStorageFileStream isoStream =
							   new IsolatedStorageFileStream( taskId.ToString(),
							   FileMode.Open,
							   FileAccess.Read,
							   FileShare.None)) 
					{
						long count = isoStream.Length;
						byte[] serializedObject = new byte[count];
						isoStream.Read(serializedObject, 0, serializedObject.Length);
						return FromByteArray(serializedObject);
					}
				}

				return null;
			}
		}

		/// <summary>
		/// Removes (deletes) the State object from isolated storage.
		/// </summary>
		/// <param name="taskId">The identifier of the task to remove the state for.</param>
		public void Remove(Guid taskId) 
		{
			using (IsolatedStorageFile isoFile =
					   IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
					   IsolatedStorageScope.Assembly |
					   IsolatedStorageScope.Domain ,
					   null,
					   null)) 
			{
				isoFile.DeleteFile(taskId.ToString());
			}
		}

		/// <summary>
		/// Converts a State object to an array of bytes.
		/// </summary>
		/// <param name="state">The state object to convert.</param>
		/// <returns>The array of bytes.</returns>
		protected virtual byte[] ToByteArray(State state) 
		{
			BinaryFormatter formatter = new BinaryFormatter();
			MemoryStream memoryStream = new MemoryStream();
			formatter.Serialize(memoryStream, state);
	        
			byte[] serializedObject = memoryStream.GetBuffer();
			return serializedObject;
		}

		/// <summary>
		/// Deserializes a byte array into a State object.
		/// </summary>
		/// <param name="serializedObj">Byte array that will be deserialized into a State object.</param>
		/// <returns>A valid State object.</returns>
		protected virtual State FromByteArray(byte[] serializedObj) 
		{
			MemoryStream memoryStream = new MemoryStream(serializedObj);
			BinaryFormatter formatter = new BinaryFormatter();
			State requestedState = (State) formatter.Deserialize(memoryStream);
			return requestedState;
		}

	}
}
