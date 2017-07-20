//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// congratulation.cs
//
// This file contains the implementations of the congratulation class.
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
	public class congratulation : WindowsFormView
	{
		private System.Windows.Forms.Button returnButton;
		private System.Windows.Forms.Label msgLabel;
        
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public congratulation()
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
            this.msgLabel = new System.Windows.Forms.Label();
            this.returnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // msgLabel
            // 
            this.msgLabel.Location = new System.Drawing.Point(32, 24);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(232, 32);
            this.msgLabel.TabIndex = 0;
            this.msgLabel.Text = "Congratulations. Your order has been sent sucessfully";
            this.msgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(96, 72);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(104, 24);
            this.returnButton.TabIndex = 1;
            this.returnButton.Text = "Return";
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // congratulation
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(288, 109);
            this.ControlBox = false;
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.msgLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "congratulation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Congratulations";
            this.Load += new System.EventHandler(this.congratulation_Load);
            this.ResumeLayout(false);

        }
		#endregion

		private void returnButton_Click(object sender, System.EventArgs e)
		{
			StoreController.StartNewShoppingSession();
		}

        private void congratulation_Load(object sender, System.EventArgs e)
        {
        }

        #region UIPManager Plumbing
        private StoreController StoreController
        {
            get{ return (StoreController)this.Controller; }
        }
        #endregion
	}
}
