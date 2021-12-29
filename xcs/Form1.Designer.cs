
namespace xcs
{
    partial class Form1
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.numericNumberOfThreads = new System.Windows.Forms.NumericUpDown();
            this.labelNumberOfThreads = new System.Windows.Forms.Label();
            this.labelDimensionsOfTheFirstMatix = new System.Windows.Forms.Label();
            this.labelDimensionsOfTheSecondMatrix = new System.Windows.Forms.Label();
            this.labelHeightOfTheFirstMatrix = new System.Windows.Forms.Label();
            this.labelWidthOfTheFirstMatrix = new System.Windows.Forms.Label();
            this.labelHeightOfTheSecondMatrix = new System.Windows.Forms.Label();
            this.labelWidthOfTheSecondMatrix = new System.Windows.Forms.Label();
            this.numericHeightOfTheFirstMatix = new System.Windows.Forms.NumericUpDown();
            this.numericWidthOfTheFirstMatix = new System.Windows.Forms.NumericUpDown();
            this.numericHeightOfTheSecondMatix = new System.Windows.Forms.NumericUpDown();
            this.numericWidthOfTheSecondMatix = new System.Windows.Forms.NumericUpDown();
            this.radioButtonAsm = new System.Windows.Forms.RadioButton();
            this.radioButtonCpp = new System.Windows.Forms.RadioButton();
            this.labelSelectedLibrary = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumberOfThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeightOfTheFirstMatix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidthOfTheFirstMatix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeightOfTheSecondMatix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidthOfTheSecondMatix)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonStart.Location = new System.Drawing.Point(642, 510);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(118, 27);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start algorithm";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // numericNumberOfThreads
            // 
            this.numericNumberOfThreads.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericNumberOfThreads.Location = new System.Drawing.Point(213, 153);
            this.numericNumberOfThreads.Margin = new System.Windows.Forms.Padding(4);
            this.numericNumberOfThreads.Maximum = new decimal(new int[] {
            65,
            0,
            0,
            0});
            this.numericNumberOfThreads.Name = "numericNumberOfThreads";
            this.numericNumberOfThreads.Size = new System.Drawing.Size(49, 26);
            this.numericNumberOfThreads.TabIndex = 1;
            this.numericNumberOfThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericNumberOfThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericNumberOfThreads.ValueChanged += new System.EventHandler(this.numericNumberOfThreads_ValueChanged);
            // 
            // labelNumberOfThreads
            // 
            this.labelNumberOfThreads.AutoSize = true;
            this.labelNumberOfThreads.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNumberOfThreads.Location = new System.Drawing.Point(23, 155);
            this.labelNumberOfThreads.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNumberOfThreads.Name = "labelNumberOfThreads";
            this.labelNumberOfThreads.Size = new System.Drawing.Size(182, 19);
            this.labelNumberOfThreads.TabIndex = 2;
            this.labelNumberOfThreads.Text = "Set number of threads ";
            // 
            // labelDimensionsOfTheFirstMatix
            // 
            this.labelDimensionsOfTheFirstMatix.AutoSize = true;
            this.labelDimensionsOfTheFirstMatix.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDimensionsOfTheFirstMatix.Location = new System.Drawing.Point(23, 222);
            this.labelDimensionsOfTheFirstMatix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDimensionsOfTheFirstMatix.Name = "labelDimensionsOfTheFirstMatix";
            this.labelDimensionsOfTheFirstMatix.Size = new System.Drawing.Size(274, 19);
            this.labelDimensionsOfTheFirstMatix.TabIndex = 3;
            this.labelDimensionsOfTheFirstMatix.Text = "Enter dimensions of the first matrix\r\n";
            // 
            // labelDimensionsOfTheSecondMatrix
            // 
            this.labelDimensionsOfTheSecondMatrix.AutoSize = true;
            this.labelDimensionsOfTheSecondMatrix.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDimensionsOfTheSecondMatrix.Location = new System.Drawing.Point(345, 222);
            this.labelDimensionsOfTheSecondMatrix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDimensionsOfTheSecondMatrix.Name = "labelDimensionsOfTheSecondMatrix";
            this.labelDimensionsOfTheSecondMatrix.Size = new System.Drawing.Size(302, 19);
            this.labelDimensionsOfTheSecondMatrix.TabIndex = 4;
            this.labelDimensionsOfTheSecondMatrix.Text = "Enter dimensions of the second matrix\r\n";
            // 
            // labelHeightOfTheFirstMatrix
            // 
            this.labelHeightOfTheFirstMatrix.AutoSize = true;
            this.labelHeightOfTheFirstMatrix.Location = new System.Drawing.Point(24, 260);
            this.labelHeightOfTheFirstMatrix.Name = "labelHeightOfTheFirstMatrix";
            this.labelHeightOfTheFirstMatrix.Size = new System.Drawing.Size(41, 18);
            this.labelHeightOfTheFirstMatrix.TabIndex = 5;
            this.labelHeightOfTheFirstMatrix.Text = "rows";
            // 
            // labelWidthOfTheFirstMatrix
            // 
            this.labelWidthOfTheFirstMatrix.AutoSize = true;
            this.labelWidthOfTheFirstMatrix.Location = new System.Drawing.Point(24, 292);
            this.labelWidthOfTheFirstMatrix.Name = "labelWidthOfTheFirstMatrix";
            this.labelWidthOfTheFirstMatrix.Size = new System.Drawing.Size(65, 18);
            this.labelWidthOfTheFirstMatrix.TabIndex = 6;
            this.labelWidthOfTheFirstMatrix.Text = "columns";
            // 
            // labelHeightOfTheSecondMatrix
            // 
            this.labelHeightOfTheSecondMatrix.AutoSize = true;
            this.labelHeightOfTheSecondMatrix.Location = new System.Drawing.Point(346, 260);
            this.labelHeightOfTheSecondMatrix.Name = "labelHeightOfTheSecondMatrix";
            this.labelHeightOfTheSecondMatrix.Size = new System.Drawing.Size(41, 18);
            this.labelHeightOfTheSecondMatrix.TabIndex = 7;
            this.labelHeightOfTheSecondMatrix.Text = "rows";
            // 
            // labelWidthOfTheSecondMatrix
            // 
            this.labelWidthOfTheSecondMatrix.AutoSize = true;
            this.labelWidthOfTheSecondMatrix.Location = new System.Drawing.Point(346, 292);
            this.labelWidthOfTheSecondMatrix.Name = "labelWidthOfTheSecondMatrix";
            this.labelWidthOfTheSecondMatrix.Size = new System.Drawing.Size(65, 18);
            this.labelWidthOfTheSecondMatrix.TabIndex = 8;
            this.labelWidthOfTheSecondMatrix.Text = "columns";
            // 
            // numericHeightOfTheFirstMatix
            // 
            this.numericHeightOfTheFirstMatix.Location = new System.Drawing.Point(95, 258);
            this.numericHeightOfTheFirstMatix.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericHeightOfTheFirstMatix.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericHeightOfTheFirstMatix.Name = "numericHeightOfTheFirstMatix";
            this.numericHeightOfTheFirstMatix.Size = new System.Drawing.Size(57, 26);
            this.numericHeightOfTheFirstMatix.TabIndex = 9;
            this.numericHeightOfTheFirstMatix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericHeightOfTheFirstMatix.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericWidthOfTheFirstMatix
            // 
            this.numericWidthOfTheFirstMatix.Location = new System.Drawing.Point(95, 290);
            this.numericWidthOfTheFirstMatix.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericWidthOfTheFirstMatix.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericWidthOfTheFirstMatix.Name = "numericWidthOfTheFirstMatix";
            this.numericWidthOfTheFirstMatix.Size = new System.Drawing.Size(57, 26);
            this.numericWidthOfTheFirstMatix.TabIndex = 10;
            this.numericWidthOfTheFirstMatix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericWidthOfTheFirstMatix.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericWidthOfTheFirstMatix.ValueChanged += new System.EventHandler(this.numericWidthOfTheFirstMatix_ValueChanged);
            // 
            // numericHeightOfTheSecondMatix
            // 
            this.numericHeightOfTheSecondMatix.Location = new System.Drawing.Point(417, 258);
            this.numericHeightOfTheSecondMatix.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericHeightOfTheSecondMatix.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericHeightOfTheSecondMatix.Name = "numericHeightOfTheSecondMatix";
            this.numericHeightOfTheSecondMatix.Size = new System.Drawing.Size(57, 26);
            this.numericHeightOfTheSecondMatix.TabIndex = 11;
            this.numericHeightOfTheSecondMatix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericHeightOfTheSecondMatix.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericHeightOfTheSecondMatix.ValueChanged += new System.EventHandler(this.numericHeightOfTheSecondMatix_ValueChanged);
            // 
            // numericWidthOfTheSecondMatix
            // 
            this.numericWidthOfTheSecondMatix.Location = new System.Drawing.Point(417, 290);
            this.numericWidthOfTheSecondMatix.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericWidthOfTheSecondMatix.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericWidthOfTheSecondMatix.Name = "numericWidthOfTheSecondMatix";
            this.numericWidthOfTheSecondMatix.Size = new System.Drawing.Size(57, 26);
            this.numericWidthOfTheSecondMatix.TabIndex = 12;
            this.numericWidthOfTheSecondMatix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericWidthOfTheSecondMatix.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // radioButtonAsm
            // 
            this.radioButtonAsm.AutoSize = true;
            this.radioButtonAsm.Location = new System.Drawing.Point(27, 81);
            this.radioButtonAsm.Name = "radioButtonAsm";
            this.radioButtonAsm.Size = new System.Drawing.Size(190, 22);
            this.radioButtonAsm.TabIndex = 13;
            this.radioButtonAsm.Text = "DLL written in MASM64";
            this.radioButtonAsm.UseVisualStyleBackColor = true;
            this.radioButtonAsm.CheckedChanged += new System.EventHandler(this.radioButtonAsm_CheckedChanged);
            // 
            // radioButtonCpp
            // 
            this.radioButtonCpp.AutoSize = true;
            this.radioButtonCpp.Checked = true;
            this.radioButtonCpp.Location = new System.Drawing.Point(27, 53);
            this.radioButtonCpp.Name = "radioButtonCpp";
            this.radioButtonCpp.Size = new System.Drawing.Size(154, 22);
            this.radioButtonCpp.TabIndex = 14;
            this.radioButtonCpp.TabStop = true;
            this.radioButtonCpp.Text = "DLL written in C++";
            this.radioButtonCpp.UseVisualStyleBackColor = true;
            this.radioButtonCpp.CheckedChanged += new System.EventHandler(this.radioButtonCpp_CheckedChanged);
            // 
            // labelSelectedLibrary
            // 
            this.labelSelectedLibrary.AutoSize = true;
            this.labelSelectedLibrary.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSelectedLibrary.Location = new System.Drawing.Point(23, 20);
            this.labelSelectedLibrary.Name = "labelSelectedLibrary";
            this.labelSelectedLibrary.Size = new System.Drawing.Size(92, 19);
            this.labelSelectedLibrary.TabIndex = 15;
            this.labelSelectedLibrary.Text = "Select DLL";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.labelSelectedLibrary);
            this.Controls.Add(this.radioButtonCpp);
            this.Controls.Add(this.radioButtonAsm);
            this.Controls.Add(this.numericWidthOfTheSecondMatix);
            this.Controls.Add(this.numericHeightOfTheSecondMatix);
            this.Controls.Add(this.numericWidthOfTheFirstMatix);
            this.Controls.Add(this.numericHeightOfTheFirstMatix);
            this.Controls.Add(this.labelWidthOfTheSecondMatrix);
            this.Controls.Add(this.labelHeightOfTheSecondMatrix);
            this.Controls.Add(this.labelWidthOfTheFirstMatrix);
            this.Controls.Add(this.labelHeightOfTheFirstMatrix);
            this.Controls.Add(this.labelDimensionsOfTheSecondMatrix);
            this.Controls.Add(this.labelDimensionsOfTheFirstMatix);
            this.Controls.Add(this.labelNumberOfThreads);
            this.Controls.Add(this.numericNumberOfThreads);
            this.Controls.Add(this.buttonStart);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matrix multiplication";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericNumberOfThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeightOfTheFirstMatix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidthOfTheFirstMatix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeightOfTheSecondMatix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidthOfTheSecondMatix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.NumericUpDown numericNumberOfThreads;
        private System.Windows.Forms.Label labelNumberOfThreads;
        private System.Windows.Forms.Label labelDimensionsOfTheFirstMatix;
        private System.Windows.Forms.Label labelDimensionsOfTheSecondMatrix;
        private System.Windows.Forms.Label labelHeightOfTheFirstMatrix;
        private System.Windows.Forms.Label labelWidthOfTheFirstMatrix;
        private System.Windows.Forms.Label labelHeightOfTheSecondMatrix;
        private System.Windows.Forms.Label labelWidthOfTheSecondMatrix;
        private System.Windows.Forms.NumericUpDown numericHeightOfTheFirstMatix;
        private System.Windows.Forms.NumericUpDown numericWidthOfTheFirstMatix;
        private System.Windows.Forms.NumericUpDown numericHeightOfTheSecondMatix;
        private System.Windows.Forms.NumericUpDown numericWidthOfTheSecondMatix;
        private System.Windows.Forms.RadioButton radioButtonAsm;
        private System.Windows.Forms.RadioButton radioButtonCpp;
        private System.Windows.Forms.Label labelSelectedLibrary;
    }
}

