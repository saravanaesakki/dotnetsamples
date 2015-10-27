Imports Gss.Veracious
Imports Gss.Data

Public Class Form1

    Private Sub FindValueInDataView(ByVal table As DataTable)
        Dim view As DataView = New DataView(table)
        view.Sort = "Customeraccountname"

        ' Find the customer named "John Smith". 
        Dim vals(1) As Object
        vals(0) = "raja"
        vals(1) = "Smith"
        Dim i As Integer = view.Find(vals)
        Console.WriteLine(view(i))
    End Sub

    Private Sub CompareDataTables(ByVal dTable1 As DataTable, ByVal dTable2 As DataTable, ByVal SearchColIndex As Integer, ByRef dtout1 As DataTable, ByRef dtout2 As DataTable)
        Dim dr As DataRow
        Dim MatchRow As DataRow
        For Each dr In dTable1.Rows
            MatchRow = dTable2.Rows.Find(dr.Item(SearchColIndex))
            If MatchRow Is Nothing Then 'If the record is not in Table 2
                dtout1.Rows.Add(dr) 'Add to RowsInFirstTable
            Else
                dtout2.Rows.Add(MatchRow) 'Add to RowsInBoth Table
            End If
        Next
        dtout1.AcceptChanges()
        dtout2.AcceptChanges()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dt As New DataTable
        ' dt.Columns.Add("Customeraccountno")
        dt.Columns.Add("Customeraccountname")
        dt.Rows.Add("raja")
        dt.Rows.Add("bala")
        dt.Rows.Add("ravi")
        dt.Rows.Add("mani")
        Dim view As DataView = New DataView(dt)
        view.Sort = "Customeraccountname"
        Dim i As Integer = view.Find("raja")
        Dim dtss As DataTable = view.ToTable
        Return

        Dim dt2 As New DataTable
        dt2.Columns.Add("Customeraccountno")
        Dim dcCustomerNo As DataColumn = dt2.Columns.Add("CustomerAccountNo")
        dt2.PrimaryKey = New DataColumn() {dcCustomerNo}
        dt.Rows.Add("raja")
        'dt.Rows.Add("Smith")
        dt2.Rows.Add(101, "raja")
        dt2.Rows.Add(103, "bala")

        FindValueInDataView(dt)
        'Dim dtout1 As New DataTable
        'Dim dtout2 As New DataTable
        'CompareDataTables(dt, dt2, 0, dtout1, dtout2)

        Return

        '******************************************************************
        'Dim objcon As New Gss.Data.DBConnectivity("User ID=TCSCT750CRRWEQB;Password=gssImpl;Data source=//vtserver/orcl;")
        'objcon.Connect()
        'Dim dtpi As New DataTable
        'dtpi.Columns.Add("paymentitemid")
        'dtpi.Columns.Add("CUSTOMERNAME")
        'dtpi.Columns.Add("LastModifiedBy")
        'dtpi.Columns.Add("LastModifiedDate")
        'dtpi.Rows.Add("7542", "raja", "gssvadmin", DateTime.Now)
        'Dim objPI As New SysDB.Process.clsPaymentItems(objcon)
        'With objPI
        '    .PaymentItemId.Used = True
        '    .CUSTOMERNAME.Used = True
        '    .LastModifiedBy.Used = True
        '    .LastModifiedDate.Used = True
        '    .Update(dtPI, 0)
        'End With
        'objcon.Disconnect()
        'Dim objbsvc As New Gss.Veracious.CTS.Client.Services.BatchService
        'Dim intDBTranCount As Integer = objbsvc.GetTransactionCount(21341, "OP")
    End Sub


    '    Private Function StartImport(ByVal AppImportFolder As String, ByVal pConfig As String, ByVal ImportFolder As String, ByVal GateId As Integer, ByVal FileName As String, ByVal DstSystemID As Integer, ByVal SrcSystemID As Integer, ByVal Domain As GatewayDomains, ByVal vIsCoreBanking As Boolean, ByVal ProcessType As String, ByVal SendMail As Boolean, ByVal ActionID As Integer, ByVal FFGroupID As Integer, ByVal pAssemblyName As String, ByVal pTypeName As String, ByVal pLog As List(Of String)) As String
    '        Dim FileStatus As String = ""
    '        Dim isDownloaded As Boolean
    '        Try
    '            Dim fsc As FileStores.IFileStoreEngine = FileStores.FileStoreFactory.GetFileStoreEngine(pAssemblyName, pTypeName)
    '            ' SETUP CONNECTIONPARAMS- USE REGISTRY PROXY SETTINGS TO OPEN	
    '            fsc.ConnectionParams.FromString("AccessType=0")
    '            fsc.Open()
    '            ' SETUP CONNECTIONPARAMS- USE DIRECT IP CONNECTION WITH THE HOST
    '            If fsc.IsOpened = True Then
    '                pLog.Add("Internet Open handle was set successfully.")
    '                ' CREATE FILESTORE OBJECT									
    '                Dim fs As FileStores.IFileStore = fsc.GetFileStore()
    '                fs.ConnectionParams.FromString(pConfig)
    '                fs.Connect()

    '                If fs.IsConnected = True Then
    '                    If ImportFolder <> "/" AndAlso ImportFolder <> "\" Then
    '                        Try
    '                            fs.Path = ImportFolder
    '                            pLog.Add("Internet Connection handle was set successfully.")
    '                        Catch ex As System.Exception
    '                            pLog.Add("Setting Ftp Current Directory was failed.")
    '                            FileStatus = "Problem In  the selected Gateway Setup. Please Check the Gateway Setup."
    '                            pLog.Add(FileStatus)
    '                            fs.Disconnect()
    '                            pLog.Add("Internet Connection  was closed successfully.")
    '                            GoTo CLOSEHANDLE
    '                        End Try
    '                    Else
    '                        pLog.Add("Ftp Current Directory was Root")
    '                    End If
    '                    Try
    '                        isDownloaded = fs.Download(FileName, AppImportFolder & "\" & FileName)
    '                    Catch
    '                        FileStatus = "File not downloaded.Check gateway setup"
    '                        Return FileStatus
    '                    End Try
    '                    If isDownloaded = True Then
    '                        'FileStatus = UpdateLog(0, isDownloaded, AppImportFolder, GateId, DstSystemID, SrcSystemID, Domain, vIsCoreBanking, ProcessType, DstSystemID, SendMail, 0, FileName, ActionID, FileFormatID, Me.mLogSessionUser)
    '                        FileStatus = ""
    '                        pLog.Add("A file named " & FileName & " was downloaded successfully.")
    '                    Else
    '                        FileStatus = "Destination folder does not exist, Please contact your system administrator."
    '                    End If
    '                End If
    '            Else
    '                pLog.Add("Internet Open handle was failed.")
    '                FileStatus = "Problem in Gateway Configuration"
    '            End If
    'CLOSEHANDLE:
    '            fsc.Close()
    '            pLog.Add("Internet Close  handled successfully.")
    '            If isDownloaded Then
    '                FileStatus = "SUCCESS"
    '            End If
    '            Return FileStatus
    '        Catch e As System.Exception
    '            Return FileStatus
    '        End Try
    '    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim result As String = StartImport()
        result = RetryFTPProcess(result)
    End Sub

    Private Function RetryFTPProcess(ByVal result As String) As String
        If result = "" Then
tryagain:
            Dim msgresult As MsgBoxResult = MsgBox("FTP Could not be connected. Please try again.", MsgBoxStyle.YesNo, "Veracious")
            If msgresult = MsgBoxResult.Yes Then
                result = StartImport()
                If result = "" Then
                    GoTo tryagain
                End If
            End If
        End If
        Return result
    End Function

    Private Function StartImport() As String
        Dim FileStatus As String = ""
        Dim x As Integer = 0
        Dim y As Integer = 10
        Try
            Dim a As Integer = y / x
        Catch ex As Exception
            Return FileStatus
        End Try
        FileStatus = "Success"
        Return FileStatus
    End Function
End Class
