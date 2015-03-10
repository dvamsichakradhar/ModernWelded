using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Welded.FunctionalLayer;
namespace Welded.DataBaseLayer
{
    class clsRodOperationsDMC
    {
        #region Private Variables

        private string _strQuery;
        private string _strErrorMessage;

        #endregion

        #region Public Functions

        public DataTable getWCOperations(double dblRulesId)
        {
            DataTable GetWCOperations = null;
            try
            {
                string strQuery2 = "select Operations from Welded.WCRulesOperation_Rod where Rules = " + dblRulesId.ToString();

                _strQuery = "select Operations from Welded.WCOperations_Rod where IFLID in ("
                            + strQuery2 + ")";
                GetWCOperations = modWeldedCylinder.MonarchConnectionObject.GetTable(_strQuery);
                if (((GetWCOperations == null)
                            || (GetWCOperations.Rows.Count <= 0)))
                {
                    GetWCOperations = null;
                    _strErrorMessage = ("Error occured while retrieving data from Welded.WCOperations_Rod" + "\r\n");
                }
                return GetWCOperations;
            }
            catch (Exception ex)
            {
                return GetWCOperations = null;
            }
        }

        public double getWCRulesID(string strRodMaterial, string strRodEndConfiguration, string strPinHoledrillingRequired)
        {
            double GetWCRulesID = 0;
            try
            {
                _strQuery = "select IFLID from Welded.WCRules_Rod where Material = '"
                            + strRodMaterial + "' and EndCondition = '"
                            + strRodEndConfiguration + "'  and PinHoleDrillingRequired = '"
                            + strPinHoledrillingRequired + "'";

                GetWCRulesID = Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));

                if ((GetWCRulesID == null))
                {
                    GetWCRulesID = 0;
                    _strErrorMessage = ("Error occured while retrieving data from Welded.WCRules_Rod" + "\r\n");
                }
                return GetWCRulesID;
            }
            catch (Exception ex)
            {
                return GetWCRulesID = 0;
            }
        }

        public DataRow getWorkCenterDetails(string strWorkStation)
        {
            DataRow GetWorkCenterDetails = null;
            try
            {
                _strQuery = "select * from Welded.WorkCenterRates where WorkStation = '" + strWorkStation + "'";
                GetWorkCenterDetails = modWeldedCylinder.MonarchConnectionObject.GetDataRow(_strQuery);
                if (((GetWorkCenterDetails == null)
                            || (GetWorkCenterDetails.ItemArray.Length <= 0)))
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

        public double getCuttingStandardCost(string strRodLength, string strColumnName, string strTableName)
        {
             double  GetCuttingStandardCost = 0;
            try
            {
                _strQuery = "select "
                            + strColumnName + "  from "
                            + strTableName + " where RodLength = '"
                            + strRodLength + "'";

                GetCuttingStandardCost = Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
                if ((GetCuttingStandardCost == 0))
                {
                    GetCuttingStandardCost = 0;
                    _strErrorMessage = ("Error occured while retrieving data from Welded.WorkCenterRates" + "\r\n");
                }
                return GetCuttingStandardCost;
            }
            catch (Exception ex)
            {
                 return GetCuttingStandardCost = 0;
            }
        }

        public double getMachiningStandardCost(string strRodLength, string strColumnName, string strTableName)
        {
            double GetMachiningStandardCost = 0;
            try
            {
                _strQuery = "select  "
                            + strColumnName + "  from "
                            + strTableName + " where RodLength =  '"
                            + strRodLength + "'";
                GetMachiningStandardCost =Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
                if ((GetMachiningStandardCost == null))
                {
                    GetMachiningStandardCost = 0;
                    _strErrorMessage = ("Error occured while retrieving data from Welded.WorkCenterRates" + "\r\n");
                }
                return GetMachiningStandardCost;
            }
            catch (Exception ex)
            {
                return GetMachiningStandardCost = 0;
            }
        }

        public double getArcTime_CastingTable(double dblRodDiameter, double dblWeldSize)
        {
            double GetArcTime_CastingTable = 0;
            try
            {
                _strQuery = "select top 1 ArcTime from Welded.REWeldSizeDetails_Casting where RodDiameter = "
                            + dblRodDiameter.ToString() + " and WeldSizeNumeric >= " + dblWeldSize.ToString();
                
                GetArcTime_CastingTable =Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
                if ((GetArcTime_CastingTable == null))
                {
                    GetArcTime_CastingTable = 0;
                    _strErrorMessage = ("Error occured while retrieving data from Welded.REWeldSizeDetails_Casting" + "\r\n");
                }
                return GetArcTime_CastingTable;
            }
            catch (Exception ex)
            {
                return GetArcTime_CastingTable = 0;
            }
        }

        public double getArcTime_LatheULugTable(double dblRodDiameter, double dblWeldSize)
        {
            double GetArcTime_LatheULugTable = 0;
            try
            {
                _strQuery = "select ArcTime from Welded.REULug_LatheWeldDetails where RodDiameter = "
                            + dblRodDiameter.ToString() + " and WeldSize >= " + dblWeldSize.ToString();
                // 12_10_2010   RAGAVA
                GetArcTime_LatheULugTable = Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
                if ((GetArcTime_LatheULugTable == 0))
                {
                    GetArcTime_LatheULugTable = 0;
                    _strErrorMessage = ("Error occured while retrieving data from Welded.REULug_LatheWeldDetails" + "\r\n");
                }
                return GetArcTime_LatheULugTable;
            }
            catch (Exception ex)
            {
                return GetArcTime_LatheULugTable = 0;
            }
        }

        public double getNumberOfPasses_ManualULugTable(double dblRodDiameter, double dblWeldSize)
        {
            double GetnumberOfPasses_ManualULugTable = 0;
            try
            {
                _strQuery = "select NumberOfPasses from Welded.REULug_ManualWeldDetails where RodDiameter = "
                            + dblRodDiameter.ToString() + " and WeldSizeNumeric = " + dblWeldSize.ToString();
                GetnumberOfPasses_ManualULugTable =Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
                if ((GetnumberOfPasses_ManualULugTable == null))
                {
                    GetnumberOfPasses_ManualULugTable = 0;
                    _strErrorMessage = ("Error occured while retrieving data from Welded.REULug_ManualWeldDetails" + "\r\n");
                }
                return GetnumberOfPasses_ManualULugTable;
            }
            catch (Exception ex)
            {
                return GetnumberOfPasses_ManualULugTable = 0;
            }
        }

        public double getNumberOfPasses_ManualCrossTubeTable(double dblRodDiameter, double dblWeldSize)
        {
            double GetNumberOfPasses_ManualCrossTubeTable = 0;
            try
            {
                _strQuery = "select NumberOfPasses from dbo.RECT_ManualWeldDetails where RodDiameter = "
                            + dblRodDiameter.ToString() + " and WeldSizeNumeric = " + dblWeldSize.ToString();
                GetNumberOfPasses_ManualCrossTubeTable = Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
                if ((GetNumberOfPasses_ManualCrossTubeTable == 0))
                {
                    GetNumberOfPasses_ManualCrossTubeTable = 0;
                    _strErrorMessage = ("Error occured while retrieving data from Welded.RECT_ManualWeldDetails" + "\r\n");
                }
                return GetNumberOfPasses_ManualCrossTubeTable;
            }
            catch (Exception ex)
            {
                return GetNumberOfPasses_ManualCrossTubeTable;
            }
        }


        #endregion
    }
}
