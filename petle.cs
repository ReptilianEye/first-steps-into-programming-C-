using System;
using System.Collections;

namespace nauka_programowania
{
    public class petle
    {
        public void PrzykladFor()
        {
            string[] tablica_str = new string[3];
            tablica_str[0] = "piotrek";
            tablica_str[1] = "marek";
            tablica_str[2] = "agatka";
            // modyfikacja i wyswietelenie elementow tabeli
            for (int i = 0; i < tablica_str.Length; i++)
            {
                tablica_str[i] = "the " + tablica_str[i] + " is cool";
                Console.WriteLine(i + " " + tablica_str[i]);
            }
            // wyswietlenie tablicy od tylu
            for (int i = tablica_str.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(i + " " + tablica_str[i]);
            }
            //suma liczb z tablicy
            int[] liczby = new int[10] { 2, 4, 5, 6, 3, 20, 6, 4, 3, 7 };
            int wynik = 0;
            for (int i = 0; i < liczby.Length; i++)
            {
                wynik = wynik + liczby[i];
            }
            Console.WriteLine("Suma wszystkich liczb to " + wynik);


            //suma liczb parzystych z tablicy
            int wynikParzystych = 0;
            for (int i = 0; i < liczby.Length; i++)
            {
                if (liczby[i] % 2 == 0)
                {
                    wynikParzystych = wynikParzystych + liczby[i];
                }
            }
            Console.WriteLine("Suma wszystkich liczb parzystych to " + wynikParzystych);

            //suma co drugiej liczby z tablicy
            int wynik_co_drugiej = 0;
            for (int i = 0; i < liczby.Length; i = i + 2)
            {
                wynik_co_drugiej = wynik_co_drugiej + liczby[i];
            }
            Console.WriteLine("Suma co drugiej liczby to " + wynik_co_drugiej);
        }
        public void PrzykladForeach()
        {
            int[] liczby = new int[10] { 2, 4, 5, 6, 3, 20, 6, 4, 3, 7 };
            int wynik = 0;
            //suma wszystkich liczb z tablicy
            foreach (var liczba in liczby)
            {
                wynik = wynik + liczba;
            }
            Console.WriteLine("Suma wszystkich liczb to " + wynik);


            //suma parzystych liczb z tablicy
            int wynikParzystych = 0;
            foreach (var liczba in liczby)
                if (liczba % 2 == 0)
                    wynikParzystych = wynikParzystych + liczba;
            Console.WriteLine("Suma patrzystych liczb to " + wynikParzystych);

        }
        public void odwracanieTablicy_ArrayList(int[] liczby)
        {
            //odwracanie tablicy Array lista
            ArrayList odwrocona = new ArrayList();
            for (int i = liczby.Length - 1; i >= 0; i--)
                odwrocona.Add(liczby[i]);
            Console.WriteLine("odwrocona tablica to ");
            foreach (var numer in odwrocona)
                Console.WriteLine(numer);
        }
        public void odwracanieTablicy_Stack(int[] liczby)
        {
            //odwracanie tablicy Stack
            Stack odwrocony = new Stack();
            foreach (var l in liczby)
                odwrocony.Push(l);
            Console.WriteLine("odwrocona tablica to ");
            foreach (var numer in odwrocony)
                Console.WriteLine(numer);
        }

        public void sprawdzanieCzyLiczbaNaLiscieJestParzysta(int[] liczby)
        {
            //Write a function that checks whether an element occurs in a list.
            Console.WriteLine("Te liczby sá parzyste na tej liscie: ");
            ArrayList lista = new ArrayList(liczby);
            foreach (int numer in lista)
                if (numer % 2 == 0)
                    Console.WriteLine(numer);
        }

        public void czyTeSlowaBrzmiaTakSamoOdTylu()
        {
            ArrayList slowa = new ArrayList();
            string[] wyrazy = new string[8] { "piotrek", "kajak", "marek", "agatka ", "level", "aparat", "bob", "wow" };
            Stack odwrocony = new Stack();
            int i = 0;
            foreach (var slowo in wyrazy)
            {
                i = i + 1;
                slowa.Add(slowo[i]);
                Console.WriteLine(slowo);
            }
            //chwilowo za trudne- nie wiem jak obrocic slowa aby byly napisane od tylu       
        }

        public void lacznieTablic()
        {
            ArrayList listaCyfr = new ArrayList();
            ArrayList listaImion = new ArrayList();

            int[] liczby = new int[8] { 2, 3, 4, 5, 9, 5, 4, 3 };
            foreach (var liczba in liczby)
                listaCyfr.Add(liczba);
            string[] imiona = new string[4] { "Agatka", "Marek", "Piotrek", "Michal" };
            foreach (var imie in imiona)
                listaImion.Add(imie);
        }
        //rowniez za trudne. problem: nie potrafie dodac string[] do listy w jednej komendzie
        public void Testy()
        {
            petle p = new petle();
            //p.PrzykladFor();
            //p.PrzykladForeach();
            int[] numery = new int[10] { 2, 4, 5, 6, 3, 20, 6, 4, 3, 7 };
            //p.odwracanieTablicy_ArrayList(numery);
            //p.odwracanieTablicy_Stack(numery);
            //p.sprawdzanieCzyLiczbaNaLiscieJestParzysta(numery);
            //p.czyTeSlowaBrzmiaTakSamoOdTylu();
            //p.lacznieTablic();
        }
    }
}
