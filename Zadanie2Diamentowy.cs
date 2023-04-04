
using System;
using System.Collections;
using nauka_programowania;
using System.Collections.Generic;

namespace nauka_programowania
{
    class Zadanie2Diament
    {
        public int sumaWszystkich = 0;
        int ZliczaNajmniejszaSumePoObcieciu(List<int> tablicaLiczb, int wielkoscTablicy, int liczbaOperacji)
        {
            for (int i = liczbaOperacji; i > 0; i--)
            {
                if (tablicaLiczb[liczbaOperacji - 1] % 2 == 1)
                    sumaWszystkich--;
                int oIleOdejmujemy = Convert.ToInt32(Math.Floor(Convert.ToDouble(tablicaLiczb[liczbaOperacji - 1] / 2)));
                tablicaLiczb[liczbaOperacji - 1] = oIleOdejmujemy;                      //dodac sprawdzenie ze jesli suma jest rowna 0 
                sumaWszystkich = sumaWszystkich - oIleOdejmujemy;                       //nie sprawdzamy dalej                                                            
                tablicaLiczb.Sort();
            }
            return sumaWszystkich;
        }
        public int main()
        {
            //********** wczytywanie wejscia
            int wielkoscTablicy;
            int liczbaOperacji;
            wielkoscTablicy = 4;
            liczbaOperacji = 3;
            List<int> tablicaLiczb = new List<int> { 20, 5, 7, 4 };       //Usunac
            int maksymalnaWartosc = 0;
            for (int i = 0; i < wielkoscTablicy; i++)
            {
                //tablicaLiczb[i] = Convert.ToInt32(Console.ReadLine());
                sumaWszystkich = sumaWszystkich + tablicaLiczb[i];
                if (maksymalnaWartosc < tablicaLiczb[i])
                    maksymalnaWartosc = tablicaLiczb[i];
            }
            tablicaLiczb.Sort();
            List<int> listaNajwiekszych = new List<int>();
            int j = liczbaOperacji - 1;
            for (int i = 0; i <= j; i++)
                listaNajwiekszych.Add(0);
            for (int i = liczbaOperacji; i > 0; i--)
            {
                listaNajwiekszych[j] = tablicaLiczb[i];
                j--;
            }
            ZliczaNajmniejszaSumePoObcieciu(listaNajwiekszych, wielkoscTablicy, liczbaOperacji);
            Console.WriteLine(sumaWszystkich);
            return 0;
        }
    }
}