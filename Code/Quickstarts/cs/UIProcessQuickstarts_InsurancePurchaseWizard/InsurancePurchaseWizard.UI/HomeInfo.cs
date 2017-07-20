//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// HomeInfo.cs
//
// This file contains the implementations of the HomeInfo class.
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.UIProcess;


namespace InsurancePurchaseWizard.UI
{
	/// <summary>
	/// Summary description for HomeInfo.
	/// </summary>
	public class HomeInfo : WindowsFormView, IWizardViewTransition
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtHomeStreetAddress;
		private System.Windows.Forms.TextBox txtHomeFloorSpace;
		private System.Windows.Forms.DateTimePicker dtpHomeBuildDate;

		private System.Windows.Forms.ErrorProvider errNotifier;
		private System.Windows.Forms.ComboBox cboHomeType;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public HomeInfo():base()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			HookupKeyPressHandlers();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtHomeStreetAddress = new System.Windows.Forms.TextBox();
			this.txtHomeFloorSpace = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cboHomeType = new System.Windows.Forms.ComboBox();
			this.dtpHomeBuildDate = new System.Windows.Forms.DateTimePicker();
			this.errNotifier = new System.Windows.Forms.ErrorProvider();
			this.SuspendLayout();
			// 
			// txtHomeStreetAddress
			// 
			this.txtHomeStreetAddress.Location = new System.Drawing.Point(136, 144);
			this.txtHomeStreetAddress.Multiline = true;
			this.txtHomeStreetAddress.Name = "txtHomeStreetAddress";
			this.txtHomeStreetAddress.Size = new System.Drawing.Size(208, 80);
			this.txtHomeStreetAddress.TabIndex = 7;
			this.txtHomeStreetAddress.Text = "";
			// 
			// txtHomeFloorSpace
			// 
			this.txtHomeFloorSpace.Location = new System.Drawing.Point(136, 104);
			this.txtHomeFloorSpace.Name = "txtHomeFloorSpace";
			this.txtHomeFloorSpace.Size = new System.Drawing.Size(208, 20);
			this.txtHomeFloorSpace.TabIndex = 5;
			this.txtHomeFloorSpace.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 152);
			this.label1.Name = "label1";
			this.label1.TabIndex = 6;
			this.label1.Text = "Street Address";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 24);
			this.label3.Name = "label3";
			this.label3.TabIndex = 0;
			this.label3.Text = "Home Type";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 64);
			this.label4.Name = "label4";
			this.label4.TabIndex = 2;
			this.label4.Text = "Date Built";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 104);
			this.label5.Name = "label5";
			this.label5.TabIndex = 4;
			this.label5.Text = "Floor Space (sqft)";
			// 
			// cboHomeType
			// 
			this.cboHomeType.Items.AddRange(new object[] {
															 "Duplex",
															 "Townhouse",
															 "Condo"});
			this.cboHomeType.Location = new System.Drawing.Point(136, 24);
			this.cboHomeType.Name = "cboHomeType";
			this.cboHomeType.Size = new System.Drawing.Size(208, 21);
			this.cboHomeType.TabIndex = 1;
			// 
			// dtpHomeBuildDate
			// 
			this.dtpHomeBuildDate.CustomFormat = "MM/yyyy";
			this.dtpHomeBuildDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpHomeBuildDate.Location = new System.Drawing.Point(136, 64);
			this.dtpHomeBuildDate.Name = "dtpHomeBuildDate";
			this.dtpHomeBuildDate.Size = new System.Drawing.Size(208, 20);
			this.dtpHomeBuildDate.TabIndex = 3;
			this.dtpHomeBuildDate.Value = new System.DateTime(2004, 1, 20, 14, 42, 22, 75);
			// 
			// errNotifier
			// 
			this.errNotifier.ContainerControl = this;
			// 
			// HomeInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 261);
			this.Controls.Add(this.cboHomeType);
			this.Controls.Add(this.dtpHomeBuildDate);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtHomeFloorSpace);
			this.Controls.Add(this.txtHomeStreetAddress);
			this.Name = "HomeInfo";
			this.Text = "HomeInfo";
			this.ResumeLayout(false);

		}
		#endregion

		#region IWizardViewTransition Members

		public bool DoFinish()
		{			
			return true;
		}

		public bool DoCancel()
		{
			return true;
		}

		public bool DoNext()
		{
			bool isValid = HomeInfoIsValid();
			if (isValid) 
				SaveInsurancePurchaseInfo();
			return isValid;
		}

		public bool DoBack()
		{
			return true;
		}

		public bool SupportsCancel
		{
			get
			{
				return true;
			}
		}

		public bool SupportsFinish
		{
			get
			{
				return true;
			}
		}

		public void WizardActivated()
		{
		}

		#endregion

		/// <summary>
		/// Method that performs validation against the fields on the form
		/// </summary>
		/// <returns>True if all of the controls contain valid information</returns>
		private bool HomeInfoIsValid()
		{
			FormValidator.ControlValidator validator = new FormValidator.ControlValidator(FormValidator.HasTextValidator);
			return FormValidator.FieldIsValid(this.errNotifier,this.txtHomeFloorSpace,"Please enter a valid number", validator) & 
				FormValidator.FieldIsValid(this.errNotifier,this.txtHomeStreetAddress,"Please enter the Street Address of the Home to be insured", validator) &
				FormValidator.FieldIsValid(this.errNotifier, this.cboHomeType, "Please select a home type", validator) & HomeBuiltDateIsValid();

		}

		/// <summary>
		/// Method that returns whether the date the house was built is valid
		/// </summary>
		/// <returns></returns>
		private bool HomeBuiltDateIsValid() 
		{
			ValidationResult result = MyController.IsHomeBuildDateValid(dtpHomeBuildDate.Value);			
			errNotifier.SetError(dtpHomeBuildDate, result.ErrorMessage);
			return result.IsValid;
		}

		/// <summary>
		/// Method used to hook up textboxes on the screen to customer keypress event handlers
		/// </summary>
		private void HookupKeyPressHandlers()
		{
			this.txtHomeFloorSpace.KeyPress+=new KeyPressEventHandler(KeyPressHandlers.NumericKeyPress);
		}

		/// <summary>
		/// Method used to store the information about the home purchase
		/// </summary>
		private void SaveInsurancePurchaseInfo() 
		{			
			MyController.CreateNewHomeInsurancePurchase();
			HomePurchaseInfo purchaseInfo = (HomePurchaseInfo)MyController.PurchaseInfo;
			purchaseInfo.DateBuilt = dtpHomeBuildDate.Value;
			purchaseInfo.FloorSpace = Convert.ToDecimal(txtHomeFloorSpace.Text.Trim(), CultureInfo.CurrentUICulture);
			purchaseInfo.HomeType = cboHomeType.Text.Trim();
			purchaseInfo.StreetAddress = txtHomeStreetAddress.Text.Trim();
		}

		private InsurancePurchaseController MyController
		{
			get
			{
				return (InsurancePurchaseController)Controller;
			}

		}
	}
}
