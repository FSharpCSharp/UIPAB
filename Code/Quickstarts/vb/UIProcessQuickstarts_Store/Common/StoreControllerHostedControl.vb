 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' StoreControllerHostedControl.vb
'
' This file contains the implementations of the StoreControllerHostedControl class.
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
Imports System.Resources
Imports System.Reflection

Imports UIProcessQuickstarts_Store
Imports Microsoft.ApplicationBlocks.UIProcess



Namespace UIProcessQuickstarts_Store
    ' <summary>
    ' The controller used by the store application
    ' </summary>
   
   Public Class StoreControllerHostedControl
      Inherits StoreControllerBase
      
      Public Sub New(navigator As Navigator)
         MyBase.New(navigator)
      End Sub 'New
       
        ' <summary>
        ' Resumes the shopping task
        ' </summary>
      Public Overrides Sub ResumeShopping()
            State.NavigateValue = "StoreForm"
         Navigate()
      End Sub 'ResumeShopping
      
      
      Public Overrides Sub StopShopping()
      End Sub 'StopShopping
   End Class 'StoreControllerHostedControl 
End Namespace 'UIProcessQuickstarts_Store