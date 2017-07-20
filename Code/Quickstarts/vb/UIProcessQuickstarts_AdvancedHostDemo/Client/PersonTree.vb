 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' PersonTree.vb
'
' This file contains the implementations of the PersonTree class.
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
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.ApplicationBlocks.UIProcess

Namespace Client

    ' <summary>
    ' Summary description for PersonTree.
    ' </summary>
    Public Class PersonTree
        Inherits WindowsFormControlView
        Private personList As System.Windows.Forms.ListView
        Private currentRow As Integer = -1

        'private EmployeeData data;
        ' <summary>
        ' Required designer variable.
        ' </summary>
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            ' This call is required by the Windows.Forms Form Designer.
            InitializeComponent()

            AddHandler personList.SelectedIndexChanged, AddressOf personList_SelectedIndexChanged
        End Sub

        Private Sub RefreshData()
            If IsSelectedRowValid Then
                If Me.personList.Items.Count > 0 Then
                    Me.personList.Items.Clear()
                End If
                AddRows()
                Me.personList.Items(currentRow).Selected = True
            End If
        End Sub

        Public ReadOnly Property IsSelectedRowValid() As Boolean
            Get
                Return currentRow >= 0 AndAlso currentRow < Me.personList.Items.Count
            End Get
        End Property

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

#Region "Component Designer generated code"

        ' <summary>
        ' Required method for Designer support - do not modify
        ' the contents of this method with the code editor.
        ' </summary>
        Private Sub InitializeComponent()
            Me.personList = New System.Windows.Forms.ListView
            Me.SuspendLayout()
            ' 
            ' personList
            ' 
            Me.personList.Dock = System.Windows.Forms.DockStyle.Fill
            Me.personList.GridLines = True
            Me.personList.Location = New System.Drawing.Point(0, 0)
            Me.personList.MultiSelect = False
            Me.personList.Name = "personList"
            Me.personList.Size = New System.Drawing.Size(150, 150)
            Me.personList.TabIndex = 0
            Me.personList.View = System.Windows.Forms.View.Details
            ' 
            ' PersonTree
            ' 
            Me.Controls.Add(personList)
            Me.Name = "PersonTree"
            Me.ResumeLayout(False)
        End Sub 'InitializeComponent 
#End Region

        Private Sub SetColumnWidth()
            Dim columnWidth As Integer = Me.personList.Width / 2
            Dim header As ColumnHeader
            For Each header In Me.personList.Columns
                header.Width = columnWidth
            Next header
        End Sub

        Private Sub AddColumns()
            Me.personList.Columns.Add("Last Name", 60, HorizontalAlignment.Left)
            Me.personList.Columns.Add("First Name", 60, HorizontalAlignment.Left)
        End Sub

        Private Sub AddRows()
            Dim row As EmployeeData.PersonRow
            For Each row In MyController.GetEmployees()
                Dim item As New ListViewItem
                item.Text = row.FirstName
                item.SubItems.Add(row.LastName)
                personList.Items.Add(item)
            Next row
        End Sub

        Private Sub personList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim i As Integer
            For i = 0 To (Me.personList.Items.Count) - 1
                If Me.personList.Items(i).Selected Then
                    currentRow = i
                    MyController.SelectedPerson = MyController.GetEmployees()(i)
                    Exit For
                End If
            Next i
        End Sub

        Public Overrides Sub Enable(ByVal enabled As Boolean)
            Me.personList.Enabled = enabled
        End Sub

		Public Overrides Sub Initialize(ByVal args As TaskArgumentsHolder, ByVal settings As ViewSettings)
			AddColumns()
			AddRows()
			SetColumnWidth()

			MyController.SubscribeForChangesToPeople(New Client.EmployeeData.PersonRowChangeEventHandler(AddressOf Person_PersonRowChanged))
		End Sub

#Region "UIP Plumbing"

		Private ReadOnly Property MyController() As PersonTreeController
			Get
				Return DirectCast(Controller, PersonTreeController)
			End Get
		End Property

#End Region

		Private Sub Person_PersonRowChanged(ByVal sender As Object, ByVal e As Client.EmployeeData.PersonRowChangeEvent)
			RefreshData()
		End Sub

	End Class

End Namespace