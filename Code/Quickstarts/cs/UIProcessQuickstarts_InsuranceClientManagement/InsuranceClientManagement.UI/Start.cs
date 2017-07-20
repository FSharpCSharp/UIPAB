//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// Start.cs
//
// This file contains the implementations of the Start class.
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

namespace InsuranceClientManagement.UI
{
	/// <summary>
	/// Summary description for Start.
	/// </summary>
	public class Start : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnStartMeUp;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Start()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			Authorization.INSTANCE.Init();
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
			this.btnStartMeUp = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnStartMeUp
			// 
			this.btnStartMeUp.Location = new System.Drawing.Point(80, 88);
			this.btnStartMeUp.Name = "btnStartMeUp";
			this.btnStartMeUp.Size = new System.Drawing.Size(128, 80);
			this.btnStartMeUp.TabIndex = 0;
			this.btnStartMeUp.Text = "Start Client Management System";
			this.btnStartMeUp.Click += new System.EventHandler(this.btnStartAuthenticated_Click);
			// 
			// Start
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.btnStartMeUp);
			this.Name = "Start";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Start";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnStartAuthenticated_Click(object sender, System.EventArgs e)
		{
			UIPManager.StartNavigationTask("ManageInsuranceClients");		
		}

	}
}
