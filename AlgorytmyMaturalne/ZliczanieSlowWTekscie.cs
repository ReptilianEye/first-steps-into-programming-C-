using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class ZliczanieSlowWTekscie
    {
        public int ZwracaIloscSlowWTekscie(string tekst)
        {
            bool CzyToSamoSlowo = false;
            int licznikSlow = 0;
            string znaki = ".,;:/?!%&()[]{} |-_/*^#@`~";
            for (int i = 0; i < tekst.Length; i++)
            {
                if (znaki.IndexOf(tekst[i]) < 0)
                {
                    if (!CzyToSamoSlowo)
                    {
                        licznikSlow++;
                        CzyToSamoSlowo = true;
                    }
                }
                else
                    CzyToSamoSlowo = false;
            }
            return licznikSlow;
        }

        public void Test()
        {
            string haslo = "Ala ma  kota i dwa psy , a  takze rybke .";
            int iloscSlowWTekscie = 9;
            if(ZwracaIloscSlowWTekscie(haslo) != iloscSlowWTekscie)
            Console.WriteLine("Blad 1");
            Console.WriteLine(ZwracaIloscSlowWTekscie(haslo));
        }
    }
}