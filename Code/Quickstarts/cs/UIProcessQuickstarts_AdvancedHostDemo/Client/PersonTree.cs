//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// PersonTree.cs
//
// This file contains the implementations of the PersonTree class.
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
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.UIProcess;

namespace Client
{
	/// <summary>
	/// Summary description for PersonTree.
	/// </summary>
	public class PersonTree : WindowsFormControlView
	{
		private System.Windows.Forms.ListView personList;
		private int currentRow = -1;

		//private EmployeeData data;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PersonTree()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			personList.SelectedIndexChanged += new EventHandler(personList_SelectedIndexChanged);
		}

		private void RefreshData()
		{
			if(IsSelectedRowValid)
			{
				if(this.personList.Items.Count > 0)
				{
					this.personList.Items.Clear();
				}
				AddRows();
				this.personList.Items[currentRow].Selected = true;
			}
		}

		public bool IsSelectedRowValid
		{
			get {return currentRow >=0 && currentRow < this.personList.Items.Count; }
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

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.personList = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			//
			// personList
			//
			this.personList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.personList.GridLines = true;
			this.personList.Location = new System.Drawing.Point(0, 0);
			this.personList.MultiSelect = false;
			this.personList.Name = "personList";
			this.personList.Size = new System.Drawing.Size(150, 150);
			this.personList.TabIndex = 0;
			this.personList.View = System.Windows.Forms.View.Details;
			//
			// PersonTree
			//
			this.Controls.Add(this.personList);
			this.Name = "PersonTree";
			this.ResumeLayout(false);

		}
		#endregion

		private void SetColumnWidth()
		{
			int columnWidth = this.personList.Width / 2;
			foreach(ColumnHeader header in this.personList.Columns)
			header.Width = columnWidth;
		}

		private void AddColumns()
		{
			this.personList.Columns.Add("Last Name", 60, HorizontalAlignment.Left);
			this.personList.Columns.Add("First Name", 60, HorizontalAlignment.Left);
		}

		private void AddRows()
		{
			foreach (EmployeeData.PersonRow row in MyController.GetEmployees())
			{
				ListViewItem item = new ListViewItem();
				item.Text = row.FirstName;
				item.SubItems.Add(row.LastName);
				personList.Items.Add(item);

			}
		}

		private void personList_SelectedIndexChanged(object sender, EventArgs e)
		{
			for(int i = 0; i<this.personList.Items.Count; i++)
			{
				if(this.personList.Items[i].Selected)
				{
					currentRow = i;
					MyController.SelectedPerson = MyController.GetEmployees()[i];
					break;
				}
			}
		}


		public override void Enable(bool enabled)
		{
			this.personList.Enabled = enabled;
		}

		public override void Initialize(TaskArgumentsHolder args, ViewSettings settings)
		{
			AddColumns();
			AddRows();
			SetColumnWidth();

			MyController.SubscribeForChangesToPeople(new Client.EmployeeData.PersonRowChangeEventHandler(Person_PersonRowChanged));
		}

		#region "UIP Plumbing"
		private PersonTreeController MyController
		{
			get
			{
				return (PersonTreeController)Controller;
			}
		}
		#endregion


		 private void Person_PersonRowChanged(object sender, Client.EmployeeData.PersonRowChangeEvent e)
		 {
			 RefreshData();
		 }


	}
}
