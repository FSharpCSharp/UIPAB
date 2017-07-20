//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// InsurancePurchaseController.cs
//
// This file contains the implementations of the InsurancePurchaseController class.
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
using System.Text;
using Microsoft.ApplicationBlocks.UIProcess;

namespace InsurancePurchaseWizard.UI
{
	/// <summary>
	/// Controller object that services all requests from various views in the InsurancePurchase Quickstart
	/// </summary>
	public class InsurancePurchaseController : ControllerBase
	{
		public InsurancePurchaseController(Navigator navigator):base(navigator)
		{
		}

		/// <summary>
		/// Navigates to the view that collects car information
		/// </summary>
		public void PurchaseCarInsurance()
		{
			this.Navigator.CurrentState.NavigateValue="car";			
		}

		/// <summary>
		/// Navigates to the view that collects home information
		/// </summary>
		public void PurchaseHomeInsurance()
		{
			this.Navigator.CurrentState.NavigateValue="home";			
		}

		/// <summary>
		/// Returns a client object that is currently stored in the state for the wizard
		/// </summary>
		public Client Client
		{
			get
			{
				return (Client)this.Navigator.CurrentState["client"];
			}
			set
			{
				this.Navigator.CurrentState["client"] = value;
			}
		} 

		/// <summary>
		/// Creates a new HomePurchaseInfo object and stores it in the state
		/// </summary>
		public void CreateNewHomeInsurancePurchase() 
		{			
			this.Navigator.CurrentState["info"] = new HomePurchaseInfo();
		}
		

		/// <summary>
		/// Creates a new CarPurchaseInfo object and stores it in the state
		/// </summary>
		public void CreateNewCarInsurancePurchase() 
		{
			this.Navigator.CurrentState["info"] = new CarPurchaseInfo();
		}

		/// <summary>
		/// Returns an object that allows the client to get information about
		/// the insurance purchase
		/// </summary>
		public IInsuranceInfo PurchaseInfo
		{
			get
			{
				return (IInsuranceInfo)this.Navigator.CurrentState["info"];
			}
		}

		/// <summary>
		/// Returns a string that summarizes the insurance information
		/// collected by the wizard
		/// </summary>
		/// <returns></returns>
		public string GetPurchaseSummary()
		{
			System.Text.StringBuilder summary = new System.Text.StringBuilder();
			
			summary.Append((Client == null) ? "" : Client.GetSummary());
			summary.Append((PurchaseInfo == null) ? "" : PurchaseInfo.GetInsuranceInfo());
			
			return summary.ToString();

		}

		#region "Validation Methods"

		public ValidationResult IsHomeBuildDateValid(DateTime dateBuilt)
		{
			bool isValid = false;
			string errorMessage ="";

			if (dateBuilt >= DateTime.Today) 
			{
				errorMessage = "The date built must be in the past.";			
			}
			else
				isValid = true;
			
			return new ValidationResult(isValid,errorMessage);
		}

		public ValidationResult IsClientElegible(DateTime birthDate) 
		{
			bool isValid = false;
			string errorMessage ="";

			if (birthDate > DateTime.Today.AddYears(-18)) 
			{
				errorMessage = "You must be over 18 years of age";								
			}
			else
				isValid = true;
			

			return new ValidationResult(isValid,errorMessage);
		}

		#endregion
	}
}
