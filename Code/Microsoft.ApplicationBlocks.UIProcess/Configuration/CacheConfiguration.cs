//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// CacheConfiguration.cs
//
// This file contains the implementations of the CacheConfiguration class.
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
	/// Stores information needed to configure the state cache.
	/// </summary>
	public class CacheConfiguration
	{
		private CacheExpirationMode _mode;
		private TimeSpan _interval;

		/// <summary>
		/// Create a CacheConfiguration object.
		/// </summary>
		/// <param name="mode">The expiration mode for the cache. <see cref="CacheExpirationMode"/></param>
		/// <param name="interval">How often to check for expiration.</param>
		public CacheConfiguration(CacheExpirationMode mode, TimeSpan interval)
		{
			_mode = mode;
			_interval = interval;
		}

		/// <summary>
		/// The expiration mode of the cache. <see cref="CacheExpirationMode"/>
		/// </summary>
		public CacheExpirationMode Mode
		{
			get { return _mode; }
		}

		/// <summary>
		/// The expiration interval for the cache.
		/// </summary>
		public TimeSpan Interval
		{
			get { return _interval; }
		}
	}
}
