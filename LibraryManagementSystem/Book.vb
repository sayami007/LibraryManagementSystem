Imports MySql.Data.MySqlClient

Public Class Book

    Dim conn As MySqlConnection
    Dim connectionString As String = "server=localhost;userid=root;password=;database=lms;sslMode=none"



    Sub ok(id As String)
        conn = New MySqlConnection
        conn.ConnectionString = connectionString
        Dim query As String = "SELECT * FROM book  WHERE Book_Id = '" & id & "'"
        conn.Open()
        Dim cmd As New MySqlCommand(query, conn)
        Dim value = cmd.ExecuteReader
        Console.WriteLine(value)
        conn.Close()
        Console.WriteLine(id)

    End Sub
End Class