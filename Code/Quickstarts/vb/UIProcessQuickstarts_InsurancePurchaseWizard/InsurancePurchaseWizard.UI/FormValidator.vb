 '===============================================================================
' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' FormValidator.vb
'
' This file contains the implementations of the FormValidator class.
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

Namespace InsurancePurchaseWizard.UI


    Public NotInheritable Class FormValidator

        ' <summary>
        ' Delegate that defines a method that can perform validation against a control
        ' </summary>
        Delegate Function ControlValidator(ByVal control As Control) As Boolean

        Private Sub New()
        End Sub

        ' <summary>
        ' Method that determines whether the contents of a field are valid
        ' </summary>
        ' <param name="errNotifier">ErrorProvider component that will be used to provide error notification</param>
        ' <param name="control">Control that is being validated ( also the one that the ErrorProvider component will
        ' render itself next to if an error occurs.</param>
        ' <param name="errMessage">String containing the error message to show if the validation fails</param>
        ' <param name="validator">Delegate that points to a method that will perform the validation</param>
        ' <returns></returns>
        Public Shared Function FieldIsValid(ByVal errNotifier As ErrorProvider, ByVal control As Control, ByVal errMessage As String, ByVal validator As ControlValidator) As Boolean
            Dim isValid As Boolean = False

            ' invoke the method that will perform the validation against the control
            If Not validator(control) Then
                ' if the validation did not pass then set the error message next to the control
                errNotifier.SetError(control, errMessage)
                isValid = False
            Else
                ' clear the error message associated with the control
                errNotifier.SetError(control, "")
                isValid = True
            End If

            Return isValid
        End Function

        ' <summary>
        ' Method that matches the ControlValidator signature and will perform a check to see if the text property of a control
        ' has been set to anything other than a zero length string
        ' </summary>
        ' <param name="control"></param>
        ' <returns></returns>
        Public Shared Function HasTextValidator(ByVal control As Control) As Boolean
            Return control.Text.Trim().Length > 0
        End Function

        Public Shared Function IsNumericValidator(ByVal control As Control) As Boolean
            Return True
        End Function

    End Class

End Namespace