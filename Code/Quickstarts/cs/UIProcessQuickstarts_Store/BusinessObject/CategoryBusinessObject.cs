//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// CategoryBusinessObject.cs
//
// This file contains the implementations of the CategoryBusinessObject class.
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
	/// This class contains all the category related business rules
	/// </summary>
    public class CategoryBusinessObject:BaseBusinessObject
    {
        public CategoryBusinessObject():base()
        {
        }
		
        /// <summary>
        /// Gets all available product categories
        /// </summary>
        public bool GetAllCategories( CategoryDS categoryDS, int from, int count)
        {
            try
            {
                CategoryDALC categoryDALC = new CategoryDALC();
                return categoryDALC.GetAllCategories( categoryDS, from, count );
            }
            catch(Exception e )
            {
                throw new ApplicationException( ResourceManager.GetString( "RES_ExceptionCantGetCategories" ), e );
            }
        }
    }
}
