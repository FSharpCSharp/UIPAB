//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// browsecatalog.aspx.cs
//
// This file contains the implementations of the browscatalog code behind class.
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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Microsoft.ApplicationBlocks.UIProcess;

namespace UIProcessQuickstarts_Store.WebUI
{
	public class browsecatalog1 : Microsoft.ApplicationBlocks.UIProcess.WebFormView
	{
		protected System.Web.UI.WebControls.DataGrid catalogGrid;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
            if( !Page.IsPostBack )
				FillCatalogRepeater();	//  Populate Catalog repeater			
		}


		private void FillCatalogRepeater() 
		{
			catalogGrid.DataSource = StoreControllerNavGraph.GetCatalogProducts().Products;
			catalogGrid.DataBind();
		}


		private void catalogGrid_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "AddItem")
			{
				int productID = (int)catalogGrid.DataKeys[ e.Item.ItemIndex ];  
				
				//  OK, there's something there...add it to cart
				StoreControllerNavGraph.AddToCart(productID, 1);
			}
			
		}


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.catalogGrid.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.catalogGrid_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		#region UIPManager Plumbing
		private StoreControllerNavGraph StoreControllerNavGraph
		{
			get{ return (StoreControllerNavGraph)this.Controller; }
		}
		#endregion
	}
}
