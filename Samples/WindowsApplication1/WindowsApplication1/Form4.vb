Public Class Form4

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        dt.Columns.Add("Deptname")
        dt.Columns.Add("Deptid")
        dt.Rows.Add(New Object() {"sales", 10})
        dt.Rows.Add(New Object() {"Purchase", 20})
        dt.Rows.Add(New Object() {"Accounts", 30})


        MultiSelectionControl1.Datasource = dt
        MultiSelectionControl1.DisplayMember = "Deptname"

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox(MultiSelectionControl1.SelectedValues)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        '        MultiSelectionControl1.SelectDefault("sales,Purchase".Split(","))
        Dim str(0) As String
        MultiSelectionControl1.SelectDefault(str)
    End Sub
End Class