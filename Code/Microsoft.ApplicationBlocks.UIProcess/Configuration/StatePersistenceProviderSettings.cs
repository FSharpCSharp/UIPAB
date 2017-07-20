//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// StatePersistenceProviderSettings.cs
//
// This file contains the implementations of the StatePersistenceProviderSettings class.
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
	/// The StatePersistenceProviderSettings class is a representation of the 
	/// state persistence configuration defined in the configuration file.
	/// </summary>
	public class StatePersistenceProviderSettings : ObjectTypeSettings
	{
		#region Declares Variables
		private NameValueCollection _attributes;
		#endregion

		#region Constructor

		/// <summary>
		/// Creates an instance of the StatePersistenceProviderSettings class using the specified configNode.
		/// </summary>
		public StatePersistenceProviderSettings( XmlNode configNode ) : base( configNode )
		{
			LoadAttributes(configNode);
		}

		private void LoadAttributes(XmlNode configNode)
		{
			_attributes = new NameValueCollection();
			foreach( XmlAttribute currentAttribute in configNode.Attributes )
			{
				_attributes.Add( currentAttribute.Name, currentAttribute.Value );
			}
		}
		#endregion

		#region Properties

		/// <summary>
		/// Gets the state persistence attributes.
		/// </summary>
		public NameValueCollection AdditionalAttributes
		{
			get { return _attributes; }
		}
		#endregion
	}
}
