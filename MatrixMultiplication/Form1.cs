using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

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

namespace MatrixMultiplication {
    
    /*Klasa reprezentująca okno programu.*/
    public partial class Form1 : Form {

        /*Import bibliotek DLL.*/
        [DllImport(@"C:\Users\Arek\Desktop\MatrixMultiplication\x64\Release\MatrixMultiplicationCPP.dll")]
        //[DllImport(@"C:\Users\Arek\Desktop\MatrixMultiplication\x64\Debug\MatrixMultiplicationCPP.dll")]
        static extern int calculateSubmatrixCpp(int[] firstFlattenedSubmatrix, int firstFlattenedSubmatrixHeight, int[] secondFlattenedAndTranposedMatrix, int secondFlattenedAndTranposedMatrixHeight, int firstFlattenedSubmatrixWidthAndSecondFlattenedAndTransposedMatrixWidth, int[] resultFlattenedSubmatrix);

        [DllImport(@"C:\Users\Arek\Desktop\MatrixMultiplication\x64\Release\MatrixMultiplicationMASM64.dll")]
        //[DllImport(@"C:\Users\Arek\Desktop\MatrixMultiplication\x64\Debug\MatrixMultiplicationMASM64.dll")]
        static extern int calculateSubmatrixMasm64(int[] firstFlattenedSubmatrix, int firstFlattenedSubmatrixHeight, int[] secondFlattenedAndTranposedMatrix, int secondFlattenedAndTranposedMatrixHeight, int firstFlattenedSubmatrixWidthAndSecondFlattenedAndTransposedMatrixWidth, int[] resultFlattenedSubmatrix);

        /*Konstruktor bezargumentowy.*/
        public Form1() {
            InitializeComponent();

            this.Size = new Size(800, 600);
            this.Padding = new Padding(20);
            this.Text = "Matrix multiplication";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Font = new Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte) 238);
            this.radioButtonCpp.Checked = true;
            this.buttonStart.Enabled = false;
            this.trackBarNumberOfThreads.Maximum = 64;
            this.trackBarNumberOfThreads.Minimum = 1;
            this.trackBarNumberOfThreads.Value = 1;

