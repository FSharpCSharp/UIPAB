//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// Client.cs
//
// This file contains the implementations of the Client class.
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

namespace InsuranceClientManagement.UI
{
	/// <summary>
	/// Class that provides information about a client
	/// </summary>
	[Serializable]
	public class Client
	{
		private string name;

		/// <summary>
		/// Client name
		/// </summary>
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}
		private string address;

		/// <summary>
		/// Client address
		/// </summary>
		public string Address
		{
			get
			{
				return address;
			}
			set
			{
				address = value;
			}
		}
		private string country;

		/// <summary>
		/// Client country
		/// </summary>
		public string Country
		{
			get
			{
				return country;
			}
			set
			{
				country = value;
			}
		}
		private string phoneNumber;

		/// <summary>
		/// Client phone number
		/// </summary>
		public string PhoneNumber
		{
			get
			{
				return phoneNumber;
			}
			set
			{
				phoneNumber = value;
			}
		}

		/// <summary>
		/// Returns a string that summarizes the information about a client
		/// </summary>
		/// <returns></returns>
		public string GenerateSummary() 
		{
			return String.Format("Name: {0} \nAddress: {1} \nCountry: {2} \nPhone Number: {3}", this.Name, this.Address, this.Country, this.PhoneNumber);
		}

		public Client()
		{
		}
	}
}
