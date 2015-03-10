namespace Welded.UILayer.Common.Import_Options_Screens
{
    partial class frmImportPorts
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
            this.txtOrificeSize = new IFLCustomUILayer.IFLTextBox();
            this.lblOrificeSize = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.LabelGradient4 = new LabelGradient.LabelGradient();
            this.LabelGradient5 = new LabelGradient.LabelGradient();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblPortODAtWeld = new System.Windows.Forms.Label();
            this.grpContractDetails = new System.Windows.Forms.GroupBox();
            this.txtPortODAtWeld = new IFLCustomUILayer.IFLTextBox();
            this.txtPortHeight = new IFLCustomUILayer.IFLTextBox();
            this.lblPortHeight = new System.Windows.Forms.Label();
            this.lblPortEndType = new System.Windows.Forms.Label();
            this.lblPortsDetails = new LabelGradient.LabelGradient();
            this.cmbPortEndType = new IFLCustomUILayer.IFLComboBox();
            this.LabelGradient3 = new LabelGradient.LabelGradient();
            this.LabelGradient2 = new LabelGradient.LabelGradient();
            this.lblGradientContractDetails = new LabelGradient.LabelGradient();
            this.ofdPortDetails = new System.Windows.Forms.OpenFileDialog();
            this.grpContractDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOrificeSize
            // 
            this.txtOrificeSize.AcceptEnterKeyAsTab = true;
            this.txtOrificeSize.ApplyIFLColor = true;
            this.txtOrificeSize.AssociateLabel = null;
            this.txtOrificeSize.IFLDataTag = null;
            this.txtOrificeSize.InvalidInputCharacters = "";
            this.txtOrificeSize.Location = new System.Drawing.Point(177, 145);
            this.txtOrificeSize.MaxLength = 32;
            this.txtOrificeSize.Name = "txtOrificeSize";
            this.txtOrificeSize.Size = new System.Drawing.Size(238, 20);
            this.txtOrificeSize.StatusMessage = "";
            this.txtOrificeSize.StatusObject = null;
            this.txtOrificeSize.TabIndex = 26;
            // 
            // lblOrificeSize
            // 
            this.lblOrificeSize.AutoSize = true;
            this.lblOrificeSize.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F);
            this.lblOrificeSize.Location = new System.Drawing.Point(56, 147);
            this.lblOrificeSize.Name = "lblOrificeSize";
            this.lblOrificeSize.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrificeSize.Size = new System.Drawing.Size(67, 15);
            this.lblOrificeSize.TabIndex = 25;
            this.lblOrificeSize.Text = "Orifice Size";
            // 
            // btnAccept
            // 
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAccept.Location = new System.Drawing.Point(293, 180);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(90, 25);
            this.btnAccept.TabIndex = 24;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            // 
            // LabelGradient4
            // 
            this.LabelGradient4.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.LabelGradient4.Dock = System.Windows.Forms.DockStyle.Right;
            this.LabelGradient4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGradient4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LabelGradient4.GradientColorOne = System.Drawing.Color.Honeydew;
            this.LabelGradient4.GradientColorTwo = System.Drawing.Color.Olive;
            this.LabelGradient4.Location = new System.Drawing.Point(925, 11);
            this.LabelGradient4.Name = "LabelGradient4";
            this.LabelGradient4.Size = new System.Drawing.Size(10, 482);
            this.LabelGradient4.TabIndex = 124;
            this.LabelGradient4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LabelGradient5
            // 
            this.LabelGradient5.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.LabelGradient5.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelGradient5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGradient5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LabelGradient5.GradientColorOne = System.Drawing.Color.Olive;
            this.LabelGradient5.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.LabelGradient5.Location = new System.Drawing.Point(10, 0);
            this.LabelGradient5.Name = "LabelGradient5";
            this.LabelGradient5.Size = new System.Drawing.Size(925, 11);
            this.LabelGradient5.TabIndex = 125;
            this.LabelGradient5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnBrowse
            // 
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBrowse.Location = new System.Drawing.Point(177, 180);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(90, 25);
            this.btnBrowse.TabIndex = 23;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // lblPortODAtWeld
            // 
            this.lblPortODAtWeld.AutoSize = true;
            this.lblPortODAtWeld.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F);
            this.lblPortODAtWeld.Location = new System.Drawing.Point(56, 109);
            this.lblPortODAtWeld.Name = "lblPortODAtWeld";
            this.lblPortODAtWeld.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPortODAtWeld.Size = new System.Drawing.Size(92, 15);
            this.lblPortODAtWeld.TabIndex = 22;
            this.lblPortODAtWeld.Text = "Port OD At Weld";
            // 
            // grpContractDetails
            // 
            this.grpContractDetails.BackColor = System.Drawing.Color.Ivory;
            this.grpContractDetails.Controls.Add(this.txtOrificeSize);
            this.grpContractDetails.Controls.Add(this.lblOrificeSize);
            this.grpContractDetails.Controls.Add(this.btnAccept);
            this.grpContractDetails.Controls.Add(this.btnBrowse);
            this.grpContractDetails.Controls.Add(this.txtPortODAtWeld);
            this.grpContractDetails.Controls.Add(this.lblPortODAtWeld);
            this.grpContractDetails.Controls.Add(this.txtPortHeight);
            this.grpContractDetails.Controls.Add(this.lblPortHeight);
            this.grpContractDetails.Controls.Add(this.lblPortEndType);
            this.grpContractDetails.Controls.Add(this.lblPortsDetails);
            this.grpContractDetails.Controls.Add(this.cmbPortEndType);
            this.grpContractDetails.Location = new System.Drawing.Point(236, 150);
            this.grpContractDetails.Name = "grpContractDetails";
            this.grpContractDetails.Size = new System.Drawing.Size(469, 211);
            this.grpContractDetails.TabIndex = 127;
            this.grpContractDetails.TabStop = false;
            // 
            // txtPortODAtWeld
            // 
            this.txtPortODAtWeld.AcceptEnterKeyAsTab = true;
            this.txtPortODAtWeld.ApplyIFLColor = true;
            this.txtPortODAtWeld.AssociateLabel = null;
            this.txtPortODAtWeld.IFLDataTag = null;
            this.txtPortODAtWeld.InvalidInputCharacters = "";
            this.txtPortODAtWeld.Location = new System.Drawing.Point(177, 107);
            this.txtPortODAtWeld.MaxLength = 32;
            this.txtPortODAtWeld.Name = "txtPortODAtWeld";
            this.txtPortODAtWeld.Size = new System.Drawing.Size(238, 20);
            this.txtPortODAtWeld.StatusMessage = "";
            this.txtPortODAtWeld.StatusObject = null;
            this.txtPortODAtWeld.TabIndex = 21;
            // 
            // txtPortHeight
            // 
            this.txtPortHeight.AcceptEnterKeyAsTab = true;
            this.txtPortHeight.ApplyIFLColor = true;
            this.txtPortHeight.AssociateLabel = null;
            this.txtPortHeight.IFLDataTag = null;
            this.txtPortHeight.InvalidInputCharacters = "";
            this.txtPortHeight.Location = new System.Drawing.Point(177, 69);
            this.txtPortHeight.MaxLength = 32;
            this.txtPortHeight.Name = "txtPortHeight";
            this.txtPortHeight.Size = new System.Drawing.Size(238, 20);
            this.txtPortHeight.StatusMessage = "";
            this.txtPortHeight.StatusObject = null;
            this.txtPortHeight.TabIndex = 3;
            // 
            // lblPortHeight
            // 
            this.lblPortHeight.AutoSize = true;
            this.lblPortHeight.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F);
            this.lblPortHeight.Location = new System.Drawing.Point(56, 71);
            this.lblPortHeight.Name = "lblPortHeight";
            this.lblPortHeight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPortHeight.Size = new System.Drawing.Size(67, 15);
            this.lblPortHeight.TabIndex = 4;
            this.lblPortHeight.Text = "Port Height";
            // 
            // lblPortEndType
            // 
            this.lblPortEndType.AutoSize = true;
            this.lblPortEndType.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortEndType.Location = new System.Drawing.Point(53, 33);
            this.lblPortEndType.Name = "lblPortEndType";
            this.lblPortEndType.Size = new System.Drawing.Size(81, 15);
            this.lblPortEndType.TabIndex = 0;
            this.lblPortEndType.Text = "Port End Type";
            // 
            // lblPortsDetails
            // 
            this.lblPortsDetails.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPortsDetails.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.lblPortsDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortsDetails.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPortsDetails.GradientColorOne = System.Drawing.Color.Olive;
            this.lblPortsDetails.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.lblPortsDetails.Location = new System.Drawing.Point(-3, 0);
            this.lblPortsDetails.Name = "lblPortsDetails";
            this.lblPortsDetails.Size = new System.Drawing.Size(472, 21);
            this.lblPortsDetails.TabIndex = 20;
            this.lblPortsDetails.Text = "Ports Details";
            this.lblPortsDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbPortEndType
            // 
            this.cmbPortEndType.AcceptEnterKeyAsTab = true;
            this.cmbPortEndType.AssociateLabel = null;
            this.cmbPortEndType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortEndType.FormattingEnabled = true;
            this.cmbPortEndType.IFLDataTag = null;
            this.cmbPortEndType.ItemHeight = 13;
            this.cmbPortEndType.Location = new System.Drawing.Point(177, 31);
            this.cmbPortEndType.Name = "cmbPortEndType";
            this.cmbPortEndType.Size = new System.Drawing.Size(238, 21);
            this.cmbPortEndType.StatusMessage = null;
            this.cmbPortEndType.StatusObject = null;
            this.cmbPortEndType.TabIndex = 2;
            // 
            // LabelGradient3
            // 
            this.LabelGradient3.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.LabelGradient3.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelGradient3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGradient3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LabelGradient3.GradientColorOne = System.Drawing.Color.Olive;
            this.LabelGradient3.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.LabelGradient3.Location = new System.Drawing.Point(0, 0);
            this.LabelGradient3.Name = "LabelGradient3";
            this.LabelGradient3.Size = new System.Drawing.Size(10, 493);
            this.LabelGradient3.TabIndex = 123;
            this.LabelGradient3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LabelGradient2
            // 
            this.LabelGradient2.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.LabelGradient2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LabelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGradient2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LabelGradient2.GradientColorOne = System.Drawing.Color.Olive;
            this.LabelGradient2.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.LabelGradient2.Location = new System.Drawing.Point(0, 493);
            this.LabelGradient2.Name = "LabelGradient2";
            this.LabelGradient2.Size = new System.Drawing.Size(935, 11);
            this.LabelGradient2.TabIndex = 122;
            this.LabelGradient2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblGradientContractDetails
            // 
            this.lblGradientContractDetails.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.lblGradientContractDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGradientContractDetails.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGradientContractDetails.GradientColorOne = System.Drawing.Color.DarkGoldenrod;
            this.lblGradientContractDetails.GradientColorTwo = System.Drawing.Color.DarkGoldenrod;
            this.lblGradientContractDetails.Location = new System.Drawing.Point(233, 139);
            this.lblGradientContractDetails.Name = "lblGradientContractDetails";
            this.lblGradientContractDetails.Size = new System.Drawing.Size(478, 236);
            this.lblGradientContractDetails.TabIndex = 126;
            this.lblGradientContractDetails.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ofdPortDetails
            // 
            this.ofdPortDetails.FileName = "OpenFileDialog1";
            // 
            // frmImportPorts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(935, 504);
            this.Controls.Add(this.LabelGradient4);
            this.Controls.Add(this.LabelGradient5);
            this.Controls.Add(this.grpContractDetails);
            this.Controls.Add(this.LabelGradient3);
            this.Controls.Add(this.LabelGradient2);
            this.Controls.Add(this.lblGradientContractDetails);
            this.Name = "frmImportPorts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.grpContractDetails.ResumeLayout(false);
            this.grpContractDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal IFLCustomUILayer.IFLTextBox txtOrificeSize;
        internal System.Windows.Forms.Label lblOrificeSize;
        internal System.Windows.Forms.Button btnAccept;
        internal LabelGradient.LabelGradient LabelGradient4;
        internal LabelGradient.LabelGradient LabelGradient5;
        internal System.Windows.Forms.Button btnBrowse;
        internal System.Windows.Forms.Label lblPortODAtWeld;
        internal System.Windows.Forms.GroupBox grpContractDetails;
        internal IFLCustomUILayer.IFLTextBox txtPortODAtWeld;
        internal IFLCustomUILayer.IFLTextBox txtPortHeight;
        internal System.Windows.Forms.Label lblPortHeight;
        internal System.Windows.Forms.Label lblPortEndType;
        internal LabelGradient.LabelGradient lblPortsDetails;
        internal IFLCustomUILayer.IFLComboBox cmbPortEndType;
        internal LabelGradient.LabelGradient LabelGradient3;
        internal LabelGradient.LabelGradient LabelGradient2;
        internal LabelGradient.LabelGradient lblGradientContractDetails;
        internal System.Windows.Forms.OpenFileDialog ofdPortDetails;
    }
}