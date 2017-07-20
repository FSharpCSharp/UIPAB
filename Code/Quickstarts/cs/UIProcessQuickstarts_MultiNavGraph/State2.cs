//===============================================================================
// Microsoft User Interface Process Application Block for .NET Quick Start
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// State2.cs
//
// This file contains the implementations of the State2 class.
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
using System.Runtime.Serialization;

using Microsoft.ApplicationBlocks.UIProcess;

namespace UIProcessQuickstarts_MultiNavGraph
{
	/// <summary>
	/// A specialized state class
	/// </summary>
	[Serializable]
	public class State2 : State
	{
		private string _previousNavGraph = "";
		private Guid _previousTaskID = Guid.Empty;
		private static State _latestInstance;
		private static Guid _staticPreviousTaskID;
		public State2(){}
		public State2( IStatePersistence spp ) : base ( spp ){_latestInstance = this;}

		/// <summary>
		/// Serialization constructor
		/// </summary>
		protected State2(SerializationInfo si, StreamingContext context) : base( si, context) 
		{
			this._previousNavGraph = si.GetString("_previousNavGraph");
			this._previousTaskID= new Guid(si.GetString("_previousTaskID"));
		}

		/// <summary>
		/// Gets/Sets the previous task id
		/// </summary>
		public Guid PreviousTaskID
		{
			get{ return _previousTaskID; }
			set{ _previousTaskID = value;
				_staticPreviousTaskID = value;}
		}

		/// <summary>
		/// Gets/Sets the previous navigation graph
		/// </summary>
		public string PreviousNavGraph
		{
			get{ return _previousNavGraph; }
			set{ _previousNavGraph = value; }
		}

		public static State LatestInstance
		{
			get
			{
				return _latestInstance;
			}
		}
		public static Guid StaticPreviousTaskID
		{
			get
			{
				return _staticPreviousTaskID;
			}
		}
		#region ISerializable Members

		/// <summary>
		/// Restore the object state
		/// </summary>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData( info, context);
			info.AddValue( "_previousNavGraph", _previousNavGraph );
			info.AddValue( "_previousTaskID", _previousTaskID.ToString() );
		}

		#endregion
	}
}
