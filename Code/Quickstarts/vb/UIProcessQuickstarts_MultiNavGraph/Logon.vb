 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' Logon.vb
'
' This file contains the implementations of the Logon class.
'
' 
'===============================================================================
' Copyright (C) 2000-2001 Microsoft Corporation
' All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
' FITNESS FOR A PARTICULAR PURPOSE.
'==============================================================================
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Xml

Imports Microsoft.ApplicationBlocks.UIProcess


Namespace UIProcessQuickstarts_MultiNavGraph
    ' <summary>
    ' This class is the logon form
    ' </summary>
   
   Public Class Logon
      Inherits System.Windows.Forms.Form
      Private WithEvents dataGrid1 As DataGrid
      Private label1 As Label
      Private WithEvents btnLogon As Button
      Private components As Container = Nothing
      Private _entry As TaskLogEntry
      Private _entries() As TaskLogEntry
      
      
      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()
         
         ShowTasks()
      End Sub 'New
      
      
        ' <summary>
        ' Clean up any resources being used.
        ' </summary>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub 'Dispose


        Public Shared Sub Application_ThreadException(ByVal [source] As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
            Dim errMessage As String = ""
            Dim tempException As Exception
            tempException = e.Exception

            While Not (tempException Is Nothing)
                errMessage += tempException.Message.ToString(System.Globalization.CultureInfo.InvariantCulture) + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While
            MessageBox.Show(String.Format("There are some problems while trying to use the UIP Application block, please check the following error messages: {0}" + Environment.NewLine + "You should be sure UIP database scripts was executed over the sql server", errMessage), "Application error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub 'Application_ThreadException

#Region "Windows Form Designer generated code"

        ' <summary>
        ' Required method for Designer support - do not modify
        ' the contents of this method with the code editor.
        ' </summary>
        Private Sub InitializeComponent()
            Me.dataGrid1 = New System.Windows.Forms.DataGrid
            Me.label1 = New System.Windows.Forms.Label
            Me.btnLogon = New System.Windows.Forms.Button
            CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' dataGrid1
            ' 
            Me.dataGrid1.DataMember = ""
            Me.dataGrid1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.dataGrid1.Location = New System.Drawing.Point(0, 72)
            Me.dataGrid1.Name = "dataGrid1"
            Me.dataGrid1.Size = New System.Drawing.Size(480, 302)
            Me.dataGrid1.TabIndex = 1
            ' 
            ' label1
            ' 
            Me.label1.Location = New System.Drawing.Point(8, 16)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(240, 40)
            Me.label1.TabIndex = 2
            Me.label1.Text = "Welcome back.  Pick a Task to log back into, or just click ""Logon"" to start a new" + " task"
            ' 
            ' btnLogon
            ' 
            Me.btnLogon.Location = New System.Drawing.Point(320, 24)
            Me.btnLogon.Name = "btnLogon"
            Me.btnLogon.Size = New System.Drawing.Size(120, 23)
            Me.btnLogon.TabIndex = 3
            Me.btnLogon.Text = "Logon New Task"
            ' 
            ' Logon
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(480, 374)
            Me.Controls.Add(btnLogon)
            Me.Controls.Add(label1)
            Me.Controls.Add(dataGrid1)
            Me.Name = "Logon"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Logon"
            CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub 'InitializeComponent 
#End Region


        ' <summary>
        ' The main entry point for the application.
        ' </summary>
        <STAThread()> _
        Shared Sub Main()
            AddHandler Application.ThreadException, AddressOf Application_ThreadException
            Application.Run(New Logon)
        End Sub 'Main


        ' <summary>
        ' Shows the existing tasks
        ' </summary>
        Private Sub ShowTasks()
            ' Get the existing task
            _entries = TaskLog.GetTaskEntries()

            ' Bind the data to a datagrid
            Dim ds As DataSet = TaskLog.GetTaskEntriesDataset()
            dataGrid1.DataSource = ds.Tables("task")
        End Sub 'ShowTasks


        Private Sub btnLogon_Click_1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogon.Click
            Dim task As New DemoTask
            Dim nav As String = "navA"

            '  set first nav + view, since we are starting fresh
            _entry = New TaskLogEntry(Guid.Empty, "navA", "Form1", DateTime.Now)

            '  save this entry
            TaskLog.MakeTaskEntry(_entry)

            ' start a new task
            UIPManager.StartNavigationTask(nav, task)
        End Sub 'btnLogon_Click_1


        Private Sub dataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dataGrid1.DoubleClick
            If dataGrid1.CurrentCell.RowNumber >= 0 AndAlso dataGrid1.CurrentCell.RowNumber <= _entries.Length Then
                _entry = _entries(dataGrid1.CurrentCell.RowNumber)

                ' get a existing task info
                Dim task As New DemoTask(_entry.TaskId)

                ' start a existing task
                Try
                    UIPManager.StartNavigationTask(_entry.NavGraphName, task)
                Catch ex As UIPException
                    If (ex.Message.IndexOf("Task not found") > -1) Then
                        MessageBox.Show(ex.Message + Environment.NewLine + "Remove the bad <task> element within the <tasks> in tasks.xml file to re-start")
                    Else
                        Throw ex
                    End If
                End Try
            End If
        End Sub 'dataGrid1_DoubleClick
    End Class 'Logon
End Namespace 'UIProcessQuickstarts_MultiNavGraph