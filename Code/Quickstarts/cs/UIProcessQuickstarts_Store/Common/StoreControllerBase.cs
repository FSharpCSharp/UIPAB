//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// StoreControllerBase.cs
//
// This file contains the implementations of the StoreContollerBase class.
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
using System.Resources;
using System.Reflection;

using UIProcessQuickstarts_Store;
using Microsoft.ApplicationBlocks.UIProcess;


namespace UIProcessQuickstarts_Store
{
	/// <summary>
	/// The controller used by the store application
	/// </summary>
	public class StoreControllerBase : ControllerBase
	{
		#region Declares variables
		protected const string STATE_EXCEPTION = "Exception";
		protected const string STATE_CART = "CartDS";
		protected static ResourceManager ResourceManager = new ResourceManager(typeof(StoreControllerBase).Namespace + ".StoreText", Assembly.GetAssembly(typeof(StoreControllerBase)));
		#endregion

		#region Constructor
		public StoreControllerBase( Navigator navigator ) : base( navigator ){}
		#endregion

		/// <summary>
		/// Cart object that will store the items that the user purchases in a shopping session
		/// </summary>
		protected CartDS Cart
		{
			get
			{
				// attempt to retrieve the cart from the state object
				CartDS cartDS = (CartDS)State[STATE_CART];
				if (cartDS == null)
				{
					// user is in a new shopping session so the cart needs to be initialized
					cartDS = new CartDS();
					State[STATE_CART] = cartDS;
				}
			
				return cartDS;
			}
			set
			{
				State[STATE_CART] = value;
			}
		}

		#region Static helper methods
		/// <summary>
		/// Gets the task related to the specified user
		/// </summary>
		/// <param name="userName"></param>
		/// <returns></returns>
		public static Guid GetUserTaskId(string userName) 
		{
			//  Look up TaskID in APPLICATION DATABASE;
			//  Remember, correlating logon or other information with UIP's TaskID is
			//  the responsibility of the consuming application
			Guid taskId = Guid.Empty;
			
			//Gets user task
			CartTaskBusinessObject cartBO = new CartTaskBusinessObject();
			taskId = cartBO.GetTask(userName);

			return taskId;
		}

		/// <summary>
		/// Checks if the specified user name and password are valid
		/// </summary>
		/// <param name="userName">User name</param>
		/// <param name="password"></param>
		/// <returns></returns>
		public static bool IsUserValid(string userName, string password) 
		{
			try
			{
				//Lookup user in database
				CustomerBusinessObject customerBO = new CustomerBusinessObject();
				int customerId = customerBO.Logon(userName, password); 
			
				if( customerId != 0)
					return true; //The user is valid
				else 
					return false; //The user isn´t valid
			}
			catch
			{
				throw;
			}
		}

		#endregion
        
		#region Instance helper methods
		/// <summary>
		/// Gets the last exception
		/// </summary>
		public Exception GetLastError()
		{
			return (Exception)State[STATE_EXCEPTION];
		}
		#endregion

		#region Navigation methods

		/// <summary>
		/// Navigates to the fail view
		/// </summary>
		public void BrowseFail() 
		{
			this.State.NavigateValue = "fail";
			Navigate();
		}


		/// <summary>
		/// Clears all existing errors
		/// </summary>
		public void ClearError() 
		{
			this.State.NavigateValue = "resume";
			Navigate();
		}

		/// <summary>
		/// Directs the user to the store help shared transition that is available to all
		/// navigation graphs within the store
		/// </summary>
		public void ShowStoreHelp()
		{
			this.State.NavigateValue = "storehelp";
			Navigate();
		}

		/// <summary>
		/// Directs the user to the store help shared transition that is availavle to the
		/// shopping navigation graph.
		/// </summary>
		public void ShowShoppingHelp()
		{
			this.State.NavigateValue = "shoppinghelp";
			Navigate();
		}
		

