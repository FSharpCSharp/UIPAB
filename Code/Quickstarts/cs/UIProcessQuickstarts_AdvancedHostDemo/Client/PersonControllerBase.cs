using System;
using Microsoft.ApplicationBlocks.UIProcess;

namespace Client
{

	/// <summary>
	/// Base class for the two controllers that are used in this quickstart, contains functionality that is common
	/// to both controllers.
	/// </summary>
	public class PersonControllerBase : ControllerBase
	{
		// constant definitions
		public const string STATE_SELECTEDPERSON = "selectedperson";		
		protected const string DATAFILE = "people.xml";		
		private const string STATE_EMPLOYEEDATA = "EmployeeData";

		// signature for custom event
		public delegate void PersonChangedHandler(object sender,PersonChangedEventArgs e);

		// events that are published by the controller
		public event PersonChangedHandler SelectedPersonChanged;

		#region "Constructors"

		public PersonControllerBase(Navigator navigator) : base(navigator) 
		{
			State.StateChanged+=new Microsoft.ApplicationBlocks.UIProcess.State.StateChangedEventHandler(State_StateChanged);
		}

		#endregion

		/// <summary>
		/// Enable the controller to check for changes to the state object, in this case we want to ensure
		/// that whenever the selected person changes that we raise our own custom event that can be handled by
		/// the view that we are currently interacting with. This isolates the view from needed to know what state
		/// change events are useful or not
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void State_StateChanged(object sender, StateChangedEventArgs e)
		{
			if (e.Key.ToUpper() == STATE_SELECTEDPERSON.ToUpper())
			{
				OnSelectedPersonChanged(new PersonChangedEventArgs(this.SelectedPerson));
			}
		}

		/// <summary>
		/// Method used to raise the event that will notify a view attached to this controller 
		/// that the selected person has changed
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnSelectedPersonChanged(PersonChangedEventArgs e)
		{
			if (SelectedPersonChanged != null)
			{
				SelectedPersonChanged(this,e);
			}			
		}

		/// <summary>
		/// Property used to encapsulate the dataset that is used for this sample
		/// </summary>
		protected EmployeeData EmployeeData
		{
			get
			{
				// check to ensure that the dataset has been loaded into the state object
				if (! EmployeeDataIsLoaded())
				{
					// load the employee information from the XML file
					LoadEmployeeData();
				}
				
				return (EmployeeData)State[STATE_EMPLOYEEDATA];
			}
			set
			{
				State[STATE_EMPLOYEEDATA] = value;
			}
		}

		/// <summary>
		/// Method used to verify whether or not the data has been loaded from the XML file into the state object
		/// </summary>
		/// <returns></returns>
		private bool EmployeeDataIsLoaded()
		{
			return (State[STATE_EMPLOYEEDATA] != null);
		}

		/// <summary>
		/// Method used to load the data used from the sample xml file into the state object
		/// </summary>
		/// <returns></returns>
		private EmployeeData LoadEmployeeData()
		{
			// instantiate the strongly typed dataset object and load it from the XML file
			Client.EmployeeData data = new EmployeeData();			
			data.ReadXml(DATAFILE);			
			data.AcceptChanges();

			// store the dataset into the state object
			State[STATE_EMPLOYEEDATA] = data;
			
			return data;
		}

		/// <summary>
		/// Property to encapsulate the person who is currently being worked with in the application
		/// </summary>
		public EmployeeData.PersonRow SelectedPerson
		{
			get
			{
				return (EmployeeData.PersonRow)State[STATE_SELECTEDPERSON];
			}
			set
			{
				State[STATE_SELECTEDPERSON] = value;
			}
		}

		/// <summary>
		/// Method used to encapsulate access to the employee table in the dataset
		/// </summary>
		/// <returns></returns>
		public EmployeeData.PersonDataTable GetEmployees()
		{		
			return EmployeeData.Person;						
		}

		/// <summary>
		/// Method used to add a subscriber that is interested in knowing about changes that occure to people in
		/// the employee table
		/// </summary>
		/// <param name="notifier">Delegate that will be invoked when a change in an employee row occurs</param>
		public void SubscribeForChangesToPeople(Client.EmployeeData.PersonRowChangeEventHandler notifier)
		{
			this.EmployeeData.Person.PersonRowChanged+=notifier;
		}
		
	}
}
