//===============================================================================
// Microsoft User Interface Process Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
//
// WizardContainer.cs
//
// This file contains the implementations of the WizardContainer class.
//
// For more information see the User Interface Process Application Block Implementation Overview. 
// 
//===============================================================================
// Copyright (C) 2000-2001 Microsoft Corporation
// All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
// FITNESS FOR A PARTICULAR PURPOSE.
//==============================================================================

using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	/// <summary>
	/// Class that is encapsulates the views for a wizard navigator.
	/// </summary>
	internal sealed class WizardContainer : Form
	{
		private IView[] _views;
		private WizardController _controller;
		private Hashtable _container;
		private System.Windows.Forms.GroupBox _groupBox;
		private WizardButtons _buttons;
		private Stack _history;

		private delegate bool ViewTransition();

		public WizardContainer():base()
		{
			InitializeComponent();			
		}

		/// <summary>
		/// Initializes a new instance of a wizard container.
		/// </summary>
		/// <param name="views">All of the views that will be contained within this container.</param>
		/// <param name="navigator">The wizard navigator managing the task.</param>
		public WizardContainer(IView[] views,Navigator navigator):this()
		{
			_views = views;
			_controller = new WizardController(navigator);
			_container = new Hashtable(_views.Length);
			_history = new Stack(_views.Length);
			InitializeViews();

			this.Closed+=new EventHandler(WizardContainer_Closed);
		}

		/// <summary>
		/// The task identifier for the wizard.
		/// </summary>
		public Guid TaskId
		{
			get {return _controller.Navigator.CurrentState.TaskId;}
		}

		/// <summary>
		/// Gets the view that is currently active in the wizard.
		/// </summary>
		/// <returns>The view that is currently active.</returns>
		public IView GetActiveView()
		{
			return (IView)_groupBox.Controls[0];
		}

		private void InitializeViews()
		{
			foreach (IView view in _views)
			{
				AddNewView(view);
			}
			ResetFormSize();
		}

		/// <summary>
		/// Releases all resources used by the wizard container.
		/// </summary>
		/// <param name="disposing">The object that is being explicitly disposed of.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(_buttons != null) 
				{
					_buttons.Dispose();
				}
				if(_groupBox != null)
				{
					_groupBox.Dispose();
				}
				if(_container != null)
				{
					foreach(IDisposable d in _container.Values)
					{
						d.Dispose();
					}
				}
			}
			base.Dispose( disposing );
		}

		private void AddNewView(IView newView)
		{
			if (newView.GetType().IsSubclassOf(typeof(Form)))
			{
				Form currentForm = (Form)newView;
				currentForm.TopLevel=false;
				currentForm.FormBorderStyle=System.Windows.Forms.FormBorderStyle.None;
			}		
			Control control = (Control)newView;
			control.Visible = true;
			_container.Add(newView.ViewName, control);					
		}

		private void ResetFormSize()
		{
			Size buttonSize = _buttons.Size;
			Size largestForm = GetLargestBounds();
			int width = (buttonSize.Width > largestForm.Width) ? buttonSize.Width : largestForm.Width;
			_groupBox.Size = new Size(width, largestForm.Height);
			this.MinimumSize = new Size(width, largestForm.Height + buttonSize.Height);
			this.Size = this.MinimumSize;
		}

		private Size GetLargestBounds()
		{		
			int largestWidth = this.Width;
			int largestHeight = this.Height;

			foreach (Control ctrl in _container.Values)
			{
				if (ctrl.Width > largestWidth)
					largestWidth = ctrl.Width;

				if (ctrl.Height > largestHeight)
					largestHeight = ctrl.Height;
			}

			return new Size(largestWidth,largestHeight);
		}

		/// <summary>
		/// Activates a specific view in the wizard by using the name of the view.
		/// </summary>
		/// <param name="viewName">The name of the view to activate.</param>
		public void Activate(string viewName)
		{
			if(!this.Visible)
			{
				this.Visible = true;
			}
			Control control = (Control)_container[viewName];
			if(!IsControlDisplayed(control)) 
			{
				Push(control);
			}
		}

		/// <summary>
		/// Returns the number of views that are contained within the wizard container.
		/// </summary>
		public int Count
		{
			get {return _container.Count; }
		}

		/// <summary>
		/// Gets the views that are used within this container.
		/// </summary>
		/// <returns>The views that are used in this container.</returns>
		public Hashtable GetCurrentViews()
		{
			return _container;
		}

		private void InitializeComponent()
		{
			this._buttons = new Microsoft.ApplicationBlocks.UIProcess.WizardButtons();
			this._groupBox = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// _buttons
			// 
			this._buttons.BackEnabled = true;
			this._buttons.CancelEnabled = true;
			this._buttons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this._buttons.FinishEnabled = true;
			this._buttons.Location = new System.Drawing.Point(0, 342);
			this._buttons.Name = "_buttons";
			this._buttons.NextEnabled = true;
			this._buttons.Size = new System.Drawing.Size(560, 40);
			this._buttons.TabIndex = 2;
			this._buttons.OnNext += new Microsoft.ApplicationBlocks.UIProcess.WizardButtons.NextEventHandler(this.btnNext_Click);
			this._buttons.OnCancel += new Microsoft.ApplicationBlocks.UIProcess.WizardButtons.CancelEventHandler(this.btnCancel_Click);
			this._buttons.OnFinish += new Microsoft.ApplicationBlocks.UIProcess.WizardButtons.FinishEventHandler(this.btnFinish_Click);
			this._buttons.OnBack += new Microsoft.ApplicationBlocks.UIProcess.WizardButtons.BackEventHandler(this.btnBack_Click);
			// 
			// _groupBox
			// 
			this._groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this._groupBox.Location = new System.Drawing.Point(0, 0);
			this._groupBox.Name = "_groupBox";
			this._groupBox.Size = new System.Drawing.Size(560, 342);
			this._groupBox.TabIndex = 1;
			this._groupBox.TabStop = false;
			// 
			// WizardContainer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(560, 382);
			this.Controls.Add(this._groupBox);
			this.Controls.Add(this._buttons);
			this.Name = "WizardContainer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.ResumeLayout(false);

		}


		private void AddViewToGroupBox(Control control)
		{
			_groupBox.Controls.Add(control);
			_groupBox.Text = control.Text;
			control.Dock = DockStyle.Fill;
			control.Visible = true;
			SetButtonVisiblity();

			IWizardViewTransition view = GetActiveWizardViewTransition();
			if (view != null)
			{
				view.WizardActivated();
			}
		}

		private IWizardViewTransition GetActiveWizardViewTransition()
		{
			return (this.GetActiveView() as IWizardViewTransition);
		}


		private void SetButtonVisiblity()
		{
			_buttons.BackEnabled = !(_history.Count == 0);
			string last = (((WizardNavigator)_controller.Navigator).LastViewName);
			_buttons.NextEnabled = !(last == GetActiveView().ViewName);

			IWizardViewTransition view = GetActiveWizardViewTransition();
			if (view != null)
			{
				_buttons.FinishEnabled = view.SupportsFinish;
				_buttons.CancelEnabled = view.SupportsCancel;
			}
			else
			{
				_buttons.FinishEnabled = false;
				_buttons.CancelEnabled = false;
			}
		}


		private bool IsControlDisplayed(Control control)
		{
			bool result = false;
			if(_groupBox.HasChildren)
			{
				Control current = _groupBox.Controls[0];
				result = (current != null && current == control);
			}
			return result;
		}


		private void Push(Control control)
		{
			if(_groupBox.HasChildren)
			{		
				_history.Push(_groupBox.Controls[0]);
				_groupBox.Controls.RemoveAt(0);
			}
			AddViewToGroupBox(control);
		}

		private Control Pop()
		{
			if(_groupBox.HasChildren)
			{
				_groupBox.Controls.RemoveAt(0);
				return (Control)_history.Pop();
			}
			else
			{
				return null;
			}
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			if (CanMoveNext())
			{
				_controller.Next();
			}
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			if (CanMoveBack()) 
			{
				Control previousControl = Pop();
				_controller.State.CurrentView = ((IView)previousControl).ViewName;
				AddViewToGroupBox(previousControl);
			}
		}

		private bool CanMoveNext()
		{	
			IWizardViewTransition view = GetCurrentTransition();
			return (view == null) ? true : view.DoNext();
		}

		private bool CanMoveBack()
		{
			if(_history.Count == 0) 
			{
				return false;
			}
			IWizardViewTransition view = GetCurrentTransition();
			return (view == null) ? true : view.DoBack();
		}

		private bool CanCancel()
		{
			IWizardViewTransition view = GetCurrentTransition();
			return (view == null) ? true : view.DoCancel();
		}

		private bool CanFinish()
		{
			IWizardViewTransition view = GetCurrentTransition();
			return (view == null) ? true : view.DoFinish();
		}

		private IWizardViewTransition GetCurrentTransition()
		{
			return _groupBox.Controls[0] as IWizardViewTransition;
		}

		private void WizardContainer_Closed(object sender, EventArgs e)
		{
			UIPManager.OnCompletion();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (CanCancel())
			{
				this.Close();
			}
		}
			
		private void btnFinish_Click(object sender, System.EventArgs e)
		{
			if (CanFinish())
			{
				this.Close();
			}
		}


	}
}
