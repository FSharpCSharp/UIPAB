' Microsoft User Interface Process Application Block for .NET Quick Start
' http://msdn.microsoft.com/library/en-us/dnbda/html/uip.asp
'
' BackButtonNotifier.aspx.vb
'
' This file contains the implementations of the browscatalog code behind class.
'
' 
'===============================================================================
' Copyright (C) 2000-2001 Microsoft Corporation
' All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
' FITNESS FOR A PARTICULAR PURPOSE.
'==============================================================================

Imports Microsoft.ApplicationBlocks.UIProcess

Public Class BackButtonNotifier
	Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

	'This call is required by the Web Form Designer.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

	End Sub
	Protected WithEvents Image1 As System.Web.UI.WebControls.Image
	Protected WithEvents cellMessage As System.Web.UI.HtmlControls.HtmlTableCell

	'NOTE: The following placeholder declaration is required by the Web Form Designer.
	'Do not delete or move it.
	Private designerPlaceholderDeclaration As System.Object

	Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
		'CODEGEN: This method call is required by the Web Form Designer
		'Do not modify it using the code editor.
		InitializeComponent()
	End Sub

#End Region

	Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		SetVisibility()
		RenderMessage()
	End Sub

	Private Sub SetVisibility()
		Me.Visible = Not UIPConfiguration.Config.AllowBackButton
	End Sub

	Private Sub RenderMessage()
		cellMessage.InnerHtml = "<b>Back button support is disabled.To enabled this feature please modify the allowBackButton attribute in the config file.</b>"
	End Sub

End Class
