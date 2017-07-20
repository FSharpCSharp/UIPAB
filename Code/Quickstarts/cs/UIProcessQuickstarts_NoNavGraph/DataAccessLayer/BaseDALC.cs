//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// BaseDAL.cs
//
// This file contains the implementations of the BaseDAL class.
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
		private string connectionString;

		protected static ResourceManager ResourceManager = new ResourceManager( typeof( BaseDALC ).Namespace + ".DALCText", Assembly.GetExecutingAssembly() );

		public BaseDALC()
		{
			NameValueCollection values = (NameValueCollection)ConfigurationSettings.GetConfig( "appParams" ); 
			if (values == null)
				throw new ConfigurationException( ResourceManager.GetString( "RES_ExceptionStoreConfigNotFound" ) );
				 
			string connectionString = values[CONFIG_CONNECTION_STRING];
			if (connectionString == null)
				throw new ConfigurationException( ResourceManager.GetString( "RES_ExceptionStoreConfigConnection" ) );
			 
			this.connectionString = connectionString;
		}

		protected string ConnectionString
		{
			get
			{
				return connectionString;
			}
			set
			{
				connectionString = value;
			}
		}
	}
}
