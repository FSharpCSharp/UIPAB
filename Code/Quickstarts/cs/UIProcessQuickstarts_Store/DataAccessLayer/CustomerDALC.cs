//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// CustomerDALC.cs
//
// This file contains the implementations of the CustomerDALC class.
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
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace UIProcessQuickstarts_Store
{
	public class CustomerDALC : BaseDALC
	{
		public CustomerDALC() : base()
		{
		}
		
		/// <summary>
		/// Gets the customer info
		/// </summary>
		/// <param name="customerDS">a dataset that will be used to store the customer info</param>
		/// <param name="email">customer email</param>
        public void GetCustomerByEmail( CustomerDS customerDS, string email )
		{
					try
					{
						SqlDataReader reader = null;				
						using ( reader = SqlHelper.ExecuteReader( this.connectionString, 
							CommandType.StoredProcedure,
							"SelectCustomerByEmail",
							new SqlParameter[] { new SqlParameter( "@EmailAddress", email ) } ))
						{
							SqlHelperExtension.Fill( reader, customerDS, customerDS.Customers.TableName, 0, 1 );				
						}											
					}
					catch (Exception e)
					{
						throw new ApplicationException( String.Format(ResourceManager.GetString( "RES_ExceptionCantGetCustomer" ), email), e);
					}
		}
	}
}
