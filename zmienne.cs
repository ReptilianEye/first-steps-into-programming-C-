using System;
using System.Collections;

namespace nauka_programowania
{
    class zmienne
    {
        public void ZabawaNaZmiennych()
        {
            string ciag_znakow = "Ala ma kota";
            char znak = 'a';
            long liczba = 3425;
            liczba = liczba * 2;
            var liczba_2 = ciag_znakow + "+" + liczba + "+" + znak;
            //bool trueFalse = 2 + 2 > 4;
            var wynikDzielenia = (float)liczba / 17;
            string[] tablica_str = new string[3];
            tablica_str[0] = "piotrek";
            tablica_str[1] = "marek";
            tablica_str[2] = "agatka";
            DateTime dataUrodzenia = new DateTime(1410, 07, 15);
            DateTime dataDzisiaj = DateTime.Now;
            TimeSpan wiek = dataDzisiaj - dataUrodzenia;
            Console.WriteLine(dataUrodzenia.DayOfWeek);


            // ArrayList cwiczenia
            ArrayList a = new ArrayList();
            a.Add("piotrek");
            a.Add("marek");
            a.Add("narty");
            a.Remove("marek");
            foreach (var ciag in a)
                Console.WriteLine(ciag);
        }
        public void Testy()
        {
            zmienne z = new zmienne();
            //z.ZabawaNaZmiennych();

        }
    }
}