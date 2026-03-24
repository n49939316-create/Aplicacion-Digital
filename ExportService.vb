Imports OfficeOpenXml
Imports System.IO
Imports System.Net

Public Class ExportService

    ' Method to export data to Excel
    Public Function ExportToExcel(data As List(Of MyDataModel), outputPath As String) As String
        Dim uniqueFilename As String = GenerateUniqueFilename(outputPath)
        Try
            Using package As New ExcelPackage()
                Dim worksheet = package.Workbook.Worksheets.Add("Data")
                ' Add headers
                worksheet.Cells(1, 1).Value = "Header1"
                worksheet.Cells(1, 2).Value = "Header2"
                ' Populate worksheet with data
                For i As Integer = 0 To data.Count - 1
                    worksheet.Cells(i + 2, 1).Value = data(i).Property1
                    worksheet.Cells(i + 2, 2).Value = data(i).Property2
                Next

                ' Save the package
                package.SaveAs(New FileInfo(uniqueFilename))
            End Using
            Return uniqueFilename
        Catch ex As IOException
            Throw New Exception("File is in use or cannot be accessed: " & ex.Message)
        Catch ex As UnauthorizedAccessException
            Throw New Exception("Permission error when attempting to save the file: " & ex.Message)
        Catch ex As Exception
            Throw New Exception("An error occurred while exporting data: " & ex.Message)
        End Try
    End Function

    ' Generate a unique filename based on the current timestamp
    Private Function GenerateUniqueFilename(basePath As String) As String
        Dim timestamp As String = DateTime.UtcNow.ToString("yyyyMMddHHmmss")
        Dim uniqueFilename As String = Path.Combine(Path.GetDirectoryName(basePath), Path.GetFileNameWithoutExtension(basePath) & "_" & timestamp & Path.GetExtension(basePath))
        Return uniqueFilename
    End Function
End Class
