using System;
using System.Collections;
using System.Collections.Generic;
using nauka_programowania;
using System.IO;

namespace nauka_programowania
{
    class ZnajdzBrakujaceDomino
    {
        /*
        DOMINO - znajdź kamień
        Chcesz zagrać ze mną w DOMINO? Uważasz, że jesteś w stanie mnie pokonać? Być może masz rację, ale muszę się do czegoś przyznać. Zgubiłem jeden kamień domina. Niestety nie pamiętam który, jeśli więc chcesz ze mną zagrać, musisz go znaleźć. 

        Wejście
        W pierwszym wierszu znajduje się jedna liczba określająca liczbę zestawów danych(nie więcej niż 1000). Każdy zestaw składa się z jednego wiersza, a w nim 27 kamieni domina w formacie[liczba oczek]|[liczba oczek].

        Wyjście
        Dla każdego zestawu testowego szukany kamień domina w formacie[liczba oczek]|[liczba oczek]. Liczbę oczek ustawiamy w ciągu niemalejącym.

        Przykład
        Wejście:
        1 
        2|5 4|5 0|1 3|4 3|6 3|1 2|6 0|0 3|3 5|3 6|6 1|1 3|0 2|2 6|4 4|2 0|4 2|3 0|2 1|6 2|1 5|0 0|6 1|4 6|5 4|4 5|1


        Wyjście:
        5|5 */
        public List<List<string>> WczytajWejscie()
        {
            var listaListKostek = new List<List<string>>();
            StreamReader file = new System.IO.StreamReader(@"Wyszukiwanie_kostki_domina\DaneDoKostekDomina.txt");
            int iloscZestawow = Convert.ToInt32(file.ReadLine());
            for (int zestaw = 1; zestaw <= iloscZestawow; zestaw++)
            {
                var listaKostek = new List<string>();
                string kostki = file.ReadLine();
                kostki = kostki.Trim();
                listaKostek.AddRange(kostki.Split(" "));
                for (int i = 0; i < listaKostek.Count; i++)
                    if ((int)listaKostek[i][0] > (int)listaKostek[i][2])
                        listaKostek[i] = listaKostek[i][2] + "|" + listaKostek[i][0];
                listaListKostek.Add(listaKostek);
            }
            file.Close();
            return listaListKostek;
        }
        public List<string> ZnajdzKostkeDomina(List<string> listaKostek)
        {
            List<string> zgubioneKostki = new List<string>();
            for (int i = 0; i <= 6; i++)
                for (int j = 0; j <= i; j++)
                {
                    string kostka = Convert.ToString(j) + "|" + Convert.ToString(i);
                    if (listaKostek.IndexOf(kostka) == -1)
                        zgubioneKostki.Add(kostka);
                }
            return zgubioneKostki;
        }

        public void WypiszWyjscie(List<string> listaKostek, List<string> listaZgubionychKostek)
        {
            Console.WriteLine("Brakujace elementy listy: {0}", string.Join(" ", listaKostek.ToArray())+"\nto:");
            foreach (var element in listaZgubionychKostek)
                Console.WriteLine(element);
        }
        public void Test()
        {
            var listaListKostek = WczytajWejscie();
            foreach (var listaKostek in listaListKostek)
            {
                var rozwiazanie = ZnajdzKostkeDomina(listaKostek);
                WypiszWyjscie(listaKostek, rozwiazanie);
            }
        }
    }
}