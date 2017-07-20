//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// checkout.cs
//
// This file contains the implementations of the checkout class.
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

namespace UIProcessQuickstarts_Store.WinUI
{
	/// <summary>
	/// Summary description for checkout.
	/// </summary>
	public class checkout : WindowsFormView
	{
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.TextBox addressText;
        private System.Windows.Forms.TextBox creditCardText;
        private System.Windows.Forms.Button finishButton;
		private System.Windows.Forms.Button cancelButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public checkout()
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.nameText = new System.Windows.Forms.TextBox();
			this.addressText = new System.Windows.Forms.TextBox();
			this.creditCardText = new System.Windows.Forms.TextBox();
			this.finishButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(56, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(240, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Please, enter your checkout information here:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(56, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Your name:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(56, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Your address:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(56, 136);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(136, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Your credit card number:";
			// 
			// nameText
			// 
			this.nameText.Enabled = false;
			this.nameText.Location = new System.Drawing.Point(192, 70);
			this.nameText.Name = "nameText";
			this.nameText.Size = new System.Drawing.Size(176, 20);
			this.nameText.TabIndex = 4;
			this.nameText.Text = "";
			// 
			// addressText
			// 
			this.addressText.Enabled = false;
			this.addressText.Location = new System.Drawing.Point(192, 102);
			this.addressText.Name = "addressText";
			this.addressText.Size = new System.Drawing.Size(176, 20);
			this.addressText.TabIndex = 5;
			this.addressText.Text = "";
			// 
			// creditCardText
			// 
			this.creditCardText.Enabled = false;
			this.creditCardText.Location = new System.Drawing.Point(192, 134);
			this.creditCardText.Name = "creditCardText";
			this.creditCardText.Size = new System.Drawing.Size(176, 20);
			this.creditCardText.TabIndex = 6;
			this.creditCardText.Text = "";
			// 
			// finishButton
			// 
			this.finishButton.Location = new System.Drawing.Point(40, 184);
			this.finishButton.Name = "finishButton";
			this.finishButton.Size = new System.Drawing.Size(128, 24);
			this.finishButton.TabIndex = 7;
			this.finishButton.Text = "Finish order";
			this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(248, 184);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 8;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// checkout
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(408, 230);
			this.ControlBox = false;
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.finishButton);
			this.Controls.Add(this.creditCardText);
			this.Controls.Add(this.addressText);
			this.Controls.Add(this.nameText);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "checkout";
			this.Text = "Checkout";
			this.Load += new System.EventHandler(this.checkout_Load);
			this.ResumeLayout(false);

		}
		#endregion

        private void finishButton_Click(object sender, System.EventArgs e)
        {
            StoreController.CompleteCheckout( nameText.Text, addressText.Text, creditCardText.Text );
        }

        private void checkout_Load(object sender, System.EventArgs e)
        {
            CustomerDS.Customer cust = StoreController.GetCustomerByLogon(logon.UserName);
            nameText.Text = cust.FullName;
            addressText.Text = cust.EmailAddress;
            creditCardText.Text = "1111-1111-1111-1111";
        }

		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			StoreController.StopShopping();
		}

        #region UIPManager Plumbing
        private StoreController StoreController
        {
            get{ return (StoreController)this.Controller; }
        }
        #endregion
	}
}
