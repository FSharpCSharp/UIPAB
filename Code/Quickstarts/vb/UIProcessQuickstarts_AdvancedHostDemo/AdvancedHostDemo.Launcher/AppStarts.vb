 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' AppStarts.vb
'
' This file contains the implementations of the AppStarts class.
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
Imports System.Windows.Forms
Imports Client
Imports Microsoft.ApplicationBlocks.UIProcess

Namespace AdvancedHostDemo.Launcher

    ' <summary>
    ' Launcher for the application
    ' </summary>
    Public Class AppStart

        <STAThread()> _
        Public Shared Sub Main()
            ' add the hook to catch all unhandled exceptions
            AddHandler Application.ThreadException, AddressOf Application_ThreadException
            Application.Run(New Client.StartMeUp)
        End Sub

        Private Shared Sub Application_ThreadException(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
            ' show the error message to the user and exit the application			
            MessageBox.Show(e.Exception.Message)
            Application.Exit()
        End Sub

    End Class

End Namespace
