using System;
using System.Collections;


namespace Microsoft.ApplicationBlocks.UIProcess
{

	public class WizardControllerBase: ControllerBase 
	{
		private delegate int GetViewIndex();
		private delegate void RaiseEvent(EventArgs e);

		public event EventHandler EnableAllButtons;
		public event EventHandler NextButtonDisable;
		public event EventHandler BackButtonDisable;

		public WizardControllerBase(State controllerState) : base(controllerState)
		{
		}

		public WizardControllerBase(Context context) : base(context){}
	

		protected virtual void OnEnableButtons(EventArgs e)
		{
			if (EnableAllButtons != null)
			{
				EnableAllButtons(this,e);
			}
		}

		protected virtual void OnNextButtonDisable(EventArgs e)
		{
			if (NextButtonDisable != null)
			{
				NextButtonDisable(this,e);
			}
		}

		protected virtual void OnBackButtonDisable(EventArgs e)
		{
			if (BackButtonDisable != null)
			{
				BackButtonDisable(this,e);
			}
		}

		
		public void ControlButtonVisibility()
		{
			OnEnableButtons(new EventArgs());
			
			string[] views = MyContext.GetSequenceViewNames();
			int viewIndex = this.GetCurrentViewIndex(views);

			if (viewIndex == 0)
				OnBackButtonDisable(new EventArgs());

			if (viewIndex == views.GetUpperBound(0))
				OnNextButtonDisable(new EventArgs());
		}

		public void Next()
		{				
			SetViewName(new GetViewIndex(GetPreviousViewIndex));
			Navigate();
		}

		public void Back()
		{
			SetViewName(new GetViewIndex(GetNextViewIndex));
			Navigate();
		}

		public void Finish()
		{

		}

		private void SetViewName(GetViewIndex viewIndexerDelegate)
		{
			string[] views = MyContext.GetSequenceViewNames();
			int viewIndex = viewIndexerDelegate();
			MyContext.State.NavigateValue = views[viewIndex];			

		}

		private WizardContext MyContext
		{
			get
			{
				return (WizardContext)Context;
			}
		}

		private int GetCurrentViewIndex(string[] views)
		{
			return Array.IndexOf(views,Context.State.CurrentView);
		}

		private int GetNextViewIndex()
		{

			string[] views = MyContext.GetSequenceViewNames();
			int currentViewIndex = GetCurrentViewIndex(views);

			if(currentViewIndex == 0) 							
				return 0;			
			else			
				return --currentViewIndex;			
		}	

		private int GetPreviousViewIndex()
		{
			string[] views = MyContext.GetSequenceViewNames();
			int currentViewIndex = GetCurrentViewIndex(views);
			if(currentViewIndex == views.GetUpperBound(0)) 						
				return views.GetUpperBound(0);			
			else			
				return ++currentViewIndex;			
		}
	}
}
