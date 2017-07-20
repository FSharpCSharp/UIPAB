//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// HomePurchaseInfo.cs
//
// This file contains the implementations of the HomePurchaseInfo class.
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
using System.Globalization;

namespace InsurancePurchaseWizard.UI
{
	/// <summary>
	/// Class that provides information about a house
	/// </summary>
	[Serializable]
	public class HomePurchaseInfo : IInsuranceInfo
	{
		private string homeType;
		private string streetAddress;
		private DateTime dateBuilt;
		private decimal floorSpace;

		public HomePurchaseInfo()
		{			
		}

		/// <summary>
		/// Amount of floorspace in the home
		/// </summary>
		public decimal FloorSpace
		{
			get
			{
				return floorSpace;
			}
			set
			{
				floorSpace = value;
			}
		}

		/// <summary>
		/// Date the house was built
		/// </summary>
		public DateTime DateBuilt
		{
			get
			{
				return dateBuilt;
			}
			set
			{
				dateBuilt = value;
			}
		}


		/// <summary>
		/// Street address
		/// </summary>
		public string StreetAddress
		{
			get
			{
				return streetAddress;
			}
			set
			{
				streetAddress = value;
			}
		}

		/// <summary>
		/// Type of home
		/// </summary>
		public string HomeType
		{
			get
			{
				return homeType;
			}
			set
			{
				homeType = value;
			}
		}

		/// <summary>
		/// Returns insurance information about the house
		/// </summary>
		/// <returns></returns>
		public string GetInsuranceInfo()
		{
			return String.Format("Home Type: {0} \nStreet Address: {1} \nFloor Space (sqft.): {2} \nMonth-Year Built: {3} \n",
			this.HomeType, this.StreetAddress, this.FloorSpace, this.DateBuilt.ToString(CultureInfo.CurrentUICulture.DateTimeFormat.YearMonthPattern));

		}

	}
}
