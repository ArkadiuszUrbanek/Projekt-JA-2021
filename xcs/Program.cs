using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//using System.Runtime.InteropServices;


namespace xcs
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        //[DllImport("c:\\xcadll\\x64\\debug\\xcadll.dll")]
        //[DllImport("c:\\xcadll\\x64\\release\\xcadll.dll")]

        //static extern void Example(ulong[] data);

        [STAThread]
        static void Main()
        {

            /*ulong[] data = new ulong[4] { 0, 0, 0, 0 };
            Console.WriteLine("{0:X16}", data[0]);
            Example(data);
            Console.WriteLine("{0:X16}", data[0]);
            return;*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
