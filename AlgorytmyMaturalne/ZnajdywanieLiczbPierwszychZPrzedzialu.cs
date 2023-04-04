using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class ZnajdywanieLiczbPierwszychWPrzedziale
    {
        //sito Eratostenesa
        //napisz ktora zwroci tablice liczb pierwszych wykorzystujac zasade wedlug ktorej kazda wielokrotnosc liczby pierwszej nie jest liczba pierwsza
        public List<long> ZwracaLiczbyPierwszeZPrzedzialuSitemEratostenesa(long granicaPrzedzialu) //funkcja ta zwraca liste liczb pierwszych przepisujac klucze z dictionary ktore maja wartosc 0
        {
            Dictionary<long, long> PrzedzialLiczb = new Dictionary<long, long>();
            for (long i = 2; i <= granicaPrzedzialu; i++)
            {
                PrzedzialLiczb.Add(i, 0);
            }
            for (long wskaznik = 2; wskaznik <= Math.Sqrt(granicaPrzedzialu); wskaznik++)
            {
                if (PrzedzialLiczb[wskaznik] == 0)
                    for (long mnoznik = wskaznik; wskaznik * mnoznik <= granicaPrzedzialu; mnoznik++) //funkcja sprawdza czy liczba jest liczba pierwsza, mnozac pierwsza wielokrotkosc z kolejnymi liczbami zaczynajac od 2
                        PrzedzialLiczb[wskaznik * mnoznik] = 1;                 //liczbie ktora jest wielokrotnoscia nadaje wartosc 1
            }
            List<long> Pierwsze = new List<long>();
            foreach (int klucz in PrzedzialLiczb.Keys)
                if (PrzedzialLiczb[klucz] == 0)
                    Pierwsze.Add(klucz);                //na koncu dodaje do list wszytskie liczby ktorych wartosci jest rowna 0
            return Pierwsze;
        }
        static public List<long> ZwracaLiczbyPierwszeZPrzedzialuSitemEratostenesaV2(long granicaPrzedzialu)
        {
            bool[] PrzedzialLiczb = new bool[granicaPrzedzialu + 1];                //funkcja dziala podobnie jak ta wyzej tylko ze uzywa bool zamiast int
            long ostatniaDoSprawdzenia = (long)Math.Sqrt(granicaPrzedzialu);        //ostatnia liczbe ktora sprawdzi bedzie pierwiastek z ostatniej liczby w ciagu 
            for (long wskaznik = 2; wskaznik <= ostatniaDoSprawdzenia; wskaznik++)
            {
                if (!PrzedzialLiczb[wskaznik])
                {
                    long wielokrotonosc = wskaznik * wskaznik;
                    while (wielokrotonosc <= granicaPrzedzialu)
                    {
                        PrzedzialLiczb[wielokrotonosc] = true;              //funkcja nadaje wartosc true kazdej wielokrotnosci - czyli liczbie zlozonej (nie-pierwszej)
                        wielokrotonosc = wielokrotonosc + wskaznik;         //funkcja zamiast mnozenia liczby dodaje do siebie wartosc pierwszej
                    }
                }
            }
            List<long> Pierwsze = new List<long>();
            for (long i = 2; i < PrzedzialLiczb.LongLength; i++)
                if (!PrzedzialLiczb[i])                                 //na koncu jesli wartosc w tabeli ma wartosc false funkcja dodaje jej index do listy 
                    Pierwsze.Add(i);
            return Pierwsze;
        }

        //sito liniowe
        //NAJSZYBSZA METODA ZNAJDYWANIA LICZB PIERWSZYCH !!!
        public List<long> ZwracaLiczbyPierwszeZPrzedzialuSitemLiniowym(long granicaPrzedzialu)
        {
            List<long> lista = new List<long>();
            bool[] PrzedzialLiczb = new bool[granicaPrzedzialu + 1];
            long p = 2;
            long q;
            long x;
            while (p * p <= granicaPrzedzialu)
            {
                q = p;
                while (p * q <= granicaPrzedzialu)
                {
                    x = p * q;
                    while (x <= granicaPrzedzialu)
                    {
                        PrzedzialLiczb[x] = true;
                        x = p * x;
                    }
                    do
                        q++;
                    while (PrzedzialLiczb[q]);
                }
                do
                    p++;
                while (PrzedzialLiczb[p]);
            }
            for (long i = 2; i <= granicaPrzedzialu; i++)
                if (!PrzedzialLiczb[i])
                    lista.Add(i);
            return lista;
        }

        //METODY MAJA BLAD - DO NAPRAWY

        // This methid finds all primes 
        // smaller than 'limit' using simple 
        // sieve of eratosthenes. It also stores 
        // found primes in vector prime[] 
        static void simpleSieve(long limit,
                                List<long> prime)
        {
            // Create a boolean array "mark[0..n-1]"  
            // and initialize all entries of it as 
            // true. A value in mark[p] will finally be 
            // false if 'p' is Not a prime, else true. 
            bool[] mark = new bool[limit + 1];

            for (long i = 0; i < mark.Length; i++)
                mark[i] = true;

            for (long p = 2; p * p < limit; p++)
            {
                // If p is not changed, then it is a prime 
                if (mark[p] == true)
                {
                    // Update all multiples of p 
                    for (long i = p * 2; i < limit; i += p)
                        mark[i] = false;
                }
            }

            // Print all prime numbers and store them in prime 
            for (long p = 2; p < limit; p++)
            {
                if (mark[p] == true)
                {
                    prime.Add(p);
                }
            }
        }
        static Dictionary<long, long> segmentedSieve(long n)
        {
            Dictionary<long, long> lista = new Dictionary<long, long>();
            // Compute all primes smaller than or equal 
            // to square root of n using simple sieve 
            long limit = (long)(Math.Floor(Math.Sqrt(n)) + 1);
            List<long> prime = new List<long>();
            simpleSieve(limit, prime);

            // Divide the range [0..n-1] in  
            // different segments We have chosen 
            // segment size as sqrt(n). 
            long low = limit;
            long high = 2 * limit;

            // While all segments of range  
            // [0..n-1] are not processed, 
            // process one segment at a time 
            while (low < n)
            {
                if (high >= n)
                    high = n;

                // To mark primes in current range. 
                // A value in mark[i] will finally 
                // be false if 'i-low' is Not a prime, 
                // else true. 
                bool[] mark = new bool[limit + 1];

                for (long i = 0; i < mark.Length; i++)
                    mark[i] = true;

                // Use the found primes by  
                // simpleSieve() to find 
                // primes in current range 
                for (int i = 0; i < prime.Count; i++)
                {
                    // Find the minimum number in  
                    // [low..high] that is a multiple 
                    // of prime.get(i) (divisible by  
                    // prime.get(i)) For example, 
                    // if low is 31 and prime.get(i) 
                    //  is 3, we start with 33. 
                    long loLim = ((long)Math.Floor((double)(low /
                                (long)prime[i])) * (long)prime[i]);
                    if (loLim < low)
                        loLim += (long)prime[i];

                    /* Mark multiples of prime.get(i) in [low..high]: 
                        We are marking j - low for j, i.e. each number 
                        in range [low, high] is mapped to [0, high-low] 
                        so if range is [50, 100] marking 50 corresponds 
                        to marking 0, marking 51 corresponds to 1 and 
                        so on. In this way we need to allocate space only 
                        for range */
                    for (long j = loLim; j < high; j += (long)prime[i])
                        mark[j - low] = false;
                }

                // Numbers which are not marked as false are prime 
                for (long i = low; i < high; i++)
                    if (mark[i - low] == true)
                        lista.Add(i, i);

                // Update low and high for next segment 
                low = low + limit;
                high = high + limit;
            }
            return lista;
        }

        public void Test()
        {
            LiczbyPierwsze lp = new LiczbyPierwsze();
            long zakres = 100000000;
            var TablicaPierwszych1 = ZwracaLiczbyPierwszeZPrzedzialuSitemEratostenesaV2(zakres);     //wolamy nasza funkcje aby zwrocila nam liste pierwszych do 'zakres'
            var TablicaPierwszych2 = ZwracaLiczbyPierwszeZPrzedzialuSitemLiniowym(zakres);
            if (TablicaPierwszych1.Count != TablicaPierwszych2.Count)
                Console.WriteLine("nie zgadza sie ilosc liczb");
            for (int i = 0; i < TablicaPierwszych1.Count; i++)
            {
                if (TablicaPierwszych1[i] != TablicaPierwszych2[i])                      //jesli liczba pierwsza nie znajduje sie w liscie pierwszych funkcja nas o tym poinformuje 
                    Console.WriteLine("Nie dziala dla liczby {0}", i);
            }
        }
    }
}