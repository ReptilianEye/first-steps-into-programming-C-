using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class ZnajdywanieKNajwiekszego
    {

        public int ZwracaKNajwiekszyElement(List<int> lista, int K)
        {
            List<int> listaNajwiekszych = new List<int>();
            for (int i = 0; i < K + 1; i++)
                listaNajwiekszych.Add(int.MinValue);            //tworzy nowa tablice 'najwiekszych'; dodaje na kazde miejsce najmniejsza mozliwa wartosc int 
            listaNajwiekszych[K] = int.MaxValue;               //dodaje wartownika - najwieksza mozliwa wartosc int, ktora bedzie chronic przez wyjsciem poza index  
            for (int i = 0; i < lista.Count; i++)
            {
                int sprawdzana = lista[i];
                int j = -1;
                while (sprawdzana > listaNajwiekszych[j + 1])       //jesli sprawdzna jest wieksza od pierwszego elementu listyNajwiekszych 
                {
                    j++;                                    
                    listaNajwiekszych[j] = listaNajwiekszych[j + 1];        //przesuwamy wartosci w lewo - znajdujemy odpowiednie miejsce dla sprawdzaniej
                }
                if (j >= 0)                                             //jesli ruszalismy j; bylismy w petli while 
                    listaNajwiekszych[j] = sprawdzana;                  //sprawdzana zostaje wstawiona w znalezione miejsce 
            }
            return listaNajwiekszych[0];                            //zwracamy pierwszy element czyli k-ty najwiekszy
        }
        public int ZwracaKNajwiekszyElementV2(List<int> lista, int maksymalnaWartosc, int K)
        {
            List<int> listaWartosci = new List<int>();
            for (int i = 0; i <= maksymalnaWartosc; i++)            //petla od 0 do najwiekszej wartosci tablicy
                listaWartosci.Add(0);                           //wstawiamy 0; wartosci beda licznikami indexow. 
            for (int i = 0; i < lista.Count; i++)
            {
                listaWartosci[lista[i]]++;                  //zwiekszamy wartosc od indexow w tablicy listaWartosci dla kolejnych liczb z 'listy' 
            }
            int j = listaWartosci.Count - 1;            //j ustawamy na ostatni element listyWartosci
            while (K > 0)                       
            {
                if (K - listaWartosci[j] <= 0)              //jesli K po odjeciu wartosci jest mniejsze lub rowne 0 to znaczy index jest wartoscia k-najwieksza
                    return j;                       //wiec zwracamy k
                else
                    K = K - listaWartosci[j];       //w innym przypadku zmniejszamy wartosc k o wartosci z listyWartosci
                j--;
            }
            return 0;
        }

        public void Test()
        {
            List<int> lista = new List<int> { 1, 4, 3, 5, 1, 7, 2, 5 };
            List<int> lista2 = new List<int> { 1, 4, 5, 2, 5, 3, 2, 1 };
            List<int> lista3 = new List<int> { 1, 5, 3, 2, 6, 3, 2, 7 };
            List<int> lista4 = new List<int> { 1, 4, 10, 3, 6, 6, 2, 2 };

            for (int j = 1; j < lista.Count; j++)
            {
                if (ZwracaKNajwiekszyElement(lista, j) != ZwracaKNajwiekszyElementV2(lista, 7, j))
                    Console.WriteLine("Blad 1");
                if (ZwracaKNajwiekszyElement(lista2, j) != ZwracaKNajwiekszyElementV2(lista2, 5, j))
                    Console.WriteLine("Blad 2");
                if (ZwracaKNajwiekszyElement(lista3, j) != ZwracaKNajwiekszyElementV2(lista3, 7, j))
                    Console.WriteLine("Blad 3");
                if (ZwracaKNajwiekszyElement(lista4, j) != ZwracaKNajwiekszyElementV2(lista4, 10, j))
                    Console.WriteLine("Blad 4");
            }
            Random r = new Random();
            int maksymalnaWartosc = 100;                //zapisujemy maksymalna wartosc ktora bedzie mogla przyjac liczba losowa
            for (int i = 1; i < 100; i++)
            {
                int iloscLiczb = r.Next(1000);                  //zapisujemy losowa liczbe, mniejsza od 1000, ktora bedzie iloscia liczb w liscie 
                List<int> listaLosowych = new List<int>();
                for (int j = 0; j < iloscLiczb; j++)            
                    listaLosowych.Add(r.Next(maksymalnaWartosc));       //dodajemy do listy losowych liczbe, mniejsza od maksymalnej wartosci
                for (int K = 1; i < iloscLiczb; i++)                   //w petli generujemy kolejne k
                    if (ZwracaKNajwiekszyElement(listaLosowych, K) != ZwracaKNajwiekszyElementV2(listaLosowych, maksymalnaWartosc, K))      
                        Console.WriteLine("blad w losowych");                       //jesli wynik jednej funkcji jest inny od drugiej zwracamy komunikat
            }
        }

    }
}