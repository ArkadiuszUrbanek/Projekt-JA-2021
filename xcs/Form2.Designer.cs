
namespace xcs
{
    partial class Form2
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
            this.buttonStartOver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStartOver
            // 
            this.buttonStartOver.Enabled = false;
            this.buttonStartOver.Location = new System.Drawing.Point(642, 510);
            this.buttonStartOver.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStartOver.Name = "buttonStartOver";
            this.buttonStartOver.Size = new System.Drawing.Size(118, 27);
            this.buttonStartOver.TabIndex = 0;
            this.buttonStartOver.Text = "Start over";
            this.buttonStartOver.UseVisualStyleBackColor = true;
            this.buttonStartOver.Click += new System.EventHandler(this.buttonStartOver_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.buttonStartOver);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form2";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matrix multiplication";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStartOver;
    }
}