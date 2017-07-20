//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// StateFactory.cs
//
// This file contains the implementations of the StateFactory class.
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
using System.Diagnostics;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// Factory for creating State objects. 
	/// </summary>
	public sealed class StateFactory
	{
		#region Constructors

		private StateFactory(){}

		#endregion

		/// <summary>
		/// Loads a State object based on the navigation graph and task ID. Internally, attempts to get the object
		/// from the cache first, then creates state persistence provider, and uses it to load explicitly.
		/// </summary>
		/// <param name="navigationGraph">A navigation graph.</param>
		/// <param name="taskId">The task identifier (a GUID associated with the task).</param>
		/// <returns>State</returns>
		public static State Load( string navigationGraph, Guid taskId )
		{
			State state = null;

			if( UIPConfiguration.Config.IsStateCacheEnabled )
			{
				state = StateCache.LoadFromCache( taskId );

				if( state == null )
				{
					//State is not there in the cache, so a new state will be created here
					IStatePersistence spp = StatePersistenceFactory.Create( navigationGraph );
					state = Load( spp, taskId );

					StateCache.PutStateInCache(state, navigationGraph, false);
				}
			}
			else
			{
				//The cache is disabled, so a new one is created
				IStatePersistence spp = StatePersistenceFactory.Create( navigationGraph );
				state = Load( spp, taskId );
			}

			return state;
		}

		/// <summary>
		/// Loads the state for a given task identifier.
		/// </summary>
		/// <param name="taskId">The task identifier (a GUID associated with the task).</param>
		/// <returns>The state.</returns>
		public static State Load (Guid taskId) 
		{
			State state = null;

			if ( UIPConfiguration.Config.IsStateCacheEnabled ) 
			{
				state = StateCache.LoadFromCache( taskId );

				if( state == null )
				{
					//State is not there in the cache, so a new state will be created here
					IStatePersistence spp = StatePersistenceFactory.Create(  );
					state = Load( spp, taskId );

					StateCache.PutStateInCache(state, false);
				}
			}
			else
			{
				//The cache is disabled, so a new one is created
				IStatePersistence spp = StatePersistenceFactory.Create( );
				state = Load( spp, taskId );
			}

			return state;
		}

		
		/// <summary>
		/// Uses the task ID to explicitly load the state from the provided IStatePersistence instance.
		/// Note that this overload does not attempt to fetch from the cache.
		/// </summary>
		/// <param name="statePersistenceProvider"></param>
		/// <param name="taskId"></param>
		/// <returns></returns>
		internal static State Load( IStatePersistence statePersistenceProvider, Guid taskId) 
		{
			State state = statePersistenceProvider.Load(taskId);
            
			if( state != null )
				state.Accept(statePersistenceProvider);
			else
				throw new UIPException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionTaskNotFound, taskId ) );

			return state;	
		}
	
		/// <summary>
		/// Creates the default State object, loading it from the persistence provider.
		/// </summary>
		/// <returns>Default state instance of type specified in the configuration file.</returns>
		public static State Create() 
		{
			IStatePersistence spp = StatePersistenceFactory.Create();
			ObjectTypeSettings typeSettings = UIPConfiguration.Config.DefaultState;

			State state = Create( spp, typeSettings );
			
			if ( UIPConfiguration.Config.IsStateCacheEnabled ) 
			{
				StateCache.PutStateInCache(state, true);
			}

			return state;
		}

		/// <summary>
		/// Creates a State object, loading it from persistence provider.
		/// </summary>
		/// <param name="navigatorName">Name of the navigator.</param>
		/// <returns>State instance of the type specified in the configuration file.</returns>
		public static State Create( string navigatorName )
		{
			//  Create a State persistence provider to be used by the state object
			IStatePersistence spp = StatePersistenceFactory.Create( navigatorName );
			ObjectTypeSettings typeSettings = UIPConfiguration.Config.GetStateSettings(navigatorName);
			
			State state = Create( spp, typeSettings );

			//Check if the cache is enabled
			if( UIPConfiguration.Config.IsStateCacheEnabled )
			{
				StateCache.PutStateInCache(state, navigatorName, true);
			}

			return state;

		}

		/// <summary>
		/// Creates a State object, loading it from persistence provider.
		/// </summary>
		/// <param name="spp">The state persistence provider.</param>
		/// <param name="typeSettings">The state settings.</param>
		/// <returns>A state instance of the type specified in the configuration file.</returns>
		internal static State Create( IStatePersistence spp, ObjectTypeSettings typeSettings ) 
		{
			State state = null;
			Guid taskId = Guid.Empty;
		
			if( typeSettings == null )
				throw new UIPException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionStateConfigNotFound, "" ) );
	
			//  set the arguments used by the State object constructor
			object[] args = {spp};


			try 
			{
				//  pass to Base class' reflection code
				//  DON'T look for this State in Cache, "CREATE" semantics in this class
				//  demand that we create it freshly...
				//  UNLIKE other Factories, State is stateful and we don't recycle in Create;
				//  instead if the consuming class wishes a Cached entry, they might get it
				//  from Load() methods instead...
				state = (State)GenericFactory.Create( typeSettings, args );
			}
			catch (Exception e)
			{
				throw new ConfigurationException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionCantCreateState, typeSettings.Type ), e );
			}

			//  create a new Task id
			taskId = Guid.NewGuid();

			//  store the task id into the state object 
			state.TaskId = taskId;

			//  return it
			return state;
		}
	}


}
