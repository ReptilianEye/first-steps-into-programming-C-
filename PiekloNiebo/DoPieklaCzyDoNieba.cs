using System;
using System.Collections;
using System.Collections.Generic;
using nauka_programowania;
using System.IO;

namespace nauka_programowania
{
    class PiekloCzyNiebo
    {

        public List<List<int>> WczytajWejscie()
        {
            var listaListUczynkow = new List<List<int>>();
            StreamReader file = new System.IO.StreamReader(@"PiekloNiebo\DaneDoPiekloNiebo.txt");
            int iloscZestawow = Convert.ToInt32(file.ReadLine());
            for (int zestaw = 1; zestaw <= iloscZestawow; zestaw++)
            {
                var listaUczynkow = new List<int>();
                var lista = new List<string>();
                int iloscUczynkow = Convert.ToInt32(file.ReadLine());
                string uczynki = file.ReadLine();
                uczynki = uczynki.Trim();
                lista.AddRange(uczynki.Split(" "));
                foreach (var wyraz in lista)
                    listaUczynkow.Add(Convert.ToInt32(wyraz));
                listaListUczynkow.Add(listaUczynkow);
            }
            file.Close();
            return listaListUczynkow;
        }
        public Boolean ZwracaNajkorzystniejszaRozniceLubTakaKtoraDajeDostepDoNieba(List<int> listaUczynkow)
        {
            for (int i = 0; i < listaUczynkow.Count; i++)
            {
                int pom = listaUczynkow[i];
                listaUczynkow.RemoveAt(i);
                if (MetodyDoPiekloNiebo.ZwrocDlugoscNajdluzszegoRosnacegoCiagu(listaUczynkow) >= MetodyDoPiekloNiebo.ZwrocDlugoscNajdluzszegoMalejacegoCiagu(listaUczynkow))
                    return true;
                listaUczynkow.Insert(i, pom);
            }
            return false;
        }
        public void WypiszWyjscie(bool doNieba)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"PiekloNiebo\WynikiDoPiekloNiebo.txt", true))
            {
                if (doNieba)
                    file.WriteLine("niebo");
                else
                    file.WriteLine("pieklo");
            }
        }
        public void Test()
        {
            var listaListUczynkow = WczytajWejscie();
            foreach (var listaUczynkow in listaListUczynkow)
            {
                var doNieba = ZwracaNajkorzystniejszaRozniceLubTakaKtoraDajeDostepDoNieba(listaUczynkow);
                WypiszWyjscie(doNieba);
            }
        }

    }
}