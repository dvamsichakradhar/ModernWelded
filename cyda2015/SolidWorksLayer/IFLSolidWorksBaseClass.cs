using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolidWorks;
using SldWorks;
using Welded.FunctionalLayer;
using System.IO;
using System.Diagnostics;
using VB = Microsoft.VisualBasic.FileIO;
using Welded.FunctionalLayer;


namespace Welded.SolidWorksLayer
{
    public class IFLSolidWorksBaseClass
    {
        #region Variables

        public Hashtable _htDocumentInstances;
        public bool blnVisibleSolidWorks = true;
        private string _strErrorMessage;
        private Exception _oErrorObject;
        private SldWorks.SldWorks _oCurrentSolidWorksObject;
        SldWorks.SldWorks oSolidWorksApplication;
        SldWorks.ModelDoc2 oSolidWorksModel;
        SldWorks.AssemblyDoc oSolidWorksAssembly;
        SldWorks.PartDoc oSolidWorksPartDocument;
        SldWorks.DrawingDoc oSolidWorksDrawingDocument;
        public SldWorks.View oSolidWorksView;
        public int nWarnings=0;
        public int Errors=0;
        public bool boolStatus;
        private SldWorks.SldWorks swApp;
        public SldWorks.ModelDocExtension swModelExt;
        public SldWorks.SwOLEObject swOleObj;

        #endregion

        public IFLSolidWorksBaseClass(bool blnVisibleSolidworks)
        {
            SolidWorksApplicationObject.Visible = blnVisibleSolidworks;
            if ((SolidWorksApplicationObject == null))
            {
                if (!ConnectSolidWorks())
                {
                    _strErrorMessage = ("Unable to Connect To SolidWorks" + "\r\n");
                    _strErrorMessage += "System Generated Error";
                }
            }

        }

        public IFLSolidWorksBaseClass()
        {
            // TODO: Complete member initialization
        }

        #region Properties

        public SldWorks.SldWorks SolidWorksApplicationObject
        {
            get
            {
                return oSolidWorksApplication;
            }
            set
            {
                oSolidWorksApplication = value;
            }
        }

        public SldWorks.ModelDoc2 SolidWorksModel
        {
            get
            {
                return oSolidWorksModel;
            }
            set
            {
                oSolidWorksModel = value;
            }
        }

        public SldWorks.AssemblyDoc SolidWorksAssembly
        {
            get
            {
                return oSolidWorksAssembly;
            }
            set
            {
                oSolidWorksAssembly = value;
            }
        }

        public SldWorks.PartDoc SolidWorksPartDocument
        {
            get
            {
                return oSolidWorksPartDocument;
            }
            set
            {
                oSolidWorksPartDocument = value;
            }
        }

        public SldWorks.DrawingDoc SolidWorksDrawingDocument
        {
            get
            {
                return oSolidWorksDrawingDocument;
            }
            set
            {
                oSolidWorksDrawingDocument = value;
            }
        }

        public SldWorks.View SolidWorksView
        {
            get
            {
                oSolidWorksView.BreakLineGap = 0.00254;
               
                return oSolidWorksView;
            }
            set
            {
                oSolidWorksView = value;
                oSolidWorksView.BreakLineGap = 0.00254;
              
            }
        }

        public bool selectOLE
        {
            get
            {
                bool bret = false;
                bret = SolidWorksModel.Extension.SelectByID2("Worksheet", "OLEITEM", 0.05817688726539, 0.2160797219023, 0, false, 0, null, 0);
                if ((bret == false))
                {
                    SolidWorksModel.Extension.SelectByID2("Worksheet", "OLEITEM", 0.07228921126611, 0.2439971402624, 0, false, 0, null, 0);
                }
                return bret;
            }
        }

        #endregion

        #region Enum

        public enum SolidworksDocumentType
        {
        PartDocument = 1,
        AssemblyDocument = 2,
        DrawingDocument = 3,
        None = 4,
        }

        #endregion

