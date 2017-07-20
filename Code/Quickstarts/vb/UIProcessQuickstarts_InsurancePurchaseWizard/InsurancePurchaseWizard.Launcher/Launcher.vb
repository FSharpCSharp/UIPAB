 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' Launcher.vb
'
' This file contains the implementations of the Launcher class.
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

Namespace InsurancePurchaseWizard.Launcher

    ' <summary>
    ' Class that is responsible for starting the main screen for the application.
    ' </summary>
    Public NotInheritable Class Launcher

        ' <summary>
        ' Entry point for the application
        ' </summary>
        Private Sub New()
        End Sub


        ' <summary>
        ' Entry point for the application.
        ' </summary>
        <STAThread()> _
        Public Shared Sub Main()
            AddHandler Application.ThreadException, AddressOf Application_ThreadException
            Application.Run(New InsurancePurchaseWizard.UI.Welcome)
        End Sub


        Private Shared Sub Application_ThreadException(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
            MessageBox.Show(e.Exception.Message)
            Application.Exit()
        End Sub
    End Class

End Namespace