using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class RozkladanieNaCzynnikiPierwsze
    {
        //napisz funcje ktora bierze liczbe calkowita do 10 * 10^10 i wzraca liste jej czynnikow pierwszych
        public List<long> ZwracaListeCzynnikowPierwszychLiczby(long liczba)
        {
            List<long> listaCzynnikow = new List<long>();
            long g = (long)Math.Sqrt(liczba);
            for (int i = 2; i <= g; i++)
                while (liczba % i == 0)
                {
                    listaCzynnikow.Add(i);
                    liczba = liczba / i;
                }
            if (liczba > 1)                         //jesli liczba jest pierwsza (nie zostala podzielona wczesniej aby miec wartosc 1 na koniec)
                listaCzynnikow.Add(liczba);         //dodajemy ja do listy czynnikow bo oznacza to ze jest liczba pierwsza
            return listaCzynnikow;
        }
        public List<long> ZwracaListeCzynnikowPierwszychLiczbyV2(long liczba)
        {
            List<long> listaCzynnikow = new List<long>();
            long g = (long)Math.Sqrt(liczba);
            int k = 1;
            for (int i = 2; i <= 3; i++)    //oskubanie z 2 i 3
                while (liczba % i == 0)
                {
                    listaCzynnikow.Add(i);
                    liczba = liczba / i;
                }
            int wielokrotnosc = 6 * k;
            while (liczba > 1 && wielokrotnosc < g) //sprawdza czy liczba "oskubana" jest wieksza od 1 - czy warto jeszcza ja sprawdzac
            {
                if (liczba % (wielokrotnosc + 1) == 0)      //jesli liczba sie dzieli, dodaje do listy czynnikow wartosc wieloktonosci +1
                {
                    liczba = liczba / (wielokrotnosc + 1);
                    listaCzynnikow.Add(wielokrotnosc + 1);
                }
                if (liczba % (wielokrotnosc - 1) == 0)      //jesli liczba sie dzieli, dodaje do listy czynnikow wartosc wieloktonosci -1
                {
                    liczba = liczba / (wielokrotnosc - 1);
                    listaCzynnikow.Add(wielokrotnosc - 1);
                }
                k++;                                        //zwieksza pomocnicza "k"
                wielokrotnosc = wielokrotnosc * k;          //i oblicza nowa wielokrotnosc
            }
            if (liczba > 1)                             //jesli liczba jest pierwsza (nie zostala podzielona wczesniej aby miec wartosc 1 na koniec)
                listaCzynnikow.Add(liczba);             //dodajemy ja do listy czynnikow bo oznacza to ze jest liczba pierwsza
            return listaCzynnikow;
        }
        public List<long> ZwracaListeCzynnikowPierwszychLiczbyMetodaFermata(long liczba)
        {

            List<long> listaCzynnikow = new List<long>();
            while (liczba % 2 == 0)
            {
                listaCzynnikow.Add(2);
                liczba = liczba / 2;
            }
            long x = (long)Math.Ceiling(Math.Sqrt(liczba));
            long z;
            long y;
            do
            {
                z = x * x - liczba;
                y = (long)Math.Ceiling(Math.Sqrt(z));
                if (z == y * y)
                {
                    long m = x + y;
                    long n = x - y;
                    if (n != 1)
                    {
                        listaCzynnikow.AddRange(ZwracaListeCzynnikowPierwszychLiczbyMetodaFermata(m));
                        listaCzynnikow.AddRange(ZwracaListeCzynnikowPierwszychLiczbyMetodaFermata(n));
                        return listaCzynnikow;
                    }
                    else
                    {
                        listaCzynnikow.Add(liczba);
                        return listaCzynnikow;
                    }
                }
                else
                    x++;
            } while (x + y < liczba);
            listaCzynnikow.Add(liczba);
            return listaCzynnikow;

        }
        public void Test()
        {
            for (long liczba = 1; liczba < 10000; liczba++)
            {
                var listaWynikow = ZwracaListeCzynnikowPierwszychLiczbyMetodaFermata(liczba);
                long pierwotnaLiczba = 1;
                foreach (var wynik in listaWynikow)
                    pierwotnaLiczba = pierwotnaLiczba * wynik;
                if (pierwotnaLiczba != liczba)
                    Console.WriteLine("zleeee dla liczby {0}", liczba);
            }
        }
    }
}