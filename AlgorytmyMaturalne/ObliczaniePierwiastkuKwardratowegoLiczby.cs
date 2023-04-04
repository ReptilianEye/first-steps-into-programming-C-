using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class ObliczaniePierwiastkaKwadratowego
    {
        //Napisz funkcje ktora wyznaczy wartosc pierwistak kwadratowego
        public double ZwracaWartoscPierwiaskaKwadratowego(double liczba, double dokladnosc = 0.00000001)
        {
            double a = 1;
            double b = liczba;
            while (Math.Abs(a - b) > dokladnosc)
            {
                b = liczba / a;
                a = (a + b) / 2;
            }
            return a;
        }

        public void Test()
        {
             for (double i = 0.1; i < 10000; i = i + 0.01)
                if (Math.Abs(ZwracaWartoscPierwiaskaKwadratowego(i) - Math.Sqrt(i)) > 0.00000001)
                    Console.WriteLine("blad dla {0}", i);
        }
    }
}