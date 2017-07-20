//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// ObjectTypeSettings.cs
//
// This file contains the implementations of the ObjectTypeSettings class.
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
	/// Base class for all providers settings within the UIP configuration settings in the configuration file.
	/// </summary>
	public class ObjectTypeSettings
	{
		#region Declares Variables
		private const string AttributeName = "name";
		private const string AttributeType = "type";
		private const string Comma = ",";

		private string _name;
		private string _type;
		private string _assembly;
		#endregion

		#region Constructors
		/// <summary>
		/// Overloaded. Default constructor.
		/// </summary>
		public ObjectTypeSettings(){}

		/// <summary>
		/// Overloaded. Initialized an instance of the ObjectTypeSettings class using the specified configNode.
		/// </summary>
		/// <param name="configNode">The XmlNode from the configuration file.</param>
		public ObjectTypeSettings( XmlNode configNode )
		{
			LoadAttributes(configNode);
		}

		private void LoadAttributes(XmlNode configNode)
		{
			XmlNode currentAttribute;
            
			//Gets the typed object attributes
			currentAttribute = configNode.Attributes.RemoveNamedItem(AttributeType);
			string fullType;
			if( currentAttribute.Value.Trim().Length > 0 )
				fullType = currentAttribute.Value;
			else
				throw new ConfigurationException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionInvalidXmlAttributeValue, AttributeType, configNode.Name ) );

			//  fix up type/asm strings
			SplitType( fullType );
			
			currentAttribute = configNode.Attributes.RemoveNamedItem(AttributeName);
			if( currentAttribute.Value.Trim().Length > 0 )
				_name = currentAttribute.Value;
			else
				throw new ConfigurationException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionInvalidXmlAttributeValue, AttributeName, configNode.Name ) );
		}
		#endregion

		/// <summary>
		/// Takes the incoming full type string, defined as: 
		/// "Microsoft.ApplicationBlocks.UIProcess.WinFormViewManager,   Microsoft.ApplicationBlocks.UIProcess, 
		///			Version=1.0.0.4, Culture=neutral, PublicKeyToken=d69d63db1380c14d"
		///  and splits the type into two strings: the typeName and the assemblyName. These are passed as OUT params. 
		///  This routine also cleans up any extra white space and throws an exception if the full type string
		///  does not have five comma-delimited parts. It expects the true full name, complete with version and publicKeyToken.
		/// </summary>
		/// <param name="fullType">The full type string defined in the configuration file.</param>
		private void SplitType( string fullType )
		{
			string[] parts = fullType.Split( Comma.ToCharArray() );

			if( parts.Length == 1 )
				_type = fullType;
			else if ( parts.Length == 5 )
			{
				//  set the object type name
				this._type = parts[0].Trim();
				
				//  set the object assembly name
				this._assembly = String.Concat( parts[1].Trim() + Comma,
					parts[2].Trim() + Comma,
					parts[3].Trim() + Comma,
					parts[4].Trim() );
			}
			else
				throw new ArgumentException( Resource.ResourceManager[ Resource.Exceptions.RES_ExceptionBadTypeArgumentInFactory ], "fullType" );
		}

		#region Properties
		/// <summary>
		/// Gets the object name.
		/// </summary>
		public String Name
		{
			get{ return _name; }
		}

		/// <summary>
		/// Gets the object fully qualified type name.
		/// </summary>
		public String Type
		{
			get{ return _type; }
		}

		/// <summary>
		/// Gets the object fully qualified assembly name.
		/// </summary>
		public String Assembly 
		{
			get { return _assembly; }
		}


		#endregion
	}
}
