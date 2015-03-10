using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using VB = Microsoft.VisualBasic.FileIO;
using System.IO;
using Welded.FunctionalLayer;
using System.Threading;
using System.Data;

namespace Welded.SolidWorksLayer
{
    class IFLSolidWorksClass : IFLSolidWorksBaseClass
    {
        #region variables
        private string _strErrorMessage;
        private Exception _oErrorObject;
        private object _oCurrentSolidWorksObject;
        SldWorks.SelectionMgr oSelMgr;
        SldWorks.Feature oSwFeat;
        SldWorks.Component2 oSwRootComp;
        SldWorks.ModelDocExtension oSwModelExt;
        SldWorks.Sheet oSwSheet;
        SldWorks.Mate2 oSwMate1;
        SldWorks.Frame oSwFrame;
        SldWorks.SketchManager oSwSketchMgr;
        SldWorks.BomFeature oSwBomFeat;
        SldWorks.Note oSwNote;
        SldWorks.MateEntity2[,] oSwMateEnt;
        SldWorks.SheetMetalFeatureData oSwSheetMetal;
        SldWorks.Configuration oSwConf;
        IFLSolidWorksBaseClass oIflBaseSolidWorksClass;
        ArrayList _alPartParameters;
        SldWorks.DrawingDoc oSolidWorksDrawingDocument;
        #endregion

        #region Enum
        public enum DelTypeEnum
        {
            swDelPartOccurence = 1,
            swDelPartPattern = 2,
            swDelSheet = 3,
            swDelView = 4,

        }
        public enum constEnvelopEnum
        {
            swMM = 0,
            swCM = 1,
            swMETER = 2,
            swINCHES = 3,
            swFEET = 4,
            swFEETINCHES = 5,
            swANGSTROM = 6,
            swNANOMETER = 7,
            swMICRON = 8,
            swMIL = 9,
            swUIN = 10,
            swNONE = 0,
            swDECIMAL = 1,
            swFRACTION = 2,

        }

        #endregion

        #region Properties

        public object ErrorMessage
        {
            get
            {
                return _strErrorMessage;
            }
        }

        public object ErrorObject
        {
            get
            {
                return _oErrorObject;
            }
        }

        public object IsCurrentSolidWorks
        {
            get
            {
                return _oCurrentSolidWorksObject;
            }
        }

        public object SwSelMgr
        {
            get
            {
                return oSelMgr;
            }
        }

        public object SwFeature
        {
            get
            {
                return oSwFeat;
            }
        }

        public ArrayList PartParameters
        {
            get
            {
                if ((_alPartParameters == null))
                {
                    _alPartParameters = new ArrayList();
                }
                return _alPartParameters;
            }
            set
            {
                _alPartParameters = value;
            }
        }

        #endregion

        #region Procedures

        public void DxfConversion1(string _strDrawingFileName, string _strdestinationPath)
        {
            Array[] aSheetName;
            long _lngErrors;
            long _lngWarnings;
            bool _blnShowMap = false;
            long i;
            bool _blnRet;
            int _SwDXFDontShowMap = 21;
            object oSwSaveAsCurrentVersion = 0;
            string sheetName = null;

            object oSwSaveAsOptions_Silent = 1;
            FileInfo ofileData = VB.FileSystem.GetFileInfo(_strDrawingFileName);
            try
            {
                if ((IsCurrentSolidWorks == null))
                {
                    oIflBaseSolidWorksClass.ConnectSolidWorks();
                }
                if ((ofileData.Extension == ".SLDDRW"))
                {
                    oIflBaseSolidWorksClass.OpenDocument(_strDrawingFileName);

                    oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(77, false);

                    oIflBaseSolidWorksClass.SolidWorksDrawingDocument = (SldWorks.DrawingDoc)oIflBaseSolidWorksClass.SolidWorksModel;
                    oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(21, true);
                    oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(_SwDXFDontShowMap, true);
                    aSheetName = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.GetSheetNames();
                    for (i = 0; (i <= aSheetName.GetUpperBound(0)); i++)
                    {
                        sheetName = aSheetName[i].ToString();
                        _blnRet = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.ActivateSheet(sheetName);

                        _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.SaveAs4(((_strdestinationPath + ("\\DRAWINGS\\"
                                        + (ofileData.Name + aSheetName[i])))
                                        + ".dxf"), Convert.ToInt32(oSwSaveAsCurrentVersion), Convert.ToInt32(oSwSaveAsOptions_Silent), 0, 0);

                    }
                    _blnRet = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.ActivateSheet(sheetName);
                    oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(_SwDXFDontShowMap, _blnShowMap);
                    oIflBaseSolidWorksClass.SaveDocument(_strDrawingFileName);
                    oIflBaseSolidWorksClass.CloseAllDocuments();
                }
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to convert drawing in to DXF FORMAT .System Generated Error: " + oException.Message));

            }
        }


        public void deleteUnattached_Dimensions()
        {
            try
            {
                long _lngI;
                string _strColour;
                long _lngRetVal;
                bool _blnRet;
                SldWorks.Annotation oSwAnn;
                SldWorks.View oSwView;
                _lngRetVal = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.GetSheetCount();
                for (_lngI = 1; (_lngI <= _lngRetVal); _lngI++)
                {
                    oIflBaseSolidWorksClass.SolidWorksDrawingDocument.SheetPrevious();
                }
                for (_lngI = 1; (_lngI <= _lngRetVal); _lngI++)
                {
                    oIflBaseSolidWorksClass.SolidWorksModel.ClearSelection2(true);
                    oSwView = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.GetFirstView();
                    while (!(oSwView == null))
                    {
                        oSwAnn = oSwView.GetFirstAnnotation2();
                        while (!(oSwAnn == null))
                        {
                            _strColour = oSwAnn.Color.ToString();
                            if ((_strColour == "32896"))
                            {
                                //  This Below Code is to Select all The Dimensions Which are Unattached
                                _blnRet = oSwAnn.Select2(true, 0);
                            }
                            oSwAnn = oSwAnn.GetNext2();
                        }
                        oSwView = oSwView.GetNextView();
                    }
                    _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.DeleteSelection(true);
                    oIflBaseSolidWorksClass.SolidWorksDrawingDocument.SheetNext();
                }
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to delete attached dimension .System Generated Error: " + oException.Message));

            }
        }

