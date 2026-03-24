Imports System.Text.RegularExpressions

Public Class ValidationHelper

    ' Validate Cedula format (Dominican Republic)
    Public Shared Function IsValidCedula(cedula As String) As Boolean
        Dim regex As New Regex("^(\d{3}-\d{7}-\d)$")
        Return regex.IsMatch(cedula)
    End Function

    ' Validate Nombre
    Public Shared Function IsValidNombre(nombre As String) As Boolean
        Return Not String.IsNullOrWhiteSpace(nombre) AndAlso nombre.All(Function(c) Char.IsLetter(c) OrElse Char.IsWhiteSpace(c))
    End Function

    ' Validate Apellido
    Public Shared Function IsValidApellido(apellido As String) As Boolean
        Return Not String.IsNullOrWhiteSpace(apellido) AndAlso apellido.All(Function(c) Char.IsLetter(c) OrElse Char.IsWhiteSpace(c))
    End Function

    ' Validate FechaNacimiento
    Public Shared Function IsValidFechaNacimiento(fecha As DateTime) As Boolean
        Dim fechaMinima As DateTime = New DateTime(1900, 1, 1)
        Dim fechaMaxima As DateTime = DateTime.UtcNow
        Return fecha >= fechaMinima AndAlso fecha <= fechaMaxima
    End Function

    ' Validate Nota (0-5 decimal)
    Public Shared Function IsValidNota(nota As Decimal) As Boolean
        Return nota >= 0D AndAlso nota <= 5D
    End Function

    ' Validate Creditos (0-21 integer)
    Public Shared Function IsValidCreditos(creditos As Integer) As Boolean
        Return creditos >= 0 AndAlso creditos <= 21
    End Function

    ' Validate Email format
    Public Shared Function IsValidEmail(email As String) As Boolean
        Dim regex As New Regex("^[^\s@]+@[\w-]+(\.[\w-]+)+$")
        Return regex.IsMatch(email)
    End Function

    ' Comprehensive Student Validation
    Public Shared Function EstudianteValidation(cedula As String, nombre As String, apellido As String, fechaNacimiento As DateTime, nota As Decimal, creditos As Integer, email As String) As Boolean
        Return IsValidCedula(cedula) AndAlso IsValidNombre(nombre) AndAlso IsValidApellido(apellido) AndAlso IsValidFechaNacimiento(fechaNacimiento) AndAlso IsValidNota(nota) AndAlso IsValidCreditos(creditos) AndAlso IsValidEmail(email)
    End Function

End Class