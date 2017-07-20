//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// LayoutManagerFactory.cs
//
// This file contains the implementations of the LayoutManagerFactory class.
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

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// Factory for creating layout managers.
	/// </summary>
	public sealed class LayoutManagerFactory
	{
		private LayoutManagerFactory()
		{

		}

		/// <summary>
		/// Creates a layout manager for the view.
		/// </summary>
		/// <param name="view">The view whose configuration information contains the layout manager settings.</param>
		/// <returns>A layout manager.</returns>
		public static ILayoutManager Create(string view) 
		{
			ILayoutManager layoutManager=null;

			ObjectTypeSettings typeSettings = UIPConfiguration.Config.GetLayoutManagerSettings(view);
			if( typeSettings != null )
				layoutManager = (ILayoutManager)GenericFactory.Create(typeSettings);

			return layoutManager ;			
		}
	}
}
