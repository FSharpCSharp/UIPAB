
Imports System
Imports Microsoft.ApplicationBlocks.UIProcess

Namespace Client

    ' <summary>
    ' Base class for the two controllers that are used in this quickstart, contains functionality that is common
    ' to both controllers.
    ' </summary>
    Public Class PersonControllerBase
        Inherits ControllerBase
        ' constant definitions
        Public Const STATE_SELECTEDPERSON As String = "selectedperson"		
		Private Const STATE_EMPLOYEEDATA As String = "EmployeeData"
		Private Const DATA_FILENAME As String = "people.xml"
		Private Shared _dataFile As String
        ' signature for custom event
        Delegate Sub PersonChangedHandler(ByVal sender As Object, ByVal e As PersonChangedEventArgs)

        ' events that are published by the controller
        Public Event SelectedPersonChanged As PersonChangedHandler

#Region "Constructors"

        Public Sub New(ByVal navigator As Navigator)
            MyBase.New(navigator)
            AddHandler State.StateChanged, AddressOf State_StateChanged
        End Sub

#End Region
		Protected Shared ReadOnly Property DataFile() As String
			Get
				If (_dataFile Is Nothing OrElse _dataFile.Trim.Length = 0) Then
					_dataFile = System.Environment.CurrentDirectory.ToLower()					
					_dataFile = _dataFile.Replace("\bin", "\")
					_dataFile = _dataFile.Replace("/", "\") & DATA_FILENAME
				End If

				Return _dataFile
			End Get
		End Property

		' <summary>
		' Enable the controller to check for changes to the state object, in this case we want to ensure
		' that whenever the selected person changes that we raise our own custom event that can be handled by
		' the view that we are currently interacting with. This isolates the view from needed to know what state
		' change events are useful or not
		' </summary>
		' <param name="sender"></param>
		' <param name="e"></param>
		Private Sub State_StateChanged(ByVal sender As Object, ByVal e As StateChangedEventArgs)
			If e.Key.ToUpper() = STATE_SELECTEDPERSON.ToUpper() Then
				OnSelectedPersonChanged(New PersonChangedEventArgs(Me.SelectedPerson))
			End If
		End Sub



		' <summary>
		' Method used to raise the event that will notify a view attached to this controller 
		' that the selected person has changed
		' </summary>
		' <param name="e"></param>
		Protected Overridable Sub OnSelectedPersonChanged(ByVal e As PersonChangedEventArgs)
			If Not Me.SelectedPersonChangedEvent Is Nothing Then
				RaiseEvent SelectedPersonChanged(Me, e)
			End If
		End Sub

		' <summary>
		' Property used to encapsulate the dataset that is used for this sample
		' </summary>
		Protected Property EmployeeData() As EmployeeData
			Get
				' check to ensure that the dataset has been loaded into the state object
				If Not EmployeeDataIsLoaded() Then
					' load the employee information from the XML file
					LoadEmployeeData()
				End If

				Return DirectCast(State(STATE_EMPLOYEEDATA), EmployeeData)
			End Get
			Set(ByVal value As EmployeeData)
				State(STATE_EMPLOYEEDATA) = value
			End Set
		End Property

		' <summary>
		' Method used to verify whether or not the data has been loaded from the XML file into the state object
		' </summary>
		' <returns></returns>
		Private Function EmployeeDataIsLoaded() As Boolean
			Return Not (State(STATE_EMPLOYEEDATA) Is Nothing)
		End Function

		' <summary>
		' Method used to load the data used from the sample xml file into the state object
		' </summary>
		' <returns></returns>
		Private Function LoadEmployeeData() As EmployeeData
			' instantiate the strongly typed dataset object and load it from the XML file
			Dim data = New EmployeeData
			data.ReadXml(DataFile)
			data.AcceptChanges()

			' store the dataset into the state object
			State(STATE_EMPLOYEEDATA) = data

			Return data
		End Function

		' <summary>
		' Property to encapsulate the person who is currently being worked with in the application
		' </summary>
		Public Property SelectedPerson() As EmployeeData.PersonRow
			Get
				Return DirectCast(State(STATE_SELECTEDPERSON), EmployeeData.PersonRow)
			End Get
			Set(ByVal value As EmployeeData.PersonRow)
				State(STATE_SELECTEDPERSON) = value
			End Set
		End Property

		' <summary>
		' Method used to encapsulate access to the employee table in the dataset
		' </summary>
		' <returns></returns>
		Public Function GetEmployees() As EmployeeData.PersonDataTable
			Return EmployeeData.Person
		End Function

		' <summary>
		' Method used to add a subscriber that is interested in knowing about changes that occure to people in
		' the employee table
		' </summary>
		' <param name="notifier">Delegate that will be invoked when a change in an employee row occurs</param>
		Public Sub SubscribeForChangesToPeople(ByVal notifier As Client.EmployeeData.PersonRowChangeEventHandler)
			AddHandler Me.EmployeeData.Person.PersonRowChanged, notifier
		End Sub

	End Class

End Namespace