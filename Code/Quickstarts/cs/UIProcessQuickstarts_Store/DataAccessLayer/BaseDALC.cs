//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// BaseDALC.cs
//
// This file contains the implementations of the BaseDALC class.
//
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
using System.Reflection;
using System.Resources;
using System.Collections.Specialized;

namespace UIProcessQuickstarts_Store
{
	/// <summary>
	/// This class is intended to be extended by the entity DALCs components in 
	/// order to share behavior between the Entity DALCs.
	/// </summary>
	public class BaseDALC
	{
		private const string CONFIG_CONNECTION_STRING = "connectionString";
		
		/// <summary>
		/// Keep the connection string from the database
		/// </summary>
		protected string connectionString;

		protected static ResourceManager ResourceManager = new ResourceManager( typeof( BaseDALC ).Namespace + ".DALCText", Assembly.GetExecutingAssembly() );

		public BaseDALC()
		{
			// retrieve the key value pairs from the appParams section of the configuration file
			NameValueCollection values = (NameValueCollection)ConfigurationSettings.GetConfig( "appParams" ); 
			if (values == null)
				throw new ConfigurationException( ResourceManager.GetString( "RES_ExceptionStoreConfigNotFound" ) );
			
			// read the database connection string from the configuration information and store it in the connection
			// string property
			string connectionString = values[CONFIG_CONNECTION_STRING];
			if (connectionString == null)
				throw new ConfigurationException( ResourceManager.GetString( "RES_ExceptionStoreConfigConnection" ) );
			 
			this.connectionString = connectionString;
		}
	}
}
