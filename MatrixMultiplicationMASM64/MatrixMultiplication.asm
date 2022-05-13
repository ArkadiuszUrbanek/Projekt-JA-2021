; Temat projektu zaliczeniowego z jêzyków asemblerowych: Mno¿enie macierzy
; Autor: Arkadiusz Urbanek
; Kierunek: Informatyka
; Grupa: 2
; Semestr: 5
; Rok akademicki: 2021/2022
; Aktualna wersja programu v.1.0

; Procedura calculateSubmatrixMasm64
; 
; Mno¿y podmacierz macierzy A z transponowan¹ macierz¹ B i zapisuje wyniki do macierzy wynikowej.
; 
; Do swoich obliczeñ wykorzystuje 128 bitowe rejestry XMM: XMM0, XMM1, XMM2, XMM3 oraz 64 bitowe rejestry ogólnego przeznaczenia: RAX, RBX, RCX, RDX, RSI, RDI, R8, R9, R10, R11, R12.
; Wartoœci rejestrów nieulotnych (RBX, RSI, RDI, R10, R11, R12) zostaj¹ od³o¿one na stos na samym pocz¹tku procedury, a nastêpnie przyrócone po skoñczeniu obliczeñ.
; 
; Nie zwraca ¿adnej wartoœci.
; Przyjmuje 6 argumentów. Pierwsze 4 argumenty s¹ przekazywane prze rejestry: RCX, RDX, R8, i R9. Pozosta³e 2 argumenty s¹ odk³adane na stos na pozycjach: [RSP + 40] oraz [RSP + 48].
; RCX: firstFlattenedSubmatrix - adres pierwszego elementu tablicy 1D reprezentuj¹cej podmacierz macierzy A 
; RDX: firstFlattenedSubmatrixHeight - liczba wierszy podmacierzy macierzy A oraz liczba wierszy podmacierzy wynikowej
; R8: secondFlattenedAndTranposedMatrix - adres pierwszego elementu tablicy 1D reprezentuj¹cej transponowan¹ macierz B
; R9: secondFlattenedAndTranposedMatrixHeight - liczba wierszy transponowanej macierzy B oraz liczba kolumn podmacierzy wynikowej
; [RSP + 40]: firstFlattenedSubmatrixWidthAndSecondFlattenedAndTransposedMatrixWidth - liczba kolumn macierzy A oraz liczba wierszy transponowanej macierzy B
; [RSP + 48]: resultFlattenedSubmatrix - adres pierwszego elementu tablicy 1D reprezentuj¹cej podmacierz wynikow¹
; 
; Wszystkie wartoœci znajduj¹ce siê w tablicach s¹ traktowane jako DWORD'y ze znakiem. Oznacza to, ¿e ich dopuszczalny zakres wartosci wynosi od -2 147 483 648 do 2 147 483 647.
; Wszystkie pozosta³e zmienne przekazane do procedury s¹ traktowane jako DWORD'y bez znaku. Oznacza to, ¿e ich dopuszczalny zakres wartosci wynosi od 0 do 4 294 967 295.
; 
; W trakcie wykonywanie procedury zmian¹ moga ulec nastêpujace znaczniki(flags):
; ZR/ZF - Zero. Znacznik ustawiany w momencie, gdy wynikiem dzia³ania by³o 0.
; AC/AF - Auxiliary carry. Znacznik ustawiany, gdy nast¹pi³o przeniesienie z bitu numer 3 na bit numer 4 lub gdy wystapi³a po¿yczka z bitu numer 4.
; PE/PF - Parity flag. Znacznik, który jest ustawiany, gdy w wyniku wykonania dzia³ania liczba bitów o wartoœci 1 jest parzysta.
; PL/SF - Sign. Przyjmuje wartoœæ 1, gdy najbardziej znacz¹cy bit w otrzymanym wyniku jest równy 1.
; CY/CF - Carry. Znacznik ten zostaje ustawiony, gdy nast¹pi³o przeniesienie z bitu najbardziej znaczacego poza dostêpny zakres zapisu lub gdy nast¹pi³a po¿yczka.

