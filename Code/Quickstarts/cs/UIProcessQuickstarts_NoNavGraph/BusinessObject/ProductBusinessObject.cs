//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// ProductBusinessObject.cs
//
// This file contains the implementations of the ProductBusinessObject class.
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
	/// This class contains all the product related business rules
	/// </summary>
	public class ProductBusinessObject:BaseBusinessObject
	{
		public ProductBusinessObject():base()
		{
		}
		
		/// <summary>
		/// Gets all products in the catalog
		/// </summary>
		public bool GetAllProducts( ProductDS productDS, int from, int count)
		{
			try
			{
				ProductDALC productDALC = new ProductDALC();
				return productDALC.GetAllProducts( productDS, from, count );
			}
			catch(Exception e )
			{
				throw new ApplicationException( ResourceManager.GetString( "RES_ExceptionGetCatalog" ), e );
			}
		}
		
		/// <summary>
		/// Gets the product with the specified identifier
		/// </summary>
		public void GetProductById( ProductDS productDS, int productId )
		{
			try
			{
				ProductDALC productDALC = new ProductDALC();
				productDALC.GetProductById( productDS, productId ); 	
			}
			catch(Exception e )
			{
				throw new ApplicationException( ResourceManager.GetString( "RES_ExceptionGetProduct" ), e );
			}
		}

        /// <summary>
        /// Creates a new the product with the specified data
        /// </summary>
        public void CreateProduct( int categoryId, string modelNumber, 
                string modelName, string image, string description,
                decimal unitCost)
        {
            try
            {
                ProductDALC productDALC = new ProductDALC();
                productDALC.CreateProduct( categoryId, modelNumber, modelName, 
                                image, description, unitCost ); 	
            }
            catch(Exception e )
            {
                throw new ApplicationException( ResourceManager.GetString( "RES_ExceptionCantCreateProduct" ), e );
            }
        }

        /// <summary>
        /// Updates a existing product with the specified data
        /// </summary>
        public void UpdateProduct( int productId, int categoryId, string modelNumber, 
            string modelName, string image, string description, decimal unitCost)
        {
            try
            {
                ProductDALC productDALC = new ProductDALC();
                productDALC.UpdateProduct( productId, categoryId, modelNumber, modelName, 
                    image, description, unitCost ); 	
            }
            catch(Exception e )
            {
                throw new ApplicationException( ResourceManager.GetString( "RES_ExceptionCantUpdateProduct" ), e );
            }
        }

        /// <summary>
        /// Removes a existing product
        /// </summary>
        public void DeleteProduct( int productId )
        {
            try
            {
                ProductDALC productDALC = new ProductDALC();
                productDALC.DeleteProduct( productId );	
            }
            catch(Exception e )
            {
                throw new ApplicationException( ResourceManager.GetString( "RES_ExceptionCantDeleteProduct" ), e );
            }
        }
	}
}
