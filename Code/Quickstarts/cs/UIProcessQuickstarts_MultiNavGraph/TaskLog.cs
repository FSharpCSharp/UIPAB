//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// TaskLog.cs
//
// This file contains the implementations of the TaskLog class.
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
using System.Xml;
using System.IO;
using System.Globalization;

namespace UIProcessQuickstarts_MultiNavGraph
{
	/// <summary>
	/// This class represents a task entry
	/// </summary>
	public struct TaskLogEntry
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="taskIdIn">Task id</param>
		/// <param name="navGraphNameIn">Navigation graph</param>
		/// <param name="viewNameIn">View name</param>
		/// <param name="entryTimeIn">Entry timestamp</param>
		public TaskLogEntry( Guid taskIdIn, string navGraphNameIn, string viewNameIn, DateTime entryTimeIn )
		{
			TaskId = taskIdIn;
			NavGraphName = navGraphNameIn;
			ViewName = viewNameIn;
			EntryTime = entryTimeIn;
		}

		public Guid TaskId;
		public string NavGraphName;
		public string ViewName;
		public DateTime EntryTime;
	}

	/// <summary>
	/// This class manages the task entries file
	/// </summary>
	public sealed class TaskLog
	{
		private static readonly string PATH_TASKS_XML = @"..\..\tasks.xml";
		
        private TaskLog(){}

		/// <summary>
		/// Static constructor
		/// </summary>
		static TaskLog()
		{
            //  make sure tasks.xml is readable
            if( File.Exists( PATH_TASKS_XML ) && 
                ( File.GetAttributes( PATH_TASKS_XML ) & FileAttributes.ReadOnly ) == FileAttributes.ReadOnly )
                File.SetAttributes( PATH_TASKS_XML, FileAttributes.Normal );
		}

		/// <summary>
		/// Updates the entries file with the specified entry
		/// </summary>
		/// <param name="entry">task entry</param>
		public static void MakeTaskEntry( TaskLogEntry entry )
		{
			MakeTaskEntry( entry.TaskId, entry.NavGraphName, entry.ViewName, entry.EntryTime );
		}

		/// <summary>
		/// Updates the task entry timestamp
		/// </summary>
		/// <param name="taskId">Task id</param>
		public static void MakeTaskEntry( Guid taskId )
		{
			XmlDocument doc = new XmlDocument();
			XmlNode node = null;
		
			doc.Load( PATH_TASKS_XML );

			//  find node that matches, if so just modify it
			node = doc.SelectSingleNode( "tasks/task[@taskid='" + Guid.Empty.ToString() + "']" );

			if( node != null )
			{
				node.SelectSingleNode( "@taskid" ).InnerText = taskId.ToString();
				node.SelectSingleNode( "@time" ).InnerText = DateTime.Now.ToString( CultureInfo.CurrentUICulture );
			}

            //  save the doc
			doc.Save( PATH_TASKS_XML );
		}

		/// <summary>
		/// Updates the task entries file. 
		/// If the specified task doesn´t exists then a new task entry is created, 
		/// otherwise the existing task is modified
		/// </summary>
		/// <param name="taskId">Task id</param>
		/// <param name="navGraphName">Navigation graph name</param>
		/// <param name="viewName">View name</param>
		/// <param name="entryTime">Entry timestamp</param>
		public static void MakeTaskEntry( Guid taskId, string navGraphName, string viewName, DateTime entryTime )
		{
			XmlDocument doc = new XmlDocument();
			XmlNode node = null;
		
			doc.Load( PATH_TASKS_XML );

			//  find node that matches, if so just modify it
			node = doc.SelectSingleNode( "tasks/task[@taskid='" + taskId.ToString() + "']" );

			if( node != null ) // Modify the existing task
			{
				node.SelectSingleNode( "@navgraph" ).InnerText = navGraphName;
				node.SelectSingleNode( "@view" ).InnerText = viewName;
				node.SelectSingleNode( "@time" ).InnerText = entryTime.ToString( System.Globalization.CultureInfo.CurrentUICulture );
			}
			else
			{
				node = doc.CreateElement( null, "task", null ); // Create a new task entry
                
                XmlAttribute tempAttribute = doc.CreateAttribute( null, "taskid", null );
				tempAttribute.Value = taskId.ToString();
                node.Attributes.Append( tempAttribute );

				tempAttribute = doc.CreateAttribute( null, "navgraph", null );
                tempAttribute.Value = navGraphName;
                node.Attributes.Append( tempAttribute );

				tempAttribute = doc.CreateAttribute( null, "view", null );
                tempAttribute.Value = viewName;
                node.Attributes.Append( tempAttribute );

				tempAttribute = doc.CreateAttribute( null, "time", null );
                tempAttribute.Value = entryTime.ToString( System.Globalization.CultureInfo.CurrentUICulture );
                node.Attributes.Append( tempAttribute );

				doc.SelectSingleNode( "tasks" ).AppendChild( node );
			}

			//  save the doc
			doc.Save( PATH_TASKS_XML );
		}
		/// <summary>
		/// Remove the task element based on taskId
		/// </summary>
		public static void RemoveTaskEntry(Guid taskId) 
		{
			XmlDocument doc = new XmlDocument();
			XmlNode node = null;
		
			doc.Load( PATH_TASKS_XML );

			//  find node that matches, if so just modify it
			node = doc.SelectSingleNode( "tasks/task[@taskid='" + taskId.ToString() + "']" );
			if( node != null )
			{
				doc.SelectSingleNode( "tasks" ).RemoveChild( node );
				doc.Save( PATH_TASKS_XML );
			}
		}
		/// <summary>
		/// Gets all task entries
		/// </summary>
		public static TaskLogEntry[] GetTaskEntries()
		{
			XmlDocument doc = new XmlDocument();
			int idx = 0;
			TaskLogEntry[] entries;

			doc.Load( PATH_TASKS_XML );

			entries = new TaskLogEntry[ doc.SelectNodes( "tasks/task" ).Count ];

			foreach( XmlNode node in doc.SelectNodes( "tasks/task" ) )
			{
				entries[idx] = new TaskLogEntry( 
								new Guid( node.SelectSingleNode( "@taskid" ).Value ) , 
								node.SelectSingleNode( "@navgraph" ).Value, 
								node.SelectSingleNode( "@view" ).Value, 
								DateTime.Parse( node.SelectSingleNode( "@time" ).Value , CultureInfo.CurrentUICulture ) );

				idx++;
			}

			return entries;
		}

		/// <summary>
		/// Gets a dataset with all task entries
		/// </summary>
		public static DataSet GetTaskEntriesDataset()
		{
			DataSet ds = new DataSet();
			ds.ReadXml( PATH_TASKS_XML );
			return ds;
		}
	}
}
