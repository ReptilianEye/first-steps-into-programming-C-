using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class Permutacje
    {
        public void ZwracaPermutacjeRekrencyjnie(List<int> lista, List<List<int>> listaPermutacji, List<int> Permutacja)
        {
            if (Permutacja.Count == lista.Count)
            {
                List<int> tymczasowa = new List<int>();
                foreach (var element in Permutacja)
                    tymczasowa.Add(element);
                listaPermutacji.Add(tymczasowa);
                //foreach (var element in Permutacja)
                //    Console.Write(element);
                //Console.WriteLine();
            }
            else
                for (int i = 0; i < lista.Count; i++)
                {
                    if (!Permutacja.Contains(lista[i]))
                    {
                        Permutacja.Add(lista[i]);
                        ZwracaPermutacjeRekrencyjnie(lista, listaPermutacji, Permutacja);
                    }
                }
            if (Permutacja.Count != 0)
                Permutacja.RemoveAt(Permutacja.Count - 1);

        }
        //Warunek B speniaja permutacje, których suma liczb bedacych tak samo oddalonej od srodka liczby jest rowna kazdej innej sumie liczb tak samo oddalonej od srodka
        public bool SprawdzaCzyPermutacjaSpelniaWarunekB(List<int> Permutacje)
        {
            int j = 0;
            int k = Permutacje.Count - 1;
            int suma = Permutacje[j] + Permutacje[k];
            while (Permutacje[j] + Permutacje[k] == suma)
            {
                if (j >= Permutacje.Count / 2)
                    return true;
                j++;
                k--;
            }
            return false;
        }
        public bool SprawdzaCzyPermutacjaSpelniaWarunekC(List<int> Permutacje, int k, int m)
        {

            k = k - 1;
            if (m <= k)
                return false;
            if (Permutacje[k] != m)
                return false;
            for (int i = 1; i <= k; i++)
            {
                if (Permutacje[i - 1] > Permutacje[i])
                    return false;
            }
            return true;
        }
        public void Test()
        {
            List<int> lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> Permutacje = new List<int>();
            List<List<int>> listaPermutacji = new List<List<int>>();
            ZwracaPermutacjeRekrencyjnie(lista, listaPermutacji, Permutacje);
            int licznikPermutacjiSpelniajacychWarunek = 0;
            foreach (var permutacje in listaPermutacji)
            {
                if (SprawdzaCzyPermutacjaSpelniaWarunekB(permutacje))
                {
                    foreach (var element in permutacje)
                        Console.Write(element);
                    Console.WriteLine();
                    licznikPermutacjiSpelniajacychWarunek++;
                }
            }
            Console.WriteLine(licznikPermutacjiSpelniajacychWarunek);
        }
        public void Test2()
        {
            List<int> lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> Permutacje = new List<int>();
            List<List<int>> listaPermutacji = new List<List<int>>();
            ZwracaPermutacjeRekrencyjnie(lista, listaPermutacji, Permutacje);
            int licznikPermutacjiSpelniajacychWarunek = 0;
            //Console.WriteLine("Podaj wartosc 'm', a nastepnie wartosc 'k'");
            //int m = Convert.ToInt32(Console.ReadLine());
            //int k = Convert.ToInt32(Console.ReadLine());
            Rekurencje r = new Rekurencje();
            int n = listaPermutacji[0].Count;
            for (int m = 3; m <= n; m++)
                for (int k = 2; k < m; k++)
                {
                    licznikPermutacjiSpelniajacychWarunek = 0;
                    foreach (var permutacje in listaPermutacji)
                    {
                        if (SprawdzaCzyPermutacjaSpelniaWarunekC(permutacje, k, m))
                        {
                            /*Console.WriteLine("Permutacja spelnia warunek dla m = {0} i k = {1}", m, k);
                            foreach (var element in permutacje)
                                Console.Write(element);
                            Console.WriteLine();
                            Console.WriteLine();*/
                            licznikPermutacjiSpelniajacychWarunek++;
                        }
                    }
                    long wynikZeWzoru = r.ZwracaSilnieRekurencyjnie((m - 1)) * r.ZwracaSilnieRekurencyjnie((n - k)) /
                                           (r.ZwracaSilnieRekurencyjnie(k - 1) * r.ZwracaSilnieRekurencyjnie(m - k));
                    if (wynikZeWzoru == licznikPermutacjiSpelniajacychWarunek)
                        Console.WriteLine("zgadza sie dla n = {0}, m = {1}, k = {2} wynik jest rowny: {3} i {4}", n, m, k,
                                            wynikZeWzoru, licznikPermutacjiSpelniajacychWarunek);
                    else
                        Console.WriteLine("NIE zgadza sie dla n = {0}, m = {1}, k = {2} wynik jest rowny: {3} i {4}", n, m, k,
                                                                    wynikZeWzoru, licznikPermutacjiSpelniajacychWarunek);


                }
        }
    }
}
