Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim objf As New XmlNotepad.FormMain
        'objf.ShowDialog()
        'Dim objxe As New Microsoft.XmlEditor.XmlEditorControl
        Dim FROMCHECKNO As String = "000000430301"
        Dim TOCHECKNO As String = "000000860651"
        Dim a As String = CInt(CInt(FROMCHECKNO) + CInt(TOCHECKNO)).ToString.PadLeft(12, "0") 'drdr("CHQ_NUM_OF_LVS")

        MsgBox(a)

    End Sub

    'Private Sub AppendAttribute(ByVal xmlfile As String)
    '    Dim xmlDoc As New Xml.XmlDocument()
    '    If File.Exists(xmlFile) Then
    '        xmlDoc.Load(xmlFile)
    '        Dim list As Xml.XmlNodeList = xmlDoc.GetElementsByTagName("FileHeader")
    '        Dim i As Integer = 0
    '        For Each node As Xml.XmlNode In list
    '            ' if element already there, it will override            
    '            Dim newAttr As Xml.XmlAttribute = xmlDoc.CreateAttribute("xmlns")
    '            node.Attributes.Append(newAttr)

    '            ' remove xml attribute            
    '            node.Attributes.RemoveNamedItem("xmlns")
    '        Next
    '        xmlDoc.Save(xmlFile)
    '    End If
    'End Sub
End Class
