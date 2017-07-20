
Imports System

Namespace Client
   
   Public Class PersonChangedEventArgs
      Inherits EventArgs
		Private objPerson As Client.EmployeeData.PersonRow

		Public Sub New(ByVal objPerson As Client.EmployeeData.PersonRow)
			Me.objPerson = objPerson
		End Sub

		Public ReadOnly Property Person() As Client.EmployeeData.PersonRow
			Get
				Return objPerson
			End Get
		End Property
	End Class

End Namespace