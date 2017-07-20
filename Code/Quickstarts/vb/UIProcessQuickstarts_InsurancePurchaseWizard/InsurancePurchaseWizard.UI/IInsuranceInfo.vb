 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' IInsuranceInfo.vb
'
' This file contains the defintion of the IInsuranceInfo interface.
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

Namespace InsurancePurchaseWizard.UI

    ' <summary>
    ' Defines a method to return insurance information
    ' </summary>
    Public Interface IInsuranceInfo
        Function GetInsuranceInfo() As String
    End Interface

End Namespace