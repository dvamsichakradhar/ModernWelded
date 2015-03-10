using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Welded.FunctionalLayer;

namespace Welded.DataBaseLayer
{
    public class clsOperationDMC
    {
        #region Variables

        private string _strQuery;
        private string _strErrorMessage;

        #endregion

        #region Public Functions

        public DataRow getWorkCenterDetails(string strWorkStation)
        {
            DataRow GetWorkCenterDetails = null;
            try
            {

                _strQuery = ("select * from Welded.WorkCenterRates where WorkStation ='"+ (strWorkStation + "'"));
                GetWorkCenterDetails = modWeldedCylinder.MonarchConnectionObject.GetDataRow(_strQuery);
                if (((GetWorkCenterDetails == null)|| (GetWorkCenterDetails.ItemArray.Length <= 0)))
                {
                    GetWorkCenterDetails = null;
                    _strErrorMessage = ("Error occured while retrieving data from Welded.WorkCenterRates" + "\r\n");
                }
                return GetWorkCenterDetails;
            }
            catch (Exception ex)
            {
                return GetWorkCenterDetails = null;
            }
        }

        public double getCuttingStandardCost(string strStrokeLength, string strColumnName)
        {
            double  GetCuttingStandardCost = 0;
            try
            {
               
                _strQuery = ("select  "+ strColumnName + "  from Welded.WCCuttingDetails where StrokeLength ='"+ strStrokeLength + "'");
                GetCuttingStandardCost = Convert.ToDouble( modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
                if ((GetCuttingStandardCost == null))
                {
                    GetCuttingStandardCost = 0;
                    _strErrorMessage = ("Error occured while retrieving data from Welded.WorkCenterRates" + "\r\n");
                }
                return GetCuttingStandardCost;
            }
            catch (Exception ex)
            {
                return GetCuttingStandardCost=0;
            }
        }

        public double getDrillingStandardCost(string strStrokeLength, string strColumnName)
        {
            double GetDrillingStandardCost = 0;
            try
            {     
                if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked == true))
                {
                    _strQuery = ("select  "+ strColumnName +"  from WCDrilling_Rephasing where StrokeLength ='"
                                + strStrokeLength +"'");
                }
                else
                {
                    _strQuery = ("select  "+ strColumnName + "  from Welded.WCDrillingDetails where StrokeLength = '"+ strStrokeLength + "'");
                }
               
                GetDrillingStandardCost = Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
                if ((GetDrillingStandardCost == 0))
                {
                    GetDrillingStandardCost = 0;
                    _strErrorMessage = ("Error occured while retrieving data from Welded.WCDrillingDetails" + "\r\n");
                }
                return GetDrillingStandardCost;
            }
            catch (Exception ex)
            {
                return GetDrillingStandardCost = 0;
            }
        }

       
        public double getGrooveDetailsStandardCost(string strStrokeLength, string strColumnName)
        {
            double GetGrooveDetailsStandardCost = 0;
            try
            {
                
                _strQuery = ("select  "
                            + (strColumnName + ("  from Welded.WCGroovingDetails where StrokeLength =  \'"
                            + (strStrokeLength + "\'"))));
                GetGrooveDetailsStandardCost = Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
                if ((GetGrooveDetailsStandardCost == 0))
                {
                    GetGrooveDetailsStandardCost = 0;
                    _strErrorMessage = ("Error occured while retrieving data from Welded.WCGroovingDetails" + "\r\n");
                }
                return GetGrooveDetailsStandardCost;

            }
            catch (Exception ex)
            {
                return GetGrooveDetailsStandardCost=0;
            }
        }

        public double getThreadedDetailsStandardCost(string strStrokeLength, string strColumnName)
        {
            double GetThreadedDetailsStandardCost = 0;
            _strQuery = ("select  "
                        + strColumnName + "  from Welded.WCThreadedDetails where StrokeLength = '"
                        + strStrokeLength + "'");

            GetThreadedDetailsStandardCost = Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
            if ((GetThreadedDetailsStandardCost==0))
            {
                GetThreadedDetailsStandardCost = 0;
                _strErrorMessage = ("Error occured while retrieving data from Welded.WCThreadedDetails" + "\r\n");
            }
            return GetThreadedDetailsStandardCost;
        }

        public double getSkivingDetailsStandardCost(string strStrokeLength, string strColumnName)
        {
            double GetSkivingDetailsStandardCost = 0;
            try
            {
               
                if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked == true))
                {
                    _strQuery = "select  "
                                + strColumnName + " from WCSkiving_Rephasing where StrokeLength = '"
                                + strStrokeLength + "'";
                }
                else
                {
                    _strQuery = "select  "
                                + strColumnName + "  from Welded.WCSkiving where StrokeLength =  \'"
                                + strStrokeLength + "\'";
                }

