//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// CartTaskDALC.cs
//
// This file contains the implementations of the CartTaskDALC class.
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
	public class CartTaskDALC : BaseDALC
	{
		public CartTaskDALC():base()
		{
		}
		
		/// <summary>
		/// Gets the customer task id
		/// </summary>
		/// <param name="customerId">a existing customer id</param>
		/// <returns></returns>
        public Guid GetTask( int customerId )
		{
			Guid taskId = Guid.Empty;
			
            try
            {	
                SqlDataReader reader = null;
                try
                {
                    reader = SqlHelper.ExecuteReader( this.connectionString, 
                        CommandType.StoredProcedure,
                        "SelectCartTaskByCustomerId",
                        new SqlParameter[] { new SqlParameter( "@CustomerID", customerId ) } ) ;
                    							
                        if (reader.Read())
                            taskId = (Guid)reader["TaskID"];

                        return taskId;
                }
                finally
                {
                    if( reader != null )
                        ((IDisposable)reader).Dispose();
                }
			}
			catch( Exception e )
			{
				throw new ApplicationException( String.Format(ResourceManager.GetString( "RES_ExceptionCantGetTaskByCustomerID" ), customerId), e );
			}
		}
		
		/// <summary>
		/// Gets the identifier of the task ownwer 
		/// </summary>
		/// <param name="taskId">task id</param>
		/// <returns>customer id</returns>
        public int GetCustomerFromTask( Guid taskId )
		{
			int customerId = 0;
			try
			{			
                SqlDataReader reader = null;

                try
                {
                    reader = SqlHelper.ExecuteReader( this.connectionString, 
                           CommandType.StoredProcedure,
                           "SelectCartTaskByTaskId",
                           new SqlParameter[] { new SqlParameter( "@TaskID", taskId ) } );

                    if (reader.Read())
                        customerId = (int)reader["CustomerID"];

                    return customerId;
				
                }
                finally
                {
                    if( reader != null )
                        ((IDisposable)reader).Dispose();
                }
			}
			catch( Exception e )
			{
				throw new ApplicationException( String.Format(ResourceManager.GetString( "RES_ExceptionCantGetTaskByTaskID" ), taskId), e );
			}
		}

		/// <summary>
		/// Creates a new task
		/// </summary>
		/// <param name="taskId">task id</param>
		/// <param name="customerId">customer id</param>
        public void CreateTask( Guid taskId, int customerId )
		{
			try
			{
				SqlHelper.ExecuteNonQuery( this.connectionString, 
					CommandType.StoredProcedure,
					"InsertCartTask",
					new SqlParameter[] { 
					new SqlParameter( "@CustomerID", customerId ),
					new SqlParameter( "@TaskID", taskId ) } );
			}
			catch(Exception e)
			{
				throw new ApplicationException( String.Format(ResourceManager.GetString( "RES_ExceptionCantCreateTask" ), customerId, taskId), e );
			}
		}
	}
}
