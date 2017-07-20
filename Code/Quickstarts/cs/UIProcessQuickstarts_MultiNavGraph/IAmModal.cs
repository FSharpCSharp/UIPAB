//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// IAmModal.cs
//
// This file contains the implementations of the IAmModal class.
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

namespace UIProcessQuickstarts_MultiNavGraph
{
	/// <summary>
	/// This class is a modal view sample
	/// </summary>
	public class IAmModal : WindowsFormView
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.Container components = null;

		public IAmModal()
		{
			InitializeComponent();
			this.Load +=new EventHandler(IAmModal_Load);
		}

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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(392, 112);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(368, 80);
			this.label1.TabIndex = 1;
			this.label1.Text = "label1";
			// 
			// IAmModal
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(424, 197);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "IAmModal";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "IAmModal";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void IAmModal_Load(object sender, EventArgs e)
		{
			label1.Text = "State passed from navB: " + Environment.NewLine + Environment.NewLine + (string)Controller.State["previousNavState"];
		}
	}
}
