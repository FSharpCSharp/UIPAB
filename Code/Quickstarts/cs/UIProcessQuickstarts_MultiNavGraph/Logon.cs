//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// Logon.cs
//
// This file contains the implementations of the Logon class.
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

using Microsoft.ApplicationBlocks.UIProcess;

namespace UIProcessQuickstarts_MultiNavGraph
{
	/// <summary>
	/// This class is the logon form
	/// </summary>
	public class Logon : System.Windows.Forms.Form
	{
		private DataGrid dataGrid1;
		private Label label1;
		private Button btnLogon;
		private Container components = null;
		private TaskLogEntry _entry;
		private TaskLogEntry[] _entries;

		public Logon()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			ShowTasks();
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

		public static void Application_ThreadException(object source, System.Threading.ThreadExceptionEventArgs e)
		{
			string errMessage = "";
			for( Exception tempException = e.Exception; tempException != null ; tempException = tempException.InnerException )
			{
				errMessage += tempException.Message + Environment.NewLine + Environment.NewLine;
			}
			MessageBox.Show( string.Format( "There are some problems while trying to use the UIP Application block, please check the following error messages: {0}" + 
				Environment.NewLine + "You should be sure UIP database scripts was executed over the sql server", errMessage ),
				"Application error", MessageBoxButtons.OK, MessageBoxIcon.Error );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 72);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(480, 302);
            this.dataGrid1.TabIndex = 1;
            this.dataGrid1.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome back.  Pick a Task to log back into, or just click \"Logon\" to start a new" +
                " task";
            // 
            // btnLogon
            // 
            this.btnLogon.Location = new System.Drawing.Point(320, 24);
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.Size = new System.Drawing.Size(120, 23);
            this.btnLogon.TabIndex = 3;
            this.btnLogon.Text = "Logon New Task";
            this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click_1);
            // 
            // Logon
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(480, 374);
            this.Controls.Add(this.btnLogon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Name = "Logon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logon";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion
		
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException); 
			Application.Run(new Logon());
		}

		/// <summary>
		/// Shows the existing tasks
		/// </summary>
		private void ShowTasks()
		{
			// Get the existing task
			_entries = TaskLog.GetTaskEntries();

			// Bind the data to a datagrid
			DataSet ds = TaskLog.GetTaskEntriesDataset();
			dataGrid1.DataSource = ds.Tables["task"];
		}
		
		private void btnLogon_Click_1(object sender, System.EventArgs e)
		{
			DemoTask task = new DemoTask();
			string nav = "navA";
			
			//  set first nav + view, since we are starting fresh
			_entry = new TaskLogEntry( Guid.Empty, "navA", "Form1", DateTime.Now );

			//  save this entry
			TaskLog.MakeTaskEntry( _entry );

			// start a new task
			UIPManager.StartNavigationTask( nav, task );
		}

        private void dataGrid1_DoubleClick(object sender, System.EventArgs e)
        {
            if( dataGrid1.CurrentCell.RowNumber >= 0 && dataGrid1.CurrentCell.RowNumber <= _entries.Length )
            {
                _entry = _entries[ dataGrid1.CurrentCell.RowNumber ];

                // get a existing task info
				DemoTask task = new DemoTask( _entry.TaskId );

                // start a existing task
				try
				{
					UIPManager.StartNavigationTask( _entry.NavGraphName, task );
				}
				catch(UIPException ex)
				{
					if(ex.Message.IndexOf("Task not found")>-1)
						MessageBox.Show(ex.Message+ Environment.NewLine+"Remove the bad <task> element within the <tasks> in tasks.xml file to re-start");
					else
						throw ex;
				}
            }
        }
	}
}
