using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Welded.UILayer.Common;
using Welded.UILayer;
using System.Windows.Forms;
using System.Collections;
using Welded.SolidWorksLayer;
using System.IO;
using System.Threading;
using System.Drawing;
using Welded.DataBaseLayer;
using Welded.ExcelLayer;


namespace Welded.FunctionalLayer
{
    public class clsWeldedCylinderFunctionalClass
    {
        #region variables

        #region FormDeclarations

        
        clsListViewMIL _oClsListViewMIL;
        clsWeldedGlobalVariables _oClsWeldedGlobalVariables;
        
        clsWeldedDataClass _oClsWeldedDataClass;
        
        IFLSolidWorksBaseClass _oClsSolidWorksBaseClass;
        ExcelClass _oClsExcelClass;

        //================ Primary Inputs ==================================

        frmPrimaryInputs _oFrmPrimaryInputs;
        frmPistonDesign _oFrmPistonDesign;
        frmTubeDetails _oFrmTubeDetails;
        frmHeadDesign _oFrmHeadDesign;
        frmPortDetails _oFrmPortDetails;
        frmRodEndConfiguration _oFrmRodEndConfiguration;
        frmPin_Port_PaintAccessories _oFrmPin_Port_PaintAccessories;

        //=====================================================================

        //================================ Double Lug =========================

        frmDLPortInTubeDetails _oFrmDLPortInTubeDetails;
        frmDLPortInTubeDetails2 _oFrmDLPortInTubeDetails2;
        frmDLCastingYes _oFrmDLCastingYes;
        frmDLCastingNo_PortInTube _oFrmDLCastingNo_PortInTube;
        frmDLCastingNo_PortInTube2 _oFrmDLCastingNo_PortInTube2;
        frmDLPortIntegral _oFrmDLPortIntegral;
        frmDLPortIntegral2 _oFrmDLPortIntegral2;
        frmDLFabrication _oFrmDLFabrication;
        frmDLDesignACasting _oFrmDLDesignACasting;
        frmDLFabrication2 _oFrmDLFabrication2;
        frmDLDesignACasting2 _oFrmDLDesignACasting2;
        frmDLCastingYes2 _oFrmDLCastingYes2;
        frmDLCastingNo_PortIntegral _oFrmDLCastingNo_PortIntegral;
        frmDLCastingNo_PortIntegral2 _oFrmDLCastingNo_PortIntegral2;
        frmFabricatedSingleLug_RetractedLength _oFrmFabricatedSingleLug;
        frmFabricatedSingleLug_RetractedLength2 _oFrmFabricatedSingleLug2;
        //=================================================================================

        //=================================== BH ==========================================


        frmBHCastingNo_PortIntegral _oFrmBHCastingNo_PortIntegral;
        frmBHCastingNo_PortInTube _oFrmBHCastingNo_PortInTube;
        frmBHCastingYes _oFrmBHCastingYes;
        frmBHDesignACasting _oFrmBHDesignACasting;
        frmBHFabrication _oFrmBHFabrication;
        frmBHPortIntegral _oFrmBHPortIntegral;
        frmBHPortInTube _oFrmBHPortinTube;
        frmBHCastingNo_PortIntegral2 _oFrmBHCastingNo_PortIntegral2;
        frmBHCastingNo_PortInTube2 _oFrmBHCastingNo_PortInTube2;
        frmBHCastingYes2 _oFrmBHCastingYes2;
        frmBHDesignACasting2 _oFrmBHDesignACasting2;
        frmBHFabrication2 _oFrmBHFabrication2;
        frmBHPortIntegral2 _oFrmBHPortIntegral2;
        frmBHPortInTube2 _oFrmBHPortinTube2;

        //=======================================================================================

        //=================================== Single Lug ========================================

        frmSLCastingNo_PortIntegral _oFrmSLCastingNo_PortIntegral;
        frmSLCastingNo_PortInTube _oFrmSLCastingNo_PortInTube;
        frmSLCastingYes _oFrmSLCastingYes;
        frmSLDesignACasting _oFrmSLDesignACasting;
        frmSLFabrication _oFrmSLFabrication;
        frmSLPortIntegral _oFrmSLPortIntegral;
        frmSLPortinTube _oFrmSLPortinTube;
        frmSLCastingNo_PortIntegral2 _oFrmSLCastingNo_PortIntegral2;
        frmSLCastingNo_PortInTube2 _oFrmSLCastingNo_PortInTube2;
        frmSLCastingYes2 _oFrmSLCastingYes2;
        frmSLDesignACasting2 _oFrmSLDesignACasting2;
        frmSLFabrication2 _oFrmSLFabrication2;
        frmSLPortIntegral2 _oFrmSLPortIntegral2;
        frmSLPortinTube2 _oFrmSLPortinTube2;

        //==============================================================================================

        //======================================= Base Plug ============================================

        frmBasePlugCastingYes _oFrmBasePlugCastingYes;
        frmBasePlugPortInTube _oFrmBasePlugPortInTube;
        frmBasePlugPortIntegral _oFrmBasePlugPortIntegral;
        frmDesignABasePlug _oFrmDesignABasePlug;
        frmBasePlugCastingYesPortIntegral _oFrmBasePlugCastingYesPortIntegral;
        frmBasePlugCastingNoPortIntegral _oFrmBasePlugCastingNoPortIntegral;

        //=============================================================================================

        //======================================= Plate Clevis =========================================

        frmConPlateClevis _oFrmConPlateClevis;

        //==============================================================================================

        //==========================================Threaded End =========================================

        frmThreadedEndCastingYes _oFrmThreadedCastingYes;
        frmThreadedEndPortInTube _oFrmThreadedPortInTube;
        frmDesignAThreadedCasting _oFrmDesignAThreadedCasting;
        frmThreadedEndPortIntegral _oFrmThreadedEndPortIntegral;
        frmBEThreadedEndCastingNo_PortIntegral _oFrmBEThreadedEndCastingNo_PortIntegral;
        frmThreadedEndCastingYes_PortIntegral _ofrmThreadedEndCastingYes_PortIntegral;

        //================================================================================================
        //=====================================Cross Tube ================================================

        frmCTPortInTube _oFrmCTPortInTube;
        frmCTPortIntegral _oFrmCTPortIntegral;
        frmCTFabrication _oFrmCTFabrication;
        frmCTDesignACasting _oFrmCTDesignACasting;
        frmCTCastingYes _oFrmCTCastingYes;
        frmCTCastingNo_PortInTube _oFrmCTCastingNo_PortInTube;
        frmCTCastingNo_PortIntegral _oFrmCTCastingNo_PortIntegral;
        frmCTPortInTube2 _oFrmCTPortInTube2;
        frmCTPortIntegral2 _oFrmCTPortIntegral2;
        frmCTFabrication2 _oFrmCTFabrication2;
        frmCTDesignACasting2 _oFrmCTDesignACasting2;
        frmCTCastingYes2 _oFrmCTCastingYes2;
        frmCTCastingNo_PortInTube2 _oFrmCTCastingNo_PortInTube2;
        frmCTCastingNo_PortIntegral2 _oFrmCTCastingNo_PortIntegral2;

        //=====================================================================================================
        //=======================================Single Lug Rod End ===========================================
        frmRESingleLugDetails _oFrmRESingleLugDetails;
        frmRESingleLugExistingNotSelected _oFrmRESingleLugExistingNotSelected;

        //=====================================================================================================
        //=======================================BH Rod End ===========================================
        frmREBHDetails _oFrmREBHDetails;
        frmREBHExistingNotSelected _oFrmREBHExistingNotSelected;

        //=====================================================================================================
        //==================================Flat With Chamfer Rod End ===========================================
        frmFlatWithChamfer _oFrmFlatWithChamfer;

        //=====================================================================================================
        //=======================================Drilled Pin Hole Rod End =====================================
        frmREDrilledPinHole _oFrmREDrilledPinHole;


        //=====================================================================================================
        //===================================Threaded Rod_Rod End ===========================================
        frmREThreadedRod _oFrmREThreadedRod;
        frmRetractedLengthValidation _oFrmRetractedLengthValidation;


        //=====================================================================================================
        //=======================================Cross Tube Rod End ===========================================

        frmRECrossTube _oFrmRECrossTube;
        frmCastingYes_RECT _oFrmCastingYes_RECT;
        frmCastingNo_RECT _oFrmCastingNo_RECT;
        frmDesignACasting_RECT _oFrmDesignACasting_RECT;
        frmFabrication_RECT _oFrmFabrication_RECT;

        //=====================================================================================================

        frmGenerate _oFrmGenerate;

        //=====================================================================================================
        //=======================================Contract Details ===========================================

        frmContractDetails _oFrmContractDetails;
        frmMonarchRevision _oFrmMonarchRevision;
        frmUpdateDatabaseRecords _ofrmUpdateRecords;

        #region REDoubleLug

        frmREDLCasting _oFrmREDLCasting;

        frmREDLThreaded _oFrmREDLThreaded;

        frmREDLWelded _oFrmREDLWelded;

        #endregion

        #region Imports Forms

        frmImportBaseEnd _oFrmImportBaseEnd;
        frmImportRodEnd _oFrmImportRodEnd;
        #endregion

        #endregion

        #region General

        bool _blnIsNewTube = false;
        bool _blnIsNewRod = false;
        ArrayList METHDM_Cylinder_ToolsList;
        ArrayList METHDM_ROD_ToolsList;
        ArrayList METHDM_TUBE_ToolsList;
        string PaintStandardCost = String.Empty;
        string PistonCodeNumber = String.Empty;
        string strExistingBaseEndPartCode = String.Empty;
        string strExistingBaseEndPartCode2 = String.Empty;
        string strExistingRodEndPartCode = String.Empty;
        string strExistingRodEndPartCode2 = String.Empty;
        bool _blnShowCasting_Thru_ExistingRESL;
        bool _blnShowCasting_Thru_ExistingREBH;
        ArrayList _aFormNavigationOrder;
        object _oCurrentForm;
        Button _btnNextClick;
        Button _btnBackClick;
        ArrayList _aEmptyControlData;
        string _strCurrentWorkingDirectory = System.Environment.CurrentDirectory;
        string _strMotherExcelPath = (_strCurrentWorkingDirectory + "\\WELD_GUI_PARAMETERS.xls");
        string _strchildExcelPath = String.Empty;
        Excel.Application _oExApplication;
        Excel.Workbook _oExWorkbook;
        Excel.Worksheet _oExSheetGUI;
        int _intGUIExcelRange;
        ArrayList _aAllControlData;
        ArrayList _aSingleFormControlData;
        ListView _lvwGeneralInformation;
        ArrayList _aGeneralInformation;
        RichTextBox _rtxtMessages;
        Hashtable _htControlValues_ToExcel = new Hashtable();
        string _strIsPortIntegral_or_PortInTube = String.Empty;
        bool _blnShowPortInTube_Thru_PortIntegral;
        bool _blnShowCastingNo_Thru_CastingYes;
        bool _blnShowCastingNo_Thru_CastingYes_RodEnd;
        bool _blnShowFabricNo_Thru_FabricYes;
        Hashtable _htNewDesignPartParams = new Hashtable();
        bool _blnNewCastingPartCopied;
        bool _blnNewBasePlugPartCopied;
        bool _blnNewSLCastingPartCopied;
        bool _blnNewUlugPartCopied;
        double _dblBendRadius;
        double _dblTopRadius;
        RadioButton _rdbFabrication;
        RadioButton _rdbDesignANewCasting;
        bool _blnGenerateULug;
        bool _blnGenerateCasting;
        ArrayList _alParameters;
        ExcelClass oExcelClass = new ExcelClass();
        Exception _oErrorObject;
        string _strErrorMessage = String.Empty;
        FileStream _oFileStream;
        StreamWriter _oStreamWriter;
        int _intLineNumber;
        bool _blnShowWelded_Thru_Threaded_REDL;
        bool _blnShowCasting_Thru_Welded_REDL;
        int _intPinHoleSize_Source;
        int _intPinHoleSize_source_RodEnd;
        string _strIsExact_NewDesign_Resize = String.Empty;
        string _strIsExact_NewDesign_Resize2 = String.Empty;
        string _strIsExact_NewDesign_Resize_RodEnd = String.Empty;
        string _strIsExact_NewDesign_Resize_RodEnd2 = String.Empty;
        string _strFacricatedPart = String.Empty;
        string _strFacricatedPart2 = String.Empty;
        string strManual_Lathe2 = String.Empty;
        string strManual_Lathe = String.Empty;
    public string strRE_Cast_Fabricated = String.Empty;
        double dblDL_LugGap;
        double dblDL_LugGap2;
        string strPortAngle_BaseEnd = String.Empty;
        string strPortAngle_RodEnd = String.Empty;
        bool _blnRetractedLengthChangedFromRetractedValidationScreen;
        bool _blnCompressCylinderChecked;
        Panel _oPnlChildFormArea;
        PictureBox _oMdiPictureBox;
        object _oCurrentForm_Object;
        bool _oIsWeldSizeLess;
        bool _blnPortIntegral_ExistingDetailsFound;
        bool _blnIsCounterBoreOrNot;
        bool _blnIsPackPinsAndClipsInPlasticBagChecked;
        bool _blnIsPort_BaseEndOrRodEnd;
        bool _blnIsImportPortsButtonClicked;
        string strCMSfileLocation = String.Empty;
        bool _blnIsBaseEndPortImported;
        bool _blnIsRodEndPortImported;
        bool _blnIsBaseEndPartImported;
        bool _blnIsRodEndPartImported;
        bool _blnIsPlateClevisImported;
        Hashtable _htPartCode_Purchase_ListViewSelectedValidation = new Hashtable();
        bool _blnIsValueChanged_Revision;
        bool _blnIsReleaseCylinderChecked;
        string _strIsNew_Revision_Released;
        bool _blnIsExistingButNotReleased_TubeWeldment;
        bool _blnIsExistingButNotReleased_RodWeldment;
        bool _blnIsExistingButNotReleased_Lug_BE;
        bool _blnIsExistingButNotReleased_Lug_RE;
        bool _blnIsExistingButNotReleased_CylinderHead;
        bool _blnIsExistingButNotReleased_Piston;
        bool _blnIsExistingButNotReleased_CrossTube_BE;
        bool _blnIsExistingButNotReleased_CrossTube_RE;
        bool _blnIsExistingButNotReleased_Casting_BE;
        bool _blnIsExistingButNotReleased_Casting_RE;
        bool _blnIsExistingButNotReleased_StopTube;
        Hashtable METHDM_LUG_TUBE_HashTable;
        Hashtable METHDM_LUG_ROD_HashTable;
        ProgressBar _prb;
        Thread _oThreadProgressBarStepping;


        #region TextBox Objects

        TextBox _oTxtLugThickness_BaseEnd;
        TextBox _oTxtCrossTubeWidth_BaseEnd;
        TextBox _oTxtSwingClearance_BaseEnd;
        TextBox _oTxtLugGap_BaseEnd;
        ComboBox _oCmbBushingPinHoleSize_BaseEnd;
        ComboBox _oCmbPinHoleSize_BaseEnd;
        TextBox _oTxtPinHoleSize_BaseEnd;
        ComboBox _oCmbGreaseZercs_BaseEnd;
        TextBox _oTxtAngleOfGreaseZercs1_BaseEnd;
        TextBox _oTxtAngleOfGreaseZercs2_BaseEnd;
        TextBox _oTxtLugThickness_RodEnd;
        TextBox _oTxtCrossTubeWidth_RodEnd;
        TextBox _oTxtSwingClearance_RodEnd;
        ComboBox _oCmbPinHoleSize_RodEnd;
        TextBox _oTxtPinHoleSize_RodEnd;
        ComboBox _oCmbGreaseZercs_RodEnd;
        TextBox _oTxtAngleOfGreaseZercs1_RodEnd;
        TextBox _oTxtAngleOfGreaseZercs2_RodEnd;
        TextBox _oTxtLugGap_RodEnd;
        ComboBox _oCmbBushingPinHoleSize_RodEnd;
        TextBox _oTxtRetractedLength;
        TextBox _oTxtCrossTubeOffset_RodEnd;
        TextBox _oTxtCrossTubeOffset_BaseEnd;
        ComboBox _oCmbPortSizeBaseEnd;
        TextBox _oTxtBasePlugDia_BaseEnd;
        ComboBox _oCmbPortType_BaseEnd;
        TextBox _oTxtFirstPortOrientation_BaseEnd;
        string FirstPortOrientation_RodEnd = String.Empty;
        TextBox _oTxtSecondPortOrientation_BaseEnd;
        ComboBox _oTxtThreadDiameter_BaseEnd;
        TextBox _oTxtThreadLength_BaseEnd;
        TextBox _oTxtToleranceUpperLimit_RodEnd;
        TextBox _oTxtToleranceLowerLimit_RodEnd;
        ComboBox _oCmbRodEndConfiguration_RodEnd;
        ComboBox _ocmbConnectionType_RodEnd;
        ComboBox _oCmbWeldType_BaseEnd;
        ComboBox _oCmbBaseEndConfiguration;
        ComboBox _oCmbPins_BaseEnd;
        ComboBox _oCmbPins_RodEnd;
        ComboBox _oCmbClips_BaseEnd;
        ComboBox _oCmbClips_RodEnd;
        TextBox _oTxtToleranceUpperLimit;
        TextBox _oTxtToleranceLowerLimit;

