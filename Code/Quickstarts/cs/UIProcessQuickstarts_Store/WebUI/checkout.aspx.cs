//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// checkout.aspx.cs
//
// This file contains the implementations of the checkout code behind class.
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

using Microsoft.ApplicationBlocks.UIProcess;

namespace UIProcessQuickstarts_Store.WebUI
{
	public class checkout : WebFormView
	{
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.TextBox txtAddr;
		protected System.Web.UI.WebControls.TextBox txtCCNum;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Button btnFinish;

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//  if known customer, try to retrieve cust info and pre-populate form fields
			if ( !Page.IsPostBack )
			{
					ShowCustInfo();
			}
		}

		private void ShowCustInfo()
		{
			CustomerDS.Customer cust = myController.GetCustomerByLogon( Page.User.Identity.Name );
			txtName.Text = cust.FullName;
			txtAddr.Text = cust.EmailAddress;
			txtCCNum.Text = "1111-1111-1111-1111";
		}

		private void btnFinish_Click(object sender, System.EventArgs e)
		{
			myController.CompleteCheckout( txtName.Text, txtAddr.Text, txtCCNum.Text );
		}

		private StoreControllerNavGraph myController
		{
			get { return (StoreControllerNavGraph)Controller; }
		}
	

		#region Web Form Designer generated code

		protected override void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
		private void InitializeComponent()
		{    
			this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
