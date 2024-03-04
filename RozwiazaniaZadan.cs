using System;
using System.Collections;
using System.Collections.Generic;

namespace nauka_programowania
{
    class CiagILicznik
    {
        public Dictionary<int, int> Ciag = new Dictionary<int, int>();
        public int Licznik;
    }
    class RozwiazaniaZadan
    {
        //Write a function that returns the largest element in a list.
        public int ZwrocNajwiekszyElementZListy(ArrayList lista)
        {
            int najwieksza;
            if (lista.Count == 0)
            {
                return 0;
            }
            else
            {
                najwieksza = (int)lista[0];
            }
            foreach (var element in lista)
            {
                if (najwieksza < (int)element)
                {
                    najwieksza = (int)element;
                }
            }
            return najwieksza;
        }
        //Write function that reverses a list, preferably in place.
        public ArrayList ZwrocOdwroconaListe(ArrayList lista)
        {
            lista.Reverse();
            return lista;
        }
        //Write a function that checks whether an element occurs in a list.
        public Boolean SprawdzCzyElementZnajdujeSieNaLiscie(ArrayList lista, int element)
        {
            foreach (int liczba in lista)
            {
                if (liczba == element)
                {
                    return true;
                }
            }
            return false;
        }
        //Write a function that returns the elements on odd positions in a list.
        public ArrayList ZwracaListeElementowZListyKtoreSaNaNieparzystychPozycjach(ArrayList lista)
        {
            ArrayList nieparzyste = new ArrayList();
            for (int i = 1; i < lista.Count; i = i + 2)
            {
                nieparzyste.Add(lista[i]);
            }
            return nieparzyste;
        }
        //Write a function that computes the running total of a list.
        public int ZwrocSumeWszytskichElmentowListy(ArrayList lista)
        {
            int suma = 0;
            foreach (int numer in lista)
            {
                suma = suma + numer;
            }
            return suma;
        }
        //Write a function that tests whether a string is a palindrome.
        public Boolean CzyWyrazJestPalindromem(string wyraz)
        {
            for (int i = 0; i < wyraz.Length / 2; i++)
            {
                if (wyraz[i] != wyraz[wyraz.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
        //Write three functions that compute the sum of the numbers in a list: using a for-loop, a while-loop and recursion. (Subject to availability of these constructs in your language of choice.)



        //Write a function that concatenates two lists. [a,b,c], [1,2,3] → [a,b,c,1,2,3]
        public ArrayList ZwrocListeZPolaczeniaDwoch(ArrayList lista1, ArrayList lista2)
        {
            //lista1.AddRange(lista2);
            //return lista1;
            ArrayList PolaczonaLista = new ArrayList();
            foreach (var liczba in lista1)
            {
                PolaczonaLista.Add(liczba);
            }
            foreach (var element in lista2)
            {
                PolaczonaLista.Add(element);
            }
            return PolaczonaLista;
        }
        //Write a function that combines two lists by alternatingly taking elements, e.g. [a,b,c], [1,2,3] → [a,1,b,2,c,3].
        public ArrayList ZwrocListeZPolaczeniaDwóchNaPrzeminnie(ArrayList lista1, ArrayList lista2)
        {
            ArrayList polaczonaLista = new ArrayList();
            for (int i = 0; i < lista1.Count || i < lista2.Count; i++)
            {
                if (i < lista1.Count)
                    polaczonaLista.Add(lista1[i]);
                if (i < lista2.Count)
                    polaczonaLista.Add(lista2[i]);
            }
            return polaczonaLista;
        }
        //Write a function that merges two sorted lists into a new sorted list. [1,4,6],[2,3,5] → [1,2,3,4,5,6]. You can do this quicker than concatenating them followed by a sort.
        public ArrayList ZwrocPosortowanaListeZDwochPosortowanychList(ArrayList lista1, ArrayList lista2)
        {
            ArrayList lista = new ArrayList();
            int a = 0;
            int b = 0;
            int elem1;
            int elem2;
            while (a < lista1.Count || b < lista2.Count)
            {
                if (a < lista1.Count)
                    elem1 = (int)lista1[a];
                else
                    elem1 = int.MaxValue;
                if (b < lista2.Count)
                    elem2 = (int)lista2[b];
                else
                    elem2 = int.MaxValue;
                if (elem1 < elem2)
                {
                    lista.Add(elem1);
                    a++;
                }
                else
                {
                    lista.Add(elem2);
                    b++;
                }
            }
            return lista;
        }
        public ArrayList ZwrocPosortowanaListeZDwochPosortowanychListV2(ArrayList lista1, ArrayList lista2)
        {
            ArrayList lista = new ArrayList();
            int elem1;
            int elem2;
            while (0 != lista1.Count || 0 != lista2.Count)
            {
                if (lista1.Count != 0)
                    elem1 = (int)lista1[0];
                else
                    elem1 = int.MaxValue;
                if (lista2.Count != 0)
                    elem2 = (int)lista2[0];
                else
                    elem2 = int.MaxValue;
                if (elem1 < elem2)
                {
                    lista.Add(lista1[0]);
                    lista1.RemoveAt(0);
                }
                else
                {
                    lista.Add(lista2[0]);
                    lista2.RemoveAt(0);
                }

            }
            return lista;
        }
        // posortuj 3 zmienne rosnaco
        public List<int> Posortuj3LiczbyRosnaco(int a, int b, int c, List<int> lista)
        {
            if (a < b)
            {
                if (a < c)
                {
                    lista.Add(a);
                    if (b < c)
                    {
                        lista.Add(b);
                        lista.Add(c);
                        return lista;
                    }
                    else
                    {
                        lista.Add(c);
                        lista.Add(b);
                        return lista;
                    }
                }
            }
            else
                Posortuj3LiczbyRosnaco(c, a, b, lista);
            return lista;
        }
        public void Test()
        {
            List<int> DoPosortowania = new List<int>();
            var lista = Posortuj3LiczbyRosnaco(3, 2, 1, DoPosortowania);
            foreach (var element in lista)
                Console.WriteLine(element);
        }
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //**********************************************************************************************************************************
        //********************************************************************************************************************************** 


        //Napisz funkcje ktora zwraca najdluzszy rosnacy ciag cyfr z podanego ciagu liczb
        public void NajdluzszyCiagZUzyciemWspolrzednych(List<int> ciagLiczb)
        {
            int poczatekNajdluzszego = 0;
            int koniecNajdluzszego = 0;
            int koncowa = 0;
            int poczatkowa = 0;
            for (int i = 0; i < ciagLiczb.Count - 1; i++)
            {
                if (ciagLiczb[i + 1] <= ciagLiczb[i]) //nastepna jest mnniejsza lub rowna
                {
                    koncowa = i;
                    if (koncowa - poczatkowa > koniecNajdluzszego - poczatekNajdluzszego)
                    {
                        poczatekNajdluzszego = poczatkowa;
                        koniecNajdluzszego = koncowa;
                    }
                    poczatkowa = i + 1;
                }
                else
                    koncowa = i + 1;
            }
            if (koncowa - poczatkowa > koniecNajdluzszego - poczatekNajdluzszego)
            {
                poczatekNajdluzszego = poczatkowa;
                koniecNajdluzszego = koncowa;
            }
            for (int wys = poczatekNajdluzszego; wys <= koniecNajdluzszego; wys++)
                Console.Write("{0} ", ciagLiczb[wys]);
        }
        public void NajdluzszyCiagZUzyciemWspolrzednychV2(List<int> ciagLiczb)
        {
            int maxDlugosc = 1;
            int poczatek = 0;
            int dlugosc = 1;
            int pomocniczyPoczatek = 0;
            for (int i = 1; i < ciagLiczb.Count; i++)
            {
                if (ciagLiczb[i] > ciagLiczb[i - 1])
                {
                    dlugosc++;
                    if (dlugosc > maxDlugosc)
                    {
                        maxDlugosc = dlugosc;
                        poczatek = pomocniczyPoczatek;
                    }
                }
                else
                {
                    pomocniczyPoczatek = i;
                    dlugosc = 1;
                }
            }
            for (int i = poczatek; i < poczatek + maxDlugosc; i++)
                Console.WriteLine(ciagLiczb[i]);
        }
        public void Test1()
        {
            List<int> listaLiczb = new List<int> { 2, 0, 1, 3, 4, 5, 6 };
            NajdluzszyCiagZUzyciemWspolrzednychV2(listaLiczb);
        }

        /* 
        **********************************************************************************************************************************
        **********************************************************************************************************************************
        **********************************************************************************************************************************
        **********************************************************************************************************************************
        **********************************************************************************************************************************
        **********************************************************************************************************************************
        */

        //znajdz ile liczb pomiedzy 1 a 'n' jest jednoczesnie palindromami i pierwszymi
        public void WypiszLiczbyPierwszeKtoreSaPalindromamiDoskonalymi(long n)
        {
            LiczbyPierwsze lp = new LiczbyPierwsze();
            List<long> listaPierwszychIPalindromow = new List<long>();
            for (long i = 0; i <= n; i++)
                if (CzyWyrazJestPalindromem(Convert.ToString(i)))
                    //if (lp.CzyTaLiczbaJestLiczbaPierwszaOptymalnie(i))
                    if (CzyWyrazJestPalindromemDoskonalymILiczbaPierwszaJednoczesnie(Convert.ToString(i)))
                        listaPierwszychIPalindromow.Add(i);
            //czy skacajac palindrom z obu stron jednoczesnie, jest on nadal liczba pierwsza - cudowny palindrom            

            foreach (var element in listaPierwszychIPalindromow)
                Console.WriteLine(element);
        }
        public Boolean CzyWyrazJestPalindromemDoskonalymILiczbaPierwszaJednoczesnie(string wyraz)
        {
            LiczbyPierwsze lp = new LiczbyPierwsze();
            Stack<string> skroconeWyrazy = new Stack<string>();
            while (wyraz.Length > 0)
            {
                if (wyraz.Length == 1)
                {
                    skroconeWyrazy.Push(wyraz);
                    break;
                }
                skroconeWyrazy.Push(wyraz);
                wyraz = wyraz.Substring(1, wyraz.Length - 2);
            }
            foreach (var element in skroconeWyrazy)
                if (!lp.CzyTaLiczbaJestLiczbaPierwszaOptymalnie(Convert.ToInt64(element)))
                    return false;
            return true;
        }
        public void Test2()
        {
            long n = 100000000;
            WypiszLiczbyPierwszeKtoreSaPalindromamiDoskonalymi(n);
        }
        /* 
           *************************************************************************************************************
           *************************************************************************************************************
           *************************************************************************************************************
           *************************************************************************************************************
           *************************************************************************************************************
           *************************************************************************************************************
        */
        public long ZwrocDwusilnieLiczby(long n)
        {
            if (n == 2)
                return 2;
            if (n == 1)
                return 1;
            return ZwrocDwusilnieLiczby(n - 2) * n;
        }
        public long ZwrocDwusilnieLiczbyV2(long n)
        {
            long wynik = n;
            while (n > 0)
            {
                if (n == 2)
                    return wynik;
                if (n == 1)
                    return wynik;
                wynik = wynik * (n - 2);
                n = n - 2;
            }
            return wynik;
        }
        public long ZwrocDwusilnieLiczbyV3(long n)
        {
            long wynik = 1;
            if (n % 2 == 0)
                for (long i = 2; i <= n; i = i + 2)
                    wynik = wynik * i;
            else
                for (long i = 1; i <= n; i = i + 2)
                    wynik = wynik * i;
            return wynik;
        }
        public void Test3()
        {
            //long wynik = ZwrocDwusilnieLiczbyV3(n);
            for (int i = 1; i <= 100; i++)
            {
                if (ZwrocDwusilnieLiczby(i) != ZwrocDwusilnieLiczbyV3(i))
                    Console.WriteLine("Zle dziala dla {0} ", i);
            }
            //Console.WriteLine(wynik);
        }
        /*  *************************************************************************************************************
            *************************************************************************************************************
            *************************************************************************************************************
            *************************************************************************************************************
            *************************************************************************************************************
            *************************************************************************************************************
         */
        public Boolean CzySumaCyfrWSystemieDziesiatkowymRownaSieTejWSystemieBinarnym(long liczba)
        {
            if (ZwrocSumeCyfrWSystemieDziesietnymRekurencyjnie(liczba) == ZwrocSumeCyfrWSystemieBinarnymRekurencyjnie(liczba))
                return true;
            return false;
        }
        public void WypiszLiczbyDlaKtorychSumaCyfrWSystemieBinarmymIDziesietnymJestRowna(long pierwszaLiczba, long drugaLiczba)
        {
            for (long i = pierwszaLiczba; i <= drugaLiczba; i++)
                if (CzySumaCyfrWSystemieDziesiatkowymRownaSieTejWSystemieBinarnym(i))
                    Console.WriteLine("Dla liczby {0} rowna sie", i);
        }
        public long ZwrocSumeCyfrWSystemieBinarnymRekurencyjnie(long liczba)
        {
            if (liczba == 0)
                return 0;
            return ZwrocSumeCyfrWSystemieBinarnymRekurencyjnie(liczba / 2) + liczba % 2;
        }
        public long ZwrocSumeCyfrWSystemieDziesietnymRekurencyjnie(long liczba)
        {
            if (liczba == 0)
                return 0;
            return ZwrocSumeCyfrWSystemieDziesietnymRekurencyjnie(liczba / 10) + liczba % 10;
        }
        public void Test4()
        {
            Console.WriteLine("Witaj w programie sprawdzajcym czy suma cyfr w systemie binarnym jest rowna tej z systemy dziesietnego dla ktorejs z liczb z zakresu");
            Console.WriteLine("Podaj dwie liczby, jedna po drugiej");
            long pierwszaLiczba = Convert.ToInt64(Console.ReadLine());
            long drugaLiczba = Convert.ToInt64(Console.ReadLine());
            WypiszLiczbyDlaKtorychSumaCyfrWSystemieBinarmymIDziesietnymJestRowna(pierwszaLiczba, drugaLiczba);
        }
    }
}
