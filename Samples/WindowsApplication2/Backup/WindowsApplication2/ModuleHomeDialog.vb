Namespace UI
    Public Class ModuleHomeDialog
        Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            'Me.btnLogoff.Image = CoreImages.Instance.LogOff
            'Me.btnExit.Image = CoreImages.Instance.ShutDown
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents ttpModules As System.Windows.Forms.ToolTip
        Friend WithEvents pnlModuleList As System.Windows.Forms.Panel
        Friend WithEvents btnLogoff As System.Windows.Forms.Button
        Friend WithEvents btnExit As System.Windows.Forms.Button
        Friend WithEvents pnlGroups As System.Windows.Forms.Panel
        Friend WithEvents pnlPointer As System.Windows.Forms.Panel
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.ttpModules = New System.Windows.Forms.ToolTip(Me.components)
            Me.btnLogoff = New System.Windows.Forms.Button
            Me.btnExit = New System.Windows.Forms.Button
            Me.pnlModuleList = New System.Windows.Forms.Panel
            Me.pnlGroups = New System.Windows.Forms.Panel
            Me.pnlPointer = New System.Windows.Forms.Panel
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.SuspendLayout()
            '
            'btnLogoff
            '
            Me.btnLogoff.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnLogoff.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnLogoff.Location = New System.Drawing.Point(592, 372)
            Me.btnLogoff.Name = "btnLogoff"
            Me.btnLogoff.Size = New System.Drawing.Size(32, 32)
            Me.btnLogoff.TabIndex = 0
            Me.ttpModules.SetToolTip(Me.btnLogoff, "Log off")
            '
            'btnExit
            '
            Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnExit.Location = New System.Drawing.Point(592, 408)
            Me.btnExit.Name = "btnExit"
            Me.btnExit.Size = New System.Drawing.Size(32, 32)
            Me.btnExit.TabIndex = 2
            Me.ttpModules.SetToolTip(Me.btnExit, "Exit")
            '
            'pnlModuleList
            '
            Me.pnlModuleList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnlModuleList.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(34, Byte), Integer))
            Me.pnlModuleList.Location = New System.Drawing.Point(20, 184)
            Me.pnlModuleList.Name = "pnlModuleList"
            Me.pnlModuleList.Size = New System.Drawing.Size(556, 256)
            Me.pnlModuleList.TabIndex = 1
            '
            'pnlGroups
            '
            Me.pnlGroups.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnlGroups.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(34, Byte), Integer))
            Me.pnlGroups.Location = New System.Drawing.Point(20, 144)
            Me.pnlGroups.Name = "pnlGroups"
            Me.pnlGroups.Size = New System.Drawing.Size(556, 36)
            Me.pnlGroups.TabIndex = 3
            '
            'pnlPointer
            '
            Me.pnlPointer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnlPointer.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(34, Byte), Integer))
            Me.pnlPointer.Location = New System.Drawing.Point(172, 143)
            Me.pnlPointer.Name = "pnlPointer"
            Me.pnlPointer.Size = New System.Drawing.Size(52, 40)
            Me.pnlPointer.TabIndex = 4
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(34, Byte), Integer))
            Me.Panel1.Location = New System.Drawing.Point(19, 182)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(558, 259)
            Me.Panel1.TabIndex = 6
            '
            'ModuleHomeDialog
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(634, 448)
            Me.Controls.Add(Me.pnlGroups)
            Me.Controls.Add(Me.btnExit)
            Me.Controls.Add(Me.pnlModuleList)
            Me.Controls.Add(Me.btnLogoff)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.pnlPointer)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ModuleHomeDialog"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Veracious Module Home"
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " METHODS- PRIVATE "
        Private Function CreateButton(ByVal pName As String, ByVal pText As String, ByVal pLocation As Point, ByVal pSize As Size, ByVal pTabIndex As Integer, ByVal pTag As Object, ByVal pToolTip As String) As Button
            Dim btnModule As Button = New Button
            btnModule.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            btnModule.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            btnModule.ForeColor = System.Drawing.Color.White
            btnModule.Location = pLocation
            btnModule.Size = pSize
            btnModule.Name = pName
            If pTabIndex >= 0 Then
                btnModule.TabIndex = pTabIndex
            End If
            btnModule.Tag = pTag
            btnModule.Text = pText
            btnModule.Visible = True
            ttpModules.SetToolTip(btnModule, pToolTip)

            Return btnModule
        End Function

        'Private Function LoadModuleButton(ByVal objModule As Plugins.IModule, ByVal Index As Integer, ByVal intCols As Integer, ByVal intButtonW As Integer, ByVal intButtonH As Integer) As Button
        '    Dim intPosX As Integer = Index Mod intCols
        '    Dim intPosY As Integer = Index \ intCols
        '    Dim ptLocation As New Point(4 + intPosX * (intButtonW + 4), 4 + intPosY * (intButtonH + 4))

        '    Dim strText As String = ""
        '    If objModule.ModuleDesign Is Nothing Then
        '        strText = objModule.Name
        '    End If

        '    Dim btnModule As Button = CreateButton("btnModule" & Index, strText, ptLocation, New System.Drawing.Size(intButtonW, intButtonH), Index, objModule, objModule.Description)
        '    If Not objModule.ModuleDesign Is Nothing Then
        '        btnModule.Image = objModule.ModuleDesign.ModuleHomeIconImage2
        '        btnModule.BackColor = objModule.ModuleDesign.ModuleHomeIconImageBackColor
        '    End If
        '    Me.pnlModuleList.Controls.Add(btnModule)
        '    If Index = 0 Then
        '        btnModule.Focus()
        '    End If
        '    AddHandler btnModule.Click, AddressOf Module_Click
        '    Return btnModule
        'End Function
#End Region

