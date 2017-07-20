//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// SharedTransitionSettings.cs
//
// This file contains the implementations of the SharedTransitionSettings class.
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
using System.Xml;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// The SharedTransitionSettings class is a representation of the 
	/// shared transition configuration defined in the configuration file.
	/// </summary>
	public class SharedTransitionSettings
	{
		#region Declares variables
		private const string AttributeNavigateValue = "navigateValue";
		private const string AttributeView = "navigateTo";
		private string _navigateValue;
		private string _view;
		#endregion

		#region Constructor
		/// <summary>
		/// Overloaded. Initializes a new instance of the SharedTransitionSettings class.
		/// </summary>
		public SharedTransitionSettings( )
		{
		}

		/// <summary>
		/// Overloaded. Initializes an instance of the SharedTransitionSettings class using the specified configNode.
		/// </summary>
		/// <param name="configNode">The XmlNode from the configuration file.</param>
		public SharedTransitionSettings( XmlNode configNode )
		{
			LoadAttributes(configNode);
		}

		private void LoadAttributes(XmlNode configNode)
		{
			XmlNode currentAttribute = configNode.Attributes.RemoveNamedItem(AttributeNavigateValue);
			if( currentAttribute.Value.Trim().Length > 0 )
				_navigateValue = currentAttribute.Value;
			else
				throw new ConfigurationException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionInvalidXmlAttributeValue, AttributeNavigateValue, configNode.Name ) );

			currentAttribute = configNode.Attributes.RemoveNamedItem(AttributeView);
			if( currentAttribute.Value.Trim().Length > 0 )
				_view = currentAttribute.Value;
			else
				throw new ConfigurationException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionInvalidXmlAttributeValue, AttributeView, configNode.Name ) );
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the navigation value.
		/// </summary>
		public string NavigateValue
		{
			get{ return _navigateValue; }
		}

		/// <summary>
		/// Gets or sets the view name.
		/// </summary>
		public string View
		{
			get{ return _view; }
		}
		#endregion
	}
}

