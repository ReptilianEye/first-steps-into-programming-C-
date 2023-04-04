using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class Sortowanie
    {
        //metoda bobelkowa - metoda bobelkowa polega na przechodzeniu po liscie i wyciaganiu na sam koniec najwiekszej liczby
        public List<int> ZwracaListePosortowanaMetodaBobelkowa(List<int> lista)
        {
            for (int i = 0; i < lista.Count; i++)    //petla 'i' idzie po listach                   
            {
                bool CzyZmienilo = false;
                for (int j = 0; j < lista.Count - 1 - i; j++)       //petla 'j' idzie po elementach listy
                {
                    if (lista[j + 1] < lista[j])
                    {
                        int pomocnicza = lista[j];              //funkcja ta zmienia miejscami wartosci list jesli zobaczy ze pierwsza z sasiadujacych ze soba liczb jest wieksza niz druga
                        lista[j] = lista[j + 1];
                        lista[j + 1] = pomocnicza;
                        CzyZmienilo = true;                 //zmienna 'CzyZmienilo' dostaje wartosc true jesli petla zmieni miejscami liczby w liscie 
                    }
                }
                if (!CzyZmienilo)               //jesli nie 'CzyZmienilo' ma wartosc false to znaczy ze lista jest juz posortowana, a wiec petla moze sie skonczyc 
                    break;
            }
            return lista;
        }
        public List<int> ZwracaListePosortowanaMetodaBobelkowaDwukierunkowa(List<int> lista)
        {
            int poczatkowaWartosc = 0;
            int koncowaWartosc = lista.Count - 1;
            bool CzyZmienilo = false;
            int p = 0;
            do
            {
                CzyZmienilo = false;
                for (int j = poczatkowaWartosc; j < koncowaWartosc; j++)       //petla 'j' idzie po elementach listy
                {
                    if (lista[j + 1] < lista[j])
                    {
                        int pomocnicza = lista[j];              //funkcja ta zmienia miejscami wartosci list jesli zobaczy ze pierwsza z sasiadujacych ze soba liczb jest wieksza niz druga
                        lista[j] = lista[j + 1];
                        lista[j + 1] = pomocnicza;
                        p = j;
                        CzyZmienilo = true;                 //zmienna 'CzyZmienilo' dostaje wartosc true jesli petla zmieni miejscami liczby w liscie 
                    }
                }
                koncowaWartosc = p;
                if (!CzyZmienilo)
                    break;
                CzyZmienilo = false;
                for (int j = koncowaWartosc; j > poczatkowaWartosc; j--)       //petla 'j' idzie po elementach listy
                {
                    if (lista[j - 1] > lista[j])
                    {
                        int pomocnicza = lista[j];              //funkcja ta zmienia miejscami wartosci list jesli zobaczy ze pierwsza z sasiadujacych ze soba liczb jest wieksza niz druga
                        lista[j] = lista[j - 1];
                        lista[j - 1] = pomocnicza;
                        p = j;
                        CzyZmienilo = true;                 //zmienna 'CzyZmienilo' dostaje wartosc true jesli petla zmieni miejscami liczby w liscie 
                    }
                }
                poczatkowaWartosc = p;
            } while (CzyZmienilo);  //jesli nie 'CzyZmienilo' ma wartosc false to znaczy ze lista jest juz posortowana, a wiec petla moze sie skonczyc 
            return lista;
        }

        //METODA WYBORU - WYBIERA NAJMNIEJSZA LICZBE I USTAWIA JA NA PIERWSZA POZYCJE, NATSTEPNIE DLA WICENAJMNIEJSZEJ - NA DRUGA POZYCJE
        //PRZY USTAWIANIU NIE PATRZY NA SASIADUJACE LICZBY
        public List<int> ZwracaListePosortowanaMetodaWyboru(List<int> lista)
        {
            int indexNajmnniejszej = 0;
            for (int i = 0; i < lista.Count - 1; i++)
            {
                indexNajmnniejszej = i;
                for (int j = i + 1; j < lista.Count; j++)       //petla 'j' idzie po elementach listy w poszukiwaniu najmniejszego elementu
                    if (lista[j] < lista[indexNajmnniejszej])
                        indexNajmnniejszej = j;
                int pomocnicza = lista[indexNajmnniejszej];     //wstawienie znalezionego najmniejszego elementu na pierwsze nieposortowane miejsce
                lista[indexNajmnniejszej] = lista[i];           //a wartosci z pierwszego 'i' miejsca na miejsce gdzie byl najmniejszy element
                lista[i] = pomocnicza;
            }
            return lista;
        }

        //METODA WSTAWIANIA - USTAWIA KAZDA LICZBE NA ODPOWIEDNIE MIEJSCE - POMIEDZY INNYMI
        //PATRZY NA SASIADUJACE LICZBY


        public List<int> ZwracaListePosortowanaMetodaWstawiania(List<int> lista)
        {
            int pomocnicza = 0;
            for (int i = 0; i < lista.Count - 1; i++)
            {
                if (lista[i + 1] < lista[i])
                    for (int j = i; j >= 0; j--)
                    {
                        if (lista[j] < lista[i + 1])            //funkcja znajduje odpowiednie odpowietne miejsce
                        {
                            pomocnicza = lista[i + 1];
                            lista.RemoveAt(i + 1);                  //usowa liczbe z poprzedniego miejsce
                            lista.Insert(j + 1, pomocnicza);        //i metoda insert wciska te sama liczbe w odpowienie miejsce - wczesniej znalezione
                            break;
                        }
                        if (j == 0)
                        {
                            pomocnicza = lista[i + 1];
                            lista.RemoveAt(i + 1);
                            lista.Insert(j, pomocnicza);
                        }
                    }
            }
            return lista;
        }
        public List<int> ZwracaListePosortowanaMetodaWstawianiaV2(List<int> lista)  //funkcja gdy znajdzie liczbe ktora nie jest posortowana
        {
            int pomocnicza = 0;
            for (int i = 0; i < lista.Count - 1; i++)
            {
                int j = i;
                while (j >= 0 && lista[j + 1] < lista[j])         //kiedy liczba ktora przesowamy bedzie wieksza od kolejnej od prawej liczby lub dojdziemy do poczatku    
                {
                    pomocnicza = lista[j + 1];              //przesowa ja w lewa strone 
                    lista[j + 1] = lista[j];                //zamieniajac miejscami ja z kolejnymi od prawej liczbami
                    lista[j] = pomocnicza;
                    j--;                                   //jesli sie tak nie stanie oznaczac to bedzie ze przesowana liczba byla najmniejsza w zbiorze
                }                                          // a wiec ustawiana jest na koncu
            }
            return lista;
        }
        //Sortowanie kubelkowe
        public List<int> ZwracaPosortowanaListeKubelkowo(List<int> listaNieposortowana, int maksymalnyZakres)
        {
            int[] listaKubelkow = new int[maksymalnyZakres + 1];
            foreach (int liczba in listaNieposortowana)
                listaKubelkow[liczba]++;
            List<int> listaPosortowana = new List<int>();
            for (int i = 0; i < maksymalnyZakres; i++)
            {
                if (listaKubelkow[i] > 0)
                    for (int j = 1; j <= listaKubelkow[i]; j++)
                        listaPosortowana.Add(i);
            }
            return listaPosortowana;
        }
        public List<int> ZwracaPosortowanaListeKubelkowoZDictionary(List<int> listaNieposortowana, int maksymalnyZakres)
        {
            Dictionary<int, int> listaKubelkow = new Dictionary<int, int>();
            foreach (int liczba in listaNieposortowana)
                if (listaKubelkow.ContainsKey(liczba))
                    listaKubelkow[liczba]++;
                else
                    listaKubelkow.Add(liczba, 1);
            List<int> listaPosortowana = new List<int>();
            for (int i = 0; i < maksymalnyZakres + 1; i++)
                if (listaKubelkow.ContainsKey(i))
                    for (int j = 1; j <= listaKubelkow[i]; j++)
                        listaPosortowana.Add(i);
            return listaPosortowana;
        }

        //quickSort
        //metoda QuickSort wykorzystuje zasade  Divide and Conquer ("dziel i zwyciezaj"). Metoda polega na tym aby podzielic zbior wzgledem wybranej wartosci - podzielic na dwie PARTYCJE
        //Nastepnie zrobic to samo z z dwoma otrzymanymi partycjami, dzielac zbior wartosci na mniejsze zbiory coraz dokladniej posortowane
        //Po pierwszym obiegu metody zbior jest podzielony na dwa podzbiory w taki sposob, ze po lewej stronie od wartosci v sa liczby mniejsze i rowne a po prawej: wieksze i rowne 
        public void SortujeMetodaQuickSort(ref List<int> lista, int poczatek, int koniec)
        {
            int v = DzielNaPartycje(ref lista, poczatek, koniec);
            if (poczatek < v - 1)
                SortujeMetodaQuickSort(ref lista, poczatek, v - 1);
            if (koniec > v + 1)
                SortujeMetodaQuickSort(ref lista, v + 1, koniec);
        }
        public int DzielNaPartycje(ref List<int> lista, int poczatek, int koniec)
        {
            int v = lista[poczatek];            //v bedzie wartoscia wzgledem ktorej bedziemy sortowali
            int i = poczatek;
            int j = koniec + 1;
            while (i < j)                             //dopoki poczatek jest mniejszy od konca
            {
                do
                    i++;
                while (i < koniec && lista[i] < v);   //zwiekszamy i a nastepnie sprawdzamy czy mniejsza od listy[i]; jesli jest to zwiekszamy i tak dlugo az liczba na liscie nie spelni tego warunku
                do
                    j--;
                while (j > poczatek && lista[j] > v);   //to samo co z i robimy z j, ale j zmniejszamy, poniewaz idzie ono od tylu
                if (i < j)
                {
                    int pom = lista[j];         //zamieniamy wartosciamy wartosc przy 'j' i przy 'i'
                    lista[j] = lista[i];
                    lista[i] = pom;
                }
            }                                   //na koniec gdy i "wyprzedzi" y
            lista[poczatek] = lista[j];         //na poczatku stawiamy wartosc ostatniej listy[j]    
            lista[j] = v;                       //a na miejsce listy[j] wstawiamy wartosc v, czyli pieczetujemy sortowanie
            return j;
        }
        public int ZwracaMedianeWyszukiwaniemSzybkim(List<int> lista)
        {
            var poczatek = 0;
            var koniec = lista.Count - 1;
            int mediana = lista.Count / 2;
            int v;            
            int i;
            int j;
            do
            {
                v = lista[poczatek];            
                i = poczatek;
                j = koniec + 1;
                while (i < j)                           
                {
                    do
                        i++;
                    while (i < koniec && lista[i] < v);             //wyszkiwanie szybkie dziala na bardzo podobnej zasadzie co sortowanie szybkie 
                    do                                              //ale nie sortuje calego zbioru, a jedynie czesc ktory jest potrzebna do znalezienia szukanej wartosci
                        j--;
                    while (j > poczatek && lista[j] > v); 
                    if (i < j)
                    {
                        int pom = lista[j];         
                        lista[j] = lista[i];
                        lista[i] = pom;
                    }
                }                                   
                lista[poczatek] = lista[j];         
                lista[j] = v;
                if (j == mediana)                            //roznica polega na tym, ze zwracamy wartosc mediany kiedy zmienna pomocnicza 'j' dojdzie do indexu mediany
                    return lista[mediana];                   //oznacza to, ze pozostawione elementy sa na dobrych miejscach i mozna zwrocic wartosc mediany                
                if (mediana < j)
                    koniec = j - 1;                         //jesli jednak 'j' nie rowna sie wartosci mediany 
                else                                     //przesowamy granice przedzialu o obszar w ktorym pozycje wartosci zostaly juz ustalone
                    poczatek = j + 1;
            } while (j != mediana);                      
            return 0;
        }
        public int ZwracaMedianeMetodaWirtha(List<int> lista)
        {
            int mediana = lista.Count / 2;          //oblicza pozycje mediany
            int poczatek = 0;
            int koniec = lista.Count - 1;
            while (poczatek < koniec)
            {
                int v = lista[mediana];         //oblicz wartosc aktualnej mediany - bedzie do niej porownywal pozostale elementy
                int i = poczatek;
                int j = koniec;
                do
                {
                    while (lista[i] < v)       //szuka elementu wiekszego do mediany (stojacego na zlym miejscu) od lewej za pomoca 'i'
                        i++;
                    while (lista[j] > v)      //szuka elemetu mniejszego od miediany (stojacego na zlym miejscu) od prawej za pomoca 'j'
                        j--;
                    if (i <= j)             //sprawdza czy 'i' i 'j' znajduja sie po odpowiednich stronach wzgledem siebie; 
                    {                          //(czy nie zamieniaja miejscami wartosci, ktore juz byly na dobrych miejscach)
                        int pom = lista[j];         
                        lista[j] = lista[i];        //zamienia miejscami wartosci
                        lista[i] = pom;
                        i++;                    //przesowa 'i' i 'j' o jedno do srodka
                        j--;    
                    }
                } while (i <= j);               
                if (j < mediana)            //jesli zmienne 'i' i 'j' sa w zlym miejscu (wyminely sie)
                    poczatek = i;           //zmniejszamy obszar przeszukiwania o obszar na ktorym wiemy ze nie ma juz wartosci na zlych miejscach  
                if (i > mediana)
                    koniec = j;
            }                               //gdy juz ustawilismy wszystkie wartosci prawidlowo
            return lista[mediana];          //mozemy zwrocic wartosc ktora jest na inexie mediany - ma tyle samo elementow mniejszych i rownych co mniejszych i rownych
        }
        public void Test()
        {
            Random r = new Random();
            for (int licznikTestow = 0; licznikTestow < 1000; licznikTestow++)
            {
                List<int> lista1 = new List<int>();
                List<int> lista2 = new List<int>();
                int dlugoscListy = r.Next(1000);
                for (int i = 0; i < dlugoscListy; i++)
                {
                    int losowa = r.Next(1000);
                    lista1.Add(losowa);
                    lista2.Add(losowa);
                }
                var lista1Posortowana = ZwracaListePosortowanaMetodaWstawianiaV2(lista1);
                SortujeMetodaQuickSort(ref lista2, 0, lista2.Count - 1);
                var lista2Posortowana = lista2;
                for (int i = 0; i < dlugoscListy; i++)
                    if (lista1Posortowana[i] != lista2Posortowana[i])
                        Console.WriteLine("blad 2");
            }
        }
        public void Test2()
        {
            List<int> lista = new List<int> { 2, 3, 4, 5, 3, 2, 4, 2, 7, 8, 6, 3, 2, 1 };
            var wynik = ZwracaMedianeMetodaWirtha(lista);
            Random r = new Random();
            for (int j = 0; j < 100; j++)
            {
                List<int> lista1 = new List<int>();
                List<int> lista2 = new List<int>();
                int losowa = r.Next(1000);
                for (int i = 0; i < losowa; i++)
                {
                    int wylosowana = r.Next(100);
                    lista1.Add(wylosowana);
                    lista2.Add(wylosowana);
                }
                if (ZwracaMedianeMetodaWirtha(lista1) != ZwracaMedianeWyszukiwaniemSzybkim(lista2))
                    Console.WriteLine("blad 1");
            }
        }
    }
}