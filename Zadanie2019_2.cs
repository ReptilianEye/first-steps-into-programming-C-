using System;
using System.Collections;
using nauka_programowania;
using System.Collections.Generic;
namespace nauka_programowania
{
    class Zadanie2
    {
        public Dictionary<long, long> ZwracaLiczbyPierwszeZPrzedzialuV2(long granicaPrzedzialu)
        {
            bool[] PrzedzialLiczb = new bool[granicaPrzedzialu + 1];
            long ostatniaDoSprawdzenia = (long)Math.Sqrt(granicaPrzedzialu);
            for (long wskaznik = 2; wskaznik <= ostatniaDoSprawdzenia; wskaznik++)
            {
                if (!PrzedzialLiczb[wskaznik])
                {
                    long wielokrotonosc = wskaznik * 2;
                    while (wielokrotonosc <= granicaPrzedzialu)
                    {
                        PrzedzialLiczb[wielokrotonosc] = true;
                        wielokrotonosc = wielokrotonosc + wskaznik;
                    }
                }
            }
            Dictionary<long, long> Pierwsze = new Dictionary<long, long>();
            for (long i = 2; i < PrzedzialLiczb.LongLength; i++)
                if (!PrzedzialLiczb[i])
                    Pierwsze.Add(i, i);
            return Pierwsze;
        }
        public void SzukajLiczbRekurencyjnie(int wiersz, int kolumna, string DotychczasoweCyfry, List<string> TablicaCyfr, Dictionary<long, long> ZnalezioneLiczby)
        {
            if (wiersz < TablicaCyfr.Count - 1)   // czy mozna isc w dol
                SzukajLiczbRekurencyjnie(wiersz + 1, 0, DotychczasoweCyfry + TablicaCyfr[wiersz][kolumna], TablicaCyfr, ZnalezioneLiczby);
            if (wiersz == TablicaCyfr.Count - 1) //czy jestesmy w ostatnim wierszu
            {
                var znalezionaLiczba = DotychczasoweCyfry + TablicaCyfr[wiersz][kolumna];
                long NowaLiczba = Convert.ToInt64(znalezionaLiczba);
                if (!ZnalezioneLiczby.ContainsKey(NowaLiczba))
                    ZnalezioneLiczby.Add(NowaLiczba, NowaLiczba);
            }
            if (kolumna < TablicaCyfr[0].Length - 1) //czy mozna isc w prawo
            {
                SzukajLiczbRekurencyjnie(wiersz, kolumna + 1, DotychczasoweCyfry, TablicaCyfr, ZnalezioneLiczby);
            }
            return;
        }

        public int PoliczLiczbyPierwszeWTablicy(List<string> tablicaCyfr)
        {
            // znajdowanie wszystkich liczb ukrytych w cyfrach
            Dictionary<long, long> ZnalezioneLiczby = new Dictionary<long, long>();
            SzukajLiczbRekurencyjnie(0, 0, "", tablicaCyfr, ZnalezioneLiczby);
            // sprawdzenie ktore z liczb znalezionych wczesniej sa pierwsze
            Dictionary<long, long> LiczbyPierwszeZZakresu = ZwracaLiczbyPierwszeZPrzedzialuV2(100000000);
            int LicznikLiczbPierwszych = 0;
            foreach (var LiczbaDoSprawdzenia in ZnalezioneLiczby)
                if (LiczbyPierwszeZZakresu.ContainsKey(LiczbaDoSprawdzenia.Key))
                    LicznikLiczbPierwszych++;
            return LicznikLiczbPierwszych;
        }
        public List<string> WczytajWejscie()
        {
            List<string> tablica = new List<string>();
            int R = Convert.ToInt32(Console.ReadLine());
            int C = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < R; i++)
            {
                string s = Console.ReadLine();
                tablica.Add(s);
            }
            return tablica;
        }


        public List<string> WczytajWejscieV2()
        {
            List<string> tablica = new List<string>();
            tablica.Add("5943");
            tablica.Add("1728");
            tablica.Add("3451");
            return tablica;
        }
        public List<string> WczytajWejscieV3()
        {
            List<string> tablica = new List<string>();
            tablica.Add("5943234");
            tablica.Add("5943234");
            tablica.Add("1594334");
            tablica.Add("5243229");
            tablica.Add("5943284");
            tablica.Add("5946323");
            tablica.Add("5943734");
            return tablica;
        }
        public void WypiszWyjscie(int ilosc)
        {
            Console.WriteLine(ilosc);
        }

        public void WykonajZadanie()
        {
            var ciagi = WczytajWejscieV3();
            var wynik = PoliczLiczbyPierwszeWTablicy(ciagi);
            WypiszWyjscie(wynik);
        }
    }
}
