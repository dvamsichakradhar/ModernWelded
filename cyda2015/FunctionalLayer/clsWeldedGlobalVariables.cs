using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace Welded.FunctionalLayer
{

    public class clsWeldedGlobalVariables
    {

        public Hashtable oRenamingHashTable = new Hashtable();

        public string strCast_Fabricated_1st = String.Empty;


        public bool blnBaseEndCasting_New = false;

        public bool blnBaseEndFabrication_New = false;

        public string strBaseEndCastingTable = String.Empty;


        public string strBaseEndFabricationTable = String.Empty;


        public string strBaseEndCastingPart = String.Empty;


        public string strBaseEndFabricationPart = String.Empty;


        public bool blnNewCastingGenerated = false;

        public bool blnNewFabricationGenerated = false;

        public bool blnExistingPartSelected_BaseEnd = false;

        public bool blnExistingPartSelected_RodEnd = false;

        public bool blnExistingPartSelected_RodEnd2 = false;

        public string strWC_619_622 = String.Empty;


        public bool blnBendradius_error = false;

        private double _dblDistanceFromPinholetoRodStop;


        private string _strSeriesCode = String.Empty;


        private double _dblBoreDiameter;

        private double _dblWorkingPressure;

        private string _strColumnLoadDeratePressure = String.Empty;

        private string _strPistonConnection = String.Empty;

        private string _strPistonShankSeal = String.Empty;

        private double _dblRodDiameter;

        private string _strSelectedClass = String.Empty;

        private string _strPistonNutSizeInFractions = String.Empty;

        private double _dblPistonNutSizeInDecimals;

        private double _dblNutSafetyFactor;

        private double _dblEndConditionSafetyFactor;

        private double _dblRetractedLength;

        private double _dblStrokeLength;

        private string _strBaseEndConfigurationDesign = String.Empty;

        private string _strBaseEndConfigurationDesign2 = String.Empty;


        private string _strBaseEndConfigurationDesignType = String.Empty;

        private string _strBaseEndConfigurationDesignType2 = String.Empty;


        private double _dblPistonNutActualSize;


        private string _strGeneratePath = String.Empty;

        public string AssyGeneratePath = String.Empty;


        private string _strGeneratePath_Drawings = String.Empty;


        private string _strcodeNumber = String.Empty;

        public string strTubeWeldmentDescription = String.Empty;


        public string strRodWeldmentDescription = String.Empty;

        public string OriginalCodeNumber = String.Empty;

        public string ImportBaseEndPartPath = String.Empty;

        public string ImportBaseEndPortPartPath = String.Empty;

        public string ImportRodEndPortPartPath = String.Empty;

        public string ImportRodEndPartPath = String.Empty;


        private double _dblStopTubeLength;


        private bool _blnRodEndFabricationSelected;

        private bool _blnRodEndFabricationSelected2;


        private bool _blnRodEndDesignSelected;

        private bool _blnRodEndDesignSelected2;


        private bool _blnBaseEndFabricationSelected;

        private bool _blnBaseEndDesignSelected;

        private bool _blnBaseEndFabricationSelected2;


        private bool _blnBaseEndDesignSelected2;


        private string _strPurchaseCode = String.Empty;

        private string _strManufactureCode = String.Empty;

        private string _strBaseEndPartName = String.Empty;

        private string _strBaseEndPartName2 = String.Empty;


        private string _strRodEndPartName = String.Empty;

        private string _strRodEndPartName2 = String.Empty;


        private string _strBaseEnd_NewDesign_TableName = String.Empty;

        private string _strBaseEnd_NewDesign_TableName2 = String.Empty;


        private string _strRodEnd_NewDesign_TableName = String.Empty;

        public Hashtable htStoreConfigurationCodeNumbers = new Hashtable();


        private string _strPinHoleType_RodEnd = String.Empty;


        private double _dblPullForce;

        private double _dblPullForce_RodEnd;


        private string _strGeneralNotes = String.Empty;

        private string _strPaintPackagingNotes = String.Empty;

        private string _strAssemblyNotes = String.Empty;

        private int _iAssyNotesCount;

        private int _iPaintingNotesCount;


        private double _dbltempWorkingPressure;


        private double _dblTempMaxNutThickness;


        private string _strRodMaterial = String.Empty;

        private string _strSelectedPistonSeal = String.Empty;

        private double _dblPistonWidth;


        private string _strPistonWearRing = String.Empty;


        private double _dblPI_MaxDistance_from_RodSide_to_SealGrooveEnd;

        private string _strCylinderHeadDesign = String.Empty;

        private double _dblShankLength;

        private double _dblCounterBoreDepth;

        private double _dblNoseLength;

        public string CylinderHeadCode = String.Empty;


        public double Breather;

        private string _strDesignType = String.Empty;

        private string _strDesignType2 = String.Empty;


        private string _strBaseEndConfiguration = String.Empty;

        private string _strBaseEndConfiguration2 = String.Empty;


        private string _strBaseEndPort = String.Empty;

        public string BaseEndPortCode = String.Empty;


        public string RodEndPortCode = String.Empty;


        private string _strPortInsertion = String.Empty;

        private double _dblTubeOD;

        private double _dblTubeWallThickness;

        private double _dblPinHoleSize;

        private double _dblLugGap;

        private double _dblBushingQuantity;

        private double _dblSwingClearance;

        private double _dblSwingClearance2;


        private double _dblBushingWidth;

        private double _dblLugThickness;

        private double _dblLugThickness2;


        private double _dblGreaseZercs;

        private double _dblGreaseZercAngle1;

        private double _dblGreaseZercAngle2;

        private string _strTubeMaterial = String.Empty;

        private double _dblLugWidth;

        private double _dblLugWidth2;


        private string _strPinWithInTubeDiameter = String.Empty;

        private double _dblAreaRequired;

        private double _dblYRequired;

        private double _dblOutSidePlugDiameter;

        private double _dblMilledFlatWidth;

        private double _dblCrossTubeWidth;

        private double _dblCrossTubeWidth2;


        private double _dblOffSet;


        private string _strPistonLocation = String.Empty;

        private string _strWeldType = String.Empty;

        private double _dblThreadDiameter;

        private double _dblThreadLength;

        private string _strPinHoleType = String.Empty;

        private string _strSearchFound = String.Empty;

        private double _dblToleranceUpperLimit;

        private double _dblToleranceLowerLimit;

        private double _dblSafetyFactor_BaseEnd;

        private double _dblSafetyFactor_BaseEnd2;

        private double _dblSafetyFactor_RodEnd;

        private double _dblSafetyFactor_RodEnd2;


        private string _strMilledFlat = String.Empty;


        private double _dblRodLength;


        private double _dblBushingOD_BaseEnd;

        private string _strPinsYesOrNo = String.Empty;


        public string strTubeWeldmentVolume = String.Empty;

        public string strRodWeldmentVolume = String.Empty;

        public string strWeldCylinderVolume = String.Empty;


        public double strTubeWeldmentWeight;

        public double strRodWeldmentWeight;

        public double strWeldCylinderWeight;

        public ArrayList TubeWorkCenterList = new ArrayList();

        public ArrayList RodWorkCenterList = new ArrayList();

        public double TubeRuleId = 0;

        public double RodRuleId = 0;


        private string _strISBushingStyle_2BushingsIndividualBore = String.Empty;

        private string _strISBushingStyle_2BushingsIndividualBore_RodEnd = String.Empty;


        private double _dblDimension8;

        private double _dblRulesID_Rod;

        private string _strPortType_RodEnd = String.Empty;

        private string _strPortType_BaseEnd = String.Empty;

        private double _dblPortFirstOrientation;

        private double _dblPortSecondOrientation;

        private int _intPortQuantity;

        private double _dblOrificeSize_RodEnd;

        private double _dblOrificeSize_BaseEnd;

        private string _strPortSize_BaseEnd = String.Empty;

        private string _strPortSize_RodEnd = String.Empty;


        private double _dblNoOfPorts;


        private double _dblNoOfPorts_RodEnd;

        private double _dblPortAccessoryType_baseEnd;

        private double _dblPortAccessoryType_RodEnd;

        private double _dblFirstPortOrientation_BaseEnd;

        private double _dblSecondPortOrientation_BaseEnd;

        private double _dblFirstPortOrientation_RodEnd;

        private double _dblSecondPortOrientation_RodEnd;

        private double _dblStandardRunQuantity;

        private DataTable _oMatchedBEDLCastingDataTable;

        private string _strPartCodeFromUlugCode = String.Empty;


        private double _dblBendRadius_BaseEnd;

        private double _dblBPBushingWidth;


        private double _dblBPODPortIntegral;

        private double _dblOutSidePlugDiameterRequiredPortIntegral;


        private bool _blnMilledFlatWidthSelected;

        private DataTable _oMatchedBEBPCastingDataTable;


        private double _dblMilledFlatHeight;


        public double BasePlugPinHoleSize;

        private DataTable _oMatchedBEThreadedEndCastingDataTable;

        public double dblWeldsize_SL_BaseEnd = 0;


        private DataTable _oMatchedBESLCastingDataTable;

        private DataTable _oMatchedBHCastingDataTable;


        private double _dblEndofTubetoRodStop;

        private double _dblEndofTubetoRodStop2;


        private string _strBaseEndCodeNumber90 = String.Empty;


        private string _strBaseEndCodeNumber = String.Empty;


        private double _dblBaseEndDistanceFromPinholetoRodStop;

        private double _dblBaseEndDistanceFromPinholetoRodStop2;

        private DataTable _oMatchedBECrossTubeCastingDataTable;

        private double _dblCrossTubeOD;

        private double _dblCrossTubeOD2;

        private string _strRodEndConfiguration = String.Empty;

        private double _dblLugThickness_RodEnd;

        private double _dblLugGap_RodEnd;

        private double _dblSwingClearance_RodEnd;

        private double _dblSwingClearance_RodEnd2;


        private string _strPins_RodEnd = String.Empty;

        private string _strClips_RodEnd = String.Empty;

        private double _dblCrossTubeWidth_RodEnd;

        private double _dblCrossTubeWidth_RodEnd2;


        private double _dblBushingQuantity_RodEnd;

        private double _dblBushingPinHoleSize_RodEnd;

        private double _dblBushingWidth_RodEnd;

        private double _dblPinHoleSize_RodEnd;

        private double _dblGreaseZercs_RodEnd;

        private string _strBushingType_RodEnd = String.Empty;

        private double _dblGreaseZercAngle1_RodEnd;

        private double _dblGreaseZercAngle2_RodEnd;

        private double _dblCost_RodEnd;


        private double _dblCrossTubeOD_RodEnd;

        private double _dblCrossTubeOD_RodEnd2;


        private double _dblLugWidth_RodEnd;

        private double _dblLugWidth_RodEnd2;


        private double _dblAreaRequired_RodEnd;

        private double _dblYRequired_RodEnd;

        private double _dblToleranceUpperLimit_RodEnd;

        private double _dblToleranceLowerLimit_RodEnd;

        private string _strPinHoleSizeType = String.Empty;

        private string _strPinHoleTypeThreaded_RE_DL = String.Empty;

        private string _strConnectionType = String.Empty;

        private double _dblREDistanceFromPinholetoRodStop;

        private double _dblREDistanceFromPinholetoRodStop2;


        private double _dblOffSet_RodEnd;

        private string _strConfigurationDesign_RodEnd = String.Empty;

        private string _strConfigurationDesign_RodEnd2 = String.Empty;


        private string _strConfigurationDesignType_RodEnd = String.Empty;

        private string _strConfigurationDesignType_RodEnd2 = String.Empty;


        private string _strConfigurationCode_RodEnd = String.Empty;

        private string _strConfigurationCode_RodEnd2 = String.Empty;


        public string strSetScrew = String.Empty;


        private string _strRodEndConfigurationDesign = String.Empty;


        private double _dblLugHeight_RodEnd;

        private double _dblLugHeight_BaseEnd;

        private string _strMilledFlat_RE = String.Empty;


        private string _strBushingPartCode_RodEnd = String.Empty;

        private double _dblBushingOD_RodEnd;

        private string _strRodEndCollarCodeNumber = String.Empty;


        private double _dblOriginalTubeLength;


        public string strSheetNumber_Tube = String.Empty;


        public string strSheetNumber_Rod = String.Empty;


        public double PortOD = 0;


        public string PortLocatorCode_Tube = String.Empty;


        public string PortLocatorCode_Rod = String.Empty;


        public string WPDS_PortCode_Tube = String.Empty;


        public string WPDS_PortCode_Rod = String.Empty;


        public string Skived_Honed_Tube = String.Empty;


        public string Skived_Honed_Rod = String.Empty;


        public bool _blnIsFocusedInRevision = false;

        private double _dblChamferAngle_RodEnd;

        private double _dblChamferSize_RodEnd;

        private string _strThreadType_RodEnd = String.Empty;

        private double _dblThreadSize_RodEnd;

        private double _dblThreadLength_RodEnd;

        private double _dblAcrossFlatValue_RodEnd;

        private double _dblFlatLength_RodEnd;

        private double _dblOverAllCylinderLength;


        private double _dblExtraRodButtonLength;

        private string _strExtraRodButton = String.Empty;

        private string _strPortEndDistanceFromTubeEnd = String.Empty;

        private double _dblCylinderThreadedHeadChamferLength;


        private bool _blnIsCompressedSelected;


        private double _dblStickOut;

        private double _dblOffsetPortOrifice;

        private double _dblSkimWidth;


        private bool _blnISFabricationChecked;


        private bool _blnIsCounterBoreChecked;


        private bool _blnSkipRetractedIfPositiveFromGenerate;


        private bool _blnGoToBaseEndScreenFromRetractedScreen;

        private bool _blnGoToRodEndScreenFromRetractedScreen;

        private DataTable _oMatchedRECrossTubeCastingDataTable;

        private double _dblWeldSize_REDL;

        private double _dblWeldSize_RECT;


        private DataTable _oMatchedREDlCastingDataTable;

        private DataTable _oMatchedREDLThreadedDataTable;


        private double _dblBendRadius_RodEnd;

        private string _strPilotHoleDiameter = String.Empty;

        private string _strClevisPlateCode = String.Empty;

        private string _strClevisPlateCode2 = String.Empty;


        private string _strConfigurationCode_BaseEnd = String.Empty;

        private string _strConfigurationCode_BaseEnd2 = String.Empty;


        private string _strCounterBoreClevisPlateCode = String.Empty;

        private double _dblCounterBoreClevisPlateThickness;

        private double _dblCounterboredClevisPlateRodStopDistance;

        private double _dblClevisPlateThickness;

        private double _dblClevisPlateThickness2;


        private double _dblClevisPlateRodStopDistance;

        private string _strClevisplatePartFilePath = String.Empty;


        private string _strClevisPlateImportOrExisting = String.Empty;

        private string _strClevisPlateImportOrExisting2 = String.Empty;

        private Hashtable _htFolderDeletion = new Hashtable();

        private double _dblWeldSize_RodEnd;

        private string _strWeldPreperation_RodEnd;

        private double _dblJGrooveWidth_RodEnd;

        private double _dblJGrooveRadius_RodEnd;

        private string _strCustomerName_ContractDetails;

        private string _strAssemblyType_ContractDetails;

        private string _strPartCode_ContractDetails;

        private string _strNew_Revision;

        private bool _blnCustomerNameComboBOxChanged;

        public string strPortAngle = String.Empty;


        private string _StrBEDLPartCode;


        public string tmpPortType = null;

        public string tmpPortSize = null;

        public bool blnPrtNumChkd = false;

        public string tmpPinholesize;


        public bool blnInstallPinsandClips = true;

        public bool blnInstallPinsandClips_Checked = false;

        public bool blnIncludepinKitPerBom_Checked = false;

        public string strBaseEndKitCode = String.Empty;


        public string strRodEndKitCode = String.Empty;


        public int _intContractRevisionNumber = 0;


        public int intContractRevisionNumber;


        private string _strRevisionContractNo;

        public string strNewPartCodeNumber_BeforeContractStart = "";

        public string strRephasingType = "";

        public bool blnBasePlugTwoPorts = false;

        public bool blnBasePlugTwoPorts_RodEnd = false;

        public string strBaseEndCastingTableName = String.Empty;


        public string strBaseEndCastingCodeNumber = String.Empty;


        public string strRodEndCastingTableName = String.Empty;


        public string strRodEndCastingCodeNumber = String.Empty;


        public string strRodEndCastingCodeNumber2 = String.Empty;


        public string RevisionContractNo
        {
            get
            {
                return _strRevisionContractNo;
            }
            set
            {
                _strRevisionContractNo = value;
            }
        }

        private Hashtable _htWeldedCompleteCylinderWCDetails;

        public Hashtable WeldedCompleteCylinderWCDetails
        {
            get
            {
                return _htWeldedCompleteCylinderWCDetails;
            }
            set
            {
                _htWeldedCompleteCylinderWCDetails = value;
            }
        }

        private Hashtable _htWeldedTubeWCDetails;

        public Hashtable WeldedTubeWCDetails
        {
            get
            {
                return _htWeldedTubeWCDetails;
            }
            set
            {
                _htWeldedTubeWCDetails = value;
            }
        }

        private Hashtable _htWeldedRodWCDetails;

        public Hashtable WeldedRodWCDetails
        {
            get
            {
                return _htWeldedRodWCDetails;
            }
            set
            {
                _htWeldedRodWCDetails = value;
            }
        }

        private Hashtable _htWeldedBELugWCDetails;

        public Hashtable WeldedBELugWCDetails
        {
            get
            {
                return _htWeldedBELugWCDetails;
            }
            set
            {
                _htWeldedBELugWCDetails = value;
            }
        }

        private Hashtable _htWeldedRELugWCDetails;

        public Hashtable WeldedRELugWCDetails
        {
            get
            {
                return _htWeldedRELugWCDetails;
            }
            set
            {
                _htWeldedRELugWCDetails = value;
            }
        }

        public double TempWorkingPressure
        {
            get
            {
                return _dbltempWorkingPressure;
            }
            set
            {
                _dbltempWorkingPressure = value;
            }
        }

        public string strPaintPackagingNotes
        {
            get
            {
                return _strPaintPackagingNotes;
            }
            set
            {
                _strPaintPackagingNotes = value;
            }
        }

        public string strAssemblyNotes
        {
            get
            {
                return _strAssemblyNotes;
            }
            set
            {
                _strAssemblyNotes = value;
            }
        }

        public string GeneralNotes
        {
            get
            {
                return _strGeneralNotes;
            }
            set
            {
                _strGeneralNotes = value;
            }
        }

        public int iAssyNotesCount
        {
            get
            {
                return _iAssyNotesCount;
            }
            set
            {
                _iAssyNotesCount = value;
            }
        }

        public int iPaintingNotesCount
        {
            get
            {
                return _iPaintingNotesCount;
            }
            set
            {
                _iPaintingNotesCount = value;
            }
        }

        public string GeneratePath
        {
            get
            {
                return _strGeneratePath;
            }
            set
            {
                _strGeneratePath = value;
            }
        }

        public string GeneratePath_Drawings
        {
            get
            {
                return _strGeneratePath_Drawings;
            }
            set
            {
                _strGeneratePath_Drawings = value;
            }
        }

        public string CodeNumber
        {
            get
            {
                return _strcodeNumber;
            }
            set
            {
                _strcodeNumber = value;
            }
        }

        public double DistanceFromPinholetoRodStop
        {
            get
            {
                return _dblDistanceFromPinholetoRodStop;
            }
            set
            {
                _dblDistanceFromPinholetoRodStop = value;
            }
        }

        public double BoreDiameter
        {
            get
            {
                return _dblBoreDiameter;
            }
            set
            {
                _dblBoreDiameter = value;
            }
        }

        public double WorkingPressure
        {
            get
            {
                return _dblWorkingPressure;
            }
            set
            {
                _dblWorkingPressure = value;
            }
        }

        public string ColumnLoadDeratePressure
        {
            get
            {
                return _strColumnLoadDeratePressure;
            }
            set
            {
                _strColumnLoadDeratePressure = value;
            }
        }

        public string PistonConnection
        {
            get
            {
                return _strPistonConnection;
            }
            set
            {
                _strPistonConnection = value;
            }
        }

        public string PistonShankSeal
        {
            get
            {
                return _strPistonShankSeal;
            }
            set
            {
                _strPistonShankSeal = value;
            }
        }

        public double RodDiameter
        {
            get
            {
                return _dblRodDiameter;
            }
            set
            {
                _dblRodDiameter = value;
            }
        }

        public string SelectedClass
        {
            get
            {
                return _strSelectedClass;
            }
            set
            {
                _strSelectedClass = value;
            }
        }

        public string PistonNutSizeInFractions
        {
            get
            {
                return _strPistonNutSizeInFractions;
            }
            set
            {
                _strPistonNutSizeInFractions = value;
            }
        }

        public double PistonNutSizeInDecimals
        {
            get
            {
                return _dblPistonNutSizeInDecimals;
            }
            set
            {
                _dblPistonNutSizeInDecimals = value;
            }
        }

        public double PistonNutActualSize
        {
            get
            {
                return _dblPistonNutActualSize;
            }
            set
            {
                _dblPistonNutActualSize = value;
            }
        }

        public double NutSafetyFactor
        {
            get
            {
                return _dblNutSafetyFactor;
            }
            set
            {
                _dblNutSafetyFactor = value;
            }
        }

        public double EndConditionSafetyFactor
        {
            get
            {
                return _dblEndConditionSafetyFactor;
            }
            set
            {
                _dblEndConditionSafetyFactor = value;
            }
        }

        public double RetractedLength
        {
            get
            {
                return _dblRetractedLength;
            }
            set
            {
                _dblRetractedLength = value;
            }
        }

        public double StrokeLength
        {
            get
            {
                return _dblStrokeLength;
            }
            set
            {
                _dblStrokeLength = value;
            }
        }

        public double EndofTubetoRodStop
        {
            get
            {
                return _dblEndofTubetoRodStop;
            }
            set
            {
                _dblEndofTubetoRodStop = value;
            }
        }

        public double EndofTubetoRodStop2
        {
            get
            {
                return _dblEndofTubetoRodStop2;
            }
            set
            {
                _dblEndofTubetoRodStop2 = value;
            }
        }

        public double BaseEndDistanceFromPinholetoRodStop
        {
            get
            {
                return _dblBaseEndDistanceFromPinholetoRodStop;
            }
            set
            {
                _dblBaseEndDistanceFromPinholetoRodStop = value;
            }
        }

        public double BaseEndDistanceFromPinholetoRodStop2
        {
            get
            {
                return _dblBaseEndDistanceFromPinholetoRodStop2;
            }
            set
            {
                _dblBaseEndDistanceFromPinholetoRodStop2 = value;
            }
        }

        public string BaseEndConfigurationDesign
        {
            get
            {
                return _strBaseEndConfigurationDesign;
            }
            set
            {
                _strBaseEndConfigurationDesign = value;
            }
        }

        public string BaseEndConfigurationDesign2
        {
            get
            {
                return _strBaseEndConfigurationDesign2;
            }
            set
            {
                _strBaseEndConfigurationDesign2 = value;
            }
        }

        public string SearchFound
        {
            get
            {
                return _strSearchFound;
            }
            set
            {
                _strSearchFound = value;
            }
        }

        public string BaseEndConfigurationDesignType
        {
            get
            {
                return _strBaseEndConfigurationDesignType;
            }
            set
            {
                _strBaseEndConfigurationDesignType = value;
            }
        }

        public string BaseEndConfigurationDesignType2
        {
            get
            {
                return _strBaseEndConfigurationDesignType2;
            }
            set
            {
                _strBaseEndConfigurationDesignType2 = value;
            }
        }

        public double StopTubeLength
        {
            get
            {
                return _dblStopTubeLength;
            }
            set
            {
                _dblStopTubeLength = value;
            }
        }

        public bool RodEndFabricationSelected
        {
            get
            {
                return _blnRodEndFabricationSelected;
            }
            set
            {
                _blnRodEndFabricationSelected = value;
            }
        }

        public bool RodEndFabricationSelected2
        {
            get
            {
                return _blnRodEndFabricationSelected2;
            }
            set
            {
                _blnRodEndFabricationSelected2 = value;
            }
        }

        public bool RodEndDesignSelected
        {
            get
            {
                return _blnRodEndDesignSelected;
            }
            set
            {
                _blnRodEndDesignSelected = value;
            }
        }

        public bool RodEndDesignSelected2
        {
            get
            {
                return _blnRodEndDesignSelected2;
            }
            set
            {
                _blnRodEndDesignSelected2 = value;
            }
        }

        public bool BaseEndFabricationSelected
        {
            get
            {
                return _blnBaseEndFabricationSelected;
            }
            set
            {
                _blnBaseEndFabricationSelected = value;
            }
        }

        public bool BaseEndFabricationSelected2
        {
            get
            {
                return _blnBaseEndFabricationSelected2;
            }
            set
            {
                _blnBaseEndFabricationSelected2 = value;
            }
        }

        public bool BaseEndDesignSelected
        {
            get
            {
                return _blnBaseEndDesignSelected;
            }
            set
            {
                _blnBaseEndDesignSelected = value;
            }
        }

        public bool BaseEndDesignSelected2
        {
            get
            {
                return _blnBaseEndDesignSelected2;
            }
            set
            {
                _blnBaseEndDesignSelected2 = value;
            }
        }

        public string PurchaseCode
        {
            get
            {
                return _strPurchaseCode;
            }
            set
            {
                _strPurchaseCode = value;
            }
        }

        public string ManufactureCode
        {
            get
            {
                return _strManufactureCode;
            }
            set
            {
                _strManufactureCode = value;
            }
        }

        public string BaseEndPartName
        {
            get
            {
                return _strBaseEndPartName;
            }
            set
            {
                _strBaseEndPartName = value;
            }
        }

        public string BaseEndPartName2
        {
            get
            {
                return _strBaseEndPartName2;
            }
            set
            {
                _strBaseEndPartName2 = value;
            }
        }

        public string RodEndPartName
        {
            get
            {
                return _strRodEndPartName;
            }
            set
            {
                _strRodEndPartName = value;
            }
        }

        public string RodEndPartName2
        {
            get
            {
                return _strRodEndPartName2;
            }
            set
            {
                _strRodEndPartName2 = value;
            }
        }

        public string BaseEnd_NewDesign_TableName
        {
            get
            {
                return _strBaseEnd_NewDesign_TableName;
            }
            set
            {
                _strBaseEnd_NewDesign_TableName = value;
            }
        }

        public string BaseEnd_NewDesign_TableName2
        {
            get
            {
                return _strBaseEnd_NewDesign_TableName2;
            }
            set
            {
                _strBaseEnd_NewDesign_TableName2 = value;
            }
        }

        public string RodEnd_NewDesign_TableName
        {
            get
            {
                return _strRodEnd_NewDesign_TableName;
            }
            set
            {
                _strRodEnd_NewDesign_TableName = value;
            }
        }

        public double PistonNutThickness
        {
            get
            {
                return _dblTempMaxNutThickness;
            }
            set
            {
                _dblTempMaxNutThickness = value;
            }
        }

        public string RodMaterial
        {
            get
            {
                return _strRodMaterial;
            }
            set
            {
                _strRodMaterial = value;
            }
        }

        public string SelectedPistonSeal
        {
            get
            {
                return _strSelectedPistonSeal;
            }
            set
            {
                _strSelectedPistonSeal = value;
            }
        }

        public double PistonWidth
        {
            get
            {
                return _dblPistonWidth;
            }
            set
            {
                _dblPistonWidth = value;
            }
        }

        public string PistonWearRing
        {
            get
            {
                return _strPistonWearRing;
            }
            set
            {
                _strPistonWearRing = value;
            }
        }

        public double PI_MaxDistance_from_RodSide_to_SealGrooveEnd
        {
            get
            {
                return _dblPI_MaxDistance_from_RodSide_to_SealGrooveEnd;
            }
            set
            {
                _dblPI_MaxDistance_from_RodSide_to_SealGrooveEnd = value;
            }
        }

        public string CylinderHeadDesign
        {
            get
            {
                return _strCylinderHeadDesign;
            }
            set
            {
                _strCylinderHeadDesign = value;
            }
        }

        public double ShankLength
        {
            get
            {
                return _dblShankLength;
            }
            set
            {
                _dblShankLength = value;
            }
        }

        public double CounterBoreDepth
        {
            get
            {
                return _dblCounterBoreDepth;
            }
            set
            {
                _dblCounterBoreDepth = value;
            }
        }

        public double NoseLength
        {
            get
            {
                return _dblNoseLength;
            }
            set
            {
                _dblNoseLength = value;
            }
        }

        public double CylinderThreadedHeadChamferLength
        {
            get
            {
                return _dblCylinderThreadedHeadChamferLength;
            }
            set
            {
                _dblCylinderThreadedHeadChamferLength = value;
            }
        }

        bool IsCompressedSelected
        {
            get
            {
                return _blnIsCompressedSelected;
            }
            set
            {
                _blnIsCompressedSelected = value;
            }
        }

        public string BEDLPartCode
        {
            get
            {
                return _StrBEDLPartCode;
            }
            set
            {
                _StrBEDLPartCode = value;
            }
        }

        public string BaseEndCodeNumber90
        {
            get
            {
                return _strBaseEndCodeNumber90;
            }
            set
            {
                _strBaseEndCodeNumber90 = value;
            }
        }

        public string BaseEndCodeNumber
        {
            get
            {
                return _strBaseEndCodeNumber;
            }
            set
            {
                _strBaseEndCodeNumber = value;
            }
        }

        public string CollarCodeNumber
        {
            get
            {
                return _strRodEndCollarCodeNumber;
            }
            set
            {
                _strRodEndCollarCodeNumber = value;
            }
        }

        public double OriginalTubeLength
        {
            get
            {
                return _dblOriginalTubeLength;
            }
            set
            {
                _dblOriginalTubeLength = value;
            }
        }

        public string DesignType
        {
            get
            {
                return _strDesignType;
            }
            set
            {
                _strDesignType = value;
            }
        }

        public string DesignType2
        {
            get
            {
                return _strDesignType2;
            }
            set
            {
                _strDesignType2 = value;
            }
        }

        public string BaseEndConfiguration
        {
            get
            {
                return _strBaseEndConfiguration;
            }
            set
            {
                _strBaseEndConfiguration = value;
            }
        }

        public string BaseEndPort
        {
            get
            {
                return _strBaseEndPort;
            }
            set
            {
                _strBaseEndPort = value;
            }
        }

        public string PortInsertion
        {
            get
            {
                return _strPortInsertion;
            }
            set
            {
                _strPortInsertion = value;
            }
        }

        public double TubeOD
        {
            get
            {
                return _dblTubeOD;
            }
            set
            {
                _dblTubeOD = value;
            }
        }

        public double TubeWallThickness
        {
            get
            {
                return _dblTubeWallThickness;
            }
            set
            {
                _dblTubeWallThickness = value;
            }
        }

        public double PinHoleSize
        {
            get
            {
                return _dblPinHoleSize;
            }
            set
            {
                _dblPinHoleSize = value;
            }
        }

        public double LugGap
        {
            get
            {
                return _dblLugGap;
            }
            set
            {
                _dblLugGap = value;
            }
        }

        public double BushingQuantity
        {
            get
            {
                return _dblBushingQuantity;
            }
            set
            {
                _dblBushingQuantity = value;
            }
        }

        public double SwingClearance
        {
            get
            {
                return _dblSwingClearance;
            }
            set
            {
                _dblSwingClearance = value;
            }
        }

        public double SwingClearance2
        {
            get
            {
                return _dblSwingClearance2;
            }
            set
            {
                _dblSwingClearance2 = value;
            }
        }

        public double BushingWidth
        {
            get
            {
                return _dblBushingWidth;
            }
            set
            {
                _dblBushingWidth = value;
            }
        }

        public double LugThickness
        {
            get
            {
                return _dblLugThickness;
            }
            set
            {
                _dblLugThickness = value;
            }
        }

        public double LugThickness2
        {
            get
            {
                return _dblLugThickness2;
            }
            set
            {
                _dblLugThickness2 = value;
            }
        }

        public double GreaseZercs
        {
            get
            {
                return _dblGreaseZercs;
            }
            set
            {
                _dblGreaseZercs = value;
            }
        }

        public double GreaseZercAngle1
        {
            get
            {
                return _dblGreaseZercAngle1;
            }
            set
            {
                _dblGreaseZercAngle1 = value;
            }
        }

        public double GreaseZercAngle2
        {
            get
            {
                return _dblGreaseZercAngle2;
            }
            set
            {
                _dblGreaseZercAngle2 = value;
            }
        }

        public string TubeMaterial
        {
            get
            {
                return _strTubeMaterial;
            }
            set
            {
                _strTubeMaterial = value;
            }
        }

        public double LugWidth
        {
            get
            {
                return _dblLugWidth;
            }
            set
            {
                _dblLugWidth = value;
            }
        }

        public double LugWidth2
        {
            get
            {
                return _dblLugWidth2;
            }
            set
            {
                _dblLugWidth2 = value;
            }
        }

        public string PinWithInTubeDiameter
        {
            get
            {
                return _strPinWithInTubeDiameter;
            }
            set
            {
                _strPinWithInTubeDiameter = value;
            }
        }

        public double AreaRequired
        {
            get
            {
                return _dblAreaRequired;
            }
            set
            {
                _dblAreaRequired = value;
            }
        }

        public double YRequired
        {
            get
            {
                return _dblYRequired;
            }
            set
            {
                _dblYRequired = value;
            }
        }

        public double OutSidePlugDiameter
        {
            get
            {
                return _dblOutSidePlugDiameter;
            }
            set
            {
                _dblOutSidePlugDiameter = value;
            }
        }

        public double MilledFlatWidth
        {
            get
            {
                return _dblMilledFlatWidth;
            }
            set
            {
                _dblMilledFlatWidth = value;
            }
        }

        public double MilledFlatHeight
        {
            get
            {
                return _dblMilledFlatHeight;
            }
            set
            {
                _dblMilledFlatHeight = value;
            }
        }

        public double CrossTubeWidth
        {
            get
            {
                return _dblCrossTubeWidth;
            }
            set
            {
                _dblCrossTubeWidth = value;
            }
        }

        public double CrossTubeWidth2
        {
            get
            {
                return _dblCrossTubeWidth2;
            }
            set
            {
                _dblCrossTubeWidth2 = value;
            }
        }

        public double OffSet
        {
            get
            {
                return _dblOffSet;
            }
            set
            {
                _dblOffSet = value;
            }
        }

        public string PistonLocation
        {
            get
            {
                return _strPistonLocation.ToUpper();
            }
            set
            {
                _strPistonLocation = value;
            }
        }

        public string WeldType
        {
            get
            {
                return _strWeldType.ToUpper();
            }
            set
            {
                _strWeldType = value;
            }
        }

        public double ThreadDiameter
        {
            get
            {
                return _dblThreadDiameter;
            }
            set
            {
                _dblThreadDiameter = value;
            }
        }

        public double ThreadLength
        {
            get
            {
                return _dblThreadLength;
            }
            set
            {
                _dblThreadLength = value;
            }
        }

        public string PinHoleType
        {
            get
            {
                return _strPinHoleType;
            }
            set
            {
                _strPinHoleType = value;
            }
        }

        public double ToleranceUpperLimit
        {
            get
            {
                return _dblToleranceUpperLimit;
            }
            set
            {
                _dblToleranceUpperLimit = value;
            }
        }

        public double ToleranceLowerLimit
        {
            get
            {
                return _dblToleranceLowerLimit;
            }
            set
            {
                _dblToleranceLowerLimit = value;
            }
        }

        public double SafetyFactor_BaseEnd
        {
            get
            {
                return _dblSafetyFactor_BaseEnd;
            }
            set
            {
                _dblSafetyFactor_BaseEnd = value;
            }
        }

        public double SafetyFactor_BaseEnd2
        {
            get
            {
                return _dblSafetyFactor_BaseEnd2;
            }
            set
            {
                _dblSafetyFactor_BaseEnd2 = value;
            }
        }

        public double SafetyFactor_RodEnd
        {
            get
            {
                return _dblSafetyFactor_RodEnd;
            }
            set
            {
                _dblSafetyFactor_RodEnd = value;
            }
        }

        public double SafetyFactor_RodEnd2
        {
            get
            {
                return _dblSafetyFactor_RodEnd2;
            }
            set
            {
                _dblSafetyFactor_RodEnd2 = value;
            }
        }

        public string MilledFlat
        {
            get
            {
                return _strMilledFlat;
            }
            set
            {
                _strMilledFlat = value;
            }
        }

        public double RodLength
        {
            get
            {
                return _dblRodLength;
            }
            set
            {
                _dblRodLength = value;
            }
        }

        public double BushingOD_BaseEnd
        {
            get
            {
                return _dblBushingOD_BaseEnd;
            }
            set
            {
                _dblBushingOD_BaseEnd = value;
            }
        }

        public string PinsYesOrNo
        {
            get
            {
                return _strPinsYesOrNo;
            }
            set
            {
                _strPinsYesOrNo = value;
            }
        }

        public string ISBushingStyle_2BushingsIndividualBore
        {
            get
            {
                return _strISBushingStyle_2BushingsIndividualBore;
            }
            set
            {
                _strISBushingStyle_2BushingsIndividualBore = value;
            }
        }

        public string ISBushingStyle_2BushingsIndividualBore_RodEnd
        {
            get
            {
                return _strISBushingStyle_2BushingsIndividualBore_RodEnd;
            }
            set
            {
                _strISBushingStyle_2BushingsIndividualBore_RodEnd = value;
            }
        }

        public double Dimension8
        {
            get
            {
                return _dblDimension8;
            }
            set
            {
                _dblDimension8 = value;
            }
        }

        public double RulesID_Rod
        {
            get
            {
                return _dblRulesID_Rod;
            }
            set
            {
                _dblRulesID_Rod = value;
            }
        }

        public string PortType_RodEnd
        {
            get
            {
                return _strPortType_RodEnd;
            }
            set
            {
                _strPortType_RodEnd = value;
            }
        }

        public string PortType_BaseEnd
        {
            get
            {
                return _strPortType_BaseEnd;
            }
            set
            {
                _strPortType_BaseEnd = value;
            }
        }

        public double PortFirstOrientation
        {
            get
            {
                return _dblPortFirstOrientation;
            }
            set
            {
                _dblPortFirstOrientation = value;
            }
        }

        public double PortSecondOrientation
        {
            get
            {
                return _dblPortSecondOrientation;
            }
            set
            {
                _dblPortSecondOrientation = value;
            }
        }

        public string PortSize_BaseEnd
        {
            get
            {
                return _strPortSize_BaseEnd;
            }
            set
            {
                _strPortSize_BaseEnd = value;
            }
        }

        public string PortSize_RodEnd
        {
            get
            {
                return _strPortSize_RodEnd;
            }
            set
            {
                _strPortSize_RodEnd = value;
            }
        }

        public int PortQuantity
        {
            get
            {
                return _intPortQuantity;
            }
            set
            {
                _intPortQuantity = value;
            }
        }

        public double OrificeSize_RodEnd
        {
            get
            {
                return _dblOrificeSize_RodEnd;
            }
            set
            {
                _dblOrificeSize_RodEnd = value;
            }
        }

        public double OrificeSize_BaseEnd
        {
            get
            {
                return _dblOrificeSize_BaseEnd;
            }
            set
            {
                _dblOrificeSize_BaseEnd = value;
            }
        }

        public double NoOfPorts_BaseEnd
        {
            get
            {
                return _dblNoOfPorts;
            }
            set
            {
                _dblNoOfPorts = value;
            }
        }

        public double NoOfPorts_RodEnd
        {
            get
            {
                return _dblNoOfPorts_RodEnd;
            }
            set
            {
                _dblNoOfPorts_RodEnd = value;
            }
        }

        public double PortAccessoryType_BaseEnd
        {
            get
            {
                return _dblPortAccessoryType_baseEnd;
            }
            set
            {
                _dblPortAccessoryType_baseEnd = value;
            }
        }

        public double PortAccessoryType_RodEnd
        {
            get
            {
                return _dblPortAccessoryType_RodEnd;
            }
            set
            {
                _dblPortAccessoryType_RodEnd = value;
            }
        }

        public double FirstPortOrientation_BaseEnd
        {
            get
            {
                return _dblFirstPortOrientation_BaseEnd;
            }
            set
            {
                _dblFirstPortOrientation_BaseEnd = value;
            }
        }

        public double SecondPortOrientation_BaseEnd
        {
            get
            {
                return _dblSecondPortOrientation_BaseEnd;
            }
            set
            {
                _dblSecondPortOrientation_BaseEnd = value;
            }
        }

        public double FirstPortOrientation_RodEnd
        {
            get
            {
                return _dblFirstPortOrientation_RodEnd;
            }
            set
            {
                _dblFirstPortOrientation_RodEnd = value;
            }
        }

        public double SecondPortOrientation_RodEnd
        {
            get
            {
                return _dblSecondPortOrientation_RodEnd;
            }
            set
            {
                _dblSecondPortOrientation_RodEnd = value;
            }
        }

        public double StandardRunQuantity
        {
            get
            {
                return _dblStandardRunQuantity;
            }
            set
            {
                _dblStandardRunQuantity = value;
            }
        }

        public DataTable MatchedBEDLCastingDataTable
        {
            get
            {
                return _oMatchedBEDLCastingDataTable;
            }
            set
            {
                _oMatchedBEDLCastingDataTable = value;
            }
        }

        public string PartCodeFromUlugCode
        {
            get
            {
                return _strPartCodeFromUlugCode;
            }
            set
            {
                _strPartCodeFromUlugCode = value;
            }
        }

        public double BendRadius_BaseEnd
        {
            get
            {
                return _dblBendRadius_BaseEnd;
            }
            set
            {
                _dblBendRadius_BaseEnd = value;
            }
        }


        public DataTable MatchedBEBPCastingDataTable
        {
            get
            {
                return _oMatchedBEBPCastingDataTable;
            }
            set
            {
                _oMatchedBEBPCastingDataTable = value;
            }
        }

        public double BPBushingWidth
        {
            get
            {
                return _dblBPBushingWidth;
            }
            set
            {
                _dblBPBushingWidth = value;
            }
        }

        public double BasePlugODPortIntegral
        {
            get
            {
                return _dblBPODPortIntegral;
            }
            set
            {
                _dblBPODPortIntegral = value;
            }
        }

        public double BasePlugOutSidePlugDiameterRequiredPortIntegral
        {
            get
            {
                return _dblOutSidePlugDiameterRequiredPortIntegral;
            }
            set
            {
                _dblOutSidePlugDiameterRequiredPortIntegral = value;
            }
        }

        public DataTable BEMatchedThreadedEndcastingDataTable
        {
            get
            {
                return _oMatchedBEThreadedEndCastingDataTable;
            }
            set
            {
                _oMatchedBEThreadedEndCastingDataTable = value;
            }
        }

        public DataTable MatchedBHCastingDataTable
        {
            get
            {
                return _oMatchedBHCastingDataTable;
            }
            set
            {
                _oMatchedBHCastingDataTable = value;
            }
        }

        public DataTable MatchedBESLCastingDataTable
        {
            get
            {
                return _oMatchedBESLCastingDataTable;
            }
            set
            {
                _oMatchedBESLCastingDataTable = value;
            }
        }

        public DataTable MatchedBECrossTubeCastingDataTable
        {
            get
            {
                return _oMatchedBECrossTubeCastingDataTable;
            }
            set
            {
                _oMatchedBECrossTubeCastingDataTable = value;
            }
        }

        public double CrossTubeOD
        {
            get
            {
                return _dblCrossTubeOD;
            }
            set
            {
                if ((value > 0))
                {
                    value = Math.Round((value / 0.125));
                    value = (value * 0.125);
                }
                _dblCrossTubeOD = value;
            }
        }

        public double CrossTubeOD2
        {
            get
            {
                return _dblCrossTubeOD2;
            }
            set
            {
                if ((value > 0))
                {
                    value = Math.Round((value / 0.125));
                    value = (value * 0.125);
                }
                _dblCrossTubeOD2 = value;
            }
        }

        public double RadiusConstant
        {
            get
            {
                return 0.06;
            }
        }

        public string RodEndConfiguration
        {
            get
            {
                return _strRodEndConfiguration;
            }
            set
            {
                _strRodEndConfiguration = value;
            }
        }

        public double LugThickness_RodEnd
        {
            get
            {
                return _dblLugThickness_RodEnd;
            }
            set
            {
                _dblLugThickness_RodEnd = value;
            }
        }

        public double LugGap_RodEnd
        {
            get
            {
                return _dblLugGap_RodEnd;
            }
            set
            {
                _dblLugGap_RodEnd = value;
            }
        }

        public double SwingClearance_RodEnd
        {
            get
            {
                return _dblSwingClearance_RodEnd;
            }
            set
            {
                _dblSwingClearance_RodEnd = value;
            }
        }

        public double SwingClearance_RodEnd2
        {
            get
            {
                return _dblSwingClearance_RodEnd2;
            }
            set
            {
                _dblSwingClearance_RodEnd2 = value;
            }
        }

        public double lugHeight_RodEnd
        {
            get
            {
                return _dblLugHeight_RodEnd;
            }
            set
            {
                _dblLugHeight_RodEnd = value;
            }
        }

        public double lugHeight_BaseEnd
        {
            get
            {
                return _dblLugHeight_BaseEnd;
            }
            set
            {
                _dblLugHeight_BaseEnd = value;
            }
        }

        public string Pins_RodEnd
        {
            get
            {
                return _strPins_RodEnd;
            }
            set
            {
                _strPins_RodEnd = value;
            }
        }

        public string Clips_RodEnd
        {
            get
            {
                return _strClips_RodEnd;
            }
            set
            {
                _strClips_RodEnd = value;
            }
        }

        public double CrossTubeWidth_RodEnd
        {
            get
            {
                return _dblCrossTubeWidth_RodEnd;
            }
            set
            {
                _dblCrossTubeWidth_RodEnd = value;
            }
        }

        public double CrossTubeWidth_RodEnd2
        {
            get
            {
                return _dblCrossTubeWidth_RodEnd2;
            }
            set
            {
                _dblCrossTubeWidth_RodEnd2 = value;
            }
        }

        public double BushingQuantity_RodEnd
        {
            get
            {
                return _dblBushingQuantity_RodEnd;
            }
            set
            {
                _dblBushingQuantity_RodEnd = value;
            }
        }

        public double BushingPinHoleSize_RodEnd
        {
            get
            {
                return _dblBushingPinHoleSize_RodEnd;
            }
            set
            {
                _dblBushingPinHoleSize_RodEnd = value;
            }
        }

        public double BushingWidth_RodEnd
        {
            get
            {
                return _dblBushingWidth_RodEnd;
            }
            set
            {
                _dblBushingWidth_RodEnd = value;
            }
        }

        public double PinHoleSize_RodEnd
        {
            get
            {
                return _dblPinHoleSize_RodEnd;
            }
            set
            {
                _dblPinHoleSize_RodEnd = value;
            }
        }

        public double GreaseZercs_RodEnd
        {
            get
            {
                return _dblGreaseZercs_RodEnd;
            }
            set
            {
                _dblGreaseZercs_RodEnd = value;
            }
        }

        public string BushingType_RodEnd
        {
            get
            {
                return _strBushingType_RodEnd;
            }
            set
            {
                _strBushingType_RodEnd = value;
            }
        }

        public double GreaseZercAngle1_RodEnd
        {
            get
            {
                return _dblGreaseZercAngle1_RodEnd;
            }
            set
            {
                _dblGreaseZercAngle1_RodEnd = value;
            }
        }

        public double GreaseZercAngle2_RodEnd
        {
            get
            {
                return _dblGreaseZercAngle2_RodEnd;
            }
            set
            {
                _dblGreaseZercAngle2_RodEnd = value;
            }
        }

        public double Cost_RodEnd
        {
            get
            {
                return _dblCost_RodEnd;
            }
            set
            {
                _dblCost_RodEnd = value;
            }
        }

        public double LugWidth_RodEnd
        {
            get
            {
                return _dblLugWidth_RodEnd;
            }
            set
            {
                _dblLugWidth_RodEnd = value;
            }
        }

        public double LugWidth_RodEnd2
        {
            get
            {
                return _dblLugWidth_RodEnd2;
            }
            set
            {
                _dblLugWidth_RodEnd2 = value;
            }
        }

        public double AreaRequired_RodEnd
        {
            get
            {
                return _dblAreaRequired_RodEnd;
            }
            set
            {
                _dblAreaRequired_RodEnd = value;
            }
        }

        public double YRequired_RodEnd
        {
            get
            {
                return _dblYRequired_RodEnd;
            }
            set
            {
                _dblYRequired_RodEnd = value;
            }
        }

        public double ToleranceUpperLimit_RodEnd
        {
            get
            {
                return _dblToleranceUpperLimit_RodEnd;
            }
            set
            {
                _dblToleranceUpperLimit_RodEnd = value;
            }
        }

        public double ToleranceLowerLimit_RodEnd
        {
            get
            {
                return _dblToleranceLowerLimit_RodEnd;
            }
            set
            {
                _dblToleranceLowerLimit_RodEnd = value;
            }
        }

        public string PinHoleSizeType_RodEnd
        {
            get
            {
                return _strPinHoleSizeType;
            }
            set
            {
                _strPinHoleSizeType = value;
            }
        }

        public string PinHoleType_Threaded_RodEnd_DL
        {
            get
            {
                return _strPinHoleTypeThreaded_RE_DL;
            }
            set
            {
                _strPinHoleTypeThreaded_RE_DL = value;
            }
        }

        public string ConnectionType
        {
            get
            {
                return _strConnectionType;
            }
            set
            {
                _strConnectionType = value;
            }
        }

        public double REDistanceFromPinholetoRodStop
        {
            get
            {
                double dblValue;

                if (((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd == "Cast")
                            && (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd == "NewDesign")))
                {
                    if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration == "Double Lug"))
                    {
                        dblValue = ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd / 2) + (0.5 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd));
                    }
                    else
                    {
                        dblValue = (0.5 + modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd);
                    }
                    return dblValue;
                }
                else if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd == "Fabricated"))
                {
                    if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration == "Cross Tube"))
                    {
                        dblValue = (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd / 2);
                        return dblValue;
                    }
                    else if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration == "Double Lug"))
                    {
                        double dblBendRadius;
                        if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd <= 0.5))
                        {
                            dblBendRadius = 0.25;
                        }
                        else if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd <= 0.63))
                        {
                            dblBendRadius = 0.5;
                        }
                        else
                        {
                            dblBendRadius = 0.625;
                        }
                        dblValue = (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
                                    + (dblBendRadius + modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd));
                        return dblValue;
                    }
                }
                return _dblREDistanceFromPinholetoRodStop;
            }
            set
            {
                _dblREDistanceFromPinholetoRodStop = value;
            }
        }

        public double REDistanceFromPinholetoRodStop2
        {
            get
            {
                double dblValue;

                if (((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd2 == "Cast")
                            && (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd2 == "NewDesign")))
                {
                    if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration == "Double Lug"))
                    {
                        dblValue = ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd / 2) + (0.5 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd));
                    }
                    else
                    {
                        dblValue = (0.5 + modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd2);
                    }
                    return dblValue;
                }
                else if (((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd == "Fabricated")
                            || (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd2 == "Fabricated")))
                {
                    if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration == "Cross Tube"))
                    {
                        dblValue = (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd2 / 2);
                        return dblValue;
                    }
                    else if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration == "Double Lug"))
                    {
                        double dblBendRadius;
                        if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd <= 0.5))
                        {
                            dblBendRadius = 0.25;
                        }
                        else if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd <= 0.63))
                        {
                            dblBendRadius = 0.5;
                        }
                        else
                        {
                            dblBendRadius = 0.625;
                        }
                        dblValue = (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
                                    + (dblBendRadius + modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd));
                        return dblValue;
                    }
                }
                return _dblREDistanceFromPinholetoRodStop2;
            }
            set
            {
                _dblREDistanceFromPinholetoRodStop2 = value;
            }
        }

        public double OffSet_RodEnd
        {
            get
            {
                return _dblOffSet_RodEnd;
            }
            set
            {
                _dblOffSet_RodEnd = value;
            }
        }

        public string ConfigurationDesign_RodEnd
        {
            get
            {
                return _strConfigurationDesign_RodEnd;
            }
            set
            {
                _strConfigurationDesign_RodEnd = value;
            }
        }

        public string ConfigurationDesign_RodEnd2
        {
            get
            {
                return _strConfigurationDesign_RodEnd2;
            }
            set
            {
                _strConfigurationDesign_RodEnd2 = value;
            }
        }

        public string ConfigurationDesignType_RodEnd
        {
            get
            {
                return _strConfigurationDesignType_RodEnd;
            }
            set
            {
                _strConfigurationDesignType_RodEnd = value;
            }
        }

        public string ConfigurationDesignType_RodEnd2
        {
            get
            {
                return _strConfigurationDesignType_RodEnd2;
            }
            set
            {
                _strConfigurationDesignType_RodEnd2 = value;
            }
        }

        public string ConfigurationCode_RodEnd
        {
            get
            {
                return _strConfigurationCode_RodEnd;
            }
            set
            {
                _strConfigurationCode_RodEnd = value;
            }
        }

        public string ConfigurationCode_RodEnd2
        {
            get
            {
                return _strConfigurationCode_RodEnd2;
            }
            set
            {
                _strConfigurationCode_RodEnd2 = value;
            }
        }

        public string strRodEndConfigurationDesign
        {
            get
            {
                return _strRodEndConfigurationDesign;
            }
            set
            {
                _strRodEndConfigurationDesign = value;
            }
        }

        public string PinHoleType_RodEnd
        {
            get
            {
                return _strPinHoleType_RodEnd;
            }
            set
            {
                _strPinHoleType_RodEnd = value;
            }
        }

        public string MilledFlat_RE
        {
            get
            {
                return _strMilledFlat_RE;
            }
            set
            {
                _strMilledFlat_RE = value;
            }
        }

        public string BushingPartCode_RodEnd
        {
            get
            {
                return _strBushingPartCode_RodEnd;
            }
            set
            {
                _strBushingPartCode_RodEnd = value;
            }
        }

        public double BushingOD_RodEnd
        {
            get
            {
                return _dblBushingOD_RodEnd;
            }
            set
            {
                _dblBushingOD_RodEnd = value;
            }
        }

        public double ChamferAngle_RodEnd
        {
            get
            {
                return _dblChamferAngle_RodEnd;
            }
            set
            {
                _dblChamferAngle_RodEnd = value;
            }
        }

        public double ChamferSize_RodEnd
        {
            get
            {
                return _dblChamferSize_RodEnd;
            }
            set
            {
                _dblChamferSize_RodEnd = value;
            }
        }

        public string ThreadType_RodEnd
        {
            get
            {
                return _strThreadType_RodEnd;
            }
            set
            {
                _strThreadType_RodEnd = value;
            }
        }

        public double ThreadSize_RodEnd
        {
            get
            {
                return _dblThreadSize_RodEnd;
            }
            set
            {
                _dblThreadSize_RodEnd = value;
            }
        }

        public double ThreadLength_RodEnd
        {
            get
            {
                return _dblThreadLength_RodEnd;
            }
            set
            {
                _dblThreadLength_RodEnd = value;
            }
        }

        public double AcrossFlatValue_RodEnd
        {
            get
            {
                return _dblAcrossFlatValue_RodEnd;
            }
            set
            {
                _dblAcrossFlatValue_RodEnd = value;
            }
        }

        public double FlatLength_RodEnd
        {
            get
            {
                return _dblFlatLength_RodEnd;
            }
            set
            {
                _dblFlatLength_RodEnd = value;
            }
        }

        public double OverAllCylinderLength
        {
            get
            {
                return _dblOverAllCylinderLength;
            }
            set
            {
                _dblOverAllCylinderLength = value;
            }
        }

        public double ExtraRodButtonLength
        {
            get
            {
                return _dblExtraRodButtonLength;
            }
            set
            {
                _dblExtraRodButtonLength = value;
            }
        }

        public string ExtraRodButton
        {
            get
            {
                return _strExtraRodButton;
            }
            set
            {
                _strExtraRodButton = value;
            }
        }

        public double PortEndDistanceFromTubeEnd
        {
            get
            {
                return _strPortEndDistanceFromTubeEnd;
            }
            set
            {
                _strPortEndDistanceFromTubeEnd = value;
            }
        }

        public double OffsetPortOrifice
        {
            get
            {
                return _dblOffsetPortOrifice;
            }
            set
            {
                _dblOffsetPortOrifice = value;
            }
        }

        public double StickOut
        {
            get
            {
                return _dblStickOut;
            }
            set
            {
                _dblStickOut = value;
            }
        }

        public double SkimWidth
        {
            get
            {
                return _dblSkimWidth;
            }
            set
            {
                _dblSkimWidth = value;
            }
        }

        public bool ISFabricationChecked
        {
            get
            {
                return _blnISFabricationChecked;
            }
            set
            {
                _blnISFabricationChecked = value;
            }
        }

        public bool IsCounterBoreChecked
        {
            get
            {
                return _blnIsCounterBoreChecked;
            }
            set
            {
                _blnIsCounterBoreChecked = value;
            }
        }

        public bool SkipRetractedIfPositiveFromGenerate
        {
            get
            {
                return _blnSkipRetractedIfPositiveFromGenerate;
            }
            set
            {
                _blnSkipRetractedIfPositiveFromGenerate = value;
            }
        }

        public bool GoToBaseEndScreenFromRetractedScreen
        {
            get
            {
                return _blnGoToBaseEndScreenFromRetractedScreen;
            }
            set
            {
                _blnGoToBaseEndScreenFromRetractedScreen = value;
            }
        }

        public bool GoToRodEndScreenFromRetractedScreen
        {
            get
            {
                return _blnGoToRodEndScreenFromRetractedScreen;
            }
            set
            {
                _blnGoToRodEndScreenFromRetractedScreen = value;
            }
        }

        public DataTable MatchedRECrossTubeCastingDataTable
        {
            get
            {
                return _oMatchedRECrossTubeCastingDataTable;
            }
            set
            {
                _oMatchedRECrossTubeCastingDataTable = value;
            }
        }

        public double CrossTubeOD_RodEnd
        {
            get
            {
                return _dblCrossTubeOD_RodEnd;
            }
            set
            {
                if ((value > 0))
                {
                    value = Math.Round((value / 0.125));
                    value = (value * 0.125);
                }
                _dblCrossTubeOD_RodEnd = value;
            }
        }

        public double CrossTubeOD_RodEnd2
        {
            get
            {
                return _dblCrossTubeOD_RodEnd2;
            }
            set
            {
                if ((value > 0))
                {
                    value = Math.Round((value / 0.125));
                    value = (value * 0.125);
                }
                _dblCrossTubeOD_RodEnd2 = value;
            }
        }

        // 06_03_2010  RAGAVA
        public double WeldSize_RodEndCT
        {
            get
            {
                return _dblWeldSize_RECT;
            }
            set
            {
                _dblWeldSize_RECT = value;
            }
        }

        public double WeldSize_RodEndDL
        {
            get
            {
                return _dblWeldSize_REDL;
            }
            set
            {
                _dblWeldSize_REDL = value;
            }
        }

        public DataTable MatchedREDLCastingDataTable
        {
            get
            {
                return _oMatchedREDlCastingDataTable;
            }
            set
            {
                _oMatchedREDlCastingDataTable = value;
            }
        }

        public DataTable MatchedREDLThreadedDataTable
        {
            get
            {
                return _oMatchedREDLThreadedDataTable;
            }
            set
            {
                _oMatchedREDLThreadedDataTable = value;
            }
        }

        public double BendRadius_RodEnd
        {
            get
            {
                return _dblBendRadius_RodEnd;
            }
            set
            {
                _dblBendRadius_RodEnd = value;
            }
        }

        public string PilotHoleDiameter
        {
            get
            {
                return _strPilotHoleDiameter;
            }
            set
            {
                _strPilotHoleDiameter = value;
            }
        }

        public string ClevisPlateCode
        {
            get
            {
                return _strClevisPlateCode;
            }
            set
            {
                _strClevisPlateCode = value;
            }
        }

        public string ClevisPlateCode2
        {
            get
            {
                return _strClevisPlateCode2;
            }
            set
            {
                _strClevisPlateCode2 = value;
            }
        }

        public string ConfigurationCode_BaseEnd
        {
            get
            {
                return _strConfigurationCode_BaseEnd;
            }
            set
            {
                _strConfigurationCode_BaseEnd = value;
            }
        }

        public string ConfigurationCode_BaseEnd2
        {
            get
            {
                return _strConfigurationCode_BaseEnd2;
            }
            set
            {
                _strConfigurationCode_BaseEnd2 = value;
            }
        }

        public string CounterBoreClevisPlateCode
        {
            get
            {
                return _strCounterBoreClevisPlateCode;
            }
            set
            {
                _strCounterBoreClevisPlateCode = value;
            }
        }

        public double CounterBoreClevisPlateThickness
        {
            get
            {
                return _dblCounterBoreClevisPlateThickness;
            }
            set
            {
                _dblCounterBoreClevisPlateThickness = value;
            }
        }

        public double CounterboredClevisPlateRodStopDistance
        {
            get
            {
                return _dblCounterboredClevisPlateRodStopDistance;
            }
            set
            {
                _dblCounterboredClevisPlateRodStopDistance = value;
            }
        }

        public double ClevisPlateThickness
        {
            get
            {
                return _dblClevisPlateThickness;
            }
            set
            {
                _dblClevisPlateThickness = value;
            }
        }

        public double ClevisPlateThickness2
        {
            get
            {
                return _dblClevisPlateThickness2;
            }
            set
            {
                _dblClevisPlateThickness2 = value;
            }
        }

        public double ClevisPlateRodStopDistance
        {
            get
            {
                return _dblClevisPlateRodStopDistance;
            }
            set
            {
                _dblClevisPlateRodStopDistance = value;
            }
        }

        public string clevisplatePartFilePath
        {
            get
            {
                return _strClevisplatePartFilePath;
            }
            set
            {
                _strClevisplatePartFilePath = value;
            }
        }

        public string ClevisPlateImportOrExisting
        {
            get
            {
                return _strClevisPlateImportOrExisting;
            }
            set
            {
                _strClevisPlateImportOrExisting = value;
            }
        }

        public string ClevisPlateImportOrExisting2
        {
            get
            {
                return _strClevisPlateImportOrExisting2;
            }
            set
            {
                _strClevisPlateImportOrExisting2 = value;
            }
        }

        public double PullForce
        {
            get
            {
                return _dblPullForce;
            }
            set
            {
                _dblPullForce = value;
            }
        }

        public double PullForce_RodEnd
        {
            get
            {
                return _dblPullForce_RodEnd;
            }
            set
            {
                _dblPullForce_RodEnd = value;
            }
        }

        public Hashtable FolderDeletionHashTable
        {
            get
            {
                return _htFolderDeletion;
            }
            set
            {
                _htFolderDeletion = value;
            }
        }

        public double WeldSize_RodEnd
        {
            get
            {
                return _dblWeldSize_RodEnd;
            }
            set
            {
                _dblWeldSize_RodEnd = value;
            }
        }

        public double JGrooveWidth_RodEnd
        {
            get
            {
                return _dblJGrooveWidth_RodEnd;
            }
            set
            {
                _dblJGrooveWidth_RodEnd = value;
            }
        }

        public double JGrooveRadius_RodEnd
        {
            get
            {
                return _dblJGrooveRadius_RodEnd;
            }
            set
            {
                _dblJGrooveRadius_RodEnd = value;
            }
        }

        public string WeldPreperation_RodEnd
        {
            get
            {
                return _strWeldPreperation_RodEnd;
            }
            set
            {
                _strWeldPreperation_RodEnd = value;
            }
        }

        public string CustomerName_ContractDetails
        {
            get
            {
                return _strCustomerName_ContractDetails;
            }
            set
            {
                _strCustomerName_ContractDetails = value;
            }
        }

        public string AssemblyType_ContractDetails
        {
            get
            {
                return _strAssemblyType_ContractDetails;
            }
            set
            {
                _strAssemblyType_ContractDetails = value;
            }
        }

        public string PartCode_ContractDetails
        {
            get
            {
                return _strPartCode_ContractDetails;
            }
            set
            {
                _strPartCode_ContractDetails = value;
            }
        }

        public string New_Revision
        {
            get
            {
                return _strNew_Revision;
            }
            set
            {
                _strNew_Revision = value;
            }
        }

        public bool CustomerNameComboBOxChanged
        {
            get
            {
                return _blnCustomerNameComboBOxChanged;
            }
            set
            {
                _blnCustomerNameComboBOxChanged = value;
            }
        }


        public bool UpdateExistedCasting()
        {
            bool success = false;
            try
            {

                if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released == "Released"))
                {
                    string strQuery = ("Update " + (strBaseEndCastingTableName + (" set IsExisted = 'True' where PartCode = " + strBaseEndCastingCodeNumber)));
                    success = modWeldedCylinder.MonarchConnectionObject.ExecuteQuery(strQuery);
                    strQuery = ("Update " + (strRodEndCastingTableName + (" set IsExisted = 'True' where PartCode = " + strRodEndCastingCodeNumber)));
                    success = modWeldedCylinder.MonarchConnectionObject.ExecuteQuery(strQuery);
                }
                return success;
            }
            catch (Exception ex)
            {
                return success = false;
            }
        }


        public double SetSafetyFactorForExisting(string strPartCode_Purchase)
        {
            double SetSafetyFactorForExisting = 0;
            try
            {

                string strQuery = String.Empty;

                strQuery = ("select BaseEndSafetyFactor from Contract_SafetyFactor_Details where BaseEndCodeNumber = '" + (strPartCode_Purchase + "'"));
                DataTable Objdt;
                Objdt = modWeldedCylinder.MonarchConnectionObject.GetTable(strQuery);
                if ((Objdt.Rows.Count > 0))
                {
                    SetSafetyFactorForExisting = Convert.ToDouble(Objdt.Rows[0][0]);
                }
                return SetSafetyFactorForExisting;

            }
            catch (Exception ex)
            {
                return SetSafetyFactorForExisting = 0;

            }
        }

        public double SetSafetyFactorForExisting_RodEnd(string strPartCode_Purchase)
        {
            double SetSafetyFactorForExisting_RodEnd = 0;
            try
            {

                string strQuery = String.Empty;

                strQuery = ("select RodEndSafetyFactor from Contract_SafetyFactor_Details where RodEndCodeNumber = '"
                            + (strPartCode_Purchase + "'"));
                DataTable Objdt;
                Objdt = modWeldedCylinder.MonarchConnectionObject.GetTable(strQuery);
                if ((Objdt.Rows.Count > 0))
                {
                    SetSafetyFactorForExisting_RodEnd = Convert.ToDouble(Objdt.Rows[0][0]);
                }
                return SetSafetyFactorForExisting_RodEnd;

            }
            catch (Exception ex)
            {
                return SetSafetyFactorForExisting_RodEnd = 0;
            }
        }


        public string GetWC_619_622()
        {
            string GetWC_619_622 = String.Empty;
            try
            {

                if ((((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength + modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonWidth) < 6)
                            && (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType == "New")))
                {
                    GetWC_619_622 = "WC622";
                    return GetWC_619_622;
                }

                if (((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter >= 0.5)
                            && ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter <= 2.5)
                            && ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodLength <= 44)
                            && (((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodLength - modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmRetractedLengthValidation.Dim8FromPistonEndofRod)
                            >= 10.75)
                            && ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength <= 54)
                            && ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth <= 6.75)
                            && ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength >= 8)
                            && ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 1.5)
                            && (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 3))))))))))
                {
                    GetWC_619_622 = "WC619";
                }
                else
                {
                    GetWC_619_622 = "WC622";
                }
                return GetWC_619_622;
            }
            catch (Exception ex)
            {
                return GetWC_619_622 = String.Empty;
            }
        }


        public bool ECR_MainFunctionality()
        {
            bool ECR_MainFunctionality = false;
            try
            {
                clsReleaseCylinderFunctionality oClsReleaseCylinderFunctionality = new clsReleaseCylinderFunctionality();

                if (oClsReleaseCylinderFunctionality.ReleaseExcelFunctionality())
                {
                    if (ECR_NewPartsUpdation_ReleaseMenuItem(oClsReleaseCylinderFunctionality))
                    {

                        ECR_MainFunctionality = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ECR_MainFunctionality = false;
            }
        }


        public bool DropReleasedCodeNumbersToDB_ReleaseMenuItemClick()
        {

            bool dropReleasedCodeNumbersToDB_ReleaseMenuItemClick = false;
            try
            {
                if (((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released == "Released")
                            || (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released == "Revision")))
                {

                    string strQuery1 = String.Empty;
                    strQuery1 = ("DELETE FROM [MIL_WELDED].[dbo].[ReleasedCylinderCodes] WHERE ReleasedCylinderCodeNumber = \'"
                                + (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber + "\'"));
                    modWeldedCylinder.MonarchConnectionObject.ExecuteQuery(strQuery1);
                    string strQuery = String.Empty;
                    strQuery = ("INSERT INTO dbo.ReleasedCylinderCodes(ReleasedCylinderCodeNumber) VALUES("
                                + (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber + ")"));
                    dropReleasedCodeNumbersToDB_ReleaseMenuItemClick = modWeldedCylinder.MonarchConnectionObject.ExecuteQuery(strQuery);
                    if ((dropReleasedCodeNumbersToDB_ReleaseMenuItemClick == false))
                    {
                        MessageBox.Show("Error in updating Released Cylinder Code to Data Table", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    return true;
                }
                return dropReleasedCodeNumbersToDB_ReleaseMenuItemClick;

            }
            catch (Exception ex)
            {
                return dropReleasedCodeNumbersToDB_ReleaseMenuItemClick = false;
            }
        }


        public bool ECR_NewPartsUpdation_ReleaseMenuItem(ref clsReleaseCylinderFunctionality oClsReleaseCylinderFunctionality)
        {
            bool ECR_NewPartsUpdation_ReleaseMenuItem = false;
            try
            {
                bool _blnIsNewTubeWeldment;
                bool _blnIsNewRodWeldment;
                bool _blnIsNewCylinderHead;
                bool _blnIsNewPiston;
                bool _blnIsNewSteelCasting_BaseEnd;
                bool _blnIsNewSteelCasting_RodEnd;
                bool _blnIsNewCrossTube_BaseEnd;
                bool _blnIsNewCrossTube_RodEnd;
                bool _blnIsNewStopTube;
                bool _blnIsNewLug_BaseEnd;
                bool _blnIsNewLug_RodEnd;

                string _strQuery = String.Empty;
                DataRow drECR_Details;
                _strQuery = ("select * from StoreECR_PartsDetails_ReleaseOnClick where ContractNumber = \'"
                            + (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber + "\'"));
                drECR_Details = modWeldedCylinder.MonarchConnectionObject.GetDataRow(_strQuery);
                if ((((drECR_Details == null) == false) || (drECR_Details.ItemArray.Length > 0)))
                {
                    string strTubeWeldment = Convert.ToString(drECR_Details["TUBEWELDMENT"]);
                    string strRodWeldment = Convert.ToString(drECR_Details["RODWELDMENT"]);
                    string strStopTube = Convert.ToString(drECR_Details["Stoptube"]);
                    string strSteelCasting_BaseEnd = Convert.ToString(drECR_Details["BaseEndSteelCasting"]);
                    string strSteelCasting_RodEnd = Convert.ToString(drECR_Details["RodEndSteelCasting"]);
                    string strCrossTube_BaseEnd = Convert.ToString(drECR_Details["CrossTube_BaseEnd"]);
                    string strCrossTube_RodEnd = Convert.ToString(drECR_Details["CrossTube_RodEnd"]);
                    string strLug_BaseEnd = Convert.ToString(drECR_Details["Lug_baseEnd"]);
                    string strLug_RodEnd = Convert.ToString(drECR_Details["Lug_RodEnd"]);
                    string strCylinderHeadCode = Convert.ToString(drECR_Details["CylinderHead"]);
                    string strPistonCode = Convert.ToString(drECR_Details["Piston"]);
                    string strCylinderCode = Convert.ToString(drECR_Details["ContractNumber"]);
                    modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = Convert.ToString(drECR_Details["BaseEndCastingTable"]);
                    modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndCastingTableName = Convert.ToString(drECR_Details["RodEndCastingTable"]);
                    modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingCodeNumber = Convert.ToString(drECR_Details["BaseEndCastingCode"]);
                    modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndCastingCodeNumber = Convert.ToString(drECR_Details["RodEndCastingCode"]);
                    if (oClsReleaseCylinderFunctionality.CreateDirectoryForNewExcel())
                    {
                        if ((strCylinderCode != ""))
                        {
                            oClsReleaseCylinderFunctionality._htCodeNumbers.Add("CYLINDER_CODE", strCylinderCode);
                            _blnIsNewTubeWeldment = true;
                        }
                        if ((strTubeWeldment != ""))
                        {
                            oClsReleaseCylinderFunctionality._htCodeNumbers.Add("TUBE_WELDMENT", strTubeWeldment);
                            _blnIsNewTubeWeldment = Convert.ToBoolean(drECR_Details["IsNewTubeWeldment"]);
                        }
                        if ((strRodWeldment != ""))
                        {
                            oClsReleaseCylinderFunctionality._htCodeNumbers.Add("ROD_WELDMENT", strRodWeldment);
                            _blnIsNewRodWeldment = Convert.ToBoolean(drECR_Details["IsNewRodWeldment"]);
                        }
                        if ((strCylinderHeadCode != ""))
                        {
                            oClsReleaseCylinderFunctionality._htCodeNumbers.Add("CYL HEAD", strCylinderHeadCode);
                            _blnIsNewCylinderHead = Convert.ToBoolean(drECR_Details["IsNewCylinderHead"]);
                        }
                        if ((strPistonCode != ""))
                        {
                            oClsReleaseCylinderFunctionality._htCodeNumbers.Add("PISTONCODE", strPistonCode);
                            _blnIsNewPiston = Convert.ToBoolean(drECR_Details["IsNewPiston"]);
                        }
                        if ((strSteelCasting_BaseEnd != ""))
                        {
                            oClsReleaseCylinderFunctionality._htCodeNumbers.Add("BASEEND_STEELCASTING", strSteelCasting_BaseEnd);
                            _blnIsNewSteelCasting_BaseEnd = Convert.ToBoolean(drECR_Details["IsNewBaseEndSteelCasting"]);
                        }
                        if ((strSteelCasting_RodEnd != ""))
                        {
                            oClsReleaseCylinderFunctionality._htCodeNumbers.Add("RODEND_STEELCASTING", strSteelCasting_RodEnd);
                            _blnIsNewSteelCasting_RodEnd = Convert.ToBoolean(drECR_Details["IsNewRodEndSteelCasting"]);
                        }
                        if ((strCrossTube_BaseEnd != ""))
                        {
                            oClsReleaseCylinderFunctionality._htCodeNumbers.Add("CROSSTUBE_BASEEND", strCrossTube_BaseEnd);
                            _blnIsNewCrossTube_BaseEnd = Convert.ToBoolean(drECR_Details["IsNewCrossTube_BaseEnd"]);
                        }
                        if ((strCrossTube_RodEnd != ""))
                        {
                            oClsReleaseCylinderFunctionality._htCodeNumbers.Add("CROSSTUBE_RODEND", strCrossTube_RodEnd);
                            _blnIsNewCrossTube_RodEnd = Convert.ToBoolean(drECR_Details["IsNewCrossTube_RodEnd"]);
                        }
                        if ((strStopTube != ""))
                        {
                            oClsReleaseCylinderFunctionality._htCodeNumbers.Add("Stop_tube", strStopTube);
                            _blnIsNewStopTube = Convert.ToBoolean(drECR_Details["IsNewStopTube"]);
                        }
                        if ((strLug_BaseEnd != ""))
                        {
                            oClsReleaseCylinderFunctionality._htCodeNumbers.Add("LUG_BASEEND", strLug_BaseEnd);
                            _blnIsNewLug_BaseEnd = Convert.ToBoolean(drECR_Details["IsNewLug_baseEnd"]);
                        }
                        if ((strLug_RodEnd != ""))
                        {
                            oClsReleaseCylinderFunctionality._htCodeNumbers.Add("LUG_RodEND", strLug_RodEnd);
                            _blnIsNewLug_RodEnd = Convert.ToBoolean(drECR_Details["IsNewLug_RodEnd"]);
                        }
                        try
                        {
                            DropReleasedCodeNumbersToDB_ReleaseMenuItemClick();

                            if (oClsReleaseCylinderFunctionality.DropDataToNewExcelSheet(drECR_Details))
                            {
                                ECR_NewPartsUpdation_ReleaseMenuItem = true;
                                oClsReleaseCylinderFunctionality.DropRod_Tube_StoptubeCodesToDB(strTubeWeldment, strRodWeldment, strLug_BaseEnd, strLug_RodEnd, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber, strCylinderHeadCode, strPistonCode, strCrossTube_BaseEnd, strCrossTube_RodEnd, strSteelCasting_BaseEnd, strSteelCasting_RodEnd, strStopTube);
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }

                    if (Directory.Exists(("W:\\WELDED\\CMS\\"
                                    + (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString() + "_CMS"))))
                    {
                        Directory.Delete(("W:\\WELDED\\CMS\\"
                                        + (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString() + "_CMS")));
                    }
                    Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
                    //My.Computer.FileSystem.MoveDirectory((" K:\\USR\\_CYLINDER\\CYLOEM\\IFL DWG NR\\WELDED\\CMS\\"
                    //                + (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString()+ "_CMS")), ("W:\\WELDED\\CMS\\"
                    //                + (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString() + "_CMS")));

                    Directory.Move((" K:\\USR\\_CYLINDER\\CYLOEM\\IFL DWG NR\\WELDED\\CMS\\"
                                   + (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString() + "_CMS")), ("W:\\WELDED\\CMS\\"
                                   + (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString() + "_CMS")));

                    if (File.Exists(("K:\\USR\\_CYLINDER\\CYLOEM\\IFL DWG NR\\WELDED\\CNC\\" + ("0"
                                    + (strRodWeldment + "1.MIN")))))
                    {
                        File.Delete(("K:\\USR\\_CYLINDER\\CYLOEM\\IFL DWG NR\\WELDED\\CNC\\" + ("0"
                                        + (strRodWeldment + "1.MIN"))));
                    }
                    //My.Computer.FileSystem.MoveFile(("C:\\WELDED_TESTING\\CNC_TEMP\\" + ("0"
                    //                + (strRodWeldment + "1.MIN"))), ("K:\\USR\\_CYLINDER\\CYLOEM\\IFL DWG NR\\WELDED\\CNC\\" + ("0"
                    //                + (strRodWeldment + "1.MIN"))));
                    File.Move(("C:\\WELDED_TESTING\\CNC_TEMP\\" + ("0" + (strRodWeldment + "1.MIN"))),
                                ("K:\\USR\\_CYLINDER\\CYLOEM\\IFL DWG NR\\WELDED\\CNC\\" + ("0" + (strRodWeldment + "1.MIN"))));

                }
            }
            catch (Exception ex)
            {
                ECR_NewPartsUpdation_ReleaseMenuItem = false;
            }
        }


        public bool InsertData_PartsDetails_ReleaseOnClick()
        {
            try
            {
                bool insertData_PartsDetails_ReleaseOnClick = false;
                string strQuery = String.Empty;
                string strTubeWeldment = Convert.ToString(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable["TUBE_WELDMENT"]);
                string strRodWeldment = Convert.ToString(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable["ROD_WELDMENT"]);
                string strStopTube = Convert.ToString(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable["Stop_tube"]);
                string strSteelCasting_BaseEnd = String.Empty;
                string strSteelCasting_RodEnd = String.Empty;

                strSteelCasting_BaseEnd = Convert.ToString(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable[modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart]);

                if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd == "Cast"))
                {
                    strSteelCasting_RodEnd = Convert.ToString(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable[modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName]);
                }
                string strCrossTube_BaseEnd = Convert.ToString(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable["BASE_CROSSTUBE_IFL"]);
                string strCrossTube_RodEnd = Convert.ToString(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable["CROSSTUBE_ROD"]);
                string strLug_BaseEnd = String.Empty;
                string strLug_RodEnd = String.Empty;

                strLug_BaseEnd = Convert.ToString(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable[modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart]);

                if (((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration.IndexOf("Lug") != -1)
                            && (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated == "Fabricated")))
                {
                    strLug_RodEnd = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd;
                }
                string strCylinderHeadCode = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign._strCH_CylinderHeadCode;
                clsList oExistingListItems_Piston = clsAddExistingCodes._htExistingCostingCodeList(clsAddExistingCodes.PISTONCODE);
                string strPistonCode = oExistingListItems_Piston.strPartCode;
                string strCylinderCode = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber;
                string strBaseTableName = String.Empty;
                string strRodEndTableName = String.Empty;
                strBaseTableName = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName;
                strRodEndTableName = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName;
                if ((strBaseTableName == ""))
                {
                    strBaseTableName = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName;
                }
                if ((strRodEndTableName == ""))
                {
                    strRodEndTableName = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndCastingTableName;
                }
                strQuery = "Insert into StoreECR_PartsDetails_ReleaseOnClick values('"
                            + modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber + "','"
                            + strTubeWeldment + "','"
                            + strRodWeldment + "','"
                            + strStopTube + "','"
                            + strCylinderHeadCode + "','"
                            + strPistonCode + "','"
                            + strSteelCasting_BaseEnd + "','"
                            + strSteelCasting_RodEnd + "','"
                            + strCrossTube_BaseEnd + "','"
                            + strCrossTube_RodEnd + "','"
                            + strLug_BaseEnd + "','"
                            + strLug_RodEnd + "',"
                            + CheckForNewOrExisting(strTubeWeldment) + ","
                            + CheckForNewOrExisting(strRodWeldment) + ","
                            + CheckForNewOrExisting(strStopTube) + ","
                            + CheckForNewOrExisting(strCylinderHeadCode) + ","
                            + CheckForNewOrExisting(strPistonCode) + ","
                            + CheckForNewOrExisting(strSteelCasting_BaseEnd) + ","
                            + CheckForNewOrExisting(strSteelCasting_RodEnd) + ","
                            + CheckForNewOrExisting(strCrossTube_BaseEnd) + ","
                            + CheckForNewOrExisting(strCrossTube_RodEnd) + ","
                            + CheckForNewOrExisting(strLug_BaseEnd) + ","
                            + CheckForNewOrExisting(strLug_RodEnd) + ",'"
                            + strBaseTableName + "','"
                            + strRodEndTableName + "','"
                            + modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingCodeNumber + "\',\'"
                            + modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndCastingCodeNumber + "\')";
                insertData_PartsDetails_ReleaseOnClick = modWeldedCylinder.MonarchConnectionObject.ExecuteQuery(strQuery);
            }
            catch (Exception ex)
            {
            }
        }

        public int CheckForNewOrExisting(string strCode)
        {
            //int CheckForNewOrExisting = 0;

            try
            {

                if ((double.Parse(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= double.Parse(strCode)))
                {
                    return 1;
                }
                else
                {

                    return 0;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}







