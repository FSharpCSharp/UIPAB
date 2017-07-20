//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// welcome.aspx.cs
//
// This file contains the implementations of the welcome code behind class.
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
	/// <summary>
	/// Summary description for welcome.
	/// </summary>
	public class welcome : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.LinkButton resumeButton;
        protected System.Web.UI.WebControls.LinkButton startButton;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
            if( !Page.IsPostBack )
            {
                //  create a CartTask object; Task object allow us to package
                //  the Task-Logon correlation code 
                CartTask task = new CartTask( Page.User.Identity.Name );
				
                if( task.Get() == Guid.Empty )
                    startButton.Text = "Start to a new buy process";
                else
                    startButton.Text = "Continue the existing buy process";
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
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void startButton_Click(object sender, System.EventArgs e)
        {
            //  create a CartTask object; Task object allow us to package
            //  the Task-Logon correlation code 
            CartTask task = new CartTask( Page.User.Identity.Name );
				
            //  ask UIPManager to Start Task--that is, 
            //  Send us to a new NavGraph and initiate a new Task...or use a known Task..in that new NavGraph
            UIPManager.StartNavigationTask ( "Shopping", task );
        }
	}
}
