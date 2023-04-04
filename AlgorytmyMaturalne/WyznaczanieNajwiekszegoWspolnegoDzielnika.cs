using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class WyznaczanieNajwiekszegoWspolnegoDzielnika
    {
        //Napisz funkcje ktora wyznaczy najwiekszy wspolny dzielnik z dwoch liczb
        public long ZwrocNWDDwochLiczb(long liczba1, long liczba2)
        {
            while (liczba1 != liczba2)
            {
                if (liczba1 > liczba2)
                    liczba1 = liczba1 - liczba2;
                else
                    liczba2 = liczba2 - liczba1;
            }
            return liczba1;
        }
        public long ZwrocNWDDwochLiczbOptymalnie(long liczba1, long liczba2)
        {
            long wartoscLiczby1;
            while (liczba2 != 0)
            {
                wartoscLiczby1 = liczba1;
                liczba1 = liczba2;
                liczba2 = wartoscLiczby1 % liczba2;

            }
            return liczba1;
        }
        public void Test()
        {
            if (ZwrocNWDDwochLiczb(12, 18) != ZwrocNWDDwochLiczbOptymalnie(12, 18))
                Console.WriteLine("blad 1");
            if (ZwrocNWDDwochLiczb(17, 2) != ZwrocNWDDwochLiczbOptymalnie(17, 2))
                Console.WriteLine("blad 2");
            if (ZwrocNWDDwochLiczb(15, 5) != ZwrocNWDDwochLiczbOptymalnie(15, 5))
                Console.WriteLine("blad 3");
            if (ZwrocNWDDwochLiczb(15, 75) != ZwrocNWDDwochLiczbOptymalnie(15, 75))
                Console.WriteLine("blad 4");
            if (ZwrocNWDDwochLiczb(101, 1) != ZwrocNWDDwochLiczbOptymalnie(101, 1))
                Console.WriteLine("blad 5");
            if (ZwrocNWDDwochLiczb(1,100) != ZwrocNWDDwochLiczbOptymalnie(1,100))
                Console.WriteLine("blad 6");
        }
    }
}