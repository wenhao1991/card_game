Attribute VB_Name = "ģ��1"
Sub to_csv()
    Dim SavePath As String
    Dim wb As Workbook
    Dim ws As Worksheet
    
    ' ���ñ���·��
    SavePath = "D:\workspace\Unity_Project\design\csv"
    
    ' ������Ļ���º;�����Ϣ
    Application.ScreenUpdating = False
    Application.DisplayAlerts = False
    
    ' ѭ���������й�����
    For Each wb In Workbooks
        ' ѭ�������������е����й�����
        For Each ws In wb.Worksheets
            ' ����������ļ���
            Dim FileName As String
            FileName = SavePath & ws.Name & ".csv"
            
            ' ���湤����ΪCSV�ļ�
            wb.SaveAs FileName, xlCSV
        Next ws
        
        ' �رչ�����
        wb.Close SaveChanges:=False
    Next wb
    
    ' �ָ���Ļ���º;�����Ϣ
    Application.ScreenUpdating = True
    Application.DisplayAlerts = True
    
    MsgBox "���й������ѱ���ΪCSV�ļ���"
End Sub
