using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;
namespace nauka_programowania
{
    class MetodyDoPiekloNiebo
    {
        public static int ZwrocDlugoscNajdluzszegoRosnacegoCiagu(List<int> ciagLiczb)
        {
            int maxDlugosc = 1;
            int poczatek = 0;
            int dlugosc = 1;
            int pomocniczyPoczatek = 0;
            for (int i = 1; i < ciagLiczb.Count; i++)
            {
                if (ciagLiczb[i] >= ciagLiczb[i - 1])
                {
                    dlugosc++;
                    if (dlugosc > maxDlugosc)
                    {
                        maxDlugosc = dlugosc;
                        poczatek = pomocniczyPoczatek;
                    }
                }
                else
                {
                    pomocniczyPoczatek = i;
                    dlugosc = 1;
                }
            }
            return maxDlugosc;
        }
        public static int ZwrocDlugoscNajdluzszegoMalejacegoCiagu(List<int> ciagLiczb)
        {
            int maxDlugosc = 1;
            int poczatek = 0;
            int dlugosc = 1;
            int pomocniczyPoczatek = 0;
            for (int i = 1; i < ciagLiczb.Count; i++)
            {
                if (ciagLiczb[i] <= ciagLiczb[i - 1])
                {
                    dlugosc++;
                    if (dlugosc > maxDlugosc)
                    {
                        maxDlugosc = dlugosc;
                        poczatek = pomocniczyPoczatek;
                    }
                }
                else
                {
                    pomocniczyPoczatek = i;
                    dlugosc = 1;
                }
            }
            return maxDlugosc;
        }
    }
}
