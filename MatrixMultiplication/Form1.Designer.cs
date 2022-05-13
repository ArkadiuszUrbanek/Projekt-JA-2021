
/*
 * Temat projektu zaliczeniowego z języków asemblerowych: Mnożenie macierzy
 * Autor: Arkadiusz Urbanek
 * Kierunek: Informatyka
 * Grupa: 2
 * Semestr: 5
 * Rok akademicki: 2021/2022
 * Aktualna wersja programu v.1.0
 *
 */

namespace MatrixMultiplication
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
            this.labelSelectedLibrary = new System.Windows.Forms.Label();
            this.radioButtonCpp = new System.Windows.Forms.RadioButton();
            this.radioButtonAsm = new System.Windows.Forms.RadioButton();
            this.numericWidthOfTheSecondMatix = new System.Windows.Forms.NumericUpDown();
            this.numericHeightOfTheSecondMatix = new System.Windows.Forms.NumericUpDown();
            this.numericWidthOfTheFirstMatix = new System.Windows.Forms.NumericUpDown();
            this.numericHeightOfTheFirstMatix = new System.Windows.Forms.NumericUpDown();
            this.labelWidthOfTheSecondMatrix = new System.Windows.Forms.Label();
            this.labelHeightOfTheSecondMatrix = new System.Windows.Forms.Label();
            this.labelWidthOfTheFirstMatrix = new System.Windows.Forms.Label();
            this.labelHeightOfTheFirstMatrix = new System.Windows.Forms.Label();
            this.labelDimensionsOfTheSecondMatrix = new System.Windows.Forms.Label();
            this.labelDimensionsOfTheFirstMatix = new System.Windows.Forms.Label();
            this.labelNumberOfThreads = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelProgress = new System.Windows.Forms.Label();
            this.checkedListBoxStagesOfAlgorithm = new System.Windows.Forms.CheckedListBox();
            this.trackBarNumberOfThreads = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidthOfTheSecondMatix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeightOfTheSecondMatix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidthOfTheFirstMatix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeightOfTheFirstMatix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNumberOfThreads)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSelectedLibrary
            // 
            this.labelSelectedLibrary.AutoSize = true;
            this.labelSelectedLibrary.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSelectedLibrary.Location = new System.Drawing.Point(24, 22);
            this.labelSelectedLibrary.Name = "labelSelectedLibrary";
            this.labelSelectedLibrary.Size = new System.Drawing.Size(92, 19);
            this.labelSelectedLibrary.TabIndex = 31;
            this.labelSelectedLibrary.Text = "Select DLL";
            // 
            // radioButtonCpp
            // 
            this.radioButtonCpp.AutoSize = true;
            this.radioButtonCpp.Checked = true;
            this.radioButtonCpp.Location = new System.Drawing.Point(28, 55);
            this.radioButtonCpp.Name = "radioButtonCpp";
            this.radioButtonCpp.Size = new System.Drawing.Size(154, 22);
            this.radioButtonCpp.TabIndex = 30;
            this.radioButtonCpp.TabStop = true;
            this.radioButtonCpp.Text = "DLL written in C++";
            this.radioButtonCpp.UseVisualStyleBackColor = true;
            this.radioButtonCpp.CheckedChanged += new System.EventHandler(this.radioButtonCpp_CheckedChanged);
            // 
            // radioButtonAsm
            // 
            this.radioButtonAsm.AutoSize = true;
            this.radioButtonAsm.Location = new System.Drawing.Point(28, 83);
            this.radioButtonAsm.Name = "radioButtonAsm";
            this.radioButtonAsm.Size = new System.Drawing.Size(190, 22);
            this.radioButtonAsm.TabIndex = 29;
            this.radioButtonAsm.Text = "DLL written in MASM64";
            this.radioButtonAsm.UseVisualStyleBackColor = true;
            this.radioButtonAsm.CheckedChanged += new System.EventHandler(this.radioButtonAsm_CheckedChanged);
            // 
            // numericWidthOfTheSecondMatix
            // 
            this.numericWidthOfTheSecondMatix.Location = new System.Drawing.Point(418, 292);
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
            this.numericWidthOfTheSecondMatix.TabIndex = 28;
            this.numericWidthOfTheSecondMatix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericWidthOfTheSecondMatix.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericHeightOfTheSecondMatix
            // 
            this.numericHeightOfTheSecondMatix.Location = new System.Drawing.Point(418, 260);
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
            this.numericHeightOfTheSecondMatix.TabIndex = 27;
            this.numericHeightOfTheSecondMatix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericHeightOfTheSecondMatix.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericHeightOfTheSecondMatix.ValueChanged += new System.EventHandler(this.numericHeightOfTheSecondMatix_ValueChanged);
            // 
            // numericWidthOfTheFirstMatix
            // 
            this.numericWidthOfTheFirstMatix.Location = new System.Drawing.Point(96, 292);
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
            this.numericWidthOfTheFirstMatix.TabIndex = 26;
            this.numericWidthOfTheFirstMatix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericWidthOfTheFirstMatix.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericWidthOfTheFirstMatix.ValueChanged += new System.EventHandler(this.numericWidthOfTheFirstMatix_ValueChanged);
            // 
            // numericHeightOfTheFirstMatix
            // 
            this.numericHeightOfTheFirstMatix.Location = new System.Drawing.Point(96, 260);
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
            this.numericHeightOfTheFirstMatix.TabIndex = 25;
            this.numericHeightOfTheFirstMatix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericHeightOfTheFirstMatix.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelWidthOfTheSecondMatrix
            // 
            this.labelWidthOfTheSecondMatrix.AutoSize = true;
            this.labelWidthOfTheSecondMatrix.Location = new System.Drawing.Point(347, 294);
            this.labelWidthOfTheSecondMatrix.Name = "labelWidthOfTheSecondMatrix";
            this.labelWidthOfTheSecondMatrix.Size = new System.Drawing.Size(65, 18);
            this.labelWidthOfTheSecondMatrix.TabIndex = 24;
            this.labelWidthOfTheSecondMatrix.Text = "columns";
            // 
            // labelHeightOfTheSecondMatrix
            // 
            this.labelHeightOfTheSecondMatrix.AutoSize = true;
            this.labelHeightOfTheSecondMatrix.Location = new System.Drawing.Point(347, 262);
            this.labelHeightOfTheSecondMatrix.Name = "labelHeightOfTheSecondMatrix";
            this.labelHeightOfTheSecondMatrix.Size = new System.Drawing.Size(41, 18);
            this.labelHeightOfTheSecondMatrix.TabIndex = 23;
            this.labelHeightOfTheSecondMatrix.Text = "rows";
            // 
            // labelWidthOfTheFirstMatrix
            // 
            this.labelWidthOfTheFirstMatrix.AutoSize = true;
            this.labelWidthOfTheFirstMatrix.Location = new System.Drawing.Point(25, 294);
            this.labelWidthOfTheFirstMatrix.Name = "labelWidthOfTheFirstMatrix";
            this.labelWidthOfTheFirstMatrix.Size = new System.Drawing.Size(65, 18);
            this.labelWidthOfTheFirstMatrix.TabIndex = 22;
            this.labelWidthOfTheFirstMatrix.Text = "columns";
            // 
            // labelHeightOfTheFirstMatrix
            // 
            this.labelHeightOfTheFirstMatrix.AutoSize = true;
            this.labelHeightOfTheFirstMatrix.Location = new System.Drawing.Point(25, 262);
            this.labelHeightOfTheFirstMatrix.Name = "labelHeightOfTheFirstMatrix";
            this.labelHeightOfTheFirstMatrix.Size = new System.Drawing.Size(41, 18);
            this.labelHeightOfTheFirstMatrix.TabIndex = 21;
            this.labelHeightOfTheFirstMatrix.Text = "rows";
            // 
            // labelDimensionsOfTheSecondMatrix
            // 
            this.labelDimensionsOfTheSecondMatrix.AutoSize = true;
            this.labelDimensionsOfTheSecondMatrix.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDimensionsOfTheSecondMatrix.Location = new System.Drawing.Point(346, 224);
            this.labelDimensionsOfTheSecondMatrix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDimensionsOfTheSecondMatrix.Name = "labelDimensionsOfTheSecondMatrix";
            this.labelDimensionsOfTheSecondMatrix.Size = new System.Drawing.Size(302, 19);
            this.labelDimensionsOfTheSecondMatrix.TabIndex = 20;
            this.labelDimensionsOfTheSecondMatrix.Text = "Enter dimensions of the second matrix\r\n";
            // 
            // labelDimensionsOfTheFirstMatix
            // 
            this.labelDimensionsOfTheFirstMatix.AutoSize = true;
            this.labelDimensionsOfTheFirstMatix.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDimensionsOfTheFirstMatix.Location = new System.Drawing.Point(24, 224);
            this.labelDimensionsOfTheFirstMatix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDimensionsOfTheFirstMatix.Name = "labelDimensionsOfTheFirstMatix";
            this.labelDimensionsOfTheFirstMatix.Size = new System.Drawing.Size(274, 19);
            this.labelDimensionsOfTheFirstMatix.TabIndex = 19;
            this.labelDimensionsOfTheFirstMatix.Text = "Enter dimensions of the first matrix\r\n";
            // 
            // labelNumberOfThreads
            // 
            this.labelNumberOfThreads.AutoSize = true;
            this.labelNumberOfThreads.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNumberOfThreads.Location = new System.Drawing.Point(24, 157);
            this.labelNumberOfThreads.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNumberOfThreads.Name = "labelNumberOfThreads";
            this.labelNumberOfThreads.Size = new System.Drawing.Size(157, 18);
            this.labelNumberOfThreads.TabIndex = 18;
            this.labelNumberOfThreads.Text = "Number of threads: 1 ";
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonStart.Location = new System.Drawing.Point(642, 510);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(118, 27);
            this.buttonStart.TabIndex = 16;
            this.buttonStart.TabStop = false;
            this.buttonStart.Text = "Start algorithm";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonGenerate.Location = new System.Drawing.Point(615, 294);
            this.buttonGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(145, 27);
            this.buttonGenerate.TabIndex = 32;
            this.buttonGenerate.TabStop = false;
            this.buttonGenerate.Text = "Generate matrices";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(349, 408);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(114, 18);
            this.labelTime.TabIndex = 33;
            this.labelTime.Text = "Execution time:";
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelProgress.Location = new System.Drawing.Point(24, 374);
            this.labelProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(79, 19);
            this.labelProgress.TabIndex = 37;
            this.labelProgress.Text = "Progress";
            // 
            // checkedListBoxStagesOfAlgorithm
            // 
            this.checkedListBoxStagesOfAlgorithm.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBoxStagesOfAlgorithm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxStagesOfAlgorithm.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkedListBoxStagesOfAlgorithm.ForeColor = System.Drawing.SystemColors.WindowText;
            this.checkedListBoxStagesOfAlgorithm.FormattingEnabled = true;
            this.checkedListBoxStagesOfAlgorithm.Location = new System.Drawing.Point(28, 408);
            this.checkedListBoxStagesOfAlgorithm.Name = "checkedListBoxStagesOfAlgorithm";
            this.checkedListBoxStagesOfAlgorithm.Size = new System.Drawing.Size(315, 126);
            this.checkedListBoxStagesOfAlgorithm.TabIndex = 38;
            this.checkedListBoxStagesOfAlgorithm.TabStop = false;
            // 
            // trackBarNumberOfThreads
            // 
            this.trackBarNumberOfThreads.BackColor = System.Drawing.SystemColors.Control;
            this.trackBarNumberOfThreads.Location = new System.Drawing.Point(188, 147);
            this.trackBarNumberOfThreads.Maximum = 64;
            this.trackBarNumberOfThreads.Minimum = 1;
            this.trackBarNumberOfThreads.Name = "trackBarNumberOfThreads";
            this.trackBarNumberOfThreads.Size = new System.Drawing.Size(572, 45);
            this.trackBarNumberOfThreads.TabIndex = 39;
            this.trackBarNumberOfThreads.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarNumberOfThreads.Value = 1;
            this.trackBarNumberOfThreads.Scroll += new System.EventHandler(this.trackBarNumberOfThreads_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.trackBarNumberOfThreads);
            this.Controls.Add(this.checkedListBoxStagesOfAlgorithm);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.buttonGenerate);
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
            this.Controls.Add(this.buttonStart);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matrix multiplication";
            ((System.ComponentModel.ISupportInitialize)(this.numericWidthOfTheSecondMatix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeightOfTheSecondMatix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidthOfTheFirstMatix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeightOfTheFirstMatix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNumberOfThreads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSelectedLibrary;
        private System.Windows.Forms.RadioButton radioButtonCpp;
        private System.Windows.Forms.RadioButton radioButtonAsm;
        private System.Windows.Forms.NumericUpDown numericWidthOfTheSecondMatix;
        private System.Windows.Forms.NumericUpDown numericHeightOfTheSecondMatix;
        private System.Windows.Forms.NumericUpDown numericWidthOfTheFirstMatix;
        private System.Windows.Forms.NumericUpDown numericHeightOfTheFirstMatix;
        private System.Windows.Forms.Label labelWidthOfTheSecondMatrix;
        private System.Windows.Forms.Label labelHeightOfTheSecondMatrix;
        private System.Windows.Forms.Label labelWidthOfTheFirstMatrix;
        private System.Windows.Forms.Label labelHeightOfTheFirstMatrix;
        private System.Windows.Forms.Label labelDimensionsOfTheSecondMatrix;
        private System.Windows.Forms.Label labelDimensionsOfTheFirstMatix;
        private System.Windows.Forms.Label labelNumberOfThreads;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.CheckedListBox checkedListBoxStagesOfAlgorithm;
        private System.Windows.Forms.TrackBar trackBarNumberOfThreads;
    }
}

