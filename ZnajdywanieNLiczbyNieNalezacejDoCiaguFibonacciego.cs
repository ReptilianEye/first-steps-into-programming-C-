using System;
using System.Collections;
using nauka_programowania;
using System.Collections.Generic;

namespace nauka_programowania
{
    class ZnajdywanieLiczbyNieZCiaguFibonacciego
    {
        public void WykonajZadanie()
        {
            List<long> listaF = new List<long>();
            listaF.Add(1);
            listaF.Add(1);
            for (int i = 2; i < 100; i++)
            {

                listaF.Add(listaF[i - 2] + listaF[i - 1]);
                if (listaF[i] > Math.Pow(10, 6))
                    break;
            }
            foreach (var element in listaF)
                Console.WriteLine(element);
        }
    }
}

