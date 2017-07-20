//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// State.cs
//
// This file contains the implementations of the State class
//
// For more information see the User Interface Process Application Block Implementation Overview. 
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
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	#region StateChangedEventArgs class definition

	/// <summary>
	/// Provides data for a StateChanged event.
	/// </summary>
    public class StateChangedEventArgs : EventArgs
	{
		/// <summary>
		/// Initializes a new StateChangedEventArgs class with a key.
		/// </summary>
		/// <param name="key">The state item key.</param>
        public StateChangedEventArgs(string key)
		{
			_key = key;
		}

		private string _key;

		/// <summary>
		/// Gets the changed state item key.
		/// </summary>
        public string Key
		{
			get { return _key ; }
		}
	}
	#endregion
	
	#region State class definition

	/// <summary>
	/// This class maintains user process state. It represents the model in a 
	/// Model-View-Controller pattern.
	/// </summary>
	/// <remarks>
	/// This class must be serializable. If a derived class requires a 
	///	complex serialization mecanism, then it must implement the
	/// <see cref="ISerializable"/> interface.
	/// Derived classes must call the base GetObjectData and serialization constructor appropriately to ensure
	/// full serialization or deserialization.
	/// </remarks>
	[Serializable]
	public class State : DictionaryBase, ISerializable
	{
		#region Declare variables
		private Guid _taskId = Guid.Empty;
		private string _currentView	= "";
		private string _navigationGraph = "";
		private string _navigateValue = "";
		
		[NonSerialized]
		private IStatePersistence _stateVisitor	= null;
		private const string CommaSeparator = ",";
		//  string names used to put local property values into serialization stream.
		//  GUID appended to end to make collisions with InnerHashtable-items VERY unlikely
		private readonly Guid _tagGuid1 = new Guid( new byte[] {0x5F, 0x4D, 0x69, 0x63, 0x68, 0x61, 0x65, 0x6C, 0x20, 0x53, 0x74, 0x75, 0x61, 0x72, 0x74, 0x5F } );
		
		private readonly string NameCurrentView = "_currentView_{FF9B8CB4-E13B-44a7-B3C6-B385D8EB8167}";
		private readonly string NameNavigationGraph = "_navigationGraph_{FF9B8CB4-E13B-44a7-B3C6-B385D8EB8167}";
		private readonly string NameNavigationValue = "_navigateValue_{FF9B8CB4-E13B-44a7-B3C6-B385D8EB8167}";
		private readonly string NameTaskId  = "_taskId_{FF9B8CB4-E13B-44a7-B3C6-B385D8EB8167}";
		#endregion
        
		#region Constructors
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="statePersistenceProvider">A valid state persistence provider.</param>
        public State(IStatePersistence statePersistenceProvider)
		{
			this.Accept(statePersistenceProvider);
		}
		
        /// <summary>
        /// Constructor.
        /// </summary>
        public State() : this(Guid.Empty, null, null, null, null){}        

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="taskId">A task identifier (a GUID associated with the task).</param>
        public State(Guid taskId) : this(taskId, null, null, null, null){}
		
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="taskId">A task identifier (a GUID associated with the task).</param>
        /// <param name="navGraph">A valid navigation navigation graph name.</param>
        public State(Guid taskId, string navGraph) : this(taskId, navGraph, null, null, null){}
		
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="taskId">A task identifier (a GUID associated with the task).</param>
        /// <param name="navGraph">A valid navigation graph name.</param>
        /// <param name="currentView">The current view in the navigation graph.</param>
        public State(Guid taskId, string navGraph, string currentView) : this(taskId, navGraph, currentView, null, null){}
		
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="taskId">A task identifier (a GUID associated with the task).</param>
        /// <param name="navigationGraph">A valid navigation graph name.</param>
        /// <param name="currentView">The current view in the navigation graph.</param>
        /// <param name="navigateValue">Used by the controller to determine which view is next.</param>
        /// <param name="statePersistence">A valid state persistence provider.</param>
        public State(Guid taskId, string navigationGraph, string currentView, string navigateValue, IStatePersistence statePersistence) 
		{
			this._taskId = taskId; 
			this._navigationGraph = navigationGraph;
			this._currentView = currentView;
			this._navigateValue = navigateValue;
			this.Accept(statePersistence);
		}

		/// <summary>
		/// Constructor; required by ISerializable.  
		/// </summary>
		/// <param name="serializationInfo">The serialization information.</param>
		/// <param name="context">The streaming context.</param>
		[SecurityPermissionAttribute(SecurityAction.Demand,SerializationFormatter = true)]
		[SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.SerializationFormatter)] 
		protected State(SerializationInfo serializationInfo, StreamingContext context)
		{
			string name = "";
			string tag = _tagGuid1.ToString();
			int tagIndex = 0;

			//  iterate over contents of serialization info; 
			//  put each key-value pair back into our inner hashtable
			foreach ( SerializationEntry se in serializationInfo ) 
			{
				name = se.Name;
				tagIndex = name.IndexOf( tag );
				//  check that the name ends in our tag guid; we tag all hashtable items with the tag guid to 
				//  allow distinguishing regular items, and items added by derived classes, from our actual hashtable items
				if( tagIndex > 0 )
				{
					this.InnerHashtable.Add( name.Substring(0, tagIndex), se.Value);
				}
			}

			//  deserialize the rest of our properties
			this._currentView = serializationInfo.GetString(NameCurrentView);
			this._navigationGraph = serializationInfo.GetString(NameNavigationGraph);
			this._navigateValue = serializationInfo.GetString(NameNavigationValue);
			this._taskId = (System.Guid)serializationInfo.GetValue(NameTaskId, typeof(System.Guid));
		}

		#endregion

		#region ISerializable Members

		/// <summary>
		/// Required GetObjectData of ISerializable. This packages class information into SerializationInfo.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[SecurityPermissionAttribute(SecurityAction.Demand,SerializationFormatter = true)]
		[SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.SerializationFormatter)] 
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			//  iterate over inner hashtable and add key-value pairs to serialization info
			Hashtable ht = this.InnerHashtable;
			foreach ( object key in ht.Keys )
			{
				//  assumption is that the inner hash table contains no duplicate keys (of course);
				//  further that keys won't collide with properties added later, which are keyed with "name_GUID"
				//  ALSO:  to be sure we don't try to add/retrieve derived classes serialization streams to our hashtable, 
				//  TAG HASH ENTRIES with a uniquefier (guid)
				info.AddValue( key.ToString() + _tagGuid1.ToString(), ht[key] );
			}
			//  Individually add the other properties of interest
			//  The StateChanged event is ignored, because we can't serialize our listeners too.
			info.AddValue(NameCurrentView, this._currentView);
			info.AddValue(NameNavigationGraph, this._navigationGraph);
			info.AddValue(NameNavigationValue, this._navigateValue);
			info.AddValue(NameTaskId, this._taskId, typeof(System.Guid));
		}

		#endregion

    	#region StateChangedEvent and Delegate Definitions
		/// <summary>
		/// This event is raised when the state has changed. Therefore, the views can refresh themselves to stay synchronized.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">A StateChangedEventArgs object that contains the event data.</param>
		public delegate void StateChangedEventHandler(object sender, StateChangedEventArgs e);

		/// <summary>
		/// Occurs when the state changes.
		/// </summary>
		public event StateChangedEventHandler StateChanged;
	
		#endregion

		/// <summary>
		/// The visitor pattern for StatePersistence.
		/// </summary>
		/// <param name="statePersistence">A valid state persistence provider object.</param>
		public void Accept(IStatePersistence statePersistence) 
		{
			this._stateVisitor = statePersistence;
		}

		/// <summary>
		/// Stores the state using the persistence provider related to this state.
		/// </summary>
		public void Save() 
		{
			if( _stateVisitor == null )
				throw new UIPException( Resource.ResourceManager[Resource.Exceptions.RES_ExceptionStateNotInitialized] );
 
			_stateVisitor.Save(this);
		}

		/// <summary>
		/// Deletes the state from storage using the persistence provider related to this state.
		/// </summary>
		public void Delete() 
		{
			if( _stateVisitor == null )
				throw new UIPException( Resource.ResourceManager[Resource.Exceptions.RES_ExceptionStateNotInitialized] );
 
			_stateVisitor.Remove(this.TaskId);
		}

		/// <summary>
		/// Gets or sets the navigation value. This value determines 
		/// which view is the next view in the navigation graph.
		/// </summary>
		public string NavigateValue
		{
			get{ return _navigateValue; }
			set{ _navigateValue = value; }
		}

		/// <summary>
		/// Gets or sets the state navigation graph.
		/// </summary>
		public string NavigationGraph
		{
			get{ return _navigationGraph; }
			set{ _navigationGraph = value; }
		}

		/// <summary>
		/// Gets or sets the current view in the navigation graph.
		/// </summary>
        public string CurrentView
		{
			get{ return _currentView; }
			set{ _currentView = value; }
		}

		/// <summary>
		/// Gets or sets the current task ID.
		/// </summary>
		public Guid TaskId
		{
			get{ return _taskId; }
			set{ _taskId = value; }
		}

		#region DictionaryBase members
		/// <summary>
		/// Indexer. Gets the item with the specified key.
		/// </summary>
        public virtual object this[string key] 
		{
			get{ return this.InnerHashtable[key]; }
			set
			{ 
				this.InnerHashtable[key] = value; 
				// Notify registered event listeners that State has changed
				// unless there are listeners, don't try firing
				if ( null != StateChanged )
				{
					StateChanged(this, new StateChangedEventArgs(key));
				}
			}
		}
        
		/// <summary>
		/// Gets an object that can be used to synchonize access to the state.
		/// </summary>
		public virtual object SyncRoot
		{
			get	{ return this.InnerHashtable.SyncRoot;	}
		}
		

		/// <summary>
		/// Adds an element with the specified key to the state.
		/// </summary>
		/// <param name="key">Key used to identify the element in the state.</param>
		/// <param name="value">Element to add to the state.</param>
		public virtual void Add(string key, object value)
		{
			this.InnerHashtable.Add(key, value);

			// notify registered event listeners that State has changed
			// unless there are listeners, don't try firing
			if ( null != StateChanged )
			{
				StateChanged(this, new StateChangedEventArgs(key));
			}
		}
                

		/// <summary>
		/// Removes the element with the specified key from the state.
		/// </summary>
		/// <param name="key">Key of the element to remove from the state.</param>
		public virtual void Remove(string key)
		{
			this.InnerHashtable.Remove(key);			
			// notify registered event listeners that State has changed
			// unless there are listeners, don't try firing
			if ( null != StateChanged )
			{
				StateChanged(this, new StateChangedEventArgs(key));
			}
		}
        

		/// <summary>
		/// Determines whether the state contains a specific key.
		/// </summary>
		/// <param name="key">Key to find in the collection.</param>
		/// <returns>True if the key was found; otherwise false.</returns>
		public virtual bool Contains(string key)
		{
			return this.InnerHashtable.Contains(key);
		}

		/// <summary>
		/// Occurs when the state has been cleared.
		/// </summary>
		protected override void OnClearComplete()
		{
			if (StateChanged != null)
				StateChanged(this, null);
			base.OnClearComplete ();
		}



		/// <summary>
		/// Copies the state elements to a array.
		/// </summary>
		/// <param name="array">The array to copy to. This must be capable of accepting objects of type DictionaryEntry.</param>
		/// <param name="index">The zero-based array where the copying should begin.</param>
		public virtual void CopyTo ( DictionaryEntry[] array , int index )
		{
			if ( null == array )
			{
				throw new ArgumentNullException ( "array" , Resource.ResourceManager[Resource.Exceptions.RES_ExceptionNullArrayInCopyToArray] );
			}
			if ( 1 != array.Rank )
			{
				throw new ArgumentException ( Resource.ResourceManager[Resource.Exceptions.RES_ExceptionInvalidArrayDimensionsInCopyToArray], "array" );
			}
			if ( ( 0 > index ) || ( array.GetUpperBound(0) < index ) || ( array.GetUpperBound(0) < (index + this.InnerHashtable.Count) ) )
			{
				throw new ArgumentOutOfRangeException ( "index", index, Resource.ResourceManager[Resource.Exceptions.RES_ExceptionOutOfBoundsIndexInCopyToArray] );
			}

			try
			{
				//  attempt to copy to array
				foreach (DictionaryEntry de in this.InnerHashtable)
				{
					array.SetValue ( de, index++ );
				}
			}
			catch ( Exception e )
			{
				throw new InvalidCastException ( Resource.ResourceManager[Resource.Exceptions.RES_ExceptionInvalidCastInCopyToArray], e );
			}
					
		}
		#endregion
	}
	#endregion
}
