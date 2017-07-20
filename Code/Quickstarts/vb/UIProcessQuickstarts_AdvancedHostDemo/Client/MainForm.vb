 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' MainForm.vb
'
' This file contains the implementations of the MainForm class.
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
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports Microsoft.ApplicationBlocks.UIProcess

Namespace Client

    ' <summary>
    ' Summary description for Form1.
    ' </summary>
    Public Class MainForm
        Inherits WindowsFormView
        Private groupBox1 As System.Windows.Forms.GroupBox
        Private splitter1 As System.Windows.Forms.Splitter
        Private groupBox2 As System.Windows.Forms.GroupBox
        Private buttonPanel As System.Windows.Forms.Panel
        Private WithEvents EditButton As System.Windows.Forms.Button
        Private WithEvents SaveButton As System.Windows.Forms.Button
        Private panel1 As System.Windows.Forms.Panel
        Private WithEvents Cancel As System.Windows.Forms.Button
        Private WithEvents bannerButton As System.Windows.Forms.Button

        Private peopleTree As PersonTree
        Private person As PersonControl
        Private editing As Boolean = False

        Delegate Sub FinishEditAction()

        ' <summary>
        ' Required designer variable.
        ' </summary>
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()
            Me.InternalViewName = "Host"
        End Sub

		Public Overrides Sub Initialize(ByVal args As TaskArgumentsHolder, ByVal settings As ViewSettings)
			'Demo use of custom attribute of View element in config file
			Me.Text = settings.Navigator.GetAttribute("MainFormTitle", "")
		End Sub

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
		End Sub

#Region "Windows Form Designer generated code"

		' <summary>
		' Required method for Designer support - do not modify
		' the contents of this method with the code editor.
		' </summary>
		Private Sub InitializeComponent()
			Me.groupBox1 = New System.Windows.Forms.GroupBox
			Me.peopleTree = New Client.PersonTree
			Me.splitter1 = New System.Windows.Forms.Splitter
			Me.groupBox2 = New System.Windows.Forms.GroupBox
			Me.panel1 = New System.Windows.Forms.Panel
			Me.person = New Client.PersonControl
			Me.buttonPanel = New System.Windows.Forms.Panel
			Me.bannerButton = New System.Windows.Forms.Button
			Me.SaveButton = New System.Windows.Forms.Button
			Me.Cancel = New System.Windows.Forms.Button
			Me.EditButton = New System.Windows.Forms.Button
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.panel1.SuspendLayout()
			Me.buttonPanel.SuspendLayout()
			Me.SuspendLayout()
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.peopleTree)
			Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Left
			Me.groupBox1.Location = New System.Drawing.Point(0, 0)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(200, 310)
			Me.groupBox1.TabIndex = 0
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Employees"
			' 
			' peopleTree
			' 
			Me.peopleTree.Dock = System.Windows.Forms.DockStyle.Fill
			Me.peopleTree.InternalController = Nothing
			Me.peopleTree.InternalNavigator = Nothing
			Me.peopleTree.InternalViewName = Nothing
			Me.peopleTree.Location = New System.Drawing.Point(3, 16)
			Me.peopleTree.Name = "peopleTree"
			Me.peopleTree.Size = New System.Drawing.Size(194, 291)
			Me.peopleTree.TabIndex = 0
			' 
			' splitter1
			' 
			Me.splitter1.Location = New System.Drawing.Point(200, 0)
			Me.splitter1.Name = "splitter1"
			Me.splitter1.Size = New System.Drawing.Size(3, 310)
			Me.splitter1.TabIndex = 1
			Me.splitter1.TabStop = False
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.panel1)
			Me.groupBox2.Controls.Add(Me.buttonPanel)
			Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill
			Me.groupBox2.Location = New System.Drawing.Point(203, 0)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(525, 310)
			Me.groupBox2.TabIndex = 2
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Details"
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.person)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.panel1.Location = New System.Drawing.Point(3, 16)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(519, 227)
			Me.panel1.TabIndex = 1
			' 
			' person
			' 
			Me.person.InternalController = Nothing
			Me.person.InternalNavigator = Nothing
			Me.person.InternalViewName = Nothing
			Me.person.Location = New System.Drawing.Point(0, 0)
			Me.person.Name = "person"
			Me.person.Person = Nothing
			Me.person.Size = New System.Drawing.Size(632, 360)
			Me.person.TabIndex = 0
			' 
			' buttonPanel
			' 
			Me.buttonPanel.Controls.Add(Me.bannerButton)
			Me.buttonPanel.Controls.Add(Me.SaveButton)
			Me.buttonPanel.Controls.Add(Me.Cancel)
			Me.buttonPanel.Controls.Add(Me.EditButton)
			Me.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.buttonPanel.Location = New System.Drawing.Point(3, 243)
			Me.buttonPanel.Name = "buttonPanel"
			Me.buttonPanel.Size = New System.Drawing.Size(519, 64)
			Me.buttonPanel.TabIndex = 0
			' 
			' bannerButton
			' 
			Me.bannerButton.Location = New System.Drawing.Point(16, 24)
			Me.bannerButton.Name = "bannerButton"
			Me.bannerButton.TabIndex = 3
			Me.bannerButton.Text = "Banner"
			' 
			' SaveButton
			' 
			Me.SaveButton.Enabled = False
			Me.SaveButton.Location = New System.Drawing.Point(432, 24)
			Me.SaveButton.Name = "SaveButton"
			Me.SaveButton.TabIndex = 2
			Me.SaveButton.Text = "Save"
			' 
			' Cancel
			' 
			Me.Cancel.Enabled = False
			Me.Cancel.Location = New System.Drawing.Point(352, 24)
			Me.Cancel.Name = "Cancel"
			Me.Cancel.TabIndex = 1
			Me.Cancel.Text = "Cancel"
			' 
			' EditButton
			' 
			Me.EditButton.Location = New System.Drawing.Point(272, 24)
			Me.EditButton.Name = "EditButton"
			Me.EditButton.TabIndex = 0
			Me.EditButton.Text = "Edit"
			' 
			' MainForm
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(728, 310)
			Me.Controls.Add(groupBox2)
			Me.Controls.Add(splitter1)
			Me.Controls.Add(groupBox1)
			Me.Name = "MainForm"
			Me.Text = "Hosted Controlls"
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.panel1.ResumeLayout(False)
			Me.buttonPanel.ResumeLayout(False)
			Me.ResumeLayout(False)
		End Sub

