//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// KeyPressHandlers.cs
//
// This file contains the implementations of the KeyPressHandlers class.
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
using System.Windows.Forms;

namespace InsurancePurchaseWizard.UI
{
	/// <summary>
	/// Class that defines static methods that can handled keypress events on controls and deal with the inputs
	/// in custom ways
	/// </summary>
	public sealed class KeyPressHandlers
	{
		private KeyPressHandlers() 
		{

		}
		
		/// <summary>
		/// Method that will only accept numeric input given to a control
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public static void NumericKeyPress(object sender,KeyPressEventArgs e)
		{
			e.Handled = ! (Char.IsDigit(e.KeyChar));
		}
	}
}
