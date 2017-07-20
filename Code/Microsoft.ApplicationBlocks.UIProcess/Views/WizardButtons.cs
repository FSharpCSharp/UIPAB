//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// WizardButtons.cs
//
// This file contains the implementations of the WizardButtons class.
//
// For more information see the User Interface Process Application Block Implementation Overview. 
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
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// WizardButtons encapsulates the Cancel, Back, Next, and Finish user interface elements.
	/// </summary>
	public class WizardButtons : System.Windows.Forms.UserControl
	{		 
		/// <summary>
		/// Event for canceling the wizard.
		/// </summary>
		public event CancelEventHandler OnCancel;

		/// <summary>
		/// Event for finishing the wizard.
		/// </summary>
		public event FinishEventHandler OnFinish;

		/// <summary>
		/// Event for back wizard functionality.
		/// </summary>
		public event BackEventHandler OnBack;

		/// <summary>
		/// Event for next wizard functionality.
		/// </summary>
		public event NextEventHandler OnNext;

		/// <summary>
		/// Delegate for handling cancel events.
		/// </summary>
		///	<param name="sender">The source of the event.</param>
		/// <param name="e">An EventArgs that contains the event data.</param>
		public delegate void CancelEventHandler(object sender, EventArgs e);

		/// <summary>
		/// Delegate for handling finish events.
		/// </summary>
		///	<param name="sender">The source of the event.</param>
		/// <param name="e">An EventArgs that contains the event data.</param>
		public delegate void FinishEventHandler(object sender, EventArgs e);

		/// <summary>
		/// Delegate for handling back events.
		/// </summary>
		///	<param name="sender">The source of the event.</param>
		/// <param name="e">An EventArgs that contains the event data.</param>
		public delegate void BackEventHandler(object sender, EventArgs e);

		/// <summary>
		/// Delegate for handling next events.
		/// </summary>
		///	<param name="sender">The source of the event.</param>
		/// <param name="e">An EventArgs that contains the event data.</param>
		public delegate void NextEventHandler(object sender, EventArgs e);

		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button backBtn;
		private System.Windows.Forms.Button nextBtn;
		private System.Windows.Forms.Button finishBtn;
	

		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Constructor.
		/// </summary>
		public WizardButtons()
		{
			InitializeComponent();			
		}

		

		/// <summary> 
		/// Cleans up any resources being used.
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for designer support. Do not use the code editor to modify 
		/// the contents of this method.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(WizardButtons));
			this.cancelBtn = new System.Windows.Forms.Button();
			this.backBtn = new System.Windows.Forms.Button();
			this.nextBtn = new System.Windows.Forms.Button();
			this.finishBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cancelBtn
			// 
			this.cancelBtn.AccessibleDescription = resources.GetString("cancelBtn.AccessibleDescription");
			this.cancelBtn.AccessibleName = resources.GetString("cancelBtn.AccessibleName");
			this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cancelBtn.Anchor")));
			this.cancelBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancelBtn.BackgroundImage")));
			this.cancelBtn.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cancelBtn.Dock")));
			this.cancelBtn.Enabled = ((bool)(resources.GetObject("cancelBtn.Enabled")));
			this.cancelBtn.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cancelBtn.FlatStyle")));
			this.cancelBtn.Font = ((System.Drawing.Font)(resources.GetObject("cancelBtn.Font")));
			this.cancelBtn.Image = ((System.Drawing.Image)(resources.GetObject("cancelBtn.Image")));
			this.cancelBtn.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cancelBtn.ImageAlign")));
			this.cancelBtn.ImageIndex = ((int)(resources.GetObject("cancelBtn.ImageIndex")));
			this.cancelBtn.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cancelBtn.ImeMode")));
			this.cancelBtn.Location = ((System.Drawing.Point)(resources.GetObject("cancelBtn.Location")));
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cancelBtn.RightToLeft")));
			this.cancelBtn.Size = ((System.Drawing.Size)(resources.GetObject("cancelBtn.Size")));
			this.cancelBtn.TabIndex = ((int)(resources.GetObject("cancelBtn.TabIndex")));
			this.cancelBtn.Text = resources.GetString("cancelBtn.Text");
			this.cancelBtn.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cancelBtn.TextAlign")));
			this.cancelBtn.Visible = ((bool)(resources.GetObject("cancelBtn.Visible")));
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// backBtn
			// 
			this.backBtn.AccessibleDescription = resources.GetString("backBtn.AccessibleDescription");
			this.backBtn.AccessibleName = resources.GetString("backBtn.AccessibleName");
			this.backBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("backBtn.Anchor")));
			this.backBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backBtn.BackgroundImage")));
			this.backBtn.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("backBtn.Dock")));
			this.backBtn.Enabled = ((bool)(resources.GetObject("backBtn.Enabled")));
			this.backBtn.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("backBtn.FlatStyle")));
			this.backBtn.Font = ((System.Drawing.Font)(resources.GetObject("backBtn.Font")));
			this.backBtn.Image = ((System.Drawing.Image)(resources.GetObject("backBtn.Image")));
			this.backBtn.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("backBtn.ImageAlign")));
			this.backBtn.ImageIndex = ((int)(resources.GetObject("backBtn.ImageIndex")));
			this.backBtn.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("backBtn.ImeMode")));
			this.backBtn.Location = ((System.Drawing.Point)(resources.GetObject("backBtn.Location")));
			this.backBtn.Name = "backBtn";
			this.backBtn.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("backBtn.RightToLeft")));
			this.backBtn.Size = ((System.Drawing.Size)(resources.GetObject("backBtn.Size")));
			this.backBtn.TabIndex = ((int)(resources.GetObject("backBtn.TabIndex")));
			this.backBtn.Text = resources.GetString("backBtn.Text");
			this.backBtn.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("backBtn.TextAlign")));
			this.backBtn.Visible = ((bool)(resources.GetObject("backBtn.Visible")));
			this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
			// 
			// nextBtn
			// 
			this.nextBtn.AccessibleDescription = resources.GetString("nextBtn.AccessibleDescription");
			this.nextBtn.AccessibleName = resources.GetString("nextBtn.AccessibleName");
			this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("nextBtn.Anchor")));
			this.nextBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("nextBtn.BackgroundImage")));
			this.nextBtn.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("nextBtn.Dock")));
			this.nextBtn.Enabled = ((bool)(resources.GetObject("nextBtn.Enabled")));
			this.nextBtn.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("nextBtn.FlatStyle")));
			this.nextBtn.Font = ((System.Drawing.Font)(resources.GetObject("nextBtn.Font")));
			this.nextBtn.Image = ((System.Drawing.Image)(resources.GetObject("nextBtn.Image")));
			this.nextBtn.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("nextBtn.ImageAlign")));
			this.nextBtn.ImageIndex = ((int)(resources.GetObject("nextBtn.ImageIndex")));
			this.nextBtn.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("nextBtn.ImeMode")));
			this.nextBtn.Location = ((System.Drawing.Point)(resources.GetObject("nextBtn.Location")));
			this.nextBtn.Name = "nextBtn";
			this.nextBtn.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("nextBtn.RightToLeft")));
			this.nextBtn.Size = ((System.Drawing.Size)(resources.GetObject("nextBtn.Size")));
			this.nextBtn.TabIndex = ((int)(resources.GetObject("nextBtn.TabIndex")));
			this.nextBtn.Text = resources.GetString("nextBtn.Text");
			this.nextBtn.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("nextBtn.TextAlign")));
			this.nextBtn.Visible = ((bool)(resources.GetObject("nextBtn.Visible")));
			this.nextBtn.Click += new System.EventHandler(this.nextButton_Click);
			// 
			// finishBtn
			// 
			this.finishBtn.AccessibleDescription = resources.GetString("finishBtn.AccessibleDescription");
			this.finishBtn.AccessibleName = resources.GetString("finishBtn.AccessibleName");
			this.finishBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("finishBtn.Anchor")));
			this.finishBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("finishBtn.BackgroundImage")));
			this.finishBtn.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("finishBtn.Dock")));
			this.finishBtn.Enabled = ((bool)(resources.GetObject("finishBtn.Enabled")));
			this.finishBtn.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("finishBtn.FlatStyle")));
			this.finishBtn.Font = ((System.Drawing.Font)(resources.GetObject("finishBtn.Font")));
			this.finishBtn.Image = ((System.Drawing.Image)(resources.GetObject("finishBtn.Image")));
			this.finishBtn.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("finishBtn.ImageAlign")));
			this.finishBtn.ImageIndex = ((int)(resources.GetObject("finishBtn.ImageIndex")));
			this.finishBtn.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("finishBtn.ImeMode")));
			this.finishBtn.Location = ((System.Drawing.Point)(resources.GetObject("finishBtn.Location")));
			this.finishBtn.Name = "finishBtn";
			this.finishBtn.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("finishBtn.RightToLeft")));
			this.finishBtn.Size = ((System.Drawing.Size)(resources.GetObject("finishBtn.Size")));
			this.finishBtn.TabIndex = ((int)(resources.GetObject("finishBtn.TabIndex")));
			this.finishBtn.Text = resources.GetString("finishBtn.Text");
			this.finishBtn.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("finishBtn.TextAlign")));
			this.finishBtn.Visible = ((bool)(resources.GetObject("finishBtn.Visible")));
			this.finishBtn.Click += new System.EventHandler(this.finishBtn_Click);
			// 
			// WizardButtons
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.Controls.Add(this.finishBtn);
			this.Controls.Add(this.nextBtn);
			this.Controls.Add(this.backBtn);
			this.Controls.Add(this.cancelBtn);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.Name = "WizardButtons";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.Size = ((System.Drawing.Size)(resources.GetObject("$this.Size")));
			this.ResumeLayout(false);

		}
		#endregion

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			OnCancel(this,e);
		}

		private void backBtn_Click(object sender, EventArgs e)
		{
			OnBack(this, e);
		}

		private void nextButton_Click(object sender, EventArgs e)
		{
			OnNext(this, e);
		}

		private void finishBtn_Click(object sender, EventArgs e)
		{
			OnFinish(this, e);
		}

		/// <summary>
		/// Property that enables or disables the Cancel button.
		/// </summary>
		public bool CancelEnabled
		{
			get { return cancelBtn.Enabled; }
			set { cancelBtn.Enabled = value; }
		}

		/// <summary>
		/// Property that enables or disables the Back button.
		/// </summary>
		public bool BackEnabled
		{
			get { return backBtn.Enabled; }
			set { backBtn.Enabled = value; }
		}

		/// <summary>
		/// Property that enables or disables the Next button.
		/// </summary>
		public bool NextEnabled
		{
			get { return nextBtn.Enabled; }
			set { nextBtn.Enabled = value; }
		}

		/// <summary>
		/// Property that enables or disables the Finish button.
		/// </summary>
		public bool FinishEnabled
		{
			get { return finishBtn.Enabled; }
			set { finishBtn.Enabled = value; }
		}

	}
}
