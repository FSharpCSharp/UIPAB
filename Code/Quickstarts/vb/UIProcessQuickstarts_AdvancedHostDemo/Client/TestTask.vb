 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' TestTask.vb
'
' This file contains the implementations of the TestTask class.
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
Imports Microsoft.ApplicationBlocks.UIProcess

Namespace Client

    Public Class TestTask
        Implements ITask
        Private taskId As Guid = Guid.Empty

        Public Sub New()

        End Sub
#Region "ITask Members"

        Public Sub Create(ByVal taskId As Guid) Implements ITask.Create
            Me.taskId = taskId
        End Sub

        Public Function [Get]() As Guid Implements ITask.Get
            Return taskId
        End Function

#End Region

    End Class

End Namespace