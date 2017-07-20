//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// browsecatalog.cs
//
// This file contains the implementations of the browsecatalog class.
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
	public class browsecatalog : WindowsFormControlView
	{
		private System.Windows.Forms.Label cartLabel;
		private System.Windows.Forms.DataGrid catalogGrid;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.LinkLabel lnkShowHelp;
		private System.Windows.Forms.Panel buttonPanel;
        

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public browsecatalog()
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
			this.addButton = new System.Windows.Forms.Button();
			this.catalogGrid = new System.Windows.Forms.DataGrid();
			this.cartLabel = new System.Windows.Forms.Label();
			this.lnkShowHelp = new System.Windows.Forms.LinkLabel();
			this.buttonPanel = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.catalogGrid)).BeginInit();
			this.buttonPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(384, 16);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(96, 24);
			this.addButton.TabIndex = 1;
			this.addButton.Text = "Add to cart";
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// catalogGrid
			// 
			this.catalogGrid.DataMember = "";
			this.catalogGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.catalogGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.catalogGrid.Location = new System.Drawing.Point(0, 64);
			this.catalogGrid.Name = "catalogGrid";
			this.catalogGrid.Size = new System.Drawing.Size(488, 205);
			this.catalogGrid.TabIndex = 2;
			// 
			// cartLabel
			// 
			this.cartLabel.Location = new System.Drawing.Point(8, 32);
			this.cartLabel.Name = "cartLabel";
			this.cartLabel.Size = new System.Drawing.Size(72, 16);
			this.cartLabel.TabIndex = 3;
			this.cartLabel.Text = "Catalog:";
			// 
			// lnkShowHelp
			// 
			this.lnkShowHelp.Location = new System.Drawing.Point(8, 8);
			this.lnkShowHelp.Name = "lnkShowHelp";
			this.lnkShowHelp.Size = new System.Drawing.Size(56, 16);
			this.lnkShowHelp.TabIndex = 7;
			this.lnkShowHelp.TabStop = true;
			this.lnkShowHelp.Text = "Help";
			this.lnkShowHelp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lnkShowHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowHelp_LinkClicked);
			// 
			// buttonPanel
			// 
			this.buttonPanel.Controls.Add(this.lnkShowHelp);
			this.buttonPanel.Controls.Add(this.cartLabel);
			this.buttonPanel.Controls.Add(this.addButton);
			this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonPanel.Location = new System.Drawing.Point(0, 0);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.Size = new System.Drawing.Size(488, 64);
			this.buttonPanel.TabIndex = 8;
			// 
			// browsecatalog
			// 
			this.Controls.Add(this.catalogGrid);
			this.Controls.Add(this.buttonPanel);
			this.Name = "browsecatalog";
			this.Size = new System.Drawing.Size(488, 269);
			this.Load += new System.EventHandler(this.browsecatalog_Load);
			((System.ComponentModel.ISupportInitialize)(this.catalogGrid)).EndInit();
			this.buttonPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void browsecatalog_Load(object sender, System.EventArgs e)
		{
			if (!this.DesignMode) 
			{
				
				
				
			}
		}

		public override void Initialize(TaskArgumentsHolder args, ViewSettings settings)
		{
			ProductDS products = StoreControllerHostedControl.GetCatalogProducts();
			catalogGrid.DataSource = products;
			catalogGrid.DataMember = "product";
			DataGridTableStyle style = new DataGridTableStyle();
			style.ReadOnly = true;
			style.MappingName = "product";

			PropertyDescriptorCollection descriptors = this.BindingContext[products, "product"].GetItemProperties();

			DataGridColumnStyle productId = new DataGridTextBoxColumn(descriptors["ProductID"]);
			productId.MappingName = "ProductID";
			productId.HeaderText = "Product ID";
			productId.ReadOnly = true;
			style.GridColumnStyles.Add(productId);

			DataGridColumnStyle categoryID = new DataGridTextBoxColumn(descriptors["CategoryID"]);
			categoryID.MappingName = "CategoryID";
			categoryID.HeaderText = "Category ID";
			categoryID.ReadOnly = true;
			style.GridColumnStyles.Add(categoryID);

			DataGridColumnStyle modelNumber = new DataGridTextBoxColumn(descriptors["ModelNumber"]);
			modelNumber.MappingName = "ModelNumber";
			modelNumber.HeaderText = "Model Number";
			modelNumber.ReadOnly = true;
			style.GridColumnStyles.Add(modelNumber);
			
			DataGridColumnStyle modelName = new DataGridTextBoxColumn(descriptors["ModelName"]);
			modelName.MappingName = "ModelName";
			modelName.HeaderText = "Model Name";
			modelName.ReadOnly = true;
			style.GridColumnStyles.Add(modelName);

			DataGridColumnStyle unitCost = new DataGridTextBoxColumn(descriptors["UnitCost"], "c");
			unitCost.MappingName = "UnitCost";
			unitCost.HeaderText = "Unit Cost";
			unitCost.ReadOnly = true;
			style.GridColumnStyles.Add(unitCost);

			DataGridColumnStyle description = new DataGridTextBoxColumn(descriptors["Description"]);
			description.MappingName = "Description";
			description.HeaderText = "Description";
			description.ReadOnly = true;
			style.GridColumnStyles.Add(description);

			catalogGrid.TableStyles.Add(style);
		}



		private void addButton_Click(object sender, System.EventArgs e)
		{
            StoreControllerHostedControl.AddToCart( (int)catalogGrid[ catalogGrid.CurrentRowIndex, 0 ], 1 );
		}


		private void lnkShowHelp_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			StoreControllerHostedControl.ShowShoppingHelp();
		}

        #region UIPManager Plumbing
        private StoreControllerHostedControl StoreControllerHostedControl
        {
            get{ return (StoreControllerHostedControl)this.Controller; }
        }
        #endregion
	}
}
