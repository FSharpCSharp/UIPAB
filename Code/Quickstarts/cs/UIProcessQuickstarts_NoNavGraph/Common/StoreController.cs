//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// StoreController.cs
//
// This file contains the implementations of the StoreController class.
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
    public class StoreController : ControllerBase
	{
		#region Declares variables
		private const string STATE_EXCEPTION = "Exception";
        private const string STATE_CART = "CartDS";
        private static ResourceManager ResourceManager = new ResourceManager(typeof(StoreController).Namespace + ".StoreText", Assembly.GetAssembly(typeof(StoreController)));
		#endregion

		#region Constructor
		public StoreController( Navigator navigator ) : base( navigator ){}
		#endregion

		private CartDS Cart
		{
			get
			{
				CartDS cartDS = (CartDS)State[STATE_CART];
				if (cartDS == null)
				{
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
			this.State.NavigateValue = "error";
			Navigate();
		}


		/// <summary>
		/// Clears all existing errors
		/// </summary>
        public void ClearError() 
		{
			this.State.NavigateValue = "cart";
			Navigate();
		}
		

		/// <summary>
		/// Adds a product to the customer cart
		/// </summary>
		public void AddToCart(int productId, int quantity) 
		{
            if(this.State == null)
				throw new ApplicationException(ResourceManager.GetString("RES_ExceptionStateRequired"));

			try
			{
				CartBusinessObject cartBO = new CartBusinessObject(); 
				cartBO.AddToCart( Cart.CartItems, productId, quantity ); 
							
				this.State.NavigateValue = "cart";
			}
			catch (Exception e)
			{
				State[STATE_EXCEPTION] = e;
                State.NavigateValue = "error";
			}

			Navigate();
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
				int customerId = cartBO.GetCustomerFromTask( State.TaskId );

				OrderBusinessObject orderBO = new OrderBusinessObject();
				orderBO.CreateOrderFromCart( customerId, Cart.CartItems ); 
			
				State.NavigateValue = "checkout";
			}
			catch (Exception e)
			{
				State[STATE_EXCEPTION] = e;
                State.NavigateValue = "error";
			}

			Navigate();
		}


		/// <summary>
		/// Resumes the shopping task
		/// </summary>
        public void ResumeShopping() 
		{
			//  proceed to next View
			State.NavigateValue = "browsecatalog";
			Navigate();
		}

        /// <summary>
        /// Quits the current task and stores the state
        /// </summary>
		public void StopShopping() 
		{		
			//  proceed to next View
			State.NavigateValue = "cart";
			Navigate();
		}

			public void StartNewShoppingSession()
			{
				State.Clear();
				State.NavigateValue = "cart";
				Navigate();
			}


		/// <summary>
		/// Used to execute the checkout operation
		/// </summary>
		/// <param name="name"></param>
		/// <param name="addr"></param>
		/// <param name="ccnum"></param>
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
                productBO.GetAllProducts(productDS, 0, 0 );
            }
            catch( Exception e )
            {
                State[STATE_EXCEPTION] = e;
                State.NavigateValue = "error"; 
                Navigate();
            }
			
            return productDS;
        }

        /// <summary>
        /// Gets customer cart
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
