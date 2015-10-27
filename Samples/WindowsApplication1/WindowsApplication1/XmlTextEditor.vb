Imports System
Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports Greg.XmlEditor.Presentation.Commands
Imports Greg.XmlEditor.Presentation.Commands.Concrete
Imports Greg.XmlEditor.Presentation.Presenters
Imports ICSharpCode.TextEditor.Actions
Imports ICSharpCode.TextEditor.Document

Namespace Greg.XmlEditor.Presentation.Views
	Public Class XmlTextEditor
		Inherits XmlTextEditorBase

		Private previousSearchLine As Integer = -1
		Private previousSearchWord As Integer

		' Methods
		Public Sub New()
			AddHandler MyBase.Document.DocumentChanged, AddressOf Document_DocumentChanged

            'Me.UndoCommand = New DelegateCommand(AddressOf CanUndo, Undo)
            'Me.RedoCommand = New DelegateCommand(AddressOf CanRedo, Redo)

            'Me.CutCommand = New DelegateCommand(AddressOf CanCut, AddressOf DoCut)
            'Me.CopyCommand = New DelegateCommand(AddressOf CanCopy, AddressOf DoCopy)
            'Me.PasteCommand = New DelegateCommand(AddressOf CanPaste, AddressOf DoPaste)

            'Me.SelectAllCommand = New DelegateCommand(AddressOf CanSelectAll, AddressOf DoSelectAll)
            'Me.FindAndReplaceCommand = New FindAndReplaceCommand(Me)
            'Me.ToggleFoldingsCommand = New DelegateCommand(Function() True, AddressOf Me.DoToggleFoldings)

			Me.CreateContextMenu()

			MyBase.Document.FoldingManager.UpdateFoldings(String.Empty, Nothing)
			MyBase.TextArea.Refresh(MyBase.TextArea.FoldMargin)
		End Sub


'INSTANT VB NOTE: The variable presenter was renamed since Visual Basic does not allow variables and other class members to have the same name:
        'Private presenter_Renamed As DocumentPresenterBase
        'Public Property Presenter() As DocumentPresenterBase
        '	Get
        '		Return Me.presenter_Renamed
        '	End Get
        '	Set(ByVal value As DocumentPresenterBase)
        '		If value Is Me.presenter_Renamed Then
        '			Return
        '		End If
        '		Me.presenter_Renamed = value
        '		Me.RefreshCommands(Me, EventArgs.Empty)
        '	End Set
        'End Property

		#Region "Extended properties"

		Public ReadOnly Property SelectedText() As String
			Get
				Return MyBase.TextArea.SelectionManager.SelectedText
			End Get
		End Property

		Public ReadOnly Property Lines() As String()
			Get
				Return MyBase.Text.Split(New String() { vbCrLf }, StringSplitOptions.None)
			End Get
		End Property

		#End Region

		

		#Region "Commands implementations"

		Private Function CanUndo() As Boolean
            '			Return Me.Presenter IsNot Nothing AndAlso MyBase.Document.UndoStack.CanUndo
		End Function

		Private Function CanRedo() As Boolean
            '	Return Me.Presenter IsNot Nothing AndAlso MyBase.Document.UndoStack.CanRedo
		End Function

		Private Function CanCopy() As Boolean
            '	Return Me.Presenter IsNot Nothing AndAlso MyBase.TextArea.SelectionManager.HasSomethingSelected
		End Function

		Private Function CanCut() As Boolean
            '	Return Me.Presenter IsNot Nothing AndAlso MyBase.TextArea.SelectionManager.HasSomethingSelected
		End Function

		Private Function CanPaste() As Boolean
            '		Return Me.Presenter IsNot Nothing AndAlso MyBase.TextArea.ClipboardHandler.EnablePaste
		End Function

		Private Function CanSelectAll() As Boolean
            'If Me.Presenter Is Nothing Then
            '	Return False
            'End If
			If MyBase.Document.TextContent Is Nothing Then
				Return False
			End If
			Return Not MyBase.Document.TextContent.Trim().Equals(String.Empty)
		End Function




		Private Sub DoCut()
			CType(New Cut(), Cut).Execute(MyBase.TextArea)
			MyBase.TextArea.Focus()
		End Sub

		Private Sub DoCopy()
			CType(New Copy(), Copy).Execute(MyBase.TextArea)
			MyBase.TextArea.Focus()
		End Sub

		Private Sub DoPaste()
			CType(New Paste(), Paste).Execute(MyBase.TextArea)
			MyBase.TextArea.Focus()
		End Sub

		Private Sub DoSelectAll()
			CType(New SelectWholeDocument(), SelectWholeDocument).Execute(MyBase.TextArea)
			MyBase.TextArea.Focus()
		End Sub

		Public Sub DoToggleFoldings()
			CType(New ToggleAllFoldings(), ToggleAllFoldings).Execute(MyBase.TextArea)
		End Sub

		#End Region

		#Region "Initialization"

		Private Sub CreateContextMenu()
			'contextmenu
			Dim mnu = New ContextMenuStrip()
			Dim mnuFind = New ToolStripMenuItem("Find/Replace")
			Dim mnuFold = New ToolStripMenuItem("Open/close all foldings")

            'CommandManager.Instance.Bindings.Add(Me.FindAndReplaceCommand, mnuFind)
            'CommandManager.Instance.Bindings.Add(Me.ToggleFoldingsCommand, mnuFold)


			'Add to main context menu
			mnu.Items.AddRange(New ToolStripItem() { mnuFind, mnuFold })

			'Assign to datagridview
			MyBase.TextArea.ContextMenuStrip = mnu
		End Sub

		#End Region

		Public Sub SelectText(ByVal start As Integer, ByVal length As Integer)
			Dim textLength = MyBase.Document.TextLength
			If textLength < (start + length) Then
				length = (textLength - 1) - start
			End If
			MyBase.TextArea.Caret.Position = MyBase.Document.OffsetToPosition(start + length)
			MyBase.TextArea.SelectionManager.ClearSelection()
			MyBase.TextArea.SelectionManager.SetSelection(New DefaultSelection(MyBase.Document, MyBase.Document.OffsetToPosition(start), MyBase.Document.OffsetToPosition(start + length)))
			MyBase.Refresh()
		End Sub

		Public Sub Find(ByVal search As String)
			Me.Find(search, False)
		End Sub

		Public Sub Find(ByVal search As String, ByVal caseSensitive As Boolean)
			Dim found = False

			Dim i = 0
