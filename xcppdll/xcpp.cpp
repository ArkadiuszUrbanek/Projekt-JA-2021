#include "pch.h"
#include "xcpp.h"


extern "C" {

	_declspec(dllexport) void __cdecl calculateSubmatrix(int* firstFlattenedSubmatrix, int firstFlattenedSubmatrixWidth, int firstFlattenedSubmatrixHeight, int* secondFlattenedSubmatrix, int secondFlattenedSubmatrixWidth, int secondFlattenedSubmatrixHeight, int* resultFlattenedSubmatrix) {
		for (int y1 = 0; y1 < firstFlattenedSubmatrixHeight; y1++) { //wiersze 1 podmacierzy
			for (int x2 = 0; x2 < secondFlattenedSubmatrixWidth; x2++) { //kolumny 2 macierzy
				for (int x1y2 = 0; x1y2 < firstFlattenedSubmatrixWidth; x1y2++) { //kolumny 1 podmacierzy oraz wiersze 2 macierzy
					resultFlattenedSubmatrix[y1 * secondFlattenedSubmatrixWidth + x2] += firstFlattenedSubmatrix[y1 * firstFlattenedSubmatrixWidth + x1y2] * secondFlattenedSubmatrix[x1y2 * secondFlattenedSubmatrixWidth + x2];

				}

			}

		}

	}
	
	/*_declspec(dllexport) void calculateSubmatrix(int* firstFlattenedSubmatrix, int firstFlattenedSubmatrixWidth, int firstFlattenedSubmatrixHeight, int* secondFlattenedSubmatrix, int secondFlattenedSubmatrixWidth, int secondFlattenedSubmatrixHeight, int* resultFlattenedSubmatrix) {

	}*/

}