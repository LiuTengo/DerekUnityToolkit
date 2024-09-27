using System.IO;
using UnityEngine;
using OfficeOpenXml;

public class ExcelReadTest : MonoBehaviour
{
    public string fileName;
    private void Start()
    {
        LoadExcel(fileName);
    }

    public static void LoadExcel(string fileName)
    {
        string path = Application.dataPath + "/ExcelData/"+fileName+".xlsx";
        FileStream fs = new FileStream(path,FileMode.Open,FileAccess.Read,FileShare.ReadWrite);
        ExcelPackage excel = new ExcelPackage(fs);
        ExcelWorksheets workSheet = excel.Workbook.Worksheets;
        //Excel表格的索引从1开始
        for (int i=1;i<=workSheet.Count;i++)
        {
            ExcelWorksheet sheet = excel.Workbook.Worksheets[i];
            int columnCount = sheet.Dimension.End.Column;
            int rowCount = sheet.Dimension.End.Row;
            Debug.Log($"Sheet{sheet.Name}");
            for (int row=1;row<=rowCount;row++)
            {
                for (int col = 1;col<=columnCount;col++)
                {
                    var text = sheet.Cells[row,col].Text;
                    Debug.Log($"下标：{row},{col}，内容：{text}");
                }
            }
        }
    }
}
