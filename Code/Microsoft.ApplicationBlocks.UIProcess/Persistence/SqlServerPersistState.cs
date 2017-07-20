//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// SqlServerStatePersistence.cs
//
// This file contains the implementations of the SqlServerStatePersistence class
//
// For more information see the User Interface Process Application Block Implementation Overview. 
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
using System.IO;
using System.Data;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.ApplicationBlocks.Data;
  
namespace Microsoft.ApplicationBlocks.UIProcess
{
	#region SqlPersistState Provider
	/// <summary>
	/// IStatePersistence SQL Server implementation.
	/// This provider uses SQL Server storage to dehydrate and rehydrate State objects.
	/// </summary>
    public class SqlServerPersistState : IStatePersistence
	{
        #region Declares variables
        private const string ConfigConnectionString = "connectionString";
	    private const string DbSelectState = "SelectState";
	    private const string DbParamStateGuid = "@StateGuid";
	    private const string DbInsertState = "InsertState";
		private const string DbDeleteState = "DeleteState";
	    private const string DbParamXmlState = "@XmlState";
        private const int ReadSize = 1400;
        private string _connectionString	= null;
        #endregion
        
        #region Constructors
		/// <summary>
		/// Initializes a new instance of the SqlServerPersistState class.
		/// </summary>
        public SqlServerPersistState() {}
        #endregion
        
        #region IPersistState implementation
        /// <summary>
        /// The possible provider configuration attributes are:
        ///    connectionString: Specifies the database connection string.
        /// </summary>
				/// <param name="statePersistenceParameters">Collection of configuration information to be used by
				/// the persistence provider.</param>
        public void Init(NameValueCollection statePersistenceParameters)
        {
			_connectionString = statePersistenceParameters[ConfigConnectionString];
			if( _connectionString == null )
				throw new ApplicationException ( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionSQLStatePersistenceProviderInit, ConfigConnectionString ) );
        }
        
        /// <summary>
        /// Saves the State object in a SQL Server database.
        /// </summary>
        /// <param name="state">A valid State object.</param>
        [SqlClientPermission(System.Security.Permissions.SecurityAction.Demand)]
        public void Save(State state) 
        {
			BinaryFormatter formatter = new BinaryFormatter();
			MemoryStream memoryStream = new MemoryStream();
			formatter.Serialize(memoryStream, state);
	        
			byte[] serializedObject = memoryStream.GetBuffer();             
			
			try
			{
				SqlParameter binState = new SqlParameter(DbParamXmlState, System.Data.SqlDbType.Image );
				binState.Value = serializedObject;
				
				SqlHelper.ExecuteNonQuery( _connectionString,
										CommandType.StoredProcedure,
										DbInsertState,
										new SqlParameter[] { 
											new SqlParameter(DbParamStateGuid, state.TaskId),
											binState} );
			}						 	
            catch (Exception ex)
            {
                throw new ApplicationException( Resource.ResourceManager[Resource.Exceptions.RES_ExceptionSQLStatePersistenceProviderDehydrate], ex );
            }
            finally 
            {
                memoryStream.Close();
            }
		}
        
        /// <summary>
        /// Loads an existing State object from a SQL Server database.
        /// </summary>
        /// <param name="taskId">The task identifier (a GUID associated with the task).</param>
        /// <returns>A valid State object.</returns>
        [SqlClientPermission(System.Security.Permissions.SecurityAction.Demand)]
        public State Load(Guid taskId) 
        {
            State requestedState = null;
            SqlDataReader reader = null;
			MemoryStream memoryStream = null;
			try
            {
				reader = SqlHelper.ExecuteReader(_connectionString, 
												CommandType.StoredProcedure, 
												DbSelectState,
												new SqlParameter(DbParamStateGuid, taskId));
				
				if (!reader.Read())
				{
					reader.Close();
					return null;
				}
							
				// Get size of image data. Pass null as the byte array parameter
				long byteTotal = reader.GetBytes(0, 0, null, 0, 0);
				
				// Allocate byte array to hold image data
				byte[] serializedObject = new byte[byteTotal];
				int index = 0;
				long bytesRead = 0;
				while (bytesRead < byteTotal)
				{			
					// read the object binary data
					bytesRead += reader.GetBytes(0, index, serializedObject, index, ReadSize);
					index += ReadSize;
				}
					
				//Deserialize the object
				memoryStream = new MemoryStream(serializedObject);
				BinaryFormatter formatter = new BinaryFormatter();
				requestedState = (State) formatter.Deserialize(memoryStream);
            }
			catch (Exception ex)
			{
				throw new ApplicationException( Resource.ResourceManager[Resource.Exceptions.RES_ExceptionSQLStatePersistenceProviderRehydrate], ex );
			}
            finally
            {
                if( reader != null ) reader.Close();
                if( memoryStream != null ) memoryStream.Close();
            }

            return requestedState;
        }

		/// <summary>
		/// Removes state information from the database.
		/// </summary>
		/// <param name="taskId">The task identifier (a GUID associated with the task). State information for this task will be removed.</param>
		[SqlClientPermission(System.Security.Permissions.SecurityAction.Demand)]
		public void Remove(Guid taskId)
		{
			try
			{
				int result = SqlHelper.ExecuteNonQuery(_connectionString, 
					CommandType.StoredProcedure, 
					DbDeleteState,
					new SqlParameter(DbParamStateGuid, taskId));
			}
			catch (Exception ex)
			{
				throw new ApplicationException( Resource.ResourceManager[Resource.Exceptions.RES_ExceptionSQLStatePersistenceProviderRehydrate], ex );
			}
		}
        #endregion
	}
	#endregion
}
