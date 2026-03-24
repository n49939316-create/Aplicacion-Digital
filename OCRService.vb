Imports Tesseract
Imports System.Text.RegularExpressions

Public Class OCRService
    Private Const MAX_RETRIES As Integer = 3

    ' Method to extract data from image
    Public Function ExtractDataFromImage(imagePath As String) As Dictionary(Of String, String)
        Dim retries As Integer = 0
        Dim result As New Dictionary(Of String, String)

        While retries < MAX_RETRIES
            Try
                ' Initialize Tesseract engine
                Using engine As New TesseractEngine("./tessdata", "eng", EngineMode.Default)
                    Using img As Pix = Pix.LoadFromFile(imagePath)
                        Using page As Page = engine.Process(img)
                            Dim text As String = page.GetText()
                            Dim ocrData As String = ProcessOCRText(text)
                            result = ExtractDetails(ocrData)
                        End Using
                    End Using
                End Using
                Exit While  ' Exit loop if successful
            Catch ex As Exception
                retries += 1
                If retries >= MAX_RETRIES Then
                    Console.WriteLine("Error processing image: " & ex.Message)
                End If
            End Try
        End While
        Return result
    End Function

    ' Method to process OCR text
    Private Function ProcessOCRText(text As String) As String
        ' You may add additional processing logic if needed
        Return text
    End Function

    ' Method to extract details using regex
    Private Function ExtractDetails(text As String) As Dictionary(Of String, String)
        Dim details As New Dictionary(Of String, String)
        ' Regex patterns for cedula, nombre, profesor, and notas
        Dim cedulaPattern As String = "Cedula:\s*(\d+)"
        Dim nombrePattern As String = "Nombre:\s*(.*?)\s*Profesor"
        Dim profesorPattern As String = "Profesor:\s*(.*?)\s*Notas"
        Dim notasPattern As String = "Notas:\s*(.*?)$"

        details("Cedula") = Regex.Match(text, cedulaPattern).Groups(1).Value
        details("Nombre") = Regex.Match(text, nombrePattern).Groups(1).Value
        details("Profesor") = Regex.Match(text, profesorPattern).Groups(1).Value
        details("Notas") = Regex.Match(text, notasPattern).Groups(1).Value

        Return details
    End Function
End Class