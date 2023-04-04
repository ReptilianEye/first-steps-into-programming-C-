using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class Zadanie2_etap3
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
        public int GenerujePalindromy(long maxZakres, List<char> znaki)
        {
            List<string> listaPalindrow = new List<string>();
            foreach (var znak in znaki)
            {
                string palin = znak.ToString();
                if (CzyTaLiczbaJestLiczbaPierwszaOptymalnie(Convert.ToInt64(palin)))
                {
                    listaPalindrow.Add(palin);
                    GenerujePalindromyRekurencyjnie(maxZakres, palin, znaki, listaPalindrow);
                }
            }
            GenerujePalindromyRekurencyjnie(maxZakres, "", znaki, listaPalindrow);
            listaPalindrow.Sort();
            foreach (var palin in listaPalindrow)
                Console.WriteLine(palin);
            return listaPalindrow.Count;
        }

        public void GenerujePalindromyRekurencyjnie(long maxZakres, string srodek, List<char> znaki, List<string> listaPalindrow)
        {
            string palin = "";
            foreach (var znak in znaki)             
            {
                palin = znak + srodek + znak;          //dodajemy do dotychczasowego palindromu znaki z obu stron
                if (Convert.ToInt64(palin) > maxZakres || palin.Length > maxZakres.ToString().Length)       //sprawdzamy czy palindrom nie jest juz wiekszy od maksymalnego zakresu
                    continue;                                                                           //jesli tak to nie robimy nic z palindromem - kontynuujemy petle
                if (palin[0] != '0')                                                                    //jesli palindrom nie zaczyna sie od zera
                    if (CzyTaLiczbaJestLiczbaPierwszaOptymalnie(Convert.ToInt64(palin)))            //sprawdzamy czy jest on liczba pierwsza
                    {
                        listaPalindrow.Add(palin);                                                  //jesli tak, to dodajemy go do listy 
                        GenerujePalindromyRekurencyjnie(maxZakres, palin, znaki, listaPalindrow);   //i wolamy rekurencje aby uzyskac kolejny palindrom
                    }
            }
        }
        public Boolean CzyTaLiczbaJestLiczbaPierwszaOptymalnie(long liczba)
        {

            if (liczba < 2)
                return false;
            if (liczba == 2 || liczba == 3)
                return true;
            if (liczba % 2 == 0 || liczba % 3 == 0)
                return false;
            long i = 1;
            long wielokrotnosc = 6 * i;
            long pierwiastek = Convert.ToInt64(Math.Sqrt(liczba));
            while (wielokrotnosc - 1 <= pierwiastek)
            {
                if (liczba % (wielokrotnosc + 1) == 0 || liczba % (wielokrotnosc - 1) == 0)
                    return false;
                i++;
                wielokrotnosc = 6 * i;
            }
            return true;
        }

        public void WypiszWyjscie(long wynik)
        {
            Console.WriteLine(wynik);
        }
        public void WykonajZadanie()
        {
            var liczba = WczytajWejscie();
            List<char> znaki = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var wynik = GenerujePalindromy(liczba, znaki);
            //var wynik = generatePalindromes(liczba);
            WypiszWyjscie(wynik);
        }
        public void Testy()
        {

        }
    }
}