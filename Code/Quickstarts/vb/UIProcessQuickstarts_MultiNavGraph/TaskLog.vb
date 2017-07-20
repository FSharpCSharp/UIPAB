 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' TaskLog.vb
'
' This file contains the implementations of the TaskLog class.
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
Imports System.Xml
Imports System.IO
Imports System.Globalization


Namespace UIProcessQuickstarts_MultiNavGraph
    ' <summary>
    ' This class represents a task entry
    ' </summary>
   
   Public Structure TaskLogEntry
      
        ' <summary>
        ' Constructor
        ' </summary>
        ' <param name="taskIdIn">Task id</param>
        ' <param name="navGraphNameIn">Navigation graph</param>
        ' <param name="viewNameIn">View name</param>
        ' <param name="entryTimeIn">Entry timestamp</param>
      Public Sub New(taskIdIn As Guid, navGraphNameIn As String, viewNameIn As String, entryTimeIn As DateTime)
         TaskId = taskIdIn
         NavGraphName = navGraphNameIn
         ViewName = viewNameIn
         EntryTime = entryTimeIn
      End Sub 'New
      
      Public TaskId As Guid
      Public NavGraphName As String
      Public ViewName As String
      Public EntryTime As DateTime
   End Structure 'TaskLogEntry
   
    ' <summary>
    ' This class manages the task entries file
    ' </summary>
   
   NotInheritable Public Class TaskLog
        Private Shared PATH_TASKS_XML As String = "..\tasks.xml"
      
      
      Private Sub New()
      End Sub 'New
       
        ' <summary>
        ' Static constructor
        ' </summary>
      Shared Sub New()
         '  make sure tasks.xml is readable
         If File.Exists(PATH_TASKS_XML) AndAlso(File.GetAttributes(PATH_TASKS_XML) And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Then
            File.SetAttributes(PATH_TASKS_XML, FileAttributes.Normal)
         End If
      End Sub 'New
       
        ' <summary>
        ' Updates the entries file with the specified entry
        ' </summary>
        ' <param name="entry">task entry</param>
      Overloads Public Shared Sub MakeTaskEntry(entry As TaskLogEntry)
         MakeTaskEntry(entry.TaskId, entry.NavGraphName, entry.ViewName, entry.EntryTime)
      End Sub 'MakeTaskEntry
      
      
        ' <summary>
        ' Updates the task entry timestamp
        ' </summary>
        ' <param name="taskId">Task id</param>
      Overloads Public Shared Sub MakeTaskEntry(taskId As Guid)
         Dim doc As New XmlDocument()
         Dim node As XmlNode = Nothing
         
         doc.Load(PATH_TASKS_XML)
         
         '  find node that matches, if so just modify it
         node = doc.SelectSingleNode(("tasks/task[@taskid='" + Guid.Empty.ToString() + "']"))
         
         If Not (node Is Nothing) Then
            node.SelectSingleNode("@taskid").InnerText = taskId.ToString()
            node.SelectSingleNode("@time").InnerText = DateTime.Now.ToString(CultureInfo.CurrentUICulture)
         End If
         
         '  save the doc
         doc.Save(PATH_TASKS_XML)
      End Sub 'MakeTaskEntry
      
      
        ' <summary>
        ' Updates the task entries file. 
        ' If the specified task doesnt exists then a new task entry is created, 
        ' otherwise the existing task is modified
        ' </summary>
        ' <param name="taskId">Task id</param>
        ' <param name="navGraphName">Navigation graph name</param>
        ' <param name="viewName">View name</param>
        ' <param name="entryTime">Entry timestamp</param>
      Overloads Public Shared Sub MakeTaskEntry(taskId As Guid, navGraphName As String, viewName As String, entryTime As DateTime)
         Dim doc As New XmlDocument()
         Dim node As XmlNode = Nothing
         
         doc.Load(PATH_TASKS_XML)
         
         '  find node that matches, if so just modify it
         node = doc.SelectSingleNode(("tasks/task[@taskid='" + taskId.ToString() + "']"))
         
         If Not (node Is Nothing) Then ' Modify the existing task
            node.SelectSingleNode("@navgraph").InnerText = navGraphName
            node.SelectSingleNode("@view").InnerText = viewName
            node.SelectSingleNode("@time").InnerText = entryTime.ToString(System.Globalization.CultureInfo.CurrentUICulture)
         Else
            node = doc.CreateElement(Nothing, "task", Nothing) ' Create a new task entry
            Dim tempAttribute As XmlAttribute = doc.CreateAttribute(Nothing, "taskid", Nothing)
                tempAttribute.Value = taskId.ToString()
            node.Attributes.Append(tempAttribute)
            
            tempAttribute = doc.CreateAttribute(Nothing, "navgraph", Nothing)
            tempAttribute.Value = navGraphName
            node.Attributes.Append(tempAttribute)
            
            tempAttribute = doc.CreateAttribute(Nothing, "view", Nothing)
            tempAttribute.Value = viewName
            node.Attributes.Append(tempAttribute)
            
            tempAttribute = doc.CreateAttribute(Nothing, "time", Nothing)
            tempAttribute.Value = entryTime.ToString(System.Globalization.CultureInfo.CurrentUICulture)
            node.Attributes.Append(tempAttribute)
            
            doc.SelectSingleNode("tasks").AppendChild(node)
         End If
         
         '  save the doc
         doc.Save(PATH_TASKS_XML)
      End Sub 'MakeTaskEntry
        '<summary>
        ' Remove the task element based on taskId
        ' </summary>
        Public Shared Sub RemoveTaskEntry(ByVal taskId As Guid)

            Dim doc As New XmlDocument
            Dim node As XmlNode = Nothing

            doc.Load(PATH_TASKS_XML)

            '  find node that matches, if so just modify it
            node = doc.SelectSingleNode(("tasks/task[@taskid='" + taskId.ToString() + "']"))
            If Not (node Is Nothing) Then
                doc.SelectSingleNode("tasks").RemoveChild(node)
                doc.Save(PATH_TASKS_XML)
            End If
        End Sub 'RemoveTaskEntry


        ' <summary>
        ' Gets all task entries
        ' </summary>
        Public Shared Function GetTaskEntries() As TaskLogEntry()
            Dim doc As New XmlDocument
            Dim idx As Integer = 0
            Dim entries() As TaskLogEntry

            doc.Load(PATH_TASKS_XML)

            entries = New TaskLogEntry(doc.SelectNodes("tasks/task").Count) {}

            Dim node As XmlNode
            For Each node In doc.SelectNodes("tasks/task")
                entries(idx) = New TaskLogEntry(New Guid(node.SelectSingleNode("@taskid").Value), node.SelectSingleNode("@navgraph").Value, node.SelectSingleNode("@view").Value, DateTime.Parse(node.SelectSingleNode("@time").Value, CultureInfo.CurrentUICulture))

                idx += 1
            Next node

            Return entries
        End Function 'GetTaskEntries


        ' <summary>
        ' Gets a dataset with all task entries
        ' </summary>
        Public Shared Function GetTaskEntriesDataset() As DataSet
            Dim ds As New DataSet
            ds.ReadXml(PATH_TASKS_XML)
            Return ds
        End Function 'GetTaskEntriesDataset
    End Class 'TaskLog
End Namespace 'UIProcessQuickstarts_MultiNavGraph