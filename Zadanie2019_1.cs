using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class Zadanie1
    {
        public void WczytajWejscie(ref int iloscDocelowych, ref int dlugoscDocelowego, ref int dlugoscPosiadanego)
        {
            string wiersz = Console.ReadLine();
            string[] liczby = wiersz.Split(" ");
            iloscDocelowych = Convert.ToInt32(liczby[0]);
            dlugoscDocelowego = Convert.ToInt32(liczby[1]);
            dlugoscPosiadanego = Convert.ToInt32(liczby[2]);
        }
        public int ZwracaIloscNiezbednychCiec(int iloscPotrzebnaDocelowych, int dlugoscDocelowego, int dlugoscPosiadanego)
        {
            List<int> lista = new List<int>();
            int iloscCiec = 0;
            int dlugoscSkladanego = dlugoscDocelowego;
            while (!(lista.Count * dlugoscPosiadanego >= dlugoscDocelowego * iloscPotrzebnaDocelowych))
                lista.Add(dlugoscPosiadanego);
            while (iloscPotrzebnaDocelowych > 0)
            {
                if (lista[0] == dlugoscSkladanego)
                {
                    iloscPotrzebnaDocelowych--;
                    lista.RemoveAt(0);
                    dlugoscSkladanego = dlugoscDocelowego;
                    continue;
                }
                if (lista[0] > dlugoscSkladanego)
                {
                    int reszta = lista[0] - dlugoscSkladanego;
                    iloscCiec++;
                    lista.Add(reszta);
                    lista.Sort();
                    iloscPotrzebnaDocelowych--;
                    dlugoscSkladanego = dlugoscDocelowego;
                    continue;
                }
                if (lista[0] < dlugoscSkladanego)
                {
                    dlugoscSkladanego = dlugoscSkladanego - lista[0];
                    lista.RemoveAt(0);
                    continue;
                }
            }
            return iloscCiec;
        }
        public void WypiszWyjscie(int wynik)
        {
            Console.WriteLine(wynik);
        }
        public void WykonajZadanie()
        {
            int iloscDocelowych = 0;
            int dlugoscDocelowego = 0;
            int dlugoscPosiadanego = 0;
            WczytajWejscie(ref iloscDocelowych, ref dlugoscDocelowego, ref dlugoscPosiadanego);
            int wynik = ZwracaIloscNiezbednychCiec(iloscDocelowych, dlugoscDocelowego, dlugoscPosiadanego);
            WypiszWyjscie(wynik);
        }
        public void Testy()
        {
            if (3 != ZwracaIloscNiezbednychCiec(5, 500, 1000))
                Console.WriteLine("blad 1");
            if (3 != ZwracaIloscNiezbednychCiec(4, 5, 4))
                Console.WriteLine("blad 2");


        }
    }
}