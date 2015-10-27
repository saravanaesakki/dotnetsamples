Imports System.Data.SqlClient
'Imports System.windows.forms


Public Class DirectCallDataTransfer

#Region " Variables "

    Dim intSampleCount As Integer = 0
    Dim strIsDelete As String = ConfigManager.GetIsDelete

#End Region

#Region " Common Functions "

    Public Sub StartProcess()
        Try
            Gss.AppFx.Plugins.GlobalContext.Map("Temp1")
            'Dim objSampleCount As Object = ConfigManager.GetSampleCount()
            'If objSampleCount Is Nothing Then
            '    intSampleCount = 0
            'Else
            '    intSampleCount = Val(ConfigManager.GetSampleCount)
            'End If
            __UpdateCustomerMaster()
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
        End Try
    End Sub

    Private Sub __UpdateCustomerMaster()
        Dim objDstCon As SqlConnection = New SqlConnection(ConfigManager.GetDstConnString)
        objDstCon.Open()

        'objCmd = New OracleCommand("SELECT * FROM V_CI_CUSTMAST", objSrcCon)
        'Dim drdr As OracleDataReader = objCmd.ExecuteReader()

        Dim ds As New DataSet


        Dim CmdInsert As New SqlCommand
        Dim CmdDelete As New SqlCommand
        Dim CmdUpdate As New SqlCommand

        CmdInsert.CommandType = CommandType.Text
        CmdInsert.Connection = objDstCon
        CmdInsert.CommandText = "INSERT INTO KVB.V_CI_CUSTMAST(REPLICATIONFLAG,CUSTOMERCODE,NAME,ADDRESS1,ADDRESS2,ADDRESS3,CITY,STATE,COUNTRY,POSTALCODE,EMAILADDRESS,PHONENO,FAXNO,STATUS,CONTACTPERSONNAME,TYPE,GROUP_ID,HOME_SECTOR) VALUES('A',@CUSTOMERCODE,@NAME,@ADDRESS1,@ADDRESS2,@ADDRESS3,@CITY,@STATE,@COUNTRY,@POSTALCODE,@EMAILADDRESS,@PHONENO,@FAXNO,@STATUS,@CONTACTPERSONNAME,@TYPE,@GROUP_ID,@HOME_SECTOR)"

        Dim prmCustomerCode1 As SqlParameter = New SqlParameter("@CUSTOMERCODE", SqlDbType.BigInt)
        Dim prmName1 As SqlParameter = New SqlParameter("@NAME", SqlDbType.VarChar, 180)
        Dim prmAddress11 As SqlParameter = New SqlParameter("@ADDRESS1", SqlDbType.VarChar, 105)
        Dim prmAddress21 As SqlParameter = New SqlParameter("@ADDRESS2", SqlDbType.VarChar, 105)
        Dim prmAddress31 As SqlParameter = New SqlParameter("@ADDRESS3", SqlDbType.VarChar, 105)
        Dim prmCity1 As SqlParameter = New SqlParameter("@CITY", SqlDbType.VarChar, 105)
        Dim prmState1 As SqlParameter = New SqlParameter("@STATE", SqlDbType.VarChar, 105)
        Dim prmCountry1 As SqlParameter = New SqlParameter("@COUNTRY", SqlDbType.VarChar, 105)
        Dim prmPostalCode1 As SqlParameter = New SqlParameter("@POSTALCODE", SqlDbType.VarChar, 105)
        Dim prmEmailAddress1 As SqlParameter = New SqlParameter("@EMAILADDRESS", SqlDbType.VarChar, 120)
        Dim prmPhoneNo1 As SqlParameter = New SqlParameter("@PHONENO", SqlDbType.VarChar, 137)
        Dim prmFaxNo1 As SqlParameter = New SqlParameter("@FAXNO", SqlDbType.VarChar, 45)
        Dim prmStatus1 As SqlParameter = New SqlParameter("@STATUS", SqlDbType.Char, 1)
        Dim prmContactPersonName1 As SqlParameter = New SqlParameter("@CONTACTPERSONNAME", SqlDbType.VarChar, 600)
        Dim prmType1 As SqlParameter = New SqlParameter("@TYPE", SqlDbType.Char, 1)
        Dim prmGroup_Id1 As SqlParameter = New SqlParameter("@GROUP_ID", SqlDbType.Char, 1)
        Dim prmHome_Sector1 As SqlParameter = New SqlParameter("@HOME_SECTOR", SqlDbType.SmallInt)

        'Dim prmCustomerCode2 As SqlParameter = New SqlParameter("@CUSTOMERCODE", SqlDbType.BigInt)

        'Dim prmCustomerCode3 As SqlParameter = New SqlParameter("@CUSTOMERCODE", SqlDbType.BigInt)
        'Dim prmName3 As SqlParameter = New SqlParameter("@NAME", SqlDbType.VarChar, 180)
        'Dim prmAddress13 As SqlParameter = New SqlParameter("@ADDRESS1", SqlDbType.VarChar, 105)
        'Dim prmAddress23 As SqlParameter = New SqlParameter("@ADDRESS2", SqlDbType.VarChar, 105)
        'Dim prmAddress33 As SqlParameter = New SqlParameter("@ADDRESS3", SqlDbType.VarChar, 105)
        'Dim prmCity3 As SqlParameter = New SqlParameter("@CITY", SqlDbType.VarChar, 105)
        'Dim prmState3 As SqlParameter = New SqlParameter("@STATE", SqlDbType.VarChar, 105)
        'Dim prmCountry3 As SqlParameter = New SqlParameter("@COUNTRY", SqlDbType.VarChar, 105)
        'Dim prmPostalCode3 As SqlParameter = New SqlParameter("@POSTALCODE", SqlDbType.VarChar, 105)
        'Dim prmEmailAddress3 As SqlParameter = New SqlParameter("@EMAILADDRESS", SqlDbType.VarChar, 120)
        'Dim prmPhoneNo3 As SqlParameter = New SqlParameter("@PHONENO", SqlDbType.VarChar, 137)
        'Dim prmFaxNo3 As SqlParameter = New SqlParameter("@FAXNO", SqlDbType.VarChar, 45)
        'Dim prmStatus3 As SqlParameter = New SqlParameter("@STATUS", SqlDbType.VarChar, 1)
        'Dim prmContactPersonName3 As SqlParameter = New SqlParameter("@CONTACTPERSONNAME", SqlDbType.VarChar, 600)
        'Dim prmType3 As SqlParameter = New SqlParameter("@TYPE", SqlDbType.VarChar, 1)
        'Dim prmGroup_Id3 As SqlParameter = New SqlParameter("@GROUP_ID", SqlDbType.Char, 1)
        'Dim prmHome_Sector3 As SqlParameter = New SqlParameter("@HOME_SECTOR", SqlDbType.SmallInt)

        CmdInsert.Parameters.Add(prmCustomerCode1)
        CmdInsert.Parameters.Add(prmName1)
        CmdInsert.Parameters.Add(prmAddress11)
        CmdInsert.Parameters.Add(prmAddress21)
        CmdInsert.Parameters.Add(prmAddress31)
        CmdInsert.Parameters.Add(prmCity1)
        CmdInsert.Parameters.Add(prmState1)
        CmdInsert.Parameters.Add(prmCountry1)
        CmdInsert.Parameters.Add(prmPostalCode1)
        CmdInsert.Parameters.Add(prmEmailAddress1)
        CmdInsert.Parameters.Add(prmPhoneNo1)
        CmdInsert.Parameters.Add(prmFaxNo1)
        CmdInsert.Parameters.Add(prmStatus1)
        CmdInsert.Parameters.Add(prmContactPersonName1)
        CmdInsert.Parameters.Add(prmType1)
        CmdInsert.Parameters.Add(prmGroup_Id1)
        CmdInsert.Parameters.Add(prmHome_Sector1)

        'CmdDelete.Parameters.Add(prmCustomerCode2)

        'CmdUpdate.Parameters.Add(prmCustomerCode3)
        'CmdUpdate.Parameters.Add(prmName3)
        'CmdUpdate.Parameters.Add(prmAddress13)
        'CmdUpdate.Parameters.Add(prmAddress23)
        'CmdUpdate.Parameters.Add(prmAddress33)
        'CmdUpdate.Parameters.Add(prmCity3)
        'CmdUpdate.Parameters.Add(prmState3)
        'CmdUpdate.Parameters.Add(prmCountry3)
        'CmdUpdate.Parameters.Add(prmPostalCode3)
        'CmdUpdate.Parameters.Add(prmEmailAddress3)
        'CmdUpdate.Parameters.Add(prmPhoneNo3)
        'CmdUpdate.Parameters.Add(prmFaxNo3)
        'CmdUpdate.Parameters.Add(prmStatus3)
        'CmdUpdate.Parameters.Add(prmContactPersonName3)
        'CmdUpdate.Parameters.Add(prmType3)
        'CmdUpdate.Parameters.Add(prmGroup_Id3)
        'CmdUpdate.Parameters.Add(prmHome_Sector3)

        Dim tran As SqlTransaction = objDstCon.BeginTransaction()
        CmdInsert.Transaction = tran
        CmdUpdate.Transaction = tran
        CmdDelete.Transaction = tran

        Dim k As Integer = 0
        Dim t1 As DateTime = DateTime.Now()
        Dim t2 As DateTime
        'For index As Integer = 0 To RecordIndex - 1
        '    drdr.Read()
        'Next
        Do While drdr.Read()
            Try
                'Dim strReplicationFlag As Object = drdr("REPLICATIONFLAG")
                'If IsDBNull(strReplicationFlag) Or strReplicationFlag Is Nothing Then
                '    strReplicationFlag = "A"
                'End If
                'Select Case DirectCast(strReplicationFlag, String)
                '    Case "A"
                prmCustomerCode1.Value = drdr("CUSTOMERCODE")
                prmName1.Value = drdr("NAME")
                prmAddress11.Value = drdr("ADDRESS1")
                prmAddress21.Value = drdr("ADDRESS2")
                prmAddress31.Value = drdr("ADDRESS3")
                prmCity1.Value = drdr("CITY")
                prmState1.Value = drdr("STATE")
                prmCountry1.Value = drdr("COUNTRY")
                prmPostalCode1.Value = drdr("POSTALCODE")
                prmEmailAddress1.Value = drdr("EMAILADDRESS")
                prmPhoneNo1.Value = drdr("PHONENO")
                prmFaxNo1.Value = drdr("FAXNO")
                prmStatus1.Value = drdr("STATUS")
                prmContactPersonName1.Value = drdr("CONTACTPERSONNAME")
                prmType1.Value = drdr("TYPE")
                prmGroup_Id1.Value = drdr("GROUP_ID")
                prmHome_Sector1.Value = drdr("HOME_SECTOR")
                CmdInsert.ExecuteNonQuery()
                '    Case "D"
                'prmCustomerCode2.Value = drdr("CUSTOMERCODE")
                'CmdDelete.ExecuteNonQuery()
                '    Case "M"
                'prmCustomerCode3.Value = drdr("CUSTOMERCODE")
                'prmName3.Value = drdr("NAME")
                'prmAddress13.Value = drdr("ADDRESS1")
                'prmAddress23.Value = drdr("ADDRESS2")
                'prmAddress33.Value = drdr("ADDRESS3")
                'prmCity3.Value = drdr("CITY")
                'prmState3.Value = drdr("STATE")
                'prmCountry3.Value = drdr("COUNTRY")
                'prmPostalCode3.Value = drdr("POSTALCODE")
                'prmEmailAddress3.Value = drdr("EMAILADDRESS")
                'prmPhoneNo3.Value = drdr("PHONENO")
                'prmFaxNo3.Value = drdr("FAXNO")
                'prmStatus3.Value = drdr("STATUS")
                'prmContactPersonName3.Value = drdr("CONTACTPERSONNAME")
                'prmType3.Value = drdr("TYPE")
                'prmGroup_Id3.Value = drdr("GROUP_ID")
                'prmHome_Sector3.Value = drdr("HOME_SECTOR")
                'CmdUpdate.ExecuteNonQuery()
                'End Select
                k += 1
                If (k Mod 10000) = 0 Then
                    t2 = DateTime.Now()
                    lstOutput.SelectedIndex = lstOutput.Items.Add("CI_CUSTMAST: " & k.ToString("N0") & " - " & t2.Subtract(t1).TotalSeconds().ToString("N2") & " - " & (k / t2.Subtract(t1).TotalSeconds).ToString("N2"))
                    Application.DoEvents()
                    GC.Collect()
                    tran.Commit()
                    tran = objDstCon.BeginTransaction()
                    CmdInsert.Transaction = tran
                    CmdUpdate.Transaction = tran
                    CmdDelete.Transaction = tran
                End If
                If intSampleCount > 0 And k >= intSampleCount Then
                    tran.Commit()
                    objDstCon.Close()
                    Return
                End If
            Catch ex As Exception
                'Select Case DirectCast(drdr("REPLICATIONFLAG"), String)
                '    Case "A"
                '        ParameterLog("Customer Insert", CmdInsert)
                '    Case "M"
                '        ParameterLog(" Customer Update ", CmdUpdate)
                'End Select
                MsgBox(ex.StackTrace)
            End Try
        Loop
        tran.Commit()
        objDstCon.Close()
    End Sub

#End Region
End Class
