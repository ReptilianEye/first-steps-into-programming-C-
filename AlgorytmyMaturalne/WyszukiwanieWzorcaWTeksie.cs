using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class SprawdzCzyPodciagUkrytyJestWCiagu
    {
        //Napisz funkcje ktora sprawdzi czy podciag ukryty jest w ciagu 

        //Funkcja idzie po ciagu i sprawdza czy pierwsza litera ciagu zgadza ske z pierwsza litera pod ciagu. Jesli tak spradza dla kolejnej litery w obu ciagach az dojdzie do konca podciagu
        //Wazna rzecz - funkcja idzie po ciagu do momentu az nie dojdzie do momentu kiedy ilosc pozostalych liter w ciagu bedzie mniejsza niz ilosc liter w podciagu
        public int ZwrocIndexPoczatkuPodciaguWCiagu(string podciag, string ciag)
        {
            if (podciag.Length > ciag.Length)
                return -1;
            int wskaznikPodciagu = 0;
            int wskaznikCiagu;
            int poczatekPodciaguWCiagu = -1;
            for (int i = 0; i <= ciag.Length - podciag.Length; i++)
            {
                wskaznikCiagu = i;
                while (ciag[wskaznikCiagu] == podciag[wskaznikPodciagu])
                {
                    if (wskaznikCiagu == i)
                        poczatekPodciaguWCiagu = wskaznikCiagu;
                    if (podciag.Length - 1 == wskaznikPodciagu)
                        return poczatekPodciaguWCiagu;
                    wskaznikCiagu++;
                    wskaznikPodciagu++;
                }
                wskaznikPodciagu = 0;
            }
            return -1;
        }
        //wersja taty
        public int ZwrocIndexPoczatkuPodciaguWCiaguV2(string podciag, string ciag)
        {
            if (podciag.Length > ciag.Length)
                return -1;
            for (int sprawdzanyPoczatek = 0; sprawdzanyPoczatek <= ciag.Length - podciag.Length; sprawdzanyPoczatek++)
            {
                bool zgadzaSie = true;
                for (int sprawdzanaLitera = 0; sprawdzanaLitera < podciag.Length; sprawdzanaLitera++)
                    if (ciag[sprawdzanyPoczatek + sprawdzanaLitera] != podciag[sprawdzanaLitera])
                    {
                        zgadzaSie = false;
                        break;
                    }
                if (zgadzaSie)
                    return sprawdzanyPoczatek;
            }
            return -1;
        }
        public void Test()
        {
            Testuje3Funkcje("tarka", "latatarka", true, "blad 1");
            Testuje3Funkcje("aaaaaaaaa", "A", false, "blad 2");
            Testuje3Funkcje("00", "c00l", true, "blad 3");
            Testuje3Funkcje("345", "12345", true, "blad 4");
            Testuje3Funkcje("345", "1234", false, "blad 5");
            Testuje3Funkcje("123", "12345", true, "blad 6");
        }
        public void Testuje3Funkcje(string podciag, string ciag, bool spodziwanaOdpowiedz, string komunikat)
        {
            int wynik1 = ZwrocIndexPoczatkuPodciaguWCiagu(podciag, ciag);
            int wynik2 = ZwrocIndexPoczatkuPodciaguWCiaguV2(podciag, ciag);
            int wynik3 = ciag.IndexOf(podciag);
            if (wynik1 != wynik2 || wynik2 != wynik3)
                Console.WriteLine(komunikat);
        }
    }
}