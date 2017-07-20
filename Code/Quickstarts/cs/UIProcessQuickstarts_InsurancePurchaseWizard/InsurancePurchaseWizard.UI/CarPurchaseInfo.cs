//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// CarPurchaseInfo.cs
//
// This file contains the implementations of the CarPurchaseInfo class.
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

namespace InsurancePurchaseWizard.UI
{
	/// <summary>
	/// Class that provides information about a car
	/// </summary>
	[Serializable]
	public class CarPurchaseInfo : IInsuranceInfo
	{
		private string make;
		private string model;
		private int year;
		private string color;

		public CarPurchaseInfo()
		{			
		}

		/// <summary>
		/// Color of the car
		/// </summary>
		public string Color
		{
			get
			{
				return color;
			}
			set
			{
				color = value;
			}
		}

		/// <summary>
		/// Year the car was made
		/// </summary>
		public int Year
		{
			get
			{
				return year;
			}
			set
			{
				year = value;
			}
		}

		/// <summary>
		/// Model of the car
		/// </summary>
		public string Model
		{
			get
			{
				return model;
			}
			set
			{
				model = value;
			}
		}

		/// <summary>
		/// Make of car
		/// </summary>
		public string Make
		{
			get
			{
				return make;
			}
			set
			{
				make = value;
			}
		}
		
		/// <summary>
		/// Returns insurance information related to a car
		/// </summary>
		/// <returns></returns>
		public string GetInsuranceInfo()
		{
			return String.Format("Make: {0} \nModel: {1} \nYear: {2} \nColor: {3} \n", this.Make, this.Model, this.Year, this.Color);
		}


		
	}
}
