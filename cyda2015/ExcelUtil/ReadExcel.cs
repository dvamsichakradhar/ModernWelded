using System.Text;
using System.Text.RegularExpressions;
using System;

namespace Welded.ExcelUtil
{
    class ReadExcel
    {
        private  StringBuilder _strErrorMessage; 
        private bool _isError;
        private ExcelUtil oExcel;

        
    public string ErrorMessage
    {
        get
        {
            return _strErrorMessage.ToString();
        }
    }
    public bool isError
    {
        get
        {
            return _isError;
        }
    }

    public ReadExcel()
    {
        _isError = false;
        _strErrorMessage = new StringBuilder();
    }
    public bool Open(string strFileName)
    {
        oExcel = OpenSheet(strFileName);
        if (oExcel == null)
        {
            return false;
        }
        return true;      

    }

    
    public string Read(string CellValue)
    {
        string Read = oExcel.Read(CellValue).ToString();
        return Read;
    }

    public void Close()
    {
        try
        {
            oExcel.SaveAndClose();
            oExcel.Quit();

        }
        catch (Exception)
        {

            
        }
    }

    private ExcelUtil OpenSheet(string strFileName)
    {
        ExcelUtil oExcel = new ExcelUtil();
        if (!oExcel.OpenWorkBook(strFileName, false))
        {
            _isError = true;
            _strErrorMessage.Append(oExcel.ErrorMessage);
            return null;
        }
        if (!oExcel.OpenWorksheet("Sheet1"))
        {
            _isError = true;
            _strErrorMessage.Append(oExcel.ErrorMessage);
            return null;
        }
        return oExcel;
    }











    }
}
