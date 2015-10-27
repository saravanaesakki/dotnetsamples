Imports System.Collections.Specialized
Imports System.configuration
Imports gss.Data
Imports gss.Data.BaseBusinessLogic
Imports Gss.Veracious
Imports Gss.Veracious.SysDB
Imports Gss.Core.FileStores
Imports Gss.Core.FileStores.FTP
Imports Gss.Veracious.CORE

Public Class ExportFTPScheduler

#Region " FIELDS "

    ' Download & Update Variables
    Private Resx_Path As String = System.IO.Path.GetDirectoryName(My.Application.Info.DirectoryPath) & "\LastUpdated.resx"
    Private objCon As New Gss.Data.DBConnectivity(ConfigurationSettings.AppSettings("ConnectionString"))
    Private ClientCode As String = ConfigurationSettings.AppSettings("ClientCode")
    Private UserName As String = ConfigurationSettings.AppSettings("UserName")
    Private strActionNAME As String = ConfigurationSettings.AppSettings("ACTIONNAME")
    Private strVIEWActionNAME As String = ConfigurationSettings.AppSettings("VIEWACTIONNAME")
    Private strARCActionNAME As String = ConfigurationSettings.AppSettings("ARCACTIONNAME")
    Private strARCVIEWActionNAME As String = ConfigurationSettings.AppSettings("ARCVIEWACTIONNAME")
    Private SrcSystemType As String = ConfigurationSettings.AppSettings("SrcSystemType")
    Private SrcSystemCode As String = ConfigurationSettings.AppSettings("SrcSystemCode")
    Private NoofArchivalIndex As Integer = ConfigurationSettings.AppSettings("NoofArchivalIndex")
    Private CopyFilePath As String = ConfigurationSettings.AppSettings("CopyFilePath")

    Private intParticipantid As Integer = 0
    Private intclientid As Integer = 0
    Private strUserID As String = ""
    Private strSRCSystemID As String = ""
    Private pRoutingNumber As String = ""
    Private intAICount As Integer
#End Region



#Region "General Functions "

    Private Sub GetClientDetails(ByVal PClientCode As String)
        Dim boolMadeConnection As Boolean = False
        objCon.Connect(boolMadeConnection)
        Try
            Dim ObjClients As New Gss.Veracious.SysDB.clsClients(objCon)
            objCon.Connect(boolMadeConnection)
            ObjClients.Select("ClientCode='" & PClientCode & "'", ObjClients.ParticipantID, ObjClients.ClientId)
            intParticipantid = ObjClients.ParticipantID.Value
            intclientid = ObjClients.ClientId.Value
        Catch ex As Exception
            Throw ex
        Finally
            ' DISCONNECT DATABASE                       
            objCon.Disconnect(boolMadeConnection)
        End Try
    End Sub

    Private Function GetWFActionS(ByVal ACTIONNAME As String) As DataTable
        Dim bConnected As Boolean = False
        Try
            objCon.Connect(bConnected)
            Dim objWFA As New Gss.Veracious.SysDB.clsWFActions(objCon)
            Dim dtcd As DataTable = objWFA.List("WFA.NAME = '" & ACTIONNAME & "'", "", objWFA.ID, objWFA.Context, objWFA.Description)
            Return dtcd
        Finally
            objCon.Disconnect(bConnected)
        End Try
    End Function

    Private Function GetModuleheaderid(ByVal pArcActionName As String) As Integer
        Dim bConnected As Boolean = False
        ' CONNECT DATABASE													
        Try
            objCon.Connect(bConnected)
            Dim objWF As New SysDB.clsWFActions(objCon)
            Dim objWFP As New SysDB.clsWFProcesses(objCon)
            Dim objJoin As New BaseBusinessLogic.EntityJoin
            objJoin.Join(objWF)
            objJoin.Join(objWFP, Gss.Data.BaseBusinessLogic.JoinTypes.InnerJoin, objWF.Process.Name & " = " & objWFP.Id.Name)
            objJoin.FullEntity.Connection = objCon.Connection
            Dim dt As DataTable = objJoin.FullEntity.List(objWF.Name.Name & "='" & pArcActionName & "'", "", objWFP.ModuleHeaderId)
            Return dt.Rows(0)(0)
        Finally
            ' DISCONNECT DATABASE												
            objCon.Disconnect(bConnected)
        End Try

    End Function

    Private Function GetRole(ByVal SrcSystemType As String) As String
        If SrcSystemType = "TPA" Then
            Return "Touch Point Admin"
        ElseIf SrcSystemType = "TP" Then
            Return "Touch Point Login"
        ElseIf SrcSystemType = "ARC" Then
            Return "Member Admin"
        End If
        Return ""
    End Function

    Private Sub GetParticipantDetails()
        Dim boolMadeConnection As Boolean = False
        objCon.Connect(boolMadeConnection)
        Try

            Dim objP As New SysDB.clsParticipant(objCon)
            Dim dtParticipants As DataTable = objP.List("P.participantid =" & intParticipantid, "", objP.NeedRoutingBasedClearingFlag, objP.ParticipantCode, objP.RoutingNo, objP.DefaultClearingHouseId)
            pRoutingNumber = dtParticipants.Rows(0).Item("RoutingNo")
        Catch ex As Exception
            Throw ex
        Finally
            objCon.Disconnect(boolMadeConnection)
        End Try
    End Sub

    Private Sub GetUserDetails(ByVal pClientID As Integer, ByVal pUserName As String)
        Dim boolMadeConnection As Boolean = False
        objCon.Connect(boolMadeConnection)
        Try
            Dim ObjUsers As New Gss.Veracious.SysDB.clsUsers(objCon)
            ObjUsers.Select("ClientID=" & pClientID & " And LoginName='" & pUserName & "'", ObjUsers.UserId)
            strUserID = ObjUsers.UserId.Value
        Catch ex As Exception
            Throw ex
        Finally
            objCon.Disconnect(boolMadeConnection)
        End Try
    End Sub

