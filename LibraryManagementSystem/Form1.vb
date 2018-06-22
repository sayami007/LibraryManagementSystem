Imports MySql.Data.MySqlClient

Public Class Form1

    Dim conn As MySqlConnection
    Dim connectionString As String = "server=localhost;userid=root;password=;database=lms;sslMode=none"



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New MySqlConnection
        conn.ConnectionString = connectionString
        Try
            conn.Open()
            Dim adp As New MySqlDataAdapter("Select * from book;", conn)
            Dim ds As New DataTable()
            adp.Fill(ds)

            DataGridView1.DataSource = ds
            DataGridView1.ReadOnly = True
            conn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim book As New Book
        book.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim allRecord As New Records
        allRecord.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim returnBook As New StudentReturn
        returnBook.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

End Class
