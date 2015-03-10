using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Welded.FunctionalLayer;

namespace Welded.DataBaseLayer
{
    class clsWeldedDataClass
    {
        #region Class Variables

        public string ErrorMessage10;
        public DataTable Data;
        public string _strQuery;
        public string _strErrorMessage;

        #endregion

        #region Properties

        public string ErrorMessage
        {
            get
            {
                return _strErrorMessage;
            }
            set
            {
                _strErrorMessage = value;
            }
        }

        #endregion

        #region SubProcedures

        public bool GetConnection()
        {
            bool getConnection = false;
            try
            {
                string strXMLFilePath = (System.Environment.CurrentDirectory + "\\MILWeldedConnection.xml");
                DataSet oDataSet = new DataSet();
                oDataSet.ReadXml(strXMLFilePath);
                if (!(oDataSet.Tables.Count <= 0))
                {
                    string strServer = oDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                    string strDataBase = oDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
                    modWeldedCylinder.MonarchConnectionObject = IFLBaseDataLayer.IFLConnectionClass.GetConnectionObject(strServer, strDataBase, "System.Data.SqlClient", "", "", "SSPI");
                    getConnection = true;

                }
                return getConnection;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error occured while connecting to server", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button3);
                return getConnection = false;
            }
        }


        #endregion

        #region Function

        public DataTable GetTableDetails(string strQuery)
        {
            DataTable getTableDetails = null;
            try
            {

                _strQuery = strQuery;
                getTableDetails = modWeldedCylinder.MonarchConnectionObject.GetTable(_strQuery);
                return getTableDetails;
            }
            catch (Exception ex)
            {
                return getTableDetails = null;
            }
        }

        public double GetPistonNutSize_Bore(string strBoreDiameter)
        {
            double getPistonNutSize_Bore = 0;
            _strQuery = ("SELECT DISTINCT(PistonNutSize) FROM WELDED.TubeDetails WHERE BOREDIAMETER=" + strBoreDiameter);
            getPistonNutSize_Bore = Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
            if ((getPistonNutSize_Bore == 0))
            {

                _strErrorMessage = ("Data not retrieved from TubeDetails table" + "\r\n");
                _strErrorMessage += "PistonNutSize not available for selected BoreDiameter";
                return getPistonNutSize_Bore = 0;
            }
            return getPistonNutSize_Bore;
        }

        public DataTable GetRodDiameters(string strBoreDiameter)
        {
            DataTable getRodDiameters = null;

            _strQuery = " select RODDIAMETER, MaximumPistonNutSize from Welded.RodDiameterDetails where RodDiameter between (select RodDiameter_Min ";
            _strQuery = (_strQuery + ("from Welded.RodDiameterRangeDetails where BoreDiameter = " + (strBoreDiameter + ") and (select RodDiameter_Max ")));
            _strQuery = (_strQuery + ("from Welded.RodDiameterRangeDetails where BoreDiameter = " + (strBoreDiameter + ")")));

            getRodDiameters = modWeldedCylinder.MonarchConnectionObject.GetTable(_strQuery);
            if (((getRodDiameters == null) || (getRodDiameters.Rows.Count == 0)))
            {

                _strErrorMessage = ("Data not retrieved from RodDiameterDetails table" + "\r\n");
                _strErrorMessage += "RodDiameter and MaximumPistonNutSize not available for seleted BoreDiameter";
                return getRodDiameters = null;
            }
            return getRodDiameters;
        }

        public DataTable GetClass()
        {
            DataTable getClass = null;
            _strQuery = "SELECT LIFECYCLECLASS FROM WELDED.LIFECYCLEDETAILS";
            getClass = modWeldedCylinder.MonarchConnectionObject.GetTable(_strQuery);
            if (((getClass == null) || (getClass.Rows.Count == 0)))
            {

                _strErrorMessage = ("Data not retrieved from LifeCycleDetails table" + "\r\n");
                return getClass = null;
            }
            return getClass;
        }

        public DataTable GetThreadSizeValues(int intCycle, double dblDiameter, double dblPullupforce)
        {
            DataTable getThreadSizeValues = null;
            _strQuery = "select StressOfThreadAtRoot from welded.LifeCycleDetails where LifeCycleClass =" + intCycle.ToString();

            double Area = Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));

            _strQuery = "select ThreadDiscription,ThreadValue from dbo.ThreadedRodDetails where ThreadValue <= " + dblDiameter.ToString() +
                        " and (" + dblPullupforce.ToString() + "/ RootStressArea) <=" + Area.ToString();

