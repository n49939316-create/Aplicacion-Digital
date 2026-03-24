Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms

Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize DataGridView
        InitializeDataGridView()
    End Sub

    Private Sub InitializeDataGridView()
        ' Example grades data
        Dim dt As New DataTable()
        dt.Columns.Add("Student Name")
        dt.Columns.Add("Trimester 1 Grade")
        dt.Columns.Add("Trimester 2 Grade")
        dt.Columns.Add("Trimester 3 Grade")

        ' Sample data
        dt.Rows.Add("John Doe", 85, 90, 88)
        dt.Rows.Add("Jane Smith", 78, 83, 80)

        ' Bind DataGridView
        DataGridView1.DataSource = dt
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ' Export DataGridView to Excel
        ExportToExcel()
    End Sub

    Private Sub ExportToExcel()
        Dim excelApp As New Microsoft.Office.Interop.Excel.Application()
        Dim workbook As Microsoft.Office.Interop.Excel.Workbook = excelApp.Workbooks.Add()
        Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet = CType(workbook.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        ' Write DataGridView content to Excel
        For i As Integer = 0 To DataGridView1.Columns.Count - 1
            worksheet.Cells(1, i + 1).Value = DataGridView1.Columns(i).HeaderText
        Next

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            For j As Integer = 0 To DataGridView1.Columns.Count - 1
                worksheet.Cells(i + 2, j + 1).Value = DataGridView1.Rows(i).Cells(j).Value
            Next
        Next

        ' Save and cleanup
        excelApp.Visible = True
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        ' Print functionality
        PrintDocument1.Print()
    End Sub
End Class