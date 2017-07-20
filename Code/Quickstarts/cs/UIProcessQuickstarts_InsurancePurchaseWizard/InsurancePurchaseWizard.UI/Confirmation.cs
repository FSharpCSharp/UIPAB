//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// Confirmation.cs
//
// This file contains the implementations of the Confirmation class.
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
	
	public class Confirmation : WindowsFormView, IWizardViewTransition
	{
		private System.Windows.Forms.Label label1;
	
		private System.ComponentModel.Container components = null;

		public Confirmation():base()
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
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(280, 256);
			this.label1.TabIndex = 0;
			this.label1.Text = "Confirmation";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Confirmation
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.label1);
			this.Name = "Confirmation";
			this.Text = "Confirmation";
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
			// TODO:  Add Confirmation.DoCancel implementation
			return false;
		}

		public bool DoNext()
		{
			// TODO:  Add Confirmation.DoNext implementation
			return false;
		}

		public bool SupportsFinish
		{
			get
			{
				return true;
			}
		}

		public bool SupportsCancel
		{
			get
			{
				// TODO:  Add Confirmation.SupportsCancel getter implementation
				return false;
			}
		}

		public void WizardActivated()
		{
			string summary = ((InsurancePurchaseController)Controller).GetPurchaseSummary();
			this.label1.Text = summary;
		}

		public bool DoBack()
		{			
			return true;
		}

		#endregion
	}
}
