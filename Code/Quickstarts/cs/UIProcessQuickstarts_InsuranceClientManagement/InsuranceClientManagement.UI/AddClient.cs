//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// AddClient.cs
//
// This file contains the implementations of the AddClient class.
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
	public class AddClient : Microsoft.ApplicationBlocks.UIProcess.WindowsFormView
	{
		private System.Windows.Forms.Button btnAddClient;
		private System.Windows.Forms.Button btnThrowException;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.TextBox txtPhoneNumber;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtCountry;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.ComponentModel.Container components = null;

		public AddClient()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
			this.btnThrowException = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.txtPhoneNumber = new System.Windows.Forms.TextBox();
			this.txtCountry = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.errorProvider = new System.Windows.Forms.ErrorProvider();
			this.label5 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// btnAddClient
			// 
			this.btnAddClient.Location = new System.Drawing.Point(24, 232);
			this.btnAddClient.Name = "btnAddClient";
			this.btnAddClient.Size = new System.Drawing.Size(112, 40);
			this.btnAddClient.TabIndex = 8;
			this.btnAddClient.Text = "Add Client";
			this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
			// 
			// btnThrowException
			// 
			this.btnThrowException.Location = new System.Drawing.Point(160, 232);
			this.btnThrowException.Name = "btnThrowException";
			this.btnThrowException.Size = new System.Drawing.Size(120, 40);
			this.btnThrowException.TabIndex = 9;
			this.btnThrowException.Text = "Search For Client (Throws Exception)";
			this.btnThrowException.Click += new System.EventHandler(this.btnThrowException_Click);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(152, 56);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(128, 20);
			this.txtName.TabIndex = 1;
			this.txtName.Text = "";
			// 
			// txtAddress
			// 
			this.txtAddress.Location = new System.Drawing.Point(152, 96);
			this.txtAddress.Multiline = true;
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(128, 40);
			this.txtAddress.TabIndex = 3;
			this.txtAddress.Text = "";
			// 
			// txtPhoneNumber
			// 
			this.txtPhoneNumber.Location = new System.Drawing.Point(152, 192);
			this.txtPhoneNumber.Name = "txtPhoneNumber";
			this.txtPhoneNumber.Size = new System.Drawing.Size(128, 20);
			this.txtPhoneNumber.TabIndex = 7;
			this.txtPhoneNumber.Text = "";
			// 
			// txtCountry
			// 
			this.txtCountry.Location = new System.Drawing.Point(152, 152);
			this.txtCountry.Name = "txtCountry";
			this.txtCountry.Size = new System.Drawing.Size(128, 20);
			this.txtCountry.TabIndex = 5;
			this.txtCountry.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Address";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(32, 192);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Phone Number";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 152);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "Country";
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(32, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(232, 32);
			this.label5.TabIndex = 10;
			this.label5.Text = "Add Client Information";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(104, 304);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.TabIndex = 11;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Help";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// AddClient
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(312, 349);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtCountry);
			this.Controls.Add(this.txtPhoneNumber);
			this.Controls.Add(this.txtAddress);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.btnThrowException);
			this.Controls.Add(this.btnAddClient);
			this.Name = "AddClient";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add Client to System";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnAddClient_Click(object sender, System.EventArgs e)
		{
			Client client = GetClientInfo();
			if (CheckControls()) 
			{
				((InsuranceClientManagementController)Controller).ExecuteAddClientRequest(client);
			}
		}

		private bool CheckControls() 
		{
			return CheckControlHasText(txtAddress, "An Address Must Be Entered") &
				CheckControlHasText(txtCountry, "A Country Must Be Entered") &
				CheckControlHasText(txtName, "A Name Must Be Entered") &
				CheckControlHasText(txtPhoneNumber, "A Phone Number Must Be Entered");
		}

		private bool CheckControlHasText(Control control, string errorMessage) 
		{
			if (control.Text.Trim().Length > 0) 
			{
				errorProvider.SetError(control, "");
				return true;
			}
			errorProvider.SetError(control, errorMessage);			
			return false;
		}

		private Client GetClientInfo() 
		{
			Client client = new Client();
			client.Address = txtAddress.Text.Trim();
			client.Country = txtCountry.Text.Trim();
			client.Name = txtName.Text.Trim();
			client.PhoneNumber = txtPhoneNumber.Text.Trim();
			return client;
		}

		private void btnThrowException_Click(object sender, System.EventArgs e)
		{
			((InsuranceClientManagementController)Controller).ThrowException();
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			((InsuranceClientManagementController)Controller).ShowHelp();
		}

	}
}
