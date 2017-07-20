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

namespace InsuranceClientManagement.UI
{
	/// <summary>
	/// Summary description for Confirmation.
	/// </summary>
	public class Confirmation : Microsoft.ApplicationBlocks.UIProcess.WindowsFormView
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnContinue;
		private System.Windows.Forms.LinkLabel linkLabel1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Confirmation()
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
			this.btnContinue = new System.Windows.Forms.Button();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(280, 216);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// btnContinue
			// 
			this.btnContinue.Location = new System.Drawing.Point(64, 240);
			this.btnContinue.Name = "btnContinue";
			this.btnContinue.Size = new System.Drawing.Size(160, 23);
			this.btnContinue.TabIndex = 1;
			this.btnContinue.Text = "Continue Client Management";
			this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(64, 272);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.TabIndex = 2;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Help";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// Confirmation
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(288, 301);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.btnContinue);
			this.Controls.Add(this.label1);
			this.Name = "Confirmation";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Confirmation";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Confirmation_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnContinue_Click(object sender, System.EventArgs e)
		{
			((InsuranceClientManagementController)Controller).ContinueManagement();
		}

		private void Confirmation_Load(object sender, System.EventArgs e)
		{
			Client client = (Client)this.Navigator.CurrentState[Constants.Client];
			label1.Text= String.Format("Client Added by User '{0}'\n\n{1}", (string)this.Navigator.CurrentState[Constants.UserId], client.GenerateSummary());
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			((InsuranceClientManagementController)Controller).ShowHelp();
		}
	}
}
