//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// NavigationGraphSettings.cs
//
// This file contains the implementations of the NavigationGraphSettings class.
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
using System.Configuration;
using System.Collections.Specialized;
using System.Xml;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// Represents the settings defined by the navigationGraph element in the configuration file.
	/// </summary>
	public class NavigationGraphSettings : NavigatorSettings
	{
		#region Declares variables
		/// <summary>
		/// Key used to retrieve the startView attribute for this NavigationGraphSettings object from
		/// the configuration file.
		/// </summary>
		internal const string AttributeStartView = "startView";
		/// <summary>
		/// Key used to retrieve the endView attribute for this NavigationGraphSettings object.
		/// </summary>
		internal const string AttributeEndView = "endView";
		/// <summary>
		/// Key used to retrieve the runInWizardMode attribute for this NavigationGraphSettings object.
		/// </summary>
		internal const string AttributeRunInWizardMode = "runInWizardMode";
		/// <summary>
		/// XPath expression used to retrieve the nodes that are defined for this NavigationGraphSettings
		/// object.
		/// </summary>
		internal const string NodeXPath = "node";
		/// <summary>
		/// XPath expression used to retrieve the shared transitions that are defined for this NavigationGraphSettings
		/// object.
		/// </summary>
		internal const string SharedTransitionsXPath= "sharedTransitions/sharedTransition";


		private bool _runInWizardMode;
		private string _startView;
		private string _endView;
		private Hashtable _views;
		private HybridDictionary _sharedTransitions;

		#endregion

		#region Constructor
		/// <summary>
		/// Default constructor.
		/// </summary>
		public NavigationGraphSettings( )
		{
			_views = new Hashtable();
			_sharedTransitions = new HybridDictionary();
		}

		/// <summary>		
		/// Creates an instance of the NavigationGraphSettings class using the specified configNode.		
		/// </summary>
		/// <param name="configNode">The XmlNode from the configuration file.</param>
		public NavigationGraphSettings( XmlNode configNode ):this()
		{
			LoadAttributes(configNode);
            
			LoadViews(configNode);

			LoadSharedTransitions(configNode);
		}

		private void LoadSharedTransitions(XmlNode configNode)
		{			
			foreach ( XmlNode currentNode in configNode.SelectNodes( SharedTransitionsXPath ) )
			{
				SharedTransitionSettings sharedTransition = new SharedTransitionSettings( currentNode ) ;

				if (! _sharedTransitions.Contains( sharedTransition.NavigateValue ) )
				{
					_sharedTransitions.Add(sharedTransition.NavigateValue, sharedTransition);
				}
				else
					throw new ConfigurationException( Resource.ResourceManager.FormatMessage(Resource.Exceptions.RES_ExceptionDuplicateNavigateGraphSharedTransition,sharedTransition.NavigateValue,this.Name));					
			}
		}


		private void LoadViews(XmlNode configNode)
		{		
			foreach( XmlNode currentNode in configNode.SelectNodes( NodeXPath ) )
			{
				NodeSettings node = new NodeSettings( currentNode );
				_views.Add( node.View, node );
			}
		}

		/// <summary>
		/// Overridden. Loads the attributes for the navigation graph specified in the configuration file.
		/// </summary>
		/// <param name="configNode">The XmlNode from the configuration file.</param>
		protected override void LoadAttributes(XmlNode configNode)
		{
			XmlNode currentAttribute;

			currentAttribute = configNode.Attributes.RemoveNamedItem(AttributeRunInWizardMode);
			if(currentAttribute != null && currentAttribute.Value.Trim().Length > 0 )
				_runInWizardMode = bool.Parse(currentAttribute.Value);
		
			
			if ( _runInWizardMode )
			{
				//Read endView attribute
				currentAttribute = configNode.Attributes.RemoveNamedItem(AttributeEndView);
				if( currentAttribute.Value.Trim().Length > 0 )
					_endView = currentAttribute.Value;
				else
					throw new ConfigurationException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionInvalidXmlAttributeValue, AttributeEndView, configNode.Name ) );

				base.LoadAttributes(configNode);

			}
			else
			{
				base.LoadAttributes(configNode);
			}

			//Read startView attribute
			currentAttribute = configNode.Attributes.RemoveNamedItem(AttributeStartView);
			if( currentAttribute.Value.Trim().Length > 0 )
				_startView = currentAttribute.Value;
			else
				throw new ConfigurationException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionInvalidXmlAttributeValue, AttributeStartView, configNode.Name ) );

			
		}
		#endregion

		#region Properties
		/// <summary>
		/// Returns true if the navigation graph is to be used for a wizard; otherwise, returns false.
		/// </summary>
		public bool RunInWizardMode
		{
			get {return _runInWizardMode;}
		}
		/// <summary>
		/// Gets <see cref="Microsoft.ApplicationBlocks.UIProcess.NodeSettings"/> for the specified view.
		/// </summary>
		public NodeSettings this[ string view ]
		{
			get{ return (NodeSettings)_views[ view ]; }
		}

		/// <summary>
		/// Gets the first <see cref="Microsoft.ApplicationBlocks.UIProcess.NodeSettings"/> configured in the navigation graph.
		/// </summary>
		public NodeSettings FirstView
		{
			get { return (NodeSettings)_views[_startView]; }
		}

		/// <summary>
		/// Gets the last <see cref="Microsoft.ApplicationBlocks.UIProcess.NodeSettings"/> configured in the navigation graph.
		/// </summary>
		public NodeSettings LastView
		{
			get { return (NodeSettings)_views[_endView]; }
		}

		/// <summary>
		/// Returns an array <see cref="Microsoft.ApplicationBlocks.UIProcess.NodeSettings"/> for each node specfied in the navigation graph.
		/// </summary>
		/// <returns>The settings.</returns>
		public NodeSettings[] Views()
		{
			NodeSettings[] results = new NodeSettings[_views.Count];
			_views.Values.CopyTo(results,0);
			return results;
		}

		/// <summary>
		/// Returns an array of <see cref="Microsoft.ApplicationBlocks.UIProcess.SharedTransitionSettings"/> for the navigation graph.
		/// </summary>
		/// <returns>The array of shared transition settings.</returns>
		public SharedTransitionSettings[] SharedTransitions()
		{
			SharedTransitionSettings[] results = new SharedTransitionSettings[_sharedTransitions.Count];
			_sharedTransitions.Values.CopyTo(results,0);
			return results;
		}

		#endregion

		#region Get Methods
		/// <summary>
		/// Returns the <see cref="Microsoft.ApplicationBlocks.UIProcess.SharedTransitionSettings"/> for the specified navigate value.
		/// </summary>
		/// <param name="navigateValue">The navigate value.</param>
		/// <returns></returns>
		public SharedTransitionSettings GetSharedTransitionSettings( string navigateValue )
		{
			SharedTransitionSettings sharedTransition=(SharedTransitionSettings)_sharedTransitions[ navigateValue ];

			return sharedTransition;
		}
		#endregion
	}
}
