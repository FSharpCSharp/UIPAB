//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// MainForm.cs
//
// This file contains the implementations of the MainForm class.
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
using System.Data;
using Microsoft.ApplicationBlocks.UIProcess;

namespace Client
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : WindowsFormView
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel buttonPanel;
		private System.Windows.Forms.Button EditButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.Button bannerButton;

		private PersonTree peopleTree;
		private PersonControl person;
		private bool editing = false;

		private delegate void FinishEditAction();

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.InternalViewName = "Host";

		}


		public override void Initialize(TaskArgumentsHolder args, ViewSettings settings)
		{
			//Demo use of custom attribute of View element in config file
			this.Text = settings.Navigator.GetAttribute("MainFormTitle","");
		}


		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null)
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
			this.peopleTree = new Client.PersonTree();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.person = new Client.PersonControl();
			this.buttonPanel = new System.Windows.Forms.Panel();
			this.bannerButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.EditButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.buttonPanel.SuspendLayout();
			this.SuspendLayout();
			//
			// groupBox1
			//
			this.groupBox1.Controls.Add(this.peopleTree);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 310);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Employees";
			//
			// peopleTree
			//
			this.peopleTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.peopleTree.InternalController = null;
			this.peopleTree.InternalNavigator = null;
			this.peopleTree.InternalViewName = null;
			this.peopleTree.Location = new System.Drawing.Point(3, 16);
			this.peopleTree.Name = "peopleTree";
			this.peopleTree.Size = new System.Drawing.Size(194, 291);
			this.peopleTree.TabIndex = 0;
			//
			// splitter1
			//
			this.splitter1.Location = new System.Drawing.Point(200, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 310);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			//
			// groupBox2
			//
			this.groupBox2.Controls.Add(this.panel1);
			this.groupBox2.Controls.Add(this.buttonPanel);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(203, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(525, 310);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Details";
			//
			// panel1
			//
			this.panel1.Controls.Add(this.person);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(519, 227);
			this.panel1.TabIndex = 1;
			//
			// person
			//
			this.person.InternalController = null;
			this.person.InternalNavigator = null;
			this.person.InternalViewName = null;
			this.person.Location = new System.Drawing.Point(0, 0);
			this.person.Name = "person";
			this.person.Person = null;
			this.person.Size = new System.Drawing.Size(632, 360);
			this.person.TabIndex = 0;
			//
			// buttonPanel
			//
			this.buttonPanel.Controls.Add(this.bannerButton);
			this.buttonPanel.Controls.Add(this.SaveButton);
			this.buttonPanel.Controls.Add(this.Cancel);
			this.buttonPanel.Controls.Add(this.EditButton);
			this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonPanel.Location = new System.Drawing.Point(3, 243);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.Size = new System.Drawing.Size(519, 64);
			this.buttonPanel.TabIndex = 0;
			//
			// bannerButton
			//
			this.bannerButton.Location = new System.Drawing.Point(16, 24);
			this.bannerButton.Name = "bannerButton";
			this.bannerButton.TabIndex = 3;
			this.bannerButton.Text = "Banner";
			this.bannerButton.Click += new System.EventHandler(this.bannerButton_Click);
			//
			// SaveButton
			//
			this.SaveButton.Enabled = false;
			this.SaveButton.Location = new System.Drawing.Point(432, 24);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.TabIndex = 2;
			this.SaveButton.Text = "Save";
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			//
			// Cancel
			//
			this.Cancel.Enabled = false;
			this.Cancel.Location = new System.Drawing.Point(352, 24);
			this.Cancel.Name = "Cancel";
			this.Cancel.TabIndex = 1;
			this.Cancel.Text = "Cancel";
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			//
			// EditButton
			//
			this.EditButton.Location = new System.Drawing.Point(272, 24);
			this.EditButton.Name = "EditButton";
			this.EditButton.TabIndex = 0;
			this.EditButton.Text = "Edit";
			this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
			//
			// MainForm
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(728, 310);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.groupBox1);
			this.Name = "MainForm";
			this.Text = "Hosted Controls";
			this.Closed += new System.EventHandler(this.MainForm_Closed);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.buttonPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void EditButton_Click(object sender, System.EventArgs e)
		{
			if(this.peopleTree.IsSelectedRowValid)
			{
				Navigator.Navigate("person");
				editing = true;
			}
			else
			{
				MessageBox.Show(this,"Please Select a Person","Unspecified Person",
				MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
			SetButtonEnableStatus();
		}

		private void Cancel_Click(object sender, System.EventArgs e)
		{
			CancelEdit();
		}

		private void CancelEdit()
		{
			// finish the edit operation and ensure that the changes are reverted
			CompleteEdit(new FinishEditAction(MyController.RejectChangesToEmployeeInformation));
		}


		private void SaveEdit()
		{
			// finish the edit operation and ensure that the changes are saved
			CompleteEdit(new FinishEditAction(MyController.SaveChangesToEmployeeInformation));
		}


		/// <summary>
		/// Method that complete the editing of client information.
		/// </summary>
		/// <param name="action">Delegate that will be invoked to perform some custom processing before the screen
		/// state reverts to read only</param>
		private void CompleteEdit(FinishEditAction action)
		{
			if (editing)
			{
				Navigator.Navigate("peopleTree");
				// invoke the method to perform custom processing (Either a save or rollback, in this instance)
				action();
				editing =false;
			}
			SetButtonEnableStatus();
		}


		private void SaveButton_Click(object sender, System.EventArgs e)
		{
			SaveEdit();
		}


		private void SetButtonEnableStatus()
		{
			SaveButton.Enabled = editing;
			Cancel.Enabled = editing;
			EditButton.Enabled = !editing;
		}


		private void MainForm_Closed(object sender, System.EventArgs e)
		{
			MyController.RejectChangesToEmployeeInformation();
		}

		public override void WinFormViewOnLoad(object source, EventArgs e)
		{
			base.WinFormViewOnLoad (source, e);
			Navigator.CurrentState.CurrentView = "peopleTree";
		}


		private void bannerButton_Click(object sender, System.EventArgs e)
		{
			Navigator.Navigate("Banner");
		}


		#region "UIP Plumbing"
		private PersonController MyController
		{
			get
			{
				return (PersonController)Controller;
			}
		}
		#endregion
	}
}
