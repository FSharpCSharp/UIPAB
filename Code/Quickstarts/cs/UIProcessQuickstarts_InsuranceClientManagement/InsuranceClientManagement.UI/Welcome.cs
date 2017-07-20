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

namespace InsuranceClientManagement.UI
{
	/// <summary>
	/// Summary description for Welcome.
	/// </summary>
	public class Welcome : Microsoft.ApplicationBlocks.UIProcess.WindowsFormView
	{
		private System.Windows.Forms.Button btnAddClient;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnDeleteClient;
		private System.Windows.Forms.Button btnSellCarInsurance;
		private System.Windows.Forms.Button btnSellHomeInsurance;
		private System.Windows.Forms.Button btnUpdateUserInfo;
		private System.Windows.Forms.Button btnSearchForUser;
		private System.Windows.Forms.LinkLabel linkLabel1;
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
			this.btnAddClient = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnDeleteClient = new System.Windows.Forms.Button();
			this.btnSellCarInsurance = new System.Windows.Forms.Button();
			this.btnSellHomeInsurance = new System.Windows.Forms.Button();
			this.btnUpdateUserInfo = new System.Windows.Forms.Button();
			this.btnSearchForUser = new System.Windows.Forms.Button();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// btnAddClient
			// 
			this.btnAddClient.Location = new System.Drawing.Point(24, 88);
			this.btnAddClient.Name = "btnAddClient";
			this.btnAddClient.Size = new System.Drawing.Size(96, 23);
			this.btnAddClient.TabIndex = 0;
			this.btnAddClient.Text = "Add Client";
			this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(24, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(232, 48);
			this.label1.TabIndex = 1;
			this.label1.Text = "Welcome to Client Management";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnDeleteClient
			// 
			this.btnDeleteClient.Enabled = false;
			this.btnDeleteClient.Location = new System.Drawing.Point(160, 88);
			this.btnDeleteClient.Name = "btnDeleteClient";
			this.btnDeleteClient.Size = new System.Drawing.Size(96, 23);
			this.btnDeleteClient.TabIndex = 2;
			this.btnDeleteClient.Text = "Delete Client";
			// 
			// btnSellCarInsurance
			// 
			this.btnSellCarInsurance.Enabled = false;
			this.btnSellCarInsurance.Location = new System.Drawing.Point(24, 144);
			this.btnSellCarInsurance.Name = "btnSellCarInsurance";
			this.btnSellCarInsurance.Size = new System.Drawing.Size(96, 32);
			this.btnSellCarInsurance.TabIndex = 3;
			this.btnSellCarInsurance.Text = "Sell Car Insurance";
			// 
			// btnSellHomeInsurance
			// 
			this.btnSellHomeInsurance.Enabled = false;
			this.btnSellHomeInsurance.Location = new System.Drawing.Point(160, 144);
			this.btnSellHomeInsurance.Name = "btnSellHomeInsurance";
			this.btnSellHomeInsurance.Size = new System.Drawing.Size(96, 32);
			this.btnSellHomeInsurance.TabIndex = 4;
			this.btnSellHomeInsurance.Text = "Sell Home Insurance";
			// 
			// btnUpdateUserInfo
			// 
			this.btnUpdateUserInfo.Enabled = false;
			this.btnUpdateUserInfo.Location = new System.Drawing.Point(24, 208);
			this.btnUpdateUserInfo.Name = "btnUpdateUserInfo";
			this.btnUpdateUserInfo.Size = new System.Drawing.Size(96, 40);
			this.btnUpdateUserInfo.TabIndex = 5;
			this.btnUpdateUserInfo.Text = "Update User Information";
			// 
			// btnSearchForUser
			// 
			this.btnSearchForUser.Enabled = false;
			this.btnSearchForUser.Location = new System.Drawing.Point(160, 208);
			this.btnSearchForUser.Name = "btnSearchForUser";
			this.btnSearchForUser.Size = new System.Drawing.Size(96, 40);
			this.btnSearchForUser.TabIndex = 6;
			this.btnSearchForUser.Text = "Search For Users";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(24, 264);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.TabIndex = 7;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Help";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// Welcome
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(288, 293);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.btnSearchForUser);
			this.Controls.Add(this.btnUpdateUserInfo);
			this.Controls.Add(this.btnSellHomeInsurance);
			this.Controls.Add(this.btnSellCarInsurance);
			this.Controls.Add(this.btnDeleteClient);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnAddClient);
			this.Name = "Welcome";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Welcome";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnAddClient_Click(object sender, System.EventArgs e)
		{
			((InsuranceClientManagementController)this.Controller).StartAddingClient();	
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			((InsuranceClientManagementController)Controller).ShowHelp();
		}
	}
}
