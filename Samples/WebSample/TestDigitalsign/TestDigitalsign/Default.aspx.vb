Partial Public Class _Default
    Inherits System.Web.UI.Page

    Dim objcon As New Gss.Data.DBConnectivity("User ID=TCSCT750CRINTMBDS;Password=gs$Impl;Data source=//SVR5-VM3-2K8.GSS.COM/IMPL11GR2.GSS.COM;")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objS As New Gss.Core.Security.clsEncryption
        objcon.Connect()
        Dim objssk As New Gss.Veracious.SysDB.clsSubSystemKeys(objcon)
        With objssk
            .PublicKey.Value = objS.Encrypt(System.Text.Encoding.Unicode.GetBytes(Server.HtmlDecode("<RSAKeyValue><Modulus>1NfnQEgPksvQiGxsGmEgC/Is7zr2zMfd0yZQ0CEmLohnAMAwT1qWgGA3oelFivUyz4++/rM9m/eFq86RPIWed0wLDiDaVjYxvFCZL350RjWjOhHgG7mOcXaxlEV0dE7jOv+Q8giIVpwQhY554Bcyp6wH/E2LhJn2EGFLRcxul3c=</Modulus><Exponent>AQAB</Exponent><P>9LLP9IyWj9z4pzpf0PfjQMtaUx+IjKajI9r5aMvjlwZEQGFU9/QyUQbcBRY9I40e2gr2E1QNFcXPuAHclqROJw==</P><Q>3qxz5D3mCBPej/qyLkqM3dNebtxKnsAXMAX4/GzaD8SmM1nh02ly2CgkvukcyDs+ck9I25ygvbcnnbVX9o6OMQ==</Q><DP>CD5+Ax85c19egUPWNpQjc+tl/6bwUszKckrOXFmCMXRkmEavNitkBpbUktdM+AWpJG96GuyaBEHF3c0yQWEHwQ==</DP><DQ>1U2HWp18zEIUUgHJS5S4agn/DN1TUc0aqTMfdtbi8HXk643vSHBbxfp2cLanjptJz4Bpf44DYJihh25ei921EQ==</DQ><InverseQ>vo6KOb2vO5YklYKMVVRPWlK09mrt348ugVALgovGTAV9tVZNbUeyzm3K2MNqU7obaGnwBYdRDugvPH2oFIz2wA==</InverseQ><D>w7SR6cVYrH3DjO1EqSzNLq7LKl1pOPo9uTzt6bHRTdAWBdaxlQWShQ/zl2jKjO7QfZGK6N8esx5xRnx1htTF0vXV3/VKvaqJuR4TtBuUU2putggju6MaWYYll/J6dYUydj1dlQC1FNyxCEy1RFD/NsurEQjADuQHzUOcLg+aeIE=</D></RSAKeyValue>")))
            .PublicKey.Value = objS.Encrypt(System.Text.Encoding.Unicode.GetBytes(Server.HtmlDecode("<RSAKeyValue><Modulus>1NfnQEgPksvQiGxsGmEgC/Is7zr2zMfd0yZQ0CEmLohnAMAwT1qWgGA3oelFivUyz4++/rM9m/eFq86RPIWed0wLDiDaVjYxvFCZL350RjWjOhHgG7mOcXaxlEV0dE7jOv+Q8giIVpwQhY554Bcyp6wH/E2LhJn2EGFLRcxul3c=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>")))
            .Update("keyid=41")
        End With
        objcon.Disconnect()
    End Sub

End Class