Imports System.Data.SqlClient

Public Class DatabaseHelper
    Private connectionString As String = "Your_Connection_String_Here"

    ' Method to test the connection to the database
    Public Function TestConnection() As Boolean
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Return True
            End Using
        Catch ex As Exception
            Console.WriteLine("Error connecting to database: " & ex.Message)
            Return False
        End Try
    End Function

    ' Method to get Estudiante by Cedula with error handling and retry logic
    Public Function GetEstudianteByCedula(cedula As String) As DataRow
        Dim retryCount As Integer = 3
        Dim delay As Integer = 2000 ' 2 seconds delay

        For attempt As Integer = 1 To retryCount
            Try
                Using connection As New SqlConnection(connectionString)
                    connection.Open()
                    Dim command As New SqlCommand("SELECT * FROM Estudiantes WHERE Cedula = @Cedula", connection)
                    command.Parameters.AddWithValue(@"Cedula", cedula)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    If table.Rows.Count > 0 Then
                        Return table.Rows(0)
                    Else
                        Return Nothing
                    End If
                End Using
            Catch ex As Exception
                Console.WriteLine("Error getting estudiante: " & ex.Message)
                If attempt < retryCount Then
                    Threading.Thread.Sleep(delay)
                Else
                    Return Nothing
                End If
            End Try
        Next
        Return Nothing
    End Function

    ' Method to insert a new Estudiante with error handling
    Public Function InsertEstudiante(cedula As String, nombre As String, apellido As String) As Boolean
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim command As New SqlCommand("INSERT INTO Estudiantes (Cedula, Nombre, Apellido) VALUES (@Cedula, @Nombre, @Apellido)", connection)
                command.Parameters.AddWithValue(@"Cedula", cedula)
                command.Parameters.AddWithValue(@"Nombre", nombre)
                command.Parameters.AddWithValue(@"Apellido", apellido)
                command.ExecuteNonQuery()
                Return True
            End Using
        Catch ex As Exception
            Console.WriteLine("Error inserting estudiante: " & ex.Message)
            Return False
        End Try
    End Function

    ' Method to get Trimestres with error handling
    Public Function GetTrimestres() As DataTable
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim command As New SqlCommand("SELECT * FROM Trimestres", connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                Return table
            End Using
        Catch ex As Exception
            Console.WriteLine("Error getting trimestres: " & ex.Message)
            Return Nothing
        End Try
    End Function
End Class