//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// AppStart.cs
//
// This file contains the implementations of the AppStart class.
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
using UIProcessQuickstarts_MultiNavGraph;
using System.Windows.Forms;

namespace MultiNavGraph.Launcher
{
	/// <summary>
	/// This class is resonsible for hooking into application thread exceptions and also launching the main form for the
	/// application.
	/// </summary>
	public sealed class AppStart
	{
	
		private AppStart()
		{
		}

		/// <summary>
		/// Entry point for the application
		/// </summary>		
		[STAThread]		
		public static void Main(string[] args)
		{
			Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException); 
			Application.Run( new Logon() );
		}

		/// <summary>
		/// Handler for unhandled exceptions that occur during the course of the application
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		public static void Application_ThreadException(object source, System.Threading.ThreadExceptionEventArgs e)
		{
			string errMessage = "";
			for( Exception tempException = e.Exception; tempException != null ; tempException = tempException.InnerException )
			{
				errMessage += tempException.Message + Environment.NewLine + Environment.NewLine;
			}
			MessageBox.Show( string.Format( "There are some problems while trying to use the UIP Application block, please check the following error messages: {0}"
				+ Environment.NewLine, errMessage ), 
				"Application error", MessageBoxButtons.OK, MessageBoxIcon.Error );
		}
	}
}
