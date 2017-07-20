//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// PickYouInsurance.cs
//
// This file contains the implementations of the PickYourInsurance class.
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
	/// <summary>
	/// Summary description for PickYourInsurance.
	/// </summary>
	public class PickYourInsurance : WindowsFormView, IWizardViewTransition
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton radCar;
		private System.Windows.Forms.RadioButton radHome;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PickYourInsurance():base()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.radCar = new System.Windows.Forms.RadioButton();
			this.radHome = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// radCar
			// 
			this.radCar.Checked = true;
			this.radCar.Location = new System.Drawing.Point(32, 96);
			this.radCar.Name = "radCar";
			this.radCar.TabIndex = 1;
			this.radCar.TabStop = true;
			this.radCar.Text = "Car";
			// 
			// radHome
			// 
			this.radHome.Location = new System.Drawing.Point(32, 144);
			this.radHome.Name = "radHome";
			this.radHome.TabIndex = 2;
			this.radHome.Text = "Home";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Choose Your Insurance:";
			// 
			// PickYourInsurance
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(248, 229);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.radHome);
			this.Controls.Add(this.radCar);
			this.Name = "PickYourInsurance";
			this.Text = "PickYourInsurance";
			this.ResumeLayout(false);

		}
		#endregion

		#region IWizardViewTransition Members

		public bool DoFinish()
		{
			// TODO:  Add PickYourInsurance.DoFinish implementation
			return false;
		}

		public bool DoCancel()
		{
			// TODO:  Add PickYourInsurance.DoCancel implementation
			return false;
		}
		
		public bool DoNext()
		{
			// A custom check is performed to determine which path of the wizard the user
			// should go down, a method is called on the controller that will change the state
			// navigate value to the equivalent view that should be activated
			if (radHome.Checked) 
			{
				MyController.PurchaseHomeInsurance();
			} 
			else 
			{
				MyController.PurchaseCarInsurance();
			}
			return true;
		}

		public bool DoBack()
		{
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

		#region "UIP Plumbing"
		private InsurancePurchaseController MyController
		{
			get { return (InsurancePurchaseController)Controller;}
		}
		#endregion
	}
}
