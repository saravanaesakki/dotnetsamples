<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.XmlTextEditor1 = New WindowsApplication1.Greg.XmlEditor.Presentation.Views.XmlTextEditor
        Me.SuspendLayout()
        '
        'XmlTextEditor1
        '
        Me.XmlTextEditor1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XmlTextEditor1.Location = New System.Drawing.Point(0, 0)
        Me.XmlTextEditor1.Name = "XmlTextEditor1"
        Me.XmlTextEditor1.ShowInvalidLines = False
        Me.XmlTextEditor1.Size = New System.Drawing.Size(284, 264)
        Me.XmlTextEditor1.TabIndent = 2
        Me.XmlTextEditor1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 264)
        Me.Controls.Add(Me.XmlTextEditor1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XmlTextEditor1 As WindowsApplication1.Greg.XmlEditor.Presentation.Views.XmlTextEditor


End Class
