using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class ObliczanieCalkowitegoPierwiastkaKwadratowego
    {
        //Napisz funkcje ktora wyznaczy wartosc pierwistak kwadratowego
        public int ZwracaWartoscPierwiastkaCalkowitegoKwadratowego(long liczba)
        {
            int i = 0;
            while (i * i <= liczba)
                i++;
            return i - 1;
        }
        public int ZwracaWartoscPierwiastkaCalkowitegoKwadratowegoV2(long liczba)

        {
            int i = 0;
            int a = 0;
            int r1 = 1;
            int r2 = 2;
            while (a <= liczba)
            {
                a = a + r1;         //algorytm obiera sie na obeserwacji roznic miedzy kwadratami poszeglnych liczb 
                r1 = r1 + r2;       //dokladnie wydlmaczenie tutaj: https://eduinf.waw.pl/inf/alg/001_search/0027.php - rozwiazanie 1
                i++;
            }
            return i - 1;
        }
        public int ZwracaWartoscPierwiastkaCalkowitegoKwadratowegoV3(int liczba)
        {
            double p = liczba;
            double poprzednieP = 0;
            while (Math.Floor(p) != Math.Floor(poprzednieP))        //zaokragla do dolu liczby calkowietej --> jesli liczby sa sobie rowne, konczy petle
            {
                poprzednieP = p;                                //algorytm wykorzystuje wzor na wartosc pierwiaska
                p = (p + liczba / p) / 2;                       //dokladne wytlumaczenie tutaj: https://eduinf.waw.pl/inf/alg/001_search/0027.php - rozwiazanie 2
            }
            p = Math.Floor(p);
            int wynik = Convert.ToInt32(p);
            return wynik;
        }
        public void Test()
        {
            for (int i = 0; i < 1000; i++)
                if (ZwracaWartoscPierwiastkaCalkowitegoKwadratowegoV3(i) != ZwracaWartoscPierwiastkaCalkowitegoKwadratowegoV2(i))
                    Console.WriteLine("Blad dla {0}", i);
        }
    }
}