#End Region

		Private Sub EditButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditButton.Click
			If Me.peopleTree.IsSelectedRowValid Then
				Navigator.Navigate("person")
				editing = True
			Else
				MessageBox.Show(Me, "Please Select a Person", "Unspecified Person", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End If
			SetButtonEnableStatus()
		End Sub

		Private Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cancel.Click
			CancelEdit()
		End Sub

		Private Sub CancelEdit()
			' finish the edit operation and ensure that the changes are reverted
			CompleteEdit(New FinishEditAction(AddressOf MyController.RejectChangesToEmployeeInformation))
		End Sub

		Private Sub SaveEdit()
			' finish the edit operation and ensure that the changes are saved
			CompleteEdit(New FinishEditAction(AddressOf MyController.SaveChangesToEmployeeInformation))
		End Sub

		' <summary>
		' Method that complete the editing of client information.
		' </summary>
		' <param name="action">Delegate that will be invoked to perform some custom processing before the screen
		' state reverts to read only</param>
		Private Sub CompleteEdit(ByVal action As FinishEditAction)
			If editing Then
				Navigator.Navigate("peopleTree")
				' invoke the method to perform custom processing (Either a save or rollback, in this instance)
				action()
				editing = False
			End If
			SetButtonEnableStatus()
		End Sub

		Private Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click
			SaveEdit()
		End Sub

		Private Sub SetButtonEnableStatus()
			SaveButton.Enabled = editing
			Cancel.Enabled = editing
			EditButton.Enabled = Not editing
		End Sub

		Private Sub MainForm_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
			MyController.RejectChangesToEmployeeInformation()
		End Sub

		Public Overrides Sub WinFormViewOnLoad(ByVal [source] As Object, ByVal e As EventArgs)
			MyBase.WinFormViewOnLoad([source], e)
			Navigator.CurrentState.CurrentView = "peopleTree"
		End Sub

		Private Sub bannerButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bannerButton.Click
			Navigator.Navigate("Banner")
		End Sub

#Region "UIP Plumbing"

		Private ReadOnly Property MyController() As PersonController
			Get
				Return DirectCast(Controller, PersonController)
			End Get
		End Property

#End Region

	End Class

End Namespace