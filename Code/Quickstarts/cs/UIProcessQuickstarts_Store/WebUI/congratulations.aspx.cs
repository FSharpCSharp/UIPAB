//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// congratulations.aspx.cs
//
// This file contains the implementations of the congratulations code behind class.
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
	public class congratulations : WebFormView
	{
		protected System.Web.UI.WebControls.LinkButton catalogButton;
        protected System.Web.UI.WebControls.LinkButton surveyButton;
		protected System.Web.UI.WebControls.LinkButton logOffButton;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
		}

		private void logOffButton_Click(object sender, System.EventArgs e)
		{
			FormsAuthentication.SignOut();
            StoreControllerNavGraph.StopShopping();
		}

		private void catalogButton_Click(object sender, System.EventArgs e)
		{
			StoreControllerNavGraph.ResumeShopping();
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
			this.catalogButton.Click += new System.EventHandler(this.catalogButton_Click);
			this.logOffButton.Click += new System.EventHandler(this.logOffButton_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		#region UIPManager Plumbing
		private StoreControllerNavGraph StoreControllerNavGraph
		{
			get{ return (StoreControllerNavGraph)Controller; }
		}
		#endregion
	}
}
