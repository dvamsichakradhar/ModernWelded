using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace Welded.FunctionalLayer
{
   public class IFLGetSetUIClass
   {
       #region Class Variables
       
       //''' This variable is used to get the Datatable from the database.
       //''' Using this _oTable we can store the current table name..

       private DataTable _oTable;

       //'''  This variable is used to get the form.
      //''' This is used to assign the current form.

       private Form _SourceForm;

      // '''  This variable is used to get the form.
       // '''  The below variable is used to create a row.

       private DataRow odataRow;

        private DataRowView oDataRowView;

        //'''  The below variable is used to give the Error message when exception raises.

        private String _strErrorMessage;

       //''' The below variable is used to give the Error object when exception raises.

        public Exception _oErrorObject;

       #endregion

       #region Properties
       //''' This property is used to store the current form.

        public Form SourceForm
        {
            get
            {
                return _SourceForm;
            }
            set
            {
                _SourceForm = value;
            }
        }

      // '' This property is used as an arraylist to store the specified fields.


        private ArrayList aTableStructure
        {
            get
            {
                ArrayList TableStructure = new ArrayList();
                TableStructure.Add("TabIndex");
                TableStructure.Add("ConName");
                TableStructure.Add("Value");
                return TableStructure;
            }
        }

       // ''' This property is used to assign the error message.

        public string ErrorMessage
        {
            get
            {
                return _strErrorMessage;
            }
        }

       // ''' This property is used to assign the error object.

        public Exception ErrorObject
        {
            get
            {
                return _oErrorObject;
            }
        }
       #endregion

       #region Procedures

       //''' This procedure is used to create a source table 
       //''' It will return a table object that can be created with specified structure which contains the tab index, control name and control value


        private bool CreateSourceTable(string strFormName)
        {
            bool CreateSourceTable = true;
            try
            {
                _oTable = new DataTable(strFormName);
                _oTable.Columns.Add("TabIndex", System.Type.GetType("System.Int32"));
                _oTable.Columns.Add("ConName", System.Type.GetType("System.String"));
                _oTable.Columns.Add("Value", System.Type.GetType("System.String"));
                return CreateSourceTable;
            }
            catch (Exception oException)
            {
                CreateSourceTable = false;
                _strErrorMessage = ("Source Table is not Created !!" + "\r\n");
                _strErrorMessage = (_strErrorMessage + ("System generated error:-" + ("\r\n" + oException.Message)));
                _oErrorObject = oException;
            }
            return CreateSourceTable;
        }

        private void AddDataToTable(Control oControl)
        {
            CheckBox oCheckBox;
            RadioButton oRadioButton;
            clsListViewMIL olistView;
            try
            {
           
                if (((oControl.GetType() == typeof(TextBox))|| ((oControl.GetType() == typeof(ComboBox))|| (oControl.GetType() == typeof(RichTextBox)))))
                {
                    
                    if (!(oControl.Text == ""))
                    {
                        odataRow = _oTable.NewRow();
                        odataRow["TabIndex"] = oControl.TabIndex;
                        odataRow["ConName"] = oControl.Name;
                        odataRow["Value"] = oControl.Text;
                        _oTable.Rows.Add(odataRow);
                    }
                }
                else if ((oControl.GetType() == typeof(CheckBox)))
                {
                    oCheckBox = ((CheckBox)(oControl));
                    odataRow = _oTable.NewRow();
                    odataRow["TabIndex"] = oCheckBox.TabIndex;
                    odataRow["ConName"] = oCheckBox.Name;
                    odataRow["Value"] = oCheckBox.Checked;
                    _oTable.Rows.Add(odataRow);
                }
                else if ((oControl.GetType() == typeof(RadioButton)))
                {
                    oRadioButton = ((RadioButton)(oControl));
                    odataRow = _oTable.NewRow();
                    odataRow["TabIndex"] = oRadioButton.TabIndex;
                    odataRow["ConName"] = oRadioButton.Name;
                    odataRow["Value"] = oRadioButton.Checked;
                    _oTable.Rows.Add(odataRow);
                }
                else if ((oControl.GetType() == typeof(ListView)))
                {
                    olistView = ((clsListViewMIL)(oControl));
                    odataRow = _oTable.NewRow();
                    odataRow["TabIndex"] = olistView.TabIndex;
                    odataRow["ConName"] = olistView.Name;
                    string strLVitem = "";
                    ListViewItem itemI = olistView.SelectedItems;
                    //ListView.SelectedListViewItemCollection itemI = olistView.SelectedItems;
                    strLVitem = itemI.Text;
                    for (int i = 1; (i<= (itemI.SubItems.Count - 1)); i++)
                    {
                        strLVitem += "-";
                        strLVitem = (strLVitem + itemI.SubItems[i].Text);
                    }
                    odataRow["Value"] = strLVitem;
                    _oTable.Rows.Add(odataRow);
                }
                //  End If
            }
            catch (Exception oException)
            {
                _strErrorMessage = ("UNABLE TO ADD THE DATA TO THE TABLE !!" + "\r\n");
                _strErrorMessage = (_strErrorMessage + ("System generated error:-" + ("\r\n" + oException.Message)));
                _oErrorObject = oException;
            }
        }

        private void FindControl(Control oFormControl)
        {
            try
            {
                foreach (Control ocontrol in oFormControl.Controls)
                {
                    
                    if (ocontrol.HasChildren)
                    {
                        FindControl(ocontrol);
                    }
                    else
                    {
                        SetControlValue(ocontrol);
                    }
                }
            }
            catch (Exception oException)
            {
                _strErrorMessage = ("UNABLE TO FIND THE CONTROL !!" + "\r\n");
                _strErrorMessage = (_strErrorMessage + ("System generated error:-" + ("\r\n" + oException.Message)));
                _oErrorObject = oException;
            }
        }

        //        '''  This procedure is used to set the control value.

        private void SetControlValue(Control ocontrol)
        {
            CheckBox oCheckBox;
            RadioButton oRadioButton;
            ComboBox oComboBox;
           
            clsListViewMIL oListView;
            try
            {
                modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables._blnIsFocusedInRevision = false;
                if ((ocontrol.Name == oDataRowView["ConName"]))
                {
                    
                    if ((ocontrol.GetType() == typeof(TextBox)))
                    {
                        modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables._blnIsFocusedInRevision = true;
                        ocontrol.Show();
                        ocontrol.Focus();
                        ocontrol.Text = Convert.ToString(oDataRowView["Value"]);
                    }
                    else if ((ocontrol.GetType() == typeof(ComboBox)))
                    {
                        
                        oComboBox = ((ComboBox)(ocontrol));
                        oComboBox.Text = Convert.ToString(oDataRowView["Value"]);
                    }
                    else if ((ocontrol.GetType() == typeof(CheckBox)))
                    {
                        oCheckBox = ((CheckBox)(ocontrol));
                        oCheckBox.Checked = Convert.ToBoolean(oDataRowView["Value"]);
                    }
                    else if ((ocontrol.GetType() == typeof(RadioButton)))
                    {
                        oRadioButton = ((RadioButton)(ocontrol));
                        oRadioButton.Checked = Convert.ToBoolean(oDataRowView["Value"]);
                    }
                    else if ((ocontrol.GetType() == typeof(ListView)))
                    {
                        oListView = ((clsListViewMIL)(ocontrol));
                        string[] items;
                        items = oDataRowView["Value"].ToString().Split('-');
                        ListViewItem oListviewItem = oListView.FindItemWithText(items[0]);
                        int Position = oListView.Items.IndexOf(oListviewItem);
                        if ((Position >= 0))
                        {
                            oListView.Items[Position].Selected = true;
                        }
                        
                    }
                    else if ((ocontrol.GetType() == typeof(RichTextBox)))
                    {
                        ocontrol.Text = Convert.ToString(oDataRowView["Value"]);
                       
                    }
                    return;
                }
            }
            catch (Exception oException)
            {
                _strErrorMessage = ("UNABLE TO SET THE CONTROL VALUE !!" + "\r\n");
                _strErrorMessage = (_strErrorMessage + ("System generated error:-" + ("\r\n" + oException.Message)));
                _oErrorObject = oException;
            }
        }


       // ''' This procedue is used to get the controls of the form

        private void GetControls(Control oFormControl)
        {
            
            foreach (Control oControl in oFormControl.Controls)
            {
                
                if ((!(oControl.GetType() == typeof(ListView)) && oControl.HasChildren))
                {
                    GetControls(oControl);
                }
                else
                {
                    AddDataToTable(oControl);
                }
            }

        }

       #endregion

       #region Functions

       // This function is used to check the table struture.

        private bool CheckTableStructure()
        {
           bool CheckTableStructure = true;
            try
            {
                if ((_oTable.TableName == _SourceForm.Name))
                {
                    foreach (string strColumnName in aTableStructure)
                    {
                        if (!_oTable.Columns.Contains(strColumnName))
                        {
                            CheckTableStructure = false;
                            _strErrorMessage = ("The Tablename doen\'t contain the specified structure like" + "\r\n");
                            _strErrorMessage += "TabIndex , ConName and Value";
                            break;
                        }
                    }
                }
                else
                {
                    _strErrorMessage = "The Tablename and the Form are not Coinciding";
                    CheckTableStructure = false;
                }
            }
            catch (Exception oException)
            {
                _strErrorMessage = ("THE TABLE STRUCTURE IS INCORRECT !!" + "\r\n");
                _strErrorMessage = (_strErrorMessage + ("System generated error:-" + ("\r\n" + oException.Message)));
                _oErrorObject = oException;
            }
            return CheckTableStructure;
        }

      // ''' This function is used to set the form with data.

       public bool SetDataToForm(DataTable oTable, Form oSourceForm) 
       {
        DataView odataview;
       bool  SetDataToForm = false;
        _oTable = oTable;
        _SourceForm = oSourceForm;
        try {
            if (CheckTableStructure()) 
            {
                odataview = SortTable();
                foreach (DataRowView oDataRowView in odataview) {
                    FindControl(_SourceForm);
                }
                SetDataToForm = true;
            }
        }
        catch (Exception oException) {
            _strErrorMessage = ("THE DATA IS NOT BEEN SET TO THE FORM !!" + "\r\n");
            _strErrorMessage = (_strErrorMessage + ("System generated error:-" + ("\r\n" + oException.Message)));
            _oErrorObject = oException;
        }
        return SetDataToForm;
    }

        //''' This function is used to sort the table.

        private DataView SortTable() {
        DataTable oDataTable;
        DataRow oRow;
        DataView SortTable = null;
        try {
            oDataTable = _oTable;
            CreateSourceTable(_oTable.TableName);
            foreach (DataRow odataRow in oDataTable.Rows) {
                oRow = _oTable.NewRow();
                oRow["TabIndex"] = ((Int32)(odataRow["TabIndex"]));
                oRow["ConName"] = odataRow["ConName"];
                oRow["Value"] = odataRow["Value"];
                _oTable.Rows.Add(oRow);
            }
            SortTable = _oTable.DefaultView;
            SortTable.Sort = "TabIndex";
        }
        catch (Exception oException) {
            _strErrorMessage = ("THE DATA IS NOT BEEN SET TO THE FORM !!" + "\r\n");
            _strErrorMessage = (_strErrorMessage + ("System generated error:-" + ("\r\n" + oException.Message)));
            _oErrorObject = oException;
        }
        return SortTable;
    }

       //''' This function is used to retreive and store all controls information.

        public DataTable StoreFormData(Control oFormControl)
        {
            
            try
            {
                if (CreateSourceTable(oFormControl.Name))
                {
                    GetControls(oFormControl);
                    return _oTable;
                }
            }
            catch (Exception oException)
            {
                _strErrorMessage = ("THE DATA IS NOT RETREIVED FROM THE SPECIFIED CONTROL FROM THE FORM !!" + "\r\n");
                _strErrorMessage = (_strErrorMessage + ("System generated error:-" + ("\r\n" + oException.Message)));
                _oErrorObject = oException;
            }
            return _oTable;

        }

       #endregion

   }
}
