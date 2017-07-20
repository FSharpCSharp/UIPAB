//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// OrderDAL.cs
//
// This file contains the implementations of the OrderDAL class.
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
	public class OrderDALC : BaseDALC
	{
		public OrderDALC():base()
		{
		}
		
		/// <summary>
		/// Creates a new order
		/// </summary>
		/// <param name="customerId"></param>
		/// <param name="orderDate"></param>
		/// <param name="shipDate"></param>
		/// <returns></returns>
        public int CreateOrder( int customerId, DateTime orderDate, DateTime shipDate )
		{
			try
			{
				SqlParameter returnParam = new SqlParameter( "@Return", SqlDbType.Int );
				returnParam.Direction = ParameterDirection.ReturnValue;
				
				SqlHelper.ExecuteNonQuery( this.ConnectionString, 
					CommandType.StoredProcedure,
					"InsertOrder",
					new SqlParameter[] { 
										   new SqlParameter( "@CustomerID", customerId),
										   new SqlParameter( "@OrderDate", orderDate ),
										   new SqlParameter( "@ShipDate", shipDate ),
										   returnParam } );
				return (int)returnParam.Value;
			}
			catch(Exception e)
			{
				throw new ApplicationException( ResourceManager.GetString( "RES_ExceptionCantCreateOrder" ), e );
			}
		}
		
		/// <summary>
		/// Creates a new order item
		/// </summary>
		/// <param name="orderId"></param>
		/// <param name="productId"></param>
		/// <param name="unitCost"></param>
		/// <param name="quantity"></param>
        public void CreateOrderItem( int orderId, int productId, decimal unitCost, int quantity )
		{
			try
			{
				SqlHelper.ExecuteNonQuery( this.ConnectionString, 
					CommandType.StoredProcedure,
					"InsertOrder_Details",
					new SqlParameter[] { 
										   new SqlParameter( "@OrderID", orderId),
										   new SqlParameter( "@ProductID", productId ),
										   new SqlParameter( "@UnitCost", unitCost ),
										   new SqlParameter( "@quantity", quantity ) } );
			}
			catch(Exception e)
			{
				throw new ApplicationException( ResourceManager.GetString( "RES_ExceptionCantCreateOrderItem" ), e );
			}
		}
	}
}