'INSTANT VB NOTE: The variable lines was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim lines_Renamed = Me.Lines
            For Each line As Object In lines_Renamed
                If i > previousSearchLine Then
                    Dim start As Integer
                    If previousSearchWord > line.Length Then
                        start = IIf(caseSensitive, line.IndexOf(search), line.ToLower().IndexOf(search.ToLower()))

                        previousSearchWord = 0
                    Else
                        start = IIf(caseSensitive, line.IndexOf(search, previousSearchWord), line.ToLower().IndexOf(search.ToLower(), previousSearchWord))
                    End If
                    Dim [end] = start + search.Length
                    If start <> -1 Then
                        Dim p1 = New Point(start, i)
                        Dim p2 = New Point([end], i)

                        MyBase.TextArea.SelectionManager.SetSelection(p1, p2)
                        MyBase.ActiveTextAreaControl.ScrollTo(i)
                        MyBase.Refresh()

                        previousSearchWord = [end]
                        previousSearchLine = i - 1
                        found = True
                        Exit For
                    End If

                    previousSearchWord = 0
                End If

                i += 1
                If i >= lines_Renamed.Length - 1 Then
                    previousSearchLine = -1
                End If
            Next line

			If Not found Then
				MessageBox.Show("The following specified text was not found: " & Environment.NewLine & Environment.NewLine & search)
			End If
		End Sub

		Public Sub Replace(ByVal search As String, ByVal replace As String, ByVal caseSensitive As Boolean)
			If MyBase.TextArea.SelectionManager.HasSomethingSelected AndAlso MyBase.TextArea.SelectionManager.SelectedText = search Then
				Dim text = MyBase.TextArea.SelectionManager.SelectedText
				MyBase.TextArea.Caret.Position = MyBase.TextArea.SelectionManager.SelectionCollection(0).StartPosition
				MyBase.TextArea.SelectionManager.ClearSelection()
				MyBase.TextArea.Document.Replace(MyBase.TextArea.Caret.Offset, text.Length, replace)
			End If
			Me.Find(search, caseSensitive)
		End Sub

		Public Sub ReplaceAll(ByVal search As String, ByVal replace As String)
			Me.ReplaceAll(search, replace, False)
		End Sub

		Public Sub ReplaceAll(ByVal search As String, ByVal replace As String, ByVal caseSensitive As Boolean)
            MyBase.Text = Regex.Replace(MyBase.Text, search, replace, IIf(caseSensitive, RegexOptions.None, RegexOptions.IgnoreCase))
			MyBase.Refresh()
		End Sub

		Public Sub ResetLastFound()
			previousSearchLine = -1
			previousSearchWord = 0
		End Sub

		Private Sub Document_DocumentChanged(ByVal sender As Object, ByVal e As DocumentEventArgs)
			MyBase.Document.FoldingManager.UpdateFoldings(String.Empty, Nothing)
			MyBase.TextArea.Refresh(MyBase.TextArea.FoldMargin)

            'If Me.Presenter Is Nothing Then
            '	Return
            'End If
            'If Me.Text = Environment.NewLine AndAlso String.IsNullOrEmpty(Me.presenter_Renamed.Text) Then
            '	Return
            'End If

            'Me.Presenter.Text = Me.Text
		End Sub
	End Class
End Namespace