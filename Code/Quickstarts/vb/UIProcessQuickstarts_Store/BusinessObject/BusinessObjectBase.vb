 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' BusinessObjectBase.vb
'
' This file contains the implementations of the BusinessObjectBase class.
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


Namespace UIProcessQuickstarts_Store
    ' <summary>
    ' This class is intended to be extended by the business rule components in 
    ' order to share behavior between them.
    ' </summary>
   
   Public Class BaseBusinessObject
        Protected Shared ResourceManager As New ResourceManager("BOText", [Assembly].GetExecutingAssembly())
   End Class 'BaseBusinessObject
End Namespace 'UIProcessQuickstarts_Store