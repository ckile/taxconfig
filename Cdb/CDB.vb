Imports System.Data
Imports System.Data.SqlClient

Namespace Data
    '
    ' 数据库连接类。
    '

    Public Class CDB
#Region "成员"
        Public ReadOnly ConnectionText As String
        Private db As SqlConnection
        Private mFilePath As String
#End Region

#Region "构造"
        Public Sub New()
            mFilePath = "GVS.udl"
            ConnectionText = (New CUDL()).GetConnectionText
            'Debug.Print(ConnectionText)
            db = New SqlConnection(ConnectionText)
        End Sub
#End Region

#Region "方法"
        ''' <summary>
        ''' 获取数据连接。
        ''' </summary>
        ''' <remarks>返回SqlConnection对象。</remarks>
        Public Function Open() As SqlConnection
            If Not db.State = ConnectionState.Open Then
                Try
                    db.Open()
                Catch ex As Exception
                    MsgBox("不能连接到数据库！")
                    Return Nothing
                End Try
            End If
            Return db
        End Function
        ''' <summary>
        ''' 关闭当前连接。
        ''' </summary>
        Public Sub Close()
            If db.State = ConnectionState.Open Then
                db.Close()
            End If
        End Sub

#End Region

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class

End Namespace