using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class ObliczaniePi
    {
        //Napisz funkcje ktora wyznaczy pi z uzyciem ciagu

        public double ObliczPiZeWzoruLeibniza()
        {
            double wynik = 0;
            for (long i = 1; i < 10000000; i++)
            {
                if (i % 2 != 0)
                    wynik = wynik + (double) (1 / (2 * i - 1));
                else
                    wynik = wynik - (double) (1 / (2 * i - 1));
            }
            return wynik * 4;

        }
        public void Test()
        {
            var wynik = ObliczPiZeWzoruLeibniza();
            Console.WriteLine("wynik = {0}, dokladnosc = {1}",wynik, Math.Abs(wynik=Math.PI));
        }
    }
}