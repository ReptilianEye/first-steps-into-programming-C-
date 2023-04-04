using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class Zadanie1_etap3
    {
        //Dana jest liczba całkowita n. Proszę napisać program, który wylicza ostatnią niezerową cyfrę liczby n!.
        
        //Wejscie
        //W pierwszym i jedynym wierszu standardowego wejścia znajduje się jedna liczba całkowita n (0 ≤ n < 10^10).

        //Wyjscie
        //W pierwszym i jedynym wierszu standardowego wyjścia program powinien wypisać jedną cyfrę będącą rozwiązaniem.
        public long WczytajWejscie()
        {
            long liczba = Convert.ToInt64(Console.ReadLine());
            return liczba;
        }
        public long ZwracaOstatnieCyfrySilniBezZer(long liczba)
        {
            long wynik = 1;
            for (long i = 1; i <= liczba; i++)
            {
                long j = i;
                while (j % 10 == 0)
                    j = j / 10;
                wynik = wynik * j;
                while (wynik % 10 == 0)
                    wynik = wynik / 10;
                if(wynik > 100000000)
                    wynik = wynik % 100000000;
            }
            return wynik;
        }
        public int ZwracaOstaniaNiezerowaCyfreSilni(long liczba)
        {
            return (int)liczba % 10;
        }
        public void WypiszWyjscie(long wynik)
        {
            Console.WriteLine(wynik);
        }
        public void WykonajZadanie()
        {
            var liczba = WczytajWejscie();
            long silnia = ZwracaOstatnieCyfrySilniBezZer(liczba);
            int wynik = ZwracaOstaniaNiezerowaCyfreSilni(silnia);
            WypiszWyjscie(wynik);
        }
        public void Testy()
        {

        }
    }
}