		/// <summary>
		/// Adds a product to the customer cart
		/// </summary>
		/// <param name="productId">ID of the product to add to the cart</param>
		/// <param name="quantity">Quantity of product to be added to the cart</param>
		public virtual void AddToCart(int productId, int quantity) 
		{

			if(this.State == null)
				throw new ApplicationException(ResourceManager.GetString("RES_ExceptionStateRequired"));

			try
			{
				CartBusinessObject cartBO = new CartBusinessObject(); 
				cartBO.AddToCart( Cart.CartItems, productId, quantity ); 
							
				this.State.NavigateValue = "addItem";
				this.State.Save();
			}
			catch (Exception e)
			{
				State[STATE_EXCEPTION] = e;
				State.NavigateValue = "fail";
			}
			
		}

		/// <summary>
		/// Creates a new order
		/// </summary>
		public void CheckoutOrder()
		{
			if (this.State == null)
				throw new ApplicationException(ResourceManager.GetString("RES_ExceptionStateRequired"));
				
			try
			{
				CartTaskBusinessObject cartBO = new CartTaskBusinessObject();
				// retrieve the customerID for the customer that is performing the current task
				int customerId = cartBO.GetCustomerFromTask( State.TaskId );

				// create a new order object and fill it with orderdetail items
				OrderBusinessObject orderBO = new OrderBusinessObject();
				orderBO.CreateOrderFromCart( customerId, Cart.CartItems ); 
			
				State.NavigateValue = "checkout";
			}
			catch (Exception e)
			{
				State[STATE_EXCEPTION] = e;
				State.NavigateValue = "fail";
			}

			Navigate();
		}


		/// <summary>
		/// Resumes the shopping task
		/// </summary>
		public virtual void ResumeShopping() 
		{
			//  proceed to next View
			State.NavigateValue = "shoppingCart";
			Navigate();
		}

		/// <summary>
		/// Quits the current task and stores the state
		/// </summary>
		public virtual void StopShopping() 
		{		
			//  proceed to next View
			State.NavigateValue = "stop";
			Navigate();
		}


		/// <summary>
		/// Used to execute the checkout operation
		/// </summary>
		/// <param name="name">Persons name</param>
		/// <param name="addr">Persons address</param>
		/// <param name="ccnum">Persons Credit card number</param>
		public void CompleteCheckout( string name, string addr, string ccnum )
		{
			//  do some checkout stuff
			if ( "1111-1111-1111-1111" != ccnum )
			{
				State.NavigateValue = "checkout";
			}
			else
			{
				//resets the state
				Cart.CartItems.Clear();
				State.NavigateValue = "congratulations";
			}
			Navigate();
		}


		/// <summary>
		/// Gets all products in the catalog
		/// </summary>
		public ProductDS GetCatalogProducts() 
		{
			ProductDS productDS = new ProductDS(); 
			try
			{
				ProductBusinessObject productBO = new ProductBusinessObject();
				// fill the products dataset will all of the products in the database
				productBO.GetAllProducts(productDS, 0, 0 );
			}
			catch( Exception e )
			{								
				State[STATE_EXCEPTION] = e;
				State.NavigateValue = "fail"; 
				Navigate();
			}
			
			return productDS;
		}

		/// <summary>
		/// Gets a cusotmers shopping cart
		/// </summary>
		public CartDS GetCart() 
		{
			if (this.State == null)
				throw new ApplicationException(ResourceManager.GetString("RES_ExceptionStateRequired"));

			return Cart;
		}

		/// <summary>
		/// Gets the customer info
		/// </summary>
		/// <param name="logon">customer logon</param>
		/// <returns>customer info</returns>
		public CustomerDS.Customer GetCustomerByLogon( string logon )
		{
			CustomerBusinessObject bo = new CustomerBusinessObject();					
			return bo.GetCustomerByLogon( logon ).Customers[0];
		}
		#endregion
	}
}
