Imports System
Imports System.IO
Imports System.Diagnostics

Namespace Data
    '
    ' 从udl文件中读取数据库连接字符串。
    '

    Public Class CUDL

#Region "成员"
        Private ReadOnly mFileName As String
        Private ReadOnly mConnectionText As String

        Private m_strPesistSecurity As String
        Private m_strIntegradedSecurity As String
        Private m_strReconstructed As String

        Private m_strDefaultFilename As String
        Private m_strDatasource As String
        Private m_strPassword As String
        Private m_strUserID As String
        Private m_strCatalog As String 'Database
#End Region

#Region "构造"
        Public Sub New()
            m_strPesistSecurity = ""
            m_strIntegradedSecurity = ""
            m_strReconstructed = ""
            m_strDefaultFilename = ""
            m_strDatasource = ""
            m_strPassword = ""
            m_strUserID = ""
            m_strCatalog = ""
            mFileName = "c:\gvhis\gvlive.udl"
            'mFileName = "c:\cshis\cs2000.udl"
            mConnectionText = ReadFromFile()
            SplitConnectionString()
        End Sub

#End Region

#Region "方法"
        Private Function ReadFromFile() As String
            Dim rule As String = ""
            Dim sr As StreamReader
            If Not File.Exists(mFileName) Then
                Throw New ApplicationException(mFileName & ":数据连接文件未找到!")
                Return rule
            End If
            sr = File.OpenText(mFileName)
            rule = sr.ReadToEnd
            sr.Close()
            Return rule
        End Function

        Public Function GetConnectionText() As String
            ReconstructSQLConnectionString()
            Return m_strReconstructed
        End Function

        Private Sub ReconstructSQLConnectionString()

            m_strReconstructed = m_strPesistSecurity & ";"

            If Not IsNothing(m_strIntegradedSecurity) Then
                m_strReconstructed &= m_strIntegradedSecurity & ";"
            End If
            If Not IsNothing(m_strPesistSecurity) Then
                m_strReconstructed &= m_strPesistSecurity & ";"
            End If
            ' 如果集成安全=false
            If m_strPesistSecurity.IndexOf("False") Then
                If Not IsNothing(m_strPassword) Then
                    m_strReconstructed &= m_strPassword & ";"
                End If
                If Not m_strUserID.Length = 0 Then
                    m_strReconstructed &= m_strUserID & ";"
                End If
            End If
            m_strReconstructed &= m_strCatalog & ";"
            m_strReconstructed &= m_strDatasource & ";"

        End Sub

        Private Function SplitConnectionString() As Boolean
            If mConnectionText = "" Then
                Return False
            End If
            Dim strArray As String() = Nothing
            Dim strString As String = ""
            Dim strProvider As String = ""

            Dim strDRIVER As String = ""
            Dim strSERVER As String = ""
            Dim strUID As String = ""
            Dim strDATABASE As String = ""

            strArray = mConnectionText.Split(";")

            If strArray(0).IndexOf("[oledb]") = -1 Then
                MsgBox(mFileName & ":Read Error！")
            End If

            For Each strString In strArray

                If strString.IndexOf("Provider") > -1 Then
                    strProvider = strString.Substring(strString.IndexOf("Provider"))
                End If

                If strString.IndexOf("Password") > -1 Then
                    m_strPassword = strString
                End If

                If strString.IndexOf("Data") > -1 Then
                    m_strDatasource = strString
                End If

                If strString.IndexOf("User") > -1 Then
                    m_strUserID = strString
                End If

                If strString.IndexOf("Initial") > -1 Then
                    m_strCatalog = strString
                End If

                If strString.IndexOf("Integrated") > -1 Then
                    m_strIntegradedSecurity = strString
                End If

                If strString.IndexOf("Persist") > -1 Then
                    m_strPesistSecurity = strString
                End If
                If strString.IndexOf("DRIVER") > -1 Then
                    strDRIVER = strString.Substring(strString.IndexOf("DRIVER"))
                End If
                If strString.IndexOf("SERVER") > -1 Then
                    strSERVER = strString
                End If
                If strString.IndexOf("UID") > -1 Then
                    strUID = strString
                End If
                If strString.IndexOf("DATABASE") > -1 Then
                    strDATABASE = strString
                    strDATABASE = strDATABASE.Remove(strDATABASE.Length - 3, 3)
                End If

            Next

            'Check if the connection string connects to SQLServer or Oracle Server.
            If strProvider.IndexOf("MSDASQL") > -1 Then
                If strDRIVER.IndexOf("SQL Server") > -1 Then

                    m_strDatasource = "Data Source" & strSERVER.Substring(6)
                    If strUID.Length > 0 Then
                        m_strUserID = "User ID" & strUID.Substring(3)
                    End If
                    m_strCatalog = "Initial Catalog " & strDATABASE.Substring(8)
                End If

            ElseIf strProvider.IndexOf("SQLOLEDB") > -1 Then
                ' m_strDatasource = m_strDatasource.Remove(m_strDatasource.Length - 2, 2)

            ElseIf strProvider.IndexOf("OraOLEDB") > -1 Then  'Oracle provider for OLEDB

            ElseIf strProvider.IndexOf("MSDAORA") > -1 Then 'Microsoft Provider for Oracle
            End If

            Return True
        End Function

#End Region
    End Class
End Namespace