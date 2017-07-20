//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// CustomerBusinessObject.cs
//
// This file contains the implementations of the CustomerBusinesObject class.
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

namespace UIProcessQuickstarts_Store
{
	/// <summary>
	/// This class contains all the customer related business rules
	/// </summary>
	public class CustomerBusinessObject : BaseBusinessObject
	{
		public CustomerBusinessObject():base()
		{
		}

		/// <summary>
		/// Gets customer information
		/// </summary>
		/// <param name="logon">customer logon</param>
        public CustomerDS GetCustomerByLogon( string logon )
		{
			CustomerDS customerDS = new CustomerDS();
			CustomerDALC customerDALC = new CustomerDALC();
				
			customerDALC.GetCustomerByEmail( customerDS, logon );
				
			return customerDS;
		}
		
		/// <summary>
		/// Authenticates a specified user
		/// </summary>
		/// <returns>Customer id</returns>
		public int Logon( string email, string password )
		{
			try
			{
				int customerId = 0;
				
				CustomerDS customerDS = new CustomerDS();
				CustomerDALC customerDALC = new CustomerDALC();
				
				customerDALC.GetCustomerByEmail( customerDS, email );
				
				if (customerDS.Customers.Rows.Count > 0)
				{
					if( (string)customerDS.Customers[0].Password == password )
						customerId = (int)customerDS.Customers[0].CustomerId;
				}
				
				return customerId;
			}
			catch(Exception e )
			{
				throw new ApplicationException( ResourceManager.GetString( "RES_ExceptionCantAuthenticateCustomer" ), e );
			}
		}
	}
}
