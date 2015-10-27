<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button2 = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.NavigationPane1 = New Ascend.Windows.Forms.NavigationPane
        Me.NavigationPanePage1 = New Ascend.Windows.Forms.NavigationPanePage
        Me.GradientCaption1 = New Ascend.Windows.Forms.GradientCaption
        Me.NavigationPanePage2 = New Ascend.Windows.Forms.NavigationPanePage
        Me.GradientAnimation1 = New Ascend.Windows.Forms.GradientAnimation
        Me.NavigationPanePage3 = New Ascend.Windows.Forms.NavigationPanePage
        Me.NavigationPanePage4 = New Ascend.Windows.Forms.NavigationPanePage
        Me.NavigationPanePage5 = New Ascend.Windows.Forms.NavigationPanePage
        Me.GradientSplitBar1 = New Ascend.Windows.Forms.GradientSplitBar
        Me.GradientLine1 = New Ascend.Windows.Forms.GradientLine
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.NavigationPane1.SuspendLayout()
        Me.NavigationPanePage1.SuspendLayout()
        Me.NavigationPanePage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(536, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Load XML"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 370)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(735, 44)
        Me.Panel1.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(628, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(95, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Validate XML"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.NavigationPane1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(735, 370)
        Me.Panel2.TabIndex = 2
        '
        'NavigationPane1
        '
        Me.NavigationPane1.ButtonActiveGradientHighColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.NavigationPane1.ButtonActiveGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.NavigationPane1.ButtonBorderColor = System.Drawing.SystemColors.MenuHighlight
        Me.NavigationPane1.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.NavigationPane1.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.NavigationPane1.ButtonGradientHighColor = System.Drawing.SystemColors.ButtonHighlight
        Me.NavigationPane1.ButtonGradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.NavigationPane1.ButtonHighlightGradientHighColor = System.Drawing.Color.White
        Me.NavigationPane1.ButtonHighlightGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.NavigationPane1.CaptionBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.NavigationPane1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.NavigationPane1.CaptionForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.NavigationPane1.CaptionGradientHighColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.NavigationPane1.CaptionGradientLowColor = System.Drawing.SystemColors.ActiveCaption
        Me.NavigationPane1.Controls.Add(Me.NavigationPanePage1)
        Me.NavigationPane1.Controls.Add(Me.NavigationPanePage2)
        Me.NavigationPane1.Controls.Add(Me.NavigationPanePage3)
        Me.NavigationPane1.Controls.Add(Me.NavigationPanePage4)
        Me.NavigationPane1.Controls.Add(Me.NavigationPanePage5)
        Me.NavigationPane1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigationPane1.FooterGradientHighColor = System.Drawing.SystemColors.ButtonHighlight
        Me.NavigationPane1.FooterGradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.NavigationPane1.FooterHeight = 30
        Me.NavigationPane1.FooterHighlightGradientHighColor = System.Drawing.Color.White
        Me.NavigationPane1.FooterHighlightGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.NavigationPane1.Location = New System.Drawing.Point(0, 0)
        Me.NavigationPane1.Name = "NavigationPane1"
        Me.NavigationPane1.NavigationPages.AddRange(New Ascend.Windows.Forms.NavigationPanePage() {Me.NavigationPanePage1, Me.NavigationPanePage2, Me.NavigationPanePage3, Me.NavigationPanePage4, Me.NavigationPanePage5})
        Me.NavigationPane1.Size = New System.Drawing.Size(735, 370)
        Me.NavigationPane1.TabIndex = 0
        Me.NavigationPane1.VisibleButtonCount = 5
        '
        'NavigationPanePage1
        '
        Me.NavigationPanePage1.ActiveGradientHighColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.NavigationPanePage1.ActiveGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.NavigationPanePage1.AutoScroll = True
        Me.NavigationPanePage1.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.NavigationPanePage1.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.NavigationPanePage1.Controls.Add(Me.GradientCaption1)
        Me.NavigationPanePage1.Dock = System.Windows.Forms.DockStyle.Top
        Me.NavigationPanePage1.GradientHighColor = System.Drawing.SystemColors.ButtonHighlight
        Me.NavigationPanePage1.GradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.NavigationPanePage1.HighlightGradientHighColor = System.Drawing.Color.White
        Me.NavigationPanePage1.HighlightGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.NavigationPanePage1.Image = Nothing
        Me.NavigationPanePage1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavigationPanePage1.ImageFooter = Nothing
        Me.NavigationPanePage1.ImageIndex = -1
        Me.NavigationPanePage1.ImageIndexFooter = -1
        Me.NavigationPanePage1.ImageKey = ""
        Me.NavigationPanePage1.ImageKeyFooter = ""
        Me.NavigationPanePage1.ImageList = Nothing
        Me.NavigationPanePage1.ImageListFooter = Nothing
        Me.NavigationPanePage1.Key = "NavigationPanePage1"
        Me.NavigationPanePage1.Name = "NavigationPanePage1"
        Me.NavigationPanePage1.Size = New System.Drawing.Size(735, 145)
        Me.NavigationPanePage1.TabIndex = 0
        Me.NavigationPanePage1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavigationPanePage1.ToolTipText = Nothing
        '
        'GradientCaption1
        '
        Me.GradientCaption1.AutoScroll = True
        Me.GradientCaption1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GradientCaption1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GradientCaption1.Location = New System.Drawing.Point(0, 0)
        Me.GradientCaption1.Name = "GradientCaption1"
        Me.GradientCaption1.Size = New System.Drawing.Size(220, 145)
        Me.GradientCaption1.TabIndex = 0
        Me.GradientCaption1.Text = "wELCOME"
        '
        'NavigationPanePage2
        '
        Me.NavigationPanePage2.ActiveGradientHighColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.NavigationPanePage2.ActiveGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.NavigationPanePage2.AutoScroll = True
        Me.NavigationPanePage2.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.NavigationPanePage2.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.NavigationPanePage2.Controls.Add(Me.GradientAnimation1)
        Me.NavigationPanePage2.GradientHighColor = System.Drawing.SystemColors.ButtonHighlight
        Me.NavigationPanePage2.GradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.NavigationPanePage2.HighlightGradientHighColor = System.Drawing.Color.White
        Me.NavigationPanePage2.HighlightGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.NavigationPanePage2.Image = Nothing
        Me.NavigationPanePage2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavigationPanePage2.ImageFooter = Nothing
        Me.NavigationPanePage2.ImageIndex = -1
        Me.NavigationPanePage2.ImageIndexFooter = -1
        Me.NavigationPanePage2.ImageKey = ""
        Me.NavigationPanePage2.ImageKeyFooter = ""
        Me.NavigationPanePage2.ImageList = Nothing
        Me.NavigationPanePage2.ImageListFooter = Nothing
        Me.NavigationPanePage2.Key = "NavigationPanePage2"
        Me.NavigationPanePage2.Location = New System.Drawing.Point(1, 27)
        Me.NavigationPanePage2.Name = "NavigationPanePage2"
        Me.NavigationPanePage2.Size = New System.Drawing.Size(733, 145)
        Me.NavigationPanePage2.TabIndex = 1
        Me.NavigationPanePage2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavigationPanePage2.ToolTipText = Nothing
        '
        'GradientAnimation1
        '
        Me.GradientAnimation1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.GradientAnimation1.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources._1
        Me.GradientAnimation1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GradientAnimation1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientAnimation1.Location = New System.Drawing.Point(0, 0)
        Me.GradientAnimation1.Name = "GradientAnimation1"
        Me.GradientAnimation1.Size = New System.Drawing.Size(733, 145)
        Me.GradientAnimation1.TabIndex = 0
        Me.GradientAnimation1.TabStop = False
        '
        'NavigationPanePage3
        '
        Me.NavigationPanePage3.ActiveGradientHighColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.NavigationPanePage3.ActiveGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.NavigationPanePage3.AutoScroll = True
        Me.NavigationPanePage3.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.NavigationPanePage3.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.NavigationPanePage3.GradientHighColor = System.Drawing.SystemColors.ButtonHighlight
        Me.NavigationPanePage3.GradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.NavigationPanePage3.HighlightGradientHighColor = System.Drawing.Color.White
        Me.NavigationPanePage3.HighlightGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.NavigationPanePage3.Image = Nothing
        Me.NavigationPanePage3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavigationPanePage3.ImageFooter = Nothing
        Me.NavigationPanePage3.ImageIndex = -1
        Me.NavigationPanePage3.ImageIndexFooter = -1
        Me.NavigationPanePage3.ImageKey = ""
        Me.NavigationPanePage3.ImageKeyFooter = ""
        Me.NavigationPanePage3.ImageList = Nothing
        Me.NavigationPanePage3.ImageListFooter = Nothing
        Me.NavigationPanePage3.Key = "NavigationPanePage3"
        Me.NavigationPanePage3.Location = New System.Drawing.Point(1, 27)
        Me.NavigationPanePage3.Name = "NavigationPanePage3"
        Me.NavigationPanePage3.Size = New System.Drawing.Size(733, 145)
        Me.NavigationPanePage3.TabIndex = 2
        Me.NavigationPanePage3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavigationPanePage3.ToolTipText = Nothing
        '
        'NavigationPanePage4
        '
        Me.NavigationPanePage4.ActiveGradientHighColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.NavigationPanePage4.ActiveGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.NavigationPanePage4.AutoScroll = True
        Me.NavigationPanePage4.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.NavigationPanePage4.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.NavigationPanePage4.GradientHighColor = System.Drawing.SystemColors.ButtonHighlight
        Me.NavigationPanePage4.GradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.NavigationPanePage4.HighlightGradientHighColor = System.Drawing.Color.White
        Me.NavigationPanePage4.HighlightGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.NavigationPanePage4.Image = Nothing
        Me.NavigationPanePage4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavigationPanePage4.ImageFooter = Nothing
        Me.NavigationPanePage4.ImageIndex = -1
        Me.NavigationPanePage4.ImageIndexFooter = -1
        Me.NavigationPanePage4.ImageKey = ""
        Me.NavigationPanePage4.ImageKeyFooter = ""
        Me.NavigationPanePage4.ImageList = Nothing
        Me.NavigationPanePage4.ImageListFooter = Nothing
        Me.NavigationPanePage4.Key = "NavigationPanePage4"
        Me.NavigationPanePage4.Location = New System.Drawing.Point(1, 27)
        Me.NavigationPanePage4.Name = "NavigationPanePage4"
        Me.NavigationPanePage4.Size = New System.Drawing.Size(733, 145)
        Me.NavigationPanePage4.TabIndex = 3
        Me.NavigationPanePage4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavigationPanePage4.ToolTipText = Nothing
        '
        'NavigationPanePage5
        '
        Me.NavigationPanePage5.ActiveGradientHighColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.NavigationPanePage5.ActiveGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.NavigationPanePage5.AutoScroll = True
        Me.NavigationPanePage5.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.NavigationPanePage5.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.NavigationPanePage5.GradientHighColor = System.Drawing.SystemColors.ButtonHighlight
        Me.NavigationPanePage5.GradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.NavigationPanePage5.HighlightGradientHighColor = System.Drawing.Color.White
        Me.NavigationPanePage5.HighlightGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.NavigationPanePage5.Image = Nothing
        Me.NavigationPanePage5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavigationPanePage5.ImageFooter = Nothing
        Me.NavigationPanePage5.ImageIndex = -1
        Me.NavigationPanePage5.ImageIndexFooter = -1
        Me.NavigationPanePage5.ImageKey = ""
        Me.NavigationPanePage5.ImageKeyFooter = ""
        Me.NavigationPanePage5.ImageList = Nothing
        Me.NavigationPanePage5.ImageListFooter = Nothing
        Me.NavigationPanePage5.Key = "NavigationPanePage5"
        Me.NavigationPanePage5.Location = New System.Drawing.Point(1, 27)
        Me.NavigationPanePage5.Name = "NavigationPanePage5"
        Me.NavigationPanePage5.Size = New System.Drawing.Size(733, 145)
        Me.NavigationPanePage5.TabIndex = 4
        Me.NavigationPanePage5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavigationPanePage5.ToolTipText = Nothing
        '
        'GradientSplitBar1
        '
        Me.GradientSplitBar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GradientSplitBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientSplitBar1.GradientHighColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GradientSplitBar1.GradientLowColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GradientSplitBar1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientSplitBar1.Location = New System.Drawing.Point(0, 0)
        Me.GradientSplitBar1.Name = "GradientSplitBar1"
        Me.GradientSplitBar1.Size = New System.Drawing.Size(733, 6)
        Me.GradientSplitBar1.TabIndex = 0
        '
        'GradientLine1
        '
        Me.GradientLine1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GradientLine1.Location = New System.Drawing.Point(0, 0)
        Me.GradientLine1.Name = "GradientLine1"
        Me.GradientLine1.TabIndex = 0
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GradientPanel1.GradientHighColor = System.Drawing.SystemColors.HotTrack
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.TabIndex = 0
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 414)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.NavigationPane1.ResumeLayout(False)
        Me.NavigationPanePage1.ResumeLayout(False)
        Me.NavigationPanePage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents GradientLine1 As Ascend.Windows.Forms.GradientLine
    Private WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Private WithEvents NavigationPane1 As Ascend.Windows.Forms.NavigationPane
    Private WithEvents GradientSplitBar1 As Ascend.Windows.Forms.GradientSplitBar
    Private WithEvents GradientCaption1 As Ascend.Windows.Forms.GradientCaption
    Private WithEvents NavigationPanePage1 As Ascend.Windows.Forms.NavigationPanePage
    Private WithEvents NavigationPanePage2 As Ascend.Windows.Forms.NavigationPanePage
    Private WithEvents NavigationPanePage3 As Ascend.Windows.Forms.NavigationPanePage
    Private WithEvents NavigationPanePage4 As Ascend.Windows.Forms.NavigationPanePage
    Private WithEvents NavigationPanePage5 As Ascend.Windows.Forms.NavigationPanePage
    Private WithEvents GradientAnimation1 As Ascend.Windows.Forms.GradientAnimation
End Class
