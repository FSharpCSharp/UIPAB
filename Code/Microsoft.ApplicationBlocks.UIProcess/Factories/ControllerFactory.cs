//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// ControllerFactory.cs
//
// This file contains the implementations of the ControllerFactory class.
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
	/// Factory for creating controllers.
	/// </summary>
	public sealed class ControllerFactory
	{
		#region Constructors

		/// <summary>
		/// Static constructor.
		/// </summary>
		static ControllerFactory()
		{
		}

		private ControllerFactory(){}
		#endregion

		/// <summary>
		/// Creates the controller for the view.
		/// </summary>
		/// <param name="view">The name of the view in the Views section of the configuration file.</param>
		/// <param name="navigator">The navigator that the controller uses for navigation services.</param>
		/// <returns></returns>
		public static ControllerBase Create(string view, Navigator navigator) 
		{
			ObjectTypeSettings typeSettings = UIPConfiguration.Config.GetControllerSettings(view);
			if( typeSettings == null )
				throw new UIPException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionControllerNotFound, view ) );

			return (ControllerBase)GenericFactory.Create( typeSettings, new object[] {navigator} );
		}
	}


}
