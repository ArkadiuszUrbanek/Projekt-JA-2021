/* Temat projektu zaliczeniowego z j�zyk�w asemblerowych: Mno�enie macierzy
 * Autor: Arkadiusz Urbanek
 * Kierunek: Informatyka
 * Grupa: 2
 * Semestr: 5
 * Rok akademicki: 2021/2022
 * Aktualna wersja programu v.1.0 */

extern "C" {
	
	/*Funkcja calculateSubmatrixCpp
	* 
	* Mno�y podmacierz macierzy A z transponowan� macierz� B i zapisuje wyniki do macierzy wynikowej. 
	* 
	* Nie zwraca �adnej warto�ci.
	* 
	* Przyjmuje 6 argument�w.
	* firstFlattenedSubmatrix - tablica 1D reprezentuj�c� podmacierz macierzy A 
	* firstFlattenedSubmatrixHeight - liczba wierszy podmacierzy macierzy A oraz liczba wierszy podmacierzy wynikowej
	* secondFlattenedAndTranposedMatrix - tablica 1D reprezentuj�c� transponowan� macierz B
	* secondFlattenedAndTranposedMatrixHeight - liczba wierszy transponowanej macierzy B oraz liczba kolumn podmacierzy wynikowej
	* firstFlattenedSubmatrixWidthAndSecondFlattenedAndTransposedMatrixWidth - liczba kolumn macierzy A oraz liczba wierszy transponowanej macierzy B
	* resultFlattenedSubmatrix - tablica 1D reprezentuj�ca podmacierz wynikow� 
	* 
	* Wszystkie warto�ci znajduj�ce si� w tablicach s� integerami. 
	* Wszystkie pozosta�e zmienne przekazane do funkcji r�wnie� s� integerami.
	* Oznacza to, �e ich dopuszczalny zakres wartosci wszystkich przekazanych zmiennych wynosi wed�ug specyfikacji C++ co najmniej od -2 147 483 648 do 2 147 483 647 co odpowiada 32 bitom.
	*/
	_declspec(dllexport) void calculateSubmatrixCpp(int* firstFlattenedSubmatrix,
													int firstFlattenedSubmatrixHeight,
													int* secondFlattenedAndTranposedMatrix,
													int secondFlattenedAndTranposedMatrixHeight,
													int firstFlattenedSubmatrixWidthAndSecondFlattenedAndTransposedMatrixWidth,
													int* resultFlattenedSubmatrix) {

		for (int i = 0; i < firstFlattenedSubmatrixHeight; i++) { //wiersze 1 podmacierzy
			for (int j = 0; j < secondFlattenedAndTranposedMatrixHeight; j++) { //wiersze 2 transponowanej macierzy
				for (int k = 0; k < firstFlattenedSubmatrixWidthAndSecondFlattenedAndTransposedMatrixWidth; k++) { //kolumny 1 podmacierzy oraz kolumny 2 transponowanej macierzy
					resultFlattenedSubmatrix[i * secondFlattenedAndTranposedMatrixHeight + j] += 
						firstFlattenedSubmatrix[i * firstFlattenedSubmatrixWidthAndSecondFlattenedAndTransposedMatrixWidth + k] * 
							secondFlattenedAndTranposedMatrix[j * firstFlattenedSubmatrixWidthAndSecondFlattenedAndTransposedMatrixWidth + k];

				}

			}

		}

	}

}
