//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// ClientSearch.cs
//
// This file contains the implementations of the ClientSearch class.
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
	/// Summary description for ClientSearch.
	/// </summary>
	public class ClientSearch : Microsoft.ApplicationBlocks.UIProcess.WindowsFormView
	{
		private System.Windows.Forms.LinkLabel linkLabel1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ClientSearch()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			throw new ApplicationException("This has not been implemented yet!");
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
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(80, 224);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.TabIndex = 0;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Help";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// ClientSearch
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.linkLabel1);
			this.Name = "ClientSearch";
			this.Text = "ClientSearch";
			this.ResumeLayout(false);

		}
		#endregion

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			((InsuranceClientManagementController)Controller).ShowHelp();
		}

	}
}
