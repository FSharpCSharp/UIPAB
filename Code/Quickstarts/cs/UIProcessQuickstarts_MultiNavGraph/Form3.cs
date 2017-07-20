//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// Form3.cs
//
// This file contains the implementations of the From3 class.
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
	public class Form3 : WindowsFormView
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnShowNavBState;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnPrevious;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnContinueLater;
		private System.Windows.Forms.Button btnCompleteTask;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form3()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.Load +=new EventHandler(Form3_Load);
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
			this.btnShowNavBState = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnContinueLater = new System.Windows.Forms.Button();
			this.btnPrevious = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnCompleteTask = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.btnShowNavBState);
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(392, 112);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(368, 56);
			this.label1.TabIndex = 10;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 9;
			this.label2.Text = "State details:";
			// 
			// btnShowNavBState
			// 
			this.btnShowNavBState.Location = new System.Drawing.Point(200, 13);
			this.btnShowNavBState.Name = "btnShowNavBState";
			this.btnShowNavBState.Size = new System.Drawing.Size(184, 23);
			this.btnShowNavBState.TabIndex = 8;
			this.btnShowNavBState.Text = "show state passed from navB";
			this.btnShowNavBState.Click += new System.EventHandler(this.btnShowNavBState_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnCompleteTask);
			this.groupBox2.Controls.Add(this.btnContinueLater);
			this.groupBox2.Controls.Add(this.btnPrevious);
			this.groupBox2.Controls.Add(this.btnNext);
			this.groupBox2.Location = new System.Drawing.Point(16, 136);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(392, 48);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			// 
			// btnContinueLater
			// 
			this.btnContinueLater.Location = new System.Drawing.Point(104, 16);
			this.btnContinueLater.Name = "btnContinueLater";
			this.btnContinueLater.Size = new System.Drawing.Size(88, 23);
			this.btnContinueLater.TabIndex = 11;
			this.btnContinueLater.Text = "Continue later";
			this.btnContinueLater.Click += new System.EventHandler(this.btnContinueLater_Click);
			// 
			// btnPrevious
			// 
			this.btnPrevious.Location = new System.Drawing.Point(200, 16);
			this.btnPrevious.Name = "btnPrevious";
			this.btnPrevious.Size = new System.Drawing.Size(88, 23);
			this.btnPrevious.TabIndex = 10;
			this.btnPrevious.Text = "goto form2";
			this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(296, 16);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(88, 23);
			this.btnNext.TabIndex = 9;
			this.btnNext.Text = "GoSub navB";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnCompleteTask
			// 
			this.btnCompleteTask.Location = new System.Drawing.Point(8, 16);
			this.btnCompleteTask.Name = "btnCompleteTask";
			this.btnCompleteTask.Size = new System.Drawing.Size(88, 23);
			this.btnCompleteTask.TabIndex = 12;
			this.btnCompleteTask.Text = "Complete Task";
			this.btnCompleteTask.Click += new System.EventHandler(this.btnCompleteTask_Click);
			// 
			// Form3
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(424, 197);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "Form3";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form3, NavGraph A";
			this.Activated += new System.EventHandler(this.Form3_Activated);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		private void btnNext_Click(object sender, System.EventArgs e)
		{
			((DemoController1)Controller).Form3btnNext();	
		}		
		
		private void btnPrevious_Click(object sender, System.EventArgs e)
		{
			((DemoController1)Controller).Form3btnPrevious();	
		}

		private void Form3_Load(object sender, EventArgs e)
		{
		}

		private void btnShowNavBState_Click(object sender, System.EventArgs e)
		{
			((DemoController1)Controller).Form3ShowPreviousNavState();
		}

        private void btnContinueLater_Click(object sender, System.EventArgs e)
        {
			((DemoController1)Controller).EndNavA();
            Application.Exit();
        }

        private void Form3_Activated(object sender, System.EventArgs e)
        {
            // Show the info stored into the state
			label1.Text = "";
            label1.Text += "TaskId = " + ((State1)Controller.State).TaskId + Environment.NewLine;
            label1.Text += "NavigationGraph = " + ((State1)Controller.State).NavigationGraph + Environment.NewLine;
            label1.Text += "PreviousTaskID = " + ((State1)Controller.State).PreviousTaskID + Environment.NewLine;
            label1.Text += "PreviousNavGraph = " + ((State1)Controller.State).PreviousNavGraph + Environment.NewLine;
        }

		private void btnCompleteTask_Click(object sender, System.EventArgs e)
		{
			((DemoController1)Controller).CompleteNavA();
			 Application.Exit();
		}
	}
}
