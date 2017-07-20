//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// cart.aspx.cs
//
// This file contains the implementations of the cart code behind class.
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
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;

using Microsoft.ApplicationBlocks.UIProcess;

namespace UIProcessQuickstarts_Store.WebUI
{
	/// <summary>
	/// Summary description for cart1.
	/// </summary>
	public class cart : WebFormView
	{
        protected System.Web.UI.WebControls.LinkButton checkoutButton;
        protected System.Web.UI.WebControls.LinkButton browseCatalog;
        protected System.Web.UI.WebControls.LinkButton endButton;
        protected System.Web.UI.WebControls.Repeater cartRepeater;

        private void Page_Load(object sender, System.EventArgs e)
        {
            if( !Page.IsPostBack )
            {
                FillCartRepeater(); // Populate Cart repeater
            }
        }

        private void FillCartRepeater() 
        {
            cartRepeater.DataSource = StoreControllerNavGraph.GetCart();
			cartRepeater.DataMember = "cart_details";
            cartRepeater.DataBind();
        }

        private void checkoutButton_Click(object sender, System.EventArgs e)
        {
            StoreControllerNavGraph.CheckoutOrder();
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
		
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
					this.browseCatalog.Click += new System.EventHandler(this.browseCatalog_Click);
					this.checkoutButton.Click += new System.EventHandler(this.checkoutButton_Click);
					this.endButton.Click += new System.EventHandler(this.endButton_Click);
					this.Load += new System.EventHandler(this.Page_Load);

				}
        #endregion

        private void browseCatalog_Click(object sender, System.EventArgs e)
        {
            StoreControllerNavGraph.ResumeShopping();
        }

        private void endButton_Click(object sender, System.EventArgs e)
        {
            FormsAuthentication.SignOut();
            StoreControllerNavGraph.StopShopping();
        }

        #region UIPManager Plumbing
        private StoreControllerNavGraph StoreControllerNavGraph
        {
            get
            { 
                return (StoreControllerNavGraph)this.Controller;
            }
        }
        #endregion
	}
}