        #region SolidWorks Connection
        // '' Opens the solidworks Session.
        // '' </summary>
        // '' <remarks></remarks>
        public bool ConnectSolidWorks()
        {
            bool connectSolidWorks = false;
            try
            {
                SolidWorksApplicationObject = (SldWorks.SldWorks)System.Runtime.InteropServices.Marshal.GetActiveObject("SldWorks.Application");
                if (!(SolidWorksApplicationObject == null))
                {
                    SolidWorksApplicationObject.Visible = true;
                    _oCurrentSolidWorksObject = SolidWorksApplicationObject;
                    connectSolidWorks = true;
                }
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("UNABLE TO OPEN THE SOLIDWORKS!! .System Generated Error: " + oException.Message));
                
            }
            return connectSolidWorks;
        }

       
        public bool SaveAndCloseAllDocuments()
        {
            bool saveAndCloseAllDocuments = false;
            try
            {
                SolidWorksModel = SolidWorksApplicationObject.ActiveDoc;
                SolidWorksModel.SaveSilent();
                SolidWorksModel.Quit();
              saveAndCloseAllDocuments= SolidWorksApplicationObject.CloseAllDocuments(false);
                
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to close Documents Some files are not saved Properly .System Generated Error: " + oException.Message));
                
            }
            return saveAndCloseAllDocuments;
        }

        // 29_03_2010  ragava
        public void checkProperty(string propertyName, object value)
        {
            try
            {
                SolidWorksModel = SolidWorksApplicationObject.ActiveDoc;
                SolidWorksModel.DeleteCustomInfo(propertyName);
                SolidWorksModel.AddCustomInfo(propertyName, "Text", Convert.ToString(value));
            }
            catch (Exception ex)
            {
            }
        }

        public bool CloseAllDocuments()
        {
            bool closeAllDocuments = false;
            try
            {
              closeAllDocuments= SolidWorksApplicationObject.CloseAllDocuments(false);
                
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to close Documents Some files are not saved Properly .System Generated Error: " + oException.Message));
                
            }
            return closeAllDocuments;
        }

        
        public bool SaveAndCloseDocument(string docName)
        {
            bool saveAndCloseDocument = false;
            try
            { 
                SolidWorksModel = SolidWorksApplicationObject.ActivateDoc(docName);
                 SolidWorksApplicationObject.IActiveDoc.SaveSilent();
                 SolidWorksApplicationObject.CloseDoc(docName);
                 saveAndCloseDocument = CloseDocument(docName);
               
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to close Documents Some files are not saved Properly .System Generated Error: " + oException.Message));
                
            }
            return saveAndCloseDocument;
        }

