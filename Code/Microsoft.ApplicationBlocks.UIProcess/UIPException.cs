//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// UIPException.cs
//
// This file contains the implementations of the UIPException class
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
using System.Runtime.Serialization; 

namespace Microsoft.ApplicationBlocks.UIProcess
{
    /// <summary>
    /// The UIP main exception.
    /// </summary>
	[Serializable]
	public class UIPException	: ApplicationException
	{
		/// <summary>
		/// Overloaded. Default Constructor.
		/// </summary>
		public UIPException(){}
        
		/// <summary>
		/// Overloaded. Initializes a new UIPException with the specified message.
		/// </summary>
		/// <param name="msg">Exception message.</param>
		public UIPException( string msg ) : base( msg ) { }
        
		/// <summary>
		/// Overloaded. Initializes a new UIPException with the specified message and inner exception.
		/// </summary>
		/// <param name="msg">Exception message.</param>
		/// <param name="inner">Inner exception.</param>
		public UIPException( string msg, Exception inner ) : base( msg, inner ) { }
		
		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info">Holds all of the data needed to serialize or deserialize an object.</param>
		/// <param name="context">The source and destination of a given serialized stream.</param>
		protected UIPException( SerializationInfo info, StreamingContext context) : base( info, context ) {}
		
		/// <summary>
		/// Returns the first exception information in an exception's stack trace.
		/// </summary>
		/// <param name="e">The exception.</param>
		/// <returns>The first line in the stack trace.</returns>
		public static string GetFirstExceptionMessage(Exception e)
		{
			if( null == e)
				return null;
			Exception firstException=e;
			while(firstException.InnerException != null)
				firstException = firstException.InnerException;
			string firstLineStackTrace = firstException.StackTrace.IndexOf(Environment.NewLine)>-1?firstException.StackTrace.Substring(0,firstException.StackTrace.IndexOf(Environment.NewLine)):firstException.StackTrace;
			return Resource.ResourceManager.FormatMessage(Resource.Exceptions.RES_ExceptionFirstExceptionMessage,firstException.Message,firstLineStackTrace);			
		}
	}
}
 