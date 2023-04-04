using System;
using System.Collections;
using nauka_programowania;

namespace nauka_programowania
{
    class SlowoILicznik
    {
        public int Licznik;
        public string Slowo;
    }
    class NaukaHashtable
    {
        public ArrayList PoliczIleRazyWystepujeSlowo(ArrayList CiagSlow)
        {
            ArrayList liczniki = new ArrayList();
            foreach (string slowo in CiagSlow)
            {
                bool znaleziono = false;
                foreach (SlowoILicznik licznik in liczniki)
                    if (licznik.Slowo == slowo)
                    {
                        licznik.Licznik++;
                        znaleziono = true;
                        break;
                    }
                if (!znaleziono)
                {
                    var licznik = new SlowoILicznik();
                    licznik.Slowo = slowo;
                    licznik.Licznik = 1;
                    liczniki.Add(licznik);
                }
            }
            return liczniki;
        }

        public Hashtable PoliczIleRazyWystepujeSlowoV2(ArrayList CiagSlow)
        {
            Hashtable liczniki = new Hashtable();
            foreach (string slowo in CiagSlow)
            {
                SlowoILicznik licznik = (SlowoILicznik)liczniki[slowo];
                if (licznik != null)
                    licznik.Licznik++;
                else
                {
                    licznik = new SlowoILicznik();
                    licznik.Slowo = slowo;
                    licznik.Licznik = 1;
                    liczniki.Add(slowo, licznik);
                }
            }
            return liczniki;
        }
        public void Testy()
        {
            NaukaHashtable z = new NaukaHashtable();
            ArrayList lista = new ArrayList { "ela", "ale", "ela", "ola", "ela", "ola", "ela" };
            var slowa = z.PoliczIleRazyWystepujeSlowoV2(lista);
            foreach (DictionaryEntry pair in slowa)
                Console.WriteLine("{0} {1} ", pair.Key, ((SlowoILicznik)pair.Value).Licznik);
        }
    }
}