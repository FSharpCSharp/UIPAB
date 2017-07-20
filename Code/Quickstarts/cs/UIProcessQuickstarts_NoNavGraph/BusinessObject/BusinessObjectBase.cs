//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// BusinessObjectBase.cs
//
// This file contains the implementations of the BusinessObjectBase class.
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
using System.Resources;
using System.Reflection;

namespace UIProcessQuickstarts_Store
{
	/// <summary>
	/// This class is intended to be extended by the business rule components in 
	/// order to share behavior between them.
	/// </summary>
	public class BaseBusinessObject
	{
		protected static ResourceManager ResourceManager = new ResourceManager( typeof( BaseBusinessObject ).Namespace + ".BOText", Assembly.GetExecutingAssembly() );
	}
}
