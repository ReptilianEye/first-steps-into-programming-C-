using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class PrzeliczanieZZapisuFibonacciego
    {
        public long ZwracaLiczbeWSystemieDziesietnymZSystemuFibonacciego(string liczbaBinarna)
        {
            List<long> ciagFibonacciego = new List<long>();
            ciagFibonacciego.Add(0);
            ciagFibonacciego.Add(1);
            for (int i = 2; i < liczbaBinarna.Length + 1; i++)
            {
                ciagFibonacciego.Add(ciagFibonacciego[i - 1] + ciagFibonacciego[i - 2]);    //generuje kolejne liczby fibonacciego
            }
            long wynikDzisietny = 0;
            for (int i = 0; i < liczbaBinarna.Length; i++)
            {
                if (liczbaBinarna[i] == '1')                      //jesli cyfra w liczba binarnej to 1
                    wynikDzisietny = wynikDzisietny + ciagFibonacciego[liczbaBinarna.Length - i];       //dodaje do wyniku wartnosc liczby z ciagu fibonacciego z odpowiedniego miejsca
            }
            return wynikDzisietny;
        }
        public string ZwracaLiczbeBinarnaWSystemieFibonacciegoZDziesietnego(long liczba)
        {
            List<long> ciagFibonacciego = new List<long>();
            ciagFibonacciego.Add(0);
            ciagFibonacciego.Add(1);
            int i = 2;
            do
            {
                ciagFibonacciego.Add(ciagFibonacciego[i - 1] + ciagFibonacciego[i - 2]);
                i++;                                            //generuje liczby fibonacciego tak dlugo az najwieksza z nich bedzie wieksza od liczby do przekonwertowania
            } while (ciagFibonacciego[i - 1] <= liczba);
            string wynikWBinarnym = "";
            for (int j = ciagFibonacciego.Count - 1; j > 0; j--)
            {
                if (ciagFibonacciego[j] <= liczba)              //jesli kolejna liczba z ciagu fibonacciego jest mniejsza lub rowna do liczby konwertrowanej
                {
                    wynikWBinarnym = wynikWBinarnym + '1';         //dodaje do wyniku "1" 
                    liczba = liczba - ciagFibonacciego[j];          //a liczbe zmniejsza o wartosc liczby fibonacciego
                }
                else
                    wynikWBinarnym = wynikWBinarnym + '0';          //gdy nie jest wieksza - dodaje "0"
            }
            wynikWBinarnym = wynikWBinarnym.TrimStart('0');         //pozbywa sie "0" z poczatku wyniku - one nie sa potrzebne
            return wynikWBinarnym;
        }
        public void Test()
        {
            for (long i = 1; i < 100000; i++)
            {
                string wynik = ZwracaLiczbeBinarnaWSystemieFibonacciegoZDziesietnego(i);            //przekazuje liczbe do zamiany na system binarny
                long wynikDzisietny = ZwracaLiczbeWSystemieDziesietnymZSystemuFibonacciego(wynik);  //liczbe z systemu binarnego zmienia ponownie na dziesietny
                if (wynikDzisietny != i)                                                            //jesli liczba poczatkowa nie rowna sie tej przekonwertowanej
                    Console.WriteLine("Blad: wynik nie rowna sie pierwotnej liczbie {0}", i);       //program poinformuje nas o tym
            }
        }
    }
}