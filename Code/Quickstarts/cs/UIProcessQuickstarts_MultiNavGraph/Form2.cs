//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// Form2.cs
//
// This file contains the implementations of the From2 class.
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
	/// This class is a view sample
	/// </summary>
	public class Form2 : WindowsFormView
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnPrevious;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form2()
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnPrevious = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(392, 112);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(136, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 24);
			this.label1.TabIndex = 4;
			this.label1.Text = "You are in the view \"form2\"";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnPrevious);
			this.groupBox2.Controls.Add(this.btnNext);
			this.groupBox2.Location = new System.Drawing.Point(16, 136);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(392, 48);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			// 
			// btnPrevious
			// 
			this.btnPrevious.Location = new System.Drawing.Point(224, 16);
			this.btnPrevious.Name = "btnPrevious";
			this.btnPrevious.TabIndex = 3;
			this.btnPrevious.Text = "goto form1";
			this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(304, 16);
			this.btnNext.Name = "btnNext";
			this.btnNext.TabIndex = 2;
			this.btnNext.Text = "goto form3";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// Form2
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(424, 197);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "Form2";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form2, NavGraph A";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnNext_Click(object sender, System.EventArgs e)
		{			
			((DemoController1)Controller).Form2btnNext();

		}

		private void btnPrevious_Click(object sender, System.EventArgs e)
		{
			((DemoController1)Controller).Form2btnPrevious();
		}
	}
}
