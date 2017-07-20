//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// PersonControl.cs
//
// This file contains the implementations of the PersonControl class.
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
	/// Control that encapsulates displaying/modifying data about a client
	/// </summary>
	public class PersonControl : WindowsFormControlView
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage InfoTab;
		private System.Windows.Forms.TabPage AddressTab;
		private System.Windows.Forms.TabPage PhoneTab;

		private EmployeeData.PersonRow person;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox FirstName;
		private System.Windows.Forms.TextBox LastName;
		private Client.AddressControl WorkAddress;
		private Client.AddressControl HomeAddress;
		private Client.PhoneControl Phone;


		private System.ComponentModel.Container components = null;

		public PersonControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			Enable(false);
		}

		/// <summary>
		/// Method to enable/disable the control and its nested controls
		/// </summary>
		/// <param name="enabled"></param>
		public override void Enable(bool enabled)
		{
			label1.Enabled = enabled;
			label2.Enabled = enabled;
			FirstName.Enabled = enabled;
			LastName.Enabled = enabled;
			WorkAddress.Enabled = enabled;
			HomeAddress.Enabled = enabled;
			Phone.Enabled = enabled;
		}

		/// <summary>
		/// Property that exposes the person that is currently being viewed in the control
		/// </summary>
		public EmployeeData.PersonRow Person
		{
			set
			{
				person = value;
				if (person != null)
				{
					RefreshData();

					ProcessAddressInformation();
					ProcessPhoneInformation();
				}
			}
			get
			{
				return person;
			}
		}


		/// <summary>
		/// Method used to load the address information for a person
		/// </summary>
		private void ProcessAddressInformation()
		{
			WorkAddress.Address = MyController.GetWorkAddressForPerson(person);
			HomeAddress.Address = MyController.GetHomeAddressForPerson(person);
		}

		/// <summary>
		/// Method used to load the phone information for a person
		/// </summary>
		private void ProcessPhoneInformation()
		{
			Phone.PhoneNumber = MyController.GetPhoneNumberForPerson(person);
		}

		/// <summary>
		/// Refreshes the contents of the controls that are bound to a particular person
		/// </summary>
		public void RefreshData()
		{
			if (person != null)
			{
				FirstName.DataBindings.Clear();
				FirstName.DataBindings.Add("Text", person, "FirstName");

				LastName.DataBindings.Clear();
				LastName.DataBindings.Add("Text", person, "LastName");
				WorkAddress.RefreshData();
				HomeAddress.RefreshData();
				Phone.RefreshData();
			}
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.InfoTab = new System.Windows.Forms.TabPage();
			this.LastName = new System.Windows.Forms.TextBox();
			this.FirstName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.AddressTab = new System.Windows.Forms.TabPage();
			this.HomeAddress = new Client.AddressControl();
			this.WorkAddress = new Client.AddressControl();
			this.PhoneTab = new System.Windows.Forms.TabPage();
			this.Phone = new Client.PhoneControl();
			this.tabControl1.SuspendLayout();
			this.InfoTab.SuspendLayout();
			this.AddressTab.SuspendLayout();
			this.PhoneTab.SuspendLayout();
			this.SuspendLayout();
			//
			// tabControl1
			//
			this.tabControl1.Controls.Add(this.InfoTab);
			this.tabControl1.Controls.Add(this.AddressTab);
			this.tabControl1.Controls.Add(this.PhoneTab);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(632, 360);
			this.tabControl1.TabIndex = 0;
			//
			// InfoTab
			//
			this.InfoTab.Controls.Add(this.LastName);
			this.InfoTab.Controls.Add(this.FirstName);
			this.InfoTab.Controls.Add(this.label2);
			this.InfoTab.Controls.Add(this.label1);
			this.InfoTab.Location = new System.Drawing.Point(4, 22);
			this.InfoTab.Name = "InfoTab";
			this.InfoTab.Size = new System.Drawing.Size(624, 334);
			this.InfoTab.TabIndex = 0;
			this.InfoTab.Text = "Info";
			//
			// LastName
			//
			this.LastName.Location = new System.Drawing.Point(144, 56);
			this.LastName.Name = "LastName";
			this.LastName.TabIndex = 3;
			this.LastName.Text = "";
			//
			// FirstName
			//
			this.FirstName.Location = new System.Drawing.Point(144, 24);
			this.FirstName.Name = "FirstName";
			this.FirstName.TabIndex = 2;
			this.FirstName.Text = "";
			//
			// label2
			//
			this.label2.Location = new System.Drawing.Point(16, 56);
			this.label2.Name = "label2";
			this.label2.TabIndex = 1;
			this.label2.Text = "Last Name";
			//
			// label1
			//
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "First Name";
			//
			// AddressTab
			//
			this.AddressTab.Controls.Add(this.HomeAddress);
			this.AddressTab.Controls.Add(this.WorkAddress);
			this.AddressTab.Location = new System.Drawing.Point(4, 22);
			this.AddressTab.Name = "AddressTab";
			this.AddressTab.Size = new System.Drawing.Size(624, 334);
			this.AddressTab.TabIndex = 1;
			this.AddressTab.Text = "Addresses";
			//
			// HomeAddress
			//
			this.HomeAddress.Address = null;
			this.HomeAddress.Location = new System.Drawing.Point(256, 8);
			this.HomeAddress.Name = "HomeAddress";
			this.HomeAddress.Size = new System.Drawing.Size(248, 200);
			this.HomeAddress.TabIndex = 1;
			this.HomeAddress.Title = "Home Address";
			//
			// WorkAddress
			//
			this.WorkAddress.Address = null;
			this.WorkAddress.Location = new System.Drawing.Point(8, 8);
			this.WorkAddress.Name = "WorkAddress";
			this.WorkAddress.Size = new System.Drawing.Size(240, 200);
			this.WorkAddress.TabIndex = 0;
			this.WorkAddress.Title = "Work Address";
			//
			// PhoneTab
			//
			this.PhoneTab.Controls.Add(this.Phone);
			this.PhoneTab.Location = new System.Drawing.Point(4, 22);
			this.PhoneTab.Name = "PhoneTab";
			this.PhoneTab.Size = new System.Drawing.Size(624, 334);
			this.PhoneTab.TabIndex = 2;
			this.PhoneTab.Text = "Phone Number";
			//
			// Phone
			//
			this.Phone.Location = new System.Drawing.Point(8, 8);
			this.Phone.Name = "Phone";
			this.Phone.Size = new System.Drawing.Size(216, 136);
			this.Phone.TabIndex = 0;
			//
			// PersonControl
			//
			this.Controls.Add(this.tabControl1);
			this.Name = "PersonControl";
			this.Size = new System.Drawing.Size(632, 360);
			this.tabControl1.ResumeLayout(false);
			this.InfoTab.ResumeLayout(false);
			this.AddressTab.ResumeLayout(false);
			this.PhoneTab.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		public override void Initialize(TaskArgumentsHolder args, ViewSettings settings)
		{
			// subscribe to be notified for the changes that we are interested in
			MyController.SelectedPersonChanged+=new Client.PersonController.PersonChangedHandler(MyController_SelectedPersonChanged);
			MyController.SubscribeForChangesToAddressInformation(new Client.EmployeeData.AddressRowChangeEventHandler(Address_AddressRowChanged));
			MyController.SubscribeForChangesToPeople(new Client.EmployeeData.PersonRowChangeEventHandler(Person_PersonRowChanged));
			MyController.SubscribeForChangesToPhoneInformation(new Client.EmployeeData.PhoneRowChangeEventHandler(Phone_PhoneRowChanged));

			// monitor when the validating address events fires off so we can implement our own custom address validation
			this.WorkAddress.ValidatingAddress+=new Client.AddressControl.ValidateAddressHandler(WorkAddress_ValidatingAddress);
			this.HomeAddress.ValidatingAddress+=new Client.AddressControl.ValidateAddressHandler(HomeAddress_ValidatingAddress);
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

		#region "Change Notification handlers"

		private void MyController_SelectedPersonChanged(object sender, PersonChangedEventArgs e)
		{
			Person = e.Person;
		}


		private void Person_PersonRowChanged(object sender, Client.EmployeeData.PersonRowChangeEvent e)
		{
			RefreshData();
		}


		private void Address_AddressRowChanged(object sender, Client.EmployeeData.AddressRowChangeEvent e)
		{
			RefreshData();
		}


		private void  Phone_PhoneRowChanged(object sender,Client.EmployeeData.PhoneRowChangeEvent e)
		{
			RefreshData();
		}


		#endregion

		#region "Address validating event handlers"

		private void WorkAddress_ValidatingAddress(object sender, AddressValidatingEventArgs e)
		{
			// do some simple field validation, if there was more complex validation to be done we could
			// offload this work to the controller that could call some domain object to do some validation for us
			if (WorkAddress.Address.Street.Trim().Length == 0)
			{
				e.AddressIsValid = false;
				e.ErrorMessage = "Please enter a valid work address";
			}
			else
				e.AddressIsValid = true;
		}

		private void HomeAddress_ValidatingAddress(object sender, AddressValidatingEventArgs e)
		{
			// do some simple field validation, if there was more complex validation to be done we could
			// offload this work to the controller that could call some domain object to do some validation for us
			if (HomeAddress.Address.Street.Trim().Length == 0)
			{
				e.AddressIsValid = false;
				e.ErrorMessage = "Please enter a valid home address";
			}
			else
				e.AddressIsValid = true;
		}

		#endregion
	}
}
