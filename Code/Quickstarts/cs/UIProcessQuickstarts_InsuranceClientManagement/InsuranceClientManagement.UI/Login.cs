//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// Login.cs
//
// This file contains the implementations of the Login class.
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
	/// Summary description for Login.
	/// </summary>
	public class Login : Microsoft.ApplicationBlocks.UIProcess.WindowsFormView
	{
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Button btnNoLogin;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.LinkLabel linkLabel1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Login()
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
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.btnNoLogin = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnLogin = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.errorProvider = new System.Windows.Forms.ErrorProvider();
			this.label4 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(152, 96);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.TabIndex = 1;
			this.txtUsername.Text = "";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(152, 144);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.TabIndex = 3;
			this.txtPassword.Text = "";
			// 
			// btnNoLogin
			// 
			this.btnNoLogin.Location = new System.Drawing.Point(152, 192);
			this.btnNoLogin.Name = "btnNoLogin";
			this.btnNoLogin.Size = new System.Drawing.Size(112, 40);
			this.btnNoLogin.TabIndex = 7;
			this.btnNoLogin.Text = "Enter Anonymously (no login)";
			this.btnNoLogin.Click += new System.EventHandler(this.btnNoLogin_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 144);
			this.label1.Name = "label1";
			this.label1.TabIndex = 9;
			this.label1.Text = "password";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 96);
			this.label2.Name = "label2";
			this.label2.TabIndex = 10;
			this.label2.Text = "username";
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(24, 192);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(112, 40);
			this.btnLogin.TabIndex = 11;
			this.btnLogin.Text = "Login";
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(272, 32);
			this.label3.TabIndex = 12;
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(240, 24);
			this.label4.TabIndex = 13;
			this.label4.Text = "Username = \'manager\' Password= \'manager\'";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(24, 240);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.TabIndex = 14;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Help";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// Login
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnNoLogin);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtUsername);
			this.Name = "Login";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
			this.Load += new System.EventHandler(this.Login_Load);
			this.ResumeLayout(false);

		}
		#endregion


		private void btnLogin_Click_1(object sender, System.EventArgs e)
		{
			if (CheckUsernameAndPassword()) 
			{
				MyController.LogMeIn(txtUsername.Text.Trim(), txtPassword.Text.Trim());
			}	
		}

		private void ClearErrors()
		{
			foreach(Control textBox in this.Controls)
			{
				if (textBox is TextBox) 
					errorProvider.SetError(textBox,"");
			}
		}
		private bool CheckUsernameAndPassword() 
		{
			ClearErrors();
			bool isValid = CheckControlHasText(txtUsername, "Must Enter Username") & CheckControlHasText(txtPassword, "Must Enter Password");			
			if (isValid)
			{
				if (! MyController.IsManager(txtUsername.Text,txtPassword.Text))			
				{
					errorProvider.SetError(txtUsername,"The login information provided is invalid.");				
					isValid = false;
				}
			}

			return isValid;
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

		private void btnNoLogin_Click(object sender, System.EventArgs e)
		{
			MyController.DoNotLogMeIn();			
		}

		private void Login_Load(object sender, System.EventArgs e)
		{
			if (this.Navigator.CurrentState[Constants.Error] != null) 
			{
				label3.Text = (string)this.Navigator.CurrentState[Constants.Error];
				btnNoLogin.Enabled = false;
			}
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			((InsuranceClientManagementController)Controller).ShowHelp();
		}

		private InsuranceClientManagementController MyController
		{
			get
			{
				return (InsuranceClientManagementController)Controller;
			}
		}

	}
}
