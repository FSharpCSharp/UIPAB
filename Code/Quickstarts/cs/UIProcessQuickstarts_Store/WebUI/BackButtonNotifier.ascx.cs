namespace UIProcessQuickstarts_Store.WebUI
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Microsoft.ApplicationBlocks.UIProcess;

	/// <summary>
	///		Summary description for BackButtonNotifier.
	/// </summary>
	public class BackButtonNotifier : System.Web.UI.UserControl
	{
		protected System.Web.UI.HtmlControls.HtmlTableCell cellMessage;
		protected System.Web.UI.WebControls.Image Image1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			SetVisibility();
			RenderMessage();
		}

		private void SetVisibility()
		{
			this.Visible = !(UIPConfiguration.Config.AllowBackButton);
		}

		private void RenderMessage()
		{
			cellMessage.InnerHtml = "<b>Back button support is disabled.To enabled this feature please modify the allowBackButton attribute in the config file.</b>";			
		}

		
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
