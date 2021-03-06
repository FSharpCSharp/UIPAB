//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// Launcher.cs
//
// This file contains the implementations of the Launcher class.
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
using System.Diagnostics;
using System.Windows.Forms;


namespace InsuranceClientManagement.Launcher
{
	/// <summary>
	/// Launcher for the application
	/// </summary>
	public sealed class Launcher
	{
		private Launcher() 
		{

		}

		/// <summary>
		/// Entry point for the application. 
		/// </summary>
		[STAThread]
		public static void Main()
		{			
			// add the hook to catch all unhandled exceptions
			Application.ThreadException+=new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
			Application.Run(new InsuranceClientManagement.UI.Start());
			
		}
		private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			// show the error message to the user and exit the application			
			MessageBox.Show(e.Exception.Message);
			Application.Exit();
		}
		
	}
}
