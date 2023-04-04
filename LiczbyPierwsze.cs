using System;
using System.Collections;
using System.Collections.Generic;
namespace nauka_programowania
{
    class LiczbyPierwsze
    {
        //Napisać funkcje która bierze liczbę całkowitą i zwraca informacje czy ta liczba jest liczbą pierwszą.
        public Boolean CzyTaLiczbaJestLiczbaPierwsza(long liczba)
        {

            if (liczba < 2)
                return false;
            int i = 2;
            while (liczba > i)
            {
                if (liczba % i == 0)
                    return false;
                i++;
            }
            return true;
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
        //Napisac funkcje ktora bierze liczbe calkowita "x" a nastepnie zwraca x kolejnych liczb pierwszych zaczynajac od pierwszej
        public ArrayList ZwrocXLiczbPierwszych(long WspX)
        {
            ArrayList pierwsze = new ArrayList();
            long i = 0;
            while (WspX > 0)
            {
                if (CzyTaLiczbaJestLiczbaPierwszaOptymalnie(i))
                {
                    pierwsze.Add(i);
                    WspX--;
                }
                i++;
            }
            return pierwsze;
        }
        //Napisac funkcje ktora bierze liczbe calkowita "x" a nastepnie zwraca x liczb pierwzych zaczynajac od tej ktora funkcja bierze jako druga
        public ArrayList ZwrocXLiczbPierwszychZaczynajacOdWybranej(long IloscLiczbPierwszychDoZwrocenia, long ZaczynajacOd)
        {
            ArrayList pierwsze = new ArrayList();
            long probowanaLiczba = ZaczynajacOd;
            while (pierwsze.Count < IloscLiczbPierwszychDoZwrocenia)
            {
                if (CzyTaLiczbaJestLiczbaPierwszaOptymalnie(probowanaLiczba))
                    pierwsze.Add(probowanaLiczba);
                probowanaLiczba++;
            }
            return pierwsze;
        }
        //metoda chinska
        public Boolean CzyTaLiczbaJestLiczbaPierwszaMetodaChinska(long liczba)
        {
            long wynik = ZwracaWartoscPotegiIModulo(2, liczba, liczba);
            if (wynik == 2)
                return true;
            else
                return false;
        }
        
        public long ZwracaWartoscPotegiIModulo(long podstawaPotegi, long wykladnikPotegi, long modulo)
        {
            long p = podstawaPotegi;
            long wynik = 1;
            long maska = 1;
            while (maska != 0)
            {
                if ((wykladnikPotegi & maska) != 0)
                    wynik = (wynik * p) % modulo;
                p = p * p % modulo;
                maska = maska << 1;
            }
            return wynik;
        }

        
        public void Testy()
        {
            LiczbyPierwsze zad = new LiczbyPierwsze();

            Console.WriteLine("Podaj ilosc liczb pierwszych ktore mam wyswietlic");
            long IloscLiczbPierwszych = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("A teraz liczbe, od ktorej mam zaczac");
            long ZaczynajacOd = Convert.ToInt64(Console.ReadLine());

            ArrayList LiczbyPierwsze = zad.ZwrocXLiczbPierwszychZaczynajacOdWybranej(IloscLiczbPierwszych, ZaczynajacOd);

            Console.WriteLine("Oto " + IloscLiczbPierwszych + " liczb pierwszych zaczynajac od " + ZaczynajacOd);
            foreach (long element in LiczbyPierwsze)
            {
                Console.WriteLine(element);
            }
            Console.ReadLine();
        }
        public void Testy2()
        {
            LiczbyPierwsze zad = new LiczbyPierwsze();
            Console.WriteLine("Podaj liczbe a ja powiem ci czy jest ona liczba pierwsza.");
            long liczba = Convert.ToInt64(Console.ReadLine());
            bool TakCzyNie = zad.CzyTaLiczbaJestLiczbaPierwszaOptymalnie(liczba);
            Console.WriteLine(TakCzyNie);
            Console.ReadLine();
        }
        public void Testy3()
        {
            List<long> lista = new List<long>();
            lista = ZnajdywanieLiczbPierwszychWPrzedziale.ZwracaLiczbyPierwszeZPrzedzialuSitemEratostenesaV2((long)(Math.Pow(10, 5)));
            for (long i = 2; i < (long)(Math.Pow(10, 3)); i++)
                if (CzyTaLiczbaJestLiczbaPierwszaMetodaChinska(i) != lista.Contains(i))
                    Console.WriteLine("Nie dziala dla {0}", i);
        }
    }
}


