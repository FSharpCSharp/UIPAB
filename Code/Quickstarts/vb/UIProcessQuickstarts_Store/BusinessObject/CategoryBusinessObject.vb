 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' CategoryBusinessObject.vb
'
' This file contains the implementations of the CategoryBusinessObject class.
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


Namespace UIProcessQuickstarts_Store
    ' <summary>
    ' This class contains all the category related business rules
    ' </summary>
   
   Public Class CategoryBusinessObject
      Inherits BaseBusinessObject
      
      Public Sub New()
      End Sub 'New
      
      
        ' <summary>
        ' Gets all available product categories
        ' </summary>
        Public Function GetAllCategories(ByVal McategoryDS As CategoryDS, ByVal from As Integer, ByVal count As Integer) As Boolean
            Try
                Dim McategoryDALC As New CategoryDALC
                Return McategoryDALC.GetAllCategories(McategoryDS, from, count)
            Catch e As Exception
                Throw New ApplicationException(ResourceManager.GetString("RES_ExceptionCantGetCategories"), e)
            End Try
        End Function 'GetAllCategories
    End Class 'CategoryBusinessObject
End Namespace 'UIProcessQuickstarts_Store