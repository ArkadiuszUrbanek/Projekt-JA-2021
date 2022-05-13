using System;
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
    static class Program {

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }

    }

}
