//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// Form4.cs
//
// This file contains the implementations of the From4 class.
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
	public class Form4 : WindowsFormView
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnNext;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form4()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.Load +=new EventHandler(Form4_Load);
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
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnNext = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(392, 112);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(360, 64);
			this.label1.TabIndex = 10;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 9;
			this.label2.Text = "State details:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnNext);
			this.groupBox2.Location = new System.Drawing.Point(16, 136);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(392, 48);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(304, 16);
			this.btnNext.Name = "btnNext";
			this.btnNext.TabIndex = 4;
			this.btnNext.Text = "goto form5";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// Form4
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(424, 197);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "Form4";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form4, NavGraph B";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			((DemoController2)Controller).Form4btnNext( "Form4btnNext" );
		}

		private void Form4_Load(object sender, EventArgs e)
		{
			// Show the info stored into the state
			label1.Text = "";
			label1.Text += "TaskId = " + ((State2)Controller.State).TaskId + Environment.NewLine;
			label1.Text += "NavigationGraph = " + ((State2)Controller.State).NavigationGraph + Environment.NewLine;
			label1.Text += "PreviousTaskID = " + ((State2)Controller.State).PreviousTaskID + Environment.NewLine;
			label1.Text += "PreviousNavGraph = " + ((State2)Controller.State).PreviousNavGraph + Environment.NewLine;
		}
	}
}
