//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// OrderBusinessObject.cs
//
// This file contains the implementations of the OrderBusinessObject class.
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
	/// This class contains all order related business rules
	/// </summary>
	public class OrderBusinessObject : BaseBusinessObject
	{
		public OrderBusinessObject():base()
		{
		}
		
		/// <summary>
		/// Creates a new order with the specified params
		/// </summary>
		public int CreateOrderFromCart( int customerId, CartDS.CartItemsDataTable items )
		{
			OrderDALC orderDALC = new OrderDALC();
			ProductDALC productDALC = new ProductDALC();
			 
			int orderId = orderDALC.CreateOrder( customerId, DateTime.Now, DateTime.Now.AddDays( 2 ) );
			
			foreach (CartDS.CartItem item in items)
			{
				ProductDS productDS = new ProductDS();
				productDALC.GetProductById( productDS, item.ProductId );
				  	
				orderDALC.CreateOrderItem( orderId, item.ProductId, productDS.Products[0].UnitCost, item.Quantity ); 
			}
			
			return orderId;
		}
	}
}
