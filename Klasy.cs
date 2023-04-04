using System;
using System.Collections;
using System.Collections.Generic;

namespace nauka_programowania
{
    class Uczen
    {
        public string imie;
        public string nazwisko;
        public int wiek;
        public List<Ocena> oceny = new List<Ocena>();
        private List<Uwaga> uwagi = new List<Uwaga>();
        public void DodajUwage(Uwaga uwaga)
        {
            uwagi.Add(uwaga);
        }
        public List<Uwaga> ZwrocUwagi()
        {
            return uwagi;
        }
    }
    class Uwaga
    {
         bool CzyPozytywna = true;
        public string tresc;
        public DateTime data;
    }
    class Ocena
    {
        public string przedmiot;
        public int grade;
    }
    class TestyKlas
    {
        public ArrayList TestyUcznia()
        {
            Uczen uczen1 = new Uczen();
            uczen1.imie = "marek";
            uczen1.nazwisko = "rzadkowski";
            uczen1.wiek = 15;
            Uwaga uwaga1 = new Uwaga();
            uwaga1.tresc = "uczen przyniosl mundurek";
            uwaga1.data = DateTime.Today;
            uczen1.DodajUwage(uwaga1);
            Uwaga uwaga2 = new Uwaga();
            uwaga2.tresc = "ucznia nie bylo na WF";
            uwaga2.data = DateTime.Today;
            Uwaga uwaga3 = new Uwaga();
            uwaga3.tresc = "Uczen wydzieral sie na lekcji";
            uwaga3.data = DateTime.Today;
            uczen1.DodajUwage(uwaga3);
            Ocena ocena4 = new Ocena();
            Ocena ocena5 = new Ocena();
            Ocena ocena6 = new Ocena();
            ocena4.przedmiot = "Wf";
            ocena4.grade = 4;
            ocena5.przedmiot = "Matematyka";
            ocena5.grade = 3;
            ocena6.przedmiot = "Fizyka";
            ocena6.grade = 2;
            uczen1.oceny.Add(ocena4);
            uczen1.oceny.Add(ocena5);
            uczen1.oceny.Add(ocena6);
            Uczen uczen2 = new Uczen();
            uczen2.imie = "piotrek";
            uczen2.nazwisko = "rzadkowski";
            uczen2.wiek = 17;
            uczen2.DodajUwage(uwaga2);
            Ocena ocena1 = new Ocena();
            ocena1.przedmiot = "WF";
            ocena1.grade = 5;
            Ocena ocena2 = new Ocena();
            ocena2.przedmiot = "Matematyka";
            ocena2.grade = 6;
            Ocena ocena3 = new Ocena();
            ocena3.przedmiot = "Fizyka";
            ocena3.grade = 5;
            uczen2.oceny.Add(ocena1);
            uczen2.oceny.Add(ocena2);
            uczen2.oceny.Add(ocena3);
            ArrayList dziennik = new ArrayList { uczen1, uczen2 };
            return dziennik;
        }
        public void SredniaCalejSzkoly()
        {
            TestyKlas z = new TestyKlas();
            int suma = 0;
            float sredniaSzkoly;
            int iloscOcen = 0;
            ArrayList dziennik = z.TestyUcznia();
            foreach (Uczen uczen in dziennik)
                foreach (Ocena ocena in uczen.oceny)
                {
                    suma = suma + ocena.grade;
                    iloscOcen++;
                }
            sredniaSzkoly = (float)suma / (float)iloscOcen;
            Console.WriteLine(sredniaSzkoly);
        }
        public void TestyOceny()
        {
            TestyKlas t = new TestyKlas();
            ArrayList dziennik = t.TestyUcznia();
            foreach (Uczen uczen in dziennik)
            {
                Console.WriteLine("Uczen {0} {1} :", uczen.imie, uczen.nazwisko);
                Console.WriteLine("Oceny:");
                foreach (Ocena ocena in uczen.oceny)
                {
                    Console.WriteLine("{0}: {1} ", ocena.przedmiot, ocena.grade);
                }
                Console.WriteLine("Uwagi: ");
                foreach (Uwaga uwaga in uczen.ZwrocUwagi())
                {
                    Console.WriteLine("{0}: {1}", uwaga.data, uwaga.tresc);
                }
                Console.WriteLine();
            }
        }
    }
}