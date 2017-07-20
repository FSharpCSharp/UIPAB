 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' AppStart.vb
'
' This file contains the implementations of the AppStart class.
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
Imports UIProcessQuickstarts_MultiNavGraph
Imports System.Windows.Forms


Namespace MultiNavGraph.Launcher
    ' <summary>
    ' This class is resonsible for hooking into application thread exceptions and also launching the main form for the
    ' application.
    ' </summary>
   
   NotInheritable Public Class AppStart
      
      
      Private Sub New()
      End Sub 'New
      
      'Entry point which delegates to C-style main Private Function
        'Public Overloads Shared Sub Main()
        '  Main(System.Environment.GetCommandLineArgs())
        ' End Sub
      
      
        ' <summary>
        ' Entry point for the application
        ' </summary>		
      <STAThread()>  _
      Overloads Public Shared Sub Main(args() As String)
         AddHandler Application.ThreadException, AddressOf Application_ThreadException
         Application.Run(New Logon())
      End Sub 'Main
      
      
        ' <summary>
        ' Handler for unhandled exceptions that occur during the course of the application
        ' </summary>
        ' <param name="source"></param>
        ' <param name="e"></param>
      Public Shared Sub Application_ThreadException([source] As Object, e As System.Threading.ThreadExceptionEventArgs)
         Dim errMessage As String = ""
            Dim tempException As Exception
            tempException = e.Exception
            While Not (tempException Is Nothing)
                errMessage = errMessage + tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While
            MessageBox.Show(String.Format("There are some problems while trying to use the UIP Application block, please check the following error messages: {0}" + Environment.NewLine, errMessage), "Application error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Sub 'Application_ThreadException
   End Class 'AppStart
End Namespace 'MultiNavGraph.Launcher