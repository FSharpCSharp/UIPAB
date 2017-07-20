//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// CartBusinessObject.cs
//
// This file contains the implementations of the CartBusinessObject class.
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

namespace UIProcessQuickstarts_Store
{
	/// <summary>
	/// This class contains all the cart related business rules
	/// </summary>
	public class CartBusinessObject : BaseBusinessObject
	{
		public CartBusinessObject():base()
		{
			
		}
		
		/// <summary>
		/// Adds a new item to a existing cart
		/// </summary>
		/// <remarks>If the item alredy exists in the cart, then only its quantity
		///	is updated</remarks>
		public void AddToCart( CartDS.CartItemsDataTable cartItems, int productId, int quantity )
		{
			try
			{
				ProductBusinessObject productBO = new ProductBusinessObject();
				ProductDS products = new ProductDS();
				productBO.GetProductById(products, productId);
				if ( cartItems.Rows.Count > 0 )
				{
					DataRow[] selectedItems = cartItems.Select("productID=" + productId);
					if (selectedItems.Length > 0)
						((CartDS.CartItem)selectedItems[0]).Quantity += quantity;
					else
						cartItems.AddCartItem( quantity, productId, products.Products[0].ModelName, products.Products[0].UnitCost );
				}
				else
					cartItems.AddCartItem( quantity, productId, products.Products[0].ModelName, products.Products[0].UnitCost );
			}
			catch(Exception e )
			{
				throw new ApplicationException( ResourceManager.GetString( "RES_ExceptionCantAddCartItem" ), e );
			}
		}
	}
}
