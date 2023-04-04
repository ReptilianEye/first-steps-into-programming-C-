using System;
using System.Collections;
using nauka_programowania;

namespace nauka_programowania
{
    class ZnajdzSlowoZSzyfru
    {
        public void WypiszSlowoZSzyfru()
        {
            
            string hasloDoRozwiazania;
            string haslo1 = "BkoelleokL  i";
            //string haslo2 = "Aaltao km a";
            //string haslo3 = "192837465";   // 123456789
            //string haslo4 = "18273645";   // 12345678
            string rozw = "";
            hasloDoRozwiazania = haslo1;
            for (int i = 0; i <= hasloDoRozwiazania.Length - 1; i++)    
            {                                                           //spisuje do rozwiazania litere a nastepnie ja usowa
                rozw = rozw + hasloDoRozwiazania[i];                    //nastepnie petla zwieksza wskaznik o 1,
                hasloDoRozwiazania = hasloDoRozwiazania.Remove(i, 1);   //a przez to ze poprzednia litera zostala usunieta                                                     
            }                                                           //dodawana jest co druga litera
            for (int i = hasloDoRozwiazania.Length - 1; i >= 0; i--)
                rozw = rozw + hasloDoRozwiazania[i];                    //od konca dodawane sa te litery ktore nie zostaly uzyte
            Console.WriteLine(rozw);                                    
        }
    }
}