 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' State1.vb
'
' This file contains the implementations of the State1 class.
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
Imports System.Runtime.Serialization

Imports Microsoft.ApplicationBlocks.UIProcess


Namespace UIProcessQuickstarts_MultiNavGraph
    ' <summary>
    ' A specialized state class
    ' </summary>
   <Serializable()>  _
   Public Class State1
      Inherits State
      Private _previousNavGraph As String = ""
      Private _previousTaskID As Guid = Guid.Empty
      Private Shared _latestInstance As State
      Private Shared _staticPreviousTaskID As Guid
      
      
      Public Sub New()
      End Sub 'New
      
      Public Sub New(spp As IStatePersistence)
         MyBase.New(spp)
         _latestInstance = Me
      End Sub 'New
       
        ' <summary>
        ' Serialization constructor
        ' </summary>
      Protected Sub New(si As SerializationInfo, context As StreamingContext)
         MyBase.New(si, context)
         Me._previousNavGraph = si.GetString("_previousNavGraph")
         Me._previousTaskID = New Guid(si.GetString("_previousTaskID"))
      End Sub 'New
      
        ' <summary>
        ' Gets/Sets the previous task id
        ' </summary>
      
      Public Property PreviousTaskID() As Guid
         Get
            Return _previousTaskID
         End Get
            Set(ByVal value As Guid)
                _previousTaskID = value
                _staticPreviousTaskID = value
            End Set
        End Property
        ' <summary>
        ' Gets/Sets the previous navigation graph
        ' </summary>
      
      Public Property PreviousNavGraph() As String
         Get
            Return _previousNavGraph
         End Get
            Set(ByVal value As String)
                _previousNavGraph = value
            End Set
        End Property
      
      Public Shared ReadOnly Property LatestInstance() As State
         Get
            Return _latestInstance
         End Get
      End Property
      
      Public Shared ReadOnly Property StaticPreviousTaskID() As Guid
         Get
            Return _staticPreviousTaskID
         End Get
      End Property
      #Region "ISerializable Members"
      
      
        ' <summary>
        ' Restore the object state
        ' </summary>
      Public Overrides Sub GetObjectData(info As SerializationInfo, context As StreamingContext)
         
         MyBase.GetObjectData(info, context)
         info.AddValue("_previousNavGraph", _previousNavGraph)
         info.AddValue("_previousTaskID", _previousTaskID.ToString())
      End Sub 'GetObjectData
      
      #End Region
   End Class 'State1
End Namespace 'UIProcessQuickstarts_MultiNavGraph