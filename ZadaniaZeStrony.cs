using System;
using System.Collections;

namespace nauka_programowania
{
    class ZadaniaZeStrony
    {
        //funkcja do zabawy funkcja switch - bez wiekszego sensu(jak wszystko tutaj)
        public void FunkcjaSwitch()
        {
            int dzien = Convert.ToInt32(Console.ReadLine());
            switch (dzien)
            {
                case 1:
                    Console.WriteLine("to moje imie");
                    break;
                case 2:
                    Console.WriteLine("dwa");
                    Console.WriteLine("dwa");
                    break;
                case 3:
                    Console.WriteLine("tamto dziala");
                    break;

            }
        }
        //funkcja do..while/do - troche sredni przyklad ale zrozumialem
        public void FunkcjaDoWhile()
        {
            ArrayList slowa = new ArrayList();
            do
            {
                string slowo = Console.ReadLine();
                if (slowo.Length > 5)
                    slowa.Add(slowo);
            } while (slowa.Count <= 5);
            foreach(var element in slowa)
                Console.WriteLine(element);
        }
        
    }
}