        private void DrawBox()
        {
            try
            {
                SldWorks.SketchPoint[] oswSketchPt;
                SldWorks.SketchSegment[] oswSketchSeg;
                object[] oCorners;

                if ((oIflBaseSolidWorksClass.SolidWorksModel.GetType() == Convert.ToInt32(SwConst.swDocumentTypes_e.swDocPART)))
                {
                    // oCorners = oIflBaseSolidWorksClass.SolidWorksModel.GetPartBox(true);
                    oCorners = oIflBaseSolidWorksClass.SolidWorksPartDocument.GetPartBox(true);
                    //  True comes back as system units - meters
                }
                else if ((oIflBaseSolidWorksClass.SolidWorksModel.GetType() == Convert.ToInt32(SwConst.swDocumentTypes_e.swDocASSEMBLY)))
                {
                    //  Units will come back as meters
                    //oCorners = oIflBaseSolidWorksClass.SolidWorksModel.GetBox(0);

                    // oCorners = oIflBaseSolidWorksClass.SolidWorksModel.GetBox(0);
                }
                else
                {
                    return;
                }

                oIflBaseSolidWorksClass.SolidWorksModel.Insert3DSketch2(true);
                oIflBaseSolidWorksClass.SolidWorksModel.SetAddToDB(true);
                oIflBaseSolidWorksClass.SolidWorksModel.SetDisplayWhenAdded(false);
                // Draw points at each corner of bounding box
                oswSketchPt[0] = oIflBaseSolidWorksClass.SolidWorksModel.CreatePoint2(Convert.ToDouble(oCorners[3]), Convert.ToDouble(oCorners[1]), Convert.ToDouble(oCorners[5]));
                oswSketchPt[1] = oIflBaseSolidWorksClass.SolidWorksModel.CreatePoint2(Convert.ToDouble(oCorners[0]), Convert.ToDouble(oCorners[1]), Convert.ToDouble(oCorners[5]));
                oswSketchPt[2] = oIflBaseSolidWorksClass.SolidWorksModel.CreatePoint2(Convert.ToDouble(oCorners[0]), Convert.ToDouble(oCorners[1]), Convert.ToDouble(oCorners[2]));
                oswSketchPt[3] = oIflBaseSolidWorksClass.SolidWorksModel.CreatePoint2(Convert.ToDouble(oCorners[3]), Convert.ToDouble(oCorners[1]), Convert.ToDouble(oCorners[2]));
                oswSketchPt[4] = oIflBaseSolidWorksClass.SolidWorksModel.CreatePoint2(Convert.ToDouble(oCorners[3]), Convert.ToDouble(oCorners[4]), Convert.ToDouble(oCorners[5]));
                oswSketchPt[5] = oIflBaseSolidWorksClass.SolidWorksModel.CreatePoint2(Convert.ToDouble(oCorners[0]), Convert.ToDouble(oCorners[4]), Convert.ToDouble(oCorners[5]));
                oswSketchPt[6] = oIflBaseSolidWorksClass.SolidWorksModel.CreatePoint2(Convert.ToDouble(oCorners[0]), Convert.ToDouble(oCorners[4]), Convert.ToDouble(oCorners[2]));
                oswSketchPt[7] = oIflBaseSolidWorksClass.SolidWorksModel.CreatePoint2(Convert.ToDouble(oCorners[3]), Convert.ToDouble(oCorners[4]), Convert.ToDouble(oCorners[2]));
                //  Now draw bounding box
                oswSketchSeg[0] = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt[0].X, oswSketchPt[0].Y, oswSketchPt[0].Z, oswSketchPt[1].X, oswSketchPt[1].Y, oswSketchPt[1].Z);
                oswSketchSeg[1] = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt[1].X, oswSketchPt[1].Y, oswSketchPt[1].Z, oswSketchPt[2].X, oswSketchPt[2].Y, oswSketchPt[2].Z);
                oswSketchSeg[2] = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt[2].X, oswSketchPt[2].Y, oswSketchPt[2].Z, oswSketchPt[3].X, oswSketchPt[3].Y, oswSketchPt[3].Z);
                oswSketchSeg[3] = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt[3].X, oswSketchPt[3].Y, oswSketchPt[3].Z, oswSketchPt[0].X, oswSketchPt[0].Y, oswSketchPt[0].Z);
                oswSketchSeg[4] = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt[0].X, oswSketchPt[0].Y, oswSketchPt[0].Z, oswSketchPt[4].X, oswSketchPt[4].Y, oswSketchPt[4].Z);
                oswSketchSeg[5] = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt[1].X, oswSketchPt[1].Y, oswSketchPt[1].Z, oswSketchPt[5].X, oswSketchPt[5].Y, oswSketchPt[5].Z);
                oswSketchSeg[6] = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt[2].X, oswSketchPt[2].Y, oswSketchPt[2].Z, oswSketchPt[6].X, oswSketchPt[6].Y, oswSketchPt[6].Z);
                oswSketchSeg[7] = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt[3].X, oswSketchPt[3].Y, oswSketchPt[3].Z, oswSketchPt[7].X, oswSketchPt[7].Y, oswSketchPt[7].Z);
                oswSketchSeg[8] = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt[4].X, oswSketchPt[4].Y, oswSketchPt[4].Z, oswSketchPt[5].X, oswSketchPt[5].Y, oswSketchPt[5].Z);
                oswSketchSeg[9] = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt[5].X, oswSketchPt[5].Y, oswSketchPt[5].Z, oswSketchPt[6].X, oswSketchPt[6].Y, oswSketchPt[6].Z);
                oswSketchSeg[10] = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt[6].X, oswSketchPt[6].Y, oswSketchPt[6].Z, oswSketchPt[7].X, oswSketchPt[7].Y, oswSketchPt[7].Z);
                oswSketchSeg[11] = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt[7].X, oswSketchPt[7].Y, oswSketchPt[7].Z, oswSketchPt[4].X, oswSketchPt[4].Y, oswSketchPt[4].Z);
                oIflBaseSolidWorksClass.SolidWorksModel.SetDisplayWhenAdded(true);
                oIflBaseSolidWorksClass.SolidWorksModel.SetAddToDB(false);
                oIflBaseSolidWorksClass.SolidWorksModel.Insert3DSketch2(true);
                oIflBaseSolidWorksClass.SolidWorksModel.EditRebuild3();
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to DrawBox for the Model .System Generated Error: " + oException.Message));

            }
        }

        public void getMassProperties(ref double cg_x, ref double cg_y, ref double cg_z, ref double mass)
        {
            try
            {
                int _lngRetVal = 0; //check this value vamsi
                object[] objMassProp;
                oIflBaseSolidWorksClass.SolidWorksModel = null;
                oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc;
                oIflBaseSolidWorksClass.SolidWorksModel.EditRebuild3();
                oSwModelExt = oIflBaseSolidWorksClass.SolidWorksModel.Extension;
                objMassProp = oSwModelExt.GetMassProperties(1, _lngRetVal);
                if (!(objMassProp == null))
                {
                    cg_x = Convert.ToDouble((objMassProp[0])) * 1000;
                    cg_y = Convert.ToDouble((objMassProp[1])) * 1000;
                    cg_z = Convert.ToDouble((objMassProp[2])) * 1000;
                    mass = Convert.ToDouble((objMassProp[5])) * 1000;
                }
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to get the mass properties of the model .System Generated Error: " + oException.Message));

            }
        }

        public string ReplaceComponentWithInstance(string _strMainFile, string _strCompName, string _strReplaceCompName, string _strTransformerType)
        {
            string replaceComponentWithInstance = "";
            try
            {
                bool blnRet = false;
                bool _bRet = false;
                if ((_strReplaceCompName.Trim() != ""))
                {
                    _bRet = false;
                    if ((IsCurrentSolidWorks == null))
                    {
                        oIflBaseSolidWorksClass = new IFLSolidWorksBaseClass(true);
                    }

                }

                blnRet = oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetCurrentWorkingDirectory(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath);
                oIflBaseSolidWorksClass.OpenDocument(_strMainFile);
                oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(77, false);
                oIflBaseSolidWorksClass.SolidWorksModel.ViewZoomtofit2();
                oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActivateDoc(_strMainFile);
                _bRet = oIflBaseSolidWorksClass.SolidWorksModel.Extension.SelectByID2(_strCompName, "COMPONENT", 0, 0, 0, true, 0, null, Convert.ToInt32(SwConst.swSelectOption_e.swSelectOptionDefault));
                if ((_bRet == true))
                {
                    string _strPart;
                    oIflBaseSolidWorksClass.SolidWorksAssembly = (SldWorks.AssemblyDoc)oIflBaseSolidWorksClass.SolidWorksModel;
                    _bRet = oIflBaseSolidWorksClass.SolidWorksAssembly.ReplaceComponents(_strReplaceCompName, "", false, true);
                    _strPart = GetPartNumber(_strReplaceCompName);
                    replaceComponentWithInstance = (_strPart + ("-" + getInstanceNumber((_strPart + _strTransformerType))));
                    oIflBaseSolidWorksClass.SolidWorksAssembly.EditRebuild();
                }
            }
            catch (Exception ex)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to perform Replacment of the component .System Generated Error: " + ex.Message);

            }

            return replaceComponentWithInstance;
        }

        public void ReferenceCutLogics(string _strCompName, string _strPlaneName, string _strSketchName, string _strTransformerType, string _strFinalpath)
        {

            try
            {
                bool _bRet = false;
                _bRet = oIflBaseSolidWorksClass.SolidWorksModel.Extension.SelectByID2(_strCompName, "COMPONENT", 0, 0, 0, false, 0, null, 0);
                if ((_bRet == true))
                {
                    oIflBaseSolidWorksClass.SolidWorksAssembly.EditPart();
                    _bRet = oIflBaseSolidWorksClass.SolidWorksModel.Extension.SelectByID2(_strPlaneName, "PLANE", 0, 0, 0, false, 0, null, 0);
                    oIflBaseSolidWorksClass.SolidWorksModel.SketchManager.InsertSketch(true);
                    _bRet = oIflBaseSolidWorksClass.SolidWorksModel.Extension.SelectByID2((_strSketchName
                                    + (_strFinalpath + _strTransformerType)), "SKETCH", 0, 0, 0, false, 0, null, 0);
                    _bRet = oIflBaseSolidWorksClass.SolidWorksModel.SketchUseEdge2(false);
                    oIflBaseSolidWorksClass.SolidWorksModel.FeatureManager.FeatureCut(true, false, false, 2, 0, 0.01, 0.01, false, false, false, false, 0.01745329251994, 0.01745329251994, false, false, false, false, false, true, true);
                    oIflBaseSolidWorksClass.SolidWorksModel.SelectionManager.EnableContourSelection = 0;
                    oIflBaseSolidWorksClass.SolidWorksAssembly.EditAssembly();
                }
                oIflBaseSolidWorksClass.SolidWorksModel.Save2(true);
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to perform Reference-Cuts for the Component .System Generated Error: " + oException.Message));

            }
        }

        public void FeatureSuppression(string _SearchStr)
        {
            //string _strfeatureName;
            //bool _blnRet;
            //try {
            //    oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc;
            //    oSwFeat = oIflBaseSolidWorksClass.SolidWorksModel.FirstFeature();
            //    while (!(oSwFeat == null)) {
            //        _strfeatureName = oSwFeat.Name;

            //        if (Microsoft.VisualBasic.Strings.InStr(1, _strfeatureName, _SearchStr, Microsoft.VisualBasic.CompareMethod.Binary)
            //        {

            //            _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.SelectByID(_strfeatureName, "BODYFEATURE", 0, 0, 0);
            //            // Select the Feature
            //            _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.EditUnsuppress();
            //            //  Unsuppress the feature
            //            _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.SelectByID(_strfeatureName, "BODYFEATURE", 0, 0, 0);
            //            // Select teh Feature
            //            _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.EditSuppress();
            //            //  Suppress the feature
            //        }
            //        oSwFeat = oSwFeat.GetNextFeature();
            //        //  Get the next feature
            //    }
            //}
            //catch (Exception ex) {
            //}
        }

        public void EnableConfigurations(string _strconfigName, string _strPath)
        {
            try
            {
                bool _blnRet;
                SetCurrentWorkingDirectory(_strPath);
                oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc;
                if ((oIflBaseSolidWorksClass.SolidWorksModel.GetType() == 2))
                {
                    oIflBaseSolidWorksClass.SolidWorksAssembly = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc;
                    oIflBaseSolidWorksClass.SolidWorksAssembly.ResolveAllLightWeightComponents(false);
                }
                _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.ShowConfiguration2(_strconfigName);
                oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = true;
                if ((_blnRet == true))
                {
                    oIflBaseSolidWorksClass.SolidWorksModel.EditRebuild3();
                    oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = true;
                    oIflBaseSolidWorksClass.SolidWorksApplicationObject.IActiveDoc2.SaveSilent();
                    oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = true;
                }
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to perform Enabling the configurations .System Generated Error: " + oException.Message));

            }
        }

        public void DeleteConfiguration(string _strConfigName)
        {
            try
            {

                oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc;

                oIflBaseSolidWorksClass.SolidWorksModel.DeleteConfiguration(_strConfigName);

                oIflBaseSolidWorksClass.SolidWorksModel.EditRebuild3();
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to delete the configurations .System Generated Error: " + oException.Message));

            }
        }

        public void deleteSuppressParts(ArrayList _strCompName)
        {

            try
            {
                if ((_strCompName.Count == 0))
                {

                    return;
                }
                else
                {
                    long i;
                    object oSwComp;
                    bool _bRet;

                    oIflBaseSolidWorksClass.SolidWorksModel.ClearSelection2(true);
                    oIflBaseSolidWorksClass.SolidWorksAssembly = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc;

                    oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc;

                    for (i = 0; (i <= (_strCompName.Count - 1)); i++)
                    {

                        oSwComp = oIflBaseSolidWorksClass.SolidWorksAssembly.FeatureByName(_strCompName.ToString());
                        // oSwComp = oIflBaseSolidWorksClass.SolidWorksAssembly.FeatureByName(_strCompName(i))
                        if (!(_strCompName == null))
                        {
                            if (!(oSwComp == null))
                            {

                                _bRet = oSwComp.select2(true, 0);
                                _bRet = oIflBaseSolidWorksClass.SolidWorksModel.DeleteSelection(false);

                            }
                        }
                    }
                }
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to perform suppression parts deletion .System Generated Error: " + oException.Message));

            }
        }

        public void Common_TraversAndDeletions_And_SuppressionParts()
        {
            try
            {
                oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = true;
                ArrayList _strCompName = new ArrayList();
                ArrayList _strCompName1 = new ArrayList();
                // 20_06_2012   RAGAVA
                ArrayList _strCompName2 = new ArrayList();
                // 20_06_2012   RAGAVA
                SldWorks.Configuration oSwConf;
                SldWorks.Component2 oSwRootComp;
                oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc;
                // 20_06_2012   RAGAVA
                if ((oIflBaseSolidWorksClass.SolidWorksModel.GetPathName().ToString().IndexOf("TUBE_WELDMENT") != -1))
                {
                    string[] oConf = oIflBaseSolidWorksClass.SolidWorksModel.GetConfigurationNames();
                    oSwConf = oIflBaseSolidWorksClass.SolidWorksModel.GetConfigurationByName(oConf[0]);
                    oSwRootComp = oSwConf.GetRootComponent();
                    _strCompName1 = TraverseComponentForInstance(oSwRootComp, 1);
                    oSwConf = oIflBaseSolidWorksClass.SolidWorksModel.GetConfigurationByName(oConf[1]);
                    oSwRootComp = oSwConf.GetRootComponent();
                    _strCompName2 = TraverseComponentForInstance(oSwRootComp, 1);
                    if ((_strCompName1.Count >= _strCompName2.Count))
                    {
                        for (int i = 0; (i
                                    <= (_strCompName1.Count - 1)); i++)
                        {
                            if (_strCompName2.Contains(_strCompName1[i]))
                            {
                                _strCompName.Add(_strCompName1[i]);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; (i
                                    <= (_strCompName2.Count - 1)); i++)
                        {
                            if (_strCompName1.Contains(_strCompName2[i]))
                            {
                                _strCompName.Add(_strCompName2[i]);
                            }
                        }
                    }
                }
                else
                {
                    oSwConf = oIflBaseSolidWorksClass.SolidWorksModel.GetActiveConfiguration();
                    oSwRootComp = oSwConf.GetRootComponent();
                    _strCompName = TraverseComponentForInstance(oSwRootComp, 1);
                }
                // Try
                //     If Not ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingYes.rdbUseSelectedSingleLugNo.Checked = True Then
                //         DeleteConfiguration("Default")
                //     End If
                // Catch ex As Exception
                // End Try
                // vamsi 23-05-14 start 
                // Try
                //     If Not ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingYes.chkDoubleLugFabricationRequired.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes.chkBHFabricationRequired.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes.chkCrossTubeFabricationRequired.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingYes.chkSingleLugFabricationRequired.Checked = True Then
                //         DeleteConfiguration("Default1")
                //     End If
                // Catch ex As Exception
                // End Try
                // End
                oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = true;
                deleteSuppressParts(_strCompName);
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region Functions

        private string GetPartNumber(string _strPartPath)
        {
            string getPartNumber = null;
            string _strSplitPartNumber = "";
            try
            {
                object[] _strSplit;
                _strSplitPartNumber = _strPartPath.Split('\\').Last();
                _strSplit = _strSplitPartNumber.Split('.');
                _strSplitPartNumber = _strSplit[0].ToString();
                return _strSplitPartNumber;
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to get the instance number of the component .System Generated Error: " + oException.Message));
                return _strSplitPartNumber = null;
            }

        }

        public ArrayList GetParameters(string _strPartAssemblyFileName)
        {
            PartParameters = null;
            //ArrayList getParameters = null;
            SldWorks.Configuration oSwConf;
            SldWorks.Component2 oSwRootComp;
            if ((IsCurrentSolidWorks == null))
            {
                oIflBaseSolidWorksClass = new IFLSolidWorksBaseClass(true);
            }
            oIflBaseSolidWorksClass.OpenDocument(_strPartAssemblyFileName);

            oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(77, false);
            oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc;
            oSwFeat = oIflBaseSolidWorksClass.SolidWorksModel.FirstFeature();
            oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc;
            oSwConf = oIflBaseSolidWorksClass.SolidWorksModel.GetActiveConfiguration();
            oSwRootComp = oSwConf.GetRootComponent();

            TraverseModelFeatures(oIflBaseSolidWorksClass.SolidWorksModel, 1);
            TraverseComponent(oSwRootComp, 1);
            return PartParameters;
        }

        public bool DeleteDesignTable(string strPartFileName)
        {
            bool deleteDesignTable = false;
            try
            {
                SldWorks.DesignTable oDesignTable;
                if ((IsCurrentSolidWorks == null))
                {
                    oIflBaseSolidWorksClass = new IFLSolidWorksBaseClass(true);
                }
                oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc;
                oDesignTable = oIflBaseSolidWorksClass.SolidWorksModel.GetDesignTable();
                oDesignTable.Detach();
                oIflBaseSolidWorksClass.SolidWorksModel.DeleteDesignTable();
                deleteDesignTable = true;
                return deleteDesignTable;
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to delete the design table .System Generated Error: " + oException.Message));

            }
            return deleteDesignTable;
        }

        //public bool DeleteEquation(string _strPartAssemblyFileName)
        //{
        //   bool  DeleteEquation = false;
        //    try
        //    {
        //        if ((IsCurrentSolidWorks == null))
        //        {
        //            oIflBaseSolidWorksClass.ConnectSolidWorks();
        //        }
        //        object oPart;
        //        oPart = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc;
        //        oSelMgr = oPart.SelectionManager();
        //        DeleteEquation = oPart.DeleteAllRelations();
        //    }
        //    catch (Exception oException)
        //    {
        //        ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to convert the drawing in to dxf format .System Generated Error: " + oException.Message));
        //        // _strErrorMessage = "UNABLE TO CONVERT THE DRAWING INTO DXF FORMAT !!" + vbCrLf
        //        // _strErrorMessage += "System generated error:-" + vbCrLf + oException.Message
        //        // _oErrorObject = oException
        //    }
        //}

        public bool SetCurrentWorkingDirectory(string _strSetPath)
        {
            bool SetCurrentWorkingDirectory = false;
            try
            {
                if ((IsCurrentSolidWorks == null))
                {
                    oIflBaseSolidWorksClass = new IFLSolidWorksBaseClass(true);
                }
                SetCurrentWorkingDirectory = oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetCurrentWorkingDirectory(_strSetPath);
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to convert the drawing in to dxf format .System Generated Error: " + oException.Message));

            }
            return SetCurrentWorkingDirectory;
        }

        // '' Gets the configuration name of the model document.
        // '' </summary>
        // '' <returns></returns>
        // '' <remarks></remarks>
        string GetCurrentConfigName()
        {
            try
            {
                SldWorks.Configuration oSwConfig;
                string GetCurrentConfigName = "";
                oSwConfig = oIflBaseSolidWorksClass.SolidWorksModel.GetActiveConfiguration();
                GetCurrentConfigName = oIflBaseSolidWorksClass.SolidWorksModel.GetActiveConfiguration().Name;
                return GetCurrentConfigName;
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Unable to get the configuration name .System Generated Error: " + oException.Message));
                return null;
            }

        }

        //    <summary>
        //Convertion of Decimal to feet inches for creating the envelop box boundaries.
        //''' </summary>
        //''' <param name="oDecimalLength"></param>
        //''' <param name="_iDenominator"></param>
        //''' <returns></returns>
        //''' <remarks></remarks>

        public string DecimalToFeetInches(int oDecimalLength, int _iDenominator)
        {
            int _intFeet;
            int _intInches;
            int _intFractions = 0;
            double _dblFractToDecimal;
            double _dblremainder;
            double _dbltmpVal;
            string DecimalToFeetInches;
            //  compute whole feet
            _intFeet = (oDecimalLength / 12);

            _dblremainder = (oDecimalLength) - (_intFeet * 12);
            _dbltmpVal = Convert.ToDouble(_iDenominator);
            _intInches = Convert.ToInt32(_dblremainder);
            _dblremainder = (_dblremainder - _intInches);
            //  compute fractional inches & check for division by zero
            if (!(_dblremainder == 0))
            {
                if (!(_iDenominator == 0))
                {
                    _dblFractToDecimal = (1 / _dbltmpVal);
                    if ((_dblFractToDecimal > 0))
                    {
                        _intFractions = Convert.ToInt32((_dblremainder / _dblFractToDecimal));
                        if ((((_dblremainder / _dblFractToDecimal) - _intFractions) > 0))
                        {
                            //  Round up so bounding box is always larger.
                            _intFractions = (_intFractions + 1);
                        }
                    }
                }
            }
            FractUp(_intFeet, _intInches, _intFractions, _iDenominator);
            //  Simplify up & down
            DecimalToFeetInches = (Convert.ToString(_intFeet).TrimStart() + "\'-");
            DecimalToFeetInches = (DecimalToFeetInches + Convert.ToString(_intInches).TrimStart());
            if ((_intFractions > 0))
            {
                DecimalToFeetInches = (DecimalToFeetInches + " ");
                DecimalToFeetInches = (DecimalToFeetInches + Convert.ToString(_intFractions).TrimStart());
                DecimalToFeetInches = (DecimalToFeetInches + ("\\" + Convert.ToString(_iDenominator).TrimStart()));
            }
            return (DecimalToFeetInches + '"');
        }

        private void FractUp(int _iInputFt, int _iInputInch, int _iInputNum, int _iInputDenom)
        {
            while ((((_iInputNum % 2) == 0) && ((_iInputDenom % 2) == 0)))
            {
                _iInputNum = (_iInputNum / 2);
                _iInputDenom = (_iInputDenom / 2);
            }
            //  See if we now have a full inch or 12 inches.  If so, bump stuff up
            if ((_iInputDenom == 1))
            {
                //  Full inch
                _iInputInch = (_iInputInch + 1);
                _iInputNum = 0;
                if ((_iInputInch == 12))
                {
                    //  Full foot
                    _iInputFt = (_iInputFt + 1);
                    _iInputInch = 0;
                }
            }
        }

        public ArrayList TraverseComponentForInstance(SldWorks.Component2 oSwComp, long _nLevel)
        {
            // 02_09_2009  ragava
            ArrayList sCompName = new ArrayList();
            try
            {
                string _sPadStr = "";
                object[] VchildComp;
                long i = 0;
                for (i = 0; (i
                            <= (_nLevel - 1)); i++)
                {
                    _sPadStr = (_sPadStr + "  ");
                }
                // Dim sCompName As String()           '02_09_2009  ragava
                //ArrayList sCompName = new ArrayList();
                if (!(oSwComp == null))
                {
                    VchildComp = oSwComp.GetChildren();
                    if ((VchildComp.Length > 0))
                    {

                        SldWorks.Component2 swChildComp;
                        for (i = 0; (i <= (VchildComp).GetUpperBound(0)); i++)
                        {
                            swChildComp = (SldWorks.Component2)VchildComp[i];
                            TraverseComponentForInstance(swChildComp, (_nLevel + 1));
                            if ((swChildComp.IsSuppressed() == true))
                            {

                                sCompName.Add(swChildComp.Name);

                            }
                        }
                    }
                }
                return sCompName;
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("System Generated Error: " + oException.Message));

            }
            return sCompName;
        }

        public int getInstanceNumber(string _strReplacedComponent)
        {
            int _intMaxInstanceNumber = 0;
            try
            {
                //int _intMaxInstanceNumber;
                SldWorks.Component2 oSwParentName;
                bool _bRet;
                oSwConf = oIflBaseSolidWorksClass.SolidWorksModel.GetActiveConfiguration();
                oSwRootComp = oSwConf.GetRootComponent();
                oSelMgr = oIflBaseSolidWorksClass.SolidWorksModel.SelectionManager;
                oSwFeat = oIflBaseSolidWorksClass.SolidWorksModel.FirstFeature();
                _bRet = oIflBaseSolidWorksClass.SolidWorksModel.Extension.SelectByID2(_strReplacedComponent, "COMPONENT", 0, 0, 0, true, 0, null, Convert.ToInt32(SwConst.swSelectOption_e.swSelectOptionDefault));
                oSwParentName = oSelMgr.GetSelectedObjectsComponent(1);
                _intMaxInstanceNumber = TraverseComponent(oSwRootComp, 1, oSwParentName);
                return _intMaxInstanceNumber;
            }
            catch (Exception ex)
            {
            }
            return _intMaxInstanceNumber;
        }

        int TraverseComponent(SldWorks.Component2 oSwComp, long _nLevel, SldWorks.Component2 oSwComp1)
        {
            int _instanceCount = 0;
            try
            {
                object[] vChildComp;
                SldWorks.Component2 oSwChildComp;
                string _sPadStr = "";
                object[] spltRslt;
                object[] spltRslt1;
                string strDefaultComponent;
                string strTrvComponent;
                long intI;
                //int _instanceCount;
                spltRslt = oSwComp1.Name.Split('-');
                strDefaultComponent = Convert.ToString(spltRslt[0]);
                for (int intJ = 1; (intJ <= ((spltRslt).GetUpperBound(0) - 1)); intJ++)
                {
                    strDefaultComponent = (strDefaultComponent + ("-" + spltRslt[intJ]));
                }
                for (intI = 0; (intI
                            <= (_nLevel - 1)); intI++)
                {
                    _sPadStr = (_sPadStr + " ");
                }
                vChildComp = oSwComp.GetChildren();
                for (intI = 0; (intI <= (vChildComp).GetUpperBound(0)); intI++)
                {
                    oSwChildComp = (SldWorks.Component2)vChildComp[intI];
                    spltRslt1 = oSwChildComp.Name.Split('-');
                    strTrvComponent = Convert.ToString(spltRslt1[0]);
                    for (int intK = 1; (intK <= (((spltRslt1).GetUpperBound(0)) - 1)); intK++)
                    {
                        strTrvComponent = (strTrvComponent + ("-" + spltRslt1[intK]));
                    }
                    if ((strDefaultComponent == strTrvComponent))
                    {
                        _instanceCount = (_instanceCount + 1);
                    }
                }
                return _instanceCount;
            }
            catch (Exception oException)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("System Generated Error: " + oException.Message));
            }
            return _instanceCount;
        }

        #endregion

        private void TraverseFeatureFeatures(SldWorks.Feature swFeat, long nLevel)
        {
            //string sPadStr = "";
            SldWorks.Feature oSolidWorksSubFeat;
            SldWorks.DisplayDimension oSolidWorksDispDim;
            SldWorks.Dimension oSolidWorksDim;
            SldWorks.Annotation oSolidWorksAnn;
            if ((IsCurrentSolidWorks == null))
            {
                oIflBaseSolidWorksClass = new IFLSolidWorksBaseClass(true);
            }
            while (!(oSwFeat == null))
            {
                oSolidWorksSubFeat = oSwFeat.GetFirstSubFeature();
                while (!(oSolidWorksSubFeat == null))
                {
                    oSolidWorksDispDim = oSolidWorksSubFeat.GetFirstDisplayDimension();
                    while (!(oSolidWorksDispDim == null))
                    {
                        oSolidWorksAnn = oSolidWorksDispDim.GetAnnotation();
                        oSolidWorksDim = oSolidWorksDispDim.GetDimension();
                        PartParameters.Add(oSolidWorksDim.FullName);
                        oSolidWorksDispDim = oSolidWorksSubFeat.GetNextDisplayDimension(oSolidWorksDispDim);
                    }
                    oSolidWorksSubFeat = oSolidWorksSubFeat.GetNextSubFeature();
                }
                oSolidWorksDispDim = oSwFeat.GetFirstDisplayDimension();
                while (!(oSolidWorksDispDim == null))
                {
                    oSolidWorksAnn = oSolidWorksDispDim.GetAnnotation();
                    oSolidWorksDim = oSolidWorksDispDim.GetDimension();
                    PartParameters.Add(oSolidWorksDim.FullName);
                    oSolidWorksDispDim = oSwFeat.GetNextDisplayDimension(oSolidWorksDispDim);
                }
                oSwFeat = oSwFeat.GetNextFeature();
            }
        }

        public bool DeleteDanglingDimensions(string strDrawingFile)
        {
            bool boolstatus = false;
            try
            {
                SldWorks.Annotation SwAnn;
                //bool boolstatus = false;
                string strFileName = strDrawingFile.Substring((strDrawingFile.LastIndexOf("\\") + 1), (strDrawingFile.Length
                                - (strDrawingFile.LastIndexOf("\\") - 1)));
                bool bret = OpenDocument(strDrawingFile);
                oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(77, false);
                SolidWorksModel = SolidWorksApplicationObject.ActivateDoc(strFileName);
                oSolidWorksDrawingDocument = (SldWorks.DrawingDoc)SolidWorksModel;
                SldWorks.View swView = oSolidWorksDrawingDocument.GetFirstView();
                ArrayList AL_Annotations = new ArrayList();
                while (!(swView == null))
                {
                    boolstatus = SolidWorksDrawingDocument.ActivateView(swView.Name);
                    SwAnn = swView.GetFirstAnnotation();
                    if (!(SwAnn == null))
                    {
                        string SwAnn_Type = Convert.ToString(SwAnn.GetType());
                        while (!(SwAnn == null))
                        {
                            if (SwAnn.IsDangling())
                            {
                                SwAnn.Select(true);
                            }
                            SwAnn = SwAnn.GetNext3();
                        }
                        SolidWorksModel.EditDelete();

                    }
                    swView = swView.GetNextView();
                }
            }
            catch (Exception ex)
            {
            }
            return boolstatus;
        }

        void TraverseComponentFeatures(SldWorks.Component2 oSwComp, long _nLevel)
        {
            oSwFeat = oSwComp.FirstFeature();
            TraverseFeatureFeatures(oSwFeat, _nLevel);
        }


        void TraverseComponent(SldWorks.Component2 oSwComp, long _nLevel)
        {
            object[] vChildComp;
            SldWorks.Component2 oSwChildComp;
            string _strPadStr = "";
            long i;
            for (i = 0; (i <= (_nLevel - 1)); i++)
            {
                _strPadStr = (_strPadStr + "  ");
            }
            vChildComp = oSwComp.GetChildren();
            for (i = 0; (i <= (vChildComp).GetUpperBound(0)); i++)
            {
                oSwChildComp = (SldWorks.Component2)vChildComp[i];
                TraverseComponentFeatures(oSwChildComp, _nLevel);
                TraverseComponent(oSwChildComp, (_nLevel + 1));
            }
        }

        public void TraverseModelFeatures(SldWorks.ModelDoc2 oSwModel, long _nLevel)
        {
            SldWorks.Feature oSwFeat;
            oSwFeat = oSwModel.FirstFeature();
            TraverseFeatureFeatures(oSwFeat, _nLevel);
        }

        public ArrayList GetPartParameters(string _strPartFileName)
        {
            //ArrayList GetPartParameters = null;
            PartParameters = null;
            SldWorks.Feature oSolidWorksSubFeat;
            SldWorks.DisplayDimension oSolidWorksDispDim;
            SldWorks.Dimension oSolidWorksDim;
            SldWorks.Annotation oSolidWorksAnn;
            if ((IsCurrentSolidWorks == null))
            {
                oIflBaseSolidWorksClass = new IFLSolidWorksBaseClass(true);
            }
            oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc;
            oSwFeat = oIflBaseSolidWorksClass.SolidWorksModel.FirstFeature();
            while (!(oSwFeat == null))
            {
                oSolidWorksSubFeat = oSwFeat.GetFirstSubFeature();
                while (!(oSolidWorksSubFeat == null))
                {
                    oSolidWorksDispDim = oSolidWorksSubFeat.GetFirstDisplayDimension();
                    while (!(oSolidWorksDispDim == null))
                    {
                        oSolidWorksAnn = oSolidWorksDispDim.GetAnnotation();
                        oSolidWorksDim = oSolidWorksDispDim.GetDimension();
                        PartParameters.Add(oSolidWorksDim.FullName);
                        oSolidWorksDispDim = oSolidWorksSubFeat.GetNextDisplayDimension(oSolidWorksDispDim);
                    }
                    oSolidWorksSubFeat = oSolidWorksSubFeat.GetNextSubFeature();
                }
                oSolidWorksDispDim = oSwFeat.GetFirstDisplayDimension();
                while (!(oSolidWorksDispDim == null))
                {
                    oSolidWorksAnn = oSolidWorksDispDim.GetAnnotation();
                    oSolidWorksDim = oSolidWorksDispDim.GetDimension();
                    PartParameters.Add(oSolidWorksDim.FullName);
                    oSolidWorksDispDim = oSwFeat.GetNextDisplayDimension(oSolidWorksDispDim);
                }
                oSwFeat = oSwFeat.GetNextFeature();
            }
            return PartParameters;
        }

        public ArrayList GetPartParametersPartAndAssemblies(string _strPartFileName)
        {

            PartParameters = null;
            SldWorks.Feature oSolidWorksSubFeat;

            //SldWorks.Dimension oSolidWorksDim;
            //SldWorks.Annotation oSolidWorksAnn;
            if ((IsCurrentSolidWorks == null))
            {
                oIflBaseSolidWorksClass = new IFLSolidWorksBaseClass(true);
            }
            oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc;
            oSwFeat = oIflBaseSolidWorksClass.SolidWorksModel.FirstFeature();
            while (!(oSwFeat == null))
            {
                oSolidWorksSubFeat = oSwFeat.GetFirstSubFeature();
                while (!(oSolidWorksSubFeat == null))
                {
                    PartParameters.Add(oSolidWorksSubFeat.Name);
                    oSolidWorksSubFeat = oSolidWorksSubFeat.GetNextSubFeature();
                }

                oSwFeat = oSwFeat.GetNextFeature();
            }
            return PartParameters;
        }

        //protected override void Finalize()
        //{
        //    base.Finalize();
        //}
        public IFLSolidWorksClass()
            : base(false)
        {

        }
        private void ImportPartReplacements(string strAssyPath)
        {
            try
            {
                //     Dim strDummyComponentName As String = "TUBE_WELDMENT-1@WELD_CYLINDER_ASSEMBLY/Import_Plate_Clevis-2@TUBE_WELDMENT"
                //     Dim strParentAssembly As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\WELD_CYLINDER_ASSEMBLY\WELD_CYLINDER_ASSEMBLY.SLDASM"
                //     IFLSolidWorksBaseClassObject.ReplaceComponentWithInstance(strParentAssembly, strDummyComponentName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.clevisplatePartFilePath, "@WELD_CYLINDER_ASSEMBLY")
                if ((strAssyPath.IndexOf("TUBE_WELDMENT") != -1))
                {
                    if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.clevisplatePartFilePath.Trim() != ""))
                    {
                        ReplaceComponentWithInstance("TUBE_WELDMENT.SLDASM", "Import_Plate_Clevis-2@TUBE_WELDMENT", modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.clevisplatePartFilePath, "@TUBE_WELDMENT");
                    }
                    if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportBaseEndPartPath.Trim() != ""))
                    {
                        ReplaceComponentWithInstance("TUBE_WELDMENT.SLDASM", "Import_Base_End-2@TUBE_WELDMENT", modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportBaseEndPartPath, "@TUBE_WELDMENT");
                    }
                    if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportBaseEndPortPartPath.Trim() != ""))
                    {
                        ReplaceComponentWithInstance("TUBE_WELDMENT.SLDASM", "dummy_port-2@TUBE_WELDMENT", modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportBaseEndPortPartPath, "@TUBE_WELDMENT");
                        if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd > 1))
                        {
                            ReplaceComponentWithInstance("TUBE_WELDMENT.SLDASM", "dummy_port-3@TUBE_WELDMENT", modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportBaseEndPortPartPath, "@TUBE_WELDMENT");
                        }
                    }
                    if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportRodEndPortPartPath.Trim() != ""))
                    {
                        ReplaceComponentWithInstance("TUBE_WELDMENT.SLDASM", "dummy_port-1@TUBE_WELDMENT", modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportRodEndPortPartPath, "@TUBE_WELDMENT");
                        if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd > 1))
                        {
                            ReplaceComponentWithInstance("TUBE_WELDMENT.SLDASM", "dummy_port-4@TUBE_WELDMENT", modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportRodEndPortPartPath, "@TUBE_WELDMENT");
                        }
                    }
                }
                if ((strAssyPath.IndexOf("ROD_WELDMENT") != -1))
                {
                    if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportRodEndPartPath.Trim() != ""))
                    {
                        ReplaceComponentWithInstance("ROD_WELDMENT.SLDASM", "Import_Rod_End-1@ROD_WELDMENT", modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportRodEndPartPath, "@ROD_WELDMENT");
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }


        public void ProcessDirectory(string targetDirectory, bool optionalblnSearchSubDir = false)
        {
            try
            {
                string strDrawingdoc = String.Empty;

                string[] arrAsmFileEntries = null;
                string[] arrPartFileEntries = null;
                string[] sCompName;
                int intI = 0;
                int intJ = 0;
                object[] strSplit;
                string strFileName;

                if ((IsCurrentSolidWorks == null))
                {
                    oIflBaseSolidWorksClass = new IFLSolidWorksBaseClass(true);
                }



                bool blnRet = oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetCurrentWorkingDirectory(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath);

                string[] arrFileEntries = Directory.GetFiles(targetDirectory);
                //object[] sCompName;
                strFileName = null;
                for (int intCount = 0; (intCount <= ((arrFileEntries).GetUpperBound(0))); intCount++)
                {
                    strSplit = arrFileEntries[intCount].Split('.');
                    if ((strSplit[(strSplit).GetUpperBound(0)].ToString().ToUpper() == "SLDASM".ToUpper()))
                    {
                        if ((arrAsmFileEntries == null))
                        {
                            //object arrAsmFileEntries;
                            arrAsmFileEntries[intI] = arrFileEntries[intCount];
                        }
                        else
                        {
                            intI = (intI + 1);
                            object Preserve;
                            //arrAsmFileEntries[intI];
                            arrAsmFileEntries[intI] = arrFileEntries[intCount];
                        }
                    }
                    else if ((strSplit[(strSplit).GetUpperBound(0)].ToString().ToUpper() == "SLDPRT".ToUpper()))
                    {
                        if ((arrPartFileEntries == null))
                        {
                            //object arrPartFileEntries;
                            arrPartFileEntries[intJ] = arrFileEntries[intCount];
                        }
                        else
                        {
                            intJ = (intJ + 1);
                            object Preserve;
                            //arrPartFileEntries[intJ];
                            arrPartFileEntries[intJ] = arrFileEntries[intCount];
                        }
                    }
                }
                if (!(arrPartFileEntries == null))
                {
                    for (int intCount = 0; (intCount <= ((arrPartFileEntries).GetUpperBound(0))); intCount++)
                    {
                        if ((arrPartFileEntries[intCount].ToString().IndexOf("~$") == -1))
                        {

                            updatePartModels(arrPartFileEntries[intCount]);
                        }
                    }
                }
                if (!(arrAsmFileEntries == null))
                {
                    for (int intCount = 0; (intCount <= (arrAsmFileEntries).GetUpperBound(0)); intCount++)
                    {
                        if ((arrAsmFileEntries[intCount].ToString().IndexOf("~$") == -1))
                        {

                            if ((IsCurrentSolidWorks == null))
                            {
                                oIflBaseSolidWorksClass = new IFLSolidWorksBaseClass(true);
                            }
                            blnRet = oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetCurrentWorkingDirectory(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath);
                            oIflBaseSolidWorksClass.OpenDocument(arrAsmFileEntries[intCount]);

                            oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(77, false);

                            try
                            {
                                oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc;

                                oIflBaseSolidWorksClass.SolidWorksModel.ViewZoomtofit2();

                            }
                            catch (Exception ex)
                            {
                            }

                            try
                            {
                                if (((arrAsmFileEntries[intCount].IndexOf("TUBE_WELDMENT") != -1)
                                            || (arrAsmFileEntries[intCount].IndexOf("ROD_WELDMENT") != -1)))
                                {
                                    ImportPartReplacements(arrAsmFileEntries[intCount]);
                                }
                            }
                            catch (Exception ex)
                            {
                            }

                            try
                            {
                                if (((arrAsmFileEntries[intCount].IndexOf("TUBE_WELDMENT") != -1)
                                            || (arrAsmFileEntries[intCount].IndexOf("ROD_WELDMENT") != -1)))
                                {
                                    string filename1 = arrAsmFileEntries[intCount];
                                    string[] arrpart1 = filename1.Split('\\');
                                    string strPart1 = arrpart1[(arrpart1).GetUpperBound(0)];
                                    string strCodeNumber1 = String.Empty;

                                    if ((arrAsmFileEntries[intCount].IndexOf("TUBE_WELDMENT") != -1))
                                    {
                                        strCodeNumber1 =Convert.ToString(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable["BORE_IFL"]);
                                    }
                                    else if ((arrAsmFileEntries[intCount].IndexOf("ROD_WELDMENT") != -1))
                                    {
                                        strCodeNumber1 = Convert.ToString(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable["Rod_Welded"]);
                                    }
                                    if ((strCodeNumber1 == ""))
                                    {
                                        strCodeNumber1 = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPurchaseAndManufactureCode(strPart1.Substring(0, strPart1.IndexOf(".")));
                                    }
                                    // Till  Here
                                    if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(filename1.Substring((filename1.LastIndexOf("\\") + 1), (filename1.IndexOf(".")
                                                        - (filename1.LastIndexOf("\\") - 1)))) == false))
                                    {
                                        modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.Add(filename1.Substring((filename1.LastIndexOf("\\") + 1), (filename1.IndexOf(".")
                                                             - (filename1.LastIndexOf("\\") - 1))), strCodeNumber1);
                                    }
                                    else
                                    {
                                        modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable[filename1.Substring((filename1.LastIndexOf("\\") + 1), (filename1.IndexOf(".")
                                                            - (filename1.LastIndexOf("\\") - 1)))] = strCodeNumber1;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                            }

                            try
                            {
                                updateCustomProperties(arrAsmFileEntries[intCount]);

                            }
                            catch (Exception ex)
                            {

                                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Updating customer Properties ");
                            }
                            oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActivateDoc(arrAsmFileEntries[intCount]);
                            oIflBaseSolidWorksClass.SolidWorksModel.EditRebuild3();

                            try
                            {
                                if ((arrAsmFileEntries[intCount].IndexOf("TUBE_WELDMENT") != -1))
                                {
                                    modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentVolume = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Volume");
                                    modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight = Math.Round((double.Parse(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentVolume) * 0.281793), 2);

                                }
                                else if ((arrAsmFileEntries[intCount].IndexOf("ROD_WELDMENT") != -1))
                                {
                                    modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodWeldmentVolume = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Volume");
                                    modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodWeldmentWeight = Math.Round((double.Parse(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodWeldmentVolume) * 0.281793), 2);

                                }
                                else if ((arrAsmFileEntries[intCount].IndexOf("WELD_CYLINDER_ASSEMBLY") != -1))
                                {
                                    modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strWeldCylinderVolume = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Volume");
                                    modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strWeldCylinderWeight = Math.Round((double.Parse(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strWeldCylinderVolume) * 0.281793), 2);

                                }
                            }
                            catch (Exception ex)
                            {
                            }
                          
                            try
                            {
                                if (!((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FirstPortOrientation_BaseEnd == 0)
                                            && (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "Cross Tube")))
                                {
                                    DeleteSketch("CT_OD");
                                    DeleteSketch("CT_WIDTH");
                                }
                                if (!((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FirstPortOrientation_BaseEnd == 0)
                                            && (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "Double Lug")))
                                {
                                    DeleteSketch("DL_THICKNESS_GAP");
                                    DeleteSketch("DL_SWING_CLEARANCE");
                                }
                                if (!((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FirstPortOrientation_BaseEnd == 0)
                                            && ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "Single Lug")
                                            || (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "BH"))))
                                {
                                    DeleteSketch("SL_THICKNESS");
                                    DeleteSketch("SL_SWING_CLEARANCE");
                                }
                                if (!((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FirstPortOrientation_BaseEnd > 0)
                                            && (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "Cross Tube")))
                                {
                                    DeleteSketch("CT_OD_90");
                                    DeleteSketch("CT_WIDTH_90");
                                }
                                if (!((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FirstPortOrientation_BaseEnd > 0)
                                            && (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "Double Lug")))
                                {
                                    DeleteSketch("DL_THICKNESS_GAP_90");
                                    DeleteSketch("DL_SWING_CLEARANCE_90");
                                }
                                if (!((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FirstPortOrientation_BaseEnd > 0)
                                            && ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "Single Lug")
                                            || (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "BH"))))
                                {
                                    DeleteSketch("SL_THICKNESS_90");
                                    DeleteSketch("SL_SWING_CLEARANCE_90");
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                DeleteDesignTable(arrAsmFileEntries[intCount]);

                            }
                            catch (Exception ex)
                            {
                            }
                            Common_TraversAndDeletions_And_SuppressionParts();
                            try
                            {
                                oIflBaseSolidWorksClass.SaveAndCloseAllDocuments();

                                if (((arrAsmFileEntries[intCount].IndexOf("TUBE_WELDMENT") != -1)
                                            || (arrAsmFileEntries[intCount].IndexOf("ROD_WELDMENT") != -1)))
                                {
                                    oIflBaseSolidWorksClass.SaveAndCloseAllDocuments();
                                }

                            }
                            catch (Exception ex)
                            {
                            }

                            string filename = arrAsmFileEntries[intCount];
                            string[] arrpart = filename.Split('\\');
                            string strPart = arrpart[(arrpart).GetUpperBound(0)];
                            if (!((strPart.IndexOf("PISTON") != -1)
                                        || ((strPart.IndexOf("CYL HEAD WIRE RING") != -1)
                                        || ((strPart.IndexOf("7") != -1)
                                        || ((strPart.IndexOf("6") != -1)
                                        || (strPart.IndexOf("5") != -1))))))
                            {
                                string strCodeNumber;
                                if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(strPart.Substring(0, strPart.IndexOf(".")))
                                            || ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text.Trim() != "New Design")
                                            && ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text.Trim() != "")
                                            && (strPart.IndexOf("CYL HEAD") != -1)))))
                                {
                                    if ((strPart.IndexOf("CYL HEAD") != -1))
                                    {
                                        if (((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text.Trim() != "New Design")
                                                    && (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text.Trim() != "")))
                                        {
                                            strCodeNumber = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text.Trim();
                                        }
                                        else
                                        {
                                            strCodeNumber = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("CYL HEAD");
                                        }

                                    }
                                    else
                                    {
                                        strCodeNumber = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(strPart.Substring(0, strPart.IndexOf(".")));
                                    }
                                }
                                else if ((filename.IndexOf("WELD_CYLINDER_ASSEMBLY.SLDASM") != -1))
                                {

                                    strCodeNumber = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber;

                                }
                                else if ((strPart.IndexOf("COLLAR") != -1))
                                {

                                    strCodeNumber = GetCollarCode();

                                }
                                else
                                {
                                    strCodeNumber = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPurchaseAndManufactureCode(strPart.Substring(0, strPart.IndexOf(".")));
                                }
                                string strModelNetworkPath = "X:\\WeldedModels";
                                string strNewPartPath = (filename.Substring(0, filename.LastIndexOf("\\")) + ("\\"
                                            + (strCodeNumber.ToString() + ".SLDASM")));
                                string strReferenceAssm;
                                if (((filename.IndexOf("BASE") != -1)
                                            || ((filename.IndexOf("BEC") != -1)
                                            || ((filename.IndexOf("COLLAR") != -1)
                                            || (filename.IndexOf("BORE_IFL") != -1)))))
                                {
                                    strReferenceAssm = (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\\TUBE_WELDMENT\\TUBE_WELDMENT.SLDASM");
                                }
                                else if (((filename.IndexOf("ROD") != -1)
                                            && (filename.IndexOf("ROD_WELDMENT.SLDASM") == -1)))
                                {
                                    strReferenceAssm = (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\\ROD_WELDMENT\\ROD_WELDMENT.SLDASM");
                                }
                                else
                                {
                                    strReferenceAssm = (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\\WELD_CYLINDER_ASSEMBLY\\WELD_CYLINDER_ASSEMBLY.SLDASM");
                                }
                                if ((filename.IndexOf("WELD_CYLINDER_ASSEMBLY.SLDASM") != -1))
                                {

                                    try
                                    {
                                        InsertTextBox();
                                    }
                                    catch (Exception ex)
                                    {
                                    }

                                    bool bret = false;
                                    string oDrawingPath = (filename.Substring(0, filename.LastIndexOf("\\")) + "\\WELD_CYLINDER_ASSEMBLY.SLDDRW");
                                    Rename(filename, strNewPartPath);
                                    bret = SolidWorksApplicationObject.ReplaceReferencedDocument(oDrawingPath, filename, strNewPartPath);
                                    string[] strAssy = strNewPartPath.Split('\\');
                                    string strPartName = ("\\" + strAssy[(strAssy).GetUpperBound(0)]);

                                    try
                                    {
                                        if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(filename.Substring((filename.LastIndexOf("\\") + 1), (filename.IndexOf(".")
                                                            - (filename.LastIndexOf("\\") - 1)))) == false))
                                        {
                                            modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.Add(filename.Substring((filename.LastIndexOf("\\") + 1), (filename.IndexOf(".")
                                                                - (filename.LastIndexOf("\\") - 1))), strCodeNumber);
                                        }
                                        else
                                        {
                                            modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(filename.Substring((filename.LastIndexOf("\\") + 1), (filename.IndexOf(".")
                                                                - (filename.LastIndexOf("\\") - 1)))) = strCodeNumber;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                    }

                                    try
                                    {

                                        string nDrawingPath = (filename.Substring(0, filename.LastIndexOf("\\"))
                                                    + (strNewPartPath.Substring(strNewPartPath.LastIndexOf("\\"), (strNewPartPath.IndexOf(".") - strNewPartPath.LastIndexOf("\\"))) + ".SLDDRW"));
                                        Rename(oDrawingPath, nDrawingPath);
                                        bret = SolidWorksApplicationObject.ReplaceReferencedDocument(strNewPartPath, oDrawingPath, nDrawingPath);

                                        if (File.Exists((strModelNetworkPath + ("\\"
                                                        + (strCodeNumber.ToString() + ".SLDASM")))))
                                        {
                                            File.Delete((strModelNetworkPath + ("\\"
                                                            + (strCodeNumber.ToString() + ".SLDASM"))));
                                        }
                                        File.Copy(strNewPartPath, (strModelNetworkPath + ("\\"
                                                        + (strCodeNumber.ToString() + ".SLDASM"))));

                                        bret = SolidWorksApplicationObject.ReplaceReferencedDocument(nDrawingPath, strNewPartPath, (strModelNetworkPath + ("\\"
                                                        + (strCodeNumber.ToString() + ".SLDASM"))));
                                        if ((Directory.Exists("W:\\WeldedDrawings") == false))
                                        {
                                            Directory.CreateDirectory("W:\\WeldedDrawings");
                                        }

                                        if (File.Exists(("W:\\WeldedDrawings\\"
                                                        + (strCodeNumber.ToString() + ".SLDDRW"))))
                                        {
                                            File.Delete(("W:\\WeldedDrawings\\"
                                                            + (strCodeNumber.ToString() + ".SLDDRW")));
                                        }
                                        File.Copy(nDrawingPath, ("W:\\WeldedDrawings\\"
                                                        + (strCodeNumber.ToString() + ".SLDDRW")));
                                        modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AssyGeneratePath = ("W:\\WeldedDrawings\\"
                                                     + (strCodeNumber.ToString() + ".SLDDRW"));
                                        bret = SolidWorksApplicationObject.ReplaceReferencedDocument((strModelNetworkPath + ("\\"
                                                        + (strCodeNumber.ToString() + ".SLDASM"))), nDrawingPath, ("W:\\WeldedDrawings\\"
                                                        + (strCodeNumber.ToString() + ".SLDDRW")));
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                    try
                                    {

                                        SolidWorksModel = SolidWorksApplicationObject.OpenDoc6(("W:\\WeldedDrawings\\"
                                                        + (strCodeNumber.ToString() + ".SLDDRW")), 3, Convert.ToInt32(SwConst.swOpenDocOptions_e.swOpenDocOptions_Silent), "", 0, 0);
                                        SolidWorksApplicationObject.UserControl = false;
                                        Thread.Sleep(2000);

                                        SolidWorksApplicationObject.IActiveDoc.SaveAs2(("W:\\WeldedDrawings\\"
                                                        + (strCodeNumber.ToString() + ".SLDDRW")), 3, true, true);

                                        SolidWorksApplicationObject.CloseAllDocuments(true);

                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                }
                                else
                                {

                                    try
                                    {
                                        string[] strarr = strNewPartPath.Split('\\');
                                        string strNewPartName = strarr[(strarr).GetUpperBound(0)];
                                        if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(filename.Substring((filename.LastIndexOf("\\") + 1), (filename.IndexOf(".")
                                                            - (filename.LastIndexOf("\\") - 1)))) == false))
                                        {
                                            modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.Add(filename.Substring((filename.LastIndexOf("\\") + 1), (filename.IndexOf(".")
                                                                - (filename.LastIndexOf("\\") - 1))), strNewPartName.Substring(0, strNewPartName.IndexOf(".")));

                                        }
                                        else
                                        {
                                            modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(filename.Substring((filename.LastIndexOf("\\") + 1), (filename.IndexOf(".")
                                                                - (filename.LastIndexOf("\\") - 1)))) = strNewPartName.Substring(0, strNewPartName.IndexOf("."));
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                    }

                                    RenamePartFile(filename, strNewPartPath, strReferenceAssm);
                                    FolderStructure(strReferenceAssm, strNewPartPath, strModelNetworkPath);
                                    RenameDrawing(filename, strNewPartPath.Replace(".SLDASM", ".SLDDRW"), strNewPartPath, (strModelNetworkPath + ("\\" + (strCodeNumber.ToString() + ".SLDASM"))));
                                }
                            }

                        }
                    }
                }
                if ((optionalblnSearchSubDir == true))
                {
                    string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);

                    foreach (string subdirectory in subdirectoryEntries)
                    {
                        ProcessDirectory(subdirectory);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void updatePartModels(string fileName)
        {
            string strpath = fileName.Replace("~$", "");
            if (!(string.Compare(fileName, strpath) == 0))
            {
                return;
            }
            bool blnRet = oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetCurrentWorkingDirectory(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath);

            try
            {

                oIflBaseSolidWorksClass.OpenDocument(fileName);

                oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(77, false);

                try
                {

                    oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActivateDoc(fileName.Substring((fileName.LastIndexOf("\\") + 1), (fileName.Length
                                        - (fileName.LastIndexOf("\\") - 1))));
                    oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc;
                }
                catch (Exception ex)
                {
                }

                SldWorks.DesignTable oDesignTable;
                if ((IsCurrentSolidWorks == null))
                {
                    oIflBaseSolidWorksClass = new IFLSolidWorksBaseClass(true);
                }
                oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc;
                oDesignTable = oIflBaseSolidWorksClass.SolidWorksModel.GetDesignTable;

                if (!(oIflBaseSolidWorksClass.SolidWorksModel == null))
                {
                    oIflBaseSolidWorksClass.SolidWorksModel.ViewZoomtofit2();
                    try
                    {
                        updateCustomProperties(fileName);

                    }
                    catch (Exception ex)
                    {

                        modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Updating customer Properties ");
                    }
                    oIflBaseSolidWorksClass.SolidWorksModel.EditRebuild3();
                    oDesignTable = null;
                    try
                    {
                        DeleteDesignTable(fileName);
                    }
                    catch (Exception EX)
                    {
                    }

                    try
                    {
                        if ((fileName.IndexOf("BASEPLUG") != -1))
                        {
                            double dblWeight = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Weight");
                            modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.BaseEndWeight = dblWeight;
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    try
                    {
                        oIflBaseSolidWorksClass.SaveAndCloseAllDocuments();
                    }
                    catch (Exception ex)
                    {
                    }

                    string[] arrpart = fileName.Split('\\');
                    string strPart = arrpart[(arrpart).GetUpperBound(0)].ToUpper();

                    if (!((strPart.IndexOf("PISTON") != -1)
                                || ((strPart.IndexOf("CYL HEAD WIRE RING") != -1)
                                || ((strPart.IndexOf("7") != -1)
                                || ((strPart.IndexOf("6") != -1)
                                || (strPart.IndexOf("5") != -1))))))
                    {
                        string strCodeNumber = String.Empty;
                        if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(strPart.Substring(0, strPart.IndexOf(".")))
                                    || ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text.Trim() != "New Design")
                                    && ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text.Trim() != "")
                                    && (strPart.IndexOf("CYL HEAD") != -1)))))
                        {
                            if ((strPart.IndexOf("CYL HEAD") != -1))
                            {
                                if (((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text.Trim() != "New Design")
                                            && (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text.Trim() != "")))
                                {
                                    strCodeNumber = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text.Trim();
                                }
                                else
                                {
                                    strCodeNumber = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("CYL HEAD");
                                }
                            }
                            else
                            {
                                strCodeNumber = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(strPart.Substring(0, strPart.IndexOf(".")));
                            }
                        }
                        else
                        {

                            if ((strPart.IndexOf("COLLAR") != -1))
                            {
                                strCodeNumber = GetCollarCode();

                            }
                            else if (((strPart.IndexOf(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName) != -1)
                                        && (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName.Trim() != "")))
                            {

                                if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode != ""))
                                {

                                    strCodeNumber = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode;
                                }
                            }
                            else if (((strPart.IndexOf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName) != -1)
                                        && (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName.Trim() != "")))
                            {

                                if ((ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode != ""))
                                {

                                    strCodeNumber = ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode;
                                }

                            }
                            else
                            {
                                strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPurchaseAndManufactureCode(strPart.Substring(0, strPart.IndexOf(".")));
                            }

                            try
                            {
                                if ((strCodeNumber == ""))
                                {
                                    strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPurchaseAndManufactureCode(strPart.Substring(0, strPart.IndexOf(".")));
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }

                        try
                        {
                            if ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(fileName.Substring((fileName.LastIndexOf("\\") + 1), (fileName.IndexOf(".")
                                                - (fileName.LastIndexOf("\\") - 1)))) == false))
                            {
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.Add(fileName.Substring((fileName.LastIndexOf("\\") + 1), (fileName.IndexOf(".")
                                                    - (fileName.LastIndexOf("\\") - 1))), strCodeNumber);
                            }
                            else
                            {
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(fileName.Substring((fileName.LastIndexOf("\\") + 1), (fileName.IndexOf(".")
                                                    - (fileName.LastIndexOf("\\") - 1)))) = strCodeNumber;
                            }
                        }
                        catch (Exception ex)
                        {
                        }

                        string strModelNetworkPath = "X:\\WeldedModels";
                        string strNewPartPath = (fileName.Substring(0, fileName.LastIndexOf("\\")) + ("\\"
                                    + (strCodeNumber.ToString + ".SLDPRT")));
                        string strReferenceAssm;
                        if (((fileName.IndexOf("BASE") != -1)
                                    || ((fileName.IndexOf("BEC") != -1)
                                    || ((fileName.IndexOf("COLLAR") != -1)
                                    || ((fileName.IndexOf("BORE_IFL") != -1)
                                    || (fileName.IndexOf("CLEVIS_PLATE_WR") != -1))))))
                        {
                            strReferenceAssm = (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\\TUBE_WELDMENT\\TUBE_WELDMENT.SLDASM");
                        }
                        else if ((fileName.IndexOf("ROD") != -1))
                        {
                            strReferenceAssm = (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\\ROD_WELDMENT\\ROD_WELDMENT.SLDASM");
                        }
                        else if ((fileName.IndexOf("CYL HEAD") != -1))
                        {
                            strReferenceAssm = (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\\CYLINDER_HEAD\\CYL HEAD ASSEMBLY.SLDASM");
                        }
                        else
                        {
                            strReferenceAssm = (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\\WELD_CYLINDER_ASSEMBLY\\WELD_CYLINDER_ASSEMBLY.SLDASM");
                        }
                        RenamePartFile(fileName, strNewPartPath, strReferenceAssm);
                        FolderStructure(strReferenceAssm, strNewPartPath, strModelNetworkPath);

                        if ((!((strPart.IndexOf("COLLAR") != -1)
                                    || ((strPart.IndexOf("BORE_IFL") != -1)
                                    || (strPart.IndexOf("Rod") != -1)))
                                    && (double.Parse(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= double.Parse(strCodeNumber))))
                        {

                            RenameDrawing(fileName, strNewPartPath.Replace(".SLDPRT", ".SLDDRW"), strNewPartPath, (strModelNetworkPath + ("\\"
                                            + (strCodeNumber.ToString + ".SLDPRT"))));
                        }

                    }

                }
            }
            catch (Exception ex)
            {
            }
        }

        private string GetCollarCode()
        {
            try
            {

                string strQuery;
                if ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType == "Rephasing at Extension"))
                {
                    strQuery = ("Select * from CollarDetails_RodEndRephasing where BoreDiameter = "
                                + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + (" and "
                                + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + (" between MinTubeWallThickness and MaxTubeWallThickness  and portSize = \'"
                                + (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.Text.ToString.Trim() + ("\' and PortAngle = \'"
                                + (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text.ToString.Trim() + ("\' and NumberOfPorts = \'"
                                + (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsRodEnd.Text.ToString.Trim() + "\'"))))))))));
                }
                else
                {
                    strQuery = ("Select * from CollarDetails where BoreDiameter = "
                                + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + (" and "
                                + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + (" between MinTubeWallThickness and MaxTubeWallThickness  and portSize = \'"
                                + (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.Text.ToString.Trim() + ("\' and PortAngle = \'"
                                + (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text.ToString.Trim() + ("\' and NumberOfPorts = \'"
                                + (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsRodEnd.Text.ToString.Trim() + "\'"))))))))));
                    if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text.ToString.Trim() == "90"))
                    {
                        strQuery = (strQuery + (" and PortFacingEnd = \'"
                                    + (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortFacingRodEnd.Text.ToString.Trim() + "\'")));
                    }
                }

                DataRow _oRow = MonarchConnectionObject.GetDataRow(strQuery);
                if (!(_oRow == null))
                {
                    return _oRow["CodeNumber"];
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void RenameDrawing(string OriginalPartName, string DrawingPath, string ReNamePart, string strPartNetworkpath)
        {
            try
            {

                bool bret = false;
                string OriginalDrawingPath = (OriginalPartName.Substring(0, OriginalPartName.IndexOf(".")) + ".SLDDRW");
                if ((File.Exists(OriginalDrawingPath) == true))
                {
                    bret = SolidWorksApplicationObject.ReplaceReferencedDocument(OriginalDrawingPath, OriginalPartName, ReNamePart);
                    string strRenameDrawing = (ReNamePart.Substring(0, ReNamePart.IndexOf(".")) + ".SLDDRW");
                    Rename(OriginalDrawingPath, strRenameDrawing);

                    string[] strDrawing = strRenameDrawing.Split('\\');
                   // string strDrawingName = strDrawing[UBound(strDrawing)];

                    string strDrawingName = strDrawing[(strDrawing).GetUpperBound(0)];

                    File.Copy(strRenameDrawing, ("W:\\WeldedDrawings\\" + strDrawingName));

                    bret = SolidWorksApplicationObject.ReplaceReferencedDocument(("W:\\WeldedDrawings\\" + strDrawingName), ReNamePart, strPartNetworkpath);

                    Thread.Sleep(2000);

                    if ((OriginalPartName.ToString().IndexOf("ROD_WELDMENT.SLDASM") == -1))
                    {

                        if ((double.Parse(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= double.Parse(strDrawingName.Substring(0, strDrawingName.IndexOf(".")))))
                        {
                            oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = false;
                            CheckCommandInProgress();

                            bool blnRet = oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetCurrentWorkingDirectory("W:\\WeldedDrawings");

                            SolidWorksModel = SolidWorksApplicationObject.OpenDoc6(("W:\\WeldedDrawings\\" + strDrawingName), 3,Convert.ToInt32(SwConst.swOpenDocOptions_e.swOpenDocOptions_Silent), "", 0, 0);

                            SolidWorksApplicationObject.IActiveDoc.SaveAs2(("W:\\WeldedDrawings\\" + strDrawingName), 3, true, true);
                            SolidWorksApplicationObject.IActiveDoc.SaveSilent();
                            SolidWorksApplicationObject.CloseAllDocuments(true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Rename(string OriginalDrawingPath, string strRenameDrawing)
        {
            try
            {
                File.Move(OriginalDrawingPath, strRenameDrawing);
            }
            catch (Exception ex)
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Renaming a file");
            }
        }

        public void updateCustomProperties(string strFileName)
        {
            try
            {
                string strDrawingDoc = String.Empty;
                string strMaterial = String.Empty; ;
                string strDescription = String.Empty; ;
                string strCode = String.Empty; ;
                string strMa = String.Empty; r;
                string strDesignation = String.Empty; ;
                string strAssyNotes = String.Empty; ;
                string strPaintNotes = String.Empty; ;
                string strGeneralNotes = String.Empty; ;
                string strDate = string.Format("{0:dd/MM/yyyy}", DateTime.Today).ToUpper();

                if ((strFileName.IndexOf("\\BASE_CROSSTUBE\\") != -1))
                {
                    strCode =modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd;
                }
                checkProperty("DATE", strDate);

                checkProperty("USERNAME", System.Environment.UserName.ToString());

                if (((strFileName.IndexOf(".SLDASM") != -1)
                            || (strFileName.IndexOf(".sldasm") != -1)))
                {
                    checkProperty("ROD END PORT DESCRIPTION THREAD", (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_RodEnd + (" - "
                                    + (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_RodEnd + " PORT TYP."))));
                    checkProperty("TUBE MATERIAL AND DIMENSIONS", (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + (" ID-"
                                    + (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD.ToString + (" OD "
                                    + (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeMaterial + (" - " + modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.TubeMaterialCode)))))));
                    checkProperty("CYLINDER THREAD DETAILS", modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadSize_RodEnd.ToString());
                    checkProperty("TUBE HARDENED AND WELD SYMBOLS", "");
                    checkProperty("BASE END EXISTING FABRICATED WELD DESCRIPTION", (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ColumnLoadDeratePressure.ToString() + " PSI WELD"));
                    checkProperty("TUBE WELDMENT SYMBOL", (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString() + " WELD SYMBOL"));
                    checkProperty("PORT IN CASTING THREAD DESCRIPTION", (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadSize_RodEnd.ToString() + " THREADED STD"));
                    checkProperty("ZERK1 DESCRIPTION", "1/4 TAPPED THREAD");
                    checkProperty("ZERK2 DESCRIPTION", "1/4 TAPPED THREAD");
                    if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_RodEnd == null))
                    {
                        modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_RodEnd = "";
                    }
                    if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_RodEnd == null))
                    {
                        modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_RodEnd = "";
                    }
                    checkProperty("PORT ASSEMBLY WELDING DESCRIPTION", (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_RodEnd.ToString() + (" "
                                    + (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_RodEnd.ToString() + " WELD"))));

                    if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeBaseEnd.SelectedItem.ToString().Trim() == "ORB"))
                    {
                        if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.SelectedItem.ToString().Trim() == "9/16"))
                        {
                            checkProperty("BASE END PORT DESCRIPTION", (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString() + ("-18UNF "
                                            + (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeBaseEnd.Text.ToString()+ " PORT TYP REF."))));
                        }
                        else if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.SelectedItem.ToString().Trim() == "3/4"))
                        {
                            checkProperty("BASE END PORT DESCRIPTION", (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString() + ("-16UNF "
                                            + (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeBaseEnd.Text.ToString() + " PORT TYP REF."))));
                        }
                        else
                        {
                            checkProperty("BASE END PORT DESCRIPTION", (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString() + (" "
                                            + (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeBaseEnd.Text.ToString() + " PORT TYP REF."))));
                        }
                    }
                    else
                    {
                        checkProperty("BASE END PORT DESCRIPTION", (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString() + (" "
                                        + (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeBaseEnd.Text.ToString() + " PORT TYP REF."))));
                    }

                    checkProperty("BASE END PORT WELDING DESCRIPTION", (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString() + " WELD"));
                    checkProperty("ROD END PORT WELDING DESCRIPTION", (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_RodEnd.ToString() + " WELD"));
                    checkProperty("CODE", modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString());
                    checkProperty("Painting_Optional_Note", modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strPaintPackagingNotes);

                    checkProperty("Assembly_Optional_Note", modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strAssemblyNotes);

                }
                else if (((strFileName.IndexOf(".SLDPRT") != -1)
                            || (strFileName.IndexOf(".sldprt") != -1)))
                {
                    if ((strFileName.IndexOf("ROD") == -1))
                    {
                        checkProperty("CODE", modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd);
                        checkProperty("PORT SIZE DETAILS", modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd);
                    }
                    else
                    {
                        checkProperty("CODE", modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd);
                        checkProperty("PORT SIZE DETAILS", modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_RodEnd);
                    }
                    checkProperty("THREAD_NOTE", "VAMSI");
                    // STANDARD_CALL_OUT                 for Rod_Weldment
                    if ((strFileName.IndexOf("TUBE_WELDMENT") != -1))
                    {
                        // TUBE WELDMENT
                        checkProperty("ROD END PORT DESCRIPTION THREAD", modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_RodEnd);
                        // TUBE MATERIAL AND DI,MENSIONS
                        // CYLINDER THREAD DETAILS
                        // TUBE HARDENED AND WELD SYMBOLS
                        // BASE END EXISTING FABRICATED WELD DESRIP
                        // TUBE WELDMENT SYMBOL
                        // PORT IN CASTING THREAD DESCRIPTION
                        // ZERK1 DESCRIPTION
                        // ZERK2 DESCRIPTION
                        // PORT ASSEMBLY WELDING DESCRI
                        // BASE END PORT DESCRIPTION
                        // BASE END PORT WELDING DESC
                        // ROD END PORT WELDING DESCRIPTION
                    }
                }

                if (((strFileName.IndexOf("TUBE_WELDMENT") != -1)
                            || ((strFileName.IndexOf("PISTON") != -1)
                            || ((strFileName.IndexOf("ROD_WELDMENT") != -1)
                            || ((strFileName.IndexOf("CYLINDER_HEAD") != -1)
                            || ((strFileName.IndexOf("STOP TUBE") != -1)
                            || ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected == true)
                            && ((strFileName.IndexOf("SINGLELUG") != -1)
                            || ((strFileName.IndexOf("DOUBLELUG") != -1)
                            || ((strFileName.IndexOf("THREADEDEND") != -1)
                            || ((strFileName.IndexOf("CROSSTUBE") != -1)
                            || (strFileName.IndexOf("BASEPLUG") != -1))))))))))))
                {
                    if ((strFileName.IndexOf("ROD_WELDMENT") != -1))
                    {
                        checkProperty("Material", "");
                        try
                        {
                            if (((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration == "Double Lug")
                                        && (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType == "Threaded")))
                            {
                                string strQuery = ("select * from Welded.REDLThreaded where PartCode =\'"
                                            + (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode + "\'"));
                                DataRow dr = modWeldedCylinder.MonarchConnectionObject.GetDataRow(strQuery);
                                if (!(dr == null))
                                {
                                    checkProperty("THREAD SIZE", dr["ThreadType"]);
                                }
                            }
                            else if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration == "Threaded Rod"))
                            {
                                checkProperty("THREAD SIZE", modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmREThreadedRod.cmbThreadSize_RodEnd.Text.Trim().ToString);
                            }
                        }
                        catch (Exception ex)
                        {
                        }

                        UpdateWeldDetails_RodWeldment();

                    }
                    else if ((strFileName.IndexOf("CYLINDER_HEAD") != -1))
                    {
                        checkProperty("Material", "C1045");
                    }
                    else if ((strFileName.IndexOf("STOP TUBE") != -1))
                    {
                        checkProperty("Material", "C1020");
                    }
                    checkProperty("Drawn", "INVILOGIC");
                    checkProperty("Designed", System.Environment.UserName.ToString.ToUpper());
                    checkProperty("Approved", "");
                    checkProperty("Date", strDate);
                    checkProperty("Scale", "NTS");
                    checkProperty("Mat#", "");

                    if ((strFileName.IndexOf("TUBE_WELDMENT") != -1))
                    {
                        checkProperty("Code", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT"));
                        checkProperty("Description", (Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, 2), "0.00").ToString + ("-"
                                        + (Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2), "00.00").ToString + "-W"))));

                    }
                    else if ((strFileName.IndexOf("ROD_WELDMENT") != -1))
                    {
                        checkProperty("Code", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT"));
                        checkProperty("Description", (Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, 2), "0.00").ToString + ("-"
                                        + (Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2), "00.00").ToString + ("-"
                                        + (Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ShankLength), "00.00").ToString + "-W"))))));

                    }

                    string strDocName = String.Empty;
                    if ((strFileName.IndexOf("TUBE_WELDMENT") != -1))
                    {
                        strDrawingDoc = (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\\TUBE_WELDMENT\\TUBE_WELDMENT.SLDDRW");
                        openAssemblyDrawingDocument((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\\TUBE_WELDMENT\\TUBE_WELDMENT.SLDDRW"));
                        strDocName = "TUBE_WELDMENT.SLDDRW";
                        SolidWorksModel = SolidWorksApplicationObject.ActivateDoc(strDocName);
                        if ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength >= 25))
                        {
                            BreakView("Drawing View1");
                            SolidWorksModel = SolidWorksApplicationObject.ActivateDoc(strDocName);
                            BreakView("Section View A-A");
                        }

                        try
                        {

                            if ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType == "FILLET"))
                            {
                                DeleteView("Drawing View11");
                                DeleteSketchSegment("Arc14", "Drawing View3");
                                DeleteDetailedCircle("Detail Circle3");
                            }

                            if ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType == "New"))
                            {

                                DeleteSketchSegment("Arc15", "Drawing View3");

                                DeleteView("Drawing View12");
                                DeleteDetailedCircle("Detail Circle4");
                                DeleteSketchSegment("Arc15", "Drawing View3");

                                UpdateWeldDetails("Drawing View3");

                                DeleteDetailItem("DetailItem407@Drawing View3", "Drawing View3");
                                DeleteDetailItem("DetailItem408@Drawing View3", "Drawing View3");

                                if ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion == "Flushed"))
                                {
                                    DeleteDetailItem("DetailItem410@Drawing View3", "Drawing View3");
                                }
                                else
                                {
                                    DeleteDetailItem("DetailItem400@Drawing View3", "Drawing View3");
                                }

                                DeleteDimension("D2@Sketch12@TUBE_WELDMENT", "Drawing View3");

                                DeleteNote("DetailItem169@Drawing View3", "Drawing View3");

                            }
                            else
                            {
                                DeleteView("Drawing View10");
                                DeleteDetailedCircle("Detail Circle2");
                                UpdateWeldDetails("Drawing View3");

                                DeleteDetailItem("DetailItem410@Drawing View3", "Drawing View3");
                                DeleteDetailItem("DetailItem409@Drawing View3", "Drawing View3");
                                if ((ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube == "Port Integral"))
                                {
                                    DeleteDetailItem("DetailItem407@Drawing View3", "Drawing View3");
                                }
                                DeleteSketchSegment("Arc13");
                            }

                        }
                        catch (Exception ex)
                        {
                        }

                    }
                    else if ((strFileName.IndexOf("ROD_WELDMENT") != -1))
                    {
                        strDrawingDoc = (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\\ROD_WELDMENT\\ROD_WELDMENT.SLDDRW");
                        openAssemblyDrawingDocument((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\\ROD_WELDMENT\\ROD_WELDMENT.SLDDRW"));
                        SolidWorksModel = SolidWorksApplicationObject.ActivateDoc("ROD_WELDMENT.SLDDRW");
                        if ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength >= 25))
                        {
                            BreakView("Drawing View1");
                            SolidWorksModel = SolidWorksApplicationObject.ActivateDoc("ROD_WELDMENT.SLDDRW");
                            BreakView("Drawing View2");
                        }
                    }

                }
                else if ((strFileName.IndexOf("WELD_CYLINDER_ASSEMBLY") != -1))
                {
                    strDrawingDoc = (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\\WELD_CYLINDER_ASSEMBLY\\WELD_CYLINDER_ASSEMBLY.SLDDRW");
                    string strGeneralNote;

                    strGeneralNote = (string.Format(Math.Round(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, 2), "00.00") + (" BORE" + (" X "
                                + (string.Format(Math.Round(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2), "00.00") + (" STROKE" + ("\r\n" + (" MAX. WORKING PRESSURE "
                                + (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure.ToString + (" PSI" + "\r\n")))))))));

                    if ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ColumnLoadDeratePressure != "N/A"))
                    {
                        strGeneralNote = (strGeneralNote + ("MAX. WORKING PRESSURE "
                                    + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ColumnLoadDeratePressure.ToString + (" PSI FULL EXTENSION " + "\r\n"))));
                    }

                    if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.chkSingleActingPullAppliction.Checked == true))
                    {
                        strGeneralNote = (strGeneralNote + (" SINGLE ACTING PULL APPLICATION " + "\r\n"));
                    }
                    else if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.chkSingleActingPushApplication.Checked == true))
                    {
                        strGeneralNote = (strGeneralNote + (" SINGLE ACTING PUSH APPLICATION " + "\r\n"));
                    }

                    string strClassNote = String.Empty;
                    if ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass == 1))
                    {
                        strClassNote = "CLASS 1-15,000 CYCLES";
                    }
                    else if ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass == 2))
                    {
                        strClassNote = "CLASS 2-50,000 CYCLES";
                    }
                    else if ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass == 3))
                    {
                        strClassNote = "CLASS 3-250,000 CYCLES";
                    }
                    else if ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass == 4))
                    {
                        strClassNote = "CLASS 4-500,000 CYCLES";
                    }

                    strGeneralNote = (strGeneralNote + ("MONARCH CYLINDER "
                                + (strClassNote + (" AS PER WI04-E-11" + "\r\n"))));

                    strGeneralNote = (strGeneralNote + ("CYLINDER CLEANLINESS CONTROLLED AS PER MONARCH WI10-E-50" + "\r\n"));

                    string StrTempRange = String.Empty;

                    if ((((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedPistonSeal == "Wyn Seal")
                                || (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedPistonSeal == "Glyd-P Seal"))
                                && (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 3)))
                    {
                        StrTempRange = " -25�C(-13�F) TO +100�C(210�F)";
                    }
                    else if ((((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedPistonSeal == "Wyn Seal")
                                || (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedPistonSeal == "Glyd-P Seal"))
                                && (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter > 3)))
                    {
                        StrTempRange = " -30�C(-20�F) TO +100�C(210�F)";
                    }
                    strGeneralNote = (strGeneralNote + ("ALLOWABLE TEMPERATURE RANGE:"
                                + (StrTempRange + "\r\n")));

                    if ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision == "Revision\'"))
                    {
                        string strCustomePartCode = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RevisionContractNo;
                        string strCustomerPartCode = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetCustomerPartCode(strCustomePartCode);
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCode_ContractDetails = strCustomerPartCode;
                    }

                    if ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCode_ContractDetails.Trim() != ""))
                    {
                        strGeneralNote = (strGeneralNote + ("CUSTOMER PART # " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCode_ContractDetails));
                    }

                    checkProperty("Material", "");
                    checkProperty("Drawn", "INVILOGIC");
                    checkProperty("Designed", System.Environment.UserName.ToString.ToUpper());
                    checkProperty("Approved", "");
                    checkProperty("Date", strDate);
                    checkProperty("Scale", "NTS");
                    checkProperty("Mat#", "");
                    checkProperty("Description", ("<MOD-DIAM> "
                                    + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " Welded Cylinder")));
                    checkProperty("Customer Name", ("For " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerName_ContractDetails.ToString));
                    checkProperty("Code", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString);


                    if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.SelectedItem.Trim() == "ORB"))
                    {
                        if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.SelectedItem.Trim() == "9/16"))
                        {
                            checkProperty("PORT TYPE", (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.SelectedItem.ToString + ("-18UNF "
                                            + (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.SelectedItem.ToString + " PORT TYP REF."))));
                        }
                        else if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.SelectedItem.Trim() == "3/4"))
                        {
                            checkProperty("PORT TYPE", (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.SelectedItem.ToString + ("-16UNF "
                                            + (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.SelectedItem.ToString + " PORT TYP REF."))));
                        }
                        else
                        {
                            checkProperty("PORT TYPE", (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.SelectedItem.ToString + (" "
                                            + (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.SelectedItem.ToString + " PORT TYP REF."))));
                        }
                    }
                    else
                    {
                        checkProperty("PORT TYPE", (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.SelectedItem.ToString + (" "
                                        + (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.SelectedItem.ToString + " PORT TYP REF."))));
                    }

                    if ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType == "New"))
                    {
                        checkProperty("Cylinder Note", (Math.Round((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter * 10), 2).ToString + ("WD"
                                        + (Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2).ToString + ("-" + (Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, 2) * 100).ToString)))));

                    }
                    else
                    {

                        if (((ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.ChkASAE.Checked == true)
                                    && ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength == 8)
                                    || (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength == 16))))
                        {
                            checkProperty("Cylinder Note", (Math.Round((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter * 10), 2).ToString + ("WPC"
                                            + (Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2).ToString + ("-"
                                            + ((Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, 2) * 100).ToString + "ASAE"))))));

                        }
                        else
                        {

                            checkProperty("Cylinder Note", (Math.Round((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter * 10), 2).ToString + ("WD"
                                            + (Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2).ToString + ("-" + (Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, 2) * 100).ToString)))));

                        }

                    }

                    checkProperty("General_Note", strGeneralNote);

                    checkProperty("EXTENDED LENGTH", Math.Round((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength), 2));

                    UpdateAssemblyDrawing();

                    string value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial.ToUpper();
                    if ((value.IndexOf("NITRO") != -1))
                    {
                        value = "NITROSTEEL";
                    }
                    OverwriteDimensionNote(("ROD_OD@Sketch1@WELD_CYLINDER_ASSEMBLY-0-SectionAssembly-2-1@Drawing View4/WELD_CYLINDER_ASSEMBLY-1@WE" +
                        "LD_CYLINDER_ASSEMBLY-SectionAssembly-2/"
                                    + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT") + ("-1@WELD_CYLINDER_ASSEMBLY/"
                                    + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("Rod_Welded") + ("-1@" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT")))))), value, "Drawing View4", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter);

                    value = ("(" + (Format(Math.Round((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength), 2), "00.00") + " EXTENDED)"));
                    OverwriteRetractedDimensionNote("RD48@Drawing View4", value, "Drawing View4", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength);

                    if ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength >= 25))
                    {

                        openAssemblyDrawingDocument((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\\WELD_CYLINDER_ASSEMBLY\\WELD_CYLINDER_ASSEMBLY.SLDDRW"));
                        SolidWorksModel = SolidWorksApplicationObject.ActivateDoc("WELD_CYLINDER_ASSEMBLY.SLDDRW");

                        BreakView("Drawing View2");
                        BreakView("Section View A-A");
                    }

                }

                if ((strDrawingDoc != ""))
                {
                    DeleteDanglingDimensions(strDrawingDoc);
                }
                SolidWorksApplicationObject.IActiveDoc.SaveSilent();

            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteSketchSegment(string strItem, string strViewName = "Drawing View2")
        {
            try
            {
                bool boolstatus = false;

                SolidWorksModel = SolidWorksApplicationObject.ActiveDoc;
                boolstatus = SolidWorksApplicationObject.ActiveDoc.ActivateView(strViewName);
                boolstatus = SolidWorksModel.Extension.SelectByID2(strItem, "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                SolidWorksModel.EditDelete();
                SolidWorksModel.ClearSelection2(true);
            }
            catch (Exception ex)
            {

                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Deleting SKETCH SEGMENT ");
            }
        }

        public void RenamePartFile(String strOldName, String strNewName, String strReferencingDoc)
        {
            try
            {
                bool bret = false;
                File.Move(strOldName, strNewName);
                bret = SolidWorksApplicationObject.ReplaceReferencedDocument(strReferencingDoc, strOldName, strNewName);
            }
            catch (Exception ex)
            {
            }
        }
        public void FolderStructure(string strReferenceDoc, string strNewPartPath, string strNetworkPath)
        {
            try
            {
                bool bRet = false;
                string[] strPart = strNewPartPath.Split('\\');
                string strPartName = ("\\" + strPart[(strPart).GetUpperBound(0)]);
                File.Copy(strNewPartPath, (strNetworkPath + strPartName));
                bRet = SolidWorksApplicationObject.ReplaceReferencedDocument(strReferenceDoc, strNewPartPath, (strNetworkPath + strPartName));
            }
            catch (Exception ex)
            {
            }
        }

        public void MoveDrawingFile(string strOldDrawingPath, string strNewPartPath, string strNetworkDrawingPath, string strNetworkPartPath)
        {
            try
            {
                bool bRet = false;
                File.Copy(strOldDrawingPath, strNetworkDrawingPath);
                bRet = SolidWorksApplicationObject.ReplaceReferencedDocument(strNetworkDrawingPath, strNewPartPath, strNetworkPartPath);
            }
            catch (Exception ex)
            {
            }
        }

        public void RenameDrawingFile(string strReferencingDoc, string strOldName, string strNewName)
        {
            try
            {
                bool bret = false;
                bret = SolidWorksApplicationObject.ReplaceReferencedDocument(strReferencingDoc, strOldName, strNewName);
                strOldName = strReferencingDoc;
                if ((strNewName.IndexOf(".SLDPRT") != -1))
                {
                    File.move(strOldName, strNewName.Replace(".SLDPRT", ".SLDDRW"));
                }
                else
                {
                    File.move(strOldName, strNewName.Replace(".SLDASM", ".SLDDRW"));
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void UpdateAssemblyDrawing()
        {
            string docName = String.Empty;
            try
            {

                string strDrawingFile = (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\\WELD_CYLINDER_ASSEMBLY\\WELD_CYLINDER_ASSEMBLY.SLDDRW");
                openAssemblyDrawingDocument(strDrawingFile);
                docName = "WELD_CYLINDER_ASSEMBLY.SLDDRW";
                SolidWorksModel = SolidWorksApplicationObject.ActivateDoc(docName);
                if (((double.Parse(ObjClsWeldedCylinderFunctionalClass.TxtFirstPortOrientation_BaseEnd.Text) == 0)
                            || (ObjClsWeldedCylinderFunctionalClass.TxtFirstPortOrientation_BaseEnd.Text.Trim() == "")))
                {
                    DeleteView("Drawing View5");
                }

                if (((double.Parse(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text) == 0)
                            || (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text.Trim() == "")))
                {

                    DeleteView("Drawing View6");
                }

                if (!((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "Single Lug")
                            || ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "BH")
                            || ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "Double Lug")
                            || (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "Base Plug")))))
                {
                    DeleteSketchSegment("Arc14");
                    DeleteSketchSegment("Arc12", "Section View A-A");

                }
                if (!((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration == "Single Lug")
                            || ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration == "BH")
                            || (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration == "Double Lug"))))
                {
                    DeleteSketchSegment("Arc15");
                    DeleteSketchSegment("Arc13", "Section View A-A");

                }

                if (((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "Single Lug")
                            || ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "BH")
                            || ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "Double Lug")
                            || (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "Base Plug")))))
                {
                    if (((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd == 2)
                                && ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd == 1)
                                && ((ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtSecondPortOrientationBaseEnd.Text.Trim() == "90")
                                && (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text.Trim() == "90")))))
                    {
                        DeleteSketchSegment("Arc14");
                        DeleteSketchSegment("Arc15");

                    }
                    if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationBaseEnd.Text.Trim() == "90"))
                    {
                        DeleteSketchSegment("Arc14");
                    }
                    else
                    {
                        DeleteSketchSegment("Arc12", "Section View A-A");
                    }
                }
                if (((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration == "Single Lug")
                            || ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration == "BH")
                            || (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration == "Double Lug"))))
                {
                    if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text.Trim() == "90"))
                    {
                        DeleteSketchSegment("Arc15");
                    }
                    else
                    {
                        DeleteSketchSegment("Arc13", "Section View A-A");
                    }
                }

                if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories._blnIsBaseEndPinsPresent == false))
                {
                    DeleteNote("DetailItem553@Drawing View2", "Drawing View2");
                }
                if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories._blnIsRodEndPinsPresent == false))
                {
                    DeleteNote("DetailItem557@Drawing View2", "Drawing View2");
                }
                try
                {

                    if ((((ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories._blnIsBaseEndPinsPresent == true)
                                || (ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories._blnIsRodEndPinsPresent == true))
                                && (ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.ChkIncludePinkitPerBom.Checked == true)))
                    {

                        InsertViewFromexternalPart(strDrawingFile, "X:\\TieRodModels\\TIE_ROD_STD_MODELS\\UPDATED Pin kit subassembly.SLDASM", docName, ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories._dblPinHoleSize_BaseEnd, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndKitCode);
                    }
                }
                catch (Exception ex)
                {
                }

                if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.chkStampCustomerPartOnTube.Checked == false))
                {
                    DeleteBlocksFromAssyDrawing("Block4-1", "Drawing View2");
                }
                if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.chkStampCustomerPartandDate.Checked == false))
                {
                    DeleteBlocksFromAssyDrawing("Block1-1", "Drawing View2");
                }
                if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.chkAffixLabel.Checked == false))
                {
                    DeleteBlocksFromAssyDrawing("Block5-1", "Drawing View2");
                }

                if (!((ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingYes.chkDoubleLugFabricationRequired.Checked == true)
                            || ((ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.rdbFabrication.Checked == true)
                            || ((ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes.chkBHFabricationRequired.Checked == true)
                            || ((ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortInTube2.rdbFabrication.Checked == true)
                            || ((ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes.chkCrossTubeFabricationRequired.Checked == true)
                            || ((ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube2.rdbFabrication.Checked == true)
                            || ((ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingYes.chkSingleLugFabricationRequired.Checked == true)
                            || (ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube2.rdbFabrication.Checked == true)))))))))
                {
                    DeleteView("Drawing View12");
                }

                if ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType == "New"))
                {
                    DeleteNote("DetailItem166@Drawing View4", "Drawing View4");
                }
                else
                {
                    DeleteNote("DetailItem605@Drawing View4", "Drawing View4");
                }

                try
                {
                    if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbPinHole.Enabled == false))
                    {
                        DeleteDimension("D1@BASE_PIN_HOLE_SIZE@WELD_CYLINDER_ASSEMBLY-2@Drawing View2", "Drawing View2");
                    }
                    if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbPinHole_RodEnd.Enabled == false))
                    {
                        DeleteDimension("D1@ROD_PIN_HOLE_SIZE@WELD_CYLINDER_ASSEMBLY-2@Drawing View2", "Drawing View2");
                    }

                    if (((ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbGreaseZercs.SelectedItem.Trim() == "0")
                                || (ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbGreaseZercs.SelectedItem.Trim() == "")))
                    {
                        DeleteDimension("RD9@Drawing View2", "Drawing View2");
                        DeleteDimension("RD11@Drawing View2", "Drawing View2");
                    }
                    else if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbGreaseZercs.SelectedItem.Trim() == "1"))
                    {
                        DeleteDimension("RD11@Drawing View2", "Drawing View2");
                    }
                    if (((ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbGreaseZercs_RodEnd.SelectedItem.Trim() == "0")
                                || (ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbGreaseZercs_RodEnd.SelectedItem.Trim() == "")))
                    {
                        DeleteDimension("RD29@Drawing View2", "Drawing View2");
                        DeleteDimension("RD19@Drawing View2", "Drawing View2");
                    }
                    else if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbGreaseZercs_RodEnd.SelectedItem.Trim() == "1"))
                    {
                        DeleteDimension("RD19@Drawing View2", "Drawing View2");
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if ((ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd == "Straight"))
                    {
                        DeleteDimension("D3@Sketch9@WELD_CYLINDER_ASSEMBLY.SLDDRW", "Section View A-A");
                    }
                    else
                    {
                        bool boolstatus = false;
                        SolidWorksModel = SolidWorksApplicationObject.ActivateDoc("WELD_CYLINDER_ASSEMBLY.SLDDRW");
                        oIflBaseSolidWorksClass.SolidWorksModel = SolidWorksApplicationObject.ActiveDoc;
                        boolstatus = SolidWorksModel.ActivateView("Section View A-A");
                        boolstatus = SolidWorksModel.Extension.SelectByID2("D3@Sketch9@WELD_CYLINDER_ASSEMBLY.SLDDRW", "DIMENSION", 0, 0, 0, false, 0, null, 0);
                        boolstatus = SolidWorksModel.EditDimensionProperties2(2, Math.Round((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit * 0.0254), 3), Math.Round((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit * 0.0254), 3), "", "", true, 9, 2, true, 12, 12, "", "<MOD-DIAM>", true, "", "", true);
                        DeleteDimension("D1@BASE_PIN_HOLE_SIZE@WELD_CYLINDER_ASSEMBLY-2@Drawing View2", "Drawing View2");
                    }
                    if ((ObjClsWeldedCylinderFunctionalClass.strPortAngle_RodEnd == "Straight"))
                    {
                        DeleteDimension("D4@Sketch9@WELD_CYLINDER_ASSEMBLY.SLDDRW", "Section View A-A");
                    }
                    else
                    {
                        bool boolstatus = false;
                        SolidWorksModel = SolidWorksApplicationObject.ActivateDoc("WELD_CYLINDER_ASSEMBLY.SLDDRW");
                        oIflBaseSolidWorksClass.SolidWorksModel = SolidWorksApplicationObject.ActiveDoc;
                        boolstatus = SolidWorksModel.ActivateView("Section View A-A");
                        boolstatus = SolidWorksModel.Extension.SelectByID2("D4@Sketch9@WELD_CYLINDER_ASSEMBLY.SLDDRW", "DIMENSION", 0, 0, 0, false, 0, null, 0);
                        boolstatus = SolidWorksModel.EditDimensionProperties2(2, Math.Round((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd * 0.0254), 3), Math.Round((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd * 0.0254), 3), "", "", true, 9, 2, true, 12, 12, "", "<MOD-DIAM>", true, "", "", true);
                        DeleteDimension("D1@ROD_PIN_HOLE_SIZE@WELD_CYLINDER_ASSEMBLY-2@Drawing View2", "Drawing View2");
                    }
                }
                catch (Exception ex)
                {

                    ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Updating Dimension of weld Cylinder ");
                }

                try
                {
                    if (!((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType.StartsWith("Rephasing") == true)
                                && (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType == "Conventional")))
                    {
                        DeleteView("Drawing View7");
                    }
                    if (!(((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType == "Rephasing at Extension")
                                || (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType == "Rephasing at Bothends"))
                                && (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType == "Conventional")))
                    {
                        DeleteView("Drawing View8");
                    }
                    if (!(((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType == "Rephasing at Retraction")
                                || (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType == "Rephasing at Bothends"))
                                && (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType == "Conventional")))
                    {
                        DeleteView("Drawing View9");
                    }
                    if (!((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType.StartsWith("Rephnasing") == true)
                                && (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType == "New")))
                    {
                        DeleteView("Drawing View10");
                    }
                    if (!((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType == "Rephasing at Extension")
                                && (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType == "New")))
                    {
                        DeleteView("Drawing View11");
                    }
                    if (!((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "Single Lug")
                                || ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "BH")
                                || ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "Double Lug")
                                || (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "Cross Tube")))))
                    {
                        DeleteView("Drawing View12");
                        DeleteView("Drawing View13");
                    }

                }
                catch (Exception ex)
                {
                }
                SolidWorksApplicationObject.IActiveDoc.SaveSilent();
            }
            catch (Exception ex)
            {
            }
        }

        private void DeleteSketch(string strItem)
        {
            try
            {
                bool boolstatus = false;
                SolidWorksModel = SolidWorksApplicationObject.ActiveDoc;
                SolidWorksModel.Extension.SelectByID2(strItem, "SKETCH", 0, 0, 0, false, 0, null, 0);
                SolidWorksModel.EditDelete();
                SolidWorksModel.ClearSelection2(true);
            }
            catch (Exception ex)
            {

                ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Deleting Sketch ");
            }
        }

        public void OverwriteDimensionNote(string strDimension, string Value, string strViewName, double dblValue, string strSheet = "Sheet1")
        {
            try
            {
                string docName = "WELD_CYLINDER_ASSEMBLY.SLDDRW";

                SolidWorksModel = SolidWorksApplicationObject.ActivateDoc(docName);
                bool boolstatus = false;
                oIflBaseSolidWorksClass.SolidWorksModel = SolidWorksApplicationObject.ActiveDoc;
                boolstatus = SolidWorksModel.ActivateView(strViewName);
                boolstatus = SolidWorksModel.Extension.SelectByID2(strDimension, "DIMENSION", 0, 0, 0, false, 0, null, 0);
                boolstatus = SolidWorksModel.EditDimensionProperties2(0, 0, 0, "", "", true, 9, 2, true, 12, 12, "", ("<MOD-DIAM>"
                                + (Format(Math.Round(dblValue, 2), "0.00").ToString + (" " + Value))), false, "", "", true);

                SolidWorksModel.ClearSelection2(true);
                boolstatus = SolidWorksModel.ActivateSheet(strSheet);

            }
            catch (Exception ex)
            {

                ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Overwritting Dimensions ");
            }
        }


        public void OverwriteRetractedDimensionNote(string strDimension, string Value, string strViewName, double dblValue, string strSheet = "Sheet1")
        {
            try
            {
                string docName = "WELD_CYLINDER_ASSEMBLY.SLDDRW";

                SolidWorksModel = SolidWorksApplicationObject.ActivateDoc(docName);
                bool boolstatus = false;
                oIflBaseSolidWorksClass.SolidWorksModel = SolidWorksApplicationObject.ActiveDoc;
                boolstatus = SolidWorksModel.ActivateView(strViewName);
                boolstatus = SolidWorksModel.Extension.SelectByID2(strDimension, "DIMENSION", 0, 0, 0, false, 0, null, 0);
                boolstatus = SolidWorksModel.EditDimensionProperties2(4, 0.0016, 0, "", "", true, 9, 2, true, 12, 12, "", " RETRACTED", true, "", "", true);
                boolstatus = SolidWorksModel.EditDimensionProperties2(4, 0.0016, 0, "", "", true, 9, 2, true, 12, 12, "", " RETRACTED", true, "", Value, true);
                SolidWorksModel.ClearSelection2(true);
                boolstatus = SolidWorksModel.ActivateSheet(strSheet);

            }
            catch (Exception ex)
            {

                ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Overwritting Dimensions ");
            }
        }


        public void DeleteDetailItem(string strDetailItem, string strViewName)
        {
            try
            {
                bool boolstatus = false;
                SolidWorksModel = SolidWorksApplicationObject.ActiveDoc;
                boolstatus = SolidWorksModel.ActivateView(strViewName);
                boolstatus = SolidWorksModel.Extension.SelectByID2(strDetailItem, "WELD", 0, 0, 0, false, 0, null, 0);

                SolidWorksModel.EditDelete();
                SolidWorksModel.ClearSelection2(true);
            }
            catch (Exception ex)
            {

                ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Deleting Details Item ");
            }

        }


        public Hashtable TubeWallThicknessInRation
        {
            get
            {
                TubeWallThicknessInRation = new Hashtable();
                TubeWallThicknessInRation.Add("0.121", "1/8");
                TubeWallThicknessInRation.Add("0.125", "1/8");
                TubeWallThicknessInRation.Add("0.170", "3/16");
                TubeWallThicknessInRation.Add("0.183", "3/16");
                TubeWallThicknessInRation.Add("0.185", "3/16");
                TubeWallThicknessInRation.Add("0.188", "3/16");
                TubeWallThicknessInRation.Add("0.204", "3/16");
                TubeWallThicknessInRation.Add("0.235", "1/4");
                TubeWallThicknessInRation.Add("0.245", "1/4");
                TubeWallThicknessInRation.Add("0.248", "1/4");
                TubeWallThicknessInRation.Add("0.250", "1/4");
                TubeWallThicknessInRation.Add("0.311", "5/16");
                TubeWallThicknessInRation.Add("0.313", "5/16");
                TubeWallThicknessInRation.Add("0.375", "3/8");
            }
        }

        private string GetTubeWallThickness()
        {
            try
            {
                string GetTubeWallThickness = String.Empty;
                GetTubeWallThickness = TubeWallThicknessInRation(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString);
                Return GetTubeWallThickness;
            }
            catch (Exception ex)
            {
            }
            Return GetTubeWallThickness;

        }

        private void UpdateWeldDetails_RodWeldment()
        {
            // ByVal strViewName As String)
            try
            {
                string strValue = String.Empty;
                bool boolstatus = false;
                openAssemblyDrawingDocument((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\\ROD_WELDMENT\\ROD_WELDMENT.SLDDRW"));
                string strDocName = "ROD_WELDMENT.SLDDRW";
                SolidWorksModel = SolidWorksApplicationObject.ActivateDoc(strDocName);
                SolidWorksModel = SolidWorksApplicationObject.ActiveDoc;
                // boolstatus = SolidWorksModel.ActivateView(strViewName)
                SolidWorksDrawingDocument = SolidWorksModel;
                SolidWorksView = SolidWorksDrawingDocument.GetFirstView;
                int iweldCount;
                SldWorks.WeldSymbol Owelds;
                object[] OweldsCollection;
                DataRow _oRow;
                while (!(SolidWorksView == null))
                {
                    iweldCount = SolidWorksView.GetWeldSymbolCount();
                    if ((iweldCount > 0))
                    {
                        Owelds = SolidWorksView.GetFirstWeldSymbol();
                        OweldsCollection = SolidWorksView.GetWeldSymbols();
                        try
                        {
                            string strquery = ("select WeldSize from Welded.REULug_ManualWeldDetails where WeldSizeNumeric = " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd.ToString);
                            _oRow = MonarchConnectionObject.GetDataRow(strquery);
                            strValue = (IsDBNull(_oRow["WeldSize"]) ? "0" : _oRow["WeldSize"].ToString);
                        }
                        catch (Exception ex)
                        {
                        }
                        foreach (object objWeld in OweldsCollection)
                        {
                            Owelds = objWeld;
                            if ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd == "Chamfer"))
                            {
                                Owelds.SetText(false, strValue, "<AWLD-FILL>", "", "", 1);
                            }
                            else if ((ObjClsWeldedCylinderFunctionalClass.strManual_Lathe == "Manual"))
                            {
                                Owelds.SetText(false, strValue, "<AWLD-GJ>", "", "", 3);
                            }
                            else if ((ObjClsWeldedCylinderFunctionalClass.strManual_Lathe == "Lathe"))
                            {
                                Owelds.SetText(false, strValue, "<AWLD-GU>", "", "", 3);
                            }
                            double dblroddia = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter;
                            double dblPullForce = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PullForce_RodEnd;
                            double dblweldstress = (dblPullForce
                                        / ((Math.Pow(dblroddia, 2) - Math.Pow((dblroddia - (2 * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd)), 2))
                                        * (Math.PI / 4)));
                            dblweldstress = (Math.Ceiling((dblweldstress / 100)) * 100);
                            Owelds.SetProcess(true, (dblweldstress.ToString + " PSI"), false);
                        }
                    }
                    SolidWorksView = SolidWorksView.GetNextView;
                }
                SolidWorksApplicationObject.IActiveDoc.SaveSilent();
                SolidWorksApplicationObject.CloseDoc(strDocName);
            }
            catch (Exception ex)
            {
            }
        }

        // 29_12_2010   RAGAVA
        private void UpdateWeldDetails(string strViewName)
        {
            try
            {
                string strvalue = String.Empty;
                string strQuery = String.Empty;
                DataRow _oRow;
                strvalue = GetTubeWallThickness();
                bool boolstatus = false;
                SolidWorksModel = SolidWorksApplicationObject.ActiveDoc;
                boolstatus = SolidWorksModel.ActivateView(strViewName);
                SolidWorksDrawingDocument = SolidWorksModel;
                SolidWorksView = SolidWorksDrawingDocument.GetFirstView;
                int iweldCount;
                SldWorks.WeldSymbol Owelds;
                object[] OweldsCollection;
                while (!(SolidWorksView == null))
                {
                    iweldCount = SolidWorksView.GetWeldSymbolCount();
                    if ((iweldCount > 0))
                    {
                        Owelds = SolidWorksView.GetFirstWeldSymbol();
                        OweldsCollection = SolidWorksView.GetWeldSymbols();
                        iweldCount = 1;
                        foreach (object objWeld in OweldsCollection)
                        {
                            Owelds = objWeld;
                            if ((iweldCount < 5))
                            {
                                Owelds.SetText(false, strvalue, "<AWLD-FILL>", "", "", 1);
                            }
                            else if ((iweldCount > 5))
                            {
                                if ((iweldCount > 7))
                                {
                                    if (((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion != "Flushed")
                                                || (iweldCount == 8)))
                                    {
                                        strQuery = ("Select * from CollarDetails where BoreDiameter = "
                                                    + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + (" and "
                                                    + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + (" between MinTubeWallThickness and MaxTubeWallThickness  and portSize = \'"
                                                    + (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.Text.ToString.Trim() + "\'"))))));
                                        _oRow = MonarchConnectionObject.GetDataRow(strQuery);
                                        strvalue = (IsDBNull(_oRow["WeldSize"]) ? "0" : _oRow["WeldSize"].ToString);
                                    }
                                    else
                                    {
                                        strvalue = GetTubeWallThickness();
                                    }
                                }
                                Owelds.SetText(false, strvalue, "<AWLD-FILL>", "", "", 1);
                            }
                            else if ((iweldCount > 4))
                            {
                                strvalue = GetTubeWallThickness();
                                Owelds.SetText(false, strvalue, "<AWLD-GV>", "", "", 3);
                            }
                            iweldCount = (iweldCount + 1);
                        }
                    }
                    SolidWorksView = SolidWorksView.GetNextView;
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void DeleteDetailedCircle(string strItem)
        {
            try
            {
                bool boolstatus = false;
                SolidWorksModel = SolidWorksApplicationObject.ActiveDoc;
                boolstatus = SolidWorksModel.Extension.SelectByID2(strItem, "DETAILCIRCLE", 0, 0, 0, false, 0, null, 0);
                SolidWorksModel.EditDelete();
                SolidWorksModel.ClearSelection2(true);
            }
            catch (Exception ex)
            {
                // MsgBox("Error in Deleting Notes")
                ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Deleting Notes");
            }
        }

        // 15_09_2009  ragava
        public void DeleteView(string strViewItem)
        {
            // , ByVal strViewName As String)
            try
            {
                bool boolstatus = false;
                SolidWorksModel = SolidWorksApplicationObject.ActiveDoc;
                boolstatus = SolidWorksModel.Extension.SelectByID2(strViewItem, "DRAWINGVIEW", 0, 0, 0, false, 0, null, 0);
                SolidWorksModel.EditDelete();
                SolidWorksModel.ClearSelection2(true);
            }
            catch (Exception ex)
            {
                // MsgBox("Error in Deleting View")
                ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Deleting View ");
            }
            // boolstatus = Part.Extension.SelectByID2("Drawing View15", "DRAWINGVIEW", 0.1869608025198, 0.1926634818219, 0, False, 0, Nothing, 0)
        }

        public void DeleteDimension(string strDimension, string strViewName)
        {
            try
            {
                bool boolstatus = false;
                SolidWorksModel = SolidWorksApplicationObject.ActiveDoc;
                boolstatus = SolidWorksModel.ActivateView(strViewName);
                boolstatus = SolidWorksModel.Extension.SelectByID2(strDimension, "DIMENSION", 0, 0, 0, false, 0, null, 0);
                SolidWorksModel.EditDelete();
                SolidWorksModel.ClearSelection2(true);
            }
            catch (Exception ex)
            {
                // MsgBox("Error in Deleting Dimension")
                ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Deleting Dimensions ");
            }
        }

        // 15_09_2009  ragava
        public void DeleteNote(string strNote, string strViewName)
        {
            try
            {
                bool boolstatus = false;
                SolidWorksModel = SolidWorksApplicationObject.ActiveDoc;
                boolstatus = SolidWorksModel.ActivateView(strViewName);
                boolstatus = SolidWorksModel.Extension.SelectByID2(strNote, "NOTE", 0, 0, 0, false, 0, null, 0);
                SolidWorksModel.EditDelete();
                SolidWorksModel.ClearSelection2(true);
            }
            catch (Exception ex)
            {
                // MsgBox("Error in Deleting Notes")
                ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Deleting Notes ");
            }
        }

        public void BreakView(string strViewName) 
{
        try 
	{	        
		 bool boolstatus = false;
            SldWorks.BreakLine sldBreakView; 
            SolidWorksModel = SolidWorksApplicationObject.ActiveDoc;
            boolstatus = SolidWorksModel.ActivateView(strViewName);
            boolstatus = SolidWorksModel.Extension.SelectByID2(strViewName, "DRAWINGVIEW", 0, 0, 0, False, 0, Nothing, 0);
            SolidWorksView = SolidWorksModel.SelectionManager.GetSelectedObject5(1);
            sldBreakView = SolidWorksView.InsertBreak(0, -((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength - 5) * 25.4 / 4000), ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength - 5) * 25.4 / 4000), 2);         
           if ((sldBreakView == null)) 
            {

                sldBreakView = SolidWorksView.InsertBreak(0, -0.05, 0.05, 2);
            }
            SolidWorksModel.BreakView();
            SolidWorksModel.EditRebuild3();
            SolidWorksModel.ClearSelection2(true);
            SolidWorksApplicationObject.IActiveDoc.SaveSilent();
	}
	catch (exception ex)
	{
		ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Breaking View ");
		
	}
}

        public void insertNewRow(int RevisionNumber, int nNumRow, SldWorks.TableAnnotation swTable)
        {
            //  RevisionNumber = RevisionNumber - 1
            if ((RevisionNumber >= 1))
            {
                nNumRow = swTable.RowCount;
                bool boolstatus = false;
                boolstatus = swTable.InsertRow(SwConst.swTableItemInsertPosition_e.swTableItemInsertPosition_After, (nNumRow - 1));
            }
        }


        public void DeleteBlocksFromAssyDrawing(string strBlockName, string strViewName = "Drawing View1")
        {
            try
            {
                bool boolstatus = false;

                SolidWorksModel = SolidWorksApplicationObject.ActiveDoc();
                SolidWorksDrawingDocument = SolidWorksModel;
                boolstatus = SolidWorksDrawingDocument.ActivateView(strViewName);
                boolstatus = SolidWorksModel.Extension.SelectByID2(strBlockName, "SUBSKETCHINST", 0, 0, 0, false, 0, null, 0);
                SolidWorksModel.EditDelete();
            }
            catch (Exception ex)
            {
            }
        }

        public void DeleteNotes(string NoteName, string SheetName, string type)
        {
            try
            {
                bool boolstatus = false;
                SolidWorksModel = SolidWorksApplicationObject.ActiveDoc;
                SolidWorksDrawingDocument = SolidWorksModel;
                boolstatus = SolidWorksDrawingDocument.ActivateSheet(SheetName);

                boolstatus = SolidWorksModel.Extension.SelectByID2(NoteName, type, 0.02899951513396, 0.1938605657194, 0, false, 0, null, 0);
                SolidWorksModel.EditDelete();
            }
            catch (Exception ex)
            {
            }
        }


        public void EditRetractedDimension(double ExtendedLength)
        {
            try
            {

                bool boolstatus = false;
                SolidWorksModel = SolidWorksApplicationObject.ActiveDoc;
                SolidWorksDrawingDocument = SolidWorksModel;
                boolstatus = SolidWorksDrawingDocument.ActivateView("Drawing View6");
                boolstatus = SolidWorksModel.Extension.SelectByID2("RD3@Drawing View6", "DIMENSION", 0, 0, 0, false, 0, null, 0);
                boolstatus = SolidWorksModel.EditDimensionProperties2(4, 0.001524, 0, "", "", true, 9, 2, true, 12, 12, "", " RETRACTED", true, "", "", true);
                boolstatus = SolidWorksModel.EditDimensionProperties2(4, 0.001524, 0, "", "", true, 9, 2, true, 12, 12, "", " RETRACTED", true, "", ("("
                                + (Math.Round(ExtendedLength, 2).ToString + " EXTENDED)")), true);
                SolidWorksModel.ClearSelection2(true);
            }
            catch (Exception ex)
            {
            }
        }

        public void AddConfiguration(string openFileName, string Name, string Comment, string AlternateName)
        {
            try
            {
                IModelDoc instance = null;
                bool SuppressByDefault;
                bool HideByDefault;
                bool MinFeatureManager;
                bool InheritProperties;
                System.UInt32 Flags;
                // X:\WELDED_STD_PARTS
                if ((IsCurrentSolidWorks == null))
                {
                    oIflBaseSolidWorksClass = new IFLSolidWorksBaseClass(true);
                }

                if ((File.Exists(openFileName) == false))
                {

                    ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(("Drawing file doesn\'t exist at path : " + openFileName));
                }
                oIflBaseSolidWorksClass.openDocument(openFileName);

                oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(77, false);
                instance = SolidWorksApplicationObject.ActiveDoc;
                instance.AddConfiguration(Name, Comment, AlternateName, SuppressByDefault, HideByDefault, MinFeatureManager, InheritProperties, Flags);
            }
            catch (Exception ex)
            {
            }
        }

        public void InsertTableRowDrawing(int iAssycount, int iPaintcount, int RevisionNumber, ArrayList alGetRevisionTableData)
        {
            try
            {
                object ArrswTable;
                SldWorks.TableAnnotation swTable;
                bool boolstatus = false;
                SolidWorksDrawingDocument = SolidWorksApplicationObject.ActiveDoc;
                object myModelView;
                myModelView = SolidWorksDrawingDocument.ActiveView;
                myModelView.FrameState = SwConst.swWindowState_e.swWindowMaximized;
                SolidWorksModel = SolidWorksApplicationObject.ActiveDoc;
                SolidWorksDrawingDocument = SolidWorksModel;
                SolidWorksView = SolidWorksDrawingDocument.GetFirstView;
                ArrswTable = SolidWorksView.GetTableAnnotations;
                if ((SolidWorksView.GetTableAnnotationCount > 0))
                {
                    //  Get the Assembly Table
                    swTable = ArrswTable[1];
                    for (int i = 1; (i
                                <= (iAssycount - 1)); i++)
                    {
                        boolstatus = swTable.InsertRow(SwConst.swTableItemInsertPosition_e.swTableItemInsertPosition_After, 0);
                    }
                }
                if ((SolidWorksView.GetTableAnnotationCount > 1))
                {
                    swTable = null;
                    swTable = ArrswTable[2];
                    if ((iPaintcount > 0))
                    {
                        for (int i = 1; (i
                                    <= (iPaintcount - 1)); i++)
                        {
                            boolstatus = swTable.InsertRow(SwConst.swTableItemInsertPosition_e.swTableItemInsertPosition_After, 0);
                        }
                    }
                    else
                    {

                    }
                }
                if ((SolidWorksView.GetTableAnnotationCount > 2))
                {
                    swTable = null;
                    int ntable = 0;
                    swTable = ArrswTable[ntable];
                    int nNumRow;

                    swTable.Text(1, 0) = "P00";
                    swTable.Text(1, 3) = Format(DateTime.Now, "ddMMMyy").ToUpper();
                    nNumRow = swTable.RowCount;
                    insertNewRow(RevisionNumber, nNumRow, swTable);
                    // Till   Here
                    if ((alGetRevisionTableData.Count > 0))
                    {
                        foreach (object oItem in alGetRevisionTableData)
                        {
                            nNumRow = swTable.RowCount;
                            // swTable.Text(nNumRow - 1, 0) = oItem(0)
                            swTable.Text((nNumRow - 1), 0) = ("P0" + oItem[0].ToString);
                            // 06_04_2010   RAGAVA
                            swTable.Text((nNumRow - 1), 1) = oItem[1];
                            swTable.Text((nNumRow - 1), 2) = oItem[2].ToString.ToUpper();
                            swTable.Text((nNumRow - 1), 3) = oItem[3].ToString.ToUpper();
                            swTable.Text((nNumRow - 1), 4) = oItem[4].ToString.ToUpper();
                            RevisionNumber = (RevisionNumber - 1);
                            insertNewRow(RevisionNumber, nNumRow, swTable);
                        }
                    }
                }
                SolidWorksModel.SaveSilent();
            }
            catch (Exception ex)
            {
            }
        }

        public void InsertTextBox()
        {
            string docName = String.Empty;
            try
            {

                openAssemblyDrawingDocument((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\\WELD_CYLINDER_ASSEMBLY\\WELD_CYLINDER_ASSEMBLY.SLDDRW"));
                docName = "WELD_CYLINDER_ASSEMBLY.SLDDRW";
                SolidWorksModel = SolidWorksApplicationObject.ActivateDoc(docName);
                getMaxContractRevisionNumber();

                InsertTableRowDrawing(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.iAssyNotesCount, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.iPaintingNotesCount, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.intContractRevisionNumber, getRevisionTableData);
                SolidWorksApplicationObject.IActiveDoc.SaveSilent();
                SolidWorksApplicationObject.CloseAllDocuments(true);
            }
            catch (Exception ex)
            {
            }

        }

        public void getMaxContractRevisionNumber()
        {
            try
            {
                string strSQL = "";
                strSQL = ("Select  max(RevisionNumber) as RevisionNumber From revisionTable where ContractNumber=\'"
                            + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber + "\'"));
                DataTable objDT = MonarchConnectionObject.GetTable(strSQL);
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.intContractRevisionNumber = (IsDBNull(objDT.Rows[0]["RevisionNumber"]) ? 0 : objDT.Rows[0]["RevisionNumber"]);

            }
            catch (Exception ex)
            {
            }
        }


        public ArrayList getRevisionTableData()
        {
            getRevisionTableData = null;
            try
            {
                getRevisionTableData = new ArrayList();
                string strSQL;
                int intCount;
                DataTable objDT;
                strSQL = ("select  top 7  * from revisionTable  where contractNumber=\'"
                            + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber + "\' order by RevisionNumber"));
                objDT = MonarchConnectionObject.GetTable(strSQL);
                if ((!(objDT == null)
                            && (objDT.Rows.Count < 7)))
                {
                    intCount = objDT.Rows.Count;
                }
                else
                {
                    intCount = 7;
                }
                for (int intj = 0; (intj
                            <= (intCount - 1)); intj++)
                {
                    getRevisionTableData.Add(new object[] {
                            4,
                            objDT.Rows[intj]["RevisionNumber"],
                            objDT.Rows[intj]["ECR_Number"],
                            objDT.Rows[intj]["DESCRIPTION"],
                            objDT.Rows[intj]["DATE"],
                            objDT.Rows[intj]["REVISEDBy"]});
                }
                return getRevisionTableData;
            }
            catch (Exception ex)
            {
            }
        }

        public void UpdateRevisionTable(string Description, string Revision)
        {
            try
            {

                string strDate = string.Format("{0:dd/MM/yyyy}", DateTime.Today).ToUpper();
                string strDescription;
                string PropertyName;
                PropertyName = "DESCRIPTION_";
                for (int i = 1; (i <= 7); i++)
                {
                    strDescription = SolidWorksModel.GetCustomInfoValue("", (PropertyName + i.ToString()));
                    if ((strDescription.Trim() == ""))
                    {
                        checkProperty(("DESCRIPTION_" + i.ToString()), ("ADD CODE # " + Description));
                        checkProperty(("NO_" + i.ToString()), Revision);
                        checkProperty(("DATE_" + i.ToString()), strDate);
                        return;
                    }
                }
                // Checking For RevisionNumber
                PropertyName = "NO_";
                int iRevision;
                int iRevision7;
                string strRevision = String.Empty;
                for (int i = 7; (i <= 1); i = (i + -1))
                {

                    strRevision = SolidWorksModel.GetCustomInfoValue("", (PropertyName + i.ToString()));
                    if ((strRevision.Trim() == "-"))
                    {
                        checkProperty(("DESCRIPTION_" + i.ToString), ("ADD CODE # " + Description));
                        checkProperty(("NO_" + i.ToString), Revision);
                        checkProperty(("DATE_" + i.ToString), strDate);
                        return;
                    }
                }
                strRevision = SolidWorksModel.GetCustomInfoValue("", (PropertyName + "7"));
                iRevision7 = Convert.ToInt16(strRevision);
                for (int i = 2; (i <= 7); i++)
                {

                    strRevision = SolidWorksModel.GetCustomInfoValue("", (PropertyName + i.ToString()));
                    if ((strRevision.Trim() != "-"))
                    {
                        iRevision = Convert.ToInt16(strRevision);
                        if ((iRevision <= iRevision7))
                        {

                            if ((i < 7))
                            {
                                for (int k = i; (k <= 6); k++)
                                {
                                    strRevision = SolidWorksModel.GetCustomInfoValue("", ("NO_" + (k + 1).ToString()));
                                    strDescription = SolidWorksModel.GetCustomInfoValue("", ("DESCRIPTION_" + (k + 1).ToString()));
                                    string MyDate = SolidWorksModel.GetCustomInfoValue("", ("DATE_" + (k + 1).ToString()));
                                    checkProperty(("DESCRIPTION_" + k.ToString()), ("ADD CODE # " + strDescription));
                                    checkProperty(("NO_" + k.ToString()), strRevision);
                                    checkProperty(("DATE_" + k.ToString()), MyDate);
                                }
                            }

                            checkProperty(("DESCRIPTION_" + i.ToString()), ("ADD CODE # " + Description));
                            checkProperty(("NO_" + i.ToString()), Revision);
                            checkProperty(("DATE_" + i.ToString()), strDate);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public bool InsertViewFromexternalPart(string _strDrwgInToWhichViewIsInserted, string AssemblyPathWhoseViewToBeInserted, string strDrawingName, double dblPinSize, string KitCode) 

{
        try 
        {
       
            bool blnSelection;
            SldWorks.View MyView;
            long Errors;
            long nWarnings;
            ConnectSolidWorks();
            if ((_strDrwgInToWhichViewIsInserted == ""))
            {
                _strDrwgInToWhichViewIsInserted = "X:\\TieRodModels\\TIE_ROD_STD_MODELS\\UPDATED Pin kit subassembly.SLDASM";
            }
            SolidWorksModel = SolidWorksApplicationObject.OpenDoc6(AssemblyPathWhoseViewToBeInserted, 2, SwConst.swOpenDocOptions_e.swOpenDocOptions_LoadModel, "", Errors, nWarnings);
            SolidWorksModel = SolidWorksApplicationObject.OpenDoc6(_strDrwgInToWhichViewIsInserted, 3, SwConst.swOpenDocOptions_e.swOpenDocOptions_LoadModel, "", Errors, nWarnings);
            EnableConfigurations(KitCode, _strDrwgInToWhichViewIsInserted);
            SolidWorksApplicationObject.ActivateDoc(strDrawingName);
            SolidWorksDrawingDocument = SolidWorksApplicationObject.ActiveDoc;
            MyView = SolidWorksDrawingDocument.CreateDrawViewFromModelView3(AssemblyPathWhoseViewToBeInserted, "*Right", 0.04447209023402, 0.1546562039322, 0);
            blnSelection = SolidWorksModel.Extension.SelectByID2(("Point1@Origin@pin subassembly-1@" + MyView.Name), "EXTSKETCHPOINT", 0, 0, 0, false, 0, null, 0);
        }  
        catch (Exception ex)
        {
        }
    } 
}
    }

