Imports System
Imports System.Drawing
Imports ICSharpCode.TextEditor
Imports ICSharpCode.TextEditor.Addons
Imports ICSharpCode.TextEditor.Document

Namespace Greg.XmlEditor.Presentation.Views
	Public Class XmlTextEditorBase
		Inherits TextEditorControl

		' Methods
		Public Sub New()
			MyBase.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("XML")
			MyBase.Document.FoldingManager.FoldingStrategy = New XmlFoldingStrategy()
			MyBase.Document.FormattingStrategy = New XmlFormattingStrategy()
			MyBase.TextEditorProperties = InitializeProperties()
			MyBase.Document.FoldingManager.UpdateFoldings(String.Empty, Nothing)
			MyBase.TextArea.Refresh(MyBase.TextArea.FoldMargin)
		End Sub

		Private Shared Function InitializeProperties() As ITextEditorProperties
			Dim properties = New DefaultTextEditorProperties()
			properties.Font = New Font("Courier new", 9, FontStyle.Regular)
			properties.IndentStyle = IndentStyle.Smart
			properties.ShowSpaces = False
			properties.LineTerminator = Environment.NewLine
			properties.ShowTabs = False
			properties.ShowInvalidLines = False
			properties.ShowEOLMarker = False
			properties.TabIndent = 2
			properties.CutCopyWholeLine = True
			properties.LineViewerStyle = LineViewerStyle.None
			properties.MouseWheelScrollDown = True
			properties.MouseWheelTextZoom = True
			properties.AllowCaretBeyondEOL = False
			properties.AutoInsertCurlyBracket = True
			properties.BracketMatchingStyle = BracketMatchingStyle.After
			properties.ConvertTabsToSpaces = False
			properties.ShowMatchingBracket = True
			properties.EnableFolding = True
			properties.ShowVerticalRuler = False
			properties.IsIconBarVisible = True
			properties.Encoding = System.Text.Encoding.Unicode
			properties.UseAntiAliasedFont = False
			Return properties
		End Function
	End Class
End Namespace
