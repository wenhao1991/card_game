Attribute VB_Name = "模块1"
Sub to_csv()
    Dim SavePath As String
    Dim wb As Workbook
    Dim ws As Worksheet
    
    ' 设置保存路径
    SavePath = "D:\workspace\Unity_Project\design\csv"
    
    ' 禁用屏幕更新和警告信息
    Application.ScreenUpdating = False
    Application.DisplayAlerts = False
    
    ' 循环遍历所有工作簿
    For Each wb In Workbooks
        ' 循环遍历工作簿中的所有工作表
        For Each ws In wb.Worksheets
            ' 构建保存的文件名
            Dim FileName As String
            FileName = SavePath & ws.Name & ".csv"
            
            ' 保存工作表为CSV文件
            wb.SaveAs FileName, xlCSV
        Next ws
        
        ' 关闭工作簿
        wb.Close SaveChanges:=False
    Next wb
    
    ' 恢复屏幕更新和警告信息
    Application.ScreenUpdating = True
    Application.DisplayAlerts = True
    
    MsgBox "所有工作表已保存为CSV文件。"
End Sub
