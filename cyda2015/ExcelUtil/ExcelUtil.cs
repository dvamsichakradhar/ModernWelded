using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using Welded.FunctionalLayer;

namespace Welded.ExcelUtil
{
    class ExcelUtil
    {
        Microsoft.Office.Interop.Excel.Application _objApp;
        Microsoft.Office.Interop.Excel.Workbook _objBook;
        Microsoft.Office.Interop.Excel.Workbooks _objBooks;
        Microsoft.Office.Interop.Excel.Worksheets _objSheets;
        Microsoft.Office.Interop.Excel.Worksheet _objSheet;
        Microsoft.Office.Interop.Excel.Range _objrange;
        string _strErrorMessage;
        bool _blnError;

    
    public string ErrorMessage {
        get {
            return _strErrorMessage;
        }
    }

    public ExcelUtil()
    {
        connectToExcel();
    }
    
    public void connectToExcel() 
    {
        try {
            // objApp = New Excel.Application
            //    objApp = New Microsoft.Office.Interop.Excel.Application
            _objApp = (Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
            _objApp.AutoRecover.Enabled = false;
            if ((_objApp == null)) {
            
               modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Excel 2007 is not available in the system");
            }
        }
        catch (Exception) 
        {
            _strErrorMessage = String.Empty;
        }
    }
    
    public bool OpenWorkBook(string strFileName)
    {
        return OpenWorkBook(strFileName, true);
    }
    
    public bool OpenWorkBook(string strFileName, bool isActive) 
    {
        try 
        {
            _objBook = _objApp.Workbooks.Open(strFileName, isActive);
            return true;
        }
        catch (Exception) 
        {
            _strErrorMessage = "Unable to OpenWorkBook for given file.";
            return false;
        }
    }
    
    public bool CreateWorkSheet(string strSheetName, bool isReplace) 
    {
        try {
            
            if (isReplace) {
                if (OpenWorksheet(strSheetName)) {
                    _objSheet.Cells.Clear();
                    _objSheet.Activate();
                   
                    return true;
                }
            }
            
            _objSheet = _objBook.Worksheets.Add();
            _objSheet.Name = strSheetName;
            _objSheet.Activate();
           
            return true;
        }
        catch (Exception ex) {
            _strErrorMessage = "Unable to Create Sheet for given Workbook.";
            return false;
        }
    }
    
    public bool ClearAll(string strSheetName) 
    {
        try {
            _objSheet = _objBook.Worksheets[strSheetName];
            _objSheet.Activate();
            _objSheet.Cells.Clear();
            return true;
        }
        catch (Exception ex) 
        {
            _strErrorMessage = "Unable to Open Sheet for given Workbook.";
            return false;
        }
    }
    
    public bool OpenWorksheet(string strSheetName)
    {
        try
        {
           
            _objSheet = _objBook.Worksheets[strSheetName];
            
            _objSheet.Activate();
            return true;
        }
        catch (Exception ex) 
        {
            _strErrorMessage = "Unable to Open Sheet for given Workbook.";
            return false;
        }
    }
    
    public string GetExcelColumn(int index) 
    {
        int quotient = index/26;
        // '//Truncate  
        if ((quotient > 0)) {
            return (GetExcelColumn((quotient - 1)) + ((char)(((index % 26) + 65))).ToString());
        }
        else {
            return ((char)((index + 65))).ToString();
        }
    }
    
    public void Write(string key, string value, string cellParameterValue, string cellValue)
    {
        _objSheet.Range[cellValue].Value = value;
    }
    
    public void Write(int rowValue, int colValue, string Value)
    {
        string cellValue;
        cellValue = (GetExcelColumn(colValue) + rowValue);
        _objSheet.Range[cellValue].Value = Value;
    }
    
    public void Write(string cellValue, string value)
    {
        _objSheet.Range[cellValue].Value = value;
    }
    
    public object Read(string CellValue)
    {
        return _objSheet.Range[CellValue].Value;
    }
    
    public object Read(int rowValue, int colValue)
    {
        string cellValue;
        cellValue = (GetExcelColumn(colValue) + rowValue);
        return _objSheet.Range[cellValue].Value;
    }
    
    public bool Save() 
    {
        try {
            _objApp.DisplayAlerts = false;
            _objBook.Save();
            _objApp.DisplayAlerts = true;
            return true;
        }
        catch (Exception ex) {
            _strErrorMessage = "Unable to save the book";
            return false;
        }
    }
    
    public bool Close()
    {
        try {
            _objBook.Close();
            return true;
        }
        catch (Exception ex) {
            _strErrorMessage = "Unable to Close the book.\"";
            return false;
        }
    }
    
    public bool SaveAndClose() 
    {
        return (Save() && Close());
    }
    
    public bool Quit()
    {
        try {
            _objApp.Quit();
            _objApp = null;
            return true;
        }
        catch (Exception ex) {
            _strErrorMessage = "Unable to Quit the Excel Application";
            return false;
        }
    }
    }
}
