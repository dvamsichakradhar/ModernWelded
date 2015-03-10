using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Welded.UILayer.Common;
using IFLBaseDataLayer;

namespace Welded.FunctionalLayer
{
    class PopulatingBackClass
    {
        static PopulatingBackClass _oPopulatingBackClass;
        DataSet _Dataset;
        string _strExecutionPath;
        string _strContractNumber;
        string _strRevisionConractNo;
        string _strDescription;

        // 'Using this property , we are using the single instance in etire application

        public static PopulatingBackClass GetPopulatingObject
        {
            get
            {
                if ((_oPopulatingBackClass == null))
                {
                    _oPopulatingBackClass = new PopulatingBackClass();
                }
                return _oPopulatingBackClass;
            }
        }

        private PopulatingBackClass()
        {
            _Dataset = new DataSet();
            _strDescription = "First";
            _strExecutionPath = Application.StartupPath;
        }

        public DataSet Dataset
        {
            get
            {
                return _Dataset;
            }
        }

        public string ContractNumber
        {
            get
            {
                return _strContractNumber;
            }
            set
            {
                _strContractNumber = value;
            }
        }

        public string RevisionContractNumber
        {
            get
            {
                return _strRevisionConractNo;
            }
            set
            {
                _strRevisionConractNo = value;
            }
        }

        public string ExecutionPath
        {
            get
            {
                return _strExecutionPath;
            }
            set
            {
                _strExecutionPath = value;
            }
        }

        public bool StoreFormDataIntoDB()
        {
            DataTable oTable;
            _Dataset = new DataSet();
            foreach (object[] oItem in modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.FormNavigationOrder)
            {
                oTable = GetDataToSave(oItem[Convert.ToInt32(clsWeldedCylinderFunctionalClass.EOrderOfFormNavigationArraylist.CurrentFormObject)]);
                Dataset.Tables.Add(oTable);
            }
            _strContractNumber = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber;
            return StoreContractDetails();
        }

        private DataTable GetDataToSave(object p)
        {
            throw new NotImplementedException();
        }


        // It is used to find the form in the dataset and if form is available , then set available data to the form
        public bool SetDataToForm(Form oForm)
        {
            int intIndex = Dataset.Tables.IndexOf(oForm.Name);
            if ((intIndex >= 0))
            {
                DataTable oTable = Dataset.Tables[intIndex];
                IFLGetSetUIClass IFLBaseData = new IFLGetSetUIClass();
                IFLBaseData.SetDataToForm(oTable, oForm);
                return true;
            }
            return false;
        }

        private byte[] GetByteArray()
        {
            Dataset.WriteXml((ExecutionPath + "\\MIL.xml"));
            FileStream fsBLOBFile = new FileStream((ExecutionPath + "\\MIL.xml"), FileMode.Open);
            long fileSize = fsBLOBFile.Length - 1;
            // byte[] bytBLOBData = fsBLOBFile.Length- 1;
            byte[] bytBLOBData = new byte[] { (((byte)(fileSize))) }; //check here
            fsBLOBFile.Read(bytBLOBData, 0, Convert.ToInt32(bytBLOBData.Length));
            fsBLOBFile.Close();
            return bytBLOBData;
        }

        private DataTable GetDataToSave(Form oForm)
        {
            IFLGetSetUIClass oGetSetUIClass = new IFLGetSetUIClass();
            setPrimaryInputsScreen(oForm);
            DataTable oTable = oGetSetUIClass.StoreFormData(oForm);
            return oTable;
        }

