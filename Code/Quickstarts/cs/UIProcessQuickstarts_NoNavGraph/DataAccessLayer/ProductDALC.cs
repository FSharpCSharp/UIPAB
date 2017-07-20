//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// ProductDAL.cs
//
// This file contains the implementations of the ProductDAL class.
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
	public class ProductDALC : BaseDALC
	{
		public ProductDALC():base()
		{
		}
		
		/// <summary>
		/// Gets all products in the catalog
		/// </summary>
		public bool GetAllProducts( ProductDS productDS, int from, int count )
		{
			try
			{
				SqlDataReader reader = null;
                try
                {
                    reader = SqlHelper.ExecuteReader( this.ConnectionString, 
					    CommandType.StoredProcedure,
					    "SelectAllProducts" );
                
					SqlHelperExtension.Fill( reader, productDS, "product", from, count );
					bool ret = reader.Read(); 
					reader.Close();
					
					return ret;
				}
                finally
                {
                    if( reader != null )
                        ((IDisposable)reader).Dispose();
                }
			}
			catch(Exception e )
			{
				throw new ApplicationException( ResourceManager.GetString( "RES_ExceptionCantGetCatalog" ), e );
			}
		}
		
		/// <summary>
		/// Gets the product with the specified identifier
		/// </summary>
		public void GetProductById( ProductDS productDS, int productId )
		{
			try
			{
                SqlDataReader reader = null;
                try
                {
                    reader = SqlHelper.ExecuteReader( this.ConnectionString, 
                           CommandType.StoredProcedure,
                           "SelectProductById", 
                           new SqlParameter[]{ new SqlParameter("@ProductID", productId) });
                    
			
                    SqlHelperExtension.Fill( reader, productDS, "product", 0, 1 );
                    reader.Close();
                }
                finally
                {
                    if( reader != null )
                        ((IDisposable)reader).Dispose();
                }
			}
			catch(Exception e )
			{
				throw new ApplicationException( String.Format(ResourceManager.GetString( "RES_ExceptionCantGetProduct" ), productId), e );
			}
		}

        /// <summary>
        /// Creates a new product with the specified data
        /// </summary>
        public void CreateProduct( int categoryId, string modelNumber, 
            string modelName, string image, string description,
            decimal unitCost)
        {
            
            SqlHelper.ExecuteNonQuery( this.ConnectionString,
                CommandType.StoredProcedure,
                "InsertProduct", 
                new SqlParameter[]{ 
                    new SqlParameter("@CategoryID", categoryId),
                    new SqlParameter("@ModelNumber", modelNumber),
                    new SqlParameter("@ModelName", modelName),
                    new SqlParameter("@ProductImage", image),
                    new SqlParameter("@Description", description),
                    new SqlParameter("@UnitCost", unitCost),
                });
            
        }

        /// <summary>
        /// Updates a existing product with the specified data
        /// </summary>
        public void UpdateProduct( int productId, int categoryId, string modelNumber, 
            string modelName, string image, string description, decimal unitCost)
        {
            SqlHelper.ExecuteNonQuery( this.ConnectionString,
                CommandType.StoredProcedure,
                "UpdateProduct", 
                new SqlParameter[]{ 
                                        new SqlParameter("@ProductID", productId),
                                        new SqlParameter("@CategoryID", categoryId),
                                        new SqlParameter("@ModelNumber", modelNumber),
                                        new SqlParameter("@ModelName", modelName),
                                        new SqlParameter("@ProductImage", image),
                                        new SqlParameter("@Description", description),
                                        new SqlParameter("@UnitCost", unitCost),
            });
        }

        /// <summary>
        /// Removes a existing product
        /// </summary>
        public void DeleteProduct( int productId )
        {
            
            SqlHelper.ExecuteNonQuery( this.ConnectionString,
                CommandType.StoredProcedure,
                "DeleteProduct", 
                new SqlParameter[]{ new SqlParameter("@ProductID", productId) });
            
        }
	}
}