            getThreadSizeValues = modWeldedCylinder.MonarchConnectionObject.GetTable(_strQuery);
            if (((getThreadSizeValues == null) || (getThreadSizeValues.Rows.Count <= 0)))
            {

                _strErrorMessage = ("Data not retrieved from ThreadedRodDetails table" + "\r\n");
                return getThreadSizeValues = null;
            }
            return getThreadSizeValues;
        }

        public DataRow NutSafetyFactor(string strSelectedClass)
        {
            DataRow nutSafetyFactor = null;
            _strQuery = ("select * from Welded.LifeCycleDetails where LifeCycleClass = " + strSelectedClass);
            nutSafetyFactor = modWeldedCylinder.MonarchConnectionObject.GetDataRow(_strQuery);

            if (((nutSafetyFactor == null) || (nutSafetyFactor.ItemArray.Length <= 0)))
            {

                _strErrorMessage = ("Data not retrieved from LifeCycleDetails table" + "\r\n");
                return nutSafetyFactor = null;
            }
            return nutSafetyFactor;
        }

        public DataRow GetRodMaterialCode(string strRodDiameter)
        {
            DataRow getRodMaterialCode = null;
            _strQuery = ("select RodMaterialCode_Crome, RodMaterialCode_NitroSteel, RodMaterialCode_LION1000 from WELDED.RODDIA" +
            "METERDETAILS where RodDiameter=" + strRodDiameter);

            getRodMaterialCode = modWeldedCylinder.MonarchConnectionObject.GetDataRow(_strQuery);
            if (((getRodMaterialCode == null)
                        || (getRodMaterialCode.ItemArray.Length <= 0)))
            {

                _strErrorMessage = ("Data not retrieved from RodDiameterDetails table" + "\r\n");
                _strErrorMessage = "RodMaterialCode is not available in Table RodDiameterDetails for selected RodDiameter";
                return getRodMaterialCode = null;
            }
            return getRodMaterialCode;
        }

        public DataTable GetStopTubeCode(double dblRodDiamter, double dblLowerStopTubeLength, double dblHigherStopTubeLength)
        {
            DataTable getStopTubeCode = null;
            _strQuery = "SELECT DrawingNumber, StopTubeCode, RodDiameter, StopTubeOD, StopTubeNominalWallThickness, StopTubeLength FROM Welded.StopTubeDetails";
            _strQuery += " WHERE RodDiameter=" + dblRodDiamter.ToString() + " AND StopTubeLength BETWEEN "
                        + dblLowerStopTubeLength.ToString() + " AND " + dblHigherStopTubeLength.ToString();

            getStopTubeCode = modWeldedCylinder.MonarchConnectionObject.GetTable(_strQuery);

            if (((getStopTubeCode == null) || (getStopTubeCode.Rows.Count <= 0)))
            {

                _strErrorMessage = ("Data not retrieved from StopTubeDetails table" + "\r\n");
                _strErrorMessage = "StopTubeCode is not available in Table StopTubeDetails for selected RodDiameter and StopTubeLength";
                return getStopTubeCode = null;
            }
            return getStopTubeCode;
        }

        public DataTable GetThreadTensileArea()
        {
            DataTable getThreadTensileArea = null;
            _strQuery = "SELECT NutSize,ThreadTensileArea FROM WELDED.NutDimensionDetails";
            getThreadTensileArea = modWeldedCylinder.MonarchConnectionObject.GetTable(_strQuery);
            if (((getThreadTensileArea == null) || (getThreadTensileArea.Rows.Count <= 0)))
            {

                _strErrorMessage = ("Data not retrieved from NutDimensionDetails table" + "\r\n");
                _strErrorMessage = "NutSize, ThreadTensileArea are not available in Table NutDimensionDetails";
                return getThreadTensileArea = null;
            }
            return getThreadTensileArea;
        }



        public DataTable GetPistonNutsizes(string boreDiameter)
        {
            DataTable getPistonNutsizes = null;
            _strQuery = "select  nutsize from welded.nutdimensionDetails where "
                        + boreDiameter + ">=borediameter_min and "
                        + boreDiameter + "<=borediameter_max";

            getPistonNutsizes = modWeldedCylinder.MonarchConnectionObject.GetTable(_strQuery);

            if (((getPistonNutsizes == null) || (getPistonNutsizes.Rows.Count <= 0)))
            {

                _strErrorMessage = ("Data not retrieved from NutDimensionDetails table" + "\r\n");
                _strErrorMessage = "NutSize, ThreadTensileArea are not available in Table NutDimensionDetails";
                return getPistonNutsizes = null; ;
            }
            return getPistonNutsizes;
        }

        public DataRow GetNutCodeAndThickness(string strNutSize)
        {
            DataRow getNutCodeAndThickness = null;
            _strQuery = ("SELECT NutSize, NutCode, MaximumThickness,ActualThickness FROM WELDED.NutDimensionDetails WHERE NutSize=" + strNutSize);
            getNutCodeAndThickness = modWeldedCylinder.MonarchConnectionObject.GetDataRow(_strQuery);

            if (((getNutCodeAndThickness == null) || (getNutCodeAndThickness.ItemArray.Length <= 0)))
            {

                _strErrorMessage = ("Data not retrieved from NutDimensionDetails table" + "\r\n");
                _strErrorMessage = "NutCode, MaximumThickness are not available in Table NutDimensionDetails for selected NutSize";
                return getNutCodeAndThickness = null;
            }
            return getNutCodeAndThickness = null; ;
        }

        public DataTable GetPistonDetails(string strBoreDiameter, string strSealType, string strSingleWearRing, string strDoubleWearRing, string strPistonConnection, string strPistonShankSeal, string strPistonNutSize)
        {
            DataTable getPistonDetails = null;
            try
            {
                _strQuery = "SELECT IFLID, PistonCode, BoreDiameter, PistonNutSize, PistonWidth, CounterBoreDepth, MinDistanceFromRodSideToSealGrooveStart, ";
                _strQuery += " MaxDistanceFromRodSideToSealGrooveEnd, " + strSealType + ", PistonConnection, PistonShankSeal, SingleWearRing, PistonDesign,DoubleWearRing,";
                _strQuery += " PistonODatSeal, PistonODatSeal_TOL_UL, PistonODatSeal_TOL_LL, SealGrooveDiameter, SealGrooveDiameter_TOL_UL, SealGrooveDiameter_TOL_LL, SealGrooveWidth, SealGrooveWidth_TOL_UL, SealGrooveWidth_TOL_LL,";
                _strQuery += " PistonODatWearRing, PistonODatWearRing_TOL_UL, PistonODatWearRing_TOL_LL, WearRingDiameter, WearRingDiameter_TOL_UL, WearRingDiameter_TOL_LL, WearRingWidth, WearRingWidth_TOL_UL, WearRingWidth_TOL_LLPart_Type";
                _strQuery += " FROM Welded.PistonDetails WHERE BOREDIAMETER=" + strBoreDiameter + " AND PistonNutSize = " + strPistonNutSize;
                _strQuery += " AND " + strSealType + " <> 'N/A' AND SingleWearRing " + strSingleWearRing + " AND DoubleWearRing" + strDoubleWearRing;
                _strQuery += " AND PistonConnection='" + strPistonConnection + "' AND PistonShankSeal='" + strPistonShankSeal + "'";
                getPistonDetails = modWeldedCylinder.MonarchConnectionObject.GetTable(_strQuery);
            }
            catch (Exception ex)
            {
            }
            if (((getPistonDetails == null) || (getPistonDetails.Rows.Count <= 0)))
            {

                _strErrorMessage = ("Data not retrieved from PistonDetails table" + "\r\n");
                _strErrorMessage += "PistonCode not available for selected values of BoreDiameter, SealType, WearRing ,PistonConnection and PistonShankSeal";
                return getPistonDetails = null;
            }
            return getPistonDetails;
        }

        public DataTable GetCylinderHeadDetails(string strBoreDiameter, string strRodDiameter, string strHeadType, string strRodSeal, string strRodWiperType, string strSingleWearRing, string strDoubleWearRing, string strWearRing, string strStandardOrCompressed)
        {
            DataTable getCylinderHeadDetails = null;
            try
            {
                _strQuery = "SELECT CylinderHeadCode, BoreDiameter, RodDiameter, HeadType, UCupRodSeal605, ZDeepRodMacroSeal, SingleWearRing";
                _strQuery += ", DoubleWearRing, Notes, SnapInRodWiper, ORing, BackUpRing,ShankLength,Overalllength, StaticSealPosition, StickOutFromTube, Part_Type FROM Welded.CylinderHeadDetails WHERE BoreDiameter =" + strBoreDiameter;
                _strQuery += " AND RodDiameter=" + strRodDiameter + " AND HeadType = '" + strHeadType + "' AND " + strRodSeal + " <> 'N/A' AND";
                _strQuery += " " + strRodWiperType + " <> 'N/A' AND SingleWearRing " + strSingleWearRing + "";
                _strQuery += " AND DoubleWearRing " + strDoubleWearRing + " AND StandardOrCompressed ='" + strStandardOrCompressed + "'";
                getCylinderHeadDetails = modWeldedCylinder.MonarchConnectionObject.GetTable(_strQuery);
            }
            catch (Exception ex)
            {
            }
            if (((getCylinderHeadDetails == null) || (getCylinderHeadDetails.Rows.Count <= 0)))
            {

                _strErrorMessage = ("Data not retrieved from CylinderHeadDetails table" + "\r\n");
                _strErrorMessage += "CylinderHeadCode not available for selected values of BoreDiameter, RodDiameter, HeadType and WearRing";
                return getCylinderHeadDetails = null;
            }
            return getCylinderHeadDetails;
        }

        public bool InsertStopTubeDetails(string strIFLID, string strDrawingNumber, string strStopTubeCode, string strStopTubeDescription, double dblRodDiameter, double dblStopTubeOD, double dblStopTubeNominalWallThickness, double dblStopTubeLength)
        {
            bool insertStopTubeDetails = true;
            _strQuery = "Insert into Welded.StopTubeDetails(IFLID,DrawingNumber,StopTubeCode,StopTubeDescription,RodDiameter,StopTubeOD,StopTubeNominalWallThickness,StopTubeLength)";
            _strQuery += "values(" + strIFLID + "," + strDrawingNumber + ",'" + strStopTubeCode + "','" + strStopTubeDescription + "'," + dblRodDiameter.ToString() + "," + dblStopTubeOD.ToString() + "," + dblStopTubeNominalWallThickness.ToString() + "," + dblStopTubeLength.ToString() + ")";

            insertStopTubeDetails = modWeldedCylinder.MonarchConnectionObject.ExecuteQuery(_strQuery);

            if (!insertStopTubeDetails)
            {

                _strErrorMessage = ("Data not inserted into table StopTubeDetails" + "\r\n");
                return insertStopTubeDetails = false;
            }
            return insertStopTubeDetails;
        }

        public string GetMaxStopTubeCode()
        {
            string getMaxStopTubeCode = null;
            _strQuery = "SELECT MAX(StopTubeCode) FROM Welded.StopTubeDetails";
            getMaxStopTubeCode = Convert.ToString(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));

            if ((getMaxStopTubeCode == null))
            {
                _strErrorMessage = ("Data not retrieved from StopTubeDetails table" + "\r\n");
                return getMaxStopTubeCode = null;

            }
            return getMaxStopTubeCode;
        }

        public DataTable GetWallThickness(double dblBoreDiameter, double dblWorkingPressure, string strClass)
        {
            DataTable getWallThickness = null;

            _strQuery = "SELECT  BoreDiameter, WorkingPressure, TubeCode, TubeMaterial, TubeWallThickness, TubeOD, RodDiameter, " + strClass + ",IFLID";
            _strQuery += "FROM Welded.TubeDetails WHERE BoreDiameter = " + dblBoreDiameter.ToString() + " AND WorkingPressure = ";
            _strQuery += "(SELECT TOP 1 WorkingPressure FROM Welded.TubeDetails WHERE WorkingPressure >= " + dblWorkingPressure.ToString();
            _strQuery += ") AND " + strClass + " <> 'N'";

            getWallThickness = modWeldedCylinder.MonarchConnectionObject.GetTable(_strQuery);
            if (((getWallThickness == null) || (getWallThickness.Rows.Count == 0)))
            {

                _strErrorMessage = ("Data not retrieved from TubeDetails table" + "\r\n");
                return getWallThickness = null; ;
            }
            return getWallThickness;
        }


        public DataTable GetPinHoleSizes(string strBoreDiameter)
        {
            DataTable getPinHoleSizes = null;
            _strQuery = "SELECT DISTINCT(PinHole) FROM Welded.PinHoleDetails where BoreDiameter = " + strBoreDiameter;
            getPinHoleSizes = modWeldedCylinder.MonarchConnectionObject.GetTable(_strQuery);
            if (((getPinHoleSizes == null) || (getPinHoleSizes.Rows.Count == 0)))
            {

                _strErrorMessage = ("Data not retrieved from PinHoleSizeDetails table" + "\r\n");
                return getPinHoleSizes = null; ;

            }
            return getPinHoleSizes;
        }

        public DataRow GetPinHoleDetails(string strPinHoleSize)
        {
            DataRow getPinHoleDetails = null;
            _strQuery = "SELECT NominalPinHoleSize, PinHoleDimension, ToleranceUpperLimit, ToleranceLowerLimit ";
            _strQuery += "FROM Welded.PinHoleSizeDetails WHERE NominalPinHoleSize = " + strPinHoleSize;

            getPinHoleDetails = modWeldedCylinder.MonarchConnectionObject.GetDataRow(_strQuery);
            if (((getPinHoleDetails == null) || (getPinHoleDetails.ItemArray.Length <= 0)))
            {

                _strErrorMessage = ("Data not retrieved from PinHoleSizeDetails table" + "\r\n");
                return getPinHoleDetails = null;
            }
            return getPinHoleDetails;
        }

        public double GetNominalPinHoleSize(double PinHoleDimension)
        {
            double getNominalPinHoleSize = 0;
            _strQuery = "SELECT NominalPinHoleSize FROM Welded.PinHoleSizeDetails WHERE PinHoleDimension = " + PinHoleDimension.ToString();
            getNominalPinHoleSize = Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
            if ((getNominalPinHoleSize == 0))
            {
                _strErrorMessage = ("Data not retrieved from PinHoleSizeDetails table" + "\r\n");
                return getNominalPinHoleSize = 0; ;
            }
            return getNominalPinHoleSize;
        }

        public DataTable GetPortCode(double dblTubeOD, string strPortOrientation, string strPortType, string strPortSize)
        {
            DataTable getPortCode = null;
            dblTubeOD = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.RoundUp(dblTubeOD, 2);
            _strQuery = "SELECT * FROM Welded.PortsAndWPDSDetails WHERE " + dblTubeOD.ToString() + " BETWEEN MinimumTubeOD AND MaximumTubeOD ";
            if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType.StartsWith("Rephasing") == true))
            {
                _strQuery += "AND PortOrientation = '"
                            + strPortOrientation + "' AND PortType = '"
                            + strPortType + "' AND PORT_SIZE = '"
                            + strPortSize + "'  order by Port_Base";
            }
            else
            {
                _strQuery += "AND PortOrientation = '"
                            + strPortOrientation + "' AND PortType = '"
                            + strPortType + "' AND PORT_SIZE = '"
                            + strPortSize + "'";
            }

            getPortCode = modWeldedCylinder.MonarchConnectionObject.GetTable(_strQuery);
            if (((getPortCode == null) || (getPortCode.Rows.Count == 0)))
            {

                _strErrorMessage = ("Data not retrieved from PortsAndWPDSDetails table" + "\r\n");
                return getPortCode = null; ;

            }
            return getPortCode;
        }

        public DataTable GetOrificesSizes(string portType, string portSize)
        {

            DataTable getOrificesSizes = null;
            _strQuery = "SELECT DISTINCT(OrificeSize) FROM Welded.PortLocators where portType='"
                        + portType + "' and PortSize='"
                        + portSize + "' And PortLocatorCode <> 'N/A'";
            getOrificesSizes = modWeldedCylinder.MonarchConnectionObject.GetTable(_strQuery);
            if (((getOrificesSizes == null) || (getOrificesSizes.Rows.Count == 0)))
            {

                _strErrorMessage = ("Data not retrieved from PortLocators table" + "\r\n");
                return getOrificesSizes = null; ;

            }
            return getOrificesSizes;
        }

        public DataRow SetOrificesSizesDefault(string portType, string portSize)
        {

            DataRow setOrificesSizesDefault = null;

            _strQuery = "SELECT DISTINCT(OrificeSize) FROM Welded.PortLocators where portType='"
                        + portType + "' and PortSize='"
                        + portSize + "' and DefaultValue='yes'";

            setOrificesSizesDefault = modWeldedCylinder.MonarchConnectionObject.GetDataRow(_strQuery);
            if ((setOrificesSizesDefault == null))
            {

                _strErrorMessage = ("Data not retrieved from PortLocators table" + "\r\n");
                return setOrificesSizesDefault = null;

            }
            return setOrificesSizesDefault;
        }


        public DataTable GetPortLocatorCode(string strOrificeSize, string strPortSize, string strPortType)
        {
            DataTable getPortLocatorCode = null;
            _strQuery = "SELECT IFLID, PortSize, PortType, OrificeSize, PortLocatorCode, OrificeOffSet FROM Welded.PortLocators WHERE ";
            _strQuery += "OrificeSize = '" + strOrificeSize + "' AND PortSize = '" + strPortSize + "' AND PortType = '" + strPortType + "'";

            getPortLocatorCode = modWeldedCylinder.MonarchConnectionObject.GetTable(_strQuery);
            if (((getPortLocatorCode == null) || (getPortLocatorCode.Rows.Count == 0)))
            {

                _strErrorMessage = ("Data not retrieved from PortsAndWPDSDetails table" + "\r\n");
                return getPortLocatorCode = null;

            }
            return getPortLocatorCode;
        }

        public DataRow GetPistonDesignData(string strBoreDiameter)
        {
            DataRow getPistonDesignData = null;
            _strQuery = ("SELECT * FROM Welded.PistonDesignData WHERE BoreDiameter = " + strBoreDiameter);
            getPistonDesignData = modWeldedCylinder.MonarchConnectionObject.GetDataRow(_strQuery);

            if (((getPistonDesignData == null) || (getPistonDesignData.ItemArray.Length <= 0)))
            {

                _strErrorMessage = ("Data not retrieved from PistonDesignData table" + "\r\n");
                return getPistonDesignData = null;
            }
            return getPistonDesignData;
        }

        public string GetCounterBoreDiameter(double dblBoreDiameter, double dblPistonNutSize)
        {
            string getCounterBoreDiameter = null;
            _strQuery = "SELECT DISTINCT(CounterBoreDiameter) FROM Welded.CounterBoreDiameterDetails WHERE BoreDiameter = " + dblBoreDiameter.ToString();
            _strQuery += " AND PistonNutSize = " + dblPistonNutSize.ToString();
            getCounterBoreDiameter = Convert.ToString(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
            if ((getCounterBoreDiameter == null))
            {

                _strErrorMessage = ("Data not retrieved from CounterBoreDiameterDetails table" + "\r\n");
                _strErrorMessage += "CounterBore Diameter not available in table CounterBoreDiameterDetails for selected BoreDiameter and PistonNutSize";
                return getCounterBoreDiameter = null;
            }
            return getCounterBoreDiameter;
        }

        public bool InsertNewDetails(string strQuery)
        {
            bool insertNewDetails = true;


            insertNewDetails = modWeldedCylinder.MonarchConnectionObject.ExecuteQuery(strQuery);
            if (!insertNewDetails)
            {

                _strErrorMessage = ("Data not inserted into table" + "\r\n");
                return insertNewDetails = false;
            }
            return insertNewDetails;

        }

        public string GetMaxIFLID(string strTableName)
        {
            string getMaxIFLID = null;
            _strQuery = ("SELECT MAX(IFLID) FROM " + strTableName);

            if (!(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery).Equals(System.DBNull.Value)))
            {
                getMaxIFLID = Convert.ToString(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
            }
            else
            {
                getMaxIFLID = null;
            }
            if ((getMaxIFLID == null))
            {
                _strErrorMessage = ("Data not retrieved from " + (strTableName + ("table" + "\r\n")));
                return getMaxIFLID = null;
            }
            return getMaxIFLID;
        }

        public string GetMaxPistonCode()
        {
            string getMaxPistonCode = null;
            _strQuery = "SELECT MAX(PistonCode) FROM Welded.PistonDetails";

            getMaxPistonCode = Convert.ToString(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
            if ((getMaxPistonCode == null))
            {
                _strErrorMessage = ("Data not retrieved from PistonDetails table" + "\r\n");
                return getMaxPistonCode = null;
            }
            return getMaxPistonCode;
        }

        public DataRow GetBoreDiameters_SealCodesDetails(string strBoreDiameter)
        {
            DataRow getBoreDiameters_SealCodesDetails = null;
            _strQuery = ("SELECT * FROM Welded.RoDDiamters_SealCodes WHERE BoreDiameter = " + strBoreDiameter);
            getBoreDiameters_SealCodesDetails = modWeldedCylinder.MonarchConnectionObject.GetDataRow(_strQuery);
            if (((getBoreDiameters_SealCodesDetails == null) || (getBoreDiameters_SealCodesDetails.ItemArray.Length <= 0)))
            {

                _strErrorMessage = ("Data not retrieved from RoDDiamters_SealCodes table" + "\r\n");
                return getBoreDiameters_SealCodesDetails = null;
            }
            return getBoreDiameters_SealCodesDetails;
        }

        public DataRow GetCylinderDesignData(string strRodDiameter)
        {
            DataRow getCylinderDesignData = null;
            _strQuery = ("SELECT * FROM Welded.CylinderHeadDesignDetails WHERE RodDiameter=" + strRodDiameter);
            getCylinderDesignData = modWeldedCylinder.MonarchConnectionObject.GetDataRow(_strQuery);
            if (((getCylinderDesignData == null) || (getCylinderDesignData.ItemArray.Length <= 0)))
            {

                _strErrorMessage = ("Data not retrieved from CylinderHeadDesignDetails table" + "\r\n");
                return getCylinderDesignData = null;
            }
            return getCylinderDesignData;
        }

        public DataRow GetExistingCylinderDesignData(string HeadCodeNumber)
        {
            DataRow getExistingCylinderDesignData = null;
            try
            {

                _strQuery = "SELECT * FROM Welded.CylinderHeadDetails WHERE CylinderHeadCode='" + HeadCodeNumber + "'";
                getExistingCylinderDesignData = modWeldedCylinder.MonarchConnectionObject.GetDataRow(_strQuery);
                return getExistingCylinderDesignData;
            }
            catch (Exception ex)
            {
                return getExistingCylinderDesignData = null;
            }
        }

        public string GetMaxCylinderHeadCode()
        {
            string getMaxCylinderHeadCode = null;
            _strQuery = "SELECT MAX(CylinderHeadCode) FROM Welded.CylinderHeadDetails";
            getMaxCylinderHeadCode = Convert.ToString(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
            if ((getMaxCylinderHeadCode == null))
            {

                _strErrorMessage = ("Data not retrieved from CylinderHeadDetails table" + "\r\n");
                return getMaxCylinderHeadCode = null;
            }
            return getMaxCylinderHeadCode;
        }

        public DataRow GetStaticSealDetails(string strBoreDiameter)
        {
            DataRow getStaticSealDetails = null;
            _strQuery = ("SELECT * FROM Welded.StaticSealDetails WHERE BoreDiameter = " + strBoreDiameter);
            getStaticSealDetails = modWeldedCylinder.MonarchConnectionObject.GetDataRow(_strQuery);
            if (((getStaticSealDetails == null) || (getStaticSealDetails.ItemArray.Length <= 0)))
            {

                _strErrorMessage = ("Data not retrieved from StaticSealDetails table" + "\r\n");
                return getStaticSealDetails = null; ;
            }
            return getStaticSealDetails;
        }

        public DataRow GetORing_BackUpCodes(string strBoreDiameter, string strThd_RR)
        {
            DataRow getORing_BackUpCodes = null;
            _strQuery = "SELECT * FROM Welded.ORing_BackupCodes WHERE BoreDiameter =" + strBoreDiameter + " AND Threaded_RR = '" + strThd_RR + "'";
            getORing_BackUpCodes = modWeldedCylinder.MonarchConnectionObject.GetDataRow(_strQuery);
            if (((getORing_BackUpCodes == null) || (getORing_BackUpCodes.ItemArray.Length <= 0)))
            {

                _strErrorMessage = ("Data not retrieved from ORing_BackupCodes table" + "\r\n");
                return getORing_BackUpCodes = null;
            }
            return getORing_BackUpCodes;
        }

        public DataRow GetTubeDetails(string strIFLID)
        {
            DataRow getTubeDetails = null;
            _strQuery = "SELECT * FROM Welded.TubeDetails WHERE IFLID = '" + strIFLID + " '";

            getTubeDetails = modWeldedCylinder.MonarchConnectionObject.GetDataRow(_strQuery);
            if (((getTubeDetails == null) || (getTubeDetails.ItemArray.Length <= 0)))
            {

                _strErrorMessage = ("Data not retrieved from TubeDetails table" + "\r\n");
                return getTubeDetails = null; ;
            }
            return getTubeDetails;
        }

        public DataRow GetPort_WPDSDetails(double dblTubeOD, string strPortAngle, string strPortType, string strPortSize)
        {
            DataRow getPort_WPDSDetails = null;

            _strQuery = "SELECT * FROM Welded.PortsAndWPDSDetails WHERE " + dblTubeOD.ToString() + " BETWEEN MinimumTubeOD AND MaximumTubeOD ";
            _strQuery += "AND PortOrientation = '" + strPortAngle + "' AND PortType = '" + strPortType + "' AND PORT_SIZE = '" + strPortSize + "'";

            getPort_WPDSDetails = modWeldedCylinder.MonarchConnectionObject.GetDataRow(_strQuery);

            if (((getPort_WPDSDetails == null) || (getPort_WPDSDetails.ItemArray.Length <= 0)))
            {

                _strErrorMessage = ("Data not retrieved from PortsAndWPDSDetails table" + "\r\n");
                return getPort_WPDSDetails = null;
            }
            return getPort_WPDSDetails;
        }

        public DataTable BEDLCastingWithoutPortDetails(string strBoreDiameter, string strWallThickness, string strBushingWidth, string strPinHoleSize, string strBushingQuantity, string strLugThickness, string strLugGap, string strSwingClearance)
        {
            DataTable bEDLCastingWithoutPortDetails = null;

            if ((strBushingQuantity == "2"))
            {
                _strQuery = "SELECT * FROM Welded.BEDLCastWithOutPort WHERE BoreDiameter = " + strBoreDiameter;
                _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue ";
                _strQuery += " AND LugThickness = " + strBushingWidth + " AND PinHole_Combined <= " + strPinHoleSize;
                _strQuery += " AND LugGap >= " + strLugGap + " AND LugGap <= " + (double.Parse(strLugGap) + 0.25).ToString();

            }
            else if ((strBushingQuantity == "0"))
            {
                _strQuery = ("SELECT * FROM Welded.BEDLCastWithOutPort WHERE BoreDiameter = " + strBoreDiameter);
                _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue ";
                _strQuery += " AND LugThickness >= " + strLugThickness + " AND LugThickness <= " + (double.Parse(strLugThickness) + 0.25).ToString();
                _strQuery += " AND PinHole_Combined <= " + strPinHoleSize + " AND LugGap >= " + strLugGap;
                _strQuery += " AND LugGap <= " + (double.Parse(strLugGap) + 0.25).ToString();

            }
            bEDLCastingWithoutPortDetails = modWeldedCylinder.MonarchConnectionObject.GetTable(_strQuery);

            if (((bEDLCastingWithoutPortDetails == null) || (bEDLCastingWithoutPortDetails.Rows.Count == 0)))
            {

                _strErrorMessage = ("Data not retrieved from BEDLCastWithOutPort table" + "\r\n");
                return bEDLCastingWithoutPortDetails = null;
            }
            return bEDLCastingWithoutPortDetails;
        }


        public DataTable BEDLCastingWithFlushedPortDetails(string strBoreDiameter, string strWallThickness, string strBushingWidth, string strPinHoleSize, string strBushingQuantity, string strLugThickness, string strLugGap, string strSwingClearance, string strPortType)
        {
            DataTable bEDLCastingWithFlushedPortDetails = null;

            if ((strBushingQuantity == "2"))
            {
                _strQuery = ("SELECT * FROM Welded.BEDLCastWithFlushPort WHERE BoreDiameter = " + strBoreDiameter);
                _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue ";
                _strQuery += " AND LugThickness = " + strBushingWidth + " AND PinHole_Combined <= " + strPinHoleSize;
                _strQuery += " AND LugGap >= " + strLugGap + " AND LugGap <= " + (double.Parse(strLugGap) + 0.25).ToString() + " AND PortType = '" + strPortType + "'";
            }
            else if ((strBushingQuantity == "0"))
            {
                _strQuery = "SELECT * FROM Welded.BEDLCastWithFlushPort WHERE BoreDiameter = " + strBoreDiameter;
                _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue ";
                _strQuery += " AND LugThickness >= " + strLugThickness + " AND LugThickness <= " + (double.Parse(strLugThickness) + 0.25).ToString();
                _strQuery += " AND PinHole_Combined <= " + strPinHoleSize + " AND LugGap >= " + strLugGap;
                _strQuery += " AND LugGap <= " + (double.Parse(strLugGap) + 0.25).ToString() + " AND PortType = '" + strPortType + "'";
            }
            bEDLCastingWithFlushedPortDetails = modWeldedCylinder.MonarchConnectionObject.GetTable(_strQuery);
            if (((bEDLCastingWithFlushedPortDetails == null) || (bEDLCastingWithFlushedPortDetails.Rows.Count == 0)))
            {

                _strErrorMessage = ("Data not retrieved from BEDLCastWithFlushPort table" + "\r\n");
                return bEDLCastingWithFlushedPortDetails = null; ;
            }
            return bEDLCastingWithFlushedPortDetails;
        }


        public DataTable GetPlateClevisDetails(string strBoreDiameter, string strTubeOD)
        {
            DataTable getPlateClevisDetails = null;

            _strQuery = "SELECT * FROM Welded.ClevisPlateDetails WHERE IFLID = ( ";
            _strQuery += "SELECT top 1 IFLID FROM Welded.ClevisPlateDetails WHERE BoreDiameter = " + strBoreDiameter + " AND TubeOD = " + strTubeOD + ")";

            getPlateClevisDetails = modWeldedCylinder.MonarchConnectionObject.GetTable(_strQuery);

            if (((getPlateClevisDetails == null) || (getPlateClevisDetails.Rows.Count == 0)))
            {
                _strErrorMessage = ("Data not retrieved from ClevisPlateDetails table" + "\r\n");
                return getPlateClevisDetails = null;
            }
            return getPlateClevisDetails;
        }

        public DataTable BEULUgDetails(string strBushingQuantity, string strBushingWidth, string strPinHoleSize, string strLugThickness, string strPinWithInTubeDia, string strTubeOD, string strLugGap, string str1st_2nd = "1")
        {


            DataTable bEULUgDetails = null;

            if ((strBushingQuantity == "2"))
            {
                _strQuery = "SELECT * FROM Welded.BEULDetails WHERE LugThickness = " + strBushingWidth + " AND PinHoleCombined <= '" + strPinHoleSize + "'";
                if ((strPinWithInTubeDia == "Yes"))
                {
                    _strQuery += " AND LugDiagonal <= " + strTubeOD;
                }
                _strQuery += " AND LugGap >= " + strLugGap + " AND LugGap <= " + (double.Parse(strLugGap) + 0.25).ToString();
            }
            else if ((strBushingQuantity == "0"))
            {
                _strQuery = "SELECT * FROM Welded.BEULDetails WHERE LugThickness >= " + strLugThickness;
                _strQuery += " AND LugThickness <= " + (double.Parse(strLugThickness) + 0.25).ToString() + " AND PinHoleCombined <= '" + strPinHoleSize + "'";
                if ((strPinWithInTubeDia == "Yes"))
                {
                    _strQuery += " AND LugDiagonal <= " + strTubeOD;
                }
                _strQuery += " AND LugGap >= " + strLugGap + " AND LugGap <= " + (double.Parse(strLugGap) + 0.25).ToString();
            }
            bEULUgDetails = modWeldedCylinder.MonarchConnectionObject.GetTable(_strQuery);

            if ((str1st_2nd == "1"))
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEULDetails";
            }
            else
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BEULDetails";
            }

            if (((bEULUgDetails == null) || (bEULUgDetails.Rows.Count == 0)))
            {

                _strErrorMessage = ("Data not retrieved from BEULDetails table" + "\r\n");

                if ((str1st_2nd == "1"))
                {
                    modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "";
                }
                else
                {
                    modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "";
                }
                return bEULUgDetails = null;
            }
            return bEULUgDetails;
        }


        public DataRow GetBEDLCastWithOutPortSelectedRowDetails(string strPartCode, string str1st_2nd = "1")
        {

            DataRow getBEDLCastWithOutPortSelectedRowDetails = null;

            _strQuery = "SELECT * FROM Welded.BEDLCastWithOutPort WHERE PartCode = '" + strPartCode + "'";
            getBEDLCastWithOutPortSelectedRowDetails = modWeldedCylinder.MonarchConnectionObject.GetDataRow(_strQuery);


            if ((str1st_2nd == "1"))
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEDLCastWithOutPort";
            }
            else
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BEDLCastWithOutPort";
            }

            if (((getBEDLCastWithOutPortSelectedRowDetails == null) || (getBEDLCastWithOutPortSelectedRowDetails.ItemArray.Length <= 0)))
            {

                _strErrorMessage = ("Data not retrieved from BEDLCastWithOutPort table" + "\r\n");

                if ((str1st_2nd == "1"))
                {
                    modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "";
                }
                else
                {
                    modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "";
                }
                return getBEDLCastWithOutPortSelectedRowDetails = null;
            }
            else
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "Welded.BEDLCastWithOutPort";
            }
            return getBEDLCastWithOutPortSelectedRowDetails;
        }

        public DataRow GetBEDLCastingWithFlushedPortSelectedRowDetails(string strPartCode, string str1st_2nd = "1")
        {

            DataRow getBEDLCastingWithFlushedPortSelectedRowDetails = null;

            _strQuery = "SELECT * FROM Welded.BEDLCastWithFlushPort WHERE PartCode = '" + strPartCode + "'";

            getBEDLCastingWithFlushedPortSelectedRowDetails = modWeldedCylinder.MonarchConnectionObject.GetDataRow(_strQuery);

            if ((str1st_2nd == "1"))
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEDLCastWithFlushPort";
            }
            else
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BEDLCastWithFlushPort";
            }


            if (((getBEDLCastingWithFlushedPortSelectedRowDetails == null) || (getBEDLCastingWithFlushedPortSelectedRowDetails.ItemArray.Length <= 0)))
            {

                _strErrorMessage = ("Data not retrieved from BEDLCastWithFlushPort table" + "\r\n");

                if ((str1st_2nd == "1"))
                {
                    modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "";
                }
                else
                {
                    modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "";
                }
                return getBEDLCastingWithFlushedPortSelectedRowDetails = null;

            }
            else
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "Welded.BEDLCastWithFlushPort";
            }
            return getBEDLCastingWithFlushedPortSelectedRowDetails;
        }

        public DataRow GetBEULDetailsSelectedRowDetails(string strPartCode, string CalledFromBaseEndOrRodEnd = "Rod End", string str1st_2nd = "1")
        {

            DataRow getBEULDetailsSelectedRowDetails = null;

            _strQuery = ("SELECT * FROM Welded.BEULDetails WHERE PartCode = '" + (strPartCode + "'"));

            getBEULDetailsSelectedRowDetails = modWeldedCylinder.MonarchConnectionObject.GetDataRow(_strQuery);

            if ((str1st_2nd == "1"))
            {
                if ((CalledFromBaseEndOrRodEnd == "Base End"))
                {
                    modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEULDetails";
                }
                else
                {
                    modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName = "Welded.BEULDetails";
                }
            }
            else if ((CalledFromBaseEndOrRodEnd == "Base End"))
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BEULDetails";
            }
            else
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName = "Welded.BEULDetails";
            }

            if (((getBEULDetailsSelectedRowDetails == null)
                        || (getBEULDetailsSelectedRowDetails.ItemArray.Length <= 0)))
            {

                _strErrorMessage = ("Data not retrieved from BEULDetails table" + "\r\n");

                if ((str1st_2nd == "1"))
                {
                    modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "";
                }
                else
                {
                    modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "";
                }
                return getBEULDetailsSelectedRowDetails = null;
            }
            return getBEULDetailsSelectedRowDetails;
        }














        #endregion


        internal string GetPurchaseAndManufactureCode(string p)
        {
            throw new NotImplementedException();
        }
    }
}
