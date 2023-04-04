using System;
using System.Collections;
using nauka_programowania;
namespace nauka_programowania
{
    class Rekurencje
    {

        //zwaraca liczbe binarna z uzyciem rekurencji przez zmienna
        public void ZwrocLiczbeWSystemieBinarnymRekurencyjnieV1(long liczba, ref string liczbaBinarnaPoZmianie)
        {
            if (liczba == 0)
                return;
            liczbaBinarnaPoZmianie = liczba % 2 + liczbaBinarnaPoZmianie;
            ZwrocLiczbeWSystemieBinarnymRekurencyjnieV1(liczba / 2, ref liczbaBinarnaPoZmianie);
        }

        //zwraca liczbe binarna z uzyciem rekurencji(przekazuje wynik przez 'return')
        public string ZwrocLiczbeWSystemieBinarnymRekurencyjnieV2(long liczba)
        {
            if (liczba == 0)
                return "";
            return ZwrocLiczbeWSystemieBinarnymRekurencyjnieV2(liczba / 2) + liczba % 2;
        }
        //zwraca liczbe binarna z uzyciem petli
        public string ZwrocLiczbeWSystemieBinarnymPetla(long liczba)
        {
            string liczbaBinarna = "";
            while (liczba != 0)
            {
                liczbaBinarna = liczba % 2 + liczbaBinarna;
                liczba = liczba / 2;
            }
            return liczbaBinarna;
        }
        public string ZwrocLiczbeWSystemieBinarnym(long liczba)
        {
            //string liczbaBinarnaPoZmianie = "";
            //ZwrocLiczbeWSystemieBinarnymRekurencyjnieV1(liczba, ref liczbaBinarnaPoZmianie);
            //return liczbaBinarnaPoZmianie;
            //return ZwrocLiczbeWSystemieBinarnymRekurencyjnieV2(liczba);
            return ZwrocLiczbeWSystemieBinarnymPetla(liczba);
        }
        public void Test()
        {
            long liczba = 10;
            var liczbaBinarna = ZwrocLiczbeWSystemieBinarnym(liczba);
            Console.WriteLine(liczbaBinarna);
        }
        //zwraca n-ty wyraz z ciagu
        public double ZwracaNtyWyrazZCiagu(int liczba)
        {
            switch (liczba)
            {
                case 1:
                    return 1;
                case 2:
                    return 0.5;
                default:
                    return -ZwracaNtyWyrazZCiagu(liczba - 1) * ZwracaNtyWyrazZCiagu(liczba - 2);
            }
        }
        public int ZwracaNtyWyrazZCiaguFibonacciego(int liczba)
        {
            switch (liczba)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    return ZwracaNtyWyrazZCiaguFibonacciego(liczba - 1) + ZwracaNtyWyrazZCiaguFibonacciego(liczba - 2);
            }
        }
        public void Test2()
        {
            int liczba = 11;
            var wynik = ZwracaNtyWyrazZCiaguFibonacciego(liczba);
            Console.WriteLine(wynik);
        }
        //sumuje cyfry w liczbie z uzyciem rekurencji
        public long SumaCyfrWLiczbieRekurencyjnie(long liczba)
        {
            if (liczba == 0)
                return 0;
            return SumaCyfrWLiczbieRekurencyjnie(liczba / 10) + liczba % 10;
        }
        public void Test3()
        {
            int liczba = 123;
            var wynik = SumaCyfrWLiczbieRekurencyjnie(liczba);
            Console.WriteLine(wynik);
        }
        //Zwraca licze z ciagu ze strony z uzyciem rekurencji
        public long ZwracaNtyWyrazZCiagu2(long liczba)
        {
            if (liczba == 1)
                return -1;
            return -ZwracaNtyWyrazZCiagu2(liczba - 1) * liczba - 3;
        }
        public void Test4()
        {
            long liczba = 4;
            var wynik = ZwracaNtyWyrazZCiagu2(liczba);
            Console.WriteLine(wynik);
        }
        //zwraca silnie z liczby z uzyciem rekurencji
        public long ZwracaSilnieRekurencyjnie(long liczba)
        {
            if (liczba == 0)
                return 1;
            return ZwracaSilnieRekurencyjnie(liczba - 1) * liczba;
        }
        public void Test5()
        {
            long liczba = 1;
            var wynik = ZwracaSilnieRekurencyjnie(liczba);
            Console.WriteLine(wynik);
        }
    }
}
