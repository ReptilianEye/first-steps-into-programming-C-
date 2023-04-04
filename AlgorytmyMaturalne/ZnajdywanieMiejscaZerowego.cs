using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class ZnajdywanieMiejscaZerowego
    {
        //Napisz funkcje ktora znajdzie miejsce zerowe funkcji metoda polawiania

        public double Func1(double x)
        {
            return x;
        }

        public double Func2(double x)
        {
            return 2 * x * x - x ;
        }

        public double ZwrocMiejsceZeroweMetodaPolawianiaPrzedzialow(Func<double, double> f, double a, double b, double dokladnosc = 0.000001)
        {
            double srodek;
            if (f(a) * f(b) > 0)
            {
                throw new Exception("nie ma miejsca zerowego dla tych wspolrzednych");
            }
            while (Math.Abs(a - b) > dokladnosc)
            {
                srodek = ((b - a) / 2) + a;
                if (f(a) * f(srodek) <= 0)
                    b = srodek;
                else
                    a = srodek;
            };
            return (b - a) / 2 + a;
        }
        public void Test()
        {
            for (double i = 10; i < 10000; i++)
            {
                    var wynik = ZwrocMiejsceZeroweMetodaPolawianiaPrzedzialow(Func2, 0, i);
                    if (Math.Abs(Func2(wynik) - 0 ) > 0.0001)
                        Console.WriteLine("zle dla {0} i {1}", 0 , i);
            }
        }
    }
}