#Region " Prepare param values "

    Private Function __Prepareparams(ByVal pmoduleheaderid As Integer) As Specialized.NameValueCollection
        Dim params As New NameValueCollection
        Dim dtsystype As DataTable = LoadSystemType(pmoduleheaderid)
        Dim strsystemtype As String = dtsystype.Rows(0)("TYPE")

        Dim dtdestsyst As DataTable = LoadDestinationSystem(strsystemtype)
        Dim intdstsysid As Integer = dtdestsyst.Rows(0)("Systemid")

        Dim dtpt As DataTable = ListProcessTypes(pmoduleheaderid, strSRCSystemID, intdstsysid)
        Dim strprocesstype As String = dtpt.Rows(0)("PROCESSTYPE")

        Dim dtactions As DataTable = LoadActions(pmoduleheaderid, strprocesstype)
        Dim actionid As String = dtactions.Rows(0)("ID")
        Dim strcontext As String = dtactions.Rows(0)("context")

        Dim dtdm As DataTable = ListInterfaceDeliveryModes()
        Dim STRDELIVARYMODE As String = dtdm.Rows(0)("VALUE")

        params.Clear()
        params("DSTSYSTEMTYPE") = strsystemtype
        params("DSTSYSTEMCODE") = dtdestsyst.Rows(0)("Code")
        params("PROCESSTYPE") = strprocesstype
        params("DELIVERYMODE") = STRDELIVARYMODE
        params("GATEWAYID") = 0
        params("GATEWAYTYPE") = Nothing
        params("COMPRESSION") = Nothing
        params("ACTIONCONTEXT") = strcontext
        params("NEEDSESSION") = "N"
        params("DATETYPE") = "CREATEDDATE"
        params("DSTSYSTEMID") = intdstsysid
        params("SRCSYSTEMID") = strSRCSystemID
        params("ACTIONID") = actionid
        Return params
    End Function

    Private Function LoadSystemType(ByVal ModuleHeaderId As Integer) As DataTable
        Dim bConnected As Boolean = False
        ' CONNECT DATABASE													
        Try
            objCon.Connect(bConnected)
            Dim objSST As New SysDB.clsSubSystemTypes(objCon)
            Dim objWFA As New SysDB.clsWFActions(objCon)
            Dim objWFP As New SysDB.clsWFProcesses(objCon)
            Dim objJoin As New EntityJoin
            objJoin.Join(objSST)
            objJoin.Join(objWFA, JoinTypes.InnerJoin, "SST.Type=WFA.Context")
            objJoin.Join(objWFP, JoinTypes.InnerJoin, "WFA.Process=WFP.ID")

            objJoin.FullEntity.Connection = objCon.Connection
            Dim dt As DataTable = objJoin.FullEntity.ListDistinct(" WFA.ViewAction is Null and WFP.ModuleHeaderID=" & ModuleHeaderId, "", objSST.Type, objSST.Description)

            Return dt
        Finally
            ' DISCONNECT DATABASE												
            objCon.Disconnect(bConnected)
        End Try
    End Function

    Private Function LoadDestinationSystem(ByVal Type As String) As DataTable

        Dim bConnected As Boolean = False
        Try
            ' CONNECT DATABASE													
            objCon.Connect(bConnected)
            Dim objES As New SysDB.clsExchangeSetup(objCon)
            Dim objSS As New SysDB.clsSubSystems(objCon)
            Dim objJoin As New EntityJoin
            objJoin.Join(objES)
            objJoin.Join(objSS, JoinTypes.InnerJoin, "ES.DstSystem = SBS.SystemId")
            objJoin.FullEntity.Connection = objCon.Connection
            Dim dt As DataTable = objJoin.FullEntity.List("ES.SrcSystem = " & strSRCSystemID & " AND SBS.Type = '" & Type.Trim & "'", "", objSS.Name, objSS.SystemID, objSS.Code)
            Return dt
        Finally
            ' DISCONNECT DATABASE												
            objCon.Disconnect(bConnected)
        End Try
    End Function

    Private Function ListProcessTypes(ByVal ModuleHeaderID As Integer, ByVal SourceID As Integer, ByVal DestinationID As Integer) As DataTable
        Dim bConnected As Boolean = False
        Try
            ' CONNECT DATABASE													
            objCon.Connect(bConnected)
            Dim objID As New SysDB.clsExchangeFileFormats(objCon)
            Dim objFFG As New SysDB.clsFileFormatGroups(objCon)
            Dim objFFPT As New SysDB.clsFileFormatProcessTypes(objCon)
            Dim objWFPT As New clsWFProcessTemplates(objCon)
            Dim objWFP As New clsWFProcesses(objCon)
            Dim objFFD As New clsFileFormatDetails(objCon)
            Dim objPT As New clsProcessTypes(objCon)
            Dim objWFA As New clsWFActions(objCon)
            Dim objWFAP As New clsWFActionParameters(objCon)
            Dim objJoin As New EntityJoin
            objJoin.Join(objID)
            objJoin.Join(objFFG, JoinTypes.InnerJoin, "FFG.ID = EFF.FFGROUPID")
            objJoin.Join(objFFD, JoinTypes.InnerJoin, "FFG.ID = FFD.FFGROUPID")
            objJoin.Join(objFFPT, JoinTypes.InnerJoin, "FFPT.FFDetailID = FFD.ID")
            objJoin.Join(objPT, JoinTypes.InnerJoin, "FFPT.PROCESSTYPE = PT.PROCESSTYPE")
            objJoin.Join(objWFPT, JoinTypes.InnerJoin, "WFPT.ProcessType = FFPT.ProcessType")
            objJoin.Join(objWFP, JoinTypes.InnerJoin, "WFPT.ID = WFP.ProcessTemplate")
            objJoin.Join(objWFA, JoinTypes.InnerJoin, "WFA.Process = WFP.Id ")
            objJoin.Join(objWFAP, JoinTypes.InnerJoin, " WFA.ID = WFAP.Actionid ")
            objJoin.FullEntity.Connection = objCon.Connection
            Dim dt As DataTable = objJoin.FullEntity.ListDistinct(" EFF.SrcSystem=" & SourceID & " AND EFF.dstSystem=" & DestinationID & " AND WFP.ModuleHeaderID=" & ModuleHeaderID _
               & " AND WFAP.VALUE=EFF.CONTEXT AND WFAP.Name='FILEFILTER'  AND  WFA.ACTIONTYPE='V'", _
              "PT.ProcessOrder, PT.Description", objPT.ProcessType, objPT.Description, objPT.ProcessOrder)
            Return dt
        Finally
            ' DISCONNECT DATABASE												
            objCon.Disconnect(bConnected)
        End Try
    End Function

    Private Function LoadActions(ByVal ModuleHeaderId As Integer, ByVal ProcessType As String) As DataTable
        Dim bConnected As Boolean = False
        Try
            ' CONNECT DATABASE													
            objCon.Connect(bConnected)

            Dim ObjWFA As New SysDB.clsWFActions(objCon)
            Dim ObjWFP As New SysDB.clsWFProcesses(objCon)
            Dim ObjMH As New SysDB.clsModuleHeaders(objCon)
            Dim objWFPT As New SysDB.clsWFProcessTemplates(objCon)
            Dim ObjJoin As New EntityJoin
            ObjJoin.Join(ObjWFA)
            ObjJoin.Join(ObjWFP, JoinTypes.InnerJoin, "WFA.Process = WFP.Id")
            ObjJoin.Join(ObjMH, JoinTypes.InnerJoin, "WFP.ModuleHeaderId = MH.ModuleHeaderId")
            ObjJoin.Join(objWFPT, JoinTypes.InnerJoin, "WFPT.ID = WFP.ProcessTemplate")
            ObjJoin.FullEntity.Connection = objCon.Connection
            Dim dt As DataTable = ObjJoin.FullEntity.List("WFA.ViewAction IS NOT NULL AND WFA.ACTIONTYPE='V' AND WFP.ModuleHeaderId = " & ModuleHeaderId & " AND WFPT.ProcessType='" & ProcessType & "'", "ID", ObjWFA.ID, ObjWFA.Description, ObjWFA.Target, ObjWFA.Context)
            Return dt
        Finally
            ' DISCONNECT DATABASE												
            objCon.Disconnect(bConnected)
        End Try
    End Function

    Private Function ListInterfaceDeliveryModes() As DataTable
        Dim bConnected As Boolean
        objCon.Connect(bConnected)
        Try
            Return clsDBSupport.ListInterfaceDeliveryModes(objCon)
        Finally
            objCon.Disconnect(bConnected)
        End Try
    End Function

    Private Function ListDataForExchange(ByVal Actionid As Integer, ByVal srcSystemID As Integer, ByVal DstSystemID As Integer, ByVal ActionContext As String, ByVal Params As NameValueCollection) As Gss.Veracious.CTS.Workflow.DataModel.WFListViewInfo
        Dim bConnected As Boolean = False
        Dim bCompleted As Boolean = False
        Try
            ' CONNECT DATABASE		                                    
            objCon.Connect(bConnected, bCompleted)
            Dim strDstSystemType As String = Params("DSTSYSTEMTYPE")
            Dim dtHandler As DataTable = clsDBSupport.GetHandlersByCode(objCon, strDstSystemType & ":" & ActionContext, "XNGLIST")
            If dtHandler.Rows.Count = 0 Then
                Return Nothing
            End If
            Dim drHandler As DataRow = dtHandler.Rows(0)
            Dim strAsmName As String = drHandler("AssemblyName")
            Dim strTypName As String = drHandler("TypeName")
            Dim strUserName As String = UserName
            Dim strClientCode As String = ClientCode
            Dim strSystemRole As String = GetRole(SrcSystemType)
            Dim intUserId As Integer = strUserID
            Dim OutwardType As String = "SB"
            Dim InwardType As String = "SB"

            Dim asm As Reflection.Assembly = Reflection.Assembly.Load(strAsmName)
            Dim typ As Type = asm.GetType(strTypName)
            Dim objList As Gss.Veracious.Exchange.Core.IUIDataListing = Activator.CreateInstance(typ)
            With objList
                .ActionContext = ActionContext
                .ActionID = Actionid
                .ClientID = intclientid
                .ClientCode = strClientCode
                .Connectivity = objCon
                .DstSystemID = DstSystemID
                .HandlerParameter = drHandler("Parameter").ToString()
                .Params = Params
                .SrcSystemID = srcSystemID
                .SystemRole = strSystemRole
                .UserName = strUserName
                .UserId = intUserId
                .Process()
                bCompleted = True
                Return .Result
            End With
        Finally
            ' DISCONNECT DATABASE                       
            objCon.Disconnect(bConnected, bCompleted)
        End Try
    End Function

    Private Sub GetSubSystemDetails(ByVal sscode As String, ByVal sstype As String)
        Dim boolMadeConnection As Boolean = False
        objCon.Connect(boolMadeConnection)
        Try
            Dim Objss As New Gss.Veracious.SysDB.clsSubSystems(objCon)
            Objss.Select("Code='" & sscode & "' And Type='" & sstype & "'", Objss.SystemID)
            strSRCSystemID = Objss.SystemID.Value
        Catch ex As Exception
            Throw ex
        Finally
            objCon.Disconnect(boolMadeConnection)
        End Try
    End Sub

