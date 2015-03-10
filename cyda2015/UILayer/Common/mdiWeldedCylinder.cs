using System.Windows.Forms;
using IFLBaseDataLayer;
using IFLCustomUILayer;
using IFLCommonLayer;
using System;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using Microsoft.Win32;
using System.Diagnostics;
using Welded.FunctionalLayer;

namespace Welded.UILayer.Common
{
    public partial class mdiWeldedCylinder : Form
    {
        
        private Single _sMiddle=0;
        private Single _sDelta=0.1f;

        public mdiWeldedCylinder()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + m_ChildFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private int m_ChildFormNumber = 0;

        private void timerCurrentDateAndTime_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("h:mm:ss tt");
        }

        private void NewMenuItem_Click(object sender, EventArgs e) 
        {

        }

#region SubProcedures

        private void CreateObjectOfFunctionalClass()
        {
          modWeldedCylinder.ObjClsWeldedCylinderFunctionalClass  = new clsWeldedCylinderFunctionalClass();
            
        }
        private void GetUserAndServerDetails()
        {
            lvwLoginDetails.Items.Clear();
            if (!(modWeldedCylinder.MonarchConnectionObject == null))
            {
                lvwLoginDetails.Columns.Add("Property", 107, HorizontalAlignment.Center);
                lvwLoginDetails.Columns.Add("Value", 200, HorizontalAlignment.Center);

                ListViewItem oListviewItem1;
                oListviewItem1 = lvwLoginDetails.Items.Add("ServerName");
                lvwLoginDetails.Items[0].SubItems.Add(modWeldedCylinder.MonarchConnectionObject.ServerName);
                ListViewItem oListViewItem2;
                oListViewItem2 = lvwLoginDetails.Items.Add("DataBase");
                lvwLoginDetails.Items[1].SubItems.Add(modWeldedCylinder.MonarchConnectionObject.DataBaseName);
                ListViewItem oListViewItem3;
                oListViewItem3 = lvwLoginDetails.Items.Add("UserName");
                lvwLoginDetails.Items[2].SubItems.Add(Environment.UserName);
                ListViewItem oListViewItem4;
                oListViewItem4 = lvwLoginDetails.Items.Add("ComputerName");
                lvwLoginDetails.Items[3].SubItems.Add(Environment.MachineName);
                ListViewItem oListViewItem5;
                oListViewItem5 = lvwLoginDetails.Items.Add("DomainName");
                lvwLoginDetails.Items[4].SubItems.Add(System.Environment.UserDomainName);
            }
            
        }


#endregion

       

        #region Events

        private void mdiWeldedCylinder_Load(object sender, EventArgs e)
        {
            CreateObjectOfFunctionalClass();
            MIL_Image();
            GetUserAndServerDetails();
        }
        private void MIL_Image()
        {
            //picMIL_Image.ImageLocation=
        }
        #endregion



    }
}
