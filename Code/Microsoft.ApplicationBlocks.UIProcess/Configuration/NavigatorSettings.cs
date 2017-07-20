//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// NavigatorSettings.cs
//
// This file contains the implementations of the NavigatorSettings class.
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
using System.Xml;
using System.Configuration;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// Base class that encapsulates information from the configuration file that is common
	/// to different types of navigators.
	/// </summary>
	public class NavigatorSettings
	{
		/// <summary>
		/// Key used to retrieve the viewManager attribute for this object.
		/// </summary>
		internal const string AttributeIViewManager = "iViewManager";
		/// <summary>
		/// Key used to retrieve the name attribute for this object.
		/// </summary>
		internal const string AttributeName = "name";
		/// <summary>
		/// Key used to retrieve the state attribute for this object.
		/// </summary>
		internal const string AttributeState = "state";
		/// <summary>
		/// /// Key used to retrieve the statePersist attribute for this object.
		/// </summary>
		internal const string AttributeStatePersist = "statePersist";
		/// <summary>
		/// /// Key used to retrieve the cacheExpirationMode attribute for this object.
		/// </summary>
		internal const string AttributeExpirationMode = "cacheExpirationMode";
		/// <summary>
		/// /// Key used to retrieve the cacheExpirationInterval attribute for this object.
		/// </summary>
		internal const string AttributeExpirationInterval = "cacheExpirationInterval";

		private string _name;
		private string _state;
		private string _statePersist;
		private string _iViewManager;
		private CacheExpirationMode _expirationMode = CacheExpirationMode.None;
		private TimeSpan _expirationInterval = TimeSpan.MinValue;

		/// <summary>
		/// Creates a NavigatorSettings object.
		/// </summary>
		public NavigatorSettings()
		{
		}

		/// <summary>
		/// Initializes properties based on settings in the configuration file.
		/// </summary>
		/// <param name="configNode">The XmlNode from the configuration file.</param>
		protected virtual void LoadAttributes(XmlNode configNode) 
		{
			XmlNode currentAttribute;

			//Read iViewManager attribute
			currentAttribute = configNode.Attributes.RemoveNamedItem(AttributeIViewManager);
			if( currentAttribute.Value.Trim().Length > 0 )
				_iViewManager = currentAttribute.Value;
			else
				throw new ConfigurationException( Resource.ResourceManager.FormatMessage( "RES_ExceptionInvalidXmlAttributeValue", AttributeIViewManager, configNode.Name ) );

			LoadRemainingAttributes(configNode);
		}


		/// <summary>
		/// Loads the remaining attributes from the configuration file.
		/// </summary>
		/// <param name="configNode">The XmlNode from the configuration file.</param>
		protected void LoadRemainingAttributes(XmlNode configNode)
		{
			XmlNode currentAttribute;
			//Read name attribute
			currentAttribute = configNode.Attributes.RemoveNamedItem(AttributeName);
			if( currentAttribute.Value.Trim().Length > 0 )
				_name = currentAttribute.Value;
			else
				throw new ConfigurationException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionInvalidXmlAttributeValue, AttributeName, configNode.Name ) );

			//Read state attribute
			currentAttribute = configNode.Attributes.RemoveNamedItem(AttributeState);
			if( currentAttribute.Value.Trim().Length > 0 )
				_state = currentAttribute.Value;
			else
				throw new ConfigurationException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionInvalidXmlAttributeValue, AttributeState, configNode.Name ) );

			//Read statePersist attribute
			currentAttribute = configNode.Attributes.RemoveNamedItem(AttributeStatePersist);
			if( currentAttribute.Value.Trim().Length > 0 )
				_statePersist = currentAttribute.Value;
			else
				throw new ConfigurationException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionInvalidXmlAttributeValue, AttributeStatePersist, configNode.Name ) );

			//Read cache expiration attributes
			currentAttribute = configNode.Attributes.RemoveNamedItem(AttributeExpirationMode);
			if( currentAttribute != null )
			{
				_expirationMode = (CacheExpirationMode)Enum.Parse( typeof( CacheExpirationMode), currentAttribute.Value, true ); 
                
				currentAttribute = configNode.Attributes.RemoveNamedItem(AttributeExpirationInterval);
				try
				{
					switch (_expirationMode)
					{
						case CacheExpirationMode.Sliding:
							_expirationInterval = new TimeSpan( 0, 0, 0, 0, int.Parse( currentAttribute.Value, System.Globalization.CultureInfo.InvariantCulture ) );
							break;
						case CacheExpirationMode.Absolute:
							_expirationInterval = TimeSpan.Parse( currentAttribute.Value ); 
							if( _expirationInterval.Days > 0 )
								throw new ConfigurationException( Resource.ResourceManager[ Resource.Exceptions.RES_ExceptionInvalidAbsoluteInterval ] );
							break;
					}
				}
				catch( Exception e )
				{
					throw new ConfigurationException( Resource.ResourceManager[ Resource.Exceptions.RES_ExceptionInvalidCacheExpirationInterval ], e );
				}
			}
		}

		/// <summary>
		/// Gets the IViewManager name.
		/// </summary>
		public string ViewManager
		{
			get{ return _iViewManager; }
		}

		/// <summary>
		/// Gets the navigation graph name.
		/// </summary>
		public string Name
		{
			get{ return _name; }
		}

		/// <summary>
		/// Gets the State object type used by this navigation graph.
		/// </summary>
		public string State
		{
			get{ return _state; }
		}

		/// <summary>
		/// Gets the state persistence provider used by this navigation graph.
		/// </summary>
		public string StatePersist
		{
			get{ return _statePersist; }
		}

		/// <summary>
		/// Gets the state cache expiration mode.
		/// </summary>
		public CacheExpirationMode CacheExpirationMode
		{
			get{ return _expirationMode; }
		}

		/// <summary>
		/// Gets the state cache expiration interval.
		/// </summary>
		public TimeSpan CacheExpirationInterval
		{
			get{ return _expirationInterval; }
		}
	}
}
