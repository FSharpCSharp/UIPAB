//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// NodeSettings.cs
//
// This file contains the implementations of the NodeSettings class.
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
using System.Xml;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// Represents the settings defined by the Node element in the configuration file.
	/// </summary>
	public class NodeSettings
	{
		#region Declares variables
		/// <summary>
		/// Key used to retrieve the view attribute for this object.
		/// </summary>
		internal const string AttributeView = "view";
		/// <summary>
		/// Key used to retrieve the navigateTo attribute for this object.
		/// </summary>
		internal const string NodeNavigateTo = "navigateTo";
		private string _view;
		private HybridDictionary _navigateToCollection;
		#endregion

		#region Constructor
		/// <summary>
		/// Overloaded. Default contructor.
		/// </summary>
		public NodeSettings( )
		{
			_navigateToCollection = new HybridDictionary();
		}

		/// <summary>
		/// Overloaded. Initializes an instance of the NodeSettings class using the specified configNode.
		/// </summary>
		/// <param name="configNode">The XmlNode from the configuration file.</param>
		public NodeSettings( XmlNode configNode ):this()
		{
			LoadAttributes(configNode);

			LoadNavigationElements(configNode);
		}


		private void LoadNavigationElements(XmlNode configNode)
		{			
			foreach(XmlNode currentNode in configNode.SelectNodes( NodeNavigateTo ) )
			{
				NavigateToSettings navigateTo = new NavigateToSettings( currentNode );
				_navigateToCollection.Add( navigateTo.NavigateValue, navigateTo );
			}
		}


		private void LoadAttributes(XmlNode configNode)
		{
			XmlNode currentAttribute = configNode.Attributes.RemoveNamedItem(AttributeView);
			if( currentAttribute.Value.Trim().Length > 0  )
				_view = currentAttribute.Value;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the specifed navigateTo settings.
		/// </summary>
		public NavigateToSettings this[ string navigateValue ]
		{
			get{ return (NavigateToSettings)_navigateToCollection[ navigateValue ]; }
		}

		/// <summary>
		/// Gets the view name.
		/// </summary>
		public string View
		{
			get{ return _view; }
		}
		#endregion
	}
}