#Region " METHODS- OVERRIDES "
        'Public Overrides Sub LoadModuleHome(ByVal mDesign As Plugins.Presentation.IModuleHomeDesign)
        '    If Not mDesign.HomeBackgroundImage Is Nothing Then
        '        Dim bmpBack As New Bitmap(mDesign.HomeBackgroundImage, Me.ClientSize)
        '        Me.BackgroundImage = bmpBack
        '        'If mDesign.HomeModulesBackgroundType = Plugins.Presentation.BackgroundType.Color Then
        '        pnlModuleList.BackColor = mDesign.HomeModulesBackgroundColor
        '        pnlGroups.BackColor = mDesign.HomeModulesBackgroundColor
        '        'Else
        '        '    pnlModuleList.BackgroundImage = mDesign.HomeModulesBackgroundImage
        '        '    pnlGroups.BackgroundImage = mDesign.HomeModulesBackgroundImage
        '        'End If
        '        With mDesign.HomeModulesBounds
        '            If Not (.X = 0 And .Y = 0 And .Width = 0 And .Height = 0) Then
        '                Me.pnlModuleList.Location = .Location
        '                Me.pnlModuleList.Size = .Size
        '            End If
        '        End With
        '    End If
        'End Sub

        Private htModuleGroups As New Hashtable
        Private htGroupButtons As New Hashtable

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            ' LOAD GROUPS												
            Dim htGroups As New Hashtable
            'For Each objModule As Plugins.IModule In GlobalContext.Modules
            '    Dim strKey As String = objModule.Group.Trim().ToUpper()
            '    If htGroups.ContainsKey(strKey) Then
            '        htGroups(strKey) += 1
            '    Else
            '        htGroups.Add(strKey, 0)
            '    End If
            'Next
            Dim arrGroups As String() = New String(htGroups.Keys.Count - 1) {}
            htGroups.Keys.CopyTo(arrGroups, 0)
            htModuleGroups.Clear()
            htGroupButtons.Clear()
            htModuleGroups.Add("__DEFAULT", New ArrayList)
            For Each strGroup As String In arrGroups
                Dim strTargetGroup As String
                If htGroups(strGroup) = 0 Or strGroup = "" Then
                    strTargetGroup = "__DEFAULT"
                Else
                    strTargetGroup = strGroup
                End If
                Dim alModules As ArrayList
                If htModuleGroups.Contains(strTargetGroup) Then
                    alModules = htModuleGroups(strTargetGroup)
                Else
                    alModules = New ArrayList
                    htModuleGroups.Add(strTargetGroup, alModules)
                End If
                'For Each objModule As Plugins.IModule In GlobalContext.Modules
                '    If objModule.Group.ToUpper() = strGroup Then
                '        If Array.IndexOf(GlobalContext.Application.AuthenticationDesign.Authentication.AvailableModules, objModule.ID) >= 0 Then
                '            alModules.Add(objModule)
                '        End If
                '    End If
                'Next
            Next
            ' TODO: LOAD MODULES BY GROUP								
            Dim Index As Integer = 0
            For Each strGroup As String In htModuleGroups.Keys
                Dim btnModuleGroup As Button = CreateButton("btnModuleGroup" & Index, "", New Point(4 + Index * (80 + 4), 2), New Size(80, 32), Index, strGroup, strGroup)
                'btnModuleGroup.Image = GlobalContext.LoadModuleIcon(strGroup)
                pnlGroups.Controls.Add(btnModuleGroup)
                AddHandler btnModuleGroup.Click, AddressOf ModuleGroup_Click
                If Index = 0 Then
                    ModuleGroup_Click(btnModuleGroup, EventArgs.Empty)
                End If
                Index += 1
            Next
            MyBase.OnLoad(e)
        End Sub

        Public Sub LoadModules(ByVal Group As String)
            Dim Index As Integer = 0
            ' CREATE MODUEL BUTTONS										

            For Index2 As Integer = pnlModuleList.Controls.Count - 1 To 0 Step -1
                Dim btn As Button = pnlModuleList.Controls(Index2)
                btn.Visible = False
            Next

            Dim alModules As ArrayList = htModuleGroups(Group)

            If htGroupButtons.ContainsKey(Group) Then
                Dim alButtons As ArrayList = htGroupButtons(Group)
                For Each btn As Button In alButtons
                    btn.Visible = True
                Next
            Else
                Dim alButtons As New ArrayList
                'For Each objModule As Plugins.IModule In alModules
                '    alButtons.Add(LoadModuleButton(objModule, Index, 5, 80, 80))
                '    Index += 1
                'Next
                htGroupButtons.Add(Group, alButtons)
            End If
            btnLogoff.TabIndex = Index
            btnExit.TabIndex = Index + 1
        End Sub
#End Region

#Region " METHODS- EVENT HANDLERS "
        Public Sub ModuleGroup_Click(ByVal Sender As Object, ByVal e As EventArgs)
            Dim btnModuleGroup As Button = Sender
            pnlPointer.Left = pnlGroups.Left + btnModuleGroup.Left - 2
            pnlPointer.Width = btnModuleGroup.Width + 4
            LoadModules(btnModuleGroup.Tag)
        End Sub

        Public Sub Module_Click(ByVal Sender As Object, ByVal e As EventArgs)
            'GlobalContext.ResetWorkspaceWindow()
            'Dim objModule As Plugins.IModule = CType(Sender, Button).Tag
            'ModuleLoader.Activate(Me, objModule)
        End Sub

        Private Sub btnLogoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogoff.Click
            'GlobalContext.DoDeAuthentication(Me)
        End Sub

        Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
            'GlobalContext.DoShutdown(Me)
        End Sub
#End Region

        Private Sub ModuleHomeDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub
    End Class
End Namespace