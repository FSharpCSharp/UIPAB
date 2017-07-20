using System;

namespace Microsoft.ApplicationBlocks.UIProcess
{
	public class EventNavigateArgs : EventArgs
	{
		private State _state;

		public State State 
		{
			get { return _state; }
			set { _state = value; }
		}
	}
}
