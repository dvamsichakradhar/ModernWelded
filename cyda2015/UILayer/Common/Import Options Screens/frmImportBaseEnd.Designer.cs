namespace Welded.UILayer.Common.Import_Options_Screens
{
    partial class frmImportBaseEnd
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblGradientContractDetails = new LabelGradient.LabelGradient();
            this.LabelGradient5 = new LabelGradient.LabelGradient();
            this.txtTubeEndToRodStopDistance = new IFLCustomUILayer.IFLTextBox();
            this.grpContractDetails = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPinHoleToRodStopDistance = new IFLCustomUILayer.IFLTextBox();
            this.lblPinHoleToRodStopDistance = new System.Windows.Forms.Label();
            this.lblTubeEndToRodStopDistance = new System.Windows.Forms.Label();
            this.lblBaseEndDetails = new LabelGradient.LabelGradient();
            this.LabelGradient4 = new LabelGradient.LabelGradient();
            this.LabelGradient2 = new LabelGradient.LabelGradient();
            this.LabelGradient3 = new LabelGradient.LabelGradient();
            this.ofdImportBaseEnd = new System.Windows.Forms.OpenFileDialog();
            this.grpContractDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAccept.Location = new System.Drawing.Point(359, 124);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(90, 25);
            this.btnAccept.TabIndex = 24;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            // 
            // lblGradientContractDetails
            // 
            this.lblGradientContractDetails.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.lblGradientContractDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGradientContractDetails.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGradientContractDetails.GradientColorOne = System.Drawing.Color.DarkGoldenrod;
            this.lblGradientContractDetails.GradientColorTwo = System.Drawing.Color.DarkGoldenrod;
            this.lblGradientContractDetails.Location = new System.Drawing.Point(212, 176);
            this.lblGradientContractDetails.Name = "lblGradientContractDetails";
            this.lblGradientContractDetails.Size = new System.Drawing.Size(501, 201);
            this.lblGradientContractDetails.TabIndex = 134;
            this.lblGradientContractDetails.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.LabelGradient5.Size = new System.Drawing.Size(904, 11);
            this.LabelGradient5.TabIndex = 133;
            this.LabelGradient5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTubeEndToRodStopDistance
            // 
            this.txtTubeEndToRodStopDistance.AcceptEnterKeyAsTab = true;
            this.txtTubeEndToRodStopDistance.ApplyIFLColor = true;
            this.txtTubeEndToRodStopDistance.AssociateLabel = null;
            this.txtTubeEndToRodStopDistance.IFLDataTag = null;
            this.txtTubeEndToRodStopDistance.InvalidInputCharacters = "";
            this.txtTubeEndToRodStopDistance.Location = new System.Drawing.Point(263, 33);
            this.txtTubeEndToRodStopDistance.MaxLength = 32;
            this.txtTubeEndToRodStopDistance.Name = "txtTubeEndToRodStopDistance";
            this.txtTubeEndToRodStopDistance.Size = new System.Drawing.Size(186, 20);
            this.txtTubeEndToRodStopDistance.StatusMessage = "";
            this.txtTubeEndToRodStopDistance.StatusObject = null;
            this.txtTubeEndToRodStopDistance.TabIndex = 25;
            // 
            // grpContractDetails
            // 
            this.grpContractDetails.BackColor = System.Drawing.Color.Ivory;
            this.grpContractDetails.Controls.Add(this.txtTubeEndToRodStopDistance);
            this.grpContractDetails.Controls.Add(this.btnAccept);
            this.grpContractDetails.Controls.Add(this.btnBrowse);
            this.grpContractDetails.Controls.Add(this.txtPinHoleToRodStopDistance);
            this.grpContractDetails.Controls.Add(this.lblPinHoleToRodStopDistance);
            this.grpContractDetails.Controls.Add(this.lblTubeEndToRodStopDistance);
            this.grpContractDetails.Controls.Add(this.lblBaseEndDetails);
            this.grpContractDetails.Location = new System.Drawing.Point(228, 192);
            this.grpContractDetails.Name = "grpContractDetails";
            this.grpContractDetails.Size = new System.Drawing.Size(469, 168);
            this.grpContractDetails.TabIndex = 135;
            this.grpContractDetails.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBrowse.Location = new System.Drawing.Point(263, 124);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(90, 25);
            this.btnBrowse.TabIndex = 23;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // txtPinHoleToRodStopDistance
            // 
            this.txtPinHoleToRodStopDistance.AcceptEnterKeyAsTab = true;
            this.txtPinHoleToRodStopDistance.ApplyIFLColor = true;
            this.txtPinHoleToRodStopDistance.AssociateLabel = null;
            this.txtPinHoleToRodStopDistance.IFLDataTag = null;
            this.txtPinHoleToRodStopDistance.InvalidInputCharacters = "";
            this.txtPinHoleToRodStopDistance.Location = new System.Drawing.Point(263, 71);
            this.txtPinHoleToRodStopDistance.MaxLength = 32;
            this.txtPinHoleToRodStopDistance.Name = "txtPinHoleToRodStopDistance";
            this.txtPinHoleToRodStopDistance.Size = new System.Drawing.Size(186, 20);
            this.txtPinHoleToRodStopDistance.StatusMessage = "";
            this.txtPinHoleToRodStopDistance.StatusObject = null;
            this.txtPinHoleToRodStopDistance.TabIndex = 3;
            // 
            // lblPinHoleToRodStopDistance
            // 
            this.lblPinHoleToRodStopDistance.AutoSize = true;
            this.lblPinHoleToRodStopDistance.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F);
            this.lblPinHoleToRodStopDistance.Location = new System.Drawing.Point(56, 73);
            this.lblPinHoleToRodStopDistance.Name = "lblPinHoleToRodStopDistance";
            this.lblPinHoleToRodStopDistance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPinHoleToRodStopDistance.Size = new System.Drawing.Size(164, 15);
            this.lblPinHoleToRodStopDistance.TabIndex = 4;
            this.lblPinHoleToRodStopDistance.Text = "Pin Hole to Rod Stop Distance";
            // 
            // lblTubeEndToRodStopDistance
            // 
            this.lblTubeEndToRodStopDistance.AutoSize = true;
            this.lblTubeEndToRodStopDistance.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTubeEndToRodStopDistance.Location = new System.Drawing.Point(53, 35);
            this.lblTubeEndToRodStopDistance.Name = "lblTubeEndToRodStopDistance";
            this.lblTubeEndToRodStopDistance.Size = new System.Drawing.Size(171, 15);
            this.lblTubeEndToRodStopDistance.TabIndex = 0;
            this.lblTubeEndToRodStopDistance.Text = "Tube End to Rod Stop Distance";
            // 
            // lblBaseEndDetails
            // 
            this.lblBaseEndDetails.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBaseEndDetails.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.lblBaseEndDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaseEndDetails.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBaseEndDetails.GradientColorOne = System.Drawing.Color.Olive;
            this.lblBaseEndDetails.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.lblBaseEndDetails.Location = new System.Drawing.Point(-3, 0);
            this.lblBaseEndDetails.Name = "lblBaseEndDetails";
            this.lblBaseEndDetails.Size = new System.Drawing.Size(472, 21);
            this.lblBaseEndDetails.TabIndex = 20;
            this.lblBaseEndDetails.Text = "Base End Details";
            this.lblBaseEndDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelGradient4
            // 
            this.LabelGradient4.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.LabelGradient4.Dock = System.Windows.Forms.DockStyle.Right;
            this.LabelGradient4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGradient4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LabelGradient4.GradientColorOne = System.Drawing.Color.Honeydew;
            this.LabelGradient4.GradientColorTwo = System.Drawing.Color.Olive;
            this.LabelGradient4.Location = new System.Drawing.Point(914, 0);
            this.LabelGradient4.Name = "LabelGradient4";
            this.LabelGradient4.Size = new System.Drawing.Size(10, 541);
            this.LabelGradient4.TabIndex = 132;
            this.LabelGradient4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LabelGradient2
            // 
            this.LabelGradient2.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.LabelGradient2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LabelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGradient2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LabelGradient2.GradientColorOne = System.Drawing.Color.Olive;
            this.LabelGradient2.GradientColorTwo = System.Drawing.Color.Honeydew;
            this.LabelGradient2.Location = new System.Drawing.Point(10, 541);
            this.LabelGradient2.Name = "LabelGradient2";
            this.LabelGradient2.Size = new System.Drawing.Size(914, 11);
            this.LabelGradient2.TabIndex = 130;
            this.LabelGradient2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.LabelGradient3.Size = new System.Drawing.Size(10, 552);
            this.LabelGradient3.TabIndex = 131;
            this.LabelGradient3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ofdImportBaseEnd
            // 
            this.ofdImportBaseEnd.FileName = "OpenFileDialog1";
            // 
            // frmImportBaseEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(924, 552);
            this.ControlBox = false;
            this.Controls.Add(this.LabelGradient5);
            this.Controls.Add(this.grpContractDetails);
            this.Controls.Add(this.LabelGradient4);
            this.Controls.Add(this.LabelGradient2);
            this.Controls.Add(this.LabelGradient3);
            this.Controls.Add(this.lblGradientContractDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmImportBaseEnd";
            this.Text = "frmImportBaseEnd";
            this.grpContractDetails.ResumeLayout(false);
            this.grpContractDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnAccept;
        internal LabelGradient.LabelGradient lblGradientContractDetails;
        internal LabelGradient.LabelGradient LabelGradient5;
        internal IFLCustomUILayer.IFLTextBox txtTubeEndToRodStopDistance;
        internal System.Windows.Forms.GroupBox grpContractDetails;
        internal System.Windows.Forms.Button btnBrowse;
        internal IFLCustomUILayer.IFLTextBox txtPinHoleToRodStopDistance;
        internal System.Windows.Forms.Label lblPinHoleToRodStopDistance;
        internal System.Windows.Forms.Label lblTubeEndToRodStopDistance;
        internal LabelGradient.LabelGradient lblBaseEndDetails;
        internal LabelGradient.LabelGradient LabelGradient4;
        internal LabelGradient.LabelGradient LabelGradient2;
        internal LabelGradient.LabelGradient LabelGradient3;
        internal System.Windows.Forms.OpenFileDialog ofdImportBaseEnd;
    }
}