using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using System.Runtime.InteropServices;

namespace xcs
{
    public partial class Form1 : FormTemplate
    {

        //[DllImport("C:\\Users\\Arek\\Desktop\\Solution\\x64\\Debug\\xcadll.dll")]
        //[DllImport("C:\\Users\\Arek\\Desktop\\Solution\\x64\\release\\xcadll.dll")]
        //static extern void Example(ulong[] data);

        //[DllImport("DllMain.dll", EntryPoint = "HelloWorld")]
        //[DllImport("C:\\Users\\Arek\\Desktop\\Solution\\x64\\Debug\\xcppdll.dll", CallingConvention = CallingConvention.Cdecl)]
        //[DllImport("C:\\Users\\Arek\\Desktop\\Solution\\x64\\Debug\\xcppdll.dll", EntryPoint = "exemplary_procedure")]
        //public static extern int exemplary_procedure();

        public Form1() : base()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ulong[] data = new ulong[4] { 0, 0, 0, 0 };
            //textBox1.Text = "0x" + data[0].ToString("x16");
            //Console.WriteLine("{0:X16}", data[0]);
            //Example(data);
            //Console.WriteLine("{0:X16}", data[0]);
            //textBox2.Text = "0x" + data[0].ToString("x16");


            //textBox3.Text = exemplary_procedure().ToString();
        }

    }
}