                GetSkivingDetailsStandardCost = Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
                if ((GetSkivingDetailsStandardCost == null))
                {
                    GetSkivingDetailsStandardCost = 0;
                    _strErrorMessage = ("Error occured while retrieving data from Welded.WCSkiving" + "\r\n");
                }
                return GetSkivingDetailsStandardCost;
            }
            catch (Exception ex)
            {
              return GetSkivingDetailsStandardCost = 0;
            }
        }

        public double getLatheWeldingDetailsStandardCost(string strBoreDimater, string strStrokeLength)
        {
            double GetLatheWeldingDetailsStandardCost = 0;
            try
            {
               
                _strQuery = ("select top 1 Cost from Welded.WCLatheWelding where  ("
                            + (strStrokeLength + (" between MinimumLength and MaximumLength) and BoreDiameter >= " + strBoreDimater)));
                GetLatheWeldingDetailsStandardCost =Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
                if ((GetLatheWeldingDetailsStandardCost == null))
                {
                    GetLatheWeldingDetailsStandardCost = 0;
                    _strErrorMessage = ("Error occured while retrieving data from Welded.WCLatheWelding" + "\r\n");
                }
                return GetLatheWeldingDetailsStandardCost;
            }
            catch (Exception ex)
            {
               return  GetLatheWeldingDetailsStandardCost = 0;
            }
        }

        public double getRobotWeldingDetailsStandardCost(string strBoreDimater, string strStrokeLength)
        {
            double GetRobotWeldingDetailsStandardCost = 0;
            try
            {
               
                _strQuery = " select top 1 Cost from Welded.WCRobotWeldng where  ("
                            + strStrokeLength + "  between MinimumLength and MaximumLength) and ("
                            + strBoreDimater + "   between MinimumBoreDiameter and MaximumBoreDiameter) ";
                GetRobotWeldingDetailsStandardCost = Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
                if ((GetRobotWeldingDetailsStandardCost == 0))
                {
                    GetRobotWeldingDetailsStandardCost = 0;
                    _strErrorMessage = ("Error occured while retrieving data from Welded.WCRobotWeldng" + "\r\n");
                }
                return GetRobotWeldingDetailsStandardCost;
            }
            catch (Exception ex)
            {
                return GetRobotWeldingDetailsStandardCost=0;
            }
        }

         public double getManualWeldingDetailsStandardCost(string strBoreDimater, string strStrokeLength, string strWeldSize)
         {
             double GetManualWeldingDetailsStandardCost = 0;
        try 
        {
            
            _strQuery = " select top 1 cost from Welded.WCManualLugWelding where  (" 
                        + strStrokeLength + "  between MinimumLength and MaximumLength) and (" 
                        + strBoreDimater + "  between MinimumBoreDiameter and MaximumBoreDiameter) and (" 
                        + strWeldSize + "  between MinimumWeldSize and MaximumWeldSize)";
            GetManualWeldingDetailsStandardCost =Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
            if (GetManualWeldingDetailsStandardCost == null)
            {
                GetManualWeldingDetailsStandardCost = 0;
                _strErrorMessage = ("Error occured while retrieving data from Welded.WCManualLugWelding" + "\r\n");
            }
            return GetManualWeldingDetailsStandardCost;
        }
        catch (Exception ex) 
        {
             return GetManualWeldingDetailsStandardCost = 0;
        }
    }
    
    public double getPortWeldingDetailsStandardCost(string strStrokeLength, string strNoOfPorts)
    {
        double GetPortWeldingDetailsStandardCost = 0;
        try 
        {
            
            _strQuery = "select top 1 cost from Welded.WCPortWelding where (" 
                        + strStrokeLength +"  between MinimumLength and MaximumLength) and NumberOFPorts = " 
                        + strNoOfPorts + "";

            GetPortWeldingDetailsStandardCost = Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
            if ((GetPortWeldingDetailsStandardCost == null))
            {
                GetPortWeldingDetailsStandardCost = 0;
                _strErrorMessage = ("Error occured while retrieving data from Welded.WCPortWelding" + "\r\n");
            }
            return GetPortWeldingDetailsStandardCost;
        }
        catch (Exception ex) 
        {
            return GetPortWeldingDetailsStandardCost=0;
        }
    }

    public double getPinHoleDetailsStandardCost(string strPartWeight, string strPinHoleSize)
    {
        double GetPinHoleDetailsStandardCost = 0;
        try
        {
            
            _strQuery = ("   select top 1 standardcost from Welded.WCPinHoleDetails where ("
                        + (strPartWeight + ("  between MinimumPartWeight and MaximumPartWeight) and ("
                        + (strPinHoleSize + " between MinimumPinHoleSize and MaximumPinHoleSize)"))));
            GetPinHoleDetailsStandardCost = Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
            if ((GetPinHoleDetailsStandardCost == 0))
            {
                GetPinHoleDetailsStandardCost = 0;
                _strErrorMessage = ("Error occured while retrieving data from Welded.WCPortWelding" + "\r\n");
            }
            return GetPinHoleDetailsStandardCost;
        }
        catch (Exception ex)
        {
            return GetPinHoleDetailsStandardCost = 0;
        }
    }

    public double getPortPluggingCost(string strStrokeLength, string strColumnName, bool blnValue)
    {
        double GetPortPluggingCost = 0;
        try
        {
            
            if (blnValue)
            {
                _strQuery = "select  "
                            + strColumnName + "  from Welded.WCPortPluggingOne90deg where StrokeLength ='"
                            + strStrokeLength + "'";
            }
            else
            {
                _strQuery = "select  "
                            + strColumnName +"  from Welded.WCPortPluggingTwo90deg where StrokeLength ='"
                            + strStrokeLength + "'";
            }
            GetPortPluggingCost =Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
            if ((GetPortPluggingCost == 0))
            {
                GetPortPluggingCost = 0;
                _strErrorMessage = ("Error occured while retrieving data from Welded.WCPortPluggingOne90deg or Welded.WCPortPluggingTwo90d" +
                "eg " + "\r\n");
            }
            return GetPortPluggingCost;
        }
        catch (Exception ex)
        {
            return GetPortPluggingCost;
        }
    }

    public double getWCRuledID(string strDesignType, string strCylinderHeadType, string strTubeMaterial, int intOneOrTwoPiece)
    {
        double GetWCRuledID = 0;
        try
        {
            
            _strQuery = "select * from Welded.WCRules where DesignType = '"
                        + strDesignType + "' and CylinderHeadType = '"
                        + strCylinderHeadType + "' and TubeMaterial = '"
                        + strTubeMaterial + "' and OneOrTwoPieceBaseEnd = " + intOneOrTwoPiece.ToString();
            if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked == true))
            {
                _strQuery = (_strQuery + " and Rephasing = 'Y'");
            }
            GetWCRuledID =Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
            if ((GetWCRuledID == 0))
            {
                GetWCRuledID = 0;
                _strErrorMessage = ("Error occured while retrieving data from Welded.WCRules" + "\r\n");
            }

            return GetWCRuledID;
        }
        catch (Exception ex)
        {
            return GetWCRuledID = 0;
        }
    }

    public DataTable getWCRulesOperations(string strRuledID)
    {
        DataTable GetWCRulesOperations = null;
        try
        {
           
            if ((double.Parse(strRuledID) > 8))
            {
               
                _strQuery = ("select Wco.Operations from Welded.WCOperations wco,(select Operations from Welded.WCRulesOperation wh" +
                "ere Rules = \'"
                            + (strRuledID + "\')  wcro where wcro.Operations = wco.IFLID"));
            }
            else
            {
                _strQuery = ("select Operations from Welded.WCOperations where IFLID in(select Operations from  Welded.WCRulesOpera" +
                "tion where Rules = "
                            + (strRuledID + " )"));
            }
            GetWCRulesOperations = modWeldedCylinder.MonarchConnectionObject.GetTable(_strQuery);
            if (((GetWCRulesOperations == null)
                        || (GetWCRulesOperations.Rows.Count < 1)))
            {
                GetWCRulesOperations = null;
                _strErrorMessage = ("Error occured while retrieving data from Welded.WCRulesOperation" + "\r\n");
            }
            return GetWCRulesOperations;
        }
        catch (Exception ex)
        {
            return GetWCRulesOperations=null;
        }
    }

    public double getHeadWeldingCost(double dblTubeDiameter, string strTubeLengthColoumnName)
    {
        double GetHeadWeldingCost = 0;
        try
        {
            if ((dblTubeDiameter <= 2))
            {
                _strQuery = "select "
                            +strTubeLengthColoumnName + " from Welded.WCWelding where TubeDiameter <= 2 ";
            }
            else
            {
                _strQuery = "select "
                            + strTubeLengthColoumnName + " from Welded.WCWelding where TubeDiameter = " + dblTubeDiameter.ToString();
            }
            GetHeadWeldingCost =Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
            if ((GetHeadWeldingCost == 0))
            {
                _strErrorMessage = ("Error occured while retrieving data from Welded.WCWelding" + "\r\n");
            }
            return GetHeadWeldingCost;

        }
        catch (Exception ex)
        {
            return GetHeadWeldingCost = 0;
        }
    }

        #endregion







    }
}
