//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// Address.cs
//
// This file contains the implementations of the Address class.
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

namespace Client
{
	
	/// <summary>
	/// Control that encapsulates capturing and displaying information about an address
	/// </summary>
	public class AddressControl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label streetLabel;
		private System.Windows.Forms.Label cityLabel;
		private System.Windows.Forms.Label stateLabel;
		private System.Windows.Forms.Label zipLabel;
		private System.Windows.Forms.TextBox street;
		private System.Windows.Forms.TextBox city;
		private System.Windows.Forms.TextBox state;
		private System.Windows.Forms.TextBox zip;
		private System.Windows.Forms.Button ValidateButton;
		private System.Windows.Forms.Label title;
		private EmployeeData.AddressRow address;
		private System.Windows.Forms.ErrorProvider errInvalid;

		public delegate void ValidateAddressHandler(object sender,AddressValidatingEventArgs e);
		public event ValidateAddressHandler ValidatingAddress;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddressControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}


		private void OnValidatingAddress(AddressValidatingEventArgs e)
		{
			if (ValidatingAddress != null)
			{
				ValidatingAddress(this,e);
				errInvalid.SetError(this.ValidateButton,e.ErrorMessage);
			}
		}

		/// <summary>
		/// Refreshes the contents of the controls that are bound to a particular address
		/// </summary>
		public void RefreshData() 
		{
			errInvalid.SetError(this.ValidateButton,"");
			if( address != null) 
			{
				street.DataBindings.Clear();
				street.DataBindings.Add("Text", address, "Street");
				city.DataBindings.Clear();
				city.DataBindings.Add("Text", address, "City");
				state.DataBindings.Clear();
				state.DataBindings.Add("Text", address, "State");
				zip.DataBindings.Clear();
				zip.DataBindings.Add("Text", address, "Zip"); 
			}
		}

		public bool AddressIsValid
		{
			get
			{ 
				AddressValidatingEventArgs e = new AddressValidatingEventArgs();
				OnValidatingAddress(e);
				return e.AddressIsValid;
			}
		}


		/// <summary>
		/// Property to set the address that the control should display/modify
		/// </summary>
		public EmployeeData.AddressRow Address 
		{
			set 
			{ 
				address = value;
				if (address != null) 
				{
					RefreshData();
				}				
			}
			get
			{
				return address;
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
			this.streetLabel = new System.Windows.Forms.Label();
			this.cityLabel = new System.Windows.Forms.Label();
			this.stateLabel = new System.Windows.Forms.Label();
			this.zipLabel = new System.Windows.Forms.Label();
			this.street = new System.Windows.Forms.TextBox();
			this.city = new System.Windows.Forms.TextBox();
			this.state = new System.Windows.Forms.TextBox();
			this.zip = new System.Windows.Forms.TextBox();
			this.ValidateButton = new System.Windows.Forms.Button();
			this.title = new System.Windows.Forms.Label();
			this.errInvalid = new System.Windows.Forms.ErrorProvider();
			this.SuspendLayout();
			// 
			// streetLabel
			// 
			this.streetLabel.Location = new System.Drawing.Point(24, 48);
			this.streetLabel.Name = "streetLabel";
			this.streetLabel.Size = new System.Drawing.Size(72, 23);
			this.streetLabel.TabIndex = 0;
			this.streetLabel.Text = "Street";
			// 
			// cityLabel
			// 
			this.cityLabel.Location = new System.Drawing.Point(24, 72);
			this.cityLabel.Name = "cityLabel";
			this.cityLabel.Size = new System.Drawing.Size(80, 23);
			this.cityLabel.TabIndex = 1;
			this.cityLabel.Text = "City";
			// 
			// stateLabel
			// 
			this.stateLabel.Location = new System.Drawing.Point(24, 104);
			this.stateLabel.Name = "stateLabel";
			this.stateLabel.Size = new System.Drawing.Size(80, 23);
			this.stateLabel.TabIndex = 2;
			this.stateLabel.Text = "State/Province";
			// 
			// zipLabel
			// 
			this.zipLabel.Location = new System.Drawing.Point(24, 136);
			this.zipLabel.Name = "zipLabel";
			this.zipLabel.Size = new System.Drawing.Size(80, 23);
			this.zipLabel.TabIndex = 3;
			this.zipLabel.Text = "Zip/Post Code";
			// 
			// street
			// 
			this.street.Location = new System.Drawing.Point(128, 48);
			this.street.Name = "street";
			this.street.TabIndex = 4;
			this.street.Text = "";
			// 
			// city
			// 
			this.city.Location = new System.Drawing.Point(128, 72);
			this.city.Name = "city";
			this.city.TabIndex = 5;
			this.city.Text = "";
			// 
			// state
			// 
			this.state.Location = new System.Drawing.Point(128, 104);
			this.state.Name = "state";
			this.state.TabIndex = 6;
			this.state.Text = "";
			// 
			// zip
			// 
			this.zip.Location = new System.Drawing.Point(128, 136);
			this.zip.Name = "zip";
			this.zip.TabIndex = 7;
			this.zip.Text = "";
			// 
			// ValidateButton
			// 
			this.ValidateButton.Location = new System.Drawing.Point(128, 168);
			this.ValidateButton.Name = "ValidateButton";
			this.ValidateButton.TabIndex = 8;
			this.ValidateButton.Text = "Validate";
			this.ValidateButton.Click += new System.EventHandler(this.ValidateButton_Click);
			// 
			// title
			// 
			this.title.Location = new System.Drawing.Point(64, 16);
			this.title.Name = "title";
			this.title.TabIndex = 9;
			this.title.Text = "Title";
			this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// errInvalid
			// 
			this.errInvalid.ContainerControl = this;
			// 
			// AddressControl
			// 
			this.Controls.Add(this.title);
			this.Controls.Add(this.ValidateButton);
			this.Controls.Add(this.zip);
			this.Controls.Add(this.state);
			this.Controls.Add(this.city);
			this.Controls.Add(this.street);
			this.Controls.Add(this.zipLabel);
			this.Controls.Add(this.stateLabel);
			this.Controls.Add(this.cityLabel);
			this.Controls.Add(this.streetLabel);
			this.Name = "AddressControl";
			this.Size = new System.Drawing.Size(256, 200);
			this.ResumeLayout(false);

		}
		#endregion

		private void ValidateButton_Click(object sender, System.EventArgs e)
		{
			ValidateAddress();
		}

		private void ValidateAddress()
		{
			OnValidatingAddress((new AddressValidatingEventArgs()));			
		}

		/// <summary>
		/// Title that will be displayed at the top of the control
		/// </summary>
		public string Title 
		{
			get { return title.Text; }
			set { title.Text = value; }
		}


	}

	public class AddressValidatingEventArgs:EventArgs
	{
		private const string DEFAULT_ERROR_MESSAGE = "Please enter a valid address";
		private bool isValid;
		private string errorMessage;

		public AddressValidatingEventArgs()
		{
			isValid = false;			
			errorMessage = DEFAULT_ERROR_MESSAGE;
		}

		public bool AddressIsValid
		{
			set
			{
				isValid = value;
			}
			get
			{
				return isValid;
			}
		}


		public string ErrorMessage
		{
			get
			{
				if (! isValid )
				{
					if (! IsValidErrorMessage)
					{
						errorMessage = DEFAULT_ERROR_MESSAGE;
					}
				}
				else
					errorMessage = "";

				return errorMessage;
			}
			set
			{
				errorMessage = value;
			}
		}


		private bool IsValidErrorMessage
		{
			get
			{
				return (errorMessage != null && errorMessage.Trim().Length >0);
			}
		}
	}
}
