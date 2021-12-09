using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xcs
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            this.Size = new Size(800, 600);
            this.Padding = new Padding(20);
            this.Text = "Matrix multiplication";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Font = new Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));

            buttonStartOver.Enabled = true; //przycisk zostanie włączony po wykonaniu algorytmu
        }

        private void buttonStartOver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
