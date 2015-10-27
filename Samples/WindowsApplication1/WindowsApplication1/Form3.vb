Imports System.Collections.Specialized
Imports System.Text

Public Class Form3

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MsgBox(Convert.ToBase64String(Encoding.ASCII.GetBytes("marimuthu")))

        Return
        Dim ds As New DataSet()
        'dsHelper = New DataSetHelper.DataSetHelper(ds)
        '
        ' Create source tables
        '
        Dim dt As New DataTable("Employees")
        dt.Columns.Add("EmployeeID", GetType(Integer))
        dt.Columns.Add("FirstName", GetType(String))
        dt.Columns.Add("LastName", GetType(String))
        dt.Columns.Add("BirthDate", GetType(DateTime))
        dt.Columns.Add("JobTitle", GetType(String))
        dt.Columns.Add("DepartmentID", GetType(Integer))
        dt.Rows.Add(New Object() {1, "Tommy", "Hill", #12/31/1970#, "Manager", 42})
        dt.Rows.Add(New Object() {2, "Brooke", "Sheals", #12/31/1977#, "Manager", 23})
        dt.Rows.Add(New Object() {3, "Bill", "Blast", #5/6/1982#, "Sales Clerk", 42})
        dt.Rows.Add(New Object() {1, "Kevin", "Kline", #5/13/1978#, "Sales Clerk", 42})
        dt.Rows.Add(New Object() {1, "Martha", "Seward", #7/4/1976#, "Sales Clerk", 23})
        dt.Rows.Add(New Object() {1, "Dora", "Smith", #10/22/1985#, "Trainee", 42})
        dt.Rows.Add(New Object() {1, "Elvis", "Pressman", #11/5/1972#, "Manager", 15})
        dt.Rows.Add(New Object() {1, "Johnny", "Cache", #1/23/1984#, "Sales Clerk", 15})
        dt.Rows.Add(New Object() {1, "Jean", "Hill", #4/14/1979#, "Sales Clerk", 44})
        dt.Rows.Add(New Object() {1, "Anna", "Smith", #6/26/1985#, "Trainee", 15})
        ds.Tables.Add(dt)

        dt = New DataTable("Departments")
        dt.Columns.Add("DepartmentID", GetType(Integer))
        dt.Columns.Add("DepartmentName", GetType(String))
        dt.Rows.Add(New Object() {15, "Men's Clothing"})
        dt.Rows.Add(New Object() {23, "Women's Clothing"})
        dt.Rows.Add(New Object() {42, "Children's Clothing"})
        ds.Tables.Add(dt)

        ds.Relations.Add("DepartmentEmployee", ds.Tables!Departments.Columns!DepartmentID, ds.Tables!Employees.Columns!DepartmentID, False)

    End Sub
End Class