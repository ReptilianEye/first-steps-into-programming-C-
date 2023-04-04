using System;
using System.Collections;
using System.Collections.Generic;

namespace nauka_programowania
{
    class Tablice
    {
        public void OdwrocTabliceZUzyciemStosu(int[] tablica)
        {
            Stack stak = new Stack();
            foreach (var element in tablica)
            {
                stak.Push(element);
            }
            var ilosc = stak.Count;
            for (var i = 0; i < ilosc; i++)
            {
                tablica[i] = (int)stak.Pop();
            }
        }
        public void OdwrocTabliceZUzyciemStosuV2(int[] tablica)
        {
            Stack stak = new Stack();
            foreach (var element in tablica)
            {
                stak.Push(element);
            }
            int i = 0;
            while (stak.Count != 0)
            {
                tablica[i++] = (int)stak.Pop();
                //i++;
            }
        }
        public void OdwrocTabliceZUzyciemArrayList(int[] tablica)
        {
            ArrayList lista = new ArrayList();
            foreach (var element in tablica)
            {
                lista.Insert(0, element);
            }
            var ilosc = lista.Count;
            for (var i = 0; i < ilosc; i++)
            {
                tablica[i] = (int)lista[i];
            }
        }
        public void OdwrocTabliceZUzyciemArrayListV2(int[] tablica)
        {
            List<int> lista = new List<int>();
            foreach (var element in tablica)
            {
                lista.Add(element);
            }
            lista.Reverse();
            var ilosc = lista.Count;
            for (var i = 0; i < ilosc; i++)
            {
                tablica[i] = lista[i];
            }
        }
        public void OdwrocTabliceZUzyciemArrayListV3(int[] tablica)
        {
            ArrayList lista = new ArrayList();
            foreach (var element in tablica)
            {
                lista.Add(element);
            }
            var ilosc = lista.Count;
            int a = 0;
            for (var i = ilosc - 1; i >= 0; i--)
            {
                tablica[i] = (int)lista[a];
                a++;
            }
        }
        public void OdwrocTabliceWMiejscu(int[] tablica)
        {
            for (int i = 0; i < tablica.Length / 2; i++)
            {
                int tymczasowa = tablica[tablica.Length - i - 1];
                tablica[tablica.Length - i - 1] = tablica[i];
                tablica[i] = tymczasowa;
            }
        }
        public ArrayList zadanie(int[] tablica)
        {
            //napisz funcje ktora bierze tablice int i zwraca array liste
            // w tej array liscie maja byc tyko parzyste liczby posortowane od najmniejszej do najwiekszej
            //np. dla int{2,3,2,4,5,8,6,4} powiino byc zwrocne --> {2,2,4,4,6,8}
            ArrayList lista = new ArrayList();
            foreach (var elementy in tablica)
            {
                if (elementy % 2 == 0)
                {
                    lista.Add(elementy);
                }
            }
            lista.Sort();
            return lista;
        }
        public void Testy()
        {
            int[] tablica = { 3, 2, 10, 50, 5, 8, 6, 4 };
            Tablice tab = new Tablice();
            tab.OdwrocTabliceZUzyciemStosuV2(tablica);
            foreach (int elem in tablica)
                Console.WriteLine(elem);
            //tab.OdwrocTabliceWMiejscu(tablica);
            //tab.OdwrocTabliceZUzyciemArrayListV2(tablica);
            /*var wynik = tab.zadanie(tablica);
            foreach(int czynnik in wynik)
            {
                Console.WriteLine(czynnik);
            }
            Console.ReadLine();
            */

            ArrayList lista = new ArrayList { 2, 3, 4, 5, 6, 7, 5 };
            ArrayList chars = new ArrayList { "a", "b", "c", "d", "a", "f", "l", "h", "g" };
            RozwiazaniaZadan zad = new RozwiazaniaZadan();
            /*
            var najwieksza = zad.ZwrocNajwiekszyElementZListy(lista);
            Console.WriteLine("Najwiekszy element: {0}", najwieksza);
            var Odwroconalista = zad.ZwrocOdwroconaListe(lista);
            Console.WriteLine("Odwrocona lista: ");
            foreach (var element in lista)
            {
                Console.WriteLine(element);
            }
            */
            //Console.WriteLine("Podaj liczbe a ja sprawdze czy znajduje sie ona na liscie");
            //int objekt = int.Parse(Console.ReadLine());
            //var odpowiedz = zad.SprawdzCzyElementZnajdujeSieNaLiscie(lista, objekt);
            //Console.WriteLine(odpowiedz);
            //var NaNieparzystych = zad.WypiszElementyZListyKtoreSaNaNieparzystychPozycjach(lista);
            //Console.WriteLine("Na nieparzystych pozycjach sa: "); 
            //foreach (var liczby in NaNieparzystych)
            /*
            {
                Console.WriteLine(liczby);
            }
            */
            //int asnw = zad.WypiszSumeWszytskichElmentowListy(lista);
            //Console.WriteLine("Suma elementow z listy wynosi: {0}", asnw);
            /*
            Console.WriteLine("Podaj wyraz a ja ci powiem czy jest od palindromem.");
            string wyraz = Console.ReadLine();
            bool odp = zad.CzyWyrazJestPalindromem(wyraz);
            Console.WriteLine(odp);
            */
            //ArrayList polaczona = zad.ZwrocListeZPolaczenia2(lista, chars);
            //ArrayList polaczona2 = zad.ZwrocListeZPolaczenia2NaPrzeminnie(lista, chars);
            /*
            foreach(var cos in polaczona2) 
            {
                Console.WriteLine(cos);
            }
            */
            /*
            ArrayList lista1 = new ArrayList{1,4,5,7,8,10};
            ArrayList lista2 = new ArrayList{2,3,8,6,9,11};
            ArrayList polaczonaPosortowana = zad.ZwrocPosortowanaListeZDwochPosortowanychListV2(lista1, lista2);
            foreach(var cos in polaczonaPosortowana) 
            {
                Console.WriteLine(cos);
            }
            */
            Console.ReadLine();
        }
    }
}
