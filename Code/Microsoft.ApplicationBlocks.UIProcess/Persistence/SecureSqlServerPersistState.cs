//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// SecureSqlServerStatePersistence.cs
//
// This file contains the implementations of the SecureSqlServerStatePersistence
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
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using System.Security.Cryptography;
using System.Diagnostics;
using Microsoft.Win32;

using Microsoft.ApplicationBlocks.Data;
  
namespace Microsoft.ApplicationBlocks.UIProcess
{
    #region SecureSqlServerPersistState Provider
    /// <summary>
    /// IStatePersistence implementation.
    /// This provider encrypts the serialized data by using a symmetric algorithm.
    /// The algorithm key is obtained from the LOCAL_MACHINE hive in the Windows registry.
    /// </summary>
    public class SecureSqlServerPersistState : IStatePersistence
    {
        #region Declares variables
        private const string ConfigRegistryValue = "symmetric key";
        private const string ConfigDefaultRegistryValue	= @"SOFTWARE\Microsoft\UIP Application Block";
        private const string ConfigConnectionString = "connectionString";
        private const string ConfigRegistry = "registryPath";
        private const string DbSelectState = "SelectState";
		private const string DbDeleteState = "DeleteState";
        private const string DbParamStateGuid = "@StateGuid";
        private const string DbInsertState = "InsertState";
        private const string DbParamXmlState = "@XmlState";
        private const int ReadSize = 1400;
        private string _connectionString = null;
		private CryptHelper _cryptHelper;

        #endregion
        
        #region IPersistState implementation

        /// <summary>
        /// The possible provider configuration attributes are:
        ///   connectionString: Specifies the database connection string.
        ///   registryPath: Specifies the registry key path where the 
        ///                 encryption symmetric key is stored. 
        /// </summary>
				/// <param name="statePersistenceParameters">The collection of configuration information to be used by
				/// the persistence provider.</param>
        public void Init(NameValueCollection statePersistenceParameters)
        {
            _connectionString = statePersistenceParameters[ConfigConnectionString];
            if( _connectionString == null )
                throw new ApplicationException ( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionSQLStatePersistenceProviderInit, ConfigConnectionString ) );
                         
            string registryPath = statePersistenceParameters[ConfigRegistry];
            if( registryPath == null )
                registryPath = ConfigDefaultRegistryValue;

			_cryptHelper = new CryptHelper(registryPath);
        }

        /// <summary>
        /// Saves the State object in a SQL Server database.
        /// </summary>
        /// <remarks>The provider encrypts the serialized state before storing it in the database.</remarks>
        /// <param name="state">A valid State object.</param>
        [SqlClientPermission(System.Security.Permissions.SecurityAction.Demand)]
        public void Save(State state) 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, state);
	        
            byte[] serializedObject = memoryStream.GetBuffer();             
			byte[] cipherObject = _cryptHelper.Encrypt( serializedObject );            
  
            try
            {
                SqlParameter binState = new SqlParameter(DbParamXmlState, System.Data.SqlDbType.Image );
                binState.Value = cipherObject;
				
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
        /// <remarks>The provider decrypts the serialized state before restoring it.</remarks>
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
							
                //Get size of image data. Pass null as the byte array parameter
                long byteTotal = reader.GetBytes(0, 0, null, 0, 0);
				
                // Allocate byte array to hold image data
                byte[] cipherObject = new byte[byteTotal];
                int index = 0;
                long bytesRead = 0;
                while (bytesRead < byteTotal)
                {			
                    // read the object binary data 
                    bytesRead += reader.GetBytes(0, index, cipherObject, index, ReadSize);
                    index += ReadSize;
                }
					
                //Decrypt the cipher object
                byte[] serializedObject = _cryptHelper.Decrypt( cipherObject );

                // Deserialize the object
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
		/// Removes secure state information from the SQL Server database.
		/// </summary>
		/// <param name="taskId">The task identifier (a GUID associated with the task).</param>
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
