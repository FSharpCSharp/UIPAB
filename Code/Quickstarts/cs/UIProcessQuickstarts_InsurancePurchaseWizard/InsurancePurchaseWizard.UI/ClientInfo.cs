//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// ClientInfo.cs
//
// This file contains the implementations of the ClientInfo class.
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
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.UIProcess;


namespace InsurancePurchaseWizard.UI
{
	public class ClientInfo : WindowsFormView, IWizardViewTransition
	{
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cboCountry;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtEmailAddress;
		private System.Windows.Forms.TextBox txtPhoneNumber;
		private System.Windows.Forms.TextBox txtMailingAddress;
	
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
		private System.Windows.Forms.ErrorProvider errNotifier;

		public ClientInfo():base()
		{
			InitializeComponent();
		}

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
		private void InitializeComponent()
		{
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtPhoneNumber = new System.Windows.Forms.TextBox();
			this.txtMailingAddress = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.cboCountry = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtEmailAddress = new System.Windows.Forms.TextBox();
			this.errNotifier = new System.Windows.Forms.ErrorProvider();
			this.SuspendLayout();
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(136, 24);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(216, 20);
			this.txtName.TabIndex = 1;
			this.txtName.Text = "";
			// 
			// txtPhoneNumber
			// 
			this.txtPhoneNumber.Location = new System.Drawing.Point(136, 104);
			this.txtPhoneNumber.Name = "txtPhoneNumber";
			this.txtPhoneNumber.Size = new System.Drawing.Size(216, 20);
			this.txtPhoneNumber.TabIndex = 5;
			this.txtPhoneNumber.Text = "";
			// 
			// txtMailingAddress
			// 
			this.txtMailingAddress.Location = new System.Drawing.Point(136, 184);
			this.txtMailingAddress.Multiline = true;
			this.txtMailingAddress.Name = "txtMailingAddress";
			this.txtMailingAddress.Size = new System.Drawing.Size(216, 88);
			this.txtMailingAddress.TabIndex = 9;
			this.txtMailingAddress.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 104);
			this.label2.Name = "label2";
			this.label2.TabIndex = 4;
			this.label2.Text = "Phone Number";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 184);
			this.label3.Name = "label3";
			this.label3.TabIndex = 8;
			this.label3.Text = "Mailing Address";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 64);
			this.label4.Name = "label4";
			this.label4.TabIndex = 2;
			this.label4.Text = "Date Of Birth";
			// 
			// dtpDateOfBirth
			// 
			this.dtpDateOfBirth.Location = new System.Drawing.Point(136, 64);
			this.dtpDateOfBirth.Name = "dtpDateOfBirth";
			this.dtpDateOfBirth.Size = new System.Drawing.Size(216, 20);
			this.dtpDateOfBirth.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 288);
			this.label5.Name = "label5";
			this.label5.TabIndex = 10;
			this.label5.Text = "Country";
			// 
			// cboCountry
			// 
			this.cboCountry.Items.AddRange(new object[] {
															"Canada",
															"United States",
															"Mexico"});
			this.cboCountry.Location = new System.Drawing.Point(136, 288);
			this.cboCountry.Name = "cboCountry";
			this.cboCountry.Size = new System.Drawing.Size(216, 21);
			this.cboCountry.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 144);
			this.label6.Name = "label6";
			this.label6.TabIndex = 6;
			this.label6.Text = "Email Address";
			// 
			// txtEmailAddress
			// 
			this.txtEmailAddress.Location = new System.Drawing.Point(136, 144);
			this.txtEmailAddress.Name = "txtEmailAddress";
			this.txtEmailAddress.Size = new System.Drawing.Size(216, 20);
			this.txtEmailAddress.TabIndex = 7;
			this.txtEmailAddress.Text = "";
			// 
			// errNotifier
			// 
			this.errNotifier.ContainerControl = this;
			// 
			// ClientInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 341);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtEmailAddress);
			this.Controls.Add(this.txtMailingAddress);
			this.Controls.Add(this.txtPhoneNumber);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.cboCountry);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.dtpDateOfBirth);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "ClientInfo";
			this.Text = "ClientInfo";
			this.ResumeLayout(false);

		}
		#endregion

		#region IWizardViewTransition Members

		public bool DoFinish()
		{
			return false;
		}

		public bool DoCancel()
		{
			return false;
		}

		public bool DoNext()
		{			
			bool doNext = false;

			doNext = ClientInfoIsValid();

			if (doNext)
			 SaveClientInformation();

			return doNext;
		}

		public bool SupportsCancel
		{
			get
			{
				return false;
			}
		}

		public bool SupportsFinish
		{
			get
			{
				return false;
			}
		}

		public bool DoBack()
		{
			return true;
		}

		public void WizardActivated()
		{
		}

		#endregion

		private void SaveClientInformation()
		{
			Client client = new Client();

			client.Name = txtName.Text.Trim();
			client.PhoneNumber = txtPhoneNumber.Text.Trim();
			client.MailingAddress = txtMailingAddress.Text.Trim();
			client.EmailAddress = txtEmailAddress.Text.Trim();
			client.Country = cboCountry.Text.Trim();
			client.DateOfBirth= dtpDateOfBirth.Value;
			
			MyController.Client = client;
		}

		private bool ClientIsElegible () 
		{
			ValidationResult result = MyController.IsClientElegible(dtpDateOfBirth.Value);			
			errNotifier.SetError(dtpDateOfBirth, result.ErrorMessage);
			return result.IsValid;
		}

	
		private bool ClientInfoIsValid()
		{
			FormValidator.ControlValidator validator = new FormValidator.ControlValidator(FormValidator.HasTextValidator);

			return FormValidator.FieldIsValid(this.errNotifier,this.txtName,"Please enter a valid name",validator) & 
						 FormValidator.FieldIsValid(this.errNotifier,this.txtMailingAddress,"Please enter your address.",validator) &
					   FormValidator.FieldIsValid(this.errNotifier,this.txtEmailAddress,"Please enter your email address.",validator) &
						 FormValidator.FieldIsValid(this.errNotifier,this.txtPhoneNumber,"Please enter your phone number.",validator) & ClientIsElegible ();

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
