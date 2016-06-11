Imports System.Data
Imports Cdb.Data
Imports System.Data.SqlClient

Public Class CCommon

#Region "常规功能"

    Public Shared Sub CheckDBNULL(ByRef _list As DataTable)
        For Each r As DataRow In _list.Rows
            For Each c As DataColumn In _list.Columns

                If IsDBNull(r.Item(c.ColumnName)) Then
                    r.Item(c.ColumnName) = 0
                End If

            Next
        Next
    End Sub

    Public Shared Sub checkDBNULL(ByRef _row As DataRow)
        For Each c As Object In _row.ItemArray

            If IsDBNull(c) Then
                c = 0
            End If

        Next
    End Sub

    ''' <summary>
    ''' 执行一条查询语句，从数据库中获取一个数据表。
    ''' </summary>
    ''' <param name="_strsql">语句</param>
    ''' <returns>数据表</returns>
    ''' <remarks></remarks>
    Public Shared Function GetSQLDatatable(ByVal _strsql As String) As DataTable
        Dim dt As New DataTable
        Dim db As New Data.CDB
        Dim da As New SqlDataAdapter(_strsql, db.Open)
        Debug.Print(_strsql)
        Try
            da.Fill(dt)
        Catch ex As Exception
            db.Close()
            Throw New ApplicationException(ex.Message)
        End Try
        da = Nothing
        db.Close()
        db = Nothing
        Return dt
    End Function

    ''' <summary>
    ''' 执行一条SQL命令。
    ''' </summary>
    ''' <param name="_strsql">语句</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ExecSQL(ByVal _strsql As String) As Boolean
        Dim db As New Data.CDB
        Dim cmd As New SqlClient.SqlCommand(_strsql, db.Open)
        Debug.Print(_strsql)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            db.Close()
            Throw New ApplicationException(ex.Message)
            Return False
        End Try
        cmd = Nothing
        db.Close()
        db = Nothing
        Return True
    End Function

#End Region


End Class

Public Class ConvertValue
    Public Shared Function ToStr(ByVal _obj As Object) As String
        If Not IsDBNull(_obj) Then
            Return Trim(Convert.ToString(_obj))
        End If
        Return ""
    End Function

    Public Shared Function ToInt(ByVal _obj As Object) As Integer
        If Not IsDBNull(_obj) Then
            Return Convert.ToInt16(_obj)
        End If
        Return 0
    End Function

    Public Shared Function ToDbl(ByVal _obj As Object) As Double
        If Not IsDBNull(_obj) Then
            Return Convert.ToDouble(_obj)
        End If
        Return 0
    End Function

    Public Shared Function ToDate(ByVal _obj As Object) As Date
        If Not IsDBNull(_obj) Then
            If IsDate(_obj) Then
                Return Convert.ToDateTime(_obj)
            End If
        End If
        Return DateTime.Now
    End Function
End Class