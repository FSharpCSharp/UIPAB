//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// GenericFactory.cs
//
// This file contains the implementations of the GenericFactory class
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
using System.Configuration;
using System.Reflection;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// Acts as the basic implementation of the multiple factory classes used in UIProcess.
	/// UIP needs to create instances based on configuration information for state, state persistence providers, ViewManagers, and so on.
	/// UIP has factories for these, and because there is much common code for doing reflection-based activation,
	/// it keeps that code in one central place.
	/// </summary>
	public sealed class GenericFactory
	{
		#region Constructors

		/// <summary>
		/// Static constructor.
		/// </summary>
        static GenericFactory(){}


		private GenericFactory(){}


		#endregion

		#region Create Overloads
        /// <summary>
        /// Creates an object using the full name type contained in typeSettings.
        /// </summary>
        /// <param name="typeSettings">A typeSetting object with the needed type information to create a class instance.</param>
        /// <returns>An instance of the specified type.</returns>
        
        public static object Create( ObjectTypeSettings typeSettings )
        {
            return Create( typeSettings, null );
        }

        /// <summary>
		/// Creates an object using the full name type contained in typeSettings.
		/// </summary>
		/// <param name="typeSettings">A typeSetting object with the needed type information to create a class instance.</param>
		/// <param name="args">Constructor arguments.</param>
		/// <returns>An instance of the specified type.</returns>
		public static object Create( ObjectTypeSettings typeSettings, object[] args )
		{
            Assembly assemblyInstance = null;
            Type typeInstance = null;

            try 
            {
                //  Use full assembly name to get assembly instance
                assemblyInstance = Assembly.Load( typeSettings.Assembly );							  
            }
            catch(Exception e)
            {				
                throw new UIPException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionCantLoadAssembly, typeSettings.Assembly )+UIPException.GetFirstExceptionMessage(e), e );
            }

            //  use type name to get type from assembly
			try
			{
				typeInstance = assemblyInstance.GetType( typeSettings.Type , true, false);
			}
			catch( Exception e)
			{
				throw new UIPException(Resource.ResourceManager.FormatMessage(Resource.Exceptions.RES_ExceptionCantGetTypeFromAssembly,typeSettings.Type, typeSettings.Assembly)+UIPException.GetFirstExceptionMessage(e), e);
			}
            try
            {
                if( args != null )
                {
                    return Activator.CreateInstance( typeInstance, args);
                }
                else
                {
                    return Activator.CreateInstance( typeInstance);
                }
            }
            catch( Exception e )
            {
                throw new UIPException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionCantCreateInstanceUsingActivate, typeInstance )+UIPException.GetFirstExceptionMessage(e), e );
            }
		}

		#endregion
	}
}
