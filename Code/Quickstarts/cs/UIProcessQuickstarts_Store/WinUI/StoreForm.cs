//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// StoreForm.cs
//
// This file contains the implementations of the StoreForm class.
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
	/// Summary description for StoreForm.
	/// </summary>
	public class StoreForm : WindowsFormView
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private browsecatalog catalog;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		private cart shoppingCart;

		public StoreForm()
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
			this.catalog = new UIProcessQuickstarts_Store.WinUI.browsecatalog();
			this.shoppingCart = new UIProcessQuickstarts_Store.WinUI.cart();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// catalog
			// 
			this.catalog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.catalog.Location = new System.Drawing.Point(0, 0);
			this.catalog.Name = "catalog";
			this.catalog.Size = new System.Drawing.Size(500, 486);
			this.catalog.TabIndex = 0;
			// 
			// shoppingCart
			// 
			this.shoppingCart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.shoppingCart.Location = new System.Drawing.Point(0, 0);
			this.shoppingCart.Name = "shoppingCart";
			this.shoppingCart.Size = new System.Drawing.Size(508, 486);
			this.shoppingCart.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.catalog);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(500, 486);
			this.panel1.TabIndex = 2;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.shoppingCart);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(500, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(508, 486);
			this.panel2.TabIndex = 3;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(500, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(8, 486);
			this.splitter1.TabIndex = 4;
			this.splitter1.TabStop = false;
			// 
			// StoreForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1008, 486);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "StoreForm";
			this.Text = "Store";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

	}
}
