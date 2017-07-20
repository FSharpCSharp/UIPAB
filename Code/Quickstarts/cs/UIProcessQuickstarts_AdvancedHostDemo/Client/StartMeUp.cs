//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// StartMeUp.cs
//
// This file contains the implementations of the StartMeUp class.
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

namespace Client
{
	/// <summary>
	/// Summary description for StartMeUp.
	/// </summary>
	public class StartMeUp : System.Windows.Forms.Form, IShutdownUIP
	{
		private ITask _startingTask;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public StartMeUp()
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
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			// button1
			//
			this.button1.Location = new System.Drawing.Point(64, 104);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(168, 24);
			this.button1.TabIndex = 0;
			this.button1.Text = "Start Hosted Control Demo";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			//
			// StartMeUp
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.button1);
			this.Name = "StartMeUp";
			this.Text = "StartMeUp";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.StartMeUp_Closing);
			this.Load += new System.EventHandler(this.StartMeUp_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			UIPManager.RegisterShutdown(this);
			this.Visible = false;
			_startingTask = new TestTask();
			UIPManager.StartUserControlsTask("demo",_startingTask);
		}

		private void StartMeUp_Load(object sender, System.EventArgs e)
		{

		}

		private void StartMeUp_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}

		public ITask StartingTask
		{
			get
			{
				return _startingTask;
			}
		}
		#region IShutdownUIP Members

		public void Shutdown()
		{
			this.Visible = true;
		}

		#endregion
	}
}