        private void setPrimaryInputsScreen(Form oForm)
        {
            if ((oForm.Name == "frmPrimaryInputs"))
            {
                frmPrimaryInputs oPrimaryInputs = ((frmPrimaryInputs)(oForm));
                int count = oPrimaryInputs.lvwPressureSelection.SelectedItems.Count;
                // rod diamter List view 
                if ((count == 0))
                {
                    ListViewItem oListviewItem = oPrimaryInputs.lvwPressureSelection.FindItemWithText(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString());
                    int Position = oPrimaryInputs.lvwPressureSelection.Items.IndexOf(oListviewItem);
                    if ((Position >= 0))
                    {
                        oPrimaryInputs.lvwPressureSelection.Items[Position].Selected = true;
                    }
                }
                // Piston List View
                count = oPrimaryInputs.lvwPistonDetails.SelectedItems.Count;
                if ((count == 0))
                {
                    ListViewItem oListviewItem = oPrimaryInputs.lvwPistonDetails.FindItemWithText(modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInFractions);
                    int Position = oPrimaryInputs.lvwPistonDetails.Items.IndexOf(oListviewItem);
                    if ((Position >= 0))
                    {
                        oPrimaryInputs.lvwPistonDetails.Items[Position].Selected = true;
                    }
                }
            }
        }

        public bool GetFormDataFromDB(string ContractNumber)
        {
            try
            {
                string strQuery;
                strQuery = ("SELECT PROJECT_XML FROM ContractMaster WHERE ContractNumber=\'" + (ContractNumber + "\'"));
                byte[] strByte = (byte[])modWeldedCylinder.MonarchConnectionObject.GetValue(strQuery);
                //byte strByte = Convert.ToByte(modWeldedCylinder.MonarchConnectionObject.GetValue(strQuery));
                string strXMLFilePath = (_strExecutionPath + "\\MIL.xml");
                if (File.Exists(strXMLFilePath))
                {
                    File.Delete(strXMLFilePath);
                }
                FileStream fstream = new FileStream(strXMLFilePath, FileMode.OpenOrCreate);
                BinaryWriter bw = new BinaryWriter(fstream);
                BinaryReader br = new BinaryReader(fstream);
                bw.Write(strByte);
                br.Close();
                _Dataset = new DataSet(ContractNumber);
                Dataset.ReadXml(strXMLFilePath);
                if (File.Exists(strXMLFilePath))
                {
                    File.Delete(strXMLFilePath);
                }
                return true;
            }
            catch (Exception ex)
            {
            }
            return true;
        }

        private bool StoreContractDetails()
        {
            bool StoreContractDetails = false;
            try
            {
                DataRow oRow;
                IFLBaseDataLayer.IFLBaseDataClass oDataBaseClass = new IFLBaseDataLayer.IFLBaseDataClass(modWeldedCylinder.MonarchConnectionObject);
                //bool IsNewRecord = false;
                string strContractNo;

                byte[] aData = GetByteArray();
                if ((modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision == "New"))
                {
                    strContractNo = _strContractNumber;
                }
                else
                {
                    strContractNo = _strRevisionConractNo;
                }
                oDataBaseClass.LoadTable("ContractMaster", "", "", "ContractNumber", strContractNo, true);
                DataTable oTable = oDataBaseClass.GetDataTable("ContractMaster");
                if ((oTable.Rows.Count == 0))
                {
                    oRow = oDataBaseClass.GetNewRecord("ContractMaster");
                    oRow["CustomerName"] = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerName_ContractDetails;
                    oRow["ContractNumber"] = _strContractNumber;
                    oRow["ContractRevision"] = 0;
                    oRow["Description"] = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AssemblyType_ContractDetails;
                    oRow["AssemblyType"] = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AssemblyType_ContractDetails;
                    oRow["Project_XML"] = aData;
                    oRow["CustomerPartCode"] = modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCode_ContractDetails;
                    oDataBaseClass.AddNewRecord("ContractMaster", oRow);
                }
                else
                {
                    oRow = oTable.Rows[0];

                    oRow["ContractRevision"] = (modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables._intContractRevisionNumber + 1);

                    oRow["Project_XML"] = aData;
                }
                StoreContractDetails = oDataBaseClass.SaveData();
            }
            catch (Exception ex)
            {


                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.WriteLogInformation(ex.Message.ToString());
            }
            return StoreContractDetails;
        }










    }
}
