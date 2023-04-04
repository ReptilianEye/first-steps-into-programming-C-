using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class SzyfrCezara
    {
        //napisz funkcje ktora zwroci zaszyfrowane slowo
        public string ZwracanieTreciHaslaPoZaszyfrowaniuSzyfremCezara(string tresc, int klucz)
        {
            string zaszyfrowanaTresc = "";
            if (Math.Abs(klucz) > 26)
                klucz = klucz % 26;
            for (int i = 0; i < tresc.Length; i++)
            {
                if (tresc[i] == ' ')
                    zaszyfrowanaTresc += ' ';
                else
                {
                    int kodLiteryWASCII = Convert.ToInt32(tresc[i]);
                    kodLiteryWASCII = ZwracaWartoscKoduAsciiDlaOkreslonychWarunkow(kodLiteryWASCII, klucz);
                    zaszyfrowanaTresc = zaszyfrowanaTresc + Convert.ToChar(kodLiteryWASCII);
                }
            }
            return zaszyfrowanaTresc;
        }
        public int ZwracaWartoscKoduAsciiDlaOkreslonychWarunkow(int kodLiteryWASCII, int klucz)
        {
            int nowyKod = kodLiteryWASCII + klucz;
            if (kodLiteryWASCII >= 65 && kodLiteryWASCII <= 90 && nowyKod > 90)
            {
                return nowyKod -= 26;
            }
            if (kodLiteryWASCII >= 65 && kodLiteryWASCII <= 90 && nowyKod < 65)
            {
                return nowyKod += 26;
            }
            if (kodLiteryWASCII >= 97 && kodLiteryWASCII <= 122 && nowyKod > 122)
            {
                return nowyKod -= 26;
            }
            if (kodLiteryWASCII >= 97 && kodLiteryWASCII <= 122 && nowyKod < 97)
            {
                return nowyKod += 26;
            }
            return nowyKod;
        }
        public void Test()
        {
            List<string> tablicaTresci = new List<string> { "Marcin", "Piotrek", "CaZar", "Skype", "aaaaaa", "ZzZzZz", "Ala ma kota" };
            foreach (string tresc in tablicaTresci)
            {
                for (int i = -100; i < 100; i++)
                {
                    string trescZaszyfrowana = ZwracanieTreciHaslaPoZaszyfrowaniuSzyfremCezara(tresc, i);
                    string trescOdszyfrowana = ZwracanieTreciHaslaPoZaszyfrowaniuSzyfremCezara(trescZaszyfrowana, -i);
                    Console.WriteLine("{0} zostala zaszyfrowana na {1}", tresc ,trescZaszyfrowana);
                    if (tresc != trescOdszyfrowana)
                        Console.WriteLine("blad dla slowa {0} i liczby {1}", tresc, i);
                }
            }
        }
    }
}