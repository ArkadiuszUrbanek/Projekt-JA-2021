using System;
using System.Drawing;
using System.Windows.Forms;

namespace xcs
{
    public class FormTemplate : Form
    {

        protected FormTemplate()
        {
            InitializeComponent();

            this.Size = new Size(800, 600);
            this.Text = "Matrix multiplication";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            this.FormClosing += new FormClosingEventHandler(FormTemplate_FormClosing);

        }

        protected bool xClicked = true;

        protected void FormTemplate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && xClicked == true)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "Dialog Title", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Environment.Exit(0);

                }
                else
                {
                    e.Cancel = true;

                }

            }
            else
            {
                e.Cancel = true;

            }

        }

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormTemplate
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FormTemplate";
            this.Load += new System.EventHandler(this.FormTemplate_Load);
            this.ResumeLayout(false);

        }

        private void FormTemplate_Load(object sender, EventArgs e)
        {
            //if (this.Site == null || !this.Site.DesignMode)
            //{
            //    // Not in design mode, okay to do dangerous stuff...
            //    this.UpdateOnline();
            //}
        }
    }

}