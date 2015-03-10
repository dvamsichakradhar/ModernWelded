using System.IO;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using System.Collections;
using System;
using Welded.FunctionalLayer;

namespace Welded.ExcelLayer
{
    class ExcelClass
    {

        IDictionaryEnumerator IDEnumerator;
        Microsoft.Office.Interop.Excel.Application objApp;
        Microsoft.Office.Interop.Excel.Workbook objBook;
        Microsoft.Office.Interop.Excel.Workbooks objBooks;
        Microsoft.Office.Interop.Excel.Sheets objSheets;
        Microsoft.Office.Interop.Excel.Worksheet objSheet;
        Microsoft.Office.Interop.Excel.Range objrange;
        Directory _dirObj_Directory;
        string _strSubdirectory;
        string _strFileName;
        string strFileNameSave;
        int intIinput = 3;
        XlLinkType xlink;


        public void connectToExcel()
        {
            try
            {
                objApp = new Microsoft.Office.Interop.Excel.Application();
                objApp.AutoRecover.Enabled = false;
                if ((objApp == null))
                {
                    
                   modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("EXCEL 2007 is not available in the system");
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void checkExcelInstance()
        {
            try
            {
                if ((objApp == null))
                {
                    connectToExcel();
                }
            }
            catch (Exception ex)
            {
            }
        }

        // THE BELOW CODE IS COMMON FOR UPDATING THE MAIN EXCEL SHEET AND INDIVIDUAL EXCEL SHEETS.
        //public void updateDesign_Parameters(string strType)
        //{
        //    int intI = 0;
        //    int intStart = 0;
        //    int intEnd = 0;
        //    int intJ = 0;
        //    try
        //    {
        //        intI = 1;
        //        intStart = 0;
        //        while ((objSheet.Range[("D" + intI)].Value.ToUpper() == "Start".ToUpper()))
        //        {
        //            intStart = (intStart + 1);
        //            intI = (intI + 1);
        //        }
        //        intEnd = 0;
        //        intI = 1;
        //        while ((objSheet.Range[("D" + intI)].Value.ToUpper() != "End".ToUpper()))
        //        {
        //            intEnd = (intEnd + 1);
        //            intI = (intI + 1);
        //        }
        //        string[] storeVal=null;
        //        int[] StorePos;
        //        //object Preserve=storeVal[0];
        //        //object Preserve=StorePos[0];
        //        intJ = 0;
        //        for (intI = (intStart + 1); (intI <= intEnd); intI++)
        //        {
        //            if ((!(objSheet.Range[("D" + intI)].Value == null)
        //                        && (objSheet.Range[("D" + intI)].Value.ToUpper() != "No".ToUpper())))
        //            {
        //                //object Preserve=storeVal[intJ];
        //                //object Preserve=StorePos[intJ];
        //                storeVal[intJ] = objSheet.Range[("B" + intI)].Value;
        //                StorePos[intJ] = intI;
        //                intJ = (intJ + 1);
        //            }
        //        }
        //        for (intI = 0; (intI
        //                    <= (storeVal.Length - 1)); intI++)
        //        {
        //            while (IDEnumerator.MoveNext())
        //            {
        //                if (storeVal[intI].Trim().Equals(IDEnumerator.Key))
        //                {
        //                    objSheet.Range[("C" + StorePos[intI])].Value = IDEnumerator.Value;
        //                }
        //            }
        //            IDEnumerator.Reset();
        //        }
        //        objApp.DisplayAlerts = false;
        //        objBook.Save();
        //        objBook.Close();
        //        objApp.DisplayAlerts = true;
        //        objApp.Quit();
        //        objApp = null;
        //        return;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //public void updateGUIParameters(string key, string value)
        //{
        //    try
        //    {
        //        objSheet.Range[("B" + intIinput)].Value = key;
        //        objSheet.Range[("C" + intIinput)].Value = value;
        //        intIinput++;
        //        try
        //        {
        //            objSheet.Rows.AutoFit();
        //        }
        //        catch (Exception ex)
        //        {
        //        }
        //        objApp.DisplayAlerts = false;
        //        objBook.Save();
        //        objApp.DisplayAlerts = true;
        //        return;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}
        // The below code is for updating the design part parameters of individual excel sheets.
        public void getExcelFiles(string strPath)
        {
            ProcessDirectory(strPath);
        }

        public void ProcessDirectory(string targetDirectory) 
        {
        try 
        {
            if ((objApp == null)) 
            {
                connectToExcel();
            }
            objApp.Visible = false;
            string[] arrFileEntries = Directory.GetFiles(targetDirectory);
            string[] arrFileEntriesSave = Directory.GetFiles(targetDirectory);
            foreach(string _strFileName in arrFileEntries) 
            {
                objApp.DisplayAlerts = false;
                try {
                    objApp.AskToUpdateLinks = false;
                    objBook = objApp.Workbooks.Open(_strFileName);
                    objBook.EnableAutoRecover = false;
                    objBook.UpdateLinks = Microsoft.Office.Interop.Excel.XlUpdateLinks.xlUpdateLinksAlways;
                    objBook.SaveLinkValues = true;
                }
                catch (Exception ex) {
                }
                objApp.DisplayAlerts = false;
                objBook.Save();
                objApp.Workbooks.Close();
                
                objApp.DisplayAlerts = true;
            }
            string[] arrSubdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string _strSubdirectory in arrSubdirectoryEntries)
            {
                ProcessDirectory(_strSubdirectory);
            }
        }
        catch (Exception ex) 
        {
           
    }
        }

        // ProcessDirectory
       
        public void SaveExcel(string strExcelFile)
        {
            try
            {
                if (File.Exists(strExcelFile))
                {
                    objApp.DisplayAlerts = false;
                    objApp.AskToUpdateLinks = false;
                    objBook = objApp.Workbooks.Open(strExcelFile);
                    objBook.UpdateLinks = Microsoft.Office.Interop.Excel.XlUpdateLinks.xlUpdateLinksAlways;
                    objBook.SaveLinkValues = true;
                    objBook.Save();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void BreakXlLink(string FileName, string strLink)
        {
           
            try
            {
                xlink = XlLinkType.xlLinkTypeExcelLinks;
                objBook = objApp.Workbooks.Open(FileName);
                objBook.Save();
                objBook.BreakLink(strLink, xlink);
                objBook.Save();
                objBook.Close();
                objApp = null;
            }
            catch (Exception ex)
            {
            }
        }

        public void SaveSfSheet(string FileName)
        {
            
            objBook.SaveAs(FileName);
            objBook.Close();
            objApp = null;
        }
    }
}
