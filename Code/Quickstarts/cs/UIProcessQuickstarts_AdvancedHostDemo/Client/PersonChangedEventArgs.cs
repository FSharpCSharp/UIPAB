using System;

namespace Client
{
	public class PersonChangedEventArgs:EventArgs
	{
		Client.EmployeeData.PersonRow person;

		public PersonChangedEventArgs(Client.EmployeeData.PersonRow person)
		{
			this.person = person;
		}

		public Client.EmployeeData.PersonRow Person
		{
			get
			{
				return person;
			}
		}
	}
}
