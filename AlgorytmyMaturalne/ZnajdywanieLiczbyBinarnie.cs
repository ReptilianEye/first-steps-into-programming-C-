using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class ZnajdywanieLiczbyWCiagu
    {
        public int ZwracaPozycjeLiczbyPoWyszukaniuBinarnym(int szukanaLiczba, List<int> ciagPosortowanychLiczb)
        {
            if (ciagPosortowanychLiczb.Count == 0)
                return -1;
            int srodekSprawdzanegoCiagu;
            int poczatekSprawdzanegoCiagu = 0;
            int koniecSprawdzanegoCiagu = ciagPosortowanychLiczb.Count - 1;
            while (koniecSprawdzanegoCiagu - poczatekSprawdzanegoCiagu > 1)
            {
                srodekSprawdzanegoCiagu = (koniecSprawdzanegoCiagu + poczatekSprawdzanegoCiagu) / 2;
                if (ciagPosortowanychLiczb[srodekSprawdzanegoCiagu] > szukanaLiczba)
                    koniecSprawdzanegoCiagu = srodekSprawdzanegoCiagu;
                else
                    poczatekSprawdzanegoCiagu = srodekSprawdzanegoCiagu;
            }
            if (ciagPosortowanychLiczb[poczatekSprawdzanegoCiagu] == szukanaLiczba)
                return poczatekSprawdzanegoCiagu;
            if (ciagPosortowanychLiczb[koniecSprawdzanegoCiagu] == szukanaLiczba)
                return koniecSprawdzanegoCiagu;
            else
                return -1;

        }
        public int ZwracaPozycjeLiczbyPoWyszukaniuBinarnymRekurencyjnie(int poczatekSprawdzanegoCiagu, int koniecSprawdzanegoCiagu, int szukanaLiczba, List<int> ciagPosortowanychLiczb)
        {
            if (ciagPosortowanychLiczb.Count == 0)
                return -1;
            int srodekSprawdzanegoCiagu;
            if (koniecSprawdzanegoCiagu - poczatekSprawdzanegoCiagu <= 1)                       //sprawdza czy zostal ciag dwuelementowy
            {
                if (ciagPosortowanychLiczb[poczatekSprawdzanegoCiagu] == szukanaLiczba)
                    return poczatekSprawdzanegoCiagu;
                if (ciagPosortowanychLiczb[koniecSprawdzanegoCiagu] == szukanaLiczba)
                    return koniecSprawdzanegoCiagu;
                else
                    return -1;
            }
            else            //ciag jest dluzszy wiec zapetlamy rekurencyjnie, podajac do przeszukania odpowiednia polowe przedzialu
            {
                srodekSprawdzanegoCiagu = (koniecSprawdzanegoCiagu + poczatekSprawdzanegoCiagu) / 2;
                if (ciagPosortowanychLiczb[srodekSprawdzanegoCiagu] > szukanaLiczba)
                    return ZwracaPozycjeLiczbyPoWyszukaniuBinarnymRekurencyjnie(poczatekSprawdzanegoCiagu, srodekSprawdzanegoCiagu, szukanaLiczba, ciagPosortowanychLiczb);
                else
                    return ZwracaPozycjeLiczbyPoWyszukaniuBinarnymRekurencyjnie(srodekSprawdzanegoCiagu, koniecSprawdzanegoCiagu, szukanaLiczba, ciagPosortowanychLiczb);
            }
        }
        public int ZwracaPozycjeLiczbyPoWyszukaniuBinarnymRekurencyjnieV2(int poczatekSprawdzanegoCiagu, int koniecSprawdzanegoCiagu, int szukanaLiczba, List<int> ciagPosortowanychLiczb)
        {
            if (poczatekSprawdzanegoCiagu > koniecSprawdzanegoCiagu)
                return -1;
            int srodekSprawdzanegoCiagu = (poczatekSprawdzanegoCiagu + koniecSprawdzanegoCiagu) / 2;
            if (ciagPosortowanychLiczb[srodekSprawdzanegoCiagu] == szukanaLiczba)
                return srodekSprawdzanegoCiagu;
            if (szukanaLiczba < ciagPosortowanychLiczb[srodekSprawdzanegoCiagu])
                return ZwracaPozycjeLiczbyPoWyszukaniuBinarnymRekurencyjnieV2(poczatekSprawdzanegoCiagu, srodekSprawdzanegoCiagu - 1, szukanaLiczba, ciagPosortowanychLiczb);
            else
                return ZwracaPozycjeLiczbyPoWyszukaniuBinarnymRekurencyjnieV2(srodekSprawdzanegoCiagu + 1, koniecSprawdzanegoCiagu, szukanaLiczba, ciagPosortowanychLiczb);
        }

        //metoda interpolacyjna

        public int ZwracaPozycjeLiczbyPoWyszukiwaniuInterpolacyjnym(List<int> listaPosortowana, int poczatek, int koniec, int szukanaLiczba)
        {
            int nowyPoczatek = poczatek;
            int nowyKoniec = koniec;
            int strzal = poczatek + (szukanaLiczba - listaPosortowana[poczatek]) * (koniec - poczatek) / (listaPosortowana[koniec] - listaPosortowana[poczatek]);
            if (strzal > koniec || strzal < poczatek)
                return -1;
            while (listaPosortowana[strzal] != szukanaLiczba)
            {
                if (listaPosortowana[strzal] < szukanaLiczba)
                {
                    nowyKoniec = nowyKoniec - strzal - 1;
                    strzal = nowyPoczatek + (szukanaLiczba - listaPosortowana[nowyPoczatek]) * (nowyKoniec - nowyPoczatek) / (listaPosortowana[nowyKoniec] - listaPosortowana[nowyPoczatek]);
                }
                else
                {
                    nowyPoczatek = nowyPoczatek + strzal + 1;
                    strzal = nowyPoczatek + (szukanaLiczba - listaPosortowana[nowyPoczatek]) * (nowyKoniec - nowyPoczatek) / (listaPosortowana[nowyKoniec] - listaPosortowana[nowyPoczatek]);
                }
            }
            return strzal;
        }
        public void Test()
        {
            List<int> ciagPosortowanychLiczb = new List<int> { 1, 1, 2, 2, 3, 5, 5, 6, 7, 8, 9, 9, 10 };
            var wynik = ZwracaPozycjeLiczbyPoWyszukiwaniuInterpolacyjnym(ciagPosortowanychLiczb, 0, ciagPosortowanychLiczb.Count - 1, 3);
            Console.WriteLine(wynik);

            /*  do
             {
                 ciagPosortowanychLiczb.RemoveAt(0);
                 for (int i = 1; i <= 10; i++)
                 {
                     //var wynik = ZwracaPozycjeLiczbyPoWyszukaniuBinarnymRekurencyjnieV2(0, ciagPosortowanychLiczb.Count - 1, i, ciagPosortowanychLiczb);
                     //var wynik = ZwracaPozycjeLiczbyPoWyszukaniuBinarnymRekurencyjnie(i, ciagPosortowanychLiczb);
                     var wynik = ZwracaPozycjeLiczbyPoWyszukiwaniuInterpolacyjnym(ciagPosortowanychLiczb, i);
                     if (wynik == -1)
                     {
                         if (wynik != ciagPosortowanychLiczb.IndexOf(i))
                             Console.WriteLine("Nie dziala dla szukanej liczby {0}", i);
                     }
                     else
                         if (i != ciagPosortowanychLiczb[wynik])
                         Console.WriteLine("Nie dziala dla szukanej liczby {0}", i);
                 }
             } while (ciagPosortowanychLiczb.Count > 0);
  */
        }
    }
}