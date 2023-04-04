using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class PotegowanieSzybkie
    {
        public long ZwracaWartoscPotegi(long podstawa, long potega)
        {
            long wynik = 1;
            string potegaWBinarnym = Convert.ToString(potega, 2);
            for (int i = potegaWBinarnym.Length - 1; i >= 0; i--)
            {
                if (potegaWBinarnym[i] == '0')
                    podstawa = podstawa * podstawa;
                if (potegaWBinarnym[i] == '1')
                {
                    wynik = podstawa * wynik;
                    podstawa = podstawa * podstawa;
                }
            }
            return wynik;
        }
        public long ZwracaWartoscPotegiV2(long podstawa, long potega)
        {
            long wynik = 1;
            string potegaWBinarnym = Convert.ToString(potega, 2);
            char[] potegaWBinarnymNaCzasOdwrocenia = potegaWBinarnym.ToCharArray();
            Array.Reverse(potegaWBinarnymNaCzasOdwrocenia);
            potegaWBinarnym = potegaWBinarnymNaCzasOdwrocenia.ToString();
            for (int i = 0; i < potegaWBinarnym.Length; i++)
            {
                if (potegaWBinarnym[i] == '0')
                    podstawa = podstawa * podstawa;
                if (potegaWBinarnym[i] == '1')
                {
                    wynik = podstawa * wynik;
                    podstawa = podstawa * podstawa;
                }
            }
            return wynik;
        }
        public void Test()
        {
            for (int podstawa = 0; podstawa <= 78; podstawa++)
                for (int potega = 0; potega <= 10; potega++)
                    if (ZwracaWartoscPotegi(podstawa, potega) != Math.Pow(podstawa, potega))
                        Console.WriteLine("Zly wynik dla podstawy = {0} i potegi = {1}", podstawa, potega);
        }
    }
}