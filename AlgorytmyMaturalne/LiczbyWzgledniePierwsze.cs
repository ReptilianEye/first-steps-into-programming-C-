using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class ZnajdywanieLiczbWzgledniePierwszych
    {
        public List<int> ZwracaListeLiczbWzgledniePierwszychDoLiczby(int poczatekPrzedzialu, int koniecPrzedzialu, int liczbaDoPorownania)
        {
            List<int> listaWzgledychPierwszych = new List<int>();
            WyznaczanieNajwiekszegoWspolnegoDzielnika wnwd = new WyznaczanieNajwiekszegoWspolnegoDzielnika();
            for (int i = poczatekPrzedzialu; i <= koniecPrzedzialu; i++)
            {
                if (wnwd.ZwrocNWDDwochLiczbOptymalnie(i, liczbaDoPorownania) == 1)
                    listaWzgledychPierwszych.Add(i);
            }
            return listaWzgledychPierwszych;
        }
        public long ZwracaLiczbeWzgledniePierwszychDoLiczby(long liczbaDoPorownania)
        {
            WyznaczanieNajwiekszegoWspolnegoDzielnika wnwd = new WyznaczanieNajwiekszegoWspolnegoDzielnika();
            bool czyZnaleziona = false;
            long i = 1000;
            while (!czyZnaleziona)
            {

                if (wnwd.ZwrocNWDDwochLiczbOptymalnie(i, liczbaDoPorownania) == 1)
                {
                    czyZnaleziona = true;
                    return i;
                }
            i--;
            }
            return 0;
        }
        public void Test()
        {
            for (int i = 1; i < 10000; i++)
                ZwracaListeLiczbWzgledniePierwszychDoLiczby(1, 1000000, i);
        }
    }
}