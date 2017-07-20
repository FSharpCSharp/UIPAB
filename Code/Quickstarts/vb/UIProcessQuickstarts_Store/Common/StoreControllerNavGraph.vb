 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' StoreControllerNavGraph.vb
'
' This file contains the implementations of the StoreControllerNavGraph class.
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
   
   Public Class StoreControllerNavGraph
      Inherits StoreControllerBase
      
      Public Sub New(navigator As Navigator)
         MyBase.New(navigator)
      End Sub 'New
       
      Public Overrides Sub AddToCart(productId As Integer, quantity As Integer)
         MyBase.AddToCart(productId, quantity)
         Navigate()
      End Sub 'AddToCart
      
      
        ' <summary>
        ' Resumes the shopping task
        ' </summary>
      Public Overrides Sub ResumeShopping()
         '  proceed to next View
         State.NavigateValue = "resume"
         Navigate()
      End Sub 'ResumeShopping
   End Class 'StoreControllerNavGraph
End Namespace 'UIProcessQuickstarts_Store