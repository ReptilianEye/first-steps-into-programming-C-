using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    //Czy slowa sa anagramami (slowami z ktorych da sie stworzyc inne slowo) 3 metodami
    class SprawdzanieCzySlowaSaAnagramami
    {
        //Funkcja pobiera litery z pierwszego slowa i dodaje i do listy. Nastepnie idze petla po literach drugiego slowa i usowa je z listy. Na koncu sprawdza czy lista jest pusta i jesli tak to zwraca true
        public Boolean CzySlowaSaAnagramami(string slowo1, string slowo2)
        {
            if (slowo1.Length != slowo2.Length)
                return false;
            List<char> listaLiterWSlowie1 = new List<char>();
            foreach (char litera in slowo1)
                listaLiterWSlowie1.Add(litera);
            for (int i = 0; i < slowo2.Length; i++)
                listaLiterWSlowie1.Remove(slowo2[i]);
            if (listaLiterWSlowie1.Count == 0)
                return true;
            return false;
        }
        //Funkcja sprawdza czy litera ze slowa drugiego znajduje sie w slowie pierwszym i jesli tak jest, to usuwa ja ze slowa pierwszego. Jesli slowo 1 na koncu algorytmu jest puste - zwraca true
        public Boolean CzySlowaSaAnagramamiV2(string slowo1, string slowo2)
        {
            if (slowo1.Length != slowo2.Length)
                return false;
            for (int i = 0; i < slowo2.Length; i++)
            {
                int pozycja = slowo1.IndexOf(slowo2[i]);
                if (pozycja >= 0)
                    slowo1 = slowo1.Remove(pozycja, 1);
                else
                    return false;
            }
            if (slowo1 == "")
                return true;
            return false;
        }
        //Funkcja idzie po slowie i zapisuje w Dictionary ile razy wystapila kazda z liter. Nastepnie idzie przez drugiem slowie i gdy litera z drugiego slowa znajduje sie w Dictionary, zmniejsza licznik tej litery.
        //Jesli liczniki wszytskich liter wynosza 0 funkcja zwaraca true.
        public Boolean CzySlowaSaAnagramamiV3(string slowo1, string slowo2)
        {
            if (slowo1.Length != slowo2.Length)
                return false;
            Dictionary<char, long> licznikiLiterWSlowie = new Dictionary<char, long>();
            foreach (char litera in slowo1)
            {
                if (licznikiLiterWSlowie.ContainsKey(litera))
                {
                    licznikiLiterWSlowie[litera]++;                        // modyfikacja licznika dla litery ktora juz znajduje sie w Dictionary
                }
                else
                    licznikiLiterWSlowie.Add(litera, 1);                 // dodanie nowego licznika (Key = litera, value = 1), poniewaz nie znajduje sie on jeszce w Dictionary 
            }
            foreach (var litera in slowo2)
            {
                if (licznikiLiterWSlowie.ContainsKey(litera))
                {
                    licznikiLiterWSlowie[litera]--;
                    if (licznikiLiterWSlowie[litera] < 0)
                        return false;
                }
                else
                    return false;
            }
            foreach (var licznik in licznikiLiterWSlowie.Values)
                if (licznik != 0)
                    return false;
            return true;
        }
        public void Test()
        {
            Testuj3Funkcje("adam", "dama", true, "blad 1");
            Testuj3Funkcje("evil", "live", true, "blad 2");
            Testuj3Funkcje("kot", "tok", true, "blad 3");
            Testuj3Funkcje("szynka", "kszyna", true, "blad 4");
            Testuj3Funkcje("tak", "nie", false, "blad 5");
            Testuj3Funkcje("1221", "1223", false, "blad 6");
            Testuj3Funkcje("122", "123", false, "blad 7");
            Testuj3Funkcje("", "", true, "blad 8");

        }
        public void Testuj3Funkcje(string slowo1, string slowo2, bool oczekiwanyRezultat, string komunikat)
        {
            if (CzySlowaSaAnagramami(slowo1, slowo2) != CzySlowaSaAnagramamiV2(slowo1, slowo2) || CzySlowaSaAnagramamiV3(slowo1, slowo2) != CzySlowaSaAnagramami(slowo1, slowo2)
                                                                                               || CzySlowaSaAnagramamiV3(slowo1, slowo2) != oczekiwanyRezultat)
                Console.WriteLine(komunikat);
            if (CzySlowaSaAnagramami(slowo2, slowo1) != CzySlowaSaAnagramamiV2(slowo2, slowo1) || CzySlowaSaAnagramamiV3(slowo2, slowo1) != CzySlowaSaAnagramami(slowo2, slowo1)
                                                                                               || CzySlowaSaAnagramamiV3(slowo2, slowo1) != oczekiwanyRezultat)

                Console.WriteLine(komunikat);

        }
    }
}