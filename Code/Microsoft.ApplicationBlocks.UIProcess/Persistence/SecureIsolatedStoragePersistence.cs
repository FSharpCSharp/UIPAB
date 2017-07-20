//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// SecureIsolatedStoregePersistence.cs
//
// This file contains the implementations of the SecureIsolatedStoregePersistence class
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
	/// The IStatePersistence implementation.
	/// This provider encrypts the serialized data by using a symmetric algorithm.
	/// The algorithm key is obtained from the LOCAL_MACHINE hive in the Windows registry.
	/// </summary>
	public class SecureIsolatedStoragePersistence : IsolatedStoragePersistence
	{
		private CryptHelper _cryptHelper;
		private const string ConfigDefaultRegistryValue	= @"SOFTWARE\Microsoft\UIP Application Block";
		private const string ConfigRegistry = "registryPath";

		/// <summary>
		/// The possible provider config attributes are:
		///   - registryPath: Specifies the registry key path where the
		///                   encryption symmetric key is stored. 
		/// </summary>
		/// <param name="statePersistenceParameters">The collection of configuration information to be used by
		/// the persistence provider.</param>
		public override void Init(System.Collections.Specialized.NameValueCollection statePersistenceParameters) 
		{
			string registryPath = statePersistenceParameters[ConfigRegistry];
			if( registryPath == null )
				registryPath = ConfigDefaultRegistryValue;

			_cryptHelper = new CryptHelper(registryPath);
		}

		/// <summary>
		/// Deserializes an encrypted byte array into a State object.
		/// </summary>
		/// <param name="serializedObject">Encrypted byte array that will be deserialized to a State object.</param>
		/// <returns>A valid State object.</returns>
		protected override State FromByteArray(byte[] serializedObject)
		{
			byte[] plain = _cryptHelper.Decrypt(serializedObject);
			return base.FromByteArray (plain);
		}

		/// <summary>
		/// Converts a State object to an encrypted array of bytes.
		/// </summary>
		/// <param name="state">The state object to convert.</param>
		/// <returns>The array of encrypted bytes that represent the serialized state object.</returns>
		protected override byte[] ToByteArray(State state)
		{
			byte[] plain = base.ToByteArray (state);
			return _cryptHelper.Encrypt(plain);
		}

	}
}
