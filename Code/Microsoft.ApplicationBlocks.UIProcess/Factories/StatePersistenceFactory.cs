//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// StatePersistenceFactory.cs
//
// This file contains the implementations of the StatePersistenceFactory class.
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
using System.Configuration;
using System.Collections.Specialized;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// Abstract factory that creates IStatePersistence types.
	/// </summary>
	public sealed class StatePersistenceFactory
	{
		#region Declarations

		private static HybridDictionary _statePersistenceCache;

		#endregion 

		#region Constructors

		/// <summary>
		/// Static constructor.
		/// </summary>
		static StatePersistenceFactory()
		{
			_statePersistenceCache = new HybridDictionary(5, true);
		}


		private StatePersistenceFactory(){}


		#endregion

		/// <summary>
		/// Returns the default instance of IStatePersistence.
		/// </summary>
		/// <returns>An instance of IStatePersistence.</returns>
		public static IStatePersistence Create() 
		{
			return Create(UIPConfiguration.Config.DefaultStatePersistence);
		}

		/// <summary>
		/// Returns an instance of IStatePersistence according to the navigator used.
		/// This is an optimization to avoid having to look up type information in the config object each time; instead, it uses the navigator name.
		/// </summary>
		/// <param name="navigator">The navigator name.</param>
		/// <returns>An instance of IStatePersistence of the specified type. It gets this from the internal cache, if possible.</returns>
		public static IStatePersistence Create( string navigator )
		{
			StatePersistenceProviderSettings providerSettings = UIPConfiguration.Config.GetPersistenceProviderSettings( navigator );
			if( providerSettings == null )
				throw new UIPException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionStatePersistenceProviderConfigNotFound, navigator ) );

			return Create( providerSettings );
		}

		/// <summary>
		/// Returns an instance of <see cref="Microsoft.ApplicationBlocks.UIProcess.IStatePersistence"/>
		/// for the given <see cref="Microsoft.ApplicationBlocks.UIProcess.StatePersistenceProviderSettings"/>.
		/// </summary>
		/// <param name="providerSettings">The settings for  state persistence.</param>
		/// <returns>The instance of IStatePersistence. It gets this from the internal cache, if possible.</returns>
		public static IStatePersistence Create( StatePersistenceProviderSettings providerSettings ) 
		{
			string statePersistenceKey = providerSettings.Type + "," + providerSettings.Assembly;
			IStatePersistence spp = (IStatePersistence)_statePersistenceCache[ statePersistenceKey ];
			if( spp == null )
			{
				try
				{
					//  now create instance based on that type info
					spp = (IStatePersistence)GenericFactory.Create( providerSettings );
					
					//  pass in parameters to spp init method.  this is where spp's find data they need such as
					//  connection strings, etc.
					spp.Init(providerSettings.AdditionalAttributes);
				}
				catch ( Exception e )
				{
					throw new UIPException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionCantCreateStatePersistenceProvider, providerSettings.Type )+UIPException.GetFirstExceptionMessage(e), e );
				}
				
				//  lock collection
				lock (_statePersistenceCache.SyncRoot)
					_statePersistenceCache[statePersistenceKey] = spp;
			}

			//  return it
			return spp;
		}

	}


}
