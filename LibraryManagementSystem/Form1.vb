Imports MySql.Data.MySqlClient

Public Class Form1

    Dim conn As MySqlConnection
    Dim connectionString As String = "server=localhost;userid=root;password=;database=lms;sslMode=none"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New MySqlConnection
        conn.ConnectionString = connectionString
        Try
            conn.Open()
            Dim query As String = "SELECT Book_Id,Book_Name, Author, Catogory_ID, ISBN FROM book ;"
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn = New MySqlConnection
        conn.ConnectionString = connectionString
        Try
            Console.WriteLine(TextBox1.Text)
            If TextBox1.Text = "" Then
                MsgBox("Please enter the book name")
                Dim query As String = "SELECT Book_Id, Book_Name, Author, Catogory_ID, ISBN FROM book "
                conn.Open()
                Dim adp As New MySqlDataAdapter(query, conn)
                Dim ds As New DataTable()
                adp.Fill(ds)
                DataGridView1.DataSource = ds
                DataGridView1.ReadOnly = True
                conn.Close()
            Else
                Dim query As String = "SELECT Book_Id,Book_Name, Author, Catogory_ID, ISBN FROM book WHERE Book_Name = '" & TextBox1.Text & "'"
                conn.Open()
                Dim adp As New MySqlDataAdapter(query, conn)
                Dim ds As New DataTable()
                Dim count = adp.Fill(ds)
                If count <= 0 Then
                    MsgBox("No record found")
                Else
                    DataGridView1.DataSource = ds
                    DataGridView1.ReadOnly = True
                End If
                conn.Close()
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim allRecord As New Records
        allRecord.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim returnBook As New StudentReturn
        returnBook.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim selectedBook As String = DataGridView1.Rows.Item(e.RowIndex).Cells.Item(0).Value
        Dim bookInformation As New Book
        bookInformation.ok(selectedBook)

        bookInformation.Show()
    End Sub
End Class