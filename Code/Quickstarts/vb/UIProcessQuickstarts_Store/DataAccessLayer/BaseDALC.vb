 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' BaseDALC.vb
'
' This file contains the implementations of the BaseDALC class.
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
Imports System.Configuration
Imports System.Reflection
Imports System.Resources
Imports System.Collections.Specialized


Namespace UIProcessQuickstarts_Store
    ' <summary>
    ' This class is intended to be extended by the entity DALCs components in 
    ' order to share behavior between the Entity DALCs.
    ' </summary>
   
   Public Class BaseDALC
      Private Const CONFIG_CONNECTION_STRING As String = "connectionString"
      
        ' <summary>
        ' Keep the connection string from the database
        ' </summary>
      Protected connectionString As String
      
        Protected Shared ResourceManager As New ResourceManager("DALCText", [Assembly].GetExecutingAssembly())
      
      
      Public Sub New()
         ' retrieve the key value pairs from the appParams section of the configuration file
         Dim values As NameValueCollection = CType(ConfigurationSettings.GetConfig("appParams"), NameValueCollection)
         If values Is Nothing Then
            Throw New ConfigurationException(ResourceManager.GetString("RES_ExceptionStoreConfigNotFound"))
         End If 
         ' read the database connection string from the configuration information and store it in the connection
         ' string property
         Dim connectionString As String = values(CONFIG_CONNECTION_STRING)
         If connectionString Is Nothing Then
            Throw New ConfigurationException(ResourceManager.GetString("RES_ExceptionStoreConfigConnection"))
         End If 
         Me.connectionString = connectionString
      End Sub 'New
   End Class 'BaseDALC
End Namespace 'UIProcessQuickstarts_Store