        #endregion

        #endregion

        #endregion

        #region Enums

        public enum ConfigurationTypes
        {
            CrossTube,
            Ulug,
            UGroove,
            ULugLathe,
        };


        public enum WeldType
        {
            ManualWeld,
            LatheWeld,
        }


        public enum EOrderOfFormNavigationArraylist
        {
            CurrentFormName = 0,
            CurrentFormObject = 1,
            PreviousFormObject = 2,
            NextFormObject = 3,
        }

        public enum EExcel_GUIControls_Relation
        {
            GUIControlName = 0,
            ExcelCellContent = 1,
            ExcelRange = 2,
            GUIControlValue = 3,
        }


        public enum YeildStrengthConstants
        {
            CrossTube = 30000,
            CrossTube_Cast_NoPort = 36000,
            CrossTube_Cast_FlushedPort = 36000,
            CrossTube_Cast_RaisedPort = 36000,
            CrossTube_RodEnd_Casting = 79000,

            BH = 44000,
            BH_Cast_NoPort = 36000,
            BH_Cast_FlushedPort = 36000,

            SingleLug = 44000,
            SingleLug_Cast_NoPort = 36000,
            SingleLug_Cast_FlushedPort = 36000,
            ULug = 44000,

            DoubleLug_Cast_NoPort = 36000,
            DoubleLug_Cast_FlushedPort = 36000,
            BasePlug_NoPort = 30000,
            BasePlug_withPort = 30000,
        }

        public enum PinHoleSourceTypes
        {
            BushingPinHole = 0,
            PinHoleCustom = 1,
            PinHoleStandard = 2,
        }

        private enum StandardPinHoles
        {
            UserSelectedPinHole = 0,
            StandardPinHole = 1,
        }

        #endregion

        #region Properties

        #region REDoubleLug

        bool _blnShowNewDesign_Thru_ExistingDesign_DoubleLug;
        frmREDLExistingDesign _oFrmREDLExistingDesign;
        frmREDLNewDesign _oFrmREDLNewDesign;


        // Sunny 03-06-10
        public bool BlnShowNewDesign_Thru_ExistingDesign_DoubleLug
        {
            get
            {
                return _blnShowNewDesign_Thru_ExistingDesign_DoubleLug;
            }
            set
            {
                _blnShowNewDesign_Thru_ExistingDesign_DoubleLug = value;
            }
        }

        public frmREDLExistingDesign ObjFrmREDLExistingDesign
        {
            get
            {
                return _oFrmREDLExistingDesign;
            }
            set
            {
                _oFrmREDLExistingDesign = value;
            }
        }

        public frmREDLNewDesign ObjFrmREDLNewDesign
        {
            get
            {
                return _oFrmREDLNewDesign;
            }
            set
            {
                _oFrmREDLNewDesign = value;
            }
        }

        #endregion

        #region Form Declaration Properties


        public object IFLSolidWorksBaseClassObject
        {
            get
            {
                if ((_oClsSolidWorksBaseClass == null))
                {
                    _oClsSolidWorksBaseClass = new IFLSolidWorksClass();
                    _oClsSolidWorksBaseClass.ConnectSolidWorks();
                }
                return _oClsSolidWorksBaseClass;
            }
        }

        public clsListViewMIL ObjClsListViewMIL
        {
            get
            {
                return _oClsListViewMIL;
            }
            set
            {
                _oClsListViewMIL = value;
            }
        }

        public clsWeldedDataClass ObjClsWeldedDataClass
        {
            get
            {
                return _oClsWeldedDataClass;
            }
            set
            {
                _oClsWeldedDataClass = value;
            }
        }

        public clsWeldedGlobalVariables ObjClsWeldedGlobalVariables
        {
            get
            {
                return _oClsWeldedGlobalVariables;
            }
            set
            {
                _oClsWeldedGlobalVariables = value;
            }
        }

        public ExcelClass ObjClsExcelClass
        {
            get
            {
                return _oClsExcelClass;
            }
            set
            {
                _oClsExcelClass = value;
            }
        }

        public frmPrimaryInputs ObjFrmPrimaryInputs
        {
            get
            {
                return _oFrmPrimaryInputs;
            }
            set
            {
                _oFrmPrimaryInputs = value;
            }
        }

        public frmPistonDesign ObjFrmPistonDesign
        {
            get
            {
                return _oFrmPistonDesign;
            }
            set
            {
                _oFrmPistonDesign = value;
            }
        }

        public frmHeadDesign ObjFrmHeadDesign
        {
            get
            {
                return _oFrmHeadDesign;
            }
            set
            {
                _oFrmHeadDesign = value;
            }
        }

        public frmRodEndConfiguration ObjFrmRodEndConfiguration
        {
            get
            {
                return _oFrmRodEndConfiguration;
            }
            set
            {
                _oFrmRodEndConfiguration = value;
            }
        }

        public frmPin_Port_PaintAccessories ObjFrmPin_Port_PaintAccessories
        {
            get
            {
                return _oFrmPin_Port_PaintAccessories;
            }
            set
            {
                _oFrmPin_Port_PaintAccessories = value;
            }
        }

        public frmThreadedEndCastingYes ObjFrmThreadedCastingYes
        {
            get
            {
                return _oFrmThreadedCastingYes;
            }
            set
            {
                _oFrmThreadedCastingYes = value;
            }
        }

        public frmThreadedEndPortInTube ObjFrmThreadedEndPortInTube
        {
            get
            {
                return _oFrmThreadedPortInTube;
            }
            set
            {
                _oFrmThreadedPortInTube = value;
            }
        }

        public frmDesignAThreadedCasting ObjFrmDesignAThreadedCasting
        {
            get
            {
                return _oFrmDesignAThreadedCasting;
            }
            set
            {
                _oFrmDesignAThreadedCasting = value;
            }
        }

        public frmThreadedEndPortIntegral ObjFrmThreadedEndPortIntegral
        {
            get
            {
                return _oFrmThreadedEndPortIntegral;
            }
            set
            {
                _oFrmThreadedEndPortIntegral = value;
            }
        }

        public frmBEThreadedEndCastingNo_PortIntegral ObjFrmBEThreadedEndCastingNo_PortIntegral
        {
            get
            {
                return _oFrmBEThreadedEndCastingNo_PortIntegral;
            }
            set
            {
                _oFrmBEThreadedEndCastingNo_PortIntegral = value;
            }
        }

        public frmThreadedEndCastingYes_PortIntegral ObjFrmThreadedEndCastingYes_PortIntegral
        {
            get
            {
                return _ofrmThreadedEndCastingYes_PortIntegral;
            }
            set
            {
                _ofrmThreadedEndCastingYes_PortIntegral = value;
            }
        }

        public frmTubeDetails ObjFrmTubeDetails
        {
            get
            {
                return _oFrmTubeDetails;
            }
            set
            {
                _oFrmTubeDetails = value;
            }
        }

        public frmPortDetails ObjFrmPortDetails
        {
            get
            {
                return _oFrmPortDetails;
            }
            set
            {
                _oFrmPortDetails = value;
            }
        }

        //===============================================================================
        //===================================== Double Lug ==============================

        public frmDLPortInTubeDetails ObjFrmDLPortInTubeDetails
        {
            get
            {
                return _oFrmDLPortInTubeDetails;
            }
            set
            {
                _oFrmDLPortInTubeDetails = value;
            }
        }

        public frmDLPortInTubeDetails2 ObjFrmDLPortInTubeDetails2
        {
            get
            {
                return _oFrmDLPortInTubeDetails2;
            }
            set
            {
                _oFrmDLPortInTubeDetails2 = value;
            }
        }

        public frmDLCastingYes ObjFrmDLCastingYes
        {
            get
            {
                return _oFrmDLCastingYes;
            }
            set
            {
                _oFrmDLCastingYes = value;
            }
        }

        public frmDLCastingYes2 ObjFrmDLCastingYes2
        {
            get
            {
                return _oFrmDLCastingYes2;
            }
            set
            {
                _oFrmDLCastingYes2 = value;
            }
        }

        public frmDLCastingNo_PortInTube ObjFrmDLCastingNo_PortInTube
        {
            get
            {
                return _oFrmDLCastingNo_PortInTube;
            }
            set
            {
                _oFrmDLCastingNo_PortInTube = value;
            }
        }

        public frmDLCastingNo_PortInTube2 ObjFrmDLCastingNo_PortInTube2
        {
            get
            {
                return _oFrmDLCastingNo_PortInTube2;
            }
            set
            {
                _oFrmDLCastingNo_PortInTube2 = value;
            }
        }

        public frmDLPortIntegral ObjFrmDLPortIntegral
        {
            get
            {
                return _oFrmDLPortIntegral;
            }
            set
            {
                _oFrmDLPortIntegral = value;
            }
        }

        public frmDLPortIntegral2 ObjFrmDLPortIntegral2
        {
            get
            {
                return _oFrmDLPortIntegral2;
            }
            set
            {
                _oFrmDLPortIntegral2 = value;
            }
        }

        public frmDLFabrication ObjFrmDLFabrication
        {
            get
            {
                return _oFrmDLFabrication;
            }
            set
            {
                _oFrmDLFabrication = value;
            }
        }

        public frmDLFabrication2 ObjFrmDLFabrication2
        {
            get
            {
                return _oFrmDLFabrication2;
            }
            set
            {
                _oFrmDLFabrication2 = value;
            }
        }

        public frmFabricatedSingleLug_RetractedLength objfrmFabricatedSingleLug
        {
            get
            {
                return _oFrmFabricatedSingleLug;
            }
            set
            {
                _oFrmFabricatedSingleLug = value;
            }
        }

        public frmFabricatedSingleLug_RetractedLength2 objfrmFabricatedSingleLug2
        {
            get
            {
                return _oFrmFabricatedSingleLug2;
            }
            set
            {
                _oFrmFabricatedSingleLug2 = value;
            }
        }

        public frmDesignABasePlug ObjFrmDesignABasePlug
        {
            get
            {
                return _oFrmDesignABasePlug;
            }
            set
            {
                _oFrmDesignABasePlug = value;
            }
        }

        public frmDLDesignACasting ObjFrmDLDesignACasting
        {
            get
            {
                return _oFrmDLDesignACasting;
            }
            set
            {
                _oFrmDLDesignACasting = value;
            }
        }

        public frmDLDesignACasting2 ObjFrmDLDesignACasting2
        {
            get
            {
                return _oFrmDLDesignACasting2;
            }
            set
            {
                _oFrmDLDesignACasting2 = value;
            }
        }

        public frmDLCastingNo_PortIntegral ObjFrmDLCastingNo_PortIntegral
        {
            get
            {
                return _oFrmDLCastingNo_PortIntegral;
            }
            set
            {
                _oFrmDLCastingNo_PortIntegral = value;
            }
        }

        public frmDLCastingNo_PortIntegral2 ObjFrmDLCastingNo_PortIntegral2
        {
            get
            {
                return _oFrmDLCastingNo_PortIntegral2;
            }
            set
            {
                _oFrmDLCastingNo_PortIntegral2 = value;
            }
        }

        //==========================================================================================
        //======================================= BH ===============================================

        public frmBHCastingNo_PortIntegral ObjFrmBHCastingNo_PortIntegral
        {
            get
            {
                return _oFrmBHCastingNo_PortIntegral;
            }
            set
            {
                _oFrmBHCastingNo_PortIntegral = value;
            }
        }

        public frmBHCastingNo_PortInTube ObjFrmBHCastingNo_PortInTube
        {
            get
            {
                return _oFrmBHCastingNo_PortInTube;
            }
            set
            {
                _oFrmBHCastingNo_PortInTube = value;
            }
        }

        public frmBHCastingYes ObjFrmBHCastingYes
        {
            get
            {
                return _oFrmBHCastingYes;
            }
            set
            {
                _oFrmBHCastingYes = value;
            }
        }

        public frmBHDesignACasting ObjFrmBHDesignACasting
        {
            get
            {
                return _oFrmBHDesignACasting;
            }
            set
            {
                _oFrmBHDesignACasting = value;
            }
        }

        public frmBHFabrication ObjFrmBHFabrication
        {
            get
            {
                return _oFrmBHFabrication;
            }
            set
            {
                _oFrmBHFabrication = value;
            }
        }

        public frmBHPortIntegral ObjFrmBHPortIntegral
        {
            get
            {
                return _oFrmBHPortIntegral;
            }
            set
            {
                _oFrmBHPortIntegral = value;
            }
        }

        public frmBHPortInTube ObjFrmBHPortinTube
        {
            get
            {
                return _oFrmBHPortinTube;
            }
            set
            {
                _oFrmBHPortinTube = value;
            }
        }

        public frmBHCastingNo_PortIntegral2 ObjFrmBHCastingNo_PortIntegral2
        {
            get
            {
                return _oFrmBHCastingNo_PortIntegral2;
            }
            set
            {
                _oFrmBHCastingNo_PortIntegral2 = value;
            }
        }

        public frmBHCastingNo_PortInTube2 ObjFrmBHCastingNo_PortInTube2
        {
            get
            {
                return _oFrmBHCastingNo_PortInTube2;
            }
            set
            {
                _oFrmBHCastingNo_PortInTube2 = value;
            }
        }

        public frmBHCastingYes2 ObjFrmBHCastingYes2
        {
            get
            {
                return _oFrmBHCastingYes2;
            }
            set
            {
                _oFrmBHCastingYes2 = value;
            }
        }

        public frmBHDesignACasting2 ObjFrmBHDesignACasting2
        {
            get
            {
                return _oFrmBHDesignACasting2;
            }
            set
            {
                _oFrmBHDesignACasting2 = value;
            }
        }

        public frmBHFabrication2 ObjFrmBHFabrication2
        {
            get
            {
                return _oFrmBHFabrication2;
            }
            set
            {
                _oFrmBHFabrication2 = value;
            }
        }

        public frmBHPortIntegral2 ObjFrmBHPortIntegral2
        {
            get
            {
                return _oFrmBHPortIntegral2;
            }
            set
            {
                _oFrmBHPortIntegral2 = value;
            }
        }

        public frmBHPortInTube2 ObjFrmBHPortinTube2
        {
            get
            {
                return _oFrmBHPortinTube2;
            }
            set
            {
                _oFrmBHPortinTube2 = value;
            }
        }

        //============================================================================
        //===================================== Single Lug ===========================

        public frmSLCastingNo_PortIntegral ObjFrmSLCastingNo_PortIntegral
        {
            get
            {
                return _oFrmSLCastingNo_PortIntegral;
            }
            set
            {
                _oFrmSLCastingNo_PortIntegral = value;
            }
        }

        public frmSLCastingNo_PortInTube ObjFrmSLCastingNo_PortInTube
        {
            get
            {
                return _oFrmSLCastingNo_PortInTube;
            }
            set
            {
                _oFrmSLCastingNo_PortInTube = value;
            }
        }

        public frmSLCastingYes ObjFrmSLCastingYes
        {
            get
            {
                return _oFrmSLCastingYes;
            }
            set
            {
                _oFrmSLCastingYes = value;
            }
        }

        public frmSLDesignACasting ObjFrmSLDesignACasting
        {
            get
            {
                return _oFrmSLDesignACasting;
            }
            set
            {
                _oFrmSLDesignACasting = value;
            }
        }

        public frmSLFabrication ObjFrmSLFabrication
        {
            get
            {
                return _oFrmSLFabrication;
            }
            set
            {
                _oFrmSLFabrication = value;
            }
        }

        public frmSLPortIntegral ObjFrmSLPortIntegral
        {
            get
            {
                return _oFrmSLPortIntegral;
            }
            set
            {
                _oFrmSLPortIntegral = value;
            }
        }

        public frmSLPortinTube ObjFrmSLPortinTube
        {
            get
            {
                return _oFrmSLPortinTube;
            }
            set
            {
                _oFrmSLPortinTube = value;
            }
        }

        public frmSLCastingNo_PortIntegral2 ObjFrmSLCastingNo_PortIntegral2
        {
            get
            {
                return _oFrmSLCastingNo_PortIntegral2;
            }
            set
            {
                _oFrmSLCastingNo_PortIntegral2 = value;
            }
        }

        public frmSLCastingNo_PortInTube2 ObjFrmSLCastingNo_PortInTube2
        {
            get
            {
                return _oFrmSLCastingNo_PortInTube2;
            }
            set
            {
                _oFrmSLCastingNo_PortInTube2 = value;
            }
        }

        public frmSLCastingYes2 ObjFrmSLCastingYes2
        {
            get
            {
                return _oFrmSLCastingYes2;
            }
            set
            {
                _oFrmSLCastingYes2 = value;
            }
        }

        public frmSLDesignACasting2 ObjFrmSLDesignACasting2
        {
            get
            {
                return _oFrmSLDesignACasting2;
            }
            set
            {
                _oFrmSLDesignACasting2 = value;
            }
        }

        public frmSLFabrication2 ObjFrmSLFabrication2
        {
            get
            {
                return _oFrmSLFabrication2;
            }
            set
            {
                _oFrmSLFabrication2 = value;
            }
        }

        public frmSLPortIntegral2 ObjFrmSLPortIntegral2
        {
            get
            {
                return _oFrmSLPortIntegral2;
            }
            set
            {
                _oFrmSLPortIntegral2 = value;
            }
        }

        public frmSLPortinTube2 ObjFrmSLPortinTube2
        {
            get
            {
                return _oFrmSLPortinTube2;
            }
            set
            {
                _oFrmSLPortinTube2 = value;
            }
        }

        //================================================================================
        //================================= Clevis Plate =================================

        public frmConPlateClevis ObjFrmConPlateClevis
        {
            get
            {
                return _oFrmConPlateClevis;
            }

            set
            {
                _oFrmConPlateClevis = value;
            }
        }

        //=================================================================================
        //================================ Base Plug ======================================

        public frmBasePlugCastingYes ObjFrmBasePlugCastingYes
        {
            get
            {
                return _oFrmBasePlugCastingYes;
            }
            set
            {
                _oFrmBasePlugCastingYes = value;
            }
        }

        public frmBasePlugPortInTube ObjFrmBasePlugPortInTube
        {
            get
            {
                return _oFrmBasePlugPortInTube;
            }
            set
            {
                _oFrmBasePlugPortInTube = value;
            }
        }

        public frmBasePlugPortIntegral ObjFrmBasePlugPortIntegral
        {
            get
            {
                return _oFrmBasePlugPortIntegral;
            }
            set
            {
                _oFrmBasePlugPortIntegral = value;
            }
        }

        public frmBasePlugCastingYesPortIntegral ObjFrmBasePlugCastingYesPortIntegral
        {
            get
            {
                return _oFrmBasePlugCastingYesPortIntegral;
            }
            set
            {
                _oFrmBasePlugCastingYesPortIntegral = value;
            }
        }

        public frmBasePlugCastingNoPortIntegral ObjFrmBasePlugCastingNoPortIntegral
        {
            get
            {
                return _oFrmBasePlugCastingNoPortIntegral;
            }
            set
            {
                _oFrmBasePlugCastingNoPortIntegral = value;
            }
        }

        public bool NewBasePlugPartCopied
        {
            get
            {
                return _blnNewBasePlugPartCopied;
            }
            set
            {
                _blnNewBasePlugPartCopied = value;
            }
        }

        //=======================================================================================================
        //============================================ Cross Tube ===============================================


        public frmCTPortInTube ObjFrmCTPortInTube
        {
            get
            {
                return _oFrmCTPortInTube;
            }
            set
            {
                _oFrmCTPortInTube = value;
            }
        }

        public frmCTPortIntegral ObjFrmCTPortIntegral
        {
            get
            {
                return _oFrmCTPortIntegral;
            }
            set
            {
                _oFrmCTPortIntegral = value;
            }
        }

        public frmCTFabrication ObjFrmCTFabrication
        {
            get
            {
                return _oFrmCTFabrication;
            }
            set
            {
                _oFrmCTFabrication = value;
            }
        }

        public frmCTDesignACasting ObjFrmCTDesignACasting
        {
            get
            {
                return _oFrmCTDesignACasting;
            }
            set
            {
                _oFrmCTDesignACasting = value;
            }
        }

        public frmCTCastingYes ObjFrmCTCastingYes
        {
            get
            {
                return _oFrmCTCastingYes;
            }
            set
            {
                _oFrmCTCastingYes = value;
            }
        }

        public frmCTCastingNo_PortInTube ObjFrmCTCastingNo_PortInTube
        {
            get
            {
                return _oFrmCTCastingNo_PortInTube;
            }
            set
            {
                _oFrmCTCastingNo_PortInTube = value;
            }
        }

        public frmCTCastingNo_PortIntegral ObjFrmCTCastingNo_PortIntegral
        {
            get
            {
                return _oFrmCTCastingNo_PortIntegral;
            }
            set
            {
                _oFrmCTCastingNo_PortIntegral = value;
            }
        }

        public frmCTPortInTube2 ObjFrmCTPortInTube2
        {
            get
            {
                return _oFrmCTPortInTube2;
            }
            set
            {
                _oFrmCTPortInTube2 = value;
            }
        }

        public frmCTPortIntegral2 ObjFrmCTPortIntegral2
        {
            get
            {
                return _oFrmCTPortIntegral2;
            }
            set
            {
                _oFrmCTPortIntegral2 = value;
            }
        }

        public frmCTFabrication2 ObjFrmCTFabrication2
        {
            get
            {
                return _oFrmCTFabrication2;
            }
            set
            {
                _oFrmCTFabrication2 = value;
            }
        }

        public frmCTDesignACasting2 ObjFrmCTDesignACasting2
        {
            get
            {
                return _oFrmCTDesignACasting2;
            }
            set
            {
                _oFrmCTDesignACasting2 = value;
            }
        }

        public frmCTCastingYes2 ObjFrmCTCastingYes2
        {
            get
            {
                return _oFrmCTCastingYes2;
            }
            set
            {
                _oFrmCTCastingYes2 = value;
            }
        }

        public frmCTCastingNo_PortInTube2 ObjFrmCTCastingNo_PortInTube2
        {
            get
            {
                return _oFrmCTCastingNo_PortInTube2;
            }
            set
            {
                _oFrmCTCastingNo_PortInTube2 = value;
            }
        }

        public frmCTCastingNo_PortIntegral2 ObjFrmCTCastingNo_PortIntegral2
        {
            get
            {
                return _oFrmCTCastingNo_PortIntegral2;
            }
            set
            {
                _oFrmCTCastingNo_PortIntegral2 = value;
            }
        }

        //================================================================================================

        //============================================ Rod End Single Lug ================================

        public frmRESingleLugDetails ObjFrmRESLDetails
        {
            get
            {
                return _oFrmRESingleLugDetails;
            }
            set
            {
                _oFrmRESingleLugDetails = value;
            }
        }

        public frmRESingleLugExistingNotSelected ObjFrmRESingleLugExistingNotSelected
        {
            get
            {
                return _oFrmRESingleLugExistingNotSelected;
            }
            set
            {
                _oFrmRESingleLugExistingNotSelected = value;
            }
        }

        //=====================================================================================================

        //======================================== Rod End BH =================================================

        public frmREBHDetails ObjFrmREBHDetails
        {
            get
            {
                return _oFrmREBHDetails;
            }

            set
            {
                _oFrmREBHDetails = value;
            }
        }


        public frmREBHExistingNotSelected ObjFrmREBHExistingNotSelected
        {
            get
            {
                return _oFrmREBHExistingNotSelected;
            }

            set
            {
                _oFrmREBHExistingNotSelected = value;
            }
        }

        //======================================================================================================

        //======================================= Rod End Flat With Chamfer ====================================

        public frmFlatWithChamfer ObjFrmFlatWithChamper
        {
            get
            {
                return _oFrmFlatWithChamfer;
            }

            set
            {
                _oFrmFlatWithChamfer = value;
            }
        }

        //======================================================================================================

        //======================================= Drilled Pin Hole Rod End ====================================

        public frmREDrilledPinHole ObjFrmREDrilledPinHole
        {
            get
            {
                return _oFrmREDrilledPinHole;
            }
            set
            {
                _oFrmREDrilledPinHole = value;

            }
        }

        //======================================================================================================

        //======================================= Threaded Rod_Rod End =========================================

        public frmREThreadedRod ObjFrmREThreadedRod
        {
            get
            {
                return _oFrmREThreadedRod;
            }
            set
            {
                _oFrmREThreadedRod = value;
            }
        }

        public frmRetractedLengthValidation ObjFrmRetractedLengthValidation
        {
            get
            {
                return _oFrmRetractedLengthValidation;
            }
            set
            {
                _oFrmRetractedLengthValidation = value;
            }
        }

        //======================================================================================================

        //======================================= Cross Tube_Rod End =========================================

        public frmRECrossTube ObjFrmRECrossTube
        {
            get
            {
                return _oFrmRECrossTube;
            }
            set
            {
                _oFrmRECrossTube = value;
            }
        }

        public frmCastingYes_RECT ObjFrmCastingYes_RECT
        {
            get
            {
                return _oFrmCastingYes_RECT;
            }
            set
            {
                _oFrmCastingYes_RECT = value;
            }
        }

        public frmCastingNo_RECT ObjFrmCastingNo_RECT
        {
            get
            {
                return _oFrmCastingNo_RECT;
            }
            set
            {
                _oFrmCastingNo_RECT = value;
            }
        }

        public frmDesignACasting_RECT ObjFrmDesignACasting_RECT
        {
            get
            {
                return _oFrmDesignACasting_RECT;
            }
            set
            {
                _oFrmDesignACasting_RECT = value;
            }
        }

        public frmFabrication_RECT ObjFrmFabrication_RECT
        {
            get
            {
                return _oFrmFabrication_RECT;
            }
            set
            {
                _oFrmFabrication_RECT = value;
            }
        }

        //==================================================================================================

        public frmGenerate ObjFrmGenerate
        {
            get
            {
                return _oFrmGenerate;
            }
            set
            {
                _oFrmGenerate = value;
            }
        }


        //======================================================================================================

        //=================================== Contract Details =================================================

        public frmContractDetails ObjFrmContractDetails
        {
            get
            {
                return _oFrmContractDetails;
            }
            set
            {
                _oFrmContractDetails = value;
            }
        }

        public frmMonarchRevision ObjFrmMonarchRevision
        {
            get
            {
                return _oFrmMonarchRevision;
            }

            set
            {
                _oFrmMonarchRevision = value;
            }
        }

        #region REDoubleLug

        public frmREDLCasting ObjFrmREDLCasting
        {
            get
            {
                return _oFrmREDLCasting;
            }
            set
            {
                _oFrmREDLCasting = value;
            }
        }

        public frmREDLThreaded ObjFrmREDLThreaded
        {
            get
            {
                return _oFrmREDLThreaded;
            }
            set
            {
                _oFrmREDLThreaded = value;
            }
        }

        public frmREDLWelded ObjFrmREDLWelded
        {
            get
            {
                return _oFrmREDLWelded;
            }
            set
            {
                _oFrmREDLWelded = value;
            }
        }

        #endregion

        #region Imports Forms

        public frmImportBaseEnd ObjFrmImportBaseEnd
        {
            get
            {
                return _oFrmImportBaseEnd;
            }
            set
            {
                _oFrmImportBaseEnd = value;
            }
        }


        public frmImportRodEnd ObjFrmImportRodEnd
        {
            get
            {
                return _oFrmImportRodEnd;
            }
            set
            {
                _oFrmImportRodEnd = value;
            }
        }

        #endregion

        #endregion

        #region General Properties

        public Hashtable RodSequence_Details
        {
            get
            {
                RodSequence_Details = new Hashtable();
                RodSequence_Details.Add("WC093", 10);
                RodSequence_Details.Add("WC122", 20);
                RodSequence_Details.Add("WC123", 20);
                RodSequence_Details.Add("WC553", 40);
                RodSequence_Details.Add("WC550", 40);
                RodSequence_Details.Add("WC550_1", 41);
                RodSequence_Details.Add("WC199", 42);
            }
        }

        public Hashtable TubeSequence_Details = new Hashtable();


        public bool ShowCasting_Thru_ExistingRESL
        {
            get
            {
                return _blnShowCasting_Thru_ExistingRESL;
            }
            set
            {
                _blnShowCasting_Thru_ExistingRESL = value;
            }
        }

        public bool ShowCasting_Thru_ExistingREBH
        {
            get
            {
                return _blnShowCasting_Thru_ExistingREBH;
            }
            set
            {
                _blnShowCasting_Thru_ExistingREBH = value;
            }
        }

        public bool GenerateULug
        {
            get
            {
                return _blnGenerateULug;
            }
            set
            {
                _blnGenerateULug = value;
            }
        }

        public bool GenerateCasting
        {
            get
            {
                return _blnGenerateCasting;
            }
            set
            {
                _blnGenerateCasting = value;
            }
        }

        public double BendRadius
        {
            get
            {
                return _dblBendRadius;
            }
            set
            {
                _dblBendRadius = value;
            }
        }

        public double TopRadius
        {
            get
            {
                return _dblTopRadius;
            }
            set
            {
                _dblTopRadius = value;
            }
        }

        public bool NewUlugPartCopied
        {
            get
            {
                return _blnNewUlugPartCopied;
            }
            set
            {
                _blnNewUlugPartCopied = value;
            }
        }

        public bool NewSLCastingPartCopied
        {
            get
            {
                return _blnNewSLCastingPartCopied;
            }
            set
            {
                _blnNewSLCastingPartCopied = value;
            }
        }

        public bool NewCastingPartCopied
        {
            get
            {
                return _blnNewCastingPartCopied;
            }
            set
            {
                _blnNewCastingPartCopied = value;
            }
        }

        public string IsPortIntegral_or_PortInTube
        {
            get
            {
                return _strIsPortIntegral_or_PortInTube;
            }
            set
            {
                _strIsPortIntegral_or_PortInTube = value;
            }
        }

        public bool ShowPortInTube_Thru_PortIntegral
        {
            get
            {
                return _blnShowPortInTube_Thru_PortIntegral;
            }
            set
            {
                _blnShowPortInTube_Thru_PortIntegral = value;
            }
        }

        public bool ShowCastingNo_Thru_CastingYes
        {
            get
            {
                return _blnShowCastingNo_Thru_CastingYes;
            }
            set
            {
                _blnShowCastingNo_Thru_CastingYes = value;
            }
        }

        public bool ShowCastingNo_Thru_CastingYes_RodEnd
        {
            get
            {
                return _blnShowCastingNo_Thru_CastingYes_RodEnd;
            }
            set
            {
                _blnShowCastingNo_Thru_CastingYes_RodEnd = value;
            }
        }

        public ArrayList FormNavigationOrder
        {
            get
            {
                FormNavigationOrder = new ArrayList();
                if ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision == "New"))
                {
                    FormNavigationOrder.Add(new object[4] { "frmContractDetails", _oFrmContractDetails, null, _oFrmPrimaryInputs });
                    //  current, previous , next
                    FormNavigationOrder.Add(new object[4] { "frmPrimaryInputs", _oFrmPrimaryInputs, _oFrmContractDetails, _oFrmPistonDesign });
                }
                else
                {
                    FormNavigationOrder.Add(new object[4] { "frmMonarchRevision", _oFrmMonarchRevision, null, _oFrmPrimaryInputs });

                    FormNavigationOrder.Add(new object[4] { "frmPrimaryInputs", _oFrmPrimaryInputs, _oFrmMonarchRevision, _oFrmPistonDesign });
                }
                FormNavigationOrder.Add(new object[4] { "frmPistonDesign", _oFrmPistonDesign, _oFrmPrimaryInputs, _oFrmHeadDesign });

                FormNavigationOrder.Add(new object[4] { "frmHeadDesign", _oFrmHeadDesign, _oFrmPistonDesign, _oFrmTubeDetails });

                FormNavigationOrder.Add(new object[4] { "frmTubeDetails", _oFrmTubeDetails, _oFrmHeadDesign, _oFrmPortDetails });



                //===============================================================================================================================
                //============================================== Double Lug =====================================================================

