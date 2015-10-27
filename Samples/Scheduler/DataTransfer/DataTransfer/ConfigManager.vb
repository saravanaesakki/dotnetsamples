Imports System.Configuration

Public Class ConfigManager
    Public Shared Function GetSampleCount() As String
        Return ConfigurationManager.AppSettings("SampleCount")
    End Function

    Public Shared Function GetDstConnString() As String
        Return ConfigurationManager.AppSettings("DestinationConnString").ToString
    End Function

    Public Shared Function GetIsDelete() As String
        Return ConfigurationManager.AppSettings("IsDelete")
    End Function
End Class
