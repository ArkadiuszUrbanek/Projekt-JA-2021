; Temat projektu zaliczeniowego z j�zyk�w asemblerowych: Mno�enie macierzy
; Autor: Arkadiusz Urbanek
; Kierunek: Informatyka
; Grupa: 2
; Semestr: 5
; Rok akademicki: 2021/2022
; Aktualna wersja programu v.1.0

; Procedura calculateSubmatrixMasm64
; 
; Mno�y podmacierz macierzy A z transponowan� macierz� B i zapisuje wyniki do macierzy wynikowej.
; 
; Do swoich oblicze� wykorzystuje 128 bitowe rejestry XMM: XMM0, XMM1, XMM2, XMM3 oraz 64 bitowe rejestry og�lnego przeznaczenia: RAX, RBX, RCX, RDX, RSI, RDI, R8, R9, R10, R11, R12.
; Warto�ci rejestr�w nieulotnych (RBX, RSI, RDI, R10, R11, R12) zostaj� od�o�one na stos na samym pocz�tku procedury, a nast�pnie przyr�cone po sko�czeniu oblicze�.
; 
; Nie zwraca �adnej warto�ci.
; Przyjmuje 6 argument�w. Pierwsze 4 argumenty s� przekazywane prze rejestry: RCX, RDX, R8, i R9. Pozosta�e 2 argumenty s� odk�adane na stos na pozycjach: [RSP + 40] oraz [RSP + 48].
; RCX: firstFlattenedSubmatrix - adres pierwszego elementu tablicy 1D reprezentuj�cej podmacierz macierzy A 
; RDX: firstFlattenedSubmatrixHeight - liczba wierszy podmacierzy macierzy A oraz liczba wierszy podmacierzy wynikowej
; R8: secondFlattenedAndTranposedMatrix - adres pierwszego elementu tablicy 1D reprezentuj�cej transponowan� macierz B
; R9: secondFlattenedAndTranposedMatrixHeight - liczba wierszy transponowanej macierzy B oraz liczba kolumn podmacierzy wynikowej
; [RSP + 40]: firstFlattenedSubmatrixWidthAndSecondFlattenedAndTransposedMatrixWidth - liczba kolumn macierzy A oraz liczba wierszy transponowanej macierzy B
; [RSP + 48]: resultFlattenedSubmatrix - adres pierwszego elementu tablicy 1D reprezentuj�cej podmacierz wynikow�
; 
; Wszystkie warto�ci znajduj�ce si� w tablicach s� traktowane jako DWORD'y ze znakiem. Oznacza to, �e ich dopuszczalny zakres wartosci wynosi od -2 147 483 648 do 2 147 483 647.
; Wszystkie pozosta�e zmienne przekazane do procedury s� traktowane jako DWORD'y bez znaku. Oznacza to, �e ich dopuszczalny zakres wartosci wynosi od 0 do 4 294 967 295.
; 
; W trakcie wykonywanie procedury zmian� moga ulec nast�pujace znaczniki(flags):
; ZR/ZF - Zero. Znacznik ustawiany w momencie, gdy wynikiem dzia�ania by�o 0.
; AC/AF - Auxiliary carry. Znacznik ustawiany, gdy nast�pi�o przeniesienie z bitu numer 3 na bit numer 4 lub gdy wystapi�a po�yczka z bitu numer 4.
; PE/PF - Parity flag. Znacznik, kt�ry jest ustawiany, gdy w wyniku wykonania dzia�ania liczba bit�w o warto�ci 1 jest parzysta.
; PL/SF - Sign. Przyjmuje warto�� 1, gdy najbardziej znacz�cy bit w otrzymanym wyniku jest r�wny 1.
; CY/CF - Carry. Znacznik ten zostaje ustawiony, gdy nast�pi�o przeniesienie z bitu najbardziej znaczacego poza dost�pny zakres zapisu lub gdy nast�pi�a po�yczka.

