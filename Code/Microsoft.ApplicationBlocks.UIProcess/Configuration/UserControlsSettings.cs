//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// HostedControlsSettings.cs
//
// This file contains the implementations of the HostedControlsSettings class.
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
	/// The UserControls settings capture the configuration information for a specific user controls
	/// navigator.
	/// </summary>
	public class UserControlsSettings : NavigatorSettings
	{
		private const string FormXPath = "form";
		private string _startForm;
		private HybridDictionary _forms;

		/// <summary>
		/// Creates a new HostedControlsSettings object.
		/// </summary>
		public UserControlsSettings()
		{
			_forms = new HybridDictionary();
		}

		/// <summary>
		/// Creates a new HostedControlsSettings object, and initializes it using the XmlNode from the configuration file.
		/// </summary>
		/// <param name="configNode">The XmlNode from the configuration file.</param>
		public UserControlsSettings(XmlNode configNode) : this() 
		{
			LoadAttributes(configNode);
			_startForm = configNode.Attributes["startForm"].Value;

			foreach ( XmlNode formNode in configNode.SelectNodes( FormXPath ) ) 
			{
				FormSettings formSettings = new FormSettings(formNode);
				_forms[formSettings.Name] = formSettings;
			}
		}

		/// <summary>
		/// The name of the form to start on.
		/// </summary>
		public string StartFormName 
		{
			get { return _startForm; }
		}

		/// <summary>
		/// Returns the FormSettings class for the named form.
		/// </summary>
		/// <param name="name">The name of the form to retrieve the settings for.</param>
		public FormSettings this[string name]
		{
			get { return (FormSettings) _forms[name]; }
		}

	}

	/// <summary>
	/// Represents the configuration file settings for a form in the HostedControls section of the configuration file.
	/// </summary>
	public class FormSettings 
	{
		private const string ChildViewXPath = "childView";
		private string _name;
		private string _initialView;
		private HybridDictionary _childSettings;

		/// <summary>
		/// Creates an instance of a FormSettings object based on information from the configuration file.
		/// </summary>
		/// <param name="configNode">The XmlNode from the configuration file.</param>
		public FormSettings(XmlNode configNode) 
		{
			_childSettings = new HybridDictionary();
			_name = configNode.Attributes["name"].Value;
			if (configNode.Attributes["initialView"] != null) 
			{
				_initialView = configNode.Attributes["initialView"].Value;
			}

			foreach (XmlNode childNode in configNode.SelectNodes( ChildViewXPath ) )
			{
				ChildViewSettings childView = new ChildViewSettings(childNode);
				_childSettings[childView.Name] = childView;
			}
		}

		/// <summary>
		/// The name of the form. Must correspond to a name in the Views section of the configuration file.
		/// </summary>
		public string Name 
		{
			get { return _name; }
		}

		/// <summary>
		/// The first control to start on. Optional.
		/// </summary>
		public string InitialView 
		{
			get { return _initialView; }
		}

		/// <summary>
		/// Gets the ChildViewSettings for a control with that name.
		/// </summary>
		/// <param name="name">The control to retrieve the settings for.</param>
		public ChildViewSettings this[string name] 
		{
			get { return (ChildViewSettings) _childSettings[name]; }
		}
	}

	/// <summary>
	/// Represents a childview (WinFormControlView) on a form.
	/// </summary>
	public class ChildViewSettings 
	{
		private string _name;
		private string _viewName;

		/// <summary>
		/// Creates a ChildViewSettings object based on information from the configuration file.
		/// </summary>
		/// <param name="configNode">XmlNode that contains the configuration information for this
		/// object</param>
		public ChildViewSettings(XmlNode configNode) 
		{
			_name = configNode.Attributes["name"].Value;
			_viewName = configNode.Attributes["viewName"].Value;
		}

		/// <summary>
		/// The name of the control.
		/// </summary>
		public string Name 
		{
			get { return _name; }
		}

		/// <summary>
		/// The name of the view in the ViewSettings section of the configuration file.
		/// </summary>
		public string ViewName 
		{
			get { return _viewName; }
		}

	}
}