        public bool CloseDocument(string _strDocName)
        {
            bool closeDocument = false;
            try
            {
                
                SolidWorksApplicationObject.CloseDoc(_strDocName);
                closeDocument = true;
            }
               
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to close Documents Some files are not saved Properly .System Generated Error: " + oException.Message));
                
            }
            return closeDocument;
        }

        
        public bool OpenDocument(string _strDocName)
        {
            SldWorks.ModelDoc2 oSwModel;
          
           int lnDoc = Convert.ToInt32(CheckFileType(_strDocName));
             bool  openDocument = false;
            try
            {
                bool blnRet = false;
                SolidWorksApplicationObject.CommandInProgress = false;
                CheckCommandInProgress();
                
                blnRet = SolidWorksApplicationObject.SetCurrentWorkingDirectory(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath);
                
                SolidWorksApplicationObject.Visible = true;
                SolidWorksModel = SolidWorksApplicationObject.OpenDoc6(_strDocName,0 ,Convert.ToInt32(SwConst.swOpenDocOptions_e.swOpenDocOptions_Silent), "", 0, 0);
                
                oSwModel = SolidWorksModel;
                
                openDocument = true;
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to open Documents check file format .System Generated Error: " + oException.Message));
                
                openDocument = false;
            }
            return openDocument;
           
        }

        
        public void CheckCommandInProgress()
        {
            try
            {
                if ((SolidWorksApplicationObject.CommandInProgress == true))
                {
                    int iCount = 0;
                    while ((iCount < 10))
                    {
                        SolidWorksApplicationObject.CommandInProgress = false;
                        if ((SolidWorksApplicationObject.CommandInProgress == false))
                        {
                            // TODO: Exit Try: Warning!!! cannot be translated
                        }
                        iCount = (iCount + 1);
                    }
                    SetCommandInProgress();
                }
            }
            catch (Exception ex)
            {
            }
        }

       
        public void SetCommandInProgress()
        {
            try
            {
                KillAllSolidWorksServices();
                SolidWorksApplicationObject = null;
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.CloseExcel();
                ConnectSolidWorks();
                SolidWorksApplicationObject.CommandInProgress = false;
            }
            catch (Exception ex)
            {
            }
        }

        public bool OpenAssemblyDrawingDocument(string _strDocName)
        {
            SldWorks.ModelDoc2 oSwModel;
            long lnDoc = CheckFileType(_strDocName);
            bool openAssemblyDrawingDocument = false;
            try
            {
                
                SolidWorksApplicationObject.CommandInProgress = false;
                CheckCommandInProgress();

                // SolidWorksModel = SolidWorksApplicationObject.OpenDoc6(_strDocName, 3, SwConst.swOpenDocOptions_e.swOpenDocOptions_LoadModel, "", Errors, nWarnings)'vamsi 14-11-2013
                SolidWorksModel = SolidWorksApplicationObject.OpenDoc6(_strDocName, 3,Convert.ToInt32(SwConst.swOpenDocOptions_e.swOpenDocOptions_LoadModel), "", 0, 0);
                oSwModel = SolidWorksModel;
                openAssemblyDrawingDocument = true;
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to open Documents check file format .System Generated Error: " + oException.Message));
                
                openAssemblyDrawingDocument = false;
            }
            return openAssemblyDrawingDocument;
            
        }

       
        private long CheckFileType(string _strPartAssemblyFileName)
        {
            long checkFileType=0;
            try
            {    
                FileInfo fileData = VB.FileSystem.GetFileInfo(_strPartAssemblyFileName);
                if ((fileData.Extension == ".SLDASM"))
                {
                    checkFileType = Convert.ToInt64(SwConst.swDocumentTypes_e.swDocASSEMBLY);
                }
                else if ((fileData.Extension == ".SLDPRT"))
                {
                    checkFileType = Convert.ToInt64(SwConst.swDocumentTypes_e.swDocPART);
                }
                else if ((fileData.Extension == ".SLDDRW"))
                {
                    checkFileType = Convert.ToInt64(SwConst.swDocumentTypes_e.swDocDRAWING);
                }
                else
                {
                    checkFileType = Convert.ToInt64(SwConst.swDocumentTypes_e.swDocNONE);
                }
                
            }
            catch (Exception oException)
            {
               modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Access Denied . " + ("\r\n" + ("File Name:"
                                + (_strPartAssemblyFileName + ("\r\n" + ("System Generated Error:" + oException.Message)))))));
                
            }
            return checkFileType;
        }

        
        public void killSolidWorks(string _strProcessName) 
        {
      
        try 
        {
            foreach (Process proc in Process.GetProcessesByName(_strProcessName))
            {
                if ((proc.HasExited == false)) 
                {
                    proc.Kill();
                }
            }
        }
        catch (Exception oException) 
        {
        modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to kill the Service .System Generated Error: " + oException.Message));
           
        }
    }

        public void KillAllSolidWorksServices()
        {
            killSolidWorks("SLDWORKS");
            killSolidWorks("SolidWorksLicTemp.0001");
            killSolidWorks("SolidWorksLicensing");
            killSolidWorks("swvbaserver");
        }

        private void SaveDocument(SldWorks.ModelDoc2 oSolidWorksModel)
        {
            try
            {
                
           oSolidWorksModel.SaveSilent();
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to kill the Service .System Generated Error: " + oException.Message));
             
            }
        }

        public void SaveDocument(string _strDocName)
        {
          try
            {
                
                oSolidWorksModel.SaveSilent();
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to kill the Service .System Generated Error: " + oException.Message));
                
            }
         
        }

        
        public bool DeleteFile(string strfilename)
        {
           bool  deleteFile = false;
            try
            {
                deleteFile = SolidWorksModel.Extension.SelectByID2(strfilename, "COMPONENT", 0, 0, 0, true, 0, null, 0);
                
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to perform delete operation.System Generated Error: " + oException.Message));
               
            }
            return deleteFile;
        }

        public bool ActivateDocument(string fileName)
        {
            bool activateDocument = false;
            try
            {
                SolidWorksApplicationObject.Visible = true;
               activateDocument= SolidWorksApplicationObject.ActivateDoc2(fileName, true, 0);
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to activate the Document.System Generated Error: " + oException.Message));
                
            }
            return activateDocument;
        }


        #endregion








    }
}
