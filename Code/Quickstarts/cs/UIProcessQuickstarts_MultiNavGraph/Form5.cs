//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// Form5.cs
//
// This file contains the implementations of the From5 class.
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
	public class Form5 : WindowsFormView
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtState;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnPrevious;
		private System.Windows.Forms.Button btnNext;
		private System.ComponentModel.Container components = null;

		public Form5()
		{
			InitializeComponent();
			this.Load +=new EventHandler(Form5_Load);
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
			this.txtState = new System.Windows.Forms.TextBox();
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
			this.groupBox1.Controls.Add(this.txtState);
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(392, 112);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 16);
			this.label1.TabIndex = 8;
			this.label1.Text = "Enter some state info:";
			// 
			// txtState
			// 
			this.txtState.Location = new System.Drawing.Point(152, 48);
			this.txtState.Name = "txtState";
			this.txtState.Size = new System.Drawing.Size(200, 20);
			this.txtState.TabIndex = 7;
			this.txtState.Text = "Put Some State Here.";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnPrevious);
			this.groupBox2.Controls.Add(this.btnNext);
			this.groupBox2.Location = new System.Drawing.Point(16, 136);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(392, 48);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			// 
			// btnPrevious
			// 
			this.btnPrevious.Location = new System.Drawing.Point(184, 16);
			this.btnPrevious.Name = "btnPrevious";
			this.btnPrevious.Size = new System.Drawing.Size(96, 23);
			this.btnPrevious.TabIndex = 6;
			this.btnPrevious.Text = "goto form4";
			this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(288, 16);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(96, 23);
			this.btnNext.TabIndex = 5;
			this.btnNext.Text = "return to navA";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// Form5
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(424, 197);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form5";
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form5, NavGraph B";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			((DemoController2)Controller).Form5btnNext( txtState.Text );
			Close();
		}
		private void btnPrevious_Click(object sender, System.EventArgs e)
		{
			((DemoController2)Controller).Form5btnPrevious();
		}

		private void txtState_TextChanged(object sender, System.EventArgs e)
		{
			// Store the entered info into our state
			if( Controller != null ) 
                Controller.State["someState"] = txtState.Text;		
		}

		private void Form5_Load(object sender, EventArgs e)
		{
			// Restore the textbox value with the value stored into the state
			txtState.Text = (string)Controller.State[ "someState" ];
		}
	}
}