                if ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration == "Double Lug"))
                {


                    if (_strIsPortIntegral_or_PortInTube == "Port Integral")
                    {
                        FormNavigationOrder.Add(new object[4] { "frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmDLPortIntegral });
                        if (PortIntegral_ExistingDetailsFound)
                        {
                            if (ShowCastingNo_Thru_CastingYes)
                            {
                                if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.chkDoubleLugFabricationRequired.Checked == true))
                                {
                                    FormNavigationOrder.Add(new object[4] { "frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmDLCastingNo_PortIntegral });
                                    FormNavigationOrder.Add(new object[4] { "frmDLCastingNo_PortIntegral", _oFrmDLCastingNo_PortIntegral, _oFrmDLPortIntegral, _oFrmDLCastingNo_PortIntegral2 });
                                    FormNavigationOrder.Add(new object[4] { "frmDLCastingNo_PortIntegral2", _oFrmDLCastingNo_PortIntegral2, _oFrmDLCastingNo_PortIntegral, _oFrmRodEndConfiguration });
                                    RodEndNavigationOrder(_oFrmDLCastingNo_PortIntegral2, FormNavigationOrder);

                                }
                                else
                                {
                                    FormNavigationOrder.Add(new object[4] { "frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmDLCastingNo_PortIntegral });
                                    FormNavigationOrder.Add(new object[4] { "frmDLCastingNo_PortIntegral", _oFrmDLCastingNo_PortIntegral, _oFrmDLPortIntegral, _oFrmRodEndConfiguration });
                                    RodEndNavigationOrder(_oFrmDLCastingNo_PortIntegral, FormNavigationOrder);
                                }
                            }
                        }
                        else if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingYes.chkDoubleLugFabricationRequired.Checked == true) || (ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingYes.rdbNewCasting.Checked == true))
                        {
                            FormNavigationOrder.Add(new object[4] { "frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmDLCastingNo_PortIntegral2 });
                            FormNavigationOrder.Add(new object[4] { "frmDLCastingNo_PortIntegral2", _oFrmDLCastingNo_PortIntegral2, _oFrmDLPortIntegral, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmDLCastingNo_PortIntegral2, FormNavigationOrder);
                        }
                        else
                        {
                            FormNavigationOrder.Add(new object[4] { "frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmDLPortIntegral, FormNavigationOrder);
                        }
                    }
                    else if (ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.chkDoubleLugFabricationRequired.Checked == true)
                    {
                        FormNavigationOrder.Add(new object[4] { "frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmDLPortIntegral2 });
                        FormNavigationOrder.Add(new object[4] { "frmDLPortIntegral2", _oFrmDLPortIntegral2, _oFrmDLPortIntegral, _oFrmRodEndConfiguration });
                        RodEndNavigationOrder(_oFrmDLPortIntegral2, FormNavigationOrder);
                    }
                    else
                    {
                        FormNavigationOrder.Add(new object[4] { "frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration });
                        RodEndNavigationOrder(_oFrmDLPortIntegral, FormNavigationOrder);
                    }
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.chkDoubleLugFabricationRequired.Visible = false;

                    if (ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.rdbDesignACasting.Checked == true)
                    {
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.chkDoubleLugFabricationRequired.Visible = true;
                    }
                    else
                    {
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.chkDoubleLugFabricationRequired.Visible = false;
                    }
                }

                else if (_strIsPortIntegral_or_PortInTube == "Port In Tube")
                {
                    FormNavigationOrder.Add(new object[4] { "frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmDLPortInTubeDetails });

                    if (PortIntegral_ExistingDetailsFound)
                    {
                        if (ShowCastingNo_Thru_CastingYes)
                        {
                            if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.chkDoubleLugFabricationRequired.Checked == true))
                            {
                                FormNavigationOrder.Add(new object[4] { "frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmDLCastingNo_PortInTube });
                                FormNavigationOrder.Add(new object[4] { "frmDLCastingNo_PortInTube", _oFrmDLCastingNo_PortInTube, _oFrmDLPortInTubeDetails, _oFrmDLCastingNo_PortInTube2 });
                                FormNavigationOrder.Add(new object[4] { "frmDLCastingNo_PortInTube2", _oFrmDLCastingNo_PortInTube2, _oFrmDLCastingNo_PortInTube, _oFrmRodEndConfiguration });
                                RodEndNavigationOrder(_oFrmDLCastingNo_PortInTube2, FormNavigationOrder);
                                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.rdbFabrication.Checked = true;
                                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.rdbDesignACasting.Enabled = false;
                            }
                            else
                            {
                                FormNavigationOrder.Add(new object[4] { "frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmDLCastingNo_PortInTube });
                                FormNavigationOrder.Add(new object[4] { "frmDLCastingNo_PortInTube", _oFrmDLCastingNo_PortInTube, _oFrmDLPortInTubeDetails, _oFrmRodEndConfiguration });
                                RodEndNavigationOrder(_oFrmDLCastingNo_PortInTube, FormNavigationOrder);
                            }
                        }
                        else if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingYes.chkDoubleLugFabricationRequired.Checked == true)
                                    || (ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingYes.rdbNewCasting.Checked == true))
                        {
                            FormNavigationOrder.Add(new object[4] { "frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmDLCastingNo_PortInTube2 });
                            FormNavigationOrder.Add(new object[4] { "frmDLCastingNo_PortInTube2", _oFrmDLCastingNo_PortInTube2, _oFrmDLPortInTubeDetails, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmDLCastingNo_PortInTube2, FormNavigationOrder);
                            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.rdbFabrication.Checked = true;
                            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.rdbDesignACasting.Enabled = false;
                            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.rdbDesignACasting.Enabled = false; ;
                        }
                        else
                        {
                            FormNavigationOrder.Add(new object[4] { "frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmDLPortInTubeDetails, FormNavigationOrder);
                        }
                    }
                    else if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.chkDoubleLugFabricationRequired.Checked == true))
                    {
                        FormNavigationOrder.Add(new object[4] { "frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmDLPortInTubeDetails2 });
                        FormNavigationOrder.Add(new object[4] { "frmDLPortInTubeDetails2", _oFrmDLPortInTubeDetails2, _oFrmDLPortInTubeDetails, _oFrmRodEndConfiguration });
                        RodEndNavigationOrder(_oFrmDLPortInTubeDetails2, FormNavigationOrder);
                    }
                    else
                    {
                        FormNavigationOrder.Add(new object[4] { "frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmRodEndConfiguration });
                        RodEndNavigationOrder(_oFrmDLPortInTubeDetails, FormNavigationOrder);
                    }
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.chkDoubleLugFabricationRequired.Visible = false;
                    if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbDesignACasting.Checked == true))
                    {
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.chkDoubleLugFabricationRequired.Visible = true;
                    }
                    else
                    {
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.chkDoubleLugFabricationRequired.Visible = false;
                    }
                }



                        //=========================================================== Plate Clevis ============================================================

                else if (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis")
                {
                    FormNavigationOrder.Add(new object[4] { "frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmConPlateClevis });
                    FormNavigationOrder.Add(new object[4] { "frmConPlateClevis", _oFrmConPlateClevis, _oFrmPortDetails, _oFrmRodEndConfiguration });
                    RodEndNavigationOrder(_oFrmConPlateClevis, FormNavigationOrder);
                }

                    //============================================================= BH ====================================================================
                else if (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "BH")
                {
                    if ((_strIsPortIntegral_or_PortInTube == "Port Integral"))
                    {
                        FormNavigationOrder.Add(new object[4] { "frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmBHPortIntegral });

                        if (PortIntegral_ExistingDetailsFound)
                        {
                            if (ShowCastingNo_Thru_CastingYes)
                            {
                                if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortIntegral.chkBHFabricationRequired.Checked == true))
                                {
                                    FormNavigationOrder.Add(new object[4] { "frmBHPortIntegral", _oFrmBHPortIntegral, _oFrmPortDetails, _oFrmBHCastingNo_PortIntegral });
                                    FormNavigationOrder.Add(new object[4] { "frmBHCastingNo_PortIntegral", _oFrmBHCastingNo_PortIntegral, _oFrmBHPortIntegral, _oFrmBHCastingNo_PortIntegral2 });
                                    FormNavigationOrder.Add(new object[4] { "frmBHCastingNo_PortIntegral2", _oFrmBHCastingNo_PortIntegral2, _oFrmBHCastingNo_PortIntegral, _oFrmRodEndConfiguration });
                                    RodEndNavigationOrder(_oFrmBHCastingNo_PortIntegral2, FormNavigationOrder);
                                }
                                else
                                {
                                    FormNavigationOrder.Add(new object[4] { "frmBHPortIntegral", _oFrmBHPortIntegral, _oFrmPortDetails, _oFrmBHCastingNo_PortIntegral });
                                    FormNavigationOrder.Add(new object[4] { "frmBHCastingNo_PortIntegral", _oFrmBHCastingNo_PortIntegral, _oFrmBHPortIntegral, _oFrmRodEndConfiguration });
                                    RodEndNavigationOrder(_oFrmBHCastingNo_PortIntegral, FormNavigationOrder);
                                }
                            }
                            else if (((ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes.chkBHFabricationRequired.Checked == true)
                                                           || (ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes.rdbNewCasting.Checked == true)))
                            {
                                FormNavigationOrder.Add(new object[4] { "frmBHPortIntegral", _oFrmBHPortIntegral, _oFrmPortDetails, _oFrmBHCastingNo_PortIntegral2 });
                                FormNavigationOrder.Add(new object[4] { "frmBHCastingNo_PortIntegral2", _oFrmBHCastingNo_PortIntegral2, _oFrmBHPortIntegral, _oFrmRodEndConfiguration });
                                RodEndNavigationOrder(_oFrmBHCastingNo_PortIntegral2, FormNavigationOrder);
                            }
                            else
                            {
                                FormNavigationOrder.Add(new object[4] { "frmBHPortIntegral", _oFrmBHPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration });
                                RodEndNavigationOrder(_oFrmBHPortIntegral, FormNavigationOrder);
                            }
                        }
                        else if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortIntegral.chkBHFabricationRequired.Checked == true))
                        {
                            FormNavigationOrder.Add(new object[4] { "frmBHPortIntegral", _oFrmBHPortIntegral, _oFrmPortDetails, _oFrmBHPortIntegral2 });
                            FormNavigationOrder.Add(new object[4] { "frmBHPortIntegral2", _oFrmBHPortIntegral2, _oFrmBHPortIntegral, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmBHPortIntegral2, FormNavigationOrder);
                        }
                        else
                        {
                            FormNavigationOrder.Add(new object[4] { "frmBHPortIntegral", _oFrmBHPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmBHPortIntegral, FormNavigationOrder);
                        }

                        ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortIntegral.chkBHFabricationRequired.Visible = false;
                        if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortIntegral.rdbDesignACasting.Checked == true))
                        {
                            ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortIntegral.chkBHFabricationRequired.Visible = true;
                        }
                        else
                        {
                            ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortIntegral.chkBHFabricationRequired.Visible = false;
                        }
                    }
                    else if ((_strIsPortIntegral_or_PortInTube == "Port In Tube"))
                    {
                        FormNavigationOrder.Add(new object[4] { "frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmBHPortinTube });
                    }
                    if (PortIntegral_ExistingDetailsFound)
                    {
                        if (ShowCastingNo_Thru_CastingYes)
                        {
                            if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortInTube.chkBHFabricationRequired.Checked == true))
                            {
                                FormNavigationOrder.Add(new object[4] { "frmBHPortInTube", _oFrmBHPortinTube, _oFrmPortDetails, _oFrmBHCastingNo_PortInTube });
                                FormNavigationOrder.Add(new object[4] { "frmBHCastingNo_PortInTube", _oFrmBHCastingNo_PortInTube, _oFrmBHPortinTube, _oFrmBHCastingNo_PortInTube2 });
                                FormNavigationOrder.Add(new object[4] { "frmBHCastingNo_PortInTube2", _oFrmBHCastingNo_PortInTube2, _oFrmBHCastingNo_PortInTube, _oFrmRodEndConfiguration });
                                RodEndNavigationOrder(_oFrmBHCastingNo_PortInTube2, FormNavigationOrder);
                            }
                            else
                            {
                                FormNavigationOrder.Add(new object[4] { "frmBHPortInTube", _oFrmBHPortinTube, _oFrmPortDetails, _oFrmBHCastingNo_PortInTube });
                                FormNavigationOrder.Add(new object[4] { "frmBHCastingNo_PortInTube", _oFrmBHCastingNo_PortInTube, _oFrmBHPortinTube, _oFrmRodEndConfiguration });
                                RodEndNavigationOrder(_oFrmBHCastingNo_PortInTube, FormNavigationOrder);
                            }
                        }
                        else if (((ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes.chkBHFabricationRequired.Checked == true)
                                    || (ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes.rdbNewCasting.Checked == true)))
                        {
                            FormNavigationOrder.Add(new object[4] { "frmBHPortInTube", _oFrmBHPortinTube, _oFrmPortDetails, _oFrmBHCastingNo_PortInTube2 });
                            FormNavigationOrder.Add(new object[4] { "frmBHCastingNo_PortInTube2", _oFrmBHCastingNo_PortInTube2, _oFrmBHPortinTube, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmBHCastingNo_PortInTube2, FormNavigationOrder);
                        }
                        else
                        {
                            FormNavigationOrder.Add(new object[4] { "frmBHPortInTube", _oFrmBHPortinTube, _oFrmPortDetails, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmBHPortinTube, FormNavigationOrder);
                        }
                    }
                    else if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortInTube.chkBHFabricationRequired.Checked == true))
                    {
                        FormNavigationOrder.Add(new object[4] { "frmBHPortInTube", _oFrmBHPortinTube, _oFrmPortDetails, _oFrmBHPortinTube2 });
                        FormNavigationOrder.Add(new object[4] { "frmBHPortInTube2", _oFrmBHPortinTube2, _oFrmBHPortinTube, _oFrmRodEndConfiguration });
                        RodEndNavigationOrder(_oFrmBHPortinTube2, FormNavigationOrder);
                    }
                    else
                    {
                        FormNavigationOrder.Add(new object[4] { "frmBHPortInTube", _oFrmBHPortinTube, _oFrmPortDetails, _oFrmRodEndConfiguration });
                        RodEndNavigationOrder(_oFrmBHPortinTube, FormNavigationOrder);
                    }

                    ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortInTube.chkBHFabricationRequired.Visible = false;

                    if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortInTube.rdbDesignACasting.Checked == true))
                    {
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortInTube.chkBHFabricationRequired.Visible = true;
                    }
                    else
                    {
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortInTube.chkBHFabricationRequired.Visible = false;
                    }
                }



            //===========================================================================================================================================

            //============================================== Single Lug =================================================================================


                else if (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug")
                {
                    if ((_strIsPortIntegral_or_PortInTube == "Port Integral"))
                    {
                        FormNavigationOrder.Add(new object[4] { "frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmSLPortIntegral });

                        if (PortIntegral_ExistingDetailsFound)
                        {
                            if (ShowCastingNo_Thru_CastingYes)
                            {
                                if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.chkSingleLugFabricationRequired.Checked == true))
                                {
                                    FormNavigationOrder.Add(new object[4] { "frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmSLCastingNo_PortIntegral });
                                    FormNavigationOrder.Add(new object[4] { "frmSLCastingNo_PortIntegral", _oFrmSLCastingNo_PortIntegral, _oFrmSLPortIntegral, _oFrmSLCastingNo_PortIntegral2 });
                                    FormNavigationOrder.Add(new object[4] { "frmSLCastingNo_PortIntegral2", _oFrmSLCastingNo_PortIntegral2, _oFrmSLCastingNo_PortIntegral, _oFrmRodEndConfiguration });
                                    RodEndNavigationOrder(_oFrmSLCastingNo_PortIntegral2, FormNavigationOrder);
                                }
                                else
                                {
                                    FormNavigationOrder.Add(new object[4] { "frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmSLCastingNo_PortIntegral });
                                    FormNavigationOrder.Add(new object[4] { "frmSLCastingNo_PortIntegral", _oFrmSLCastingNo_PortIntegral, _oFrmSLPortIntegral, _oFrmRodEndConfiguration });
                                    RodEndNavigationOrder(_oFrmSLCastingNo_PortIntegral, FormNavigationOrder);
                                }
                            }
                            else
                            {
                                if (((ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingYes.chkSingleLugFabricationRequired.Checked == true)
                                            || (ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingYes.rdbNewCasting.Checked == true)))
                                {
                                    FormNavigationOrder.Add(new object[4] { "frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmSLCastingNo_PortIntegral2 });
                                    FormNavigationOrder.Add(new object[4] { "frmSLCastingNo_PortIntegral2", _oFrmSLCastingNo_PortIntegral2, _oFrmSLPortIntegral, _oFrmRodEndConfiguration });
                                    RodEndNavigationOrder(_oFrmSLCastingNo_PortIntegral2, FormNavigationOrder);
                                }
                                else
                                {
                                    FormNavigationOrder.Add(new object[4] { "frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration });
                                    RodEndNavigationOrder(_oFrmSLPortIntegral, FormNavigationOrder);
                                }
                                FormNavigationOrder.Add(new object[4] { "frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmSLCastingNo_PortIntegral2 });
                                FormNavigationOrder.Add(new object[4] { "frmSLCastingNo_PortIntegral2", _oFrmSLCastingNo_PortIntegral2, _oFrmSLPortIntegral, _oFrmRodEndConfiguration });
                                RodEndNavigationOrder(_oFrmSLCastingNo_PortIntegral2, FormNavigationOrder);
                            }
                        }
                        else if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.chkSingleLugFabricationRequired.Checked == true))
                        {
                            FormNavigationOrder.Add(new object[4] { "frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmSLPortIntegral2 });
                            FormNavigationOrder.Add(new object[4] { "frmSLPortIntegral2", _oFrmSLPortIntegral2, _oFrmSLPortIntegral, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmSLPortIntegral2, FormNavigationOrder);
                        }
                        else
                        {
                            FormNavigationOrder.Add(new object[4] { "frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmSLPortIntegral, FormNavigationOrder);
                        }

                        ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.chkSingleLugFabricationRequired.Visible = false;

                        if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.rdbDesignACasting.Checked == true))
                        {
                            ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.chkSingleLugFabricationRequired.Visible = true;
                        }
                        else
                        {
                            ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.chkSingleLugFabricationRequired.Visible = false;
                        }
                    }
                    else if ((_strIsPortIntegral_or_PortInTube == "Port In Tube"))
                    {
                        FormNavigationOrder.Add(new object[4] { "frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmSLPortinTube });

                        if (PortIntegral_ExistingDetailsFound)
                        {
                            if (ShowCastingNo_Thru_CastingYes)
                            {
                                if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.chkSingleLugFabricationRequired.Checked == true))
                                {
                                    FormNavigationOrder.Add(new object[4] { "frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmSLCastingNo_PortInTube });
                                    FormNavigationOrder.Add(new object[4] { "frmSLCastingNo_PortInTube", _oFrmSLCastingNo_PortInTube, _oFrmSLPortinTube, _oFrmSLCastingNo_PortInTube2 });
                                    FormNavigationOrder.Add(new object[4] { "frmSLCastingNo_PortInTube2", _oFrmSLCastingNo_PortInTube2, _oFrmSLCastingNo_PortInTube, _oFrmRodEndConfiguration });
                                    RodEndNavigationOrder(_oFrmSLCastingNo_PortInTube2, FormNavigationOrder);
                                }
                                else
                                {
                                    FormNavigationOrder.Add(new object[4] { "frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmSLCastingNo_PortInTube });
                                    FormNavigationOrder.Add(new object[4] { "frmSLCastingNo_PortInTube", _oFrmSLCastingNo_PortInTube, _oFrmSLPortinTube, _oFrmRodEndConfiguration });
                                    RodEndNavigationOrder(_oFrmSLCastingNo_PortInTube, FormNavigationOrder);
                                }
                            }
                            else if (((ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingYes.chkSingleLugFabricationRequired.Checked == true)
                                        || (ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingYes.rdbNewCasting.Checked == true)))
                            {
                                FormNavigationOrder.Add(new object[4] { "frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmSLCastingNo_PortInTube2 });
                                FormNavigationOrder.Add(new object[4] { "frmSLCastingNo_PortInTube2", _oFrmSLCastingNo_PortInTube2, _oFrmSLPortinTube, _oFrmRodEndConfiguration });
                                RodEndNavigationOrder(_oFrmSLCastingNo_PortInTube2, FormNavigationOrder);
                            }
                            else
                            {
                                FormNavigationOrder.Add(new object[4] { "frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmRodEndConfiguration });
                                RodEndNavigationOrder(_oFrmSLPortinTube, FormNavigationOrder);
                            }
                        }
                        else if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.chkSingleLugFabricationRequired.Checked == true))
                        {
                            FormNavigationOrder.Add(new object[4] { "frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmSLPortinTube2 });
                            FormNavigationOrder.Add(new object[4] { "frmSLPortinTube2", _oFrmSLPortinTube2, _oFrmSLPortinTube, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmSLPortinTube2, FormNavigationOrder);
                        }
                        else
                        {
                            FormNavigationOrder.Add(new object[4] { "frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmSLPortinTube, FormNavigationOrder);
                        }

                        ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.chkSingleLugFabricationRequired.Visible = false;

                        if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.rdbDesignACasting.Checked == true))
                        {
                            ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.chkSingleLugFabricationRequired.Visible = true;
                        }
                        else
                        {
                            ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.chkSingleLugFabricationRequired.Visible = false;
                        }
                    }
                }

                //==============================================================================================================================

                //=============================================================== Base Plug ====================================================

                else if (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Base Plug")
                {
                    if ((_strIsPortIntegral_or_PortInTube == "Port Integral"))
                    {
                        FormNavigationOrder.Add(new object[4] { "frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmBasePlugPortIntegral });

                        if (PortIntegral_ExistingDetailsFound)
                        {
                            if (ShowCastingNo_Thru_CastingYes)
                            {
                                FormNavigationOrder.Add(new object[4] { "frmBasePlugPortIntegral", _oFrmBasePlugPortIntegral, _oFrmPortDetails, _oFrmBasePlugCastingNoPortIntegral });
                                FormNavigationOrder.Add(new object[4] { "frmBasePlugCastingNoPortIntegral", _oFrmBasePlugCastingNoPortIntegral, _oFrmBasePlugPortIntegral, _oFrmRodEndConfiguration });
                                RodEndNavigationOrder(_oFrmBasePlugCastingNoPortIntegral, FormNavigationOrder);
                            }
                            else
                            {
                                FormNavigationOrder.Add(new object[4] { "frmBasePlugPortIntegral", _oFrmBasePlugPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration });
                                RodEndNavigationOrder(_oFrmBasePlugPortIntegral, FormNavigationOrder);
                            }
                        }
                        else
                        {
                            FormNavigationOrder.Add(new object[4] { "frmBasePlugPortIntegral", _oFrmBasePlugPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmBasePlugPortIntegral, FormNavigationOrder);
                        }
                    }
                    else if ((_strIsPortIntegral_or_PortInTube == "Port In Tube"))
                    {
                        FormNavigationOrder.Add(new object[4] { "frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmBasePlugPortInTube });

                        if (ShowCastingNo_Thru_CastingYes)
                        {
                            FormNavigationOrder.Add(new object[4] { "frmBasePlugPortInTube", _oFrmBasePlugPortInTube, _oFrmPortDetails, _oFrmDesignABasePlug });
                            FormNavigationOrder.Add(new object[4] { "frmDesignABasePlug", _oFrmDesignABasePlug, _oFrmBasePlugPortInTube, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmDesignABasePlug, FormNavigationOrder);
                        }
                        else
                        {
                            FormNavigationOrder.Add(new object[4] { "frmBasePlugPortInTube", _oFrmBasePlugPortInTube, _oFrmPortDetails, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmBasePlugPortInTube, FormNavigationOrder);
                        }
                    }
                }

            //===============================================================================================================================

            //=================================================== Cross Tube =================================================================

                else if (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube")
                {
                    if ((_strIsPortIntegral_or_PortInTube == "Port Integral"))
                    {
                        FormNavigationOrder.Add(new object[4] { "frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmCTPortIntegral });
                        if (PortIntegral_ExistingDetailsFound)
                        {
                            if (ShowCastingNo_Thru_CastingYes)
                            {
                                if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.chkCrossTubeFabricationRequired.Checked == true))
                                {
                                    FormNavigationOrder.Add(new object[4] { "frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmCTCastingNo_PortIntegral });
                                    FormNavigationOrder.Add(new object[4] { "frmCTCastingNo_PortIntegral", _oFrmCTCastingNo_PortIntegral, _oFrmCTPortIntegral, _oFrmCTCastingNo_PortIntegral2 });
                                    FormNavigationOrder.Add(new object[4] { "frmCTCastingNo_PortIntegral2", _oFrmCTCastingNo_PortIntegral2, _oFrmCTCastingNo_PortIntegral, _oFrmRodEndConfiguration });
                                    RodEndNavigationOrder(_oFrmCTCastingNo_PortIntegral2, FormNavigationOrder);
                                }
                                else
                                {
                                    FormNavigationOrder.Add(new object[4] { "frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmCTCastingNo_PortIntegral });
                                    FormNavigationOrder.Add(new object[4] { "frmCTCastingNo_PortIntegral", _oFrmCTCastingNo_PortIntegral, _oFrmCTPortIntegral, _oFrmRodEndConfiguration });
                                    RodEndNavigationOrder(_oFrmCTCastingNo_PortIntegral, FormNavigationOrder);
                                }
                            }
                            else if (((ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes.chkCrossTubeFabricationRequired.Checked == true)
                                        || (ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes.rdbNewCasting.Checked == true)))
                            {
                                FormNavigationOrder.Add(new object[4] { "frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmCTCastingNo_PortIntegral2 });
                                FormNavigationOrder.Add(new object[4] { "frmCTCastingNo_PortIntegral2", _oFrmCTCastingNo_PortIntegral2, _oFrmCTPortIntegral, _oFrmRodEndConfiguration });
                                RodEndNavigationOrder(_oFrmCTCastingNo_PortIntegral2, FormNavigationOrder);
                            }
                            else
                            {
                                FormNavigationOrder.Add(new object[4] { "frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration });
                                RodEndNavigationOrder(_oFrmCTPortIntegral, FormNavigationOrder);
                            }
                        }
                        else if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.chkCrossTubeFabricationRequired.Checked == true))
                        {
                            FormNavigationOrder.Add(new object[4] { "frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmCTPortIntegral2 });
                            FormNavigationOrder.Add(new object[4] { "frmCTPortIntegral2", _oFrmCTPortIntegral2, _oFrmCTPortIntegral, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmCTPortIntegral2, FormNavigationOrder);
                        }
                        else
                        {
                            FormNavigationOrder.Add(new object[4] { "frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmCTPortIntegral, FormNavigationOrder);
                        }
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.chkCrossTubeFabricationRequired.Visible = false;

                        if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.rdbDesignACasting.Checked == true))
                        {
                            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.chkCrossTubeFabricationRequired.Visible = true;
                        }
                        else
                        {
                            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.chkCrossTubeFabricationRequired.Visible = false;
                        }
                    }
                    else if ((_strIsPortIntegral_or_PortInTube == "Port In Tube"))
                    {
                        FormNavigationOrder.Add(new object[4] { "frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmCTPortInTube });
                        if (PortIntegral_ExistingDetailsFound)
                        {
                            if (ShowCastingNo_Thru_CastingYes)
                            {
                                if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.chkCrossTubeFabricationRequired.Checked == true))
                                {
                                    FormNavigationOrder.Add(new object[4] { "frmCTPortInTube", _oFrmCTPortInTube, _oFrmPortDetails, _oFrmCTCastingNo_PortInTube });
                                    FormNavigationOrder.Add(new object[4] { "frmCTCastingNo_PortInTube", _oFrmCTCastingNo_PortInTube, _oFrmCTPortInTube, _oFrmCTCastingNo_PortInTube2 });
                                    FormNavigationOrder.Add(new object[4] { "frmCTCastingNo_PortInTube2", _oFrmCTCastingNo_PortInTube2, _oFrmCTCastingNo_PortInTube, _oFrmRodEndConfiguration });
                                    RodEndNavigationOrder(_oFrmCTCastingNo_PortInTube2, FormNavigationOrder);
                                }
                                else
                                {
                                    FormNavigationOrder.Add(new object[4] { "frmCTPortInTube", _oFrmCTPortInTube, _oFrmPortDetails, _oFrmCTCastingNo_PortInTube });
                                    FormNavigationOrder.Add(new object[4] { "frmCTCastingNo_PortInTube", _oFrmCTCastingNo_PortInTube, _oFrmCTPortInTube, _oFrmRodEndConfiguration });
                                    RodEndNavigationOrder(_oFrmCTCastingNo_PortInTube, FormNavigationOrder);
                                }
                            }
                            else if (((ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes.chkCrossTubeFabricationRequired.Checked == true)
                                        || (ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes.rdbNewCasting.Checked == true)))
                            {
                                FormNavigationOrder.Add(new object[4] { "frmCTPortInTube", _oFrmCTPortInTube, _oFrmPortDetails, _oFrmCTCastingNo_PortInTube2 });
                                FormNavigationOrder.Add(new object[4] { "frmCTCastingNo_PortInTube2", _oFrmCTCastingNo_PortInTube2, _oFrmCTPortInTube, _oFrmRodEndConfiguration });
                                RodEndNavigationOrder(_oFrmCTCastingNo_PortInTube2, FormNavigationOrder);
                            }
                            else
                            {
                                FormNavigationOrder.Add(new object[4] { "frmCTPortInTube", _oFrmCTPortInTube, _oFrmPortDetails, _oFrmRodEndConfiguration });
                                RodEndNavigationOrder(_oFrmCTPortInTube, FormNavigationOrder);
                            }
                        }
                        else if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.chkCrossTubeFabricationRequired.Checked == true))
                        {
                            FormNavigationOrder.Add(new object[4] { "frmCTPortInTube", _oFrmCTPortInTube, _oFrmPortDetails, _oFrmCTPortInTube2 });
                            FormNavigationOrder.Add(new object[4] { "frmCTPortInTube2", _oFrmCTPortInTube2, _oFrmCTPortInTube, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmCTPortInTube2, FormNavigationOrder);
                        }
                        else
                        {
                            FormNavigationOrder.Add(new object[4] { "frmCTPortInTube", _oFrmCTPortInTube, _oFrmPortDetails, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmCTPortInTube, FormNavigationOrder);
                        }

                        ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.chkCrossTubeFabricationRequired.Visible = false;
                        if ((ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.rdbDesignACasting.Checked == true))
                        {
                            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.chkCrossTubeFabricationRequired.Visible = true;
                        }
                        else
                        {
                            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.chkCrossTubeFabricationRequired.Visible = false;
                        }
                    }
                }

    //==========================================================================================================================

    //===================================== Threaded End =======================================================================

                else if (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Threaded End")
                {
                    if ((_strIsPortIntegral_or_PortInTube == "Port Integral"))
                    {
                        FormNavigationOrder.Add(new object[4] { "frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmThreadedEndPortIntegral });
                        if (PortIntegral_ExistingDetailsFound)
                        {
                            if (ShowCastingNo_Thru_CastingYes)
                            {
                                FormNavigationOrder.Add(new object[4] { "frmThreadedEndPortIntegral", _oFrmThreadedEndPortIntegral, _oFrmPortDetails, _oFrmBEThreadedEndCastingNo_PortIntegral });
                                FormNavigationOrder.Add(new object[4] { "frmBEThreadedEndCastingNo_PortIntegral", _oFrmBEThreadedEndCastingNo_PortIntegral, _oFrmThreadedEndPortIntegral, _oFrmRodEndConfiguration });
                                RodEndNavigationOrder(_oFrmBEThreadedEndCastingNo_PortIntegral, FormNavigationOrder);
                            }
                            else
                            {
                                FormNavigationOrder.Add(new object[4] { "frmThreadedEndPortIntegral", _oFrmThreadedEndPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration });
                                RodEndNavigationOrder(_oFrmThreadedEndPortIntegral, FormNavigationOrder);
                            }
                        }
                        else
                        {
                            FormNavigationOrder.Add(new object[4] { "frmThreadedEndPortIntegral", _oFrmThreadedEndPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmThreadedEndPortIntegral, FormNavigationOrder);
                        }
                    }

                    else if ((_strIsPortIntegral_or_PortInTube == "Port In Tube"))
                    {
                        FormNavigationOrder.Add(new object[4] { "frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmThreadedPortInTube });
                        if (ShowCastingNo_Thru_CastingYes)
                        {
                            FormNavigationOrder.Add(new object[4] { "frmThreadedEndPortInTube", _oFrmThreadedPortInTube, _oFrmPortDetails, _oFrmDesignAThreadedCasting });
                            FormNavigationOrder.Add(new object[4] { "frmDesignAThreadedCasting", _oFrmDesignAThreadedCasting, _oFrmThreadedPortInTube, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmDesignAThreadedCasting, FormNavigationOrder);
                        }
                        else
                        {
                            FormNavigationOrder.Add(new object[4] { "frmThreadedEndPortInTube", _oFrmThreadedPortInTube, _oFrmPortDetails, _oFrmRodEndConfiguration });
                            RodEndNavigationOrder(_oFrmThreadedPortInTube, FormNavigationOrder);
                        }
                    }
                }

                else if (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Import")
                {
                    FormNavigationOrder.Add(new object[4] { "frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmImportBaseEnd });
                    FormNavigationOrder.Add(new object[4] { "frmImportBaseEnd", _oFrmImportBaseEnd, _oFrmPortDetails, _oFrmRodEndConfiguration });
                    RodEndNavigationOrder(_oFrmImportBaseEnd, FormNavigationOrder);
                }
                return FormNavigationOrder;
            }


        }

        private void RodEndNavigationOrder(Form oFrmPrevious, ArrayList aNavigationOrder)
      {
          //''*******************Flat With Chamfer***********************************************
           if( ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Flat With Chamfer")
           {
               aNavigationOrder.Add(new object[4] {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmFlatWithChamfer});
            aNavigationOrder.Add(new object[4] {"frmFlatWithChamfer", _oFrmFlatWithChamfer, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation});
            aNavigationOrder.Add(new object[4] {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmFlatWithChamfer, _oFrmPin_Port_PaintAccessories});
if(ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate)
{
     aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmFlatWithChamfer, _oFrmGenerate});
}
else
{
aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate});
}
                aNavigationOrder.Add(new object[4] {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, null});


           }

               //''*******************Drilled Pin Hole***********************************************

           else if(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Drilled Pin Hole")
           {
               aNavigationOrder.Add(new object[4] {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmRetractedLengthValidation});
            aNavigationOrder.Add(new object[4] {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmRodEndConfiguration, _oFrmPin_Port_PaintAccessories});
               if(ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate)
               {
                    aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRodEndConfiguration, _oFrmGenerate});
               }
               else
               {
                    aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate});
               }
               aNavigationOrder.Add(new object[4] {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, null});
           }

          //       ''*******************Threaded Rod***********************************************

           else if(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Threaded Rod")
           {
               aNavigationOrder.Add(new object[4] {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmREThreadedRod});
            aNavigationOrder.Add(new object[4] {"frmREThreadedRod", _oFrmREThreadedRod, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation});
            aNavigationOrder.Add(new object[4] {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREThreadedRod, _oFrmPin_Port_PaintAccessories});

               if(ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate)
               {
                   aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmFlatWithChamfer, _oFrmGenerate});
               }
               else
               {
                   aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate});
               }
                 aNavigationOrder.Add(new object[4] {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, null});
           }


          //''*******************Single Lug***********************************************

           else if(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug")
           {
                aNavigationOrder.Add(new object[4] {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmRESingleLugDetails});
               if(ShowCasting_Thru_ExistingRES)
               {
                   aNavigationOrder.Add(new object[4] {"frmRESingleLugDetails", _oFrmRESingleLugDetails, _oFrmRodEndConfiguration, _oFrmRESingleLugExistingNotSelected});
                aNavigationOrder.Add(new object[4] {"frmRESingleLugExistingNotSelected", _oFrmRESingleLugExistingNotSelected, _oFrmRESingleLugDetails, _oFrmRetractedLengthValidation});
               }
               else
               {
                   aNavigationOrder.Add(new object[4] {"frmRESingleLugDetails", _oFrmRESingleLugDetails, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation});
               }
                aNavigationOrder.Add(new object[4] {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmRESingleLugDetails, _oFrmPin_Port_PaintAccessories});

               if(ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate)
               {
                   aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRESingleLugDetails, _oFrmGenerate});
               }
               else
               {
                   aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate});
               }
               aNavigationOrder.Add(new object[4] {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, null});
           }


          //''***************************************************************************


          //  ''******************* BH ***********************************************
           else if( ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "BH")
           {
            aNavigationOrder.Add(new object[4] {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmREBHDetails});
            if( ShowCasting_Thru_ExistingREBH)
            {
                aNavigationOrder.Add(new object[4] {"frmREBHDetails", _oFrmREBHDetails, _oFrmRodEndConfiguration, _oFrmREBHExistingNotSelected});
                aNavigationOrder.Add(new object[4] {"frmREBHExistingNotSelected", _oFrmREBHExistingNotSelected, _oFrmREBHDetails, _oFrmRetractedLengthValidation});
            }
            else
            {
                aNavigationOrder.Add(new object[4] {"frmREBHDetails", _oFrmREBHDetails, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation});
            }
          
            aNavigationOrder.Add(new object[4] {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREBHDetails, _oFrmPin_Port_PaintAccessories});
            if( ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate)
            {
                aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmREBHDetails, _oFrmGenerate});
            }
            else
            {
                aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate});
            }
            aNavigationOrder.Add(new object[4] {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, null});
           }


          //''***************************************************************************


           // ''*******************Double Lug***********************************************
           else if( ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug")
           {
               if(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Threaded")
               {
                aNavigationOrder.Add(new object[4] {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmREDLThreaded});
                if(ObjClsWeldedCylinderFunctionalClass.ShowWelded_Thru_Threaded_REDL)
                {
                    aNavigationOrder.Add(new object[4] {"frmREDLThreaded", _oFrmREDLThreaded, _oFrmRodEndConfiguration, _oFrmREDLWelded});
                   
                    aNavigationOrder.Add(new object[4] {"frmREDLWelded", _oFrmREDLWelded, _oFrmREDLThreaded, _oFrmRetractedLengthValidation});
                    aNavigationOrder.Add(new object[4] {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREDLThreaded, _oFrmPin_Port_PaintAccessories});
                
                   if(ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate)
                   {
                        aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmREDLThreaded, _oFrmGenerate});
                   }
                   else
                   {
                        aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate});
                   }
                
                    aNavigationOrder.Add(new object[4] {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, null});
                }
                   else
                   {
                    aNavigationOrder.Add(new object[4] {"frmREDLThreaded", _oFrmREDLThreaded, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation});
                    aNavigationOrder.Add(new object[4] { "frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREDLThreaded, _oFrmPin_Port_PaintAccessories });
                    if(ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate)
                    {
                        aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmREDLThreaded, _oFrmGenerate});
                    }
                    else
                    {
                        aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate});
                    }
                  
                    aNavigationOrder.Add(new object[4] {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, null});
                   }
                }


               else if(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Welded")
               {

                   aNavigationOrder.Add(new object[4] {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmREDLWelded});
                if(BlnShowNewDesign_Thru_ExistingDesign_DoubleLug)
                {
                    aNavigationOrder.Add(new object[4] {"frmREDLWelded", _oFrmREDLWelded, _oFrmRodEndConfiguration, _oFrmREDLNewDesign});
                    aNavigationOrder.Add(new object[4] {"frmREDLNewDesign", _oFrmREDLNewDesign, _oFrmREDLWelded, _oFrmRetractedLengthValidation});
                    aNavigationOrder.Add(new object[4] {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREDLNewDesign, _oFrmPin_Port_PaintAccessories});
                    if(ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate)
                    {
                        aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmREDLNewDesign, _oFrmGenerate});
                    }
                    else
                    {
                        aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate});
                    }
                    
                    aNavigationOrder.Add(new object[4] {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, null});
                }
                    else
                    {
                    aNavigationOrder.Add(new object[4] {"frmREDLWelded", _oFrmREDLWelded, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation});
                    aNavigationOrder.Add(new object[4] {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREDLWelded, _oFrmPin_Port_PaintAccessories});
                    if(ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate)
                    {
                        aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmREDLWelded, _oFrmGenerate});
                    }
                        else
                    {
                        aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate});
                    }
                    aNavigationOrder.Add(new object[4] {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, null});
                    }
                aNavigationOrder.Add(new object[4] {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmREDLCasting});
                aNavigationOrder.Add(new object[4] {"frmREDLCasting", _oFrmREDLCasting, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation});
                aNavigationOrder.Add(new object[4] {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREDLCasting, _oFrmPin_Port_PaintAccessories});
                if(ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate)
                {
                    aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmREDLCasting, _oFrmGenerate});
                }
                else
                {
                    aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate});
                }
                
                aNavigationOrder.Add(new object[4] {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, null});
                    }
                }
           
               

          //============================ Cross Tube ===========================================================================
          else if(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube")
           {
            aNavigationOrder.Add(new object[4] {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmRECrossTube});
            if (ShowCastingNo_Thru_CastingYes_RodEnd)
            {
            aNavigationOrder.Add(new object[4] {"frmRECrossTube", _oFrmRECrossTube, _oFrmRodEndConfiguration, _oFrmCastingNo_RECT});
            aNavigationOrder.Add(new object[4] {"frmCastingNo_RECT", _oFrmCastingNo_RECT, _oFrmRECrossTube, _oFrmRetractedLengthValidation});
            aNavigationOrder.Add(new object[4] {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmCastingNo_RECT, _oFrmPin_Port_PaintAccessories});
    if (ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate) 
    {
       aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmCastingNo_RECT, _oFrmGenerate});
    }
    else 
    {
       aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate});
    }
   aNavigationOrder.Add(new object[4] {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, null});
        }
        else 
            {
   aNavigationOrder.Add(new object[4] {"frmRECrossTube", _oFrmRECrossTube, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation});
                aNavigationOrder.Add(new object[4] {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmRECrossTube, _oFrmPin_Port_PaintAccessories});
    if (ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate) 
    {
       aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRECrossTube, _oFrmGenerate});
    }
    else 
    {
        aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate});
    }
    aNavigationOrder.Add(new object[4] {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, null});
    }
  }
          //================================================= Import Special =============================================================
          else if(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Import Special")
           {

aNavigationOrder.Add(new object[4] {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmRetractedLengthValidation});
            aNavigationOrder.Add(new object[4] {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmRodEndConfiguration, _oFrmPin_Port_PaintAccessories});
if (ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate)
{
   aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRodEndConfiguration, _oFrmGenerate});
}
else 
{
   aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate});
}
 aNavigationOrder.Add(new object[4] {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, null});
          }

else if(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Import")
{
aNavigationOrder.Add(new object[4] {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmImportRodEnd});
            aNavigationOrder.Add(new object[4] {"frmImportRodEnd", _oFrmImportRodEnd, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation});
            aNavigationOrder.Add(new object[4] {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmRodEndConfiguration, _oFrmPin_Port_PaintAccessories});
            aNavigationOrder.Add(new object[4] {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate});
            aNavigationOrder.Add(new object[4] {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, null});
}
          }

        public object ObjCurrentForm
        {
            get
            {
                return _oCurrentForm;
            }
            set
            {
                _oCurrentForm = value;
            }
        }

        public Button BackClick
        {
            get
            {
                return _btnBackClick;
            }
            set
            {
                _btnBackClick = value;
            }
        }

        public Button NextClick
        {
            get
            {
                return _btnNextClick;
            }
            set
            {
                _btnNextClick = value;
            }
        }

        public string CurrentWorkingDirectory
        {
            get
            {
                return _strCurrentWorkingDirectory;
            }
            set
            {
                _strCurrentWorkingDirectory = value;
            }
        }

        public string ChildExcelPath
        {
            get
            {
                return _strchildExcelPath;
            }
            set
            {
                _strchildExcelPath = value;
            }
        }

        public Excel.Workbook ExWorkbook
        {
            get
            {
                return _oExWorkbook;
            }
            set
            {
                _oExWorkbook = value;
            }
        }

        public Excel.Application ExApplication
        {
            get
            {
                return _oExApplication;
            }
            set
            {
                _oExApplication = value;
            }
        }

        public ListView GeneralInformationListview
        {
            get
            {
                return _lvwGeneralInformation;
            }
            set
            {
                _lvwGeneralInformation = value;
            }
        }

        public ArrayList GeneralInformation
        {
            get
            {
                _aGeneralInformation = new ArrayList();
                _aGeneralInformation.Add(new Object[1] { "Working Pressure", "" });
                _aGeneralInformation.Add(new Object[1] { "Column Load Derate Pressure", "" });
                _aGeneralInformation.Add(new Object[1] { "Bore Diameter", "" });
                _aGeneralInformation.Add(new Object[1] { "Rod Diameter", "" });
                _aGeneralInformation.Add(new Object[1] { "Piston Nut Size", "" });
                _aGeneralInformation.Add(new Object[1] { "Rod Material Code", "" });
                _aGeneralInformation.Add(new Object[1] { "Piston Nut Code", "" });
                _aGeneralInformation.Add(new Object[1] { "Piston Nut Max Thickness", "" });
                _aGeneralInformation.Add(new Object[1] { "Stop Tube Length", "" });
                _aGeneralInformation.Add(new Object[1] { "Stop Tube Code", "" });

                _aGeneralInformation.Add(new Object[1] { "Piston Code", "" });
                _aGeneralInformation.Add(new Object[1] { "Piston Seal Code", "" });
                _aGeneralInformation.Add(new Object[1] { "Piston WareRing Code", "" });
                _aGeneralInformation.Add(new Object[1] { "Piston Seal", "" });
                _aGeneralInformation.Add(new Object[1] { "Piston Width", "" });
                _aGeneralInformation.Add(new Object[1] { "CounterBoreDepth", "" });
                _aGeneralInformation.Add(new Object[1] { "Min Distance from RodSide to Seal Groove Start", "" });
                _aGeneralInformation.Add(new Object[1] { "Max Distance from RodSide to Seal Groove End", "" });
                _aGeneralInformation.Add(new Object[1] { "Head Type", "" });
                _aGeneralInformation.Add(new Object[1] { "Rod Seal", "" });

                _aGeneralInformation.Add(new Object[1] { "Cylinder Head Code", "" });
                _aGeneralInformation.Add(new Object[1] { "Tube Code", "" });
                _aGeneralInformation.Add(new Object[1] { "Tube Wall Thickness", "" });
                _aGeneralInformation.Add(new Object[1] { "Tube Material", "" });
                _aGeneralInformation.Add(new Object[1] { "TubeOD", "" });

                _aGeneralInformation.Add(new Object[1] { "BaseEnd Port Code", "" });
                _aGeneralInformation.Add(new Object[1] { "RodEnd Port Code", "" });
                _aGeneralInformation.Add(new Object[1] { "BaseEnd PortLocator Code", "" });
                _aGeneralInformation.Add(new Object[1] { "RodEnd PortLocator Code", "" });

                _aGeneralInformation.Add(new Object[1] { "DoubleLug without Port Code", "" });
                _aGeneralInformation.Add(new Object[1] { "ClevisPlate Code", "" });
                _aGeneralInformation.Add(new Object[1] { "ULug Code", "" });
                _aGeneralInformation.Add(new Object[1] { "SingleLug without Port Code", "" });
                _aGeneralInformation.Add(new Object[1] { "SingleLug Code", "" });
                _aGeneralInformation.Add(new Object[1] { "CrossTube without Port Code", "" });
                _aGeneralInformation.Add(new Object[1] { "CrossTube Code", "" });
                _aGeneralInformation.Add(new Object[1] { "ThreadedEnd without Port Code", "" });
                _aGeneralInformation.Add(new Object[1] { "ULug Lathe Code", "" });
                return _aGeneralInformation;
            }
            set
            {
                _aGeneralInformation = value;
            }
        }

        public RichTextBox MessagesRichTextBox
        {
            get
            {
                return _rtxtMessages;
            }
            set
            {
                _rtxtMessages = value;
            }
        }

        public ArrayList NutSizesInFractions
        {
            get
            {
                NutSizesInFractions = new ArrayList();

                NutSizesInFractions.Add(new Object[1] { "3 / 8", 0.375 });
                NutSizesInFractions.Add(new Object[1] { "1 / 2", 0.5 });
                NutSizesInFractions.Add(new Object[1] { "5 / 8", 0.625 });
                NutSizesInFractions.Add(new Object[1] { "3 / 4", 0.75 });
                NutSizesInFractions.Add(new Object[1] { "7 / 8", 0.875 });
                NutSizesInFractions.Add(new Object[1] { "1", 1 });
                NutSizesInFractions.Add(new Object[1] { "1 1/8", 1.125 });
                NutSizesInFractions.Add(new Object[1] { "1 1/4", 1.25 });
                NutSizesInFractions.Add(new Object[1] { "1 1/2", 1.5 });
                NutSizesInFractions.Add(new Object[1] { "1 3/4", 1.75 });
                return NutSizesInFractions;
            }
        }

        public ArrayList StandardPinHoleSizes
        {
            get
            {
                StandardPinHoleSizes = new ArrayList();
                StandardPinHoleSizes.Add(new Object[1] { 0.5, 0.5 });
                StandardPinHoleSizes.Add(new Object[1] { 0.75, 0.765 });
                StandardPinHoleSizes.Add(new Object[1] { 1, 1.015 });
                StandardPinHoleSizes.Add(new Object[1] { 1.13, 1.14 });
                StandardPinHoleSizes.Add(new Object[1] { 1.25, 1.265 });
                StandardPinHoleSizes.Add(new Object[1] { 1.38, 1.39 });
                StandardPinHoleSizes.Add(new Object[1] { 1.5, 1.515 });
                StandardPinHoleSizes.Add(new Object[1] { 1.63, 1.64 });
                StandardPinHoleSizes.Add(new Object[1] { 1.75, 1.765 });
                StandardPinHoleSizes.Add(new Object[1] { 2, 2.015 });
                return StandardPinHoleSizes;
            }
        }

        public RadioButton RdbFabrication
        {
            get
            {
                return _rdbFabrication;
            }
            set
            {
                _rdbFabrication = value;
            }
        }

        public RadioButton RdbDesignANewCasting
        {
            get
            {
                return _rdbDesignANewCasting;
            }
            set
            {
                _rdbDesignANewCasting = value;
            }
        }

        public ArrayList EmptyControlData
        {
            get
            {
                return _aEmptyControlData;
            }
            set
            {
                _aEmptyControlData = value;
            }
        }

        public bool ShowWelded_Thru_Threaded_REDL
        {
            get
            {
                return _blnShowWelded_Thru_Threaded_REDL;
            }
            set
            {
                _blnShowWelded_Thru_Threaded_REDL = value;
            }
        }

        public bool ShowCasting_Thru_Welded_REDL
        {
            get
            {
                return _blnShowCasting_Thru_Welded_REDL;
            }
            set
            {
                _blnShowCasting_Thru_Welded_REDL = value;
            }
        }

        public int PinHoleSize_Source
        {
            get
            {
                return _intPinHoleSize_Source;
            }
            set
            {
                _intPinHoleSize_Source = value;
            }
        }

        public int PinHoleSize_source_RodEnd
        {
            get
            {
                return _intPinHoleSize_source_RodEnd;
            }
            set
            {
                _intPinHoleSize_source_RodEnd = value;
            }
        }

        public string IsExact_NewDesign_Resize
        {
            get
            {
                return _strIsExact_NewDesign_Resize;
            }
            set
            {
                _strIsExact_NewDesign_Resize = value;
            }
        }

        public string IsExact_NewDesign_Resize2
        {
            get
            {
                return _strIsExact_NewDesign_Resize2;
            }
            set
            {
                _strIsExact_NewDesign_Resize2 = value;
            }
        }

        public string IsExact_NewDesign_Resize_RodEnd
        {
            get
            {
                return _strIsExact_NewDesign_Resize_RodEnd;
            }
            set
            {
                _strIsExact_NewDesign_Resize_RodEnd = value;
            }
        }

        public string IsExact_NewDesign_Resize_RodEnd2
        {
            get
            {
                return _strIsExact_NewDesign_Resize_RodEnd2;
            }
            set
            {
                _strIsExact_NewDesign_Resize_RodEnd2 = value;
            }
        }

        public string FacricatedPart
        {
            get
            {
                return _strFacricatedPart;
            }
            set
            {
                _strFacricatedPart = value;
            }
        }

        public string FacricatedPart2
        {
            get
            {
                return _strFacricatedPart2;
            }
            set
            {
                _strFacricatedPart2 = value;
            }
        }

        public bool RetractedLengthChangedFromRetractedValidationScreen
        {
            get
            {
                return _blnRetractedLengthChangedFromRetractedValidationScreen;
            }
            set
            {
                _blnRetractedLengthChangedFromRetractedValidationScreen = value;
            }
        }

        public bool CompressCylinderChecked
        {
            get
            {
                return _blnCompressCylinderChecked;
            }
            set
            {
                _blnCompressCylinderChecked = value;
            }
        }

        public Panel ObjPnlChildFormArea
        {
            get
            {
                return _oPnlChildFormArea;
            }
            set
            {
                _oPnlChildFormArea = value;
            }
        }

        public PictureBox MdiPictureBox
        {
            get
            {
                return _oMdiPictureBox;
            }
            set
            {
                _oMdiPictureBox = value;
            }
        }

        public object CurrentForm_Object
        {
            get
            {
                return _oCurrentForm_Object;
            }
            set
            {
                _oCurrentForm_Object = value;
            }
        }

        public bool IsWeldSizeLess
        {
            get
            {
                return _oIsWeldSizeLess;
            }
            set
            {
                _oIsWeldSizeLess = value;
            }
        }

        public bool PortIntegral_ExistingDetailsFound
        {
            get
            {
                return _blnPortIntegral_ExistingDetailsFound;
            }
            set
            {
                _blnPortIntegral_ExistingDetailsFound = value;
            }
        }

        public bool IsCounterBoreOrNot
        {
            get
            {
                return _blnIsCounterBoreOrNot;
            }
            set
            {
                _blnIsCounterBoreOrNot = value;
            }
        }

        public bool IsPackPinsAndClipsInPlasticBagChecked
        {
            get
            {
                return _blnIsPackPinsAndClipsInPlasticBagChecked;
            }
            set
            {
                _blnIsPackPinsAndClipsInPlasticBagChecked = value;
            }
        }

        public Hashtable PinHoleSizes_DefaultSettings
        {
            get
            {
                htPinHoleSizes_DefaultSettings = new Hashtable();
                htPinHoleSizes_DefaultSettings.Add(1.0, "0.500");
                htPinHoleSizes_DefaultSettings.Add(1.25, "0.500");
                htPinHoleSizes_DefaultSettings.Add(1.5, "0.750");
                htPinHoleSizes_DefaultSettings.Add(1.75, "0.750");
                htPinHoleSizes_DefaultSettings.Add(2.0, "1.000");
                htPinHoleSizes_DefaultSettings.Add(2.25, "1.000");
                htPinHoleSizes_DefaultSettings.Add(2.5, "1.000");
                htPinHoleSizes_DefaultSettings.Add(2.75, "1.000");
                htPinHoleSizes_DefaultSettings.Add(3.0, "1.000");
                htPinHoleSizes_DefaultSettings.Add(3.25, "1.000");
                htPinHoleSizes_DefaultSettings.Add(3.5, "1.000");
                htPinHoleSizes_DefaultSettings.Add(3.75, "1.000");
                htPinHoleSizes_DefaultSettings.Add(4.0, "1.000");
                htPinHoleSizes_DefaultSettings.Add(4.5, "1.250");
                htPinHoleSizes_DefaultSettings.Add(5.0, "1.250");
                htPinHoleSizes_DefaultSettings.Add(5.5, "1.500");
                htPinHoleSizes_DefaultSettings.Add(6.0, "1.500");
                return htPinHoleSizes_DefaultSettings;
            }
        }

        public bool IsPort_BaseEndOrRodEnd
        {
            get
            {
                return _blnIsPort_BaseEndOrRodEnd;
            }
            set
            {
                _blnIsPort_BaseEndOrRodEnd = value;
            }
        }

        public bool IsImportPortsButtonClicked
        {
            get
            {
                return _blnIsImportPortsButtonClicked;
            }
            set
            {
                _blnIsImportPortsButtonClicked = value;
            }
        }

        public bool IsBaseEndPortImported
        {
            get
            {
                return _blnIsBaseEndPortImported;
            }
            set
            {
                _blnIsBaseEndPortImported = value;
            }
        }

        public bool IsRodEndPortImported
        {
            get
            {
                return _blnIsRodEndPortImported;
            }
            set
            {
                _blnIsRodEndPortImported = value;
            }
        }

        public bool IsBaseEndPartImported
        {
            get
            {
                return _blnIsBaseEndPartImported;
            }
            set
            {
                _blnIsBaseEndPartImported = value;
            }
        }

        public bool IsRodEndPartImported
        {
            get
            {
                return _blnIsRodEndPartImported;
            }
            set
            {
                _blnIsRodEndPartImported = value;
            }
        }

        public bool IsPlateClevisImported
        {
            get
            {
                return _blnIsPlateClevisImported;
            }
            set
            {
                _blnIsPlateClevisImported = value;
            }
        }

        public bool IsValueChanged_Revision
        {
            get
            {
                return _blnIsValueChanged_Revision;
            }
            set
            {
                _blnIsValueChanged_Revision = value;
            }
        }

        public bool IsReleaseCylinderChecked
        {
            get
            {
                return _blnIsReleaseCylinderChecked;
            }
            set
            {
                _blnIsReleaseCylinderChecked = value;
            }
        }

        public string IsNew_Revision_Released
        {
            get
            {
                return _strIsNew_Revision_Released;
            }
            set
            {
                _strIsNew_Revision_Released = value;
            }
        }

        public bool IsExistingButNotReleased_TubeWeldment
        {
            get
            {
                return _blnIsExistingButNotReleased_TubeWeldment;
            }
            set
            {
                _blnIsExistingButNotReleased_TubeWeldment = value;
            }
        }

        public bool IsExistingButNotReleased_RodWeldment
        {
            get
            {
                return _blnIsExistingButNotReleased_RodWeldment;
            }
            set
            {
                _blnIsExistingButNotReleased_RodWeldment = value;
            }
        }

        public bool IsExistingButNotReleased_Lug_BE
        {
            get
            {
                return _blnIsExistingButNotReleased_Lug_BE;
            }
            set
            {
                _blnIsExistingButNotReleased_Lug_BE = value;
            }
        }

        public bool IsExistingButNotReleased_Lug_RE
        {
            get
            {
                return _blnIsExistingButNotReleased_Lug_RE;
            }
            set
            {
                _blnIsExistingButNotReleased_Lug_RE = value;
            }
        }

        public bool IsExistingButNotReleased_CylinderHead
        {
            get
            {
                return _blnIsExistingButNotReleased_CylinderHead;
            }
            set
            {
                _blnIsExistingButNotReleased_CylinderHead = value;
            }
        }

        public bool IsExistingButNotReleased_Piston
        {
            get
            {
                return _blnIsExistingButNotReleased_Piston;
            }
            set
            {
                _blnIsExistingButNotReleased_Piston = value;
            }
        }

        public bool IsExistingButNotReleased_CrossTube_BE
        {
            get
            {
                return _blnIsExistingButNotReleased_CrossTube_BE;
            }
            set
            {
                _blnIsExistingButNotReleased_CrossTube_BE = value;
            }
        }

        public bool IsExistingButNotReleased_CrossTube_RE
        {
            get
            {
                return _blnIsExistingButNotReleased_CrossTube_RE;
            }
            set
            {
                _blnIsExistingButNotReleased_CrossTube_RE = value;
            }
        }

        public bool IsExistingButNotReleased_Casting_BE
        {
            get
            {
                return _blnIsExistingButNotReleased_Casting_BE;
            }
            set
            {
                _blnIsExistingButNotReleased_Casting_BE = value;
            }
        }

        public bool IsExistingButNotReleased_Casting_RE
        {
            get
            {
                return _blnIsExistingButNotReleased_Casting_RE;
            }
            set
            {
                _blnIsExistingButNotReleased_Casting_RE = value;
            }
        }

        public bool IsExistingButNotReleased_StopTube
        {
            get
            {
                return _blnIsExistingButNotReleased_StopTube;
            }
            set
            {
                _blnIsExistingButNotReleased_StopTube = value;
            }
        }

        #region TextBox Objects

        public TextBox TxtLugThickness_BaseEnd
        {
            get
            {
                return _oTxtLugThickness_BaseEnd;
            }
            set
            {
                _oTxtLugThickness_BaseEnd = value;
            }
        }

        public TextBox TxtCrossTubeWidth_BaseEnd
        {
            get
            {
                return _oTxtCrossTubeWidth_BaseEnd;
            }
            set
            {
                _oTxtCrossTubeWidth_BaseEnd = value;
            }
        }

        public TextBox TxtSwingClearance_BaseEnd
        {
            get
            {
                return _oTxtSwingClearance_BaseEnd;
            }
            set
            {
                _oTxtSwingClearance_BaseEnd = value;
            }
        }

        public TextBox TxtLugGap_BaseEnd
        {
            get
            {
                return _oTxtLugGap_BaseEnd;
            }
            set
            {
                _oTxtLugGap_BaseEnd = value;
            }
        }

        public ComboBox CmbBushingPinHoleSize_BaseEnd
        {
            get
            {
                return _oCmbBushingPinHoleSize_BaseEnd;
            }
            set
            {
                _oCmbBushingPinHoleSize_BaseEnd = value;
            }
        }

        public ComboBox CmbPinHoleSize_BaseEnd
        {
            get
            {
                return _oCmbPinHoleSize_BaseEnd;
            }
            set
            {
                _oCmbPinHoleSize_BaseEnd = value;
            }
        }

        public TextBox TxtPinHoleSize_BaseEnd
        {
            get
            {
                return _oTxtPinHoleSize_BaseEnd;
            }
            set
            {
                _oTxtPinHoleSize_BaseEnd = value;
            }
        }

        public ComboBox CmbGreaseZercs_BaseEnd
        {
            get
            {
                return _oCmbGreaseZercs_BaseEnd;
            }
            set
            {
                _oCmbGreaseZercs_BaseEnd = value;
            }
        }

        public TextBox TxtAngleOfGreaseZercs1_BaseEnd
        {
            get
            {
                return _oTxtAngleOfGreaseZercs1_BaseEnd;
            }
            set
            {
                _oTxtAngleOfGreaseZercs1_BaseEnd = value;
            }
        }

        public TextBox TxtAngleOfGreaseZercs2_BaseEnd
        {
            get
            {
                return _oTxtAngleOfGreaseZercs2_BaseEnd;
            }
            set
            {
                _oTxtAngleOfGreaseZercs2_BaseEnd = value;
            }
        }

        public TextBox TxtLugThickness_RodEnd
        {
            get
            {
                return _oTxtLugThickness_RodEnd;
            }
            set
            {
                _oTxtLugThickness_RodEnd = value;
            }
        }

        public TextBox TxtSwingClearance_RodEnd
        {
            get
            {
                return _oTxtSwingClearance_RodEnd;
            }
            set
            {
                _oTxtSwingClearance_RodEnd = value;
            }
        }

        public ComboBox CmbPinHoleSize_RodEnd
        {
            get
            {
                return _oCmbPinHoleSize_RodEnd;
            }
            set
            {
                _oCmbPinHoleSize_RodEnd = value;
            }
        }

        public TextBox TxtPinHoleSize_RodEnd
        {
            get
            {
                return _oTxtPinHoleSize_RodEnd;
            }
            set
            {
                _oTxtPinHoleSize_RodEnd = value;
            }
        }

        public ComboBox CmbGreaseZercs_RodEnd
        {
            get
            {
                return _oCmbGreaseZercs_RodEnd;
            }
            set
            {
                _oCmbGreaseZercs_RodEnd = value;
            }
        }

        public TextBox TxtAngleOfGreaseZercs1_RodEnd
        {
            get
            {
                return _oTxtAngleOfGreaseZercs1_RodEnd;
            }
            set
            {
                _oTxtAngleOfGreaseZercs1_RodEnd = value;
            }
        }

        public TextBox TxtAngleOfGreaseZercs2_RodEnd
        {
            get
            {
                return _oTxtAngleOfGreaseZercs2_RodEnd;
            }
            set
            {
                _oTxtAngleOfGreaseZercs2_RodEnd = value;
            }
        }

        public TextBox TxtCrossTubeWidth_RodEnd
        {
            get
            {
                return _oTxtCrossTubeWidth_RodEnd;
            }
            set
            {
                _oTxtCrossTubeWidth_RodEnd = value;
            }
        }

        public TextBox TxtLugGap_RodEnd
        {
            get
            {
                return _oTxtLugGap_RodEnd;
            }
            set
            {
                _oTxtLugGap_RodEnd = value;
            }
        }

        public ComboBox CmbBushingPinHoleSize_RodEnd
        {
            get
            {
                return _oCmbBushingPinHoleSize_RodEnd;
            }
            set
            {
                _oCmbBushingPinHoleSize_RodEnd = value;
            }
        }

        public TextBox TxtRetractedLength
        {
            get
            {
                return _oTxtRetractedLength;
            }
            set
            {
                _oTxtRetractedLength = value;
            }
        }

        public TextBox TxtCrossTubeOffset_BaseEnd
        {
            get
            {
                return _oTxtCrossTubeOffset_BaseEnd;
            }
            set
            {
                _oTxtCrossTubeOffset_BaseEnd = value;
            }
        }

        public TextBox TxtCrossTubeOffset_RodEnd
        {
            get
            {
                return _oTxtCrossTubeOffset_RodEnd;
            }
            set
            {
                _oTxtCrossTubeOffset_RodEnd = value;
            }
        }

        public ComboBox CmbPortSizeBaseEnd
        {
            get
            {
                return _oCmbPortSizeBaseEnd;
            }
            set
            {
                _oCmbPortSizeBaseEnd = value;
            }
        }

        public TextBox TxtBasePlugDia_BaseEnd
        {
            get
            {
                return _oTxtBasePlugDia_BaseEnd;
            }
            set
            {
                _oTxtBasePlugDia_BaseEnd = value;
            }
        }

        public ComboBox CmbPortType_BaseEnd
        {
            get
            {
                return _oCmbPortType_BaseEnd;
            }
            set
            {
                _oCmbPortType_BaseEnd = value;
            }
        }

        public TextBox TxtFirstPortOrientation_BaseEnd
        {
            get
            {
                return _oTxtFirstPortOrientation_BaseEnd;
            }
            set
            {
                _oTxtFirstPortOrientation_BaseEnd = value;
            }
        }

        public TextBox TxtSecondPortOrientation_BaseEnd
        {
            get
            {
                return _oTxtSecondPortOrientation_BaseEnd;
            }
            set
            {
                _oTxtSecondPortOrientation_BaseEnd = value;
            }
        }

        public ComboBox TxtThreadDiameter_BaseEnd
        {
            get
            {
                return _oTxtThreadDiameter_BaseEnd;
            }
            set
            {
                _oTxtThreadDiameter_BaseEnd = value;
            }
        }

        public TextBox TxtThreadLength_BaseEnd
        {
            get
            {
                return _oTxtThreadLength_BaseEnd;
            }
            set
            {
                _oTxtThreadLength_BaseEnd = value;
            }
        }

        public TextBox TxtToleranceUpperLimit_RodEnd
        {
            get
            {
                return _oTxtToleranceUpperLimit_RodEnd;
            }
            set
            {
                _oTxtToleranceUpperLimit_RodEnd = value;
            }
        }

        public TextBox TxtToleranceLowerLimit_RodEnd
        {
            get
            {
                return _oTxtToleranceLowerLimit_RodEnd;
            }
            set
            {
                _oTxtToleranceLowerLimit_RodEnd = value;
            }
        }

        public ComboBox CmbRodEndConfiguration_RodEnd
        {
            get
            {
                return _oCmbRodEndConfiguration_RodEnd;
            }
            set
            {
                _oCmbRodEndConfiguration_RodEnd = value;
            }
        }

        public ComboBox cmbConnectionType_RodEnd
        {
            get
            {
                return _ocmbConnectionType_RodEnd;
            }
            set
            {
                _ocmbConnectionType_RodEnd = value;
            }
        }

        public ComboBox CmbWeldType_BaseEnd
        {
            get
            {
                return _oCmbWeldType_BaseEnd;
            }
            set
            {
                _oCmbWeldType_BaseEnd = value;
            }
        }

        public ComboBox CmbBaseEndConfiguration
        {
            get
            {
                return _oCmbBaseEndConfiguration;
            }
            set
            {
                _oCmbBaseEndConfiguration = value;
            }
        }

        public ComboBox CmbPins_BaseEnd
        {
            get
            {
                return _oCmbPins_BaseEnd;
            }
            set
            {
                _oCmbPins_BaseEnd = value;
            }
        }

        public ComboBox CmbPins_RodEnd
        {
            get
            {
                return _oCmbPins_RodEnd;
            }
            set
            {
                _oCmbPins_RodEnd = value;
            }
        }

        public ComboBox CmbClips_BaseEnd
        {
            get
            {
                return _oCmbClips_BaseEnd;
            }
            set
            {
                _oCmbClips_BaseEnd = value;
            }
        }

        public ComboBox CmbClips_RodEnd
        {
            get
            {
                return _oCmbClips_RodEnd;
            }
            set
            {
                _oCmbClips_RodEnd = value;
            }
        }

        public TextBox TxtToleranceUpperLimit
        {
            get
            {
                return _oTxtToleranceUpperLimit;
            }
            set
            {
                _oTxtToleranceUpperLimit = value;
            }
        }

        public TextBox TxtToleranceLowerLimit
        {
            get
            {
                return _oTxtToleranceLowerLimit;
            }
            set
            {
                _oTxtToleranceLowerLimit = value;
            }
        }



        #endregion

        #endregion

        #region MILDB

        private clsCostingMILDB _oClsCostingMILDB;
        public clsCostingMILDB ObjClsMIL_TieRodDataClass
        {
            get
            {
                return _oClsCostingMILDB;
            }
            set
            {
                _oClsCostingMILDB = value;
            }
        }

        #endregion

        #region Base_RodEnd Weight

        double _dblBaseEndWeight;

        public double BaseEndWeight
        {
            get
            {
                return _dblBaseEndWeight;
            }
            set
            {
                _dblBaseEndWeight = value;
            }
        }

        private double _dblRodEndWeight;

        public double RodEndWeight
        {
            get
            {
                return _dblRodEndWeight;
            }
            set
            {
                _dblRodEndWeight = value;
            }
        }

        #endregion

        public frmUpdateDatabaseRecords ObjFrmUpdateRecords
        {
            get
            {
                return _ofrmUpdateRecords;
            }
            set
            {
                _ofrmUpdateRecords = value;
            }
        }

        public ProgressBar MonarchProgressbar
        {
            get
            {
                return _prb;
            }
            set
            {
                _prb = value;
            }
        }

        public string StopWatchAndProgressBar
        {
            set
            {
                if ((value == "Start"))
                {
                    MonarchProgressBar.Visible = true;
                    Control.CheckForIllegalCrossThreadCalls = false;
                    _oThreadProgressBarStepping = new Thread(new ThreadStart(new System.EventHandler(this.StartStepingProgressBar)));
                    _oThreadProgressBarStepping.IsBackground = true;
                    _oThreadProgressBarStepping.Start();
                }
                else if ((value == "Stop"))
                {
                    if (_oThreadProgressBarStepping.IsAlive)
                    {
                        MonarchProgressBar.Value = MonarchProgressBar.Maximum;
                        MonarchProgressBar.Value = 0;
                        _oThreadProgressBarStepping.Abort();
                        MonarchProgressBar.Visible = false;
                    }
                }
            }
        }

        #endregion

        #region Function ProtoTypes


        [DllImport("kernel32.dll")]
        static extern void Sleep(int milliSec);

        #endregion

        #region SubProcedures

        public clsWeldedCylinderFunctionalClass()
        {
            DeletePreviousErrorLogFile();
            InitialiseAllChildFormObjects();
        }

        public void StartStepingProgressBar()
        {
            
            while (!(MonarchProgressbar.Value== (MonarchProgressbar.Maximum + 1)))
            {
                if ((MonarchProgressbar.Value == MonarchProgressbar.Maximum))
                {
                    MonarchProgressbar.Value = 0;
                }
                MonarchProgressbar.Value++;
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);
            }
        }

        private void InitialiseAllChildFormObjects()
        {
            try
            {

                _oClsListViewMIL = new clsListViewMIL();
                _oClsWeldedDataClass = new clsWeldedDataClass();
                _oClsCostingMILDB = new clsCostingMILDB();
                _oClsWeldedGlobalVariables = new clsWeldedGlobalVariables();
                _oFrmPortDetails = new frmPortDetails();
                _oClsExcelClass = new ExcelClass();

                //============================= Primary ================================================

                _oFrmPrimaryInputs = new frmPrimaryInputs();
                _oFrmPistonDesign = new frmPistonDesign();
                _oFrmTubeDetails = new frmTubeDetails();
                _oFrmHeadDesign = new frmHeadDesign();
                _oFrmRodEndConfiguration = new frmRodEndConfiguration();

                //=======================================================================================

                //========================== Plate Clevis ================================================

                _oFrmConPlateClevis = new frmConPlateClevis();

                //=========================================================================================

                //================================ Double Lug =============================================

                _oFrmDLPortInTubeDetails = new frmDLPortInTubeDetails();
                _oFrmDLPortInTubeDetails2 = new frmDLPortInTubeDetails2();
                _oFrmDLCastingYes = new frmDLCastingYes();
                _oFrmDLCastingYes2 = new frmDLCastingYes2();
                _oFrmDLCastingNo_PortInTube = new frmDLCastingNo_PortInTube();
                _oFrmDLCastingNo_PortInTube2 = new frmDLCastingNo_PortInTube2();
                _oFrmDLPortIntegral = new frmDLPortIntegral();
                _oFrmDLPortIntegral2 = new frmDLPortIntegral2();
                _oFrmDLFabrication = new frmDLFabrication();
                _oFrmDLFabrication2 = new frmDLFabrication2();
                _oFrmDLDesignACasting = new frmDLDesignACasting();
                _oFrmDLDesignACasting2 = new frmDLDesignACasting2();
                _oFrmDLCastingNo_PortIntegral = new frmDLCastingNo_PortIntegral();
                _oFrmFabricatedSingleLug = new frmFabricatedSingleLug_RetractedLength();
               
                _oFrmFabricatedSingleLug2 = new frmFabricatedSingleLug_RetractedLength2();
               
                _oFrmDLCastingNo_PortIntegral2 = new frmDLCastingNo_PortIntegral2();

                //===================================================================================================

                //======================================  BH    =====================================================


                _oFrmBHCastingNo_PortIntegral = new frmBHCastingNo_PortIntegral();
                _oFrmBHCastingNo_PortInTube = new frmBHCastingNo_PortInTube();
                _oFrmBHCastingYes = new frmBHCastingYes();
                _oFrmBHDesignACasting = new frmBHDesignACasting();
                _oFrmBHFabrication = new frmBHFabrication();
                _oFrmBHPortIntegral = new frmBHPortIntegral();
                _oFrmBHPortinTube = new frmBHPortInTube();
                _oFrmBHCastingNo_PortIntegral2 = new frmBHCastingNo_PortIntegral2();
                _oFrmBHCastingNo_PortInTube2 = new frmBHCastingNo_PortInTube2();
                _oFrmBHCastingYes2 = new frmBHCastingYes2();
                _oFrmBHDesignACasting2 = new frmBHDesignACasting2();
                _oFrmBHFabrication2 = new frmBHFabrication2();
                _oFrmBHPortIntegral2 = new frmBHPortIntegral2();
                _oFrmBHPortinTube2 = new frmBHPortInTube2();

                //===================================================================================================

                //======================================  Single Lug ================================================

                _oFrmSLCastingNo_PortIntegral = new frmSLCastingNo_PortIntegral();
                _oFrmSLCastingNo_PortInTube = new frmSLCastingNo_PortInTube();
                _oFrmSLCastingYes = new frmSLCastingYes();
                _oFrmSLDesignACasting = new frmSLDesignACasting();
                _oFrmSLFabrication = new frmSLFabrication();
                _oFrmSLPortIntegral = new frmSLPortIntegral();
                _oFrmSLPortinTube = new frmSLPortinTube();
                _oFrmSLCastingNo_PortIntegral2 = new frmSLCastingNo_PortIntegral2();
                _oFrmSLCastingNo_PortInTube2 = new frmSLCastingNo_PortInTube2();
                _oFrmSLCastingYes2 = new frmSLCastingYes2();
                _oFrmSLDesignACasting2 = new frmSLDesignACasting2();
                _oFrmSLFabrication2 = new frmSLFabrication2();
                _oFrmSLPortIntegral2 = new frmSLPortIntegral2();
                _oFrmSLPortinTube2 = new frmSLPortinTube2();

                //===================================================================================================

                //======================================  Base Plug  ================================================

                oFrmBasePlugCastingYes = new frmBasePlugCastingYes();
                _oFrmBasePlugPortIntegral = new frmBasePlugPortIntegral();
                _oFrmBasePlugPortInTube = new frmBasePlugPortInTube();
                _oFrmBasePlugCastingYesPortIntegral = new frmBasePlugCastingYesPortIntegral();
                _oFrmBasePlugCastingNoPortIntegral = new frmBasePlugCastingNoPortIntegral();

                //===================================================================================================

                //======================================  Threaded End ===============================================


                _oFrmThreadedCastingYes = new frmThreadedEndCastingYes();
               
                _oFrmDesignAThreadedCasting = new frmDesignAThreadedCasting();
               
                _oFrmThreadedPortInTube = new frmThreadedEndPortInTube();
                
                _oFrmThreadedEndPortIntegral = new frmThreadedEndPortIntegral();
                _oFrmBEThreadedEndCastingNo_PortIntegral = new frmBEThreadedEndCastingNo_PortIntegral();

                _ofrmThreadedEndCastingYes_PortIntegral = new frmThreadedEndCastingYes_PortIntegral();

                //===================================================================================================

                //======================================  Cross Tube  ===============================================

                _oFrmCTPortInTube = new frmCTPortInTube();
                _oFrmCTPortIntegral = new frmCTPortIntegral();
                _oFrmCTFabrication = new frmCTFabrication();
                _oFrmCTDesignACasting = new frmCTDesignACasting();
                _oFrmCTCastingYes = new frmCTCastingYes();
                _oFrmCTCastingNo_PortInTube = new frmCTCastingNo_PortInTube();
                _oFrmCTCastingNo_PortIntegral = new frmCTCastingNo_PortIntegral();
                _oFrmDesignABasePlug = new frmDesignABasePlug();
                
                _oFrmCTPortInTube2 = new frmCTPortInTube2();
                _oFrmCTPortIntegral2 = new frmCTPortIntegral2();
                _oFrmCTFabrication2 = new frmCTFabrication2();
                _oFrmCTDesignACasting2 = new frmCTDesignACasting2();
                _oFrmCTCastingYes2 = new frmCTCastingYes2();
                _oFrmCTCastingNo_PortInTube2 = new frmCTCastingNo_PortInTube2();
                _oFrmCTCastingNo_PortIntegral2 = new frmCTCastingNo_PortIntegral2();

                //===================================================================================================

                //====================================== Rod End Single Lug =========================================

                _oFrmRESingleLugDetails = new frmRESingleLugDetails();
                _oFrmRESingleLugExistingNotSelected = new frmRESingleLugExistingNotSelected();

                //===================================================================================================

                //====================================== RodEnd BH  =================================================

                _oFrmREBHDetails = new frmREBHDetails();
                _oFrmREBHExistingNotSelected = new frmREBHExistingNotSelected();


                //===================================================================================================

                //====================================== Rod End Flat With Chamfer ===================================

                _oFrmFlatWithChamfer = new frmFlatWithChamfer();

                //===================================================================================================

                //====================================== Drilled Pin Hole Rod End ===================================

                _oFrmREDrilledPinHole = new frmREDrilledPinHole();

                //===================================================================================================

                //====================================== Threaded End _ Rod End    ===================================

                _oFrmREThreadedRod = new frmREThreadedRod();

                //===================================================================================================

                _oFrmRetractedLengthValidation = new frmRetractedLengthValidation();

                //===================================================================================================

                //====================================== RodEndDoubleLug         ===================================

                _oFrmREDLCasting = new frmREDLCasting();
                _oFrmREDLThreaded = new frmREDLThreaded();
                _oFrmREDLWelded = new frmREDLWelded();
                _oFrmREDLExistingDesign = new frmREDLExistingDesign();
                _oFrmREDLNewDesign = new frmREDLNewDesign();

                //===================================================================================================

                //====================================== Cross Tube - Rod End     ===================================

                _oFrmRECrossTube = new frmRECrossTube();
                _oFrmCastingYes_RECT = new frmCastingYes_RECT();
                _oFrmCastingNo_RECT = new frmCastingNo_RECT();
                _oFrmDesignACasting_RECT = new frmDesignACasting_RECT();
                _oFrmFabrication_RECT = new frmFabrication_RECT();

                //===================================================================================================

                //====================================== Generate      ==============================================

                _oFrmGenerate = new frmGenerate();

                //===================================================================================================

                //====================================== Contract Details=============================================

                _oFrmContractDetails = new frmContractDetails();
                _oFrmMonarchRevision = new frmMonarchRevision();
                _oFrmPin_Port_PaintAccessories = new frmPin_Port_PaintAccessories();
               
                _oFrmImportBaseEnd = new frmImportBaseEnd();
                _oFrmImportRodEnd = new frmImportRodEnd();

                _ofrmUpdateRecords = new frmUpdateDatabaseRecords();

            }
            catch (Exception ex)
            {
            }

        }

        public void AddItemsToGeneralInformationListView()
        {
            _lvwGeneralInformation.Columns.Clear();
            _lvwGeneralInformation.Items.Clear();
            _lvwGeneralInformation.Columns.Add("Property", 190, HorizontalAlignment.Center);
            _lvwGeneralInformation.Columns.Add("Value", 115, HorizontalAlignment.Center);
            int intCount = 0;
            foreach (object oGeneralInformationItem in GeneralInformation)
            {
                ListViewItem oGeneralListViewItem;
                oGeneralListViewItem = _lvwGeneralInformation.Items.Add(oGeneralInformationItem[0]);
                _lvwGeneralInformation.Items(intCount).SubItems.Add(oGeneralInformationItem[1]);
                intCount++;
            }
        }

        public void AddGeneralInformationValues(string strKey, string strValue)
        {
            foreach (object oGeneralInformationListViewItem in _lvwGeneralInformation.Items)
            {
                if (oGeneralInformationListViewItem.SubItems.items[0].Text.Equals(strKey))
                {
                    oGeneralInformationListViewItem.SubItems.Item[1].Text = strValue;
                    break;
                }
            }
        }
        private string GetCylinderCodeNumber()
        {
            GetCylinderCodeNumber = "";
            try
            {
                long iContractNumber = 677500;
                // vamsi changed for IFL System as per updates from 675000
                string strQuery = String.Empty;
                strQuery = "select top 1 ContractNumber from ContractNumberDetails order by ContractNumber Desc";
                DataTable objDT = MonarchConnectionObject.GetTable(strQuery);
                if ((objDT.Rows.Count > 0))
                {
                    iContractNumber = double.Parse(objDT.Rows[0].Item["ContractNumber"].ToString);
                    iContractNumber = (iContractNumber + 1);
                }
                try
                {
                    strQuery = ("Insert into ContractNumberDetails Values (\'"
                                + (iContractNumber.ToString + "\')"));
                    objDT = MonarchConnectionObject.GetTable(strQuery);
                }
                catch (Exception ex)
                {
                }
                GetCylinderCodeNumber = iContractNumber.ToString;
            }
            catch (Exception ex)
            {
            }
            return GetCylinderCodeNumber;
        }
        #endregion


        public double RoundUp(double number, int significant)
        {
            RoundUp = Math.Round(number, significant);
            if ((RoundUp < number))
            {
                RoundUp = (RoundUp + (1 / Math.Pow(10, significant)));
                RoundUp = Math.Round(RoundUp, significant);
            }
        }






        public void WriteLogInformation(string p)
        {
            throw new NotImplementedException();
        }

        internal void CloseExcel()
        {
            throw new NotImplementedException();
        }
    }



}
