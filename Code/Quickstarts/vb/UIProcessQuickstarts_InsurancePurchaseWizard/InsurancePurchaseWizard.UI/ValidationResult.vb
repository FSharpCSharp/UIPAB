Imports System

Namespace InsurancePurchaseWizard.UI

	Public Class ValidationResult
		Dim m_isValid As Boolean
		Dim m_errorMessage As String

		Public Sub New(ByVal isValid As Boolean, ByVal errorMessage As String)		
			m_isValid = isValid
			m_errorMessage = errorMessage
		End Sub

		Public ReadOnly Property ErrorMessage() As String
			Get

				Return m_errorMessage
			End Get
		End Property
		Public ReadOnly Property IsValid() As Boolean
			Get
				Return m_isValid
			End Get
		End Property
	End Class
end Namespace
