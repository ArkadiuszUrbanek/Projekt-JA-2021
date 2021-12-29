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
using System.Diagnostics;
using System.IO;
using System.Threading;

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
        //[DllImport("C:\\Users\\Arek\\Desktop\\projekt JA\\Projekt-JA-2021\\x64\\Debug\\xcppdll.dll", EntryPoint = "calculateSubmatrix")]
        //public static extern unsafe void calculateSubmatrix(int** firstSubmatrix, int firstSubmatrixWidth, int firstSubmatrixHeight, int** secondSubmatrix, int secondSubmatrixWidth, int secondSubmatrixHeight, int** resultSubmatrix);
        //[DllImport("../../x64/Debug/xcppdll.dll", EntryPoint = "calculateSubmatrix")]
        [DllImport("C:\\Users\\Arek\\Desktop\\projekt JA\\Projekt-JA-2021\\x64\\Debug\\xcppdll.dll", EntryPoint = "calculateSubmatrix", CallingConvention = CallingConvention.Cdecl)]
        //public static extern unsafe void calculateSubmatrix(int* firstFlattenedSubmatrix, int firstFlattenedSubmatrixWidth, int firstFlattenedSubmatrixHeight, int* secondFlattenedSubmatrix, int secondFlattenedSubmatrixWidth, int secondFlattenedSubmatrixHeight, int* resultFlattenedSubmatrix);
        public static extern void calculateSubmatrix(int[] firstFlattenedSubmatrix, int firstFlattenedSubmatrixWidth, int firstFlattenedSubmatrixHeight, int[] secondFlattenedSubmatrix, int secondFlattenedSubmatrixWidth, int secondFlattenedSubmatrixHeight, int[] resultFlattenedSubmatrix);

        public Form1() {
            InitializeComponent();

            this.Size = new Size(800, 600);
            this.Padding = new Padding(20);
            this.Text = "Matrix multiplication";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Font = new Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonCpp.Checked = true;

            //this.FormClosing += new FormClosingEventHandler(FormTemplate_FormClosing);

        }

        //protected bool xClicked = true;

        private bool cppDllChosen = true;
        private bool areMatricesInitialized = false;

        private int firstMatrixWidth = 0;
        private int firstMatrixHeight = 0;

        private int secondMatrixWidth = 0;
        private int secondMatrixHeight = 0;

        private List<int[]> listOfFirstMatrixRows = new List<int[]>();
        private List<int[]> listOfSecondMatrixRows = new List<int[]>();

        //private List<int[][]> listOfResultSubmatrices = new List<int[][]>();
        //private List<int[]> listOfResultFlattenedSubmatrices = new List<int[]>();

        //ToArray()

        //private int firstMatrix[][];
        /*private class Coordinates { 
            private int x { get; set; }
            private int y { get; set; }
        }*/

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

        private void radioButtonCpp_CheckedChanged(object sender, EventArgs e) {
            cppDllChosen = true;

        }

        private void radioButtonAsm_CheckedChanged(object sender, EventArgs e) {
            cppDllChosen = false;

        }

        private void multiplyMatrices(int rowIndexFromWhichSubmatixBegins, int firstSubmatrixHeight, int[] secondFlattenedMatrix, int[,] resultMatrix) {
            //to jest w klasie
            //private List<int[]> listOfFirstMatrixRows = new List<int[]>();
            //private List<int[]> listOfSecondMatrixRows = new List<int[]>();
            //private int secondMatrixWidth = 0;
            //private int secondMatrixHeight = 0;

            //Console.WriteLine("rowIndex = {0}, SubmatrixHeight = {1}", rowIndexFromWhichSubmatixBegins, firstSubmatrixHeight);
            //Console.WriteLine("rowIndex = {1}, SubmatrixHeight = {2}", rowIndexFromWhichSubmatixBegins, firstSubmatrixHeight);

            //Stworzenie spłaszczonego wycinka podmacierzy macierzy pierwszej
            int[] firstFlattenedSubmatrix = new int[firstMatrixWidth * firstSubmatrixHeight];
       
            for (int i = rowIndexFromWhichSubmatixBegins; i < firstSubmatrixHeight + rowIndexFromWhichSubmatixBegins; i++) {
                for (int j = 0; j < firstMatrixWidth; j++) {
                    firstFlattenedSubmatrix[(i - rowIndexFromWhichSubmatixBegins) * firstMatrixWidth + j] = listOfFirstMatrixRows[i][j];

                }

            }

            //Stworzenie spłaszczonej podmacierzy wynikowej
            int[] resultFlattenedSubmatrix = new int[secondMatrixWidth * firstSubmatrixHeight];


            if (cppDllChosen == true) {
                //wybrano c++ dll
                calculateSubmatrix(firstFlattenedSubmatrix, firstMatrixWidth, firstSubmatrixHeight, secondFlattenedMatrix, secondMatrixWidth, secondMatrixHeight, resultFlattenedSubmatrix);

            } else { 
                //wybrano masm64 dll


            }



        } 
        private void buttonStart_Click(object sender, EventArgs e) {

            buttonStart.Enabled = false;
            numericNumberOfThreads.Enabled = false;
            radioButtonCpp.Enabled = false;
            radioButtonAsm.Enabled = false;

            if (areMatricesInitialized == false) {
                firstMatrixWidth = (int) numericWidthOfTheFirstMatix.Value;
                firstMatrixHeight = (int) numericHeightOfTheFirstMatix.Value;

                numericWidthOfTheFirstMatix.Enabled = false;
                numericHeightOfTheFirstMatix.Enabled = false;

                secondMatrixWidth = (int) numericWidthOfTheSecondMatix.Value;
                secondMatrixHeight = (int) numericHeightOfTheSecondMatix.Value;

                numericWidthOfTheSecondMatix.Enabled = false;
                numericHeightOfTheSecondMatix.Enabled = false;


                Random drawingNumbersObj = new Random();
                StreamWriter fileWriter = new StreamWriter("first_matrix.csv", false);

                for (int i = 0; i < firstMatrixHeight; i++) {
                    int[] row = new int[firstMatrixWidth];

                    for (int j = 0; j < firstMatrixWidth; j++) {
                        row[j] = drawingNumbersObj.Next(0, 100);
                        
                        if(j == firstMatrixWidth - 1) fileWriter.Write(row[j]);
                        else fileWriter.Write(row[j] + ";");

                    }
                    listOfFirstMatrixRows.Add(row);
                    fileWriter.WriteLine("");
                    fileWriter.Flush();

                }

                fileWriter.Close();
                fileWriter = new StreamWriter("second_matrix.csv", false);

                for (int i = 0; i < secondMatrixHeight; i++) {
                    int[] row = new int[secondMatrixWidth];

                    for (int j = 0; j < secondMatrixWidth; j++) {
                        row[j] = drawingNumbersObj.Next(0, 100);

                        if (j == secondMatrixWidth - 1) fileWriter.Write(row[j]);
                        else fileWriter.Write(row[j] + ";");

                    }
                    listOfSecondMatrixRows.Add(row);
                    fileWriter.WriteLine("");
                    fileWriter.Flush();

                }

                fileWriter.Close();
                areMatricesInitialized = true;

            }

            if ((int) numericNumberOfThreads.Value > firstMatrixHeight || (int) numericNumberOfThreads.Value > secondMatrixWidth) {
                Console.WriteLine("Could not use all threads on such small matrices!");

            } else { 

                //Rozpoczęcie odliczania czasu
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                int basicFirstSubmatrixHeight = firstMatrixHeight / (int) numericNumberOfThreads.Value;
                int extraFirstSubmatrixHeight = firstMatrixHeight % (int) numericNumberOfThreads.Value;

                //Zmiana wymiaru drugiej macierzy z 2D na 1D 
                int[] secondFlattenedMatrix = new int[secondMatrixWidth * secondMatrixHeight];

                for (int i = 0; i < secondMatrixHeight; i++) {
                    for (int j = 0; j < secondMatrixWidth; j++) {
                        secondFlattenedMatrix[i * secondMatrixWidth + j] = listOfSecondMatrixRows[i][j];

                    }

                }

                //Stworzenie macierzy wynikowej
                int[,] resultMatrix = new int[firstMatrixWidth, secondMatrixHeight];

                //Stworzenie tablicy wątków
                Thread[] threadsArray = new Thread[(int) numericNumberOfThreads.Value];

                //Rozdział wierszy pierwszej macierzy pomiędzy wątki
                for (int i = 0, y = 0; i < (int)numericNumberOfThreads.Value; i++) {
                    if (extraFirstSubmatrixHeight > 0) {
                        //Console.WriteLine("i = {0}, y = {1}, basicFirstSubmatrixHeight = {2}", i, y, basicFirstSubmatrixHeight + 1);
                        int temp = y;
                        threadsArray[i] = new Thread(unsued => multiplyMatrices(temp, basicFirstSubmatrixHeight + 1, secondFlattenedMatrix, resultMatrix));
                        //multiplyMatrices(y, basicFirstSubmatrixHeight + 1, secondFlattenedMatrix, resultMatrix);
                        y++;
                        extraFirstSubmatrixHeight--;

                    } else {
                        //Console.WriteLine("i = {0}, y = {1}, basicFirstSubmatrixHeight = {2}", i, y, basicFirstSubmatrixHeight);
                        int temp = y;
                        threadsArray[i] = new Thread(unsued => multiplyMatrices(temp, basicFirstSubmatrixHeight, secondFlattenedMatrix, resultMatrix));
                        //multiplyMatrices(y, basicFirstSubmatrixHeight, secondFlattenedMatrix, resultMatrix);

                    }

                    y += basicFirstSubmatrixHeight;
                    threadsArray[i].Start();

                }


                //foreach (var singleThread in threadsArray) {
                //    singleThread.Start();

                //}
                    /*Thread[] threadsArray = new Thread[numberOfThreads];

                    for (int i = 0; i < numberOfThreads; i++)
                    {

                        threadsArray[i] = new Thread(unsued => method());

                    }

                    stopWatch.Start();*/

                    foreach (var singleThread in threadsArray) {
                    singleThread.Join();

                }

                //Zakończenie pomiaru czasu
                stopwatch.Stop();

                //Pobranie zmierzonego czasu
                TimeSpan ts = stopwatch.Elapsed;
                Console.WriteLine("Elapsed Time is {0:00}:{1:00}:{2:00}.{3}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

            }

            buttonStart.Enabled = true;
            numericNumberOfThreads.Enabled = true;
            radioButtonCpp.Enabled = true;
            radioButtonAsm.Enabled = true;

            //this.Hide();
            //za każdym razem nowy 2 form jest tworzony
            //Form2 f2 = new Form2(this.Size, this.Left, this.Top, this.Text, firstMatrixDimensions, secondMatrixDimensions);

            //if (isArrayGenerated == false) { 


            //}

            //Form2 f2 = new Form2();
            //f2.Show();
            //f2.Closed += (s, evt) => this.forceImmediateClose = true;
            //f2.Closed += (s, evt) => this.Close();
            //f2.VisibleChanged += (s, evt) => this.Show();
        }


    }
}
