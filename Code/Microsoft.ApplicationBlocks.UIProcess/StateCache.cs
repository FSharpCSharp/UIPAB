//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// StateCache.cs
//
// This file contains the implementations of the StateCache class.
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
using System.Diagnostics;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	#region CacheEntry class definition
	/// <summary>
	/// This class represents an entry in the state cache.
	/// </summary>
	public class CacheEntry
	{
		private DateTime _itemAge = DateTime.MinValue;
		private object _value;

		/// <summary>
		/// Overloaded. Initializes a new CacheEntry class with a value and an expiration time.
		/// </summary>
		/// <param name="value">The item value.</param>
		/// <param name="itemAge">The item age. Specifies that the item expires.</param>
		public CacheEntry( object value, DateTime itemAge )
		{
			_itemAge = itemAge;
			_value = value;
		}

		/// <summary>
		/// Overloaded. Initializes a new CacheEntry class that never expires and has a value.
		/// </summary>
		/// <remarks>The item never expires.</remarks>
		/// <param name="value">The item value.</param>
		public CacheEntry( object value )
		{
			_value = value;
		}

		/// <summary>
		/// Specifies if the item has expired.
		/// </summary>
		public bool IsExpired
		{
			get
			{ 
				if( _itemAge.Equals( DateTime.MinValue ) ) //The item never expires
					return false;
				else
					return DateTime.Now > _itemAge; 
			}
		}

		/// <summary>
		/// Gets the item value.
		/// </summary>
		public object Value
		{
			get { return _value; } 
		}
	}
	#endregion
	/// <summary>
	/// Object used to provide caching services for State objects.
	/// </summary>
	public sealed class StateCache
	{
		#region Declarations
		private static ListDictionary _stateCache;
		#endregion

		#region Constructors

		/// <summary>
		/// Static constructor.
		/// </summary>
		static StateCache()
		{
			_stateCache = new ListDictionary();
		}


		private StateCache(){}

		#endregion

		/// <summary>
		/// Creates a new cache entry.
		/// </summary>
		/// <param name="mode">The cache expiration mode.</param>
		/// <param name="interval">The cache expiration interval.</param>
		/// <param name="cacheValue">The cache value.</param>
		/// <returns>A valid CacheEntry object.</returns>
		public static CacheEntry CreateCacheEntry( CacheExpirationMode mode, TimeSpan interval, object cacheValue )
		{
			DateTime now = DateTime.Now;
			switch( mode )
			{
				case CacheExpirationMode.Absolute:
					DateTime absoluteDate = new DateTime( now.Year, now.Month, now.Day ).Add( interval );
					if( absoluteDate > now )
						return new CacheEntry( cacheValue, absoluteDate );
					else
						return new CacheEntry( cacheValue, absoluteDate.AddDays( 1 ) ); 
				case CacheExpirationMode.Sliding:
					return new CacheEntry( cacheValue, DateTime.Now.Add( interval ) );
				default:
					return new CacheEntry( cacheValue );
			}
		}

		/// <summary>
		/// Looks up a State object from the cache for the specified navigation graph and task ID.
		/// </summary>
		/// <param name="taskId">The task identifier (a GUID associated with the task).</param>
		/// <returns>The State object.</returns>
		public static State LoadFromCache( Guid taskId )
		{		 
			State state = null;

			//  attempt to retrieve from cache
			CacheEntry cacheEntry = (CacheEntry)_stateCache[taskId];

			if( cacheEntry != null )
			{
				//Check if the entry has expired
				if( !cacheEntry.IsExpired )
				{
					WeakReference weakReference = (WeakReference)cacheEntry.Value;
					if( weakReference.IsAlive )
						state = (State)weakReference.Target;
				}
			}

			//  return it
			return state;
		}

		/// <summary>
		/// Stores the state in StateCache.
		/// </summary>
		/// <param name="state">The state to be cached.</param>
		/// <param name="navigationGraph">The name of the navigation graph.</param>
		/// <param name="trackResurection">Indicates when to stop tracking the object. If true, the object is tracked after finalization; if false, the object is tracked only until finalization. </param>
		public static void PutStateInCache(State state, string navigationGraph, bool trackResurection) 
		{
			//Get expiration configuration
			CacheConfiguration cacheConfig = UIPConfiguration.Config.GetCacheConfiguration(navigationGraph); 

			//  Create a new StateCacheEntry object using the existing state object and cache configuration
			CacheEntry stateCache = CreateCacheEntry( cacheConfig.Mode, cacheConfig.Interval, new WeakReference( state, trackResurection ) );

			//  PUT IT IN Cache, we manage State Cache in State Factory...
			//  as with all other concrete Factory implementations...
			lock( _stateCache.SyncRoot )
			{
				_stateCache[state.TaskId] = stateCache ;
				Debug.Assert( ( _stateCache[state.TaskId] == stateCache ) , "Cache object DID NOT contain StateCacheEntry just added to it.", "");
			}
		}

		/// <summary>
		/// Stores the state in the StateCache.
		/// </summary>
		/// <param name="state">The state to be cached.</param>
		/// <param name="trackResurection">Indicates when to stop tracking the object. If true, the object is tracked after finalization; if false, the object is tracked only until finalization.</param>
		public static void PutStateInCache(State state, bool trackResurection) 
		{
			//Get expiration configuration
			CacheConfiguration cacheConfig = UIPConfiguration.Config.GetCacheConfiguration(); 

			//  Create a new StateCacheEntry object using the existing state object and cache configuration
			CacheEntry stateCache = CreateCacheEntry( cacheConfig.Mode, cacheConfig.Interval, new WeakReference( state, trackResurection ) );

			//  PUT IT IN Cache, we manage State Cache in State Factory...
			//  as with all other concrete Factory implementations...
			lock( _stateCache.SyncRoot )
			{
				_stateCache[state.TaskId] = stateCache ;
				Debug.Assert( ( _stateCache[state.TaskId] == stateCache ) , "Cache object DID NOT contain StateCacheEntry just added to it.", "");
			}
		}

		/// <summary>
		/// Remove the state for a given task from the StateCache.
		/// </summary>
		/// <param name="taskId">The task identifier (a GUID associated with the task).</param>
		public static void RemoveFromCache(Guid taskId) 
		{
			lock( _stateCache.SyncRoot ) 
			{
				_stateCache.Remove(taskId);
			}
		}
	}
}
