//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// ViewSettings.cs
//
// This file contains the implementations of the ViewSettings class.
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
using System.Configuration;
using System.Xml;
using System.Xml.XPath;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// The ViewSettings capture the configuration information for a specific view (a view is a class that implements the 
	/// <see cref="Microsoft.ApplicationBlocks.UIProcess.IView"/> interface).
	/// </summary>
	public class ViewSettings : ObjectTypeSettings
	{
		#region Declares Variables
		private const string AttributeController = "controller";
		private const string AttributeStayOpen = "stayOpen";        
		private const string AttributeOpenModal = "openModal";
		private const string AtributeLayoutManager = "layoutManager";
		private const string AttributeFloatable = "floatable";
		private const string AttributeCanHaveFloatingWindows = "canHaveFloatingWindows";
		private string _controller;
		private string _layoutManager;
		private bool _canHaveFloatingWindows = false;
		private bool _isFloatable = false;
		private bool _isStayOpen = false;       
		private bool _isOpenModal = false;
		private XPathNavigator _navigator;
		private XmlNode _node;
		#endregion

		#region Constructor
		/// <summary>
		/// Overloaded. Default constructor.
		/// </summary>
		public ViewSettings( ) : base( )
		{
		}

		/// <summary>
		/// Overloaded. Initialized a new instance of the ViewSettings class using the specified configNode.
		/// </summary>
		/// /// <param name="configNode">XmlNode from the configuration file.</param>
		public ViewSettings(XmlNode configNode) : this(configNode, System.Globalization.CultureInfo.CurrentCulture)
		{
			
		}

		/// <summary>
		/// Creates an instance of ViewSettings using the specified configNode and IFormatProvider. 
		/// </summary>
		/// <param name="configNode">The XmlNode from the configuration file.</param>
		/// <param name="formatProvider">The IFormatProvider required for globalization.</param>
		public ViewSettings(XmlNode configNode, IFormatProvider formatProvider) : base(configNode)
		{
			LoadAttributes(configNode, formatProvider);
			_node = configNode;
		}
		
		private bool GetBooleanAttribute(XmlNode configNode, string attributeName) 
		{
		   	XmlNode currentAttribute = configNode.Attributes.RemoveNamedItem(attributeName);
		   	if(IsValidAttribute(currentAttribute))
		   	   return XmlConvert.ToBoolean(currentAttribute.Value);
		   	return false;
		}
		      


		private void LoadAttributes(XmlNode configNode, IFormatProvider formatProvider)
		{
		       _isFloatable = GetBooleanAttribute(configNode, AttributeFloatable);
		        _canHaveFloatingWindows = GetBooleanAttribute(configNode, AttributeCanHaveFloatingWindows);
		        if(_isFloatable && _canHaveFloatingWindows)
		           throw new ConfigurationException(Resource.ResourceManager.FormatMessage(Resource.Exceptions.RES_ExceptionConflictingFloatingWindowsAttribute, AttributeFloatable, AttributeCanHaveFloatingWindows));

			LoadControllerAttribute(configNode);
			LoadStayOpenAttribute(configNode);
			LoadOpenModalAttribute(configNode);
			LoadLayoutManagerAttribute(configNode,formatProvider);
			_navigator = configNode.CreateNavigator();
		}

		private void LoadLayoutManagerAttribute(XmlNode configNode, IFormatProvider formatProvider)
		{
			XmlNode currentAttribute;
			currentAttribute = configNode.Attributes.RemoveNamedItem(AtributeLayoutManager);
			if( IsValidAttribute(currentAttribute) )
				_layoutManager = currentAttribute.Value.ToString(formatProvider);
		}

		private bool IsValidAttribute(XmlNode currentAttribute)
		{
			return currentAttribute != null && currentAttribute.Value.Trim().Length > 0;
		}

		private void LoadOpenModalAttribute(XmlNode configNode)
		{
			XmlNode currentAttribute;
			currentAttribute = configNode.Attributes.RemoveNamedItem(AttributeOpenModal);
			if( IsValidAttribute(currentAttribute) )
				_isOpenModal = XmlConvert.ToBoolean(currentAttribute.Value);
		}

		private void LoadStayOpenAttribute(XmlNode configNode)
		{
			XmlNode currentAttribute;
			currentAttribute = configNode.Attributes.RemoveNamedItem(AttributeStayOpen);
			if( IsValidAttribute(currentAttribute) )
				_isStayOpen = XmlConvert.ToBoolean(currentAttribute.Value);
		}

		private void LoadControllerAttribute(XmlNode configNode)
		{
			XmlNode currentAttribute;
			currentAttribute = configNode.Attributes.RemoveNamedItem(AttributeController);
			if( IsValidAttribute(currentAttribute) )
				_controller = currentAttribute.Value;
			else
				throw new ConfigurationException( Resource.ResourceManager.FormatMessage( Resource.Exceptions.RES_ExceptionInvalidXmlAttributeValue, AttributeController, configNode.Name ) );
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the controller name related to this view.
		/// </summary>
		public string Controller
		{
			get { return _controller; }
		}

		/// <summary>
		/// Specifies if the windows should stay open when the Navigate
		/// method is invoked.
		/// </summary>
		public bool IsStayOpen
		{
			get { return _isStayOpen; }
		}

		/// <summary>
		/// Gets a value that indicates if this view is displayed modally.
		/// </summary>
		public bool IsOpenModal
		{
			get {return _isOpenModal;}
		}

		/// <summary>
		/// Gets a value that indicates the layout manager for this view.
		/// </summary>
		public string LayoutManager
		{
			get {return _layoutManager;}
		}

		/// <summary>
		/// Gets the XPathNavigator that can be used to traverse the XmlNode that defines the view. 
		/// </summary>
		public XPathNavigator Navigator
		{
			get { return _navigator; }
		}
		
		/// <summary>
		/// Returns true if the view can be a floating window; if not, returns false.
		/// </summary>
		public bool IsFloatable
		{
		   	get { return _isFloatable; }
		}

		/// <summary>
		/// Returns true if the view can be a parent for floating windows; if not, returns false.
		/// </summary>
		public bool CanHaveFloatingWindows
		{
		   	get { return _canHaveFloatingWindows; }
		}

		/// <summary>
		/// Gets the collection of custom attributes defined in the app.config. 
		/// </summary>
		public XmlAttributeCollection CustomAttributes 
		{
			get { return _node.Attributes; }
		}

		/// <summary>
		/// Gets the child nodes that make up the View element in the app.config.
		/// </summary>
		public XmlNodeList ChildNodes 
		{
			get { return _node.ChildNodes; }
		}

		#endregion
	}
}
