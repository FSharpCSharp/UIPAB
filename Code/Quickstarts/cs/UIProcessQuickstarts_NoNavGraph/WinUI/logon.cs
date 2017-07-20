//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// logon.cs
//
// This file contains the implementations of the logon class.
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
using System.Diagnostics;

using Microsoft.ApplicationBlocks.UIProcess;

namespace UIProcessQuickstarts_Store.WinUI
{
	public class logon : System.Windows.Forms.Form, IShutdownUIP
	{
		private ITask _startingTask;
		private System.Windows.Forms.Label emailLabel;
		private System.Windows.Forms.TextBox emailText;
		private System.Windows.Forms.TextBox passwordText;
		private System.Windows.Forms.Label passwordLabel;
		private System.Windows.Forms.Button okButton;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;

		private static string User;
				
		public static string UserName
		{
			get{ return User; }
		}	

		public logon()
		{
            
            //
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			UIPManager.RegisterShutdown(this);
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
			this.emailLabel = new System.Windows.Forms.Label();
			this.emailText = new System.Windows.Forms.TextBox();
			this.passwordText = new System.Windows.Forms.TextBox();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// emailLabel
			// 
			this.emailLabel.Location = new System.Drawing.Point(48, 80);
			this.emailLabel.Name = "emailLabel";
			this.emailLabel.Size = new System.Drawing.Size(48, 16);
			this.emailLabel.TabIndex = 0;
			this.emailLabel.Text = "Email";
			// 
			// emailText
			// 
			this.emailText.Location = new System.Drawing.Point(112, 80);
			this.emailText.Name = "emailText";
			this.emailText.Size = new System.Drawing.Size(144, 20);
			this.emailText.TabIndex = 1;
			this.emailText.Text = "";
			// 
			// passwordText
			// 
			this.passwordText.Location = new System.Drawing.Point(112, 112);
			this.passwordText.Name = "passwordText";
			this.passwordText.PasswordChar = '*';
			this.passwordText.Size = new System.Drawing.Size(144, 20);
			this.passwordText.TabIndex = 3;
			this.passwordText.Text = "";
			// 
			// passwordLabel
			// 
			this.passwordLabel.Location = new System.Drawing.Point(48, 112);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(64, 16);
			this.passwordLabel.TabIndex = 2;
			this.passwordLabel.Text = "Password";
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(176, 144);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(80, 24);
			this.okButton.TabIndex = 4;
			this.okButton.Text = "Let´s roll";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(48, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(208, 32);
			this.label1.TabIndex = 5;
			this.label1.Text = "Log On As: user@UIP.rocks, password";
			// 
			// logon
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(328, 184);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.passwordText);
			this.Controls.Add(this.emailText);
			this.Controls.Add(this.passwordLabel);
			this.Controls.Add(this.emailLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "logon";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Logon";
			this.ResumeLayout(false);

		}
		#endregion

		private void okButton_Click(object sender, System.EventArgs e)
		{
			//Ask controller if user is valid
			if ( StoreController.IsUserValid(emailText.Text, passwordText.Text) ) 
			{
				//  Logon was valid.
				User = emailText.Text;
			
				// Start task with the previous task id
				_startingTask = new CartTask(emailText.Text);
				UIPManager.StartOpenNavigationTask("shopping", "cart", _startingTask );  
						                        
				//This view can be hidden because it started the task and its lifetime isn´t controlled
				//by the UIPManager class
				this.Visible = false; 
			}
			else
			{
				MessageBox.Show("The user or password are incorrect");
			}
		}
		public ITask StartingTask
		{
			get
			{
				return _startingTask;
			}
		}
		#region IShutdownUIP Members

		public void Shutdown()
		{
			// TODO:  Add logon.Shutdown implementation
			Application.Exit();
		}

		#endregion
	}
}
