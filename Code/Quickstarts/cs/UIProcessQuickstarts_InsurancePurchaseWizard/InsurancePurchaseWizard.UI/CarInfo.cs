//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// CarInfo.cs
//
// This file contains the implementations of the CarInfo class.
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
	public class CarInfo : WindowsFormView, IWizardViewTransition
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtCarMake;
		private System.Windows.Forms.TextBox txtCarYear;
		private System.Windows.Forms.TextBox txtCarModel;
		private System.Windows.Forms.TextBox txtCarColor;
		private System.Windows.Forms.ErrorProvider errNotifier;


	
		private System.ComponentModel.Container components = null;

		public CarInfo():base()
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtCarMake = new System.Windows.Forms.TextBox();
			this.txtCarColor = new System.Windows.Forms.TextBox();
			this.txtCarYear = new System.Windows.Forms.TextBox();
			this.txtCarModel = new System.Windows.Forms.TextBox();
			this.errNotifier = new System.Windows.Forms.ErrorProvider();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 24);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Make";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 64);
			this.label2.Name = "label2";
			this.label2.TabIndex = 2;
			this.label2.Text = "Model";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(32, 104);
			this.label3.Name = "label3";
			this.label3.TabIndex = 4;
			this.label3.Text = "Year";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 144);
			this.label4.Name = "label4";
			this.label4.TabIndex = 6;
			this.label4.Text = "Color";
			// 
			// txtCarMake
			// 
			this.txtCarMake.Location = new System.Drawing.Point(152, 24);
			this.txtCarMake.Name = "txtCarMake";
			this.txtCarMake.TabIndex = 1;
			this.txtCarMake.Text = "";
			// 
			// txtCarColor
			// 
			this.txtCarColor.Location = new System.Drawing.Point(152, 144);
			this.txtCarColor.Name = "txtCarColor";
			this.txtCarColor.TabIndex = 7;
			this.txtCarColor.Text = "";
			// 
			// txtCarYear
			// 
			this.txtCarYear.Location = new System.Drawing.Point(152, 104);
			this.txtCarYear.Name = "txtCarYear";
			this.txtCarYear.TabIndex = 5;
			this.txtCarYear.Text = "";
			// 
			// txtCarModel
			// 
			this.txtCarModel.Location = new System.Drawing.Point(152, 64);
			this.txtCarModel.Name = "txtCarModel";
			this.txtCarModel.TabIndex = 3;
			this.txtCarModel.Text = "";
			// 
			// errNotifier
			// 
			this.errNotifier.ContainerControl = this;
			// 
			// CarInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(304, 213);
			this.Controls.Add(this.txtCarModel);
			this.Controls.Add(this.txtCarYear);
			this.Controls.Add(this.txtCarColor);
			this.Controls.Add(this.txtCarMake);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "CarInfo";
			this.Text = "CarInfo";
			this.ResumeLayout(false);

		}
		#endregion

		#region IWizardViewTransition Members

		public bool DoFinish()
		{
			// TODO:  Add CarInfo.DoFinish implementation
			return false;
		}

		public bool DoCancel()
		{
			// TODO:  Add CarInfo.DoCancel implementation
			return false;
		}

		public bool DoNext()
		{
			bool isValid = CarInfoIsValid();
			if (isValid) 
				SaveInsurancePurchaseInfo();
			return isValid;
		}

		public bool DoBack()
		{
			// TODO:  Add CarInfo.DoBack implementation
			return true;
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

		public void WizardActivated()
		{			
		}

		#endregion

		private void HookupKeyPressHandlers()
		{
			this.txtCarYear.KeyPress+=new KeyPressEventHandler(KeyPressHandlers.NumericKeyPress);
		}

		public bool CarInfoIsValid() 
		{
			FormValidator.ControlValidator validator = new FormValidator.ControlValidator(FormValidator.HasTextValidator);

			return FormValidator.FieldIsValid(this.errNotifier,txtCarColor, "You must enter a color", validator) & 
						 FormValidator.FieldIsValid(this.errNotifier,txtCarMake, "You must enter a make", validator) & 
						 FormValidator.FieldIsValid(this.errNotifier,txtCarModel, "You must enter a model", validator) & 
						 FormValidator.FieldIsValid(this.errNotifier,txtCarYear, "You must enter a year", validator);
		}

		private void SaveInsurancePurchaseInfo() 
		{
			MyController.CreateNewCarInsurancePurchase();
			CarPurchaseInfo purchaseInfo = (CarPurchaseInfo)MyController.PurchaseInfo;
			purchaseInfo.Color = txtCarColor.Text.Trim();
			purchaseInfo.Make = txtCarMake.Text.Trim();
			purchaseInfo.Model = txtCarModel.Text.Trim();
			purchaseInfo.Year = Convert.ToInt32(txtCarYear.Text.Trim(), CultureInfo.CurrentUICulture);

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
