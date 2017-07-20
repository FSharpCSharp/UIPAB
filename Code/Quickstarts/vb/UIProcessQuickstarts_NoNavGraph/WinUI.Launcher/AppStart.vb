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
Imports System.Windows.Forms

Namespace UIProcessQuickstarts_Store.WinUI

    Public NotInheritable Class AppStart

        Private Sub New()
        End Sub

		<STAThread()> _
		Public Overloads Shared Sub Main(ByVal args() As String)
			AddHandler Application.ThreadException, AddressOf Application_ThreadException
			Application.Run(New logon)
		End Sub

		Private Shared Sub Application_ThreadException(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
			Dim errMessage As String = ""
			Dim tempException As Exception = e.Exception
			
			While Not (tempException Is Nothing)
				errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
				tempException = tempException.InnerException
			End While

			MessageBox.Show(String.Format("There are some problems while trying to use the UIP Application block, please check the following error messages: {0}" _
			 + Environment.NewLine + "You should be sure UIP database scripts was executed over the sql server", errMessage), _
			 "Application error", MessageBoxButtons.OK, MessageBoxIcon.Error)

			Application.Exit()
		End Sub
	End Class

End Namespace
