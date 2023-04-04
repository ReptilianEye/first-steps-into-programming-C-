using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class SzyfrPrzestawieniowy
    {
        //napisz funkcje ktora zwroci zaszyfrowane slowo szyfrem przestawieniowym
        public string ZwracanieTresciHaslaPoZaszyfrowaniuPrzestawieniowym(string slowo)
        {
            string zaszyfrowanaTresc = "";
            for (int i = 0; i < slowo.Length; i = i + 2)
            {
                if (slowo.Length - 1 > i)
                {
                    char pierwszaLitera = slowo[i];
                    char drugaLitera = slowo[i + 1];
                    zaszyfrowanaTresc = zaszyfrowanaTresc + drugaLitera + pierwszaLitera;
                }
                else

                    zaszyfrowanaTresc = zaszyfrowanaTresc + slowo[i];
            }
            return zaszyfrowanaTresc;
        }
        public string ZwracanieHaslaPoPrzestawieniuSamoglosek(string slowo)
        {
            string samogloski = "aeyioąęuó";
            char pomocnicza;
            char zastepczaPomocniczej = 'l';
            int pierwszaSamogloska = -1;
            int miejscePierwszejSamogloski = -1;
            string zaszyfrowanaTresc = "";
            int naPoczatku = 0;
            while (pierwszaSamogloska == -1)        //idziemy w petli dopoki nie znajdziemy pierwszej samogloski
            {
                if (samogloski.IndexOf(slowo[naPoczatku]) >= 0)
                {
                    pierwszaSamogloska = samogloski.IndexOf(slowo[naPoczatku]);
                    miejscePierwszejSamogloski = slowo.IndexOf(slowo[naPoczatku]);
                    pomocnicza = slowo[naPoczatku];
                    zastepczaPomocniczej = pomocnicza;
                }
                naPoczatku++;
            }
            for (int i = 0; i < slowo.Length; i++)
            {
                if (samogloski.IndexOf(slowo[i]) >= 0)
                {
                    pomocnicza = slowo[i];
                    zaszyfrowanaTresc = zaszyfrowanaTresc + zastepczaPomocniczej;
                    zastepczaPomocniczej = pomocnicza;
                }
                else
                    zaszyfrowanaTresc = zaszyfrowanaTresc + slowo[i];
            }
            char[] doZamiany = zaszyfrowanaTresc.ToCharArray();
            doZamiany[miejscePierwszejSamogloski] = zastepczaPomocniczej;
            zaszyfrowanaTresc = "";
            foreach (var element in doZamiany)
                zaszyfrowanaTresc += element;
            Console.WriteLine(zaszyfrowanaTresc);
            return zaszyfrowanaTresc;
        }
        public string ZwracanieHaslaPoPrzestawieniuSamoglosekV2(string slowo)
        {
            string samogloski = "aeyioąęuó";
            bool bylaSamogloska = false;
            int miejscePierwszejSamogloski = -1;
            char poprzedniaSamogloska ='a';
            string zaszyfrowanaTresc = "";
            for (int i = 0; i < slowo.Length; i++)
            {
                if (samogloski.IndexOf(slowo[i]) >= 0)      //czy trafilismy na samogloske
                {
                    if (bylaSamogloska)                  //czy trafilismy na kolejna samogloske
                    {
                        zaszyfrowanaTresc = zaszyfrowanaTresc + poprzedniaSamogloska;
                        poprzedniaSamogloska = slowo[i];
                    }
                    else
                    {
                        bylaSamogloska = true;
                        miejscePierwszejSamogloski = i;
                        poprzedniaSamogloska = slowo[i];
                    }
                }
                else
                    zaszyfrowanaTresc = zaszyfrowanaTresc + slowo[i];
            }
            if (bylaSamogloska)
            {
                zaszyfrowanaTresc = zaszyfrowanaTresc.Substring(0, miejscePierwszejSamogloski) + poprzedniaSamogloska + zaszyfrowanaTresc.Substring(miejscePierwszejSamogloski);
            }
            Console.WriteLine(zaszyfrowanaTresc);
            return zaszyfrowanaTresc;
        }
        public void Test()
        {
            /* List<string> tablicaTresci = new List<string> { "1234", "123", "1", "12", "Marcin", "Piotrek", "CaZar", "Skype", "aaaaaa", "ZzZzZz", "Ala ma kota", "tata", "lokomotywa" };
            foreach (string tresc in tablicaTresci)
            {
                string trescZaszyfrowana = ZwracanieTresciHaslaPoZaszyfrowaniuPrzestawieniowym(tresc);
                string trescOdszyfrowana = ZwracanieTresciHaslaPoZaszyfrowaniuPrzestawieniowym(trescZaszyfrowana);
                Console.WriteLine("{0} zostala zaszyfrowana na {1}", tresc, trescZaszyfrowana);
                if (tresc != trescOdszyfrowana)
                    Console.WriteLine("blad dla slowa {0}", tresc);
             }*/
            ZwracanieHaslaPoPrzestawieniuSamoglosekV2("piotrek");

        }

    }
}