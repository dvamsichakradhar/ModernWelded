namespace Welded.UILayer.Common
{
    partial class frmUpdateDatabaseRecords
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grbCastingListView = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdateToDatabase = new System.Windows.Forms.Button();
            this.lvwDatabaseRecordView = new System.Windows.Forms.ListView();
            this.cmbPortAngle = new IFLCustomUILayer.IFLComboBox();
            this.lblPortAngle = new System.Windows.Forms.Label();
            this.txtSearchString = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.cmbPortType = new IFLCustomUILayer.IFLComboBox();
            this.lblTypeOfPort = new System.Windows.Forms.Label();
            this.cmbEndPort = new IFLCustomUILayer.IFLComboBox();
            this.lblBaseEndPort = new System.Windows.Forms.Label();
            this.cmbSubConfiguration = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbConfiguration = new System.Windows.Forms.ComboBox();
            this.lblConfiguration = new System.Windows.Forms.Label();
            this.lbDatabaseRecord = new LabelGradient.LabelGradient();
            this.lblGreen2 = new LabelGradient.LabelGradient();
            this.lblGreen1 = new LabelGradient.LabelGradient();
            this.lblGreen4 = new LabelGradient.LabelGradient();
            this.lblOrange = new LabelGradient.LabelGradient();
            this.lblGreen3 = new LabelGradient.LabelGradient();
            this.grbCastingListView.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbCastingListView
            // 
            this.grbCastingListView.BackColor = System.Drawing.Color.Ivory;
            this.grbCastingListView.Controls.Add(this.btnCancel);
            this.grbCastingListView.Controls.Add(this.btnUpdateToDatabase);
            this.grbCastingListView.Controls.Add(this.lvwDatabaseRecordView);
            this.grbCastingListView.Controls.Add(this.cmbPortAngle);
            this.grbCastingListView.Controls.Add(this.lblPortAngle);
            this.grbCastingListView.Controls.Add(this.txtSearchString);
            this.grbCastingListView.Controls.Add(this.lblSearch);
            this.grbCastingListView.Controls.Add(this.cmbPortType);
            this.grbCastingListView.Controls.Add(this.lblTypeOfPort);
            this.grbCastingListView.Controls.Add(this.cmbEndPort);
            this.grbCastingListView.Controls.Add(this.lblBaseEndPort);
            this.grbCastingListView.Controls.Add(this.cmbSubConfiguration);
            this.grbCastingListView.Controls.Add(this.Label1);
            this.grbCastingListView.Controls.Add(this.cmbConfiguration);
            this.grbCastingListView.Controls.Add(this.lblConfiguration);
            this.grbCastingListView.Controls.Add(this.lbDatabaseRecord);
            this.grbCastingListView.Location = new System.Drawing.Point(31, 47);
            this.grbCastingListView.Name = "grbCastingListView";
            this.grbCastingListView.Size = new System.Drawing.Size(565, 363);
            this.grbCastingListView.TabIndex = 128;
            this.grbCastingListView.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(429, 141);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 20);
            this.btnCancel.TabIndex = 125;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnUpdateToDatabase
            // 
            this.btnUpdateToDatabase.Location = new System.Drawing.Point(329, 141);
            this.btnUpdateToDatabase.Name = "btnUpdateToDatabase";
            this.btnUpdateToDatabase.Size = new System.Drawing.Size(94, 20);
            this.btnUpdateToDatabase.TabIndex = 124;
            this.btnUpdateToDatabase.Text = "Update";
            this.btnUpdateToDatabase.UseVisualStyleBackColor = true;
            // 
            // lvwDatabaseRecordView
            // 
            this.lvwDatabaseRecordView.GridLines = true;
            this.lvwDatabaseRecordView.Location = new System.Drawing.Point(47, 174);
            this.lvwDatabaseRecordView.MultiSelect = false;
            this.lvwDatabaseRecordView.Name = "lvwDatabaseRecordView";
            this.lvwDatabaseRecordView.Size = new System.Drawing.Size(476, 158);
            this.lvwDatabaseRecordView.TabIndex = 123;
            this.lvwDatabaseRecordView.UseCompatibleStateImageBehavior = false;
            this.lvwDatabaseRecordView.View = System.Windows.Forms.View.Details;
            // 
            // cmbPortAngle
            // 
            this.cmbPortAngle.AcceptEnterKeyAsTab = true;
            this.cmbPortAngle.AssociateLabel = null;
            this.cmbPortAngle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortAngle.FormattingEnabled = true;
            this.cmbPortAngle.IFLDataTag = null;
            this.cmbPortAngle.Location = new System.Drawing.Point(373, 86);
            this.cmbPortAngle.Name = "cmbPortAngle";
            this.cmbPortAngle.Size = new System.Drawing.Size(151, 21);
            this.cmbPortAngle.StatusMessage = null;
            this.cmbPortAngle.StatusObject = null;
            this.cmbPortAngle.TabIndex = 121;
            // 
            // lblPortAngle
            // 
            this.lblPortAngle.AutoSize = true;
            this.lblPortAngle.Location = new System.Drawing.Point(295, 90);
            this.lblPortAngle.Name = "lblPortAngle";
            this.lblPortAngle.Size = new System.Drawing.Size(59, 13);
            this.lblPortAngle.TabIndex = 122;
            this.lblPortAngle.Text = " Port Angle";
            // 
            // txtSearchString
            // 
            this.txtSearchString.Location = new System.Drawing.Point(127, 141);
            this.txtSearchString.Name = "txtSearchString";
            this.txtSearchString.Size = new System.Drawing.Size(151, 20);
            this.txtSearchString.TabIndex = 120;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(40, 145);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(47, 13);
            this.lblSearch.TabIndex = 119;
            this.lblSearch.Text = "Search..";
            // 
            // cmbPortType
            // 
            this.cmbPortType.AcceptEnterKeyAsTab = true;
            this.cmbPortType.AssociateLabel = null;
            this.cmbPortType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortType.FormattingEnabled = true;
            this.cmbPortType.IFLDataTag = null;
            this.cmbPortType.Location = new System.Drawing.Point(373, 59);
            this.cmbPortType.Name = "cmbPortType";
            this.cmbPortType.Size = new System.Drawing.Size(151, 21);
            this.cmbPortType.StatusMessage = null;
            this.cmbPortType.StatusObject = null;
            this.cmbPortType.TabIndex = 117;
            // 
            // lblTypeOfPort
            // 
            this.lblTypeOfPort.AutoSize = true;
            this.lblTypeOfPort.Location = new System.Drawing.Point(295, 63);
            this.lblTypeOfPort.Name = "lblTypeOfPort";
            this.lblTypeOfPort.Size = new System.Drawing.Size(56, 13);
            this.lblTypeOfPort.TabIndex = 118;
            this.lblTypeOfPort.Text = " Port Type";
            // 
            // cmbEndPort
            // 
            this.cmbEndPort.AcceptEnterKeyAsTab = true;
            this.cmbEndPort.AssociateLabel = null;
            this.cmbEndPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEndPort.FormattingEnabled = true;
            this.cmbEndPort.IFLDataTag = null;
            this.cmbEndPort.Location = new System.Drawing.Point(127, 62);
            this.cmbEndPort.Name = "cmbEndPort";
            this.cmbEndPort.Size = new System.Drawing.Size(151, 21);
            this.cmbEndPort.StatusMessage = null;
            this.cmbEndPort.StatusObject = null;
            this.cmbEndPort.TabIndex = 115;
            // 
            // lblBaseEndPort
            // 
            this.lblBaseEndPort.AutoSize = true;
            this.lblBaseEndPort.Location = new System.Drawing.Point(40, 66);
            this.lblBaseEndPort.Name = "lblBaseEndPort";
            this.lblBaseEndPort.Size = new System.Drawing.Size(75, 13);
            this.lblBaseEndPort.TabIndex = 116;
            this.lblBaseEndPort.Text = "Base End Port";
            // 
            // cmbSubConfiguration
            // 
            this.cmbSubConfiguration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubConfiguration.FormattingEnabled = true;
            this.cmbSubConfiguration.Location = new System.Drawing.Point(373, 32);
            this.cmbSubConfiguration.Name = "cmbSubConfiguration";
            this.cmbSubConfiguration.Size = new System.Drawing.Size(151, 21);
            this.cmbSubConfiguration.TabIndex = 114;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(295, 36);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(69, 13);
            this.Label1.TabIndex = 113;
            this.Label1.Text = "Configuration";
            // 
            // cmbConfiguration
            // 
            this.cmbConfiguration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConfiguration.FormattingEnabled = true;
            this.cmbConfiguration.Location = new System.Drawing.Point(127, 31);
            this.cmbConfiguration.Name = "cmbConfiguration";
            this.cmbConfiguration.Size = new System.Drawing.Size(151, 21);
            this.cmbConfiguration.TabIndex = 112;
            // 
            // lblConfiguration
            // 
            this.lblConfiguration.AutoSize = true;
            this.lblConfiguration.Location = new System.Drawing.Point(40, 35);
            this.lblConfiguration.Name = "lblConfiguration";
            this.lblConfiguration.Size = new System.Drawing.Size(69, 13);
            this.lblConfiguration.TabIndex = 111;
            this.lblConfiguration.Text = "Configuration";
            // 
            // lbDatabaseRecord
            // 
            this.lbDatabaseRecord.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.lbDatabaseRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDatabaseRecord.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbDatabaseRecord.GradientColorOne = System.Drawing.Color.Olive;
            this.lbDatabaseRecord.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.lbDatabaseRecord.Location = new System.Drawing.Point(0, 0);
            this.lbDatabaseRecord.Name = "lbDatabaseRecord";
            this.lbDatabaseRecord.Size = new System.Drawing.Size(565, 19);
            this.lbDatabaseRecord.TabIndex = 110;
            this.lbDatabaseRecord.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblGreen2
            // 
            this.lblGreen2.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.lblGreen2.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblGreen2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreen2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGreen2.GradientColorOne = System.Drawing.Color.Olive;
            this.lblGreen2.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.lblGreen2.Location = new System.Drawing.Point(1014, 19);
            this.lblGreen2.Name = "lblGreen2";
            this.lblGreen2.Size = new System.Drawing.Size(22, 742);
            this.lblGreen2.TabIndex = 131;
            this.lblGreen2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblGreen1
            // 
            this.lblGreen1.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.lblGreen1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGreen1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreen1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblGreen1.GradientColorOne = System.Drawing.Color.Olive;
            this.lblGreen1.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.lblGreen1.Location = new System.Drawing.Point(20, 0);
            this.lblGreen1.Name = "lblGreen1";
            this.lblGreen1.Size = new System.Drawing.Size(1016, 19);
            this.lblGreen1.TabIndex = 130;
            this.lblGreen1.Text = "Casting Details";
            this.lblGreen1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGreen4
            // 
            this.lblGreen4.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.lblGreen4.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblGreen4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreen4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGreen4.GradientColorOne = System.Drawing.Color.Olive;
            this.lblGreen4.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.lblGreen4.Location = new System.Drawing.Point(0, 0);
            this.lblGreen4.Name = "lblGreen4";
            this.lblGreen4.Size = new System.Drawing.Size(20, 761);
            this.lblGreen4.TabIndex = 132;
            this.lblGreen4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblOrange
            // 
            this.lblOrange.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.lblOrange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrange.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOrange.GradientColorOne = System.Drawing.Color.DarkGoldenrod;
            this.lblOrange.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.lblOrange.Location = new System.Drawing.Point(26, 28);
            this.lblOrange.Name = "lblOrange";
            this.lblOrange.Size = new System.Drawing.Size(578, 396);
            this.lblOrange.TabIndex = 129;
            this.lblOrange.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblGreen3
            // 
            this.lblGreen3.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.lblGreen3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblGreen3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreen3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGreen3.GradientColorOne = System.Drawing.Color.Olive;
            this.lblGreen3.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.lblGreen3.Location = new System.Drawing.Point(0, 761);
            this.lblGreen3.Name = "lblGreen3";
            this.lblGreen3.Size = new System.Drawing.Size(1036, 19);
            this.lblGreen3.TabIndex = 133;
            this.lblGreen3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmUpdateDatabaseRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1036, 780);
            this.ControlBox = false;
            this.Controls.Add(this.grbCastingListView);
            this.Controls.Add(this.lblGreen2);
            this.Controls.Add(this.lblGreen1);
            this.Controls.Add(this.lblGreen4);
            this.Controls.Add(this.lblOrange);
            this.Controls.Add(this.lblGreen3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUpdateDatabaseRecords";
            this.Text = "frmUpdateDatabaseRecords";
            this.grbCastingListView.ResumeLayout(false);
            this.grbCastingListView.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox grbCastingListView;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnUpdateToDatabase;
        internal System.Windows.Forms.ListView lvwDatabaseRecordView;
        internal IFLCustomUILayer.IFLComboBox cmbPortAngle;
        internal System.Windows.Forms.Label lblPortAngle;
        internal System.Windows.Forms.TextBox txtSearchString;
        internal System.Windows.Forms.Label lblSearch;
        internal IFLCustomUILayer.IFLComboBox cmbPortType;
        internal System.Windows.Forms.Label lblTypeOfPort;
        internal IFLCustomUILayer.IFLComboBox cmbEndPort;
        internal System.Windows.Forms.Label lblBaseEndPort;
        internal System.Windows.Forms.ComboBox cmbSubConfiguration;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cmbConfiguration;
        internal System.Windows.Forms.Label lblConfiguration;
        internal LabelGradient.LabelGradient lbDatabaseRecord;
        internal LabelGradient.LabelGradient lblGreen2;
        internal LabelGradient.LabelGradient lblGreen1;
        internal LabelGradient.LabelGradient lblGreen4;
        internal LabelGradient.LabelGradient lblOrange;
        internal LabelGradient.LabelGradient lblGreen3;
    }
}