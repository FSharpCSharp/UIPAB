//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// NavigateToSettings.cs
//
// This file contains the implementations of the NavigateToSettings class.
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
using System.Xml;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// Class that defines the navigateTo settings within the UIP configuration settings in the configuration file.
	/// </summary>
	public class NavigateToSettings
	{
		#region Declares variables
		/// <summary>
		/// Key used to retrieve the navigateValue attribute for this navigateToSettings object.
		/// </summary>
		internal const string AttributeNavigateValue = "navigateValue";
		/// <summary>
		/// Key used to retrieve the view attribute for this navigateToSettings object.
		/// </summary>
		internal const string AttributeView = "view";
		private string _navigateValue;
		private string _view;
		#endregion

		#region Constructor
		/// <summary>
		/// Creates an instance of the NavigationToSettings class using the specified configNode.
		/// </summary>
		/// <param name="configNode">The XmlNode from the configuration file.</param>
		public NavigateToSettings( XmlNode configNode )
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