            this.checkedListBoxStagesOfAlgorithm.Items.Add("Second Matrix flattened and transposed");
            this.checkedListBoxStagesOfAlgorithm.Items.Add("Result matrix created");
            this.checkedListBoxStagesOfAlgorithm.Items.Add("All Threads created and started");
            this.checkedListBoxStagesOfAlgorithm.Items.Add("Matrix multiplication executed");
            this.checkedListBoxStagesOfAlgorithm.Items.Add("Result matrix saved to csv file");
            this.checkedListBoxStagesOfAlgorithm.Enabled = false;

        }

        /*Zmienna sygnalizująca która bilioteka DLL została wybrana przez użytkownika.*/
        private bool cppDllChosen = true;


        /*Liczba wierszy pierwszej macierzy.*/
        private int realFirstMatrixHeight = 0;

        /*Liczba kolumn pierwszej macierzy oraz liczba wierszy drugiej macierzy wyrównane do liczby podzielnej przez 4.*/
        private int alignedTo4FirstMatrixWidthAndSecondMatrixHeight = 0;

        /*Liczba kolumn pierwszej macierzy oraz liczba wierszy drugiej macierzy.*/
        private int realFirstMatrixWidthAndSecondMatrixHeight = 0;

        /*Liczba kolumn drugiej macierzy*/
        private int realSecondMatrixWidth = 0;


        /*Lista wierszy pierwszej macierzy.*/
        private List<int[]> listOfFirstMatrixRows = new List<int[]>();

        /*Lista wierszy drugiej macierzy.*/
        private List<int[]> listOfSecondMatrixRows = new List<int[]>();

        //static Mutex mutexObj = new Mutex();

        /* Metoda wywoływana w momencie, gdy zmienia się stan zaznaczenia przycisku radiowego.
         * sender - obiekt, który wysłał powiadomienie o zmianie swojego stanu
         * e - obiekt przechowujacy dodatkowe argumenty zdarzenia
         */
        private void radioButtonCpp_CheckedChanged(object sender, EventArgs e) {
            cppDllChosen = true;

        }

        /* Metoda wywoływana w momencie, gdy zmienia się stan zaznaczenia przycisku radiowego.
         * sender - obiekt, który wysłał powiadomienie o zmianie swojego stanu
         * e - obiekt przechowujacy dodatkowe argumenty zdarzenia
         */
        private void radioButtonAsm_CheckedChanged(object sender, EventArgs e) {
            cppDllChosen = false;

        }

        /* Metoda wywoływana w momencie, gdy zmienia się stan wartość na suwaku.
         * Tekst na etykiecie labelNumberOfThreads jest zmieniany odpowiednio do ilości wątków ustawionych na suwaku.
         * sender - obiekt, który wysłał powiadomienie o zmianie swojego stanu
         * e - obiekt przechowujacy dodatkowe argumenty zdarzenia
         */
        private void trackBarNumberOfThreads_Scroll(object sender, EventArgs e) {
            labelNumberOfThreads.Text = "Number of threads: " + trackBarNumberOfThreads.Value.ToString();

        }

        /* Metoda wywoływana w momencie, gdy zmienia się wartośc wpisana w pole numeryczne.
         * Macierze mogą zostać przez siebie wymnożone w momencie, gdy liczba kolumn pierwszej macierzy jest taka sama jak liczba wierszy drugiej macierzy.
         * W celu uniknięcia błędu ze strony użytkownika metoda ustawia taką samą wartość polu numerycznemu z liczbą wierszy drugiej macierzy na taką jaka jest w polu numerycznym z kolumnami pierwszej macierzy.
         * sender - obiekt, który wysłał powiadomienie o zmianie swojego stanu
         * e - obiekt przechowujacy dodatkowe argumenty zdarzenia
         */
        private void numericWidthOfTheFirstMatix_ValueChanged(object sender, EventArgs e) {
            numericHeightOfTheSecondMatix.Value = numericWidthOfTheFirstMatix.Value;

        }

        /* Metoda wywoływana w momencie, gdy zmienia się wartośc wpisana w pole numeryczne.
         * Macierze mogą zostać przez siebie wymnożone w momencie, gdy liczba kolumn pierwszej macierzy jest taka sama jak liczba wierszy drugiej macierzy.
         * W celu uniknięcia błędu ze strony użytkownika metoda ustawia taką samą wartość polu numerycznemu z liczbą kolumn pierwszej macierzy na taką jaka jest w polu numerycznym z wierszami drugiej macierzy.
         * sender - obiekt, który wysłał powiadomienie o zmianie swojego stanu
         * e - obiekt przechowujacy dodatkowe argumenty zdarzenia
         */
        private void numericHeightOfTheSecondMatix_ValueChanged(object sender, EventArgs e) {
            numericWidthOfTheFirstMatix.Value = numericHeightOfTheSecondMatix.Value;

        }

        /* Metoda wykonywana w sposób równoległy.
         * Tworzy oraz inicjalizuje podmacierz macierzy A. Wywołuje odpowiednią bibliotekę dynamiczną DLL. Na samym końcu wpisuje wartości z podmacierzy macierzy A do macierzy wynikowej.
         * rowIndexFromWhichSubmatixBegins - indeks, od którego należy skopiować dane z macierzy A do tablicy 1D reprezentującej podmacierz macierzy A
         * firstSubmatrixHeight - liczba wierszy podmacierzy macierzy A
         * secondFlattenedAndTranposedMatrix - tablica 1D reprezentująca transponowaną macierz B 
         * resultMatrix - tablica 2D reprezentująca macierz wynikową
         */
        private void multiplyMatrices(int rowIndexFromWhichSubmatixBegins, int firstSubmatrixHeight, int[] secondFlattenedAndTranposedMatrix, int[,] resultMatrix) {

            //Stworzenie spłaszczonego wycinka podmacierzy macierzy pierwszej
            int[] firstFlattenedSubmatrix = new int[alignedTo4FirstMatrixWidthAndSecondMatrixHeight * firstSubmatrixHeight];

            for (int i = rowIndexFromWhichSubmatixBegins; i < firstSubmatrixHeight + rowIndexFromWhichSubmatixBegins; i++) {
                for (int j = 0; j < alignedTo4FirstMatrixWidthAndSecondMatrixHeight; j++) {
                    firstFlattenedSubmatrix[(i - rowIndexFromWhichSubmatixBegins) * alignedTo4FirstMatrixWidthAndSecondMatrixHeight + j] = listOfFirstMatrixRows[i][j];

                }

            }

            //Stworzenie spłaszczonej podmacierzy wynikowej
            int[] resultFlattenedSubmatrix = new int[realSecondMatrixWidth * firstSubmatrixHeight];


            if (cppDllChosen == true) {
                //wybrano c++ dll
                calculateSubmatrixCpp(firstFlattenedSubmatrix, firstSubmatrixHeight, secondFlattenedAndTranposedMatrix, realSecondMatrixWidth, alignedTo4FirstMatrixWidthAndSecondMatrixHeight, resultFlattenedSubmatrix);

            } else {
                //wybrano masm64 dll
                calculateSubmatrixMasm64(firstFlattenedSubmatrix, firstSubmatrixHeight, secondFlattenedAndTranposedMatrix, realSecondMatrixWidth, alignedTo4FirstMatrixWidthAndSecondMatrixHeight, resultFlattenedSubmatrix);
                
            }

            //Zapis podmacierzy do macierzy wynikowej
            //mutexObj.WaitOne();

            for (int i = rowIndexFromWhichSubmatixBegins; i < firstSubmatrixHeight + rowIndexFromWhichSubmatixBegins; i++) {
                for (int j = 0; j < realSecondMatrixWidth; j++) {
                    resultMatrix[i, j] = resultFlattenedSubmatrix[(i - rowIndexFromWhichSubmatixBegins) * realSecondMatrixWidth + j];

                }

            }

            //mutexObj.ReleaseMutex();

        }

        /* Metoda wywoływana w momencie, gdy przycisk rozpoczynający algorytm zostanie kliknięty.
         * Na samym początku metoda wyłącza możliwość interakcji użytkownika ze wszystkimi kontrolkami.
         * Następnie, sprawdza ona czy wiersze pierwszej macierzy da się rozdzielić pomiędzy liczbę wątków.
         * Jeżeli liczby wierszy pierwszej macierzy nie da sie rozdzielić pomiędzy wątki metoda wyświetla komunikat o błędzie i przywraca możliwość interakcji użytkownika ze wszystkimi kontrolkami.
         * W przypadku, gdy liczba wierszy pierwszej macierzy jest większa lub równa liczbie wątków metoda rozpoczyna algorytm mnożący przez siebie macierze.
         * Zegar rozpoczyna odliczanie.
         * Tworzona i inicjalizowana jest tablica 1D reprezentująca transponowaną drugą macierz.
         * Tworzona jest macierz wynikowa.
         * Tworzona jest tablica wątków.
         * W pętli poszczególnym wątkom jest przydzielane zadanie wykonania metody multiplyMatrices z odpowiednimi parametrami.
         * Wątki zostają natychmiast rozpoczęte.
         * Po ukończeniu mnożenia macierzy przez wszystkie wątki zatrzymywany jest zegar i w GUI zostaje wyświetlony zmierzony czas.
         * Macierz wynikowa zostaje zapisana do pliku o nazwie "result_matrix.csv".
         * Na samym końcu przywracana jest możliwość interakcji użytkownika ze wszystkimi kontrolkami w GUI.
         * sender - obiekt, który wysłał powiadomienie o zmianie swojego stanu
         * e - obiekt przechowujacy dodatkowe argumenty zdarzenia
         */
        private void buttonStart_Click(object sender, EventArgs e) {
            buttonGenerate.Enabled = false;
            buttonStart.Enabled = false;
            radioButtonCpp.Enabled = false;
            radioButtonAsm.Enabled = false;
            trackBarNumberOfThreads.Enabled = false;
            numericWidthOfTheFirstMatix.Enabled = false;
            numericHeightOfTheFirstMatix.Enabled = false;
            numericWidthOfTheSecondMatix.Enabled = false;
            numericHeightOfTheSecondMatix.Enabled = false;


            numericWidthOfTheFirstMatix.Value = realFirstMatrixWidthAndSecondMatrixHeight;
            numericHeightOfTheFirstMatix.Value = realFirstMatrixHeight;
            
            numericWidthOfTheSecondMatix.Value = realSecondMatrixWidth;
            numericHeightOfTheSecondMatix.Value = realFirstMatrixWidthAndSecondMatrixHeight;


            if (trackBarNumberOfThreads.Value > realFirstMatrixHeight) {
                MessageBox.Show("Number of rows of the first matrix is too small to be splitted between all threads.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } else {

                //Rozpoczęcie odliczania czasu
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                int basicFirstSubmatrixHeight = realFirstMatrixHeight / trackBarNumberOfThreads.Value;
                int extraFirstSubmatrixHeight = realFirstMatrixHeight % trackBarNumberOfThreads.Value;

                //Zmiana wymiaru drugiej macierzy z 2D na 1D oraz jej transpozycja 
                int[] secondFlattenedAndTransposedMatrix = new int[alignedTo4FirstMatrixWidthAndSecondMatrixHeight * realSecondMatrixWidth];

                for (int i = 0; i < realSecondMatrixWidth; i++) {
                    for (int j = 0; j < alignedTo4FirstMatrixWidthAndSecondMatrixHeight; j++) {
                        secondFlattenedAndTransposedMatrix[i * alignedTo4FirstMatrixWidthAndSecondMatrixHeight + j] = listOfSecondMatrixRows[j][i];

                    }

                }

                checkedListBoxStagesOfAlgorithm.SetItemCheckState(0, CheckState.Checked);

                //Stworzenie macierzy wynikowej
                int[,] resultMatrix = new int[realFirstMatrixHeight, realSecondMatrixWidth];
                checkedListBoxStagesOfAlgorithm.SetItemCheckState(1, CheckState.Checked);

                //Stworzenie tablicy wątków
                Thread[] threadsArray = new Thread[trackBarNumberOfThreads.Value];

                //Rozdział wierszy pierwszej macierzy pomiędzy wątki
                for (int i = 0, y = 0; i < trackBarNumberOfThreads.Value; i++) {
                    if (extraFirstSubmatrixHeight > 0) {
                        int temp = y;
                        threadsArray[i] = new Thread(unsued => multiplyMatrices(temp, basicFirstSubmatrixHeight + 1, secondFlattenedAndTransposedMatrix, resultMatrix));
                        y++;
                        extraFirstSubmatrixHeight--;

                    } else {
                        int temp = y;
                        threadsArray[i] = new Thread(unsued => multiplyMatrices(temp, basicFirstSubmatrixHeight, secondFlattenedAndTransposedMatrix, resultMatrix));

                    }

                    y += basicFirstSubmatrixHeight;
                    threadsArray[i].Start();
                    if(i == trackBarNumberOfThreads.Value - 1) checkedListBoxStagesOfAlgorithm.SetItemCheckState(2, CheckState.Checked);

                }


                foreach (var singleThread in threadsArray) {
                    singleThread.Join();

                }

                //Zakończenie pomiaru czasu
                stopwatch.Stop();

                
                //Pobranie zmierzonego czasu
                TimeSpan ts = stopwatch.Elapsed;
                labelTime.Text = "Execution time: " + ts.Hours + " [h] " + ts.Minutes + " [min] " + ts.Seconds + " [sec] " + ts.Milliseconds + " [ms]";


                checkedListBoxStagesOfAlgorithm.SetItemCheckState(3, CheckState.Checked);

                //Zapis macierzy wynikowej do pliku csv
                StreamWriter fileWriter = new StreamWriter("result_matrix.csv", false);

                for (int i = 0; i < realFirstMatrixHeight; i++) {
                    for (int j = 0; j < realSecondMatrixWidth; j++) {
                        if (j == realSecondMatrixWidth - 1) fileWriter.Write(resultMatrix[i, j]);
                        else fileWriter.Write(resultMatrix[i, j] + ";");

                    }
                    fileWriter.WriteLine("");
                    fileWriter.Flush();

                }

                fileWriter.Close();

                checkedListBoxStagesOfAlgorithm.SetItemCheckState(4, CheckState.Checked);

                MessageBox.Show("Matrices have been successfully multiplied.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                labelTime.Text = "Execution time:";

                checkedListBoxStagesOfAlgorithm.SetItemCheckState(0, CheckState.Unchecked);
                checkedListBoxStagesOfAlgorithm.SetItemCheckState(1, CheckState.Unchecked);
                checkedListBoxStagesOfAlgorithm.SetItemCheckState(2, CheckState.Unchecked);
                checkedListBoxStagesOfAlgorithm.SetItemCheckState(3, CheckState.Unchecked);
                checkedListBoxStagesOfAlgorithm.SetItemCheckState(4, CheckState.Unchecked);

            }

            buttonGenerate.Enabled = true;
            buttonStart.Enabled = true;
            radioButtonCpp.Enabled = true;
            radioButtonAsm.Enabled = true;
            trackBarNumberOfThreads.Enabled = true;
            numericWidthOfTheFirstMatix.Enabled = true;
            numericHeightOfTheFirstMatix.Enabled = true;
            numericWidthOfTheSecondMatix.Enabled = true;
            numericHeightOfTheSecondMatix.Enabled = true;
        }

        /* Metoda wywoływana w momencie, gdy przycisk rozpoczynający generowanie macierzy do wymnożenia zostanie kliknięty.
         * Na samym początku metoda wyłącza możliwość interakcji użytkownika ze wszystkimi kontrolkami.
         * Liczba kolumn pierwszej macierzy, która jest również liczbą wierszy drugiej macierzy jest tak modyfikowana, aby była liczbą podzielną przez 4.
         * Macierze są wypełniane całkowitymi liczbami losowymi z zakresu -100 do 100.
         * Do pliku "first_matrix.csv" zapisywana jest pierwsza macierz.
         * Do pliku "second_matrix.csv" zapisywana jest pierwsza macierz.
         * Tworzny jest pusty plik "result_matrix.csv".
         * Na samym końcu przywracana jest możliwość interakcji użytkownika ze wszystkimi kontrolkami w GUI.
         * sender - obiekt, który wysłał powiadomienie o zmianie swojego stanu
         * e - obiekt przechowujacy dodatkowe argumenty zdarzenia
         */
        private void buttonGenerate_Click(object sender, EventArgs e) {
            buttonGenerate.Enabled = false;
            numericWidthOfTheFirstMatix.Enabled = false;
            numericHeightOfTheFirstMatix.Enabled = false;
            numericWidthOfTheSecondMatix.Enabled = false;
            numericHeightOfTheSecondMatix.Enabled = false;

            realFirstMatrixWidthAndSecondMatrixHeight = (int)numericWidthOfTheFirstMatix.Value;
            realFirstMatrixHeight = (int)numericHeightOfTheFirstMatix.Value;
            realSecondMatrixWidth = (int)numericWidthOfTheSecondMatix.Value;

            int alignmentTo4 = 4 - (realFirstMatrixWidthAndSecondMatrixHeight % 4);

            if (alignmentTo4 == 4) {
                alignedTo4FirstMatrixWidthAndSecondMatrixHeight = realFirstMatrixWidthAndSecondMatrixHeight;
                alignmentTo4 = 0;

            } else {
                alignedTo4FirstMatrixWidthAndSecondMatrixHeight = realFirstMatrixWidthAndSecondMatrixHeight + alignmentTo4;

            }

            Random drawingNumbersObj = new Random();
            StreamWriter fileWriter = new StreamWriter("first_matrix.csv", false);

            if(listOfFirstMatrixRows.Count != 0) listOfFirstMatrixRows.Clear();

            for (int i = 0; i < realFirstMatrixHeight; i++) {
                int[] row = new int[alignedTo4FirstMatrixWidthAndSecondMatrixHeight];

                for (int j = 0; j < alignedTo4FirstMatrixWidthAndSecondMatrixHeight; j++) {
                    if (j >= alignedTo4FirstMatrixWidthAndSecondMatrixHeight - alignmentTo4) row[j] = 0;
                    else row[j] = drawingNumbersObj.Next(-100, 100);

                    if (j == alignedTo4FirstMatrixWidthAndSecondMatrixHeight - 1) fileWriter.Write(row[j]);
                    else fileWriter.Write(row[j] + ";");

                }
                listOfFirstMatrixRows.Add(row);
                fileWriter.WriteLine("");
                fileWriter.Flush();

            }

            fileWriter.Close();
            fileWriter = new StreamWriter("second_matrix.csv", false);

            if (listOfSecondMatrixRows.Count != 0)  listOfSecondMatrixRows.Clear();

            for (int i = 0; i < alignedTo4FirstMatrixWidthAndSecondMatrixHeight; i++) {
                int[] row = new int[realSecondMatrixWidth];

                for (int j = 0; j < realSecondMatrixWidth; j++) {
                    if (i >= alignedTo4FirstMatrixWidthAndSecondMatrixHeight - alignmentTo4) row[j] = 0;
                    else row[j] = drawingNumbersObj.Next(-100, 100);

                    if (j == realSecondMatrixWidth - 1) fileWriter.Write(row[j]);
                    else fileWriter.Write(row[j] + ";");

                }
                listOfSecondMatrixRows.Add(row);
                fileWriter.WriteLine("");
                fileWriter.Flush();

            }
                
            fileWriter.Close();

            try {
                FileStream fileStream = new FileStream("result_matrix.csv", FileMode.Truncate, FileAccess.ReadWrite);
                fileStream.Close();

            } catch (FileNotFoundException) {
                File.Create("result_matrix.csv").Dispose();

            }

            buttonStart.Enabled = true;
            buttonGenerate.Enabled = true;
            numericWidthOfTheFirstMatix.Enabled = true;
            numericHeightOfTheFirstMatix.Enabled = true;
            numericWidthOfTheSecondMatix.Enabled = true;
            numericHeightOfTheSecondMatix.Enabled = true;    

        }

        
    }

}