#End Region

#End Region

    Public Sub StartProcess()
        Try
            Gss.AppFx.Plugins.GlobalContext.Map("Temp1")
            GetClientDetails(ClientCode)
            GetParticipantDetails()
            GetSubSystemDetails(SrcSystemCode, SrcSystemType)
            GetUserDetails(intclientid, UserName)
            ExportFilesFromFTP()
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
        End Try
    End Sub

    Public Sub ExportFilesFromFTP()

        Dim dtACTIONS As DataTable = GetWFActionS(strARCActionNAME)
        If dtACTIONS.Rows.Count = 0 Then
            Debug.WriteLine(" Invalid Action id")
            Return
        End If
        Dim intProcessActionId As Integer = dtACTIONS.Rows(0)("ID")
        Dim intModuleheaderid As Integer = GetModuleheaderid(strARCActionNAME)
        Dim params As Specialized.NameValueCollection = __Prepareparams(intModuleheaderid)
        Dim OBJWFINFO As Gss.Veracious.CTS.Workflow.DataModel.WFListViewInfo = ListDataForExchange(params("actionid"), params("srcsystemid"), params("dstsystemid"), params("ACTIONcontexT"), params)

        '  __UploadFile()
    End Sub

    Public Function UploadFile(ByVal ActionID As Integer, ByVal pProceesData As DataTable, ByVal Params As NameValueCollection, ByVal ActionContext As String, ByVal SessionID As String) As DataTable
        Dim bConnected As Boolean = False
        Dim bCompleted As Boolean = False
        Try
            Dim intSrcSystemID As Integer = Session("SystemID")

            'If Params.Get("FILEFORMATID") Is Nothing Then
            '    Throw New System.Exception("FileFormat not defined.")
            'End If
            If Params("GATEWAYID") Is Nothing OrElse Params("GATEWAYTYPE") Is Nothing Then
                Throw New System.Exception("Gateway not defined.")
            End If
            If Params("COMPRESSION") Is Nothing Then
                Throw New System.Exception("Compression not defined.")
            End If
            If Params("PROCESSTYPE") Is Nothing Then
                Throw New System.Exception("Process type not defined.")
            End If

            Dim intTransferByteCount As Integer = 1024
            If Not Session("TransferByteCount") Is Nothing Then
                intTransferByteCount = Session("TransferByteCount")
            End If
            Params.Add("TRANSFERBYTECOUNT", intTransferByteCount)

            ' CONNECT DATABASE													
            objCon.Connect(bConnected, bCompleted)

            Dim dtData As DataTable = pProceesData.DefaultView.ToTable(True, "DSTSYSID", "FFGroupID", "DSTCODE").Copy

            Dim dc As New DataColumn("Result", GetType(String))
            dtData.Columns.Add(dc)

            For Each dr As DataRow In dtData.Rows
                pProceesData.DefaultView.RowFilter = "DSTSYSID = " & CInt(dr("DSTSYSID")) & " AND FFGroupID = " & CInt(dr("FFGroupID"))
                Dim dtTemp As DataTable = pProceesData.DefaultView.ToTable.Copy

                Dim FileIDs As Integer() = New Integer() {}
                If ActionContext = "CU" Then
                    Dim strFileIDs As String() = New String() {}
                    For Each drFileId As DataRow In dtTemp.Rows
                        strFileIDs = drFileId("FileID").ToString.Split(",")
                        FileIDs = New Integer(strFileIDs.Length - 1) {}
                        Dim index As Integer = 0
                        For Each ID As String In strFileIDs
                            FileIDs(index) = CInt(ID)
                            index += 1
                        Next
                    Next
                Else
                    FileIDs = New Integer(dtTemp.Rows.Count - 1) {}
                    Dim index As Integer = 0
                    For Each drFileId As DataRow In dtTemp.Rows
                        FileIDs(index) = CInt(drFileId("FileID"))
                        index += 1
                    Next
                End If

                Dim up As New Gss.Veracious.Exchange.FileUploadProcess(objCon)
                With up
                    .ActionContext = ActionContext
                    .ActionID = ActionID
                    .ClientCode = Session("LoginCode")
                    .ClientID = Session("LoginID")
                    .CurrencySymbol = Session("CurrencySymbol")
                    .DstSystemCode = dr("DSTCODE")
                    .DstSystemID = dr("DSTSYSID")
                    .DstSystemType = Params("DSTSYSTEMTYPE")
                    .ExchangeHeaderIDs = FileIDs
                    .Params = Params
                    .SrcSystemID = intSrcSystemID
                    .SystemRole = Session("Role")
                    .UserID = Session("UserId")
                    .UserName = Session("UserName").ToString()
                    .Perform()
                    dr("Result") = .Result
                End With
                If dr("Result").ToString.ToUpper = "SUCCESS" Then
                    bCompleted = True
                End If
            Next
            Return dtData
        Finally
            ' DISCONNECT DATABASE												
            objCon.Disconnect(bConnected, bCompleted)
        End Try
    End Function

    Private Function __UploadFile(ByVal SourceDirectory As String, ByVal SourceFileName As String, ByVal drGW As DataRow, ByRef FileStatus As String) As Boolean
        Dim strGatewayType As String = drGW("TYPE").ToString()
        Dim strGatewayConfig As String = drGW("CONFIG").ToString()
        Dim strExportFolder As String = drGW("WritePath").ToString()
        Dim strAssemblyName As String = drGW("AssemblyName").ToString()
        Dim strTypeName As String = drGW("TypeName").ToString()
        ' LOG PARAMETER
        Dim mLogFolder As String = drGW("WritePath")

        ' CREATE FILESTOREENGINE OBJECT									
        Dim fsc As IFileStoreEngine = FileStoreFactory.GetFileStoreEngine(strAssemblyName, strTypeName)

        fsc.Open()
        If fsc.IsOpened = False Then
            FileStatus = "Problem In  the selected Gateway Setup. Please Check the Gateway Setup."
            Return False
        End If
        ' ENGINE CONNECTION SUCCEEDED								

        ' CREATE FILESTORE OBJECT									
        Dim fs As IFileStore = fsc.GetFileStore()
        fs.ConnectionParams.FromString(strGatewayConfig)
        fs.Connect()

        Dim isUploaded As Boolean
        If fs.IsConnected = True Then
            ' FILESTORE CONNE
            Try
                fs.Path = strExportFolder
            Catch ex As Exception
                FileStatus = "Problem In the selected Gateway Setup. Please Check the Gateway Setup."
                fs.Disconnect()
                GoTo CLOSEHANDLE
            End Try



            Try
                isUploaded = fs.Upload(SourceDirectory & SourceFileName, SourceFileName)
            Catch e As Exception
                FileStatus = "File not uploaded. Please check gateway setup"
                Return False
            End Try
            If isUploaded Then
                FileStatus = "SUCCESS"
            Else
                FileStatus = "Either source file or destination folder does not exist. Please contact your system administrator."
            End If
            fs.Disconnect()
        Else
            FileStatus = "Problem in Gateway Configuration"
        End If
CLOSEHANDLE:
        fsc.Close()
        Return isUploaded
    End Function
End Class
