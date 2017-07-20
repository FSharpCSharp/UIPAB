//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// Welcome.cs
//
// This file contains the implementations of the Welcome class.
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
	/// Summary description for Welcome.
	/// </summary>
	public class Welcome : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCarAndHome;
		private System.Windows.Forms.Button btnCars;
		private System.Windows.Forms.Button btnHome;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Welcome()
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
			this.label1 = new System.Windows.Forms.Label();
			this.btnCarAndHome = new System.Windows.Forms.Button();
			this.btnCars = new System.Windows.Forms.Button();
			this.btnHome = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(40, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(208, 80);
			this.label1.TabIndex = 0;
			this.label1.Text = "Welcome to the Insurance Purchase System";
			// 
			// btnCarAndHome
			// 
			this.btnCarAndHome.Location = new System.Drawing.Point(56, 128);
			this.btnCarAndHome.Name = "btnCarAndHome";
			this.btnCarAndHome.Size = new System.Drawing.Size(168, 23);
			this.btnCarAndHome.TabIndex = 1;
			this.btnCarAndHome.Text = "Car && Home Insurance";
			this.btnCarAndHome.Click += new System.EventHandler(this.btnCarAndHome_Click);
			// 
			// btnCars
			// 
			this.btnCars.Location = new System.Drawing.Point(56, 168);
			this.btnCars.Name = "btnCars";
			this.btnCars.Size = new System.Drawing.Size(168, 23);
			this.btnCars.TabIndex = 2;
			this.btnCars.Text = "Car Insurance";
			this.btnCars.Click += new System.EventHandler(this.btnCars_Click);
			// 
			// btnHome
			// 
			this.btnHome.Location = new System.Drawing.Point(56, 208);
			this.btnHome.Name = "btnHome";
			this.btnHome.Size = new System.Drawing.Size(168, 23);
			this.btnHome.TabIndex = 3;
			this.btnHome.Text = "Home Insurance";
			this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
			// 
			// Welcome
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.btnHome);
			this.Controls.Add(this.btnCars);
			this.Controls.Add(this.btnCarAndHome);
			this.Controls.Add(this.label1);
			this.Name = "Welcome";
			this.Text = "Welcome";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCarAndHome_Click(object sender, System.EventArgs e)
		{
			UIPManager.StartNavigationTask("InsurancePurchaseWizard");
		}

		private void btnCars_Click(object sender, System.EventArgs e)
		{
			UIPManager.StartNavigationTask("CarWizard");
		}

		private void btnHome_Click(object sender, System.EventArgs e)
		{
			UIPManager.StartNavigationTask("HomeWizard");
		}
	}
}
