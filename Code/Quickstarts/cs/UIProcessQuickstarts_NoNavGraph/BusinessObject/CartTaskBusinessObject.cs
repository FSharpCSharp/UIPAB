//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// CartTaskBusinessObject.cs
//
// This file contains the implementations of the CartTaskBusinessObject class.
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
	/// This class contains all the operations to map a user with a specific task
	/// </summary>
	public class CartTaskBusinessObject : BaseBusinessObject
	{
		public CartTaskBusinessObject():base()
		{
		}
		

		/// <summary>
		/// Gets the task related to the specified user
		/// </summary>
		public Guid GetTask( string logon )
		{
			try
			{
				CustomerDS customerDS = new CustomerDS(); 
				CustomerDALC customerDALC = new CustomerDALC();
				customerDALC.GetCustomerByEmail( customerDS, logon );
				
				int customerId = customerDS.Customers[0].CustomerId; 
				
				CartTaskDALC cartTaskDALC = new CartTaskDALC();
				return cartTaskDALC.GetTask( customerId );  
			}
			catch (Exception e)
			{
				throw new ApplicationException( ResourceManager.GetString( "RES_ExceptionGetTask" ), e );
			}
		}
		

		/// <summary>
		/// Gets the customer related to the specified task
		/// </summary>
		public int GetCustomerFromTask( Guid taskId )
		{
			try
			{
				CartTaskDALC cartTaskDALC = new CartTaskDALC();
				return cartTaskDALC.GetCustomerFromTask( taskId );  
			}
			catch (Exception e)
			{
				throw new ApplicationException( ResourceManager.GetString( "RES_ExceptionGetTask" ), e );
			}
		}


		/// <summary>
		/// Creates a new task for the specified user
		/// </summary>
		public void CreateTask( Guid taskId, string logon )
		{
			try
			{
				CustomerDS customerDS = new CustomerDS(); 
				CustomerDALC customerDALC = new CustomerDALC();
				customerDALC.GetCustomerByEmail( customerDS, logon );
				
				int customerId = customerDS.Customers[0].CustomerId; 

				CartTaskDALC cartTaskDALC = new CartTaskDALC();
				cartTaskDALC.CreateTask( taskId, customerId );  
			}
			catch(Exception e)
			{
				throw new ApplicationException( ResourceManager.GetString( "RES_ExceptionCreateTask" ), e );
			}
		}
	}
}
