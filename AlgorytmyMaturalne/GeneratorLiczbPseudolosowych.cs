using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class GenerowanieLiczbPsedolosowych
    {
        static long poprzedniaLiczbaPseudolosowa = DateTime.Now.Millisecond;
        static long przyrost;
        static long mnoznik;
        static long modul;
        static long maksymalnyZakres = 1000;
        public  GenerowanieLiczbPsedolosowych()
        {
            ZnajdywanieLiczbWzgledniePierwszych zlwp = new ZnajdywanieLiczbWzgledniePierwszych();
            RozkladanieNaCzynnikiPierwsze rncp = new RozkladanieNaCzynnikiPierwsze();
            modul = maksymalnyZakres + 1;
            przyrost = zlwp.ZwracaLiczbeWzgledniePierwszychDoLiczby(modul);     //przyrost musi byc liczba wsglednie pierwsza do modulu
            var listaCzynnikow = rncp.ZwracaListeCzynnikowPierwszychLiczbyV2(modul);        //rozklada modul na czynniki pierwsze
            mnoznik = ZwracaLiczbeKtoraDzieliSiePrzezKazdyZCzynikow(listaCzynnikow) + 1;   //aby nastepnie znalezc liczbe ktora dzieli sie przez kazdy czynnik
        }
        public long ZwracaLiczbePseudolosowa()
        {
            long liczbaPseudolosowa;
            liczbaPseudolosowa = (mnoznik * poprzedniaLiczbaPseudolosowa + przyrost) % modul;
            poprzedniaLiczbaPseudolosowa = liczbaPseudolosowa;                 //przekazuje wartosc liczby pseudolosowej, aby zostala ona zapisana w zmiennej statycznej w klasie
            return liczbaPseudolosowa;
        }
        public long ZwracaLiczbeKtoraDzieliSiePrzezKazdyZCzynikow(List<long> listaCzynnikow)
        {
            int liczba = 2;
            while (true)
            {
                for (int i = 0; i < listaCzynnikow.Count; i++)
                {
                    if (liczba % listaCzynnikow[i] != 0)
                    {
                        break;                          // liczba sie nie podzielia przez jakis czynniki czyli odpada - probujemy kolejna
                    }
                    return liczba;
                }
                liczba++;
            }
        }
        public void Test()
        {
            for (var i = 0; i < 10; i++)
            {
                var liczbaPseudolosowa = ZwracaLiczbePseudolosowa();
                Console.WriteLine(liczbaPseudolosowa);
            }
        }
        public void Test1()
        {
            
            var randGenerator = new Random();
            for (var i = 0; i < 10; i++)
            {
                var liczbaPseudolosowa = randGenerator.Next();
                Console.WriteLine(liczbaPseudolosowa);
            }
        }
        

    }
}