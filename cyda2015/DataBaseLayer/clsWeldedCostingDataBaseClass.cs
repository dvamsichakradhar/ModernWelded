using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Welded.FunctionalLayer;

namespace Welded.DataBaseLayer
{
    class clsWeldedCostingDataBaseClass
    {
        private string _strQuery;

        public double GetBaseMachiningCost(double dblBoreDiameter)
        {
            double getBaseMachiningCost = 0;
            try
            {
                _strQuery = "select Cost from Welded.BaseMachiningCost where BoreDiameter = " + dblBoreDiameter.ToString();
                getBaseMachiningCost =Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
                return getBaseMachiningCost;
            }
            catch (Exception ex)
            {
                return getBaseMachiningCost=0;
            }
        }

        public double GetRodMachiningCost(double dblRodDiameter)
        {
            double getRodMachiningCost = 0;
            try
            {
                _strQuery = "select top 1 Cost from RodMechiningCost where RodDaimeter >= " + dblRodDiameter.ToString();
                getRodMachiningCost =Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
                return getRodMachiningCost;
            }
            catch (Exception ex)
            {
                return getRodMachiningCost = 0;
            }
        }

        public double GetPinHoleMachiningCost(double dblPinHoleDiameter, string strCastingType, double dblTolerance)
        {
            double getPinHoleMachiningCost = 0;
            try
            {
                _strQuery = "select Cost from Welded.PinHoleMachiningCost where PinHoleDiameter = "
                            + dblPinHoleDiameter.ToString() + " and CastingType = '"
                            + strCastingType + "' and Tolerance = " + dblTolerance.ToString();
                getPinHoleMachiningCost =Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
                return getPinHoleMachiningCost;
            }
            catch (Exception ex)
            {
                return getPinHoleMachiningCost = 0;
            }
        }

        public double GetPortMachiningCost(string strPortSize)
        {
            double getPortMachiningCost = 0;
            try
            {
                _strQuery = "select Cost from Welded.PortMachiningCost where PortSize = '"
                            + strPortSize + "'";
                getPortMachiningCost =Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
                return getPortMachiningCost;
            }
            catch (Exception ex)
            {
                return getPortMachiningCost = 0;
            }
        }

        public double GetMaterialCost(double dblWeight, string strMaterialType)
        {
            double getMaterialCost = 0;
            try
            {
                _strQuery = "select Cost from Welded.MaterialCost where MaterialType ='"
                            + strMaterialType + "' and '"
                            + dblWeight.ToString() + "'between MinWeight and MaxWeight";
                getMaterialCost =Convert.ToDouble(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
               return  getMaterialCost;
            }
            catch (Exception ex)
            {
              return   getMaterialCost=0;
            }
        }

        public string GetMaterialCode(string strLugThickness, string strLugWidth)
        {
            string getMaterialCode = null;
            try
            {
                _strQuery = "select MaterialCode from LugDesignDetails where LugThickness = "
                            + Math.Round((double.Parse(strLugThickness) + 0.005), 2).ToString() +" and LugWidth = "
                            + strLugWidth + "";
                getMaterialCode = Convert.ToString(modWeldedCylinder.MonarchConnectionObject.GetValue(_strQuery));
                if ((getMaterialCode == null))
                {
                    getMaterialCode = null;
                }
                return getMaterialCode;
            }
            catch (Exception ex)
            {
                return getMaterialCode = null;
            }
        }
    }
}
