//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// WizardSettings.cs
//
// This file contains the implementations of the WizardSettings class.
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

using System.Collections;
using System.Configuration;
using System.Xml;
using System;
using System.Globalization;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// <para>The settings for a UIP-mediated wizard.</para>
	/// <para>Settings are stored in the app.config.</para>
	/// </summary>
	public class WizardSettings 
	{
		string _name = null;
		private const string AttributeWizardName ="name";
		private const string AttributeSequenceViewName = "view";
		private const string SequenceXPath= "sequence";
		private ArrayList _sequences = null;

		private string _defaultViewManager;
		private string _defaultStatePersistence;
		private string _defaultState;
		
		/// <summary>
		/// Overloaded. Initializes a new instance of WizardSettings that uses the default state persistence and state identified in
		/// the configuration file.
		/// </summary>
		/// <param name="defaultStatePersistence">The default StatePersistence mechanism specified in the configuration file.</param>
		/// <param name="defaultState">The State object to be used as specified in the configuration file.</param>
		public WizardSettings(string defaultStatePersistence, string defaultState)
		{
			_defaultViewManager=typeof(WizardViewManager).Name;
			_defaultStatePersistence=defaultStatePersistence;
			_defaultState=defaultState;
			_sequences = new ArrayList();
		}
			
		/// <summary>
		/// Overloaded. Initializes a new instance of WizardSettings that uses the default state persistence and state identified in
		/// the app.config and configuration details.
		/// </summary>
		/// <param name="defaultStatePersistence">The default StatePersistence mechanism specified in the configuration file.</param>
		/// <param name="defaultState">The State object specified in the configuration file.</param>
		/// <param name="configNode">The XmlNode from the uipWizard element in the configuration file.</param>
		public WizardSettings(string defaultStatePersistence, string defaultState,XmlNode configNode ):this(defaultStatePersistence,defaultState)
		{			
			LoadAttributes(configNode);
			LoadSequences(configNode);
		}

		/// <summary>
		/// Adds a view to the sequence of <see cref="Microsoft.ApplicationBlocks.UIProcess.IView"/> items in the wizard.
		/// </summary>
		/// <param name="viewName">The name of the view.</param>
		public void AddSequence(string viewName)
		{
			_sequences.Add(viewName);
		}

		/// <summary>
		/// The name of the wizard.
		/// </summary>
		public string Name
		{
			get { return _name;}
			set { _name = value;}
		}

		/// <summary>
		/// Gets the number of views that make up the wizard.
		/// </summary>
		public int SequenceCount
		{
			get {return _sequences.Count;}
		}

		/// <summary>
		/// Gets the name of the view at the specified position within the sequence of views.
		/// </summary>
		public string this[int sequenceIndex]
		{
			get {return _sequences[sequenceIndex].ToString();}
		}

		/// <summary>
		/// Gets the first view in the sequence of views.
		/// </summary>
		public string First
		{
			get 
			{
				return _sequences[0].ToString();
			}
		}

		/// <summary>
		/// Gets the last view in the sequence of views.
		/// </summary>
		public string Last
		{
			get 
			{
				return _sequences[_sequences.Count-1].ToString();
			}
		}

		private void LoadAttributes(XmlNode configNode)
		{
			XmlNode wizardNode = configNode.Attributes.RemoveNamedItem(AttributeWizardName);
			
			if( wizardNode.Value.Trim().Length > 0 )
				_name = wizardNode.Value;
			else			
				throw new ConfigurationException(Resource.ResourceManager[Resource.Exceptions.RES_ExceptionInvalidWizardName]);				

		}

		private void LoadSequences(XmlNode configNode)
		{
			foreach ( XmlNode sequenceNode in configNode.SelectNodes( SequenceXPath ) )
			{								
				XmlNode sequenceAttribute = sequenceNode.Attributes.RemoveNamedItem(AttributeSequenceViewName);
				_sequences.Add(sequenceAttribute.Value);				
			}
		}

		/// <summary>
		/// Gets all of the names that make up the sequence of views.
		/// </summary>
		/// <returns>The array of views within the sequence of views.</returns>
		public string[] GetSequenceViewNames()
		{
			return (string[])_sequences.ToArray(typeof(string));
		}

		/// <summary>
		/// Converts wizard settings to a NavGraph xmlNode to be used by <see cref="Microsoft.ApplicationBlocks.UIProcess.NavigationGraphSettings"/>.
		/// </summary>
		/// <param name="formatProvider">The format provider.</param>
		/// <returns>The created XmlNode.</returns>
		public XmlNode GetNavGraphXmlNode(IFormatProvider formatProvider)
		{
			
			string xml = GetNavGraphXml(formatProvider as CultureInfo);

			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.InnerXml = xml;

			return xmlDoc.FirstChild;
		}

		/// <summary>
		/// Converts wizard settings to an XML string that can be converted to an XmlNode.		
		/// </summary>
		/// <param name="cultureInfo">The culture for which formatting applies.</param>
		/// <returns>The XML string.</returns>
		public string GetNavGraphXml(CultureInfo cultureInfo)
		{
			if(cultureInfo == null) 
			{
				cultureInfo = CultureInfo.InvariantCulture;
			}
			System.IO.StringWriter stream = new System.IO.StringWriter(cultureInfo);
			XmlTextWriter writer = new XmlTextWriter(stream);
			writer.WriteStartElement("navigationGraph");
			writer.WriteAttributeString(NavigationGraphSettings.AttributeName, Name);
			writer.WriteAttributeString(NavigationGraphSettings.AttributeRunInWizardMode, true.ToString().ToLower(cultureInfo));
			writer.WriteAttributeString(NavigationGraphSettings.AttributeStartView, _sequences[0].ToString());
			writer.WriteAttributeString(NavigationGraphSettings.AttributeEndView, _sequences[_sequences.Count - 1].ToString());
			writer.WriteAttributeString(NavigationGraphSettings.AttributeIViewManager,_defaultViewManager);
			writer.WriteAttributeString(NavigationGraphSettings.AttributeStatePersist,_defaultStatePersistence);
			writer.WriteAttributeString(NavigationGraphSettings.AttributeState,_defaultState);
			string[] viewNames = GetSequenceViewNames();
			if(viewNames.Length >1)
			{
				for(int i=0; i < viewNames.Length; i++)
				{
					writer.WriteStartElement(NavigationGraphSettings.NodeXPath);
					writer.WriteAttributeString(NodeSettings.AttributeView,viewNames[i]);
					if( i < viewNames.GetUpperBound(0)) 
					{
						writer.WriteStartElement(NodeSettings.NodeNavigateTo);
						writer.WriteAttributeString(NavigateToSettings.AttributeNavigateValue,"next");
						writer.WriteAttributeString(NavigateToSettings.AttributeView,viewNames[i+1]);
						writer.WriteEndElement();
					}				
					else
					{
						writer.WriteStartElement(NodeSettings.NodeNavigateTo);
						writer.WriteAttributeString(NavigateToSettings.AttributeNavigateValue,"next");
						writer.WriteAttributeString(NavigateToSettings.AttributeView,viewNames[i]);
						writer.WriteEndElement();
					}
					writer.WriteEndElement();
				}
			}
			writer.WriteEndElement();

			writer.Flush();
			writer.Close();
			return stream.ToString();
		}
	}
}
