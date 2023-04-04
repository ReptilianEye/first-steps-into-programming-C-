using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using nauka_programowania;

namespace nauka_programowania
{
    class ZnajdywanieNajdluzszegoWspolnegoLancucha
    {
        //funkcja szuka najdluzszego wspolnego ciagu znakow, porownujac dwa slowa
        //zwraca dlugosc tego lancucha
        
        //wykorzystuje ona zapisywanie wartosci w TABLICY DWUWYMIAROWEJ
        public int ZwracaDlugoscNajdluzszegoWspolnegoCiagu(string slowo1, string slowo2, ref int indexLancucha1, ref int indexLancucha2)
        {
            int dlugoscSlowa1 = slowo1.Length;
            int dlugoscSlowa2 = slowo2.Length;
            int[,] tablicaDlugosci = new int[2, dlugoscSlowa2 + 1];     //tworzymy dwuwymiarowa tablice w ktorej bedziemy wartosci wspolne
                                                                        //wykorzystujac zmienne 'i' i 'j' ktorymi bedziemy szli po slowach (jak w ukladzie wspolrzednych)
            int najdluzszaDlugosc = 0;
            for (int i = 0; i < dlugoscSlowa1; i++)             //petla 'i' idziemy po slowie1
            {
                for (int j = 0; j < dlugoscSlowa2; j++)         //petla 'j' idziemy po slowie2
                {
                    if (slowo1[i] != slowo2[j])             //jesli kolejne litery nie zgadzaja sie ze soba 
                    {
                        tablicaDlugosci[1, j + 1] = 0;      //zerujemy miejsce w tablicy gdzie doszly nasze zmienne - oznacza to ze rozpoczynamy nowe slowo (skonczylismy poprzedni wspolny lancuch)
                        continue;                              //i rozpoczynamy petle od poczatku - sprawdzamy kolejna litere
                    }
                    tablicaDlugosci[1, j + 1] = 1 + tablicaDlugosci[0, j];     //ustawiamy dlugosc na 1 w drugim wierszu lub dodajemy wartosc poprzedniej dlugosci - zliczamy najdluzsza dlugosc
                    if (tablicaDlugosci[1, j + 1] <= najdluzszaDlugosc)     //jesli aktualna dlugosc jest wieksza od aktualnej najdluzszej dlugosci 
                        continue;
                    najdluzszaDlugosc = tablicaDlugosci[1, j + 1];          //- aktualizujemy najdluzszaDlugosc
                    indexLancucha1 = i - najdluzszaDlugosc + 1;             
                    indexLancucha2 = j - najdluzszaDlugosc + 1;

                }
                for (int j = 0; j < dlugoscSlowa2; j++)
                    tablicaDlugosci[0, j] = tablicaDlugosci[1, j];          //przenosimy wartosci z wiersza pierwszego na drugi, poniewaz sa one juz nie aktualne
            }                                                               //wiersz drugi jest wierszem gdzie zapisujemy wartosci z wiersza pierwszego, juz zaaktualizowane
            return najdluzszaDlugosc;
        }
        public void Test()
        {
            string slowo1 = "hythnytbbbjkuymjmhjPIOTRcccc";
            string slowo2 = "adsabbbtrgtrijhyutPIOTRaaa";
            int indexLancucha1 = -1;
            int indexLancucha2 = -1;
            var najdluzszaDlugosc = ZwracaDlugoscNajdluzszegoWspolnegoCiagu(slowo1, slowo2, ref indexLancucha1, ref indexLancucha2);
            Console.WriteLine("Dlugosc najdluzszego lancucha dla {0} i {1} to {2}", slowo1, slowo2, najdluzszaDlugosc);
        }
    }
}