 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' SqlHelperExtension.vb
'
' This file contains the implementations of the SqlHelperExtension class.
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
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Namespace UIProcessQuickstarts_Store
    ' <summary>
    ' Sql Helper class
    ' </summary>
   
   NotInheritable Friend Class SqlHelperExtension
      
      Private Sub New()
      End Sub 'New
      
      
        ' <summary>
        ' Fills a typed DataSet using the DataReader's current result. This method 
        ' allows paginated access to the database.
        ' </summary>
        ' <param name="dataReader">The DataReader used to fetch the values.</param>
        ' <param name="dataSet">The DataSet used to store the values.</param>
        ' <param name="tableName">The name of the DataSet table used to add the 
        ' DataReader records.</param>
        ' <param name="from">The quantity of records skipped before placing
        ' values on the DataReader on the DataSet.</param>
        ' <param name="count">The maximum quantity of records alloed to fill on the
        ' DataSet.</param>
      Public Shared Sub Fill(dataReader As IDataReader, dataSet As DataSet, tableName As String, from As Integer, count As Integer)
         If tableName Is Nothing Then
            tableName = "unknownTable"
         End If 
         If dataSet.Tables(tableName) Is Nothing Then
            dataSet.Tables.Add(tableName)
         End If 
         ' Get the DataTable reference
         Dim fillTable As DataTable
         If tableName Is Nothing Then
            fillTable = dataSet.Tables(0)
         Else
            fillTable = dataSet.Tables(tableName)
         End If 
         Dim fillRow As DataRow
         Dim fieldName As String
         Dim recNumber As Integer = 0
         Dim totalRecords As Integer = from + count
            While dataReader.Read()
                recNumber = recNumber + 1
                If recNumber >= from Then
                    fillRow = fillTable.NewRow()
                    Dim fieldIdx As Integer
                    For fieldIdx = 0 To dataReader.FieldCount - 1
                        fieldName = dataReader.GetName(fieldIdx)
                        If fillTable.Columns.IndexOf(fieldName) = -1 Then
                            fillTable.Columns.Add(fieldName, dataReader.GetValue(fieldIdx).GetType())
                        End If
                        fillRow(fieldName) = dataReader.GetValue(fieldIdx)
                    Next fieldIdx
                    fillTable.Rows.Add(fillRow)
                End If
                If count <> 0 AndAlso totalRecords <= recNumber Then
                    Exit While
                End If
            End While
            dataSet.AcceptChanges()
      End Sub 'Fill
   End Class 'SqlHelperExtension
End Namespace 'UIProcessQuickstarts_Store