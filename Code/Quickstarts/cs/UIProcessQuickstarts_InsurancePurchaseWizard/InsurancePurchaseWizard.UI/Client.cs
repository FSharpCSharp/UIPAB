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
using System.Globalization;
using System.Text;

namespace InsurancePurchaseWizard.UI
{
	/// <summary>
	///	Class used to collect information about a client
	/// </summary>
	[Serializable]
	public class Client
	{
		DateTime dateOfBirth;
		string name;
		string phoneNumber;
		string emailAddress;
		string mailingAddress;
		string country;

		/// <summary>
		/// Client's name
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

		
		/// <summary>
		/// Client's birthday
		/// </summary>
		public DateTime DateOfBirth
		{
			get
			{
				return dateOfBirth;
			}
			set
			{
				dateOfBirth = value;
			}
		}

		/// <summary>
		/// Client's phone number
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
		/// Client's email address
		/// </summary>
		public string EmailAddress
		{
			get
			{
				return emailAddress;
			}
			set
			{
				emailAddress = value;
			}
		}

		/// <summary>
		/// Client's mailing address
		/// </summary>
		public string MailingAddress
		{
			get
			{
				return mailingAddress;
			}
			set
			{
				mailingAddress = value;
			}
		}


		/// <summary>
		/// Client's country of residence
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

		/// <summary>
		/// Get's a string that returns a summary of the client information
		/// </summary>
		/// <returns></returns>
		public string GetSummary()
		{
			
			return String.Format("Name: {0} \nDate of Birth: {1} \ne-mail address: {2} \nMailing Address: {3} \nCountry: {4} \n",
			this.Name, this.DateOfBirth.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern), this.EmailAddress, this.MailingAddress, this.Country);

		}
	
	}
}
