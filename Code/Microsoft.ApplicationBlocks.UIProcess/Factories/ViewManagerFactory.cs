//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// ViewManagerFactory.cs
//
// This file contains the implementations of the ViewManagerFactory class.
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
using System.Configuration;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// Factory for creating view managers.
	/// </summary>
	internal sealed class ViewManagerFactory
	{
		#region Declarations

		private static HybridDictionary _viewManagerCache;

		#endregion

		#region Constructors

		/// <summary>
		/// Static constructor.
		/// </summary>
		static ViewManagerFactory()
		{
			_viewManagerCache = new HybridDictionary(5, true);
		}


		private ViewManagerFactory(){}

		#endregion


		/// <summary>
		/// Creates an IViewManager of a type specific to the named NavigationGraph. 
		/// If possible, it returns a reference from the internal cache because these are presumed to be stateless.
		/// </summary>
		/// <param name="navigator">The name of a navigator.</param>
		/// <returns>An instance of IViewManager. It gets this from the internal cache, if possible.</returns>
		public static IViewManager Create( string navigator )
		{
			return Create( navigator, null );
		}

		/// <summary>
		/// Creates an IViewManager of a type specific to the named NavigationGraph. 
		/// If possible, it returns a reference from the internal cache because these are presumed to be stateless.
		/// </summary>
		/// <param name="navigator">The name of a navigator.</param>
		/// <param name="args">The constructor parameter for ViewManager.</param>
		/// <returns>An instance of IViewManager. It gets this from the internal cache, if possible.</returns>
		public static IViewManager Create( string navigator, object[] args )
		{
			ObjectTypeSettings ivmSettings = null;
			
			//  check if we have an instance of requested ivm in cache
			IViewManager ivm = (IViewManager)_viewManagerCache[navigator];
			
			//  not found in cache--create, store in cache, and return
			if ( ivm == null )
			{
				//  get the type info from config
				//Get the view manager according to the configured application type
				ivmSettings = UIPConfiguration.Config.GetIViewManagerSettingsFromNavigatorName( navigator );
			
				if( ivmSettings == null )
					throw new ConfigurationException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionIViewManagerNotFound, navigator ) );
				try
				{
					//  activate an instance
					ivm = (IViewManager)GenericFactory.Create( ivmSettings, args );
				}
				catch ( Exception e )
				{
					throw new ConfigurationException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionCantCreateIViewManager, ivmSettings.Type ), e );
				}
							
				//  lock collection
				lock (_viewManagerCache.SyncRoot)
					_viewManagerCache[navigator] = ivm; //  add this IViewManager to the cache
			}
			
			//  return it
			return ivm;
			
		}
		/// <summary>
		/// Creates an IViewManager defined as DefaultViewManager. 
		/// </summary>
		/// <returns>An instance of IViewManager.</returns>
		public static IViewManager Create() 
		{
			ObjectTypeSettings ivmSettings = UIPConfiguration.Config.DefaultViewManager;
			IViewManager ivm = null;

			try
			{
				//  activate an instance
				ivm = (IViewManager)GenericFactory.Create( ivmSettings );
			}
			catch ( Exception e )
			{
				throw new ConfigurationException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionCantCreateIViewManager, ivmSettings.Type ), e );
			}

			return ivm;
		}

		/// <summary>
		/// Method to retrieve all of the active view managers.
		/// </summary>
		/// <returns>An array of active view managers.</returns>
		public static IViewManager[] GetViewManagers()
		{
			IViewManager[] views = new IViewManager[_viewManagerCache.Count];
			int i = 0;
			foreach(IViewManager view in _viewManagerCache.Values) 
			{
				views[i++] = view;
			}
			return views;
		}

	}


}