.CODE
calculateSubmatrixMasm64 PROC

    ; Prolog procedury - zachowanie nieulotnych rejestrów na stosie
    PUSH RBX
    PUSH RSI
    PUSH RDI
    PUSH R10
    PUSH R11
    PUSH R12

    XOR RAX, RAX ; Wyzerowanie licznika i
    XOR RSI, RSI ; Wyzerowanie licznika j
    XOR RDI, RDI ; Wyzerowanie licznika k


    MOV R11, RCX ; Wczytaj adres pierwszej podmacierzy firstFlattenedSubmatrix
    
    MOV R10, [RSP + 96] ; Wczytaj adres podmacierzy wynikowej
    MOV R12, [RSP + 88] ; Wczytaj liczbê kolumn pierwszej podmacierzy oraz liczbê kolumn drugiej transponowanej macierzy 
    MOV RBX, R8         ; Utworzenie kopii adresu secondFlattenedAndTranposedMatrix

	CMP RAX, RDX                 ; Porównaj wartoœæ licznika i z liczb¹ wierszy pierwszej podmacierzy 
    JGE most_outer_for_loop_done ; Je¿eli licznik i >= firstFlattenedSubmatrixHeight to zakoñcz pêtle

    most_outer_for_loop:
        


        CMP RSI, R9             ; Porównaj wartoœæ licznika j z liczb¹ wierszy drugiej transponowanej macierzy
        JGE outer_for_loop_done ; Je¿eli licznik j >= secondFlattenedAndTranposedMatrixHeight to zakoñcz pêtle
        MOV R8, RBX             ; Wczytanie adresu drugiej transponowanej macierzy
       

        outer_for_loop:
            


            CMP RDI, R12            ; Porównaj wartoœæ licznika k z liczb¹ kolumn pierwszej podmacierzy oraz liczb¹ kolumn drugiej transponowanej macierzy
            JGE inner_for_loop_done ; Je¿eli licznik k >= firstFlattenedSubmatrixWidthAndSecondFlattenedAndTransposedMatrixWidth to zakoñcz pêtle
            PXOR XMM2, XMM2         ; Wyzeruj rejestr XMM2

            inner_for_loop:
                

                MOVDQU XMM0, XMMWORD PTR[R11][RDI * 4] ; Wczytaj 4 DWORD'y z firstFlattenedSubmatrix do rejestru XMM0
                MOVDQU XMM1, XMMWORD PTR[R8][RDI * 4]  ; Wczytaj 4 DWORD'y z secondFlattenedAndTranposedMatrix do rejestru XMM1
                PMULLD XMM0, XMM1                      ; Wykonaj mno¿enie DWORD'ów z rejestru XMM0 przez DWORD'y z rejestru XMM1
                PADDD XMM2, XMM0                       ; Wykonaj dodawanie DWORD'ów z rejestru XMM0 do DWORD'ów z rejestru XMM2


                ADD RDI, 4        ; Dodaj 4 do licznika k
                CMP RDI, R12      ; Porównaj wartoœæ licznika k z liczb¹ kolumn pierwszej podmacierzy oraz liczb¹ kolumn drugiej transponowanej macierzy
                JL inner_for_loop ; Je¿eli licznik k < firstFlattenedSubmatrixWidthAndSecondFlattenedAndTransposedMatrixWidth to powtórz pêtle

                ; Zsumuj wszystkie 4 DWORD'y znajduj¹ce siê w rejestrze XMM2
                ; Suma bêdzie znajdowa³a siê na najm³odszych 32 bitach rejestru XMM2
                PSHUFD XMM3, XMM2, 4Eh
                PADDD XMM2, XMM3
                PSHUFLW XMM3, XMM2, 4Eh
                PADDD XMM2, XMM3
                MOVD ECX, XMM2 ; Wpisanie sumy 4 DWORD'ów do rejestru ECX

                MOV DWORD PTR[R10][RSI * 4], ECX ; Zapisz DWORD'a do podmacierzy wynikowej

                MOV RCX, R12 ; Wczytaj do rejestru RCX firstFlattenedSubmatrixWidthAndSecondFlattenedAndTransposedMatrixWidth
                SHL RCX, 2   ; Wykonaj przesuniêcie logiczne o 2 bity w lewo (mno¿enie przez 4)
                ADD R8, RCX  ; Ustaw wskaŸnik R8 na kolejny wiersz drugiej transponowanej macierzy
                XOR RDI, RDI ; Wyzeruj licznik k 


            inner_for_loop_done:

            INC RSI           ; Inkrementuj licznik j
            CMP RSI, R9       ; Porównaj wartoœæ licznika j z liczb¹ wierszy drugiej transponowanej macierzy
            JL outer_for_loop ; Je¿eli licznik j < secondFlattenedAndTranposedMatrixHeight to powtórz pêtle
            
            MOV RCX, R9  ; Wczytaj do rejestru RCX secondFlattenedAndTranposedMatrixHeight
            SHL RCX, 2   ; Wykonaj przesuniêcie logiczne o 2 bity w lewo (mno¿enie przez 4)
            ADD R10, RCX ; Ustaw wskaŸnik R10 na kolejny wiersz podmacierzy wynikowej

            
            MOV RCX, R12 ; Wczytaj do rejestru RCX firstFlattenedSubmatrixWidthAndSecondFlattenedAndTransposedMatrixWidth
            SHL RCX, 2   ; Wykonaj przesuniêcie logiczne o 2 bity w lewo (mno¿enie przez 4)
            ADD R11, RCX ; Ustaw wskaŸnik R11 na kolejny wiersz pierwszej podmacierzy
            XOR RSI, RSI ; Wyzeruj licznik j

        outer_for_loop_done:

        INC RAX                ; Inkrementuj licznik i
        CMP RAX, RDX           ; Porównaj wartoœæ licznika i z liczb¹ wierszy pierwszej podmacierzy    
        JL most_outer_for_loop ; Je¿eli licznik i < firstFlattenedSubmatrixHeight to powtórz pêtle
        XOR RAX, RAX           ; Wyzeruj licznik i

    most_outer_for_loop_done:


    ; Epilog procedury - odtworzenie nieulotnych rejestrów
    POP R12
    POP R11
    POP R10
    POP RDI
    POP RSI
    POP RBX
    
    RET ; Powrót z procedury
calculateSubmatrixMasm64 ENDP
END