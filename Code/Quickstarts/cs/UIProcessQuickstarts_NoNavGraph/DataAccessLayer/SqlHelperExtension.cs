//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// SQLHelperExtension.cs
//
// This file contains the implementations of the SQLHelperExtension class.
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
	/// <summary>
	/// Sql Helper class
	/// </summary>
	internal sealed class SqlHelperExtension
	{
		private SqlHelperExtension()
		{
		}
        
        /// <summary>
        /// Fills a typed DataSet using the DataReader's current result. This method 
        /// allows paginated access to the database.
        /// </summary>
        /// <param name="dataReader">The DataReader used to fetch the values.</param>
        /// <param name="dataSet">The DataSet used to store the values.</param>
        /// <param name="tableName">The name of the DataSet table used to add the 
        /// DataReader records.</param>
        /// <param name="from">The quantity of records skipped before placing
        /// values on the DataReader on the DataSet.</param>
        /// <param name="count">The maximum quantity of records alloed to fill on the
        /// DataSet.</param>
        public static void Fill( IDataReader dataReader, DataSet dataSet, string tableName, int from, int count )
        {
            if( tableName == null)
                tableName = "unknownTable";
			    
            if( dataSet.Tables[ tableName ] == null  )
                dataSet.Tables.Add( tableName );
			
            // Get the DataTable reference
            DataTable fillTable;
            if( tableName == null )
                fillTable = dataSet.Tables[ 0 ];
            else
                fillTable = dataSet.Tables[ tableName ];

            DataRow fillRow;
            string fieldName;
            int recNumber = 0;
            int totalRecords = from + count;
            while( dataReader.Read() )
            {
                if( recNumber++ >= from )
                {
                    fillRow = fillTable.NewRow();
                    for( int fieldIdx = 0; fieldIdx < dataReader.FieldCount; fieldIdx++ )
                    {
                        fieldName = dataReader.GetName( fieldIdx );
                        if( fillTable.Columns.IndexOf( fieldName ) == -1 )
                            fillTable.Columns.Add( fieldName, dataReader.GetValue( fieldIdx ).GetType() );
                        fillRow[ fieldName ] = dataReader.GetValue( fieldIdx );
                    }
                    fillTable.Rows.Add( fillRow );
                }
                if( count != 0 && totalRecords <= recNumber )
                    break;
            }
            dataSet.AcceptChanges();
        }
	}
}
