Imports MySql.Data.MySqlClient
Public Class StudentReturn
    Dim conn As MySqlConnection
    Dim connectionString As String = "server=localhost;userid=root;password=;database=lms;sslMode=none"

    Private Sub StudentReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New MySqlConnection
        conn.ConnectionString = connectionString
        Try
            conn.Open()
            Dim query As String = "SELECT * FROM issue ;"
            Dim adp As New MySqlDataAdapter(query, conn)
            Dim ds As New DataTable()
            adp.Fill(ds)
            DataGridView1.DataSource = ds
            DataGridView1.ReadOnly = True
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class