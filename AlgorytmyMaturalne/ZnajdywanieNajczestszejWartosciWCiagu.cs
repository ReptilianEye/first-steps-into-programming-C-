using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class ZnajdywanieDomianta
    {
        //Napisz funkcje ktora wyznaczy wartosc pierwistak kwadratowego
        public int ZwracaWartoscDominantaWLisciePosortowanej(List<int> lista)
        {
            if (lista.Count == 0)
                return -1;
            int wartoscDominanta = lista[0];
            int dlugoscCiaguDominantow = 0;
            int dlugoscNajdluzszegoCiaguDominantow = 0;
            int rozpatrywanaLiczba = lista[0];
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i] != rozpatrywanaLiczba)
                {
                    if (dlugoscCiaguDominantow > dlugoscNajdluzszegoCiaguDominantow)
                    {
                        wartoscDominanta = rozpatrywanaLiczba;
                        dlugoscNajdluzszegoCiaguDominantow = dlugoscCiaguDominantow;
                    }
                    rozpatrywanaLiczba = lista[i];
                    dlugoscCiaguDominantow = 1;
                }
                else
                    dlugoscCiaguDominantow++;
            }
            return wartoscDominanta;
        }
        public int ZwracaWartoscLideraJesliWystepuje(List<int> lista)
        {
            int tymczasowyLider = 0;
            int licznik = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                if (licznik == 0)
                {
                    tymczasowyLider = lista[i];
                    licznik = 1;
                }
                else
                {
                    if (lista[i] == tymczasowyLider)
                        licznik++;
                    else
                        licznik--;
                }
            }
            if (licznik == 0)
                return -1;
            int licznikLidera = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                if (licznikLidera > lista.Count / 2)
                    return tymczasowyLider;
                if (lista[i] == tymczasowyLider)
                    licznikLidera++;
            }
            return -1;
        }
        public void Test()
        {
            List<int> lista = new List<int> { 3, 2, 4, 2, 2, 2, 1, 3, 4, 2,2,2, 2, 3, 4 };
            var wynik = ZwracaWartoscLideraJesliWystepuje(lista);
            if (wynik == -1)
                Console.WriteLine("Zbiór był pusty - nie ma domianta");
            else
                Console.WriteLine(wynik);
        }
    }
}