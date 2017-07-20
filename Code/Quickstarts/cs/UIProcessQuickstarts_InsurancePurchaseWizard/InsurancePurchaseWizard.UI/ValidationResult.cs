using System;

namespace InsurancePurchaseWizard.UI
{
	public class ValidationResult
	{
		bool isValid;
		string errorMessage;

		public ValidationResult(bool isValid,string errorMessage)
		{
			this.isValid = isValid;
			this.errorMessage = errorMessage;
		}

		public string ErrorMessage
		{
			get
			{
				return errorMessage;
			}			
		}

		public bool IsValid
		{
			get
			{
				return isValid;
			}			
		}


	}
}
