using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;
using System.Text.RegularExpressions;

namespace nauka_programowania
{
    class Zadanie6_etap3
    {
        public string WczytajWejscie()
        {
            string haslo = "c[2[3ab]]c."; //Console.ReadLine();
            return haslo;
        }
        public string ZwracaZdekompresowaneciagV1(string ciag)
        {
            string zdekompresowaneciag = "";
            string cyfry = "123456789";
            for (int i = 0; i < ciag.Length; i++)
            {
                if (ciag[i] == '[')
                {
                    int p = 0;
                    string powtarzanyPodstring = "";
                    int granicaPowtorki = Int32.Parse(ciag[i + 1].ToString());
                    p = (i + 2);
                    while (ciag[p] != ']')
                    {
                        powtarzanyPodstring = powtarzanyPodstring + ciag[p];
                        p++;
                    }
                    for (int j = 0; j <= granicaPowtorki; j++)
                    {
                        zdekompresowaneciag = zdekompresowaneciag + powtarzanyPodstring;
                    }
                    i = i + p - 1;
                }
                else
                    zdekompresowaneciag = zdekompresowaneciag + ciag[i];
            }
            return zdekompresowaneciag;
        }
        public string ZwracaZdekompresowanyCiagV2(string ciag)
        {
            Regex rx = new Regex(@"\[\d[a-z]+\]", RegexOptions.Compiled);
            while (true)
            {
                var match = rx.Match(ciag);
                if (!match.Success)
                    return ciag;
                else
                {
                    var skompresowanyCiag = match.Value;
                    var rozkompresowanyCiag = ZwracaZdekompresowanyPodciag(skompresowanyCiag);
                    ciag =  rx.Replace(ciag, rozkompresowanyCiag, 1);
                }
            }
        }
        public string ZwracaZdekompresowanyPodciag(string skompresowanyCiag)
        {
            string rozkompresowanyCiag = "";
            string powtarzanyPodstring = "";
            int iloscPowtorki = Int32.Parse(skompresowanyCiag[1].ToString());
            powtarzanyPodstring = skompresowanyCiag.Substring(2, skompresowanyCiag.Length - 3);
            for (int j = 0; j < iloscPowtorki; j++)
            {
                rozkompresowanyCiag = rozkompresowanyCiag + powtarzanyPodstring;
            }
            return rozkompresowanyCiag;
        }
        public string ZwracaZdekompresowanyCiagRekurencyjnie(string skompresowanyCiag)
        {
            int licznikNawiasow = 0;
            int polozenieNawiasu = 0;
            for (int i = 0; i < skompresowanyCiag.Length; i++)
            {
                if (skompresowanyCiag[i] == '[')
                {
                    licznikNawiasow++;
                    polozenieNawiasu = i;
                }
                if (licznikNawiasow > 1 && skompresowanyCiag[i] == ']')
                {
                    return ZwracaZdekompresowanyCiagRekurencyjnie(skompresowanyCiag.Substring(polozenieNawiasu, skompresowanyCiag.Length - i + 1));
                }
            }
            string rozkompresowanyCiag = "";
            int mnoznik = Int32.Parse(skompresowanyCiag[1].ToString());
            string ciag = skompresowanyCiag.Substring(2, 2);
            for (int i = 0; i < mnoznik; i++)
                rozkompresowanyCiag = rozkompresowanyCiag + ciag;
            return rozkompresowanyCiag;
        }
        public void WypiszWyjscie(string wynik)
        {
            Console.WriteLine(wynik);
        }
        public void WykonajZadanie()
        {
            string ciag = WczytajWejscie();
            string wynik = //ZwracaZdekompresowanyCiagRekurencyjnie(ciag);
            ZwracaZdekompresowanyCiagV2(ciag);
            WypiszWyjscie(wynik);
        }
        public void Testy()
        {


        }
    }
}