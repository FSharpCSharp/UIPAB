//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// cart.cs
//
// This file contains the implementations of the cart class.
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
using System.Data;

namespace UIProcessQuickstarts_Store.WinUI
{
	public class cart : WindowsFormControlView
	{
		private System.Windows.Forms.DataGrid cartGrid;
		private System.Windows.Forms.Label cartLabel;
		private System.Windows.Forms.Button catalogButton;
		private System.Windows.Forms.Button checkoutButton;
        private System.Windows.Forms.Button continueButton;
		private System.Windows.Forms.LinkLabel lnkShowHelp;
		private System.Windows.Forms.Panel buttonPanel;
		private CartDS cartDS;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public cart()
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
			this.catalogButton = new System.Windows.Forms.Button();
			this.cartGrid = new System.Windows.Forms.DataGrid();
			this.cartLabel = new System.Windows.Forms.Label();
			this.checkoutButton = new System.Windows.Forms.Button();
			this.continueButton = new System.Windows.Forms.Button();
			this.lnkShowHelp = new System.Windows.Forms.LinkLabel();
			this.buttonPanel = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.cartGrid)).BeginInit();
			this.buttonPanel.SuspendLayout();
			this.SuspendLayout();
			//
			// catalogButton
			//
			this.catalogButton.Location = new System.Drawing.Point(384, 16);
			this.catalogButton.Name = "catalogButton";
			this.catalogButton.Size = new System.Drawing.Size(96, 24);
			this.catalogButton.TabIndex = 1;
			this.catalogButton.Text = "Browse catalog";
			this.catalogButton.Click += new System.EventHandler(this.browseCatalogButton_Click);
			//
			// cartGrid
			//
			this.cartGrid.DataMember = "";
			this.cartGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cartGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.cartGrid.Location = new System.Drawing.Point(0, 64);
			this.cartGrid.Name = "cartGrid";
			this.cartGrid.Size = new System.Drawing.Size(488, 205);
			this.cartGrid.TabIndex = 2;
			//
			// cartLabel
			//
			this.cartLabel.Location = new System.Drawing.Point(8, 32);
			this.cartLabel.Name = "cartLabel";
			this.cartLabel.Size = new System.Drawing.Size(72, 16);
			this.cartLabel.TabIndex = 3;
			this.cartLabel.Text = "Your cart:";
			//
			// checkoutButton
			//
			this.checkoutButton.Location = new System.Drawing.Point(272, 16);
			this.checkoutButton.Name = "checkoutButton";
			this.checkoutButton.Size = new System.Drawing.Size(96, 24);
			this.checkoutButton.TabIndex = 4;
			this.checkoutButton.Text = "Checkout order";
			this.checkoutButton.Click += new System.EventHandler(this.checkoutButton_Click);
			//
			// continueButton
			//
			this.continueButton.Location = new System.Drawing.Point(160, 16);
			this.continueButton.Name = "continueButton";
			this.continueButton.Size = new System.Drawing.Size(96, 24);
			this.continueButton.TabIndex = 5;
			this.continueButton.Text = "Continue later";
			this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
			//
			// lnkShowHelp
			//
			this.lnkShowHelp.Location = new System.Drawing.Point(8, 0);
			this.lnkShowHelp.Name = "lnkShowHelp";
			this.lnkShowHelp.Size = new System.Drawing.Size(56, 16);
			this.lnkShowHelp.TabIndex = 6;
			this.lnkShowHelp.TabStop = true;
			this.lnkShowHelp.Text = "Help";
			this.lnkShowHelp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lnkShowHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowHelp_LinkClicked);
			//
			// buttonPanel
			//
			this.buttonPanel.Controls.Add(this.lnkShowHelp);
			this.buttonPanel.Controls.Add(this.continueButton);
			this.buttonPanel.Controls.Add(this.checkoutButton);
			this.buttonPanel.Controls.Add(this.catalogButton);
			this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonPanel.Location = new System.Drawing.Point(0, 0);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.Size = new System.Drawing.Size(488, 64);
			this.buttonPanel.TabIndex = 7;
			//
			// cart
			//
			this.Controls.Add(this.cartGrid);
			this.Controls.Add(this.buttonPanel);
			this.Name = "cart";
			this.Size = new System.Drawing.Size(488, 269);
			this.Load += new System.EventHandler(this.cart_Load);
			((System.ComponentModel.ISupportInitialize)(this.cartGrid)).EndInit();
			this.buttonPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void cart_Load(object sender, System.EventArgs e)
		{
		}

		private void browseCatalogButton_Click(object sender, System.EventArgs e)
		{
            StoreControllerHostedControl.ResumeShopping();
		}

		private void checkoutButton_Click(object sender, System.EventArgs e)
		{
            StoreControllerHostedControl.CheckoutOrder();
		}

        private void continueButton_Click(object sender, System.EventArgs e)
        {
            StoreControllerHostedControl.StopShopping();
            Application.Exit();
        }

		private void lnkShowHelp_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			StoreControllerHostedControl.ShowStoreHelp();
		}

        #region UIPManager Plumbing
        private StoreControllerHostedControl StoreControllerHostedControl
        {
            get{ return (StoreControllerHostedControl)this.Controller; }
        }

		public override void Initialize(TaskArgumentsHolder args, ViewSettings settings)
		{
			
			cartDS = StoreControllerHostedControl.GetCart();
			cartDS.CartItems.RowChanging += new DataRowChangeEventHandler(OnRowChanged);
			cartDS.CartItems.RowDeleted += new DataRowChangeEventHandler(OnRowDeleted);
			DataView view = cartDS.CartItems.DefaultView;
			view.AllowNew = false;
			this.cartGrid.DataSource = cartDS;
			this.cartGrid.DataMember = "cart_details";
			DataGridTableStyle tableStyle = new DataGridTableStyle();
			tableStyle.MappingName = "cart_details";

			PropertyDescriptorCollection descriptors = this.BindingContext[cartDS, "cart_details"].GetItemProperties();

			DataGridColumnStyle quantity = new DataGridTextBoxColumn(descriptors["Quantity"]);
			quantity.MappingName = "Quantity";
			quantity.ReadOnly = false;
			quantity.HeaderText = "Quantity";
			tableStyle.GridColumnStyles.Add(quantity);

			DataGridColumnStyle productId = new DataGridTextBoxColumn(descriptors["ProductID"]);
			productId.MappingName = "ProductID";
			productId.HeaderText = "Product ID";
			productId.ReadOnly = true;
			tableStyle.GridColumnStyles.Add(productId);
			
			DataGridColumnStyle modelName = new DataGridTextBoxColumn(descriptors["ModelName"]);
			modelName.MappingName = "ModelName";
			modelName.HeaderText = "Model Name";
			modelName.ReadOnly = true;
			tableStyle.GridColumnStyles.Add(modelName);

			DataGridColumnStyle unitCost = new DataGridTextBoxColumn(descriptors["UnitCost"], "c");
			unitCost.MappingName = "UnitCost";
			unitCost.HeaderText = "Unit Cost";
			unitCost.ReadOnly = true;
			tableStyle.GridColumnStyles.Add(unitCost);

			this.cartGrid.TableStyles.Add(tableStyle);
			checkoutButton.Enabled = ItemCount > 0;
		}

		#endregion

		public int ItemCount
		{
			get { return cartDS.CartItems.Rows.Count; }
		}

		private void OnRowChanged(object sender, DataRowChangeEventArgs args)
		{
			if (args.Action == DataRowAction.Add)
				checkoutButton.Enabled = true;
		}

		private void OnRowDeleted(object sender, DataRowChangeEventArgs args)
		{
			if(args.Action == DataRowAction.Delete && ItemCount == 0)
				checkoutButton.Enabled = false;
		}
	}
}
