//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// UIPConfigHandler.cs
//
// This file contains the implementations of the UIPConfigHandler class.
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
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// The configuration section handler for the uipConfiguration section of the configuration file. 
	/// </summary>
	public class UIPConfigHandler : IConfigurationSectionHandler
	{
		private bool _isValidDocument = true;
		private string _schemaErrors;
		
		/// <summary>
		/// Default constructor.
		/// </summary>
		public UIPConfigHandler(){}

		/// <summary>
		/// Factory method that creates a configuration handler for a specific section of XML in the app.config.
		/// </summary>
		/// <param name="parent">Unused; was for future development (should be removed).</param>
		/// <param name="input">Unused; was for future development (should be removed).</param>
		/// <param name="section">The node.</param>
		/// <returns>UIPConfigSettings for the section.</returns>
		public object Create(object parent, object input, XmlNode section) 
		{			
			return Create(parent, input,section, System.Globalization.CultureInfo.CurrentCulture);
		}

		/// <summary>
		/// Factory method that creates a configuration handler for a specific section of XML in the app.config.
		/// </summary>
		/// <param name="parent">Unused; was for future development (should be removed).</param>
		/// <param name="input">Unused; was for future development (should be removed).</param>
		/// <param name="section">The node.</param>
		/// <param name="formatProvider">The format provider.</param>
		/// <returns>UIPConfigSettings for the section.</returns>
		public object Create(object parent, object input, XmlNode section, IFormatProvider formatProvider)
		{
			ValidateSchema( section );
			UIPConfigSettings config = new UIPConfigSettings(section,formatProvider); 
			return config;
		}

		private void ValidateSchema( XmlNode section )
		{
			XmlValidatingReader validatingReader = null;
			Stream xsdFile = null; 
			StreamReader streamReader = null; 
			try
			{
				//Validate the document using a schema
				validatingReader = new XmlValidatingReader( new XmlTextReader( new StringReader( section.OuterXml ) ) );
				validatingReader.ValidationType = ValidationType.Schema;

				xsdFile = Resource.ResourceManager.GetStream( "UIPConfigSchema.xsd" ); 
				streamReader = new StreamReader( xsdFile ); 

				validatingReader.Schemas.Add( XmlSchema.Read( new XmlTextReader( streamReader ), null ) );
				validatingReader.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

				// Validate the document
				while (validatingReader.Read()){}

				if( !_isValidDocument )
				{
					throw new ConfigurationException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionDocumentNotValidated, _schemaErrors ) );
				}
			}
			finally
			{
				if( validatingReader != null ) validatingReader.Close();
				if( xsdFile != null ) xsdFile.Close();
				if( streamReader != null ) streamReader.Close();
			}
		}

		private void ValidationCallBack( object sender, ValidationEventArgs args )
		{
			_isValidDocument = false;
			_schemaErrors += args.Message + Environment.NewLine;
		}

	}
}