.CODE
calculateSubmatrixMasm64 PROC

    ; Prolog procedury - zachowanie nieulotnych rejestr�w na stosie
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
    MOV R12, [RSP + 88] ; Wczytaj liczb� kolumn pierwszej podmacierzy oraz liczb� kolumn drugiej transponowanej macierzy 
    MOV RBX, R8         ; Utworzenie kopii adresu secondFlattenedAndTranposedMatrix

	CMP RAX, RDX                 ; Por�wnaj warto�� licznika i z liczb� wierszy pierwszej podmacierzy 
    JGE most_outer_for_loop_done ; Je�eli licznik i >= firstFlattenedSubmatrixHeight to zako�cz p�tle

    most_outer_for_loop:
        


        CMP RSI, R9             ; Por�wnaj warto�� licznika j z liczb� wierszy drugiej transponowanej macierzy
        JGE outer_for_loop_done ; Je�eli licznik j >= secondFlattenedAndTranposedMatrixHeight to zako�cz p�tle
        MOV R8, RBX             ; Wczytanie adresu drugiej transponowanej macierzy
       

        outer_for_loop:
            


            CMP RDI, R12            ; Por�wnaj warto�� licznika k z liczb� kolumn pierwszej podmacierzy oraz liczb� kolumn drugiej transponowanej macierzy
            JGE inner_for_loop_done ; Je�eli licznik k >= firstFlattenedSubmatrixWidthAndSecondFlattenedAndTransposedMatrixWidth to zako�cz p�tle
            PXOR XMM2, XMM2         ; Wyzeruj rejestr XMM2

            inner_for_loop:
                

                MOVDQU XMM0, XMMWORD PTR[R11][RDI * 4] ; Wczytaj 4 DWORD'y z firstFlattenedSubmatrix do rejestru XMM0
                MOVDQU XMM1, XMMWORD PTR[R8][RDI * 4]  ; Wczytaj 4 DWORD'y z secondFlattenedAndTranposedMatrix do rejestru XMM1
                PMULLD XMM0, XMM1                      ; Wykonaj mno�enie DWORD'�w z rejestru XMM0 przez DWORD'y z rejestru XMM1
                PADDD XMM2, XMM0                       ; Wykonaj dodawanie DWORD'�w z rejestru XMM0 do DWORD'�w z rejestru XMM2


                ADD RDI, 4        ; Dodaj 4 do licznika k
                CMP RDI, R12      ; Por�wnaj warto�� licznika k z liczb� kolumn pierwszej podmacierzy oraz liczb� kolumn drugiej transponowanej macierzy
                JL inner_for_loop ; Je�eli licznik k < firstFlattenedSubmatrixWidthAndSecondFlattenedAndTransposedMatrixWidth to powt�rz p�tle

                ; Zsumuj wszystkie 4 DWORD'y znajduj�ce si� w rejestrze XMM2
                ; Suma b�dzie znajdowa�a si� na najm�odszych 32 bitach rejestru XMM2
                PSHUFD XMM3, XMM2, 4Eh
                PADDD XMM2, XMM3
                PSHUFLW XMM3, XMM2, 4Eh
                PADDD XMM2, XMM3
                MOVD ECX, XMM2 ; Wpisanie sumy 4 DWORD'�w do rejestru ECX

                MOV DWORD PTR[R10][RSI * 4], ECX ; Zapisz DWORD'a do podmacierzy wynikowej

                MOV RCX, R12 ; Wczytaj do rejestru RCX firstFlattenedSubmatrixWidthAndSecondFlattenedAndTransposedMatrixWidth
                SHL RCX, 2   ; Wykonaj przesuni�cie logiczne o 2 bity w lewo (mno�enie przez 4)
                ADD R8, RCX  ; Ustaw wska�nik R8 na kolejny wiersz drugiej transponowanej macierzy
                XOR RDI, RDI ; Wyzeruj licznik k 


            inner_for_loop_done:

            INC RSI           ; Inkrementuj licznik j
            CMP RSI, R9       ; Por�wnaj warto�� licznika j z liczb� wierszy drugiej transponowanej macierzy
            JL outer_for_loop ; Je�eli licznik j < secondFlattenedAndTranposedMatrixHeight to powt�rz p�tle
            
            MOV RCX, R9  ; Wczytaj do rejestru RCX secondFlattenedAndTranposedMatrixHeight
            SHL RCX, 2   ; Wykonaj przesuni�cie logiczne o 2 bity w lewo (mno�enie przez 4)
            ADD R10, RCX ; Ustaw wska�nik R10 na kolejny wiersz podmacierzy wynikowej

            
            MOV RCX, R12 ; Wczytaj do rejestru RCX firstFlattenedSubmatrixWidthAndSecondFlattenedAndTransposedMatrixWidth
            SHL RCX, 2   ; Wykonaj przesuni�cie logiczne o 2 bity w lewo (mno�enie przez 4)
            ADD R11, RCX ; Ustaw wska�nik R11 na kolejny wiersz pierwszej podmacierzy
            XOR RSI, RSI ; Wyzeruj licznik j

        outer_for_loop_done:

        INC RAX                ; Inkrementuj licznik i
        CMP RAX, RDX           ; Por�wnaj warto�� licznika i z liczb� wierszy pierwszej podmacierzy    
        JL most_outer_for_loop ; Je�eli licznik i < firstFlattenedSubmatrixHeight to powt�rz p�tle
        XOR RAX, RAX           ; Wyzeruj licznik i

    most_outer_for_loop_done:


    ; Epilog procedury - odtworzenie nieulotnych rejestr�w
    POP R12
    POP R11
    POP R10
    POP RDI
    POP RSI
    POP RBX
    
    RET ; Powr�t z procedury
calculateSubmatrixMasm64 ENDP
END