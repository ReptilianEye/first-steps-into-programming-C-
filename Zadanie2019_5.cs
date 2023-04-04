using System;
using System.Collections;
using nauka_programowania;
using System.Collections.Generic;
namespace nauka_programowania
{
    class Zadanie5
    {
        public List<string> SzukajLiczbBinarnych(int liczbaOsob)
        {
            List<string> lista = new List<string>();
            for (int i = 1; i < Math.Pow(2, liczbaOsob); i++)
            {
                string liczbaBinarnie = Convert.ToString(i, 2);
                int suma1 = 0;
                foreach (char cyfra in liczbaBinarnie)
                {
                    if (cyfra == '1')
                        suma1++;
                }
                if (suma1 == liczbaOsob / 2)
                {
                    liczbaBinarnie = new string('0', liczbaOsob - liczbaBinarnie.Length) + liczbaBinarnie;
                    lista.Add(liczbaBinarnie);
                }
            }
            return lista;
        }
        public Boolean SprawdzaCzySumaPunktowUczniowMozeBycTakaSamaDla2RownychGrup(List<string> listaWzorowDoSprawdzenia, Dictionary<int, int> listaPunktow, int liczbaUczniow)
        {
            for (int i = 0; i < listaWzorowDoSprawdzenia.Count; i++)
            {
                int sumaUczniow0 = 0;
                int sumaUczniow1 = 0;
                for (int j = 0; j < liczbaUczniow; j++)
                {
                    if (listaWzorowDoSprawdzenia[i][j] == '0')
                        sumaUczniow0 = sumaUczniow0 + listaPunktow[j];
                    else
                        sumaUczniow1 = sumaUczniow1 + listaPunktow[j];
                }
                if (sumaUczniow0 == sumaUczniow1)
                    return true;
            }
            return false;
        }

        public Dictionary<int, int> WczytajWejscie(ref int liczbaUczniow)
        {
            Dictionary<int, int> listaPunktow = new Dictionary<int, int>();
            liczbaUczniow = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < liczbaUczniow; i++)
            {
                int wynikUcznia = Convert.ToInt32(Console.ReadLine());
                listaPunktow.Add(i, wynikUcznia);
            }
            return listaPunktow;
        }
        public Dictionary<int, int> WczytajWejscieV2(ref int liczbaUczniow)
        {
            liczbaUczniow = 20;
            Dictionary<int, int> tablica = new Dictionary<int, int>();
            tablica.Add(0, 25);
            tablica.Add(1, 25);
            tablica.Add(2, 10);
            tablica.Add(3, 41);
            tablica.Add(4, 41);
            tablica.Add(5, 41);
            tablica.Add(6, 41);
            tablica.Add(7, 21);
            tablica.Add(8, 41);
            tablica.Add(9, 61);
            tablica.Add(10, 43);
            tablica.Add(11, 48);
            tablica.Add(12, 43);
            tablica.Add(13, 23);
            tablica.Add(14, 76);
            tablica.Add(15, 65);
            tablica.Add(16, 35);
            tablica.Add(17, 56);
            tablica.Add(18, 76);
            tablica.Add(19, 88);

            return tablica;
        }
        public Dictionary<int, int> WczytajWejscieV3(ref int liczbaUczniow)
        {
            liczbaUczniow = 4;
            Dictionary<int, int> tablica = new Dictionary<int, int>();
            tablica.Add(0, 25);
            tablica.Add(1, 25);
            tablica.Add(2, 10);
            tablica.Add(3, 41);
            return tablica;
        }
        public void WypiszWyjscie(bool wynik)
        {
            if (wynik)
                Console.WriteLine("TAK");
            else
                Console.WriteLine("NIE");
        }

        public void WykonajZadanie()
        {
            int liczbaUczniow = 0;
            var listaPunktow = WczytajWejscieV2(ref liczbaUczniow);
            var listaWzorowDoSprawdzenia = SzukajLiczbBinarnych(liczbaUczniow);
            var wynik = SprawdzaCzySumaPunktowUczniowMozeBycTakaSamaDla2RownychGrup(listaWzorowDoSprawdzenia, listaPunktow, liczbaUczniow);
            WypiszWyjscie(wynik);
        }


        public Boolean SprwdzaCzyMoznaUzyskacSumeZelementowTablicy()
        {
            List<int> lista = new List<int>();
            lista.Add(10);
            lista.Add(70);
            lista.Add(150);
            lista.Add(80);
            lista.Add(120);
            lista.Add(200);
            lista.Add(50);
            lista.Add(190);
            lista.Add(55);
            lista.Add(60);
            lista.Add(65);
            lista.Sort();
            int suma = 0;
            foreach (var element in lista)
                suma = suma + element;
            for (int i = lista.Count - 1; i >= 0; i--)
            {
                int pulaPolowy = lista.Count / 2;
                int polowaSumy = suma / 2;
                int j = i;
                while (j >= 0)
                {
                    if (lista[j] <= polowaSumy)
                    {
                        polowaSumy = polowaSumy - lista[j];
                        pulaPolowy--;
                        j--;
                    }
                    else
                        j--;
                    if (pulaPolowy == 0 && polowaSumy == 0)
                        return true;
                }

            }
            return false;
        }

    }
}

