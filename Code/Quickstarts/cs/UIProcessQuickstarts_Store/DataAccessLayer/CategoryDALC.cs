//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// CategoryDALC.cs
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
	public class CategoryDALC : BaseDALC
	{
		public CategoryDALC():base()
		{
		}
		
		/// <summary>
		/// Gets all available product categories
		/// </summary>
		public bool GetAllCategories( CategoryDS categoryDS, int from, int count)
		{
			try
			{
				SqlDataReader reader = null;
                try
                {
                    reader = SqlHelper.ExecuteReader( this.connectionString, 
					CommandType.StoredProcedure,
					"SelectAllCategories" );
                
					SqlHelperExtension.Fill( reader, categoryDS, "category", from, count );
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
				throw new ApplicationException( ResourceManager.GetString( "RES_ExceptionCantGetCategories" ), e );
			}
		}
	}
}
