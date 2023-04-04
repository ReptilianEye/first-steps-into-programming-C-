using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class Program
    {
        static void Main(string[] args)
        {
            TestyKlas t = new TestyKlas();
            Zadanie1 z1 = new Zadanie1();
            Zadanie2 z2 = new Zadanie2();
            Zadanie5 z5 = new Zadanie5();

            ZadaniaZeStrony s = new ZadaniaZeStrony();
            Rekurencje r = new Rekurencje();
            RozwiazaniaZadan rz = new RozwiazaniaZadan();
            ZnajdzBrakujaceDomino zd = new ZnajdzBrakujaceDomino();
            ZnajdzSlowoZSzyfru zs = new ZnajdzSlowoZSzyfru();
            PiekloCzyNiebo pcn = new PiekloCzyNiebo();
            LiczbyPierwsze lp = new LiczbyPierwsze();



            //Algorytmy maturalne
            RozkladanieNaCzynnikiPierwsze rncp = new RozkladanieNaCzynnikiPierwsze();
            WyznaczanieNajwiekszegoWspolnegoDzielnika nwd = new WyznaczanieNajwiekszegoWspolnegoDzielnika();
            ZnajdywanieLiczbWzgledniePierwszych zlwp = new ZnajdywanieLiczbWzgledniePierwszych();
            ObliczaniePi opi = new ObliczaniePi();
            ObliczaniePierwiastkaKwadratowego opk = new ObliczaniePierwiastkaKwadratowego();
            ZnajdywanieMiejscaZerowego zmz = new ZnajdywanieMiejscaZerowego();
            SprawdzanieCzySlowaSaAnagramami scssa = new SprawdzanieCzySlowaSaAnagramami();
            SprawdzCzyPodciagUkrytyJestWCiagu cpjuwc = new SprawdzCzyPodciagUkrytyJestWCiagu();
            SzyfrCezara sc = new SzyfrCezara();
            SzyfrPrzestawieniowy sp = new SzyfrPrzestawieniowy();
            ZnajdywanieLiczbyWCiagu zlwc = new ZnajdywanieLiczbyWCiagu();
            PotegowanieSzybkie ps = new PotegowanieSzybkie();
            ZnajdywanieLiczbPierwszychWPrzedziale zlpwp = new ZnajdywanieLiczbPierwszychWPrzedziale();
            Sortowanie sort = new Sortowanie();
            GenerowanieLiczbPsedolosowych glps = new GenerowanieLiczbPsedolosowych();
            PrzeliczanieZZapisuFibonacciego pzfnd = new PrzeliczanieZZapisuFibonacciego();
            ObliczanieCalkowitegoPierwiastkaKwadratowego ocpk = new ObliczanieCalkowitegoPierwiastkaKwadratowego();
            ZnajdywanieDomianta zdwc = new ZnajdywanieDomianta();
            ZnajdywanieKNajwiekszego zkn = new ZnajdywanieKNajwiekszego();
            ZliczanieSlowWTekscie zswt = new ZliczanieSlowWTekscie();
            ZnajdywanieNajdluzszegoWspolnegoLancucha znwl = new ZnajdywanieNajdluzszegoWspolnegoLancucha();
            Zadanie1_etap3 z1e3 = new Zadanie1_etap3();
            Zadanie2_etap3 z2e3 = new Zadanie2_etap3();
            Zadanie6_etap3 z6e3 = new Zadanie6_etap3();
            Permutacje permutacje = new Permutacje();
            ZnajdywanieLiczbyNieZCiaguFibonacciego zlnzcf = new ZnajdywanieLiczbyNieZCiaguFibonacciego();
            List<long> listaPierwszych = new List<long>();
            Zadanie2Diament z2d = new Zadanie2Diament();
            Solution sol = new Solution();
            int[] array1 = new int[] { 5, 4, -3, 2, 0, 1, -1, 0, 2, -3, 4, -5 };
            int res = sol.solution(array1);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
