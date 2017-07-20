//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// genericError.aspx.cs
//
// This file contains the implementations of the genericError code behind class.
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
using System.Diagnostics;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Microsoft.ApplicationBlocks.UIProcess;

namespace UIProcessQuickstarts_Store.WebUI
{
	public class genericError : Page
	{
        protected System.Web.UI.WebControls.Label errorLabel;
		protected System.Web.UI.WebControls.LinkButton backButton;

		private void Page_Load(object sender, System.EventArgs e)
		{
            if( !Page.IsPostBack )
            {
                Exception exception = (Exception)Session["UnhandledException"];
                Session.Remove("UnhandledException");
                                 
                string errMessage = "";
                for( Exception tempException = exception; tempException != null ; tempException = tempException.InnerException )
                {
                    errMessage += tempException.Message + "<br><br>";
                }

				errorLabel.Text = errMessage + "<br>" + "You should be sure UIP database scripts was executed over the sql server";
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
			this.backButton.Click += new System.EventHandler(this.backButton_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

        private void backButton_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("logon.aspx");
        }
	}
}
