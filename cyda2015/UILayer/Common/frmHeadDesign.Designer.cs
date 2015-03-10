namespace Welded.UILayer.Common
{
    partial class frmHeadDesign
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
            this.txtCylinderHeadCode = new IFLCustomUILayer.IFLNumericBox();
            this.grbInsertCylinderHeadDetailsIntoDB = new System.Windows.Forms.GroupBox();
            this.btnHeadDesignContinue = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblInsertCylinderHeadDetails = new LabelGradient.LabelGradient();
            this.LabelGradient5 = new LabelGradient.LabelGradient();
            this.txtSealType = new System.Windows.Forms.TextBox();
            this.lblCylinderHeadCode = new System.Windows.Forms.Label();
            this.cmbRodWearRingQty = new IFLCustomUILayer.IFLComboBox();
            this.lblInsertIntoDb = new LabelGradient.LabelGradient();
            this.lblRodWearRingQty = new System.Windows.Forms.Label();
            this.cmbRodWiperType = new IFLCustomUILayer.IFLComboBox();
            this.cmbRodWearRing = new IFLCustomUILayer.IFLComboBox();
            this.lblHeadDesign = new LabelGradient.LabelGradient();
            this.grbHeadDesign = new System.Windows.Forms.GroupBox();
            this.lblRodWiperType = new System.Windows.Forms.Label();
            this.lblRodWearRing = new System.Windows.Forms.Label();
            this.cmbRodSeal = new IFLCustomUILayer.IFLComboBox();
            this.cmbHeadType = new IFLCustomUILayer.IFLComboBox();
            this.lblRodSeal = new System.Windows.Forms.Label();
            this.lblHeadDesignIndex = new LabelGradient.LabelGradient();
            this.lblHeadType = new System.Windows.Forms.Label();
            this.LabelGradient4 = new LabelGradient.LabelGradient();
            this.LabelGradient3 = new LabelGradient.LabelGradient();
            this.LabelGradient2 = new LabelGradient.LabelGradient();
            this.temCylinderHeadCode = new IFLCustomUILayer.IFLNumericBox();
            this.grbInsertCylinderHeadDetailsIntoDB.SuspendLayout();
            this.grbHeadDesign.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCylinderHeadCode
            // 
            this.txtCylinderHeadCode.AcceptEnterKeyAsTab = true;
            this.txtCylinderHeadCode.ApplyIFLColor = true;
            this.txtCylinderHeadCode.AssociateLabel = null;
            this.txtCylinderHeadCode.DecimalValue = 2;
            this.txtCylinderHeadCode.IFLDataTag = null;
            this.txtCylinderHeadCode.InvalidInputCharacters = "";
            this.txtCylinderHeadCode.IsAllowNegative = false;
            this.txtCylinderHeadCode.LengthValue = 5;
            this.txtCylinderHeadCode.Location = new System.Drawing.Point(609, 74);
            this.txtCylinderHeadCode.MaximumValue = 99999999999999D;
            this.txtCylinderHeadCode.MaxLength = 10;
            this.txtCylinderHeadCode.MinimumValue = 0D;
            this.txtCylinderHeadCode.Name = "txtCylinderHeadCode";
            this.txtCylinderHeadCode.Size = new System.Drawing.Size(98, 20);
            this.txtCylinderHeadCode.StatusMessage = "";
            this.txtCylinderHeadCode.StatusObject = null;
            this.txtCylinderHeadCode.TabIndex = 6;
            this.txtCylinderHeadCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grbInsertCylinderHeadDetailsIntoDB
            // 
            this.grbInsertCylinderHeadDetailsIntoDB.BackColor = System.Drawing.Color.Ivory;
            this.grbInsertCylinderHeadDetailsIntoDB.Controls.Add(this.btnHeadDesignContinue);
            this.grbInsertCylinderHeadDetailsIntoDB.Controls.Add(this.lblMessage);
            this.grbInsertCylinderHeadDetailsIntoDB.Controls.Add(this.lblInsertCylinderHeadDetails);
            this.grbInsertCylinderHeadDetailsIntoDB.Location = new System.Drawing.Point(60, 211);
            this.grbInsertCylinderHeadDetailsIntoDB.Name = "grbInsertCylinderHeadDetailsIntoDB";
            this.grbInsertCylinderHeadDetailsIntoDB.Size = new System.Drawing.Size(700, 85);
            this.grbInsertCylinderHeadDetailsIntoDB.TabIndex = 164;
            this.grbInsertCylinderHeadDetailsIntoDB.TabStop = false;
            // 
            // btnHeadDesignContinue
            // 
            this.btnHeadDesignContinue.Location = new System.Drawing.Point(583, 41);
            this.btnHeadDesignContinue.Name = "btnHeadDesignContinue";
            this.btnHeadDesignContinue.Size = new System.Drawing.Size(72, 23);
            this.btnHeadDesignContinue.TabIndex = 155;
            this.btnHeadDesignContinue.Text = "Continue";
            this.btnHeadDesignContinue.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(255, 46);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(191, 15);
            this.lblMessage.TabIndex = 153;
            this.lblMessage.Text = "This is an Existing CylinderHead";
            // 
            // lblInsertCylinderHeadDetails
            // 
            this.lblInsertCylinderHeadDetails.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.lblInsertCylinderHeadDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertCylinderHeadDetails.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInsertCylinderHeadDetails.GradientColorOne = System.Drawing.Color.Olive;
            this.lblInsertCylinderHeadDetails.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.lblInsertCylinderHeadDetails.Location = new System.Drawing.Point(-2, 0);
            this.lblInsertCylinderHeadDetails.Name = "lblInsertCylinderHeadDetails";
            this.lblInsertCylinderHeadDetails.Size = new System.Drawing.Size(702, 19);
            this.lblInsertCylinderHeadDetails.TabIndex = 21;
            this.lblInsertCylinderHeadDetails.Text = "Information";
            this.lblInsertCylinderHeadDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelGradient5
            // 
            this.LabelGradient5.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.LabelGradient5.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelGradient5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGradient5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LabelGradient5.GradientColorOne = System.Drawing.Color.Olive;
            this.LabelGradient5.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.LabelGradient5.Location = new System.Drawing.Point(20, 0);
            this.LabelGradient5.Name = "LabelGradient5";
            this.LabelGradient5.Size = new System.Drawing.Size(988, 19);
            this.LabelGradient5.TabIndex = 160;
            this.LabelGradient5.Text = "Head Design";
            this.LabelGradient5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSealType
            // 
            this.txtSealType.Location = new System.Drawing.Point(340, 37);
            this.txtSealType.Name = "txtSealType";
            this.txtSealType.Size = new System.Drawing.Size(98, 20);
            this.txtSealType.TabIndex = 156;
            this.txtSealType.Text = "RU9 Rod Seal";
            // 
            // lblCylinderHeadCode
            // 
            this.lblCylinderHeadCode.AutoSize = true;
            this.lblCylinderHeadCode.Location = new System.Drawing.Point(496, 77);
            this.lblCylinderHeadCode.Name = "lblCylinderHeadCode";
            this.lblCylinderHeadCode.Size = new System.Drawing.Size(101, 13);
            this.lblCylinderHeadCode.TabIndex = 132;
            this.lblCylinderHeadCode.Text = "Cylinder Head Code";
            // 
            // cmbRodWearRingQty
            // 
            this.cmbRodWearRingQty.AcceptEnterKeyAsTab = true;
            this.cmbRodWearRingQty.AssociateLabel = null;
            this.cmbRodWearRingQty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRodWearRingQty.FormattingEnabled = true;
            this.cmbRodWearRingQty.IFLDataTag = null;
            this.cmbRodWearRingQty.Location = new System.Drawing.Point(340, 74);
            this.cmbRodWearRingQty.Name = "cmbRodWearRingQty";
            this.cmbRodWearRingQty.Size = new System.Drawing.Size(98, 21);
            this.cmbRodWearRingQty.StatusMessage = null;
            this.cmbRodWearRingQty.StatusObject = null;
            this.cmbRodWearRingQty.TabIndex = 5;
            // 
            // lblInsertIntoDb
            // 
            this.lblInsertIntoDb.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.lblInsertIntoDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertIntoDb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInsertIntoDb.GradientColorOne = System.Drawing.Color.DarkGoldenrod;
            this.lblInsertIntoDb.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.lblInsertIntoDb.Location = new System.Drawing.Point(40, 190);
            this.lblInsertIntoDb.Name = "lblInsertIntoDb";
            this.lblInsertIntoDb.Size = new System.Drawing.Size(742, 126);
            this.lblInsertIntoDb.TabIndex = 163;
            this.lblInsertIntoDb.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRodWearRingQty
            // 
            this.lblRodWearRingQty.AutoSize = true;
            this.lblRodWearRingQty.Location = new System.Drawing.Point(229, 77);
            this.lblRodWearRingQty.Name = "lblRodWearRingQty";
            this.lblRodWearRingQty.Size = new System.Drawing.Size(100, 13);
            this.lblRodWearRingQty.TabIndex = 130;
            this.lblRodWearRingQty.Text = "Rod Wear Ring Qty";
            // 
            // cmbRodWiperType
            // 
            this.cmbRodWiperType.AcceptEnterKeyAsTab = true;
            this.cmbRodWiperType.AssociateLabel = null;
            this.cmbRodWiperType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRodWiperType.FormattingEnabled = true;
            this.cmbRodWiperType.IFLDataTag = null;
            this.cmbRodWiperType.Location = new System.Drawing.Point(609, 36);
            this.cmbRodWiperType.Name = "cmbRodWiperType";
            this.cmbRodWiperType.Size = new System.Drawing.Size(98, 21);
            this.cmbRodWiperType.StatusMessage = null;
            this.cmbRodWiperType.StatusObject = null;
            this.cmbRodWiperType.TabIndex = 3;
            // 
            // cmbRodWearRing
            // 
            this.cmbRodWearRing.AcceptEnterKeyAsTab = true;
            this.cmbRodWearRing.AssociateLabel = null;
            this.cmbRodWearRing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRodWearRing.FormattingEnabled = true;
            this.cmbRodWearRing.IFLDataTag = null;
            this.cmbRodWearRing.Items.AddRange(new object[] {
            "YES"});
            this.cmbRodWearRing.Location = new System.Drawing.Point(94, 74);
            this.cmbRodWearRing.Name = "cmbRodWearRing";
            this.cmbRodWearRing.Size = new System.Drawing.Size(98, 21);
            this.cmbRodWearRing.StatusMessage = null;
            this.cmbRodWearRing.StatusObject = null;
            this.cmbRodWearRing.TabIndex = 4;
            // 
            // lblHeadDesign
            // 
            this.lblHeadDesign.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.lblHeadDesign.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadDesign.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHeadDesign.GradientColorOne = System.Drawing.Color.DarkGoldenrod;
            this.lblHeadDesign.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.lblHeadDesign.Location = new System.Drawing.Point(43, 36);
            this.lblHeadDesign.Name = "lblHeadDesign";
            this.lblHeadDesign.Size = new System.Drawing.Size(739, 152);
            this.lblHeadDesign.TabIndex = 161;
            this.lblHeadDesign.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grbHeadDesign
            // 
            this.grbHeadDesign.BackColor = System.Drawing.Color.Ivory;
            this.grbHeadDesign.Controls.Add(this.txtSealType);
            this.grbHeadDesign.Controls.Add(this.txtCylinderHeadCode);
            this.grbHeadDesign.Controls.Add(this.lblCylinderHeadCode);
            this.grbHeadDesign.Controls.Add(this.cmbRodWearRingQty);
            this.grbHeadDesign.Controls.Add(this.lblRodWearRingQty);
            this.grbHeadDesign.Controls.Add(this.cmbRodWiperType);
            this.grbHeadDesign.Controls.Add(this.cmbRodWearRing);
            this.grbHeadDesign.Controls.Add(this.lblRodWiperType);
            this.grbHeadDesign.Controls.Add(this.lblRodWearRing);
            this.grbHeadDesign.Controls.Add(this.cmbRodSeal);
            this.grbHeadDesign.Controls.Add(this.cmbHeadType);
            this.grbHeadDesign.Controls.Add(this.lblRodSeal);
            this.grbHeadDesign.Controls.Add(this.lblHeadDesignIndex);
            this.grbHeadDesign.Controls.Add(this.lblHeadType);
            this.grbHeadDesign.Location = new System.Drawing.Point(47, 52);
            this.grbHeadDesign.Name = "grbHeadDesign";
            this.grbHeadDesign.Size = new System.Drawing.Size(713, 114);
            this.grbHeadDesign.TabIndex = 156;
            this.grbHeadDesign.TabStop = false;
            // 
            // lblRodWiperType
            // 
            this.lblRodWiperType.AutoSize = true;
            this.lblRodWiperType.Location = new System.Drawing.Point(512, 39);
            this.lblRodWiperType.Name = "lblRodWiperType";
            this.lblRodWiperType.Size = new System.Drawing.Size(85, 13);
            this.lblRodWiperType.TabIndex = 127;
            this.lblRodWiperType.Text = "Rod Wiper Type";
            // 
            // lblRodWearRing
            // 
            this.lblRodWearRing.AutoSize = true;
            this.lblRodWearRing.Location = new System.Drawing.Point(7, 77);
            this.lblRodWearRing.Name = "lblRodWearRing";
            this.lblRodWearRing.Size = new System.Drawing.Size(81, 13);
            this.lblRodWearRing.TabIndex = 125;
            this.lblRodWearRing.Text = "Rod Wear Ring";
            // 
            // cmbRodSeal
            // 
            this.cmbRodSeal.AcceptEnterKeyAsTab = true;
            this.cmbRodSeal.AssociateLabel = null;
            this.cmbRodSeal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRodSeal.FormattingEnabled = true;
            this.cmbRodSeal.IFLDataTag = null;
            this.cmbRodSeal.Location = new System.Drawing.Point(340, 36);
            this.cmbRodSeal.Name = "cmbRodSeal";
            this.cmbRodSeal.Size = new System.Drawing.Size(98, 21);
            this.cmbRodSeal.StatusMessage = null;
            this.cmbRodSeal.StatusObject = null;
            this.cmbRodSeal.TabIndex = 2;
            // 
            // cmbHeadType
            // 
            this.cmbHeadType.AcceptEnterKeyAsTab = true;
            this.cmbHeadType.AssociateLabel = null;
            this.cmbHeadType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHeadType.DropDownWidth = 120;
            this.cmbHeadType.FormattingEnabled = true;
            this.cmbHeadType.IFLDataTag = null;
            this.cmbHeadType.Location = new System.Drawing.Point(94, 36);
            this.cmbHeadType.Name = "cmbHeadType";
            this.cmbHeadType.Size = new System.Drawing.Size(98, 21);
            this.cmbHeadType.StatusMessage = null;
            this.cmbHeadType.StatusObject = null;
            this.cmbHeadType.TabIndex = 1;
            // 
            // lblRodSeal
            // 
            this.lblRodSeal.AutoSize = true;
            this.lblRodSeal.Location = new System.Drawing.Point(279, 39);
            this.lblRodSeal.Name = "lblRodSeal";
            this.lblRodSeal.Size = new System.Drawing.Size(51, 13);
            this.lblRodSeal.TabIndex = 120;
            this.lblRodSeal.Text = "Rod Seal";
            // 
            // lblHeadDesignIndex
            // 
            this.lblHeadDesignIndex.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.lblHeadDesignIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadDesignIndex.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHeadDesignIndex.GradientColorOne = System.Drawing.Color.Olive;
            this.lblHeadDesignIndex.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.lblHeadDesignIndex.Location = new System.Drawing.Point(-2, 0);
            this.lblHeadDesignIndex.Name = "lblHeadDesignIndex";
            this.lblHeadDesignIndex.Size = new System.Drawing.Size(715, 19);
            this.lblHeadDesignIndex.TabIndex = 21;
            this.lblHeadDesignIndex.Text = "Head Design";
            this.lblHeadDesignIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeadType
            // 
            this.lblHeadType.AutoSize = true;
            this.lblHeadType.Location = new System.Drawing.Point(28, 39);
            this.lblHeadType.Name = "lblHeadType";
            this.lblHeadType.Size = new System.Drawing.Size(60, 13);
            this.lblHeadType.TabIndex = 114;
            this.lblHeadType.Text = "Head Type";
            // 
            // LabelGradient4
            // 
            this.LabelGradient4.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.LabelGradient4.Dock = System.Windows.Forms.DockStyle.Right;
            this.LabelGradient4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGradient4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LabelGradient4.GradientColorOne = System.Drawing.Color.Olive;
            this.LabelGradient4.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.LabelGradient4.Location = new System.Drawing.Point(1008, 0);
            this.LabelGradient4.Name = "LabelGradient4";
            this.LabelGradient4.Size = new System.Drawing.Size(22, 737);
            this.LabelGradient4.TabIndex = 159;
            this.LabelGradient4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.LabelGradient3.Size = new System.Drawing.Size(20, 737);
            this.LabelGradient3.TabIndex = 158;
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
            this.LabelGradient2.Location = new System.Drawing.Point(0, 737);
            this.LabelGradient2.Name = "LabelGradient2";
            this.LabelGradient2.Size = new System.Drawing.Size(1030, 19);
            this.LabelGradient2.TabIndex = 157;
            this.LabelGradient2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // temCylinderHeadCode
            // 
            this.temCylinderHeadCode.AcceptEnterKeyAsTab = true;
            this.temCylinderHeadCode.ApplyIFLColor = true;
            this.temCylinderHeadCode.AssociateLabel = null;
            this.temCylinderHeadCode.DecimalValue = 2;
            this.temCylinderHeadCode.IFLDataTag = null;
            this.temCylinderHeadCode.InvalidInputCharacters = "";
            this.temCylinderHeadCode.IsAllowNegative = false;
            this.temCylinderHeadCode.LengthValue = 5;
            this.temCylinderHeadCode.Location = new System.Drawing.Point(617, 191);
            this.temCylinderHeadCode.MaximumValue = 1E+18D;
            this.temCylinderHeadCode.MaxLength = 100;
            this.temCylinderHeadCode.MinimumValue = 0D;
            this.temCylinderHeadCode.Name = "temCylinderHeadCode";
            this.temCylinderHeadCode.Size = new System.Drawing.Size(98, 20);
            this.temCylinderHeadCode.StatusMessage = "";
            this.temCylinderHeadCode.StatusObject = null;
            this.temCylinderHeadCode.TabIndex = 162;
            this.temCylinderHeadCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmHeadDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1030, 756);
            this.Controls.Add(this.grbInsertCylinderHeadDetailsIntoDB);
            this.Controls.Add(this.LabelGradient5);
            this.Controls.Add(this.lblInsertIntoDb);
            this.Controls.Add(this.grbHeadDesign);
            this.Controls.Add(this.LabelGradient4);
            this.Controls.Add(this.LabelGradient3);
            this.Controls.Add(this.LabelGradient2);
            this.Controls.Add(this.temCylinderHeadCode);
            this.Controls.Add(this.lblHeadDesign);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHeadDesign";
            this.Text = "frmHeadDesign";
            this.grbInsertCylinderHeadDetailsIntoDB.ResumeLayout(false);
            this.grbInsertCylinderHeadDetailsIntoDB.PerformLayout();
            this.grbHeadDesign.ResumeLayout(false);
            this.grbHeadDesign.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal IFLCustomUILayer.IFLNumericBox txtCylinderHeadCode;
        internal System.Windows.Forms.GroupBox grbInsertCylinderHeadDetailsIntoDB;
        internal System.Windows.Forms.Button btnHeadDesignContinue;
        internal System.Windows.Forms.Label lblMessage;
        internal LabelGradient.LabelGradient lblInsertCylinderHeadDetails;
        internal LabelGradient.LabelGradient LabelGradient5;
        internal System.Windows.Forms.TextBox txtSealType;
        internal System.Windows.Forms.Label lblCylinderHeadCode;
        internal IFLCustomUILayer.IFLComboBox cmbRodWearRingQty;
        internal LabelGradient.LabelGradient lblInsertIntoDb;
        internal System.Windows.Forms.Label lblRodWearRingQty;
        internal IFLCustomUILayer.IFLComboBox cmbRodWiperType;
        internal IFLCustomUILayer.IFLComboBox cmbRodWearRing;
        internal LabelGradient.LabelGradient lblHeadDesign;
        internal System.Windows.Forms.GroupBox grbHeadDesign;
        internal System.Windows.Forms.Label lblRodWiperType;
        internal System.Windows.Forms.Label lblRodWearRing;
        internal IFLCustomUILayer.IFLComboBox cmbRodSeal;
        internal IFLCustomUILayer.IFLComboBox cmbHeadType;
        internal System.Windows.Forms.Label lblRodSeal;
        internal LabelGradient.LabelGradient lblHeadDesignIndex;
        internal System.Windows.Forms.Label lblHeadType;
        internal LabelGradient.LabelGradient LabelGradient4;
        internal LabelGradient.LabelGradient LabelGradient3;
        internal LabelGradient.LabelGradient LabelGradient2;
        internal IFLCustomUILayer.IFLNumericBox temCylinderHeadCode;
    }
}