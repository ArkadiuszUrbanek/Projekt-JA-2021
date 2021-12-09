using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace xcs
{
    public partial class Form1 : Form
    {

        //[DllImport("C:\\Users\\Arek\\Desktop\\projekt JA\\Projekt-JA-2021\\x64\\Debug\\xcadll.dll")]
        //[DllImport("C:\\Users\\Arek\\Desktop\\Solution\\x64\\release\\xcadll.dll")]
        //static extern void Example(ulong[] data);

        //[DllImport("DllMain.dll", EntryPoint = "HelloWorld")]
        //[DllImport("C:\\Users\\Arek\\Desktop\\Solution\\x64\\Debug\\xcppdll.dll", CallingConvention = CallingConvention.Cdecl)]

        //[DllImport("C:\\Users\\Arek\\Desktop\\projekt JA\\Projekt-JA-2021\\x64\\Debug\\xcppdll.dll", EntryPoint = "exemplary_procedure")]
        //C:\Users\Arek\Desktop\projekt JA\Projekt-JA-2021\x64\Debug
        //public static extern int exemplary_procedure();

        public Form1() //: base()
        {
            InitializeComponent();

            this.Size = new Size(800, 600);
            this.Padding = new Padding(20);
            this.Text = "Matrix multiplication";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Font = new Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));

            //this.FormClosing += new FormClosingEventHandler(FormTemplate_FormClosing);

        }

        //protected bool xClicked = true;

        /*protected void FormTemplate_FormClosing(object sender, FormClosingEventArgs e)
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

        }*/

        private void Form1_Load(object sender, EventArgs e)
        {
            //ulong[] data = new ulong[4] { 0, 0, 0, 0 };
            //labelDimensionsOfTheFirstMatix.Text = "0x" + data[0].ToString("x16");

            //Console.WriteLine("{0:X16}", data[0]);
            //Example(data);
            //Console.WriteLine("{0:X16}", data[0]);
            //labelDimensionsOfTheSecondMatrix.Text = "0x" + data[0].ToString("x16");

            //labelDimensionsOfTheFirstMatix.Text = exemplary_procedure().ToString();
            //textBox3.Text = exemplary_procedure().ToString();
        }

        private void numericNumberOfThreads_ValueChanged(object sender, EventArgs e)  {
            if (numericNumberOfThreads.Value == numericNumberOfThreads.Maximum) {
                numericNumberOfThreads.Value = numericNumberOfThreads.Minimum + 1;
            }

            if (numericNumberOfThreads.Value == numericNumberOfThreads.Minimum) {
                numericNumberOfThreads.Value = numericNumberOfThreads.Maximum - 1;
            }
        }

        private void numericWidthOfTheFirstMatix_ValueChanged(object sender, EventArgs e) {
            numericHeightOfTheSecondMatix.Value = numericWidthOfTheFirstMatix.Value;
        }

        private void numericHeightOfTheSecondMatix_ValueChanged(object sender, EventArgs e) {
            numericWidthOfTheFirstMatix.Value = numericHeightOfTheSecondMatix.Value;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            //za każdym razem nowy 2 form jest tworzony
            //Form2 f2 = new Form2(this.Size, this.Left, this.Top, this.Text, firstMatrixDimensions, secondMatrixDimensions);
            Form2 f2 = new Form2();
            f2.Show();
            //f2.Closed += (s, evt) => this.forceImmediateClose = true;
            f2.Closed += (s, evt) => this.Close();
            f2.VisibleChanged += (s, evt) => this.Show();
        }
    }
}
