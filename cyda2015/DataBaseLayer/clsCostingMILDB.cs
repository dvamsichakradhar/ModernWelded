using IFLBaseDataLayer;
using IFLCommonLayer;
using System.Data;
using System;
using Welded.FunctionalLayer;

namespace Welded.DataBaseLayer
{
    public class clsCostingMILDB
    {
        private IFLConnectionClass _oMILConnectionObject;
        private string _strQuery;

        public IFLConnectionClass MILConnectionObject
        {
            get
            {
                return _oMILConnectionObject;
            }
            set
            {
                _oMILConnectionObject = value;
            }
        }

        public clsCostingMILDB()
        {
            try
            {
                string strXMLFilePath = (System.Environment.CurrentDirectory + "\\MILConnection.xml");
                DataSet oDataSet = new DataSet();
                oDataSet.ReadXml(strXMLFilePath);
                if (!(oDataSet.Tables.Count <= 0))
                {
                    string strServer = oDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                    string strDataBase = oDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
                    _oMILConnectionObject = IFLConnectionClass.GetConnectionObject(strServer, strDataBase, "System.Data.SqlClient");
                }
            }
            catch (Exception ex)
            {
            }
        }

        public DataRow GetPartCodeDetails(string strPartCode)
        {
            DataRow partCodeDetails = null;
            try
            {

                _strQuery = "select PartCode,Description,Cost,CostMangementReferenceNumber from CostingDetails where PartCode = \'"
                            + (strPartCode + "\'");
                partCodeDetails = MILConnectionObject.GetDataRow(_strQuery);
                if ((partCodeDetails == null))
                {
                    partCodeDetails = null;
                }
                return partCodeDetails;

            }
            catch (Exception ex)
            {
                return partCodeDetails = null;
            }

            
        }

        public double GetCostMultiplyValue(string strID)
        {
            double getCostMultipleValue = 0.0;
            try
            {
                _strQuery = ("select Cost from CostManagementDetails where IFLID = \'" + (strID + "\'"));
                getCostMultipleValue = Convert.ToDouble(MILConnectionObject.GetValue(_strQuery));
                return getCostMultipleValue;
            }
            catch (Exception ex)
            {
                return getCostMultipleValue=0.0;
            }
            
        }

        public DataTable GetCostingDetails()
        {
            DataTable getCostingDetails = null;

            try
            {
                _strQuery = "select * from CostingDetails ";
                getCostingDetails = MILConnectionObject.GetTable(_strQuery);
                if (((getCostingDetails == null) || (getCostingDetails.Rows.Count <= 0)))
                {
                    getCostingDetails = null;
                }
                else
                {
                    foreach (DataRow dr in getCostingDetails.Rows)
                    {
                        if ((Convert.ToDouble(dr["Cost"]) < 0.001))
                        {
                            dr["Cost"] = 0;
                        }
                    }

                }
                return getCostingDetails;

            }
            catch (Exception ex)
            {
                return getCostingDetails = null;
            }
           
        }

        public double GetRodWeight(string strRodDiameter)
        {
            double getRodWeight = 0.0;
            try
            {
                string strQuery1 = ("select WeightPerFoot from RodWeightDetails where RodDiameter = " + strRodDiameter);
                getRodWeight = Convert.ToDouble(MILConnectionObject.GetValue(strQuery1));
                return getRodWeight;
            }
            catch (Exception ex)
            {
               return  getRodWeight = 0;
            }
            
        }

        public string GetPaintCode(string strPaint)
        {
            string getPaintCode = null;
            try
            {
                getPaintCode = Convert.ToString(MILConnectionObject.GetValue(("Select PaintCode from PaintDetails where PaintColor = \'" + (strPaint + "\'"))));
                return getPaintCode;
            }
            catch (Exception ex)
            {
              return  getPaintCode = null;

            }
            
        }

        public void CloseConnection()
        {
            try
            {
                if (!(MILConnectionObject == null))
                {
                    MILConnectionObject.CloseConnection();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public DataTable PaintDataTable()
        {
            DataTable paintDataTable = null;
            try
            {
                _strQuery = "select * from dbo.PaintDetails";
                paintDataTable = MILConnectionObject.GetTable(_strQuery);
                if (((paintDataTable == null) && (paintDataTable.Rows.Count <= 0)))
                {
                    paintDataTable = null;
                }
                return paintDataTable;
            }
            catch (Exception ex)
            {
                return paintDataTable = null;
            }
           
        }


        public string GetPurchasedPartCode(string strPartCode)
        {
            string getPurchasedPartCode = String.Empty;
            try
            {
                _strQuery = ("select PurchasePartCode from CostingDetails where PartCode =\'" + (strPartCode + "\' and Purchased_Manfractured=\'P\'"));
                getPurchasedPartCode = Convert.ToString(MILConnectionObject.GetValue(_strQuery));
                if (string.IsNullOrEmpty(getPurchasedPartCode))
                {
                    getPurchasedPartCode = String.Empty;
                }
                return getPurchasedPartCode;
            }
            catch (Exception ex)
            {
                return getPurchasedPartCode = String.Empty;
            }
            
        }


        // Paint Description Notes From MIL DB
        public string GetPaintDescription(string cmbText)
        {
            string getPaintDescription = String.Empty;
            try
            {
                _strQuery = ("select description from PaintDetails where PaintColor=\'" + (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbPaint.Text + "\'"));
                getPaintDescription = Convert.ToString(MILConnectionObject.GetValue(_strQuery));
                if ((getPaintDescription == null))
                {
                    getPaintDescription = String.Empty;
                }
                return getPaintDescription;
            }
            catch (Exception ex)
            {
                return getPaintDescription=string.Empty;
            }
            
        }
    }
}

 
