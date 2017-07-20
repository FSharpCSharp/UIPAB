//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// BannerForm.cs
//
// This file contains the implementations of the BannerForm class.
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

namespace Client
{
	/// <summary>
	/// Summary description for BannerForm.
	/// </summary>
	public class BannerForm : Microsoft.ApplicationBlocks.UIProcess.WindowsFormView
	{
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BannerForm()
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
			if( disposing)
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
			this.label1.Location = new System.Drawing.Point(104, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Right Click To Hide!";
			this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BannerForm_MouseDown);
			// 
			// BannerForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(328, 86);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BannerForm";
			this.ShowInTaskbar = false;
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BannerForm_MouseDown);
			this.ResumeLayout(false);

		}
		#endregion

		private void BannerForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Right)
			{
				this.Close();
			}
		}

	}
}
