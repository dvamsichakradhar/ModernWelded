namespace Welded.UILayer.Common
{
    partial class frmPistonDesign
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
            this.LabelGradient5 = new LabelGradient.LabelGradient();
            this.txtPistonCode = new IFLCustomUILayer.IFLNumericBox();
            this.lblPistonCode = new System.Windows.Forms.Label();
            this.cmbWearRingQuantity = new IFLCustomUILayer.IFLComboBox();
            this.grbPistonDesign = new System.Windows.Forms.GroupBox();
            this.lblWearRingQty = new System.Windows.Forms.Label();
            this.cmbPistonWearRing = new IFLCustomUILayer.IFLComboBox();
            this.lblPistonWearRing = new System.Windows.Forms.Label();
            this.cmbPistonSeal = new IFLCustomUILayer.IFLComboBox();
            this.lblPistonSeal = new System.Windows.Forms.Label();
            this.lblPistonDesignIndex = new LabelGradient.LabelGradient();
            this.lblPistonDesign = new LabelGradient.LabelGradient();
            this.LabelGradient4 = new LabelGradient.LabelGradient();
            this.LabelGradient3 = new LabelGradient.LabelGradient();
            this.LabelGradient2 = new LabelGradient.LabelGradient();
            this.grbPistonDesign.SuspendLayout();
            this.SuspendLayout();
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
            this.LabelGradient5.Size = new System.Drawing.Size(994, 19);
            this.LabelGradient5.TabIndex = 44;
            this.LabelGradient5.Text = "Piston Design";
            this.LabelGradient5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPistonCode
            // 
            this.txtPistonCode.AcceptEnterKeyAsTab = true;
            this.txtPistonCode.ApplyIFLColor = true;
            this.txtPistonCode.AssociateLabel = null;
            this.txtPistonCode.DecimalValue = 2;
            this.txtPistonCode.IFLDataTag = null;
            this.txtPistonCode.InvalidInputCharacters = "";
            this.txtPistonCode.IsAllowNegative = false;
            this.txtPistonCode.LengthValue = 5;
            this.txtPistonCode.Location = new System.Drawing.Point(94, 80);
            this.txtPistonCode.MaximumValue = 1000000D;
            this.txtPistonCode.MaxLength = 10;
            this.txtPistonCode.MinimumValue = 6D;
            this.txtPistonCode.Name = "txtPistonCode";
            this.txtPistonCode.Size = new System.Drawing.Size(98, 20);
            this.txtPistonCode.StatusMessage = "";
            this.txtPistonCode.StatusObject = null;
            this.txtPistonCode.TabIndex = 4;
            this.txtPistonCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPistonCode
            // 
            this.lblPistonCode.AutoSize = true;
            this.lblPistonCode.Location = new System.Drawing.Point(24, 83);
            this.lblPistonCode.Name = "lblPistonCode";
            this.lblPistonCode.Size = new System.Drawing.Size(64, 13);
            this.lblPistonCode.TabIndex = 152;
            this.lblPistonCode.Text = "Piston Code";
            // 
            // cmbWearRingQuantity
            // 
            this.cmbWearRingQuantity.AcceptEnterKeyAsTab = true;
            this.cmbWearRingQuantity.AssociateLabel = null;
            this.cmbWearRingQuantity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWearRingQuantity.FormattingEnabled = true;
            this.cmbWearRingQuantity.IFLDataTag = null;
            this.cmbWearRingQuantity.Location = new System.Drawing.Point(572, 36);
            this.cmbWearRingQuantity.Name = "cmbWearRingQuantity";
            this.cmbWearRingQuantity.Size = new System.Drawing.Size(98, 21);
            this.cmbWearRingQuantity.StatusMessage = null;
            this.cmbWearRingQuantity.StatusObject = null;
            this.cmbWearRingQuantity.TabIndex = 3;
            // 
            // grbPistonDesign
            // 
            this.grbPistonDesign.BackColor = System.Drawing.Color.Ivory;
            this.grbPistonDesign.Controls.Add(this.txtPistonCode);
            this.grbPistonDesign.Controls.Add(this.lblPistonCode);
            this.grbPistonDesign.Controls.Add(this.cmbWearRingQuantity);
            this.grbPistonDesign.Controls.Add(this.lblWearRingQty);
            this.grbPistonDesign.Controls.Add(this.cmbPistonWearRing);
            this.grbPistonDesign.Controls.Add(this.lblPistonWearRing);
            this.grbPistonDesign.Controls.Add(this.cmbPistonSeal);
            this.grbPistonDesign.Controls.Add(this.lblPistonSeal);
            this.grbPistonDesign.Controls.Add(this.lblPistonDesignIndex);
            this.grbPistonDesign.Location = new System.Drawing.Point(47, 48);
            this.grbPistonDesign.Name = "grbPistonDesign";
            this.grbPistonDesign.Size = new System.Drawing.Size(701, 120);
            this.grbPistonDesign.TabIndex = 40;
            this.grbPistonDesign.TabStop = false;
            // 
            // lblWearRingQty
            // 
            this.lblWearRingQty.AutoSize = true;
            this.lblWearRingQty.Location = new System.Drawing.Point(466, 39);
            this.lblWearRingQty.Name = "lblWearRingQty";
            this.lblWearRingQty.Size = new System.Drawing.Size(100, 13);
            this.lblWearRingQty.TabIndex = 116;
            this.lblWearRingQty.Text = "Wear Ring Quantity";
            // 
            // cmbPistonWearRing
            // 
            this.cmbPistonWearRing.AcceptEnterKeyAsTab = true;
            this.cmbPistonWearRing.AssociateLabel = null;
            this.cmbPistonWearRing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPistonWearRing.FormattingEnabled = true;
            this.cmbPistonWearRing.IFLDataTag = null;
            this.cmbPistonWearRing.Location = new System.Drawing.Point(330, 36);
            this.cmbPistonWearRing.Name = "cmbPistonWearRing";
            this.cmbPistonWearRing.Size = new System.Drawing.Size(98, 21);
            this.cmbPistonWearRing.StatusMessage = null;
            this.cmbPistonWearRing.StatusObject = null;
            this.cmbPistonWearRing.TabIndex = 2;
            // 
            // lblPistonWearRing
            // 
            this.lblPistonWearRing.AutoSize = true;
            this.lblPistonWearRing.Location = new System.Drawing.Point(234, 39);
            this.lblPistonWearRing.Name = "lblPistonWearRing";
            this.lblPistonWearRing.Size = new System.Drawing.Size(90, 13);
            this.lblPistonWearRing.TabIndex = 120;
            this.lblPistonWearRing.Text = "Piston Wear Ring";
            // 
            // cmbPistonSeal
            // 
            this.cmbPistonSeal.AcceptEnterKeyAsTab = true;
            this.cmbPistonSeal.AssociateLabel = null;
            this.cmbPistonSeal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPistonSeal.FormattingEnabled = true;
            this.cmbPistonSeal.IFLDataTag = null;
            this.cmbPistonSeal.Location = new System.Drawing.Point(94, 36);
            this.cmbPistonSeal.Name = "cmbPistonSeal";
            this.cmbPistonSeal.Size = new System.Drawing.Size(98, 21);
            this.cmbPistonSeal.StatusMessage = null;
            this.cmbPistonSeal.StatusObject = null;
            this.cmbPistonSeal.TabIndex = 1;
            // 
            // lblPistonSeal
            // 
            this.lblPistonSeal.AutoSize = true;
            this.lblPistonSeal.Location = new System.Drawing.Point(24, 39);
            this.lblPistonSeal.Name = "lblPistonSeal";
            this.lblPistonSeal.Size = new System.Drawing.Size(60, 13);
            this.lblPistonSeal.TabIndex = 114;
            this.lblPistonSeal.Text = "Piston Seal";
            // 
            // lblPistonDesignIndex
            // 
            this.lblPistonDesignIndex.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.lblPistonDesignIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPistonDesignIndex.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPistonDesignIndex.GradientColorOne = System.Drawing.Color.Olive;
            this.lblPistonDesignIndex.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.lblPistonDesignIndex.Location = new System.Drawing.Point(-2, 0);
            this.lblPistonDesignIndex.Name = "lblPistonDesignIndex";
            this.lblPistonDesignIndex.Size = new System.Drawing.Size(703, 19);
            this.lblPistonDesignIndex.TabIndex = 21;
            this.lblPistonDesignIndex.Text = "Piston Design";
            this.lblPistonDesignIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPistonDesign
            // 
            this.lblPistonDesign.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.lblPistonDesign.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPistonDesign.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPistonDesign.GradientColorOne = System.Drawing.Color.DarkGoldenrod;
            this.lblPistonDesign.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.lblPistonDesign.Location = new System.Drawing.Point(26, 28);
            this.lblPistonDesign.Name = "lblPistonDesign";
            this.lblPistonDesign.Size = new System.Drawing.Size(745, 158);
            this.lblPistonDesign.TabIndex = 45;
            this.lblPistonDesign.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LabelGradient4
            // 
            this.LabelGradient4.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.LabelGradient4.Dock = System.Windows.Forms.DockStyle.Right;
            this.LabelGradient4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGradient4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LabelGradient4.GradientColorOne = System.Drawing.Color.Olive;
            this.LabelGradient4.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.LabelGradient4.Location = new System.Drawing.Point(1014, 0);
            this.LabelGradient4.Name = "LabelGradient4";
            this.LabelGradient4.Size = new System.Drawing.Size(22, 761);
            this.LabelGradient4.TabIndex = 43;
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
            this.LabelGradient3.Size = new System.Drawing.Size(20, 761);
            this.LabelGradient3.TabIndex = 42;
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
            this.LabelGradient2.Location = new System.Drawing.Point(0, 761);
            this.LabelGradient2.Name = "LabelGradient2";
            this.LabelGradient2.Size = new System.Drawing.Size(1036, 19);
            this.LabelGradient2.TabIndex = 41;
            this.LabelGradient2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmPistonDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1036, 780);
            this.Controls.Add(this.LabelGradient5);
            this.Controls.Add(this.grbPistonDesign);
            this.Controls.Add(this.lblPistonDesign);
            this.Controls.Add(this.LabelGradient4);
            this.Controls.Add(this.LabelGradient3);
            this.Controls.Add(this.LabelGradient2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPistonDesign";
            this.Text = "frmPistonDesign";
            this.grbPistonDesign.ResumeLayout(false);
            this.grbPistonDesign.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal LabelGradient.LabelGradient LabelGradient5;
        internal IFLCustomUILayer.IFLNumericBox txtPistonCode;
        internal System.Windows.Forms.Label lblPistonCode;
        internal IFLCustomUILayer.IFLComboBox cmbWearRingQuantity;
        internal System.Windows.Forms.GroupBox grbPistonDesign;
        internal System.Windows.Forms.Label lblWearRingQty;
        internal IFLCustomUILayer.IFLComboBox cmbPistonWearRing;
        internal System.Windows.Forms.Label lblPistonWearRing;
        internal IFLCustomUILayer.IFLComboBox cmbPistonSeal;
        internal System.Windows.Forms.Label lblPistonSeal;
        internal LabelGradient.LabelGradient lblPistonDesignIndex;
        internal LabelGradient.LabelGradient lblPistonDesign;
        internal LabelGradient.LabelGradient LabelGradient4;
        internal LabelGradient.LabelGradient LabelGradient3;
        internal LabelGradient.LabelGradient LabelGradient2;
    }
}