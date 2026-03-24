Imports System.IO

Public Class ErrorLogger
    Private Shared logFilePath As String = "log.txt"

    Public Shared Sub LogError(message As String)
        Log("ERROR", message)
    End Sub

    Public Shared Sub LogInfo(message As String)
        Log("INFO", message)
    End Sub

    Public Shared Sub LogWarning(message As String)
        Log("WARNING", message)
    End Sub

    Private Shared Sub Log(severity As String, message As String)
        Dim logMessage As String = String.Format("[{0}] [{1}] {2}", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"), severity, message)
        Console.WriteLine(logMessage)
        WriteToFile(logMessage)
    End Sub

    Private Shared Sub WriteToFile(logMessage As String)
        Using writer As New StreamWriter(logFilePath, True)
            writer.WriteLine(logMessage)
        End Using
    End Sub
End Class