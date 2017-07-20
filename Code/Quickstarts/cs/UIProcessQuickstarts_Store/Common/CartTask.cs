//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// CartTask.cs
//
// This file contains the implementations of the CartTask class.
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
using Microsoft.ApplicationBlocks.UIProcess;

namespace UIProcessQuickstarts_Store
{
    /// <summary>
    /// Defines a Task Object which can be passed to UIPManager.  
    /// Used to correlate a existing Task Id with a logon
    /// </summary>
    public class CartTask : ITask
	{
		#region Constructors

		public CartTask(){}

		/// <summary>
		/// Instantiates a task object initialized with a task ID retrieved using the users logon information
		/// </summary>
		/// <param name="userLogon">Login information used to retrieve a persons previous task information</param>
		public CartTask( string userLogon ) 
		{
			_userLogon = userLogon;

			// retrieve a task id that correlates to the task that a user was performing in a previous session
			_taskId = StoreControllerBase.GetUserTaskId( _userLogon );
		}
		#endregion

		#region Variable Declarations

		private string _userLogon				= "";
		private Guid _taskId					= Guid.Empty;

		#endregion

        #region ITask Members

		/// <summary>
		/// Creates a new task for the specific logon
		/// </summary>
		/// <param name="taskId"></param>
        public void Create(Guid taskId)
		{
			//  this is app-specific.
			//  in the case of this shopping cart application, we want to 
			//  correlate logons with tasks.  We use a lookup table to do so.
			//  so here, we are given a TaskId...and we must correlate it with our Logon
			
			//  create the business object to be used
			CartTaskBusinessObject bo = new CartTaskBusinessObject();

			//  cache task id given to us by UIPManager (or whatever entity)
			_taskId = taskId;

			//  tell business object to create CartTask entry
			bo.CreateTask( _taskId, _userLogon );
		}

		/// <summary>
		/// Gets the task id related to the specific logon
		/// </summary>
		/// <returns></returns>
        public Guid Get()
		{
			return _taskId;
		}

		#endregion
	}
}
