//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// CryptHelper.cs
//
// This file contains the implementations of the CryptHelper class.
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

using System;
using System.IO;
using System.Security.Permissions;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// Helper class used to perform encryption/decryption of information.
	/// </summary>
	internal class CryptHelper
	{
		private const string ConfigRegistryValue = "symmetric key";
		private readonly byte[] IV = { 162, 239, 121, 27, 111, 214, 206, 34 };
		private RegistryKey _registryKey;

		/// <summary>
		/// Initializes a new instance of the CryptHelper class.
		/// </summary>
		/// <param name="registryPath">Path to the registry key that contains the key used to
		/// perform encryption and decription.</param>
		internal CryptHelper(string registryPath) 
		{
			try
			{
				//Request the permission to access the given registry key.
				RegistryPermission permission = new RegistryPermission( RegistryPermissionAccess.Read, Registry.LocalMachine.Name + "\\" + registryPath ); 
				permission.Demand();
			}
			catch( System.Security.SecurityException e )
			{
				throw new UIPException( Resource.ResourceManager[Resource.Exceptions.RES_ExceptionSecureSqlProviderRegistryPermissions]+UIPException.GetFirstExceptionMessage(e), e );
			}

            
			_registryKey = Registry.LocalMachine.OpenSubKey( registryPath, false );
			
			if( _registryKey == null )
				throw new UIPException( Resource.ResourceManager[Resource.Exceptions.RES_ExceptionSecureSqlProviderSymmetricKey] );
		}

		/// <summary>
		/// Encrypts a stream of bytes by using a TripleDES symmetric algorithm.
		/// </summary>
		/// <param name="plainValue">Stream of bytes to be encrypted.</param>
		/// <param name="key">Symmetric algorithm key.</param>
		/// <returns>An encrypted stream of bytes.</returns>
		private byte[] Encrypt( byte[] plainValue, byte[] key )
		{
			byte[] chiperValue = {};

			TripleDES algorithm = TripleDESCryptoServiceProvider.Create();
			MemoryStream memStream = new MemoryStream();
            
			CryptoStream cryptoStream = new CryptoStream( memStream, algorithm.CreateEncryptor( key, IV ), CryptoStreamMode.Write );
            
			try
			{
				cryptoStream.Write( plainValue, 0, plainValue.Length );
				cryptoStream.Flush(); 
				cryptoStream.FlushFinalBlock(); 
    
				chiperValue = memStream.ToArray();
			}
			catch( Exception e )
			{
				throw new UIPException( Resource.ResourceManager[Resource.Exceptions.RES_ExceptionSecureSqlProviderCantEncrypt]+UIPException.GetFirstExceptionMessage(e), e );
			}
			finally
			{
				memStream.Close();
				cryptoStream.Close();
			}

			return chiperValue;
		}

		/// <summary>
		/// Decrypts an encrypted stream of bytes by using a TripleDES symmetric algorithm.
		/// </summary>
		/// <param name="cipherValue">The encrypted stream of bytes to be decrypted.</param>
		/// <param name="key">Symmetric algorithm key.</param>
		/// <returns>A stream of bytes.</returns>
		private byte[] Decrypt( byte[] cipherValue, byte[] key )
		{
			byte[] plainValue = new byte[ cipherValue.Length ];

			TripleDES algorithm = TripleDESCryptoServiceProvider.Create();
			MemoryStream memStream = new MemoryStream(cipherValue);
            
			CryptoStream cryptoStream = new CryptoStream( memStream, algorithm.CreateDecryptor( key, IV ), CryptoStreamMode.Read );
            
			try
			{
				cryptoStream.Read( plainValue, 0, plainValue.Length );
			}
			catch( Exception e )
			{
				throw new UIPException( Resource.ResourceManager[Resource.Exceptions.RES_ExceptionSecureSqlProviderCantDecrypt]+UIPException.GetFirstExceptionMessage(e), e );
			}
			finally
			{
				//Flush the stream buffer
				cryptoStream.Close();
			}

			return plainValue;
		}

		/// <summary>
		/// Encrypts a stream of bytes by using a TripleDES symmetric algorithm.
		/// </summary>
		/// <param name="plainValue">Stream of bytes to be encrypted.</param>		
		/// <returns>An encrypted stream of bytes.</returns>
		internal byte[] Encrypt( byte[] plainValue )
		{
			byte[] chiperValue = {};

			//Get encryption key
			byte[] key = GetKey();
            
			chiperValue = Encrypt( plainValue, key );

			//Clean encryption key
			key = new byte[0];

			return chiperValue;
		}

		/// <summary>
		/// Decrypts an encrypted stream of bytes by using a TripleDES symmetric algorithm.
		/// </summary>
		/// <param name="cipherValue">The encrypted stream of bytes to be decrypted.</param>		
		/// <returns>A stream of bytes.</returns>
		internal byte[] Decrypt( byte[] cipherValue )
		{
			byte[] plainValue = new byte[ cipherValue.Length ];

			//Get encryption key
			byte[] key = GetKey();
            
			plainValue = Decrypt( cipherValue, key );

			//Clean encryption key
			key = new byte[0];

			return plainValue;
		}

		private byte[] GetKey() 
		{
			string base64Key = _registryKey.GetValue( ConfigRegistryValue ).ToString(); 
			byte[] key = Convert.FromBase64String( base64Key ); 
			base64Key = null;
			return key;
		}
	}
}
