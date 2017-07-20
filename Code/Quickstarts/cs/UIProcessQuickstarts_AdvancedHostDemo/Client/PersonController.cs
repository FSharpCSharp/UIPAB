//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// PersonController.cs
//
// This file contains the implementations of the PersonController class.
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
using Microsoft.ApplicationBlocks.UIProcess;

namespace Client
{
	
	/// <summary>
	/// Controller for the Person Control
	/// </summary>
	/// 
	public sealed class PersonController : PersonControllerBase
	{		
		private const string HOMEADDRESS_TYPE = "home";
		private const string WORKADDRESS_TYPE = "work";

		#region "Constructors"

		public PersonController(Navigator navigator) : base(navigator) 
		{			
		}


		#endregion

		/// <summary>
		/// Method used to return a particular address for a person
		/// </summary>
		/// <param name="person">Person whose address to search for</param>
		/// <param name="addressType">Type of address (work,home)</param>
		/// <returns></returns>
		private Client.EmployeeData.AddressRow GetAddress(Client.EmployeeData.PersonRow person,string addressType)
		{
			EmployeeData.AddressRow address = null;

			foreach (EmployeeData.PersonAddressRow row in person.GetPersonAddressRows())
			{
				if (row.Type.ToUpper() == addressType.ToUpper())
				{
					address =  row.AddressRow;					
					break;
				}				
			}

			return address;
		}


		/// <summary>
		/// Method used to add a subscriber that is interested in knowing about changes that occure to a person's
		/// address.
		/// </summary>
		/// <param name="notifier">Delegate that will be invoked when a change in an employee's address occurs</param>	
		public void SubscribeForChangesToAddressInformation(Client.EmployeeData.AddressRowChangeEventHandler notifier)
		{
			this.EmployeeData.Address.AddressRowChanged+=notifier;			
		}

		/// <summary>
		/// Method used to add a subscriber that is interested in knowing about changes that occure to a person's
		/// phone information.
		/// </summary>
		/// <param name="notifier">Delegate that will be invoked when a change in an employee's phone number occurs</param>
		public void SubscribeForChangesToPhoneInformation(Client.EmployeeData.PhoneRowChangeEventHandler notifier)
		{
			this.EmployeeData.Phone.PhoneRowChanged+=notifier;
		}

		/// <summary>
		/// Method used to rollback changes made to information in the dataset
		/// </summary>
		public void RejectChangesToEmployeeInformation()
		{
			this.EmployeeData.RejectChanges();
		}

		/// <summary>
		/// Method used to save changes made to the information in the dataset
		/// </summary>
		public void SaveChangesToEmployeeInformation()
		{
			this.EmployeeData.AcceptChanges();
			this.EmployeeData.WriteXml(DATAFILE);
		}

		/// <summary>
		/// Method used to retrieve a persons's work address
		/// </summary>
		/// <param name="person"></param>
		/// <returns></returns>
		public Client.EmployeeData.AddressRow GetWorkAddressForPerson(Client.EmployeeData.PersonRow person)
		{
			return GetAddress(person,WORKADDRESS_TYPE);
		}


		/// <summary>
		/// Method used to retrieve a person's home address
		/// </summary>
		/// <param name="person"></param>
		/// <returns></returns>
		public EmployeeData.AddressRow GetHomeAddressForPerson(Client.EmployeeData.PersonRow person)
		{
			return GetAddress(person,HOMEADDRESS_TYPE);
		}

		/// <summary>
		/// Method used to retrieve a person's phone number
		/// </summary>
		/// <param name="person"></param>
		/// <returns></returns>
		public EmployeeData.PhoneRow GetPhoneNumberForPerson(Client.EmployeeData.PersonRow person)
		{
			EmployeeData.PhoneRow[] rows = person.GetPhoneRows();
			return rows[0];
		}


		
		
	}
}

