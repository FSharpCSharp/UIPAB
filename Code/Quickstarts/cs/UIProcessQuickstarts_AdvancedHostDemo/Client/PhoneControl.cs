//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// PhoneControl.cs
//
// This file contains the implementations of the PhoneControl class.
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
	/// Summary description for PhoneControl.
	/// </summary>
	public class PhoneControl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox areaCodeTxt;
		private System.Windows.Forms.TextBox phoneNumTxt;

		private EmployeeData.PhoneRow phone;		

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PhoneControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			// TODO: Add any initialization after the InitializeComponent call
		}

		public void RefreshData() 
		{
			if( phone != null) 
			{
				areaCodeTxt.DataBindings.Clear();
				areaCodeTxt.DataBindings.Add("Text", phone, "AreaCode");
				phoneNumTxt.DataBindings.Clear();
				phoneNumTxt.DataBindings.Add("Text", phone, "PhoneNumber");
			}
		}

		public EmployeeData.PhoneRow PhoneNumber 
		{
			set 
			{ 
				phone = value;
				if (phone != null) 
				{
					RefreshData();			
				}
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.areaCodeTxt = new System.Windows.Forms.TextBox();
			this.phoneNumTxt = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Area Code";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Phone #";
			// 
			// areaCodeTxt
			// 
			this.areaCodeTxt.Location = new System.Drawing.Point(88, 24);
			this.areaCodeTxt.MaxLength = 3;
			this.areaCodeTxt.Name = "areaCodeTxt";
			this.areaCodeTxt.Size = new System.Drawing.Size(48, 20);
			this.areaCodeTxt.TabIndex = 2;
			this.areaCodeTxt.Text = "";
			// 
			// phoneNumTxt
			// 
			this.phoneNumTxt.Location = new System.Drawing.Point(88, 64);
			this.phoneNumTxt.MaxLength = 8;
			this.phoneNumTxt.Name = "phoneNumTxt";
			this.phoneNumTxt.Size = new System.Drawing.Size(88, 20);
			this.phoneNumTxt.TabIndex = 3;
			this.phoneNumTxt.Text = "";
			// 
			// PhoneControl
			// 
			this.Controls.Add(this.phoneNumTxt);
			this.Controls.Add(this.areaCodeTxt);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "PhoneControl";
			this.Size = new System.Drawing.Size(216, 136);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
