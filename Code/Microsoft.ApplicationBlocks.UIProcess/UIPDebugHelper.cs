//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// UIPDebugHelper.cs
//
// This file contains the implementations of the UIPDebugHelper class.
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
using EnvDTE;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// Summary description for UIPDebugHelper.
	/// </summary>
	public sealed class UIPDebugHelper
	{
		private static string _filename;
		private static string _lineno;
		private static void openFile(string strFilename,int lineno)
		{
			EnvDTE.DTE dte=null;
			// try to connect to visual studio instance
			try 
			{
				dte = (DTE)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE"); 
			}
			catch(System.Runtime.InteropServices.COMException)
			{
				return;
			}
			if (dte!=null)			
			{
				EnvDTE.Window w = dte.ItemOperations.OpenFile(strFilename, Constants.vsViewKindCode);
				w.Activate();
				EnvDTE.TextDocument td = (EnvDTE.TextDocument) dte.ActiveDocument.Object("TextDocument");
				td.Selection.MoveTo(lineno,1, false);
				td.Selection.EndOfLine(false);
				td.Selection.SelectLine();
				dte.Debugger.Stop(false);
			}
		}
		
		/// <summary>
		/// Captures the exception information for the current culture
		/// </summary>
		/// <param name="source">the source of the exception</param>
		/// <param name="e">the exception</param>
		public static void AppThreadException(object source, System.Threading.ThreadExceptionEventArgs e)
		{
			AppThreadException(source, e, System.Globalization.CultureInfo.CurrentCulture);
		}

		/// <summary>
		/// Captures the exception information
		/// </summary>
		/// <param name="source">the source of the exception</param>
		/// <param name="e">the exception</param>
		/// <param name="formatProvider">the formatter</param>
		public static void AppThreadException(object source, System.Threading.ThreadExceptionEventArgs e, IFormatProvider formatProvider)
		{
			Exception firstException=e.Exception;
			// drill down to first exception
			for(Exception tempException = e.Exception; tempException != null ; tempException = tempException.InnerException )
			{
				firstException = tempException;
			}
			int inPos = firstException.StackTrace.IndexOf(" in ");
			int linePos = firstException.StackTrace.IndexOf(":line");
			_filename = firstException.StackTrace.Substring(inPos+4,linePos-inPos-4);
			_lineno = firstException.StackTrace.Substring(linePos+6,firstException.StackTrace.Length-linePos-6);
			if (_lineno.IndexOf("\n",0)>0)
				_lineno = _lineno.Substring(0,_lineno.IndexOf("\n",0));
			openFile(_filename,int.Parse(_lineno,formatProvider));
			throw firstException;
		}

		/// <summary>
		/// Gets the file name of the class that threw the exception
		/// </summary>
		public static String ErrorThrowingFileName
		{
			get
			{
				return _filename;
			}
		}

		/// <summary>
		/// Gets the the line of the stack trace that threw the error
		/// </summary>
		public static String ErrorThrowingLine
		{
			get
			{
				return _lineno;
			}
		}

		/// <summary>
		/// Private constructor to prevent instantiation of the UIPDebugHelper class.
		/// </summary>
		private UIPDebugHelper()
		{
		}
	}
}
