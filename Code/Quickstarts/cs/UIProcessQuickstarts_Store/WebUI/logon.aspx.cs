//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// logon.aspx.cs
//
// This file contains the implementations of the logon code behind class.
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
using System.Web.Security;

using Microsoft.ApplicationBlocks.UIProcess;

namespace UIProcessQuickstarts_Store.WebUI
{
	public class Logon : System.Web.UI.Page 
	{
		protected System.Web.UI.WebControls.TextBox emailText;
		protected System.Web.UI.WebControls.Button OkButton;
		protected System.Web.UI.WebControls.Label passwordLabel;
		protected System.Web.UI.WebControls.TextBox passwordText;
		protected System.Web.UI.WebControls.Label emailLabel;
		protected System.Web.UI.WebControls.Label lblCookie;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label errorLabel;
		
		private void Logon_Load(object sender, EventArgs e)
		{
			
		}

		private void OkButton_Click(object sender, System.EventArgs e)
		{
			errorLabel.Visible = false;
			string email = emailText.Text;
			string password = passwordText.Text;
			bool isUserValid = false;

			try
			{
				isUserValid = StoreControllerNavGraph.IsUserValid( email, password );
			}
			catch( Exception ex )
			{
				string err =  "ERROR: " + ex.Message + "<br/>" + ex.StackTrace;
				lblCookie.Text = err;
			}

			//Ask controller if user is valid
			if ( isUserValid ) 
			{
				//  Logon was valid.
				FormsAuthentication.SetAuthCookie( email, false );

                Response.Redirect("welcome.aspx");
			}
			else
				errorLabel.Visible = true; //  logon was not valid.
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
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			this.Load += new System.EventHandler(this.Logon_Load);

		}
		#endregion

	}
}
