using P06BibliotekaPolaczenieZBaza;
using P02AplikacjaZawodnicy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace P02AplikacjaZawodnicy.Repositories
{
    internal class ZawodnicyRepository
    {
        public Zawodnik[] PodajZawodnikow()
        {
            ModelBazyDataContext db = new ModelBazyDataContext();
            ZawodnikDB[] zawodnicy = db.ZawodnikDB.ToArray();

            Zawodnik[] wynik = new Zawodnik[zawodnicy.Length];
            for (int i = 0; i < zawodnicy.Length; i++)
            {
                wynik[i] = new Zawodnik()
                {
                    Id_zawodnika = zawodnicy[i].id_zawodnika,
                    Id_trenera = zawodnicy[i].id_trenera,
                    Imie = zawodnicy[i].imie,
                    Nazwisko = zawodnicy[i].nazwisko,
                    Kraj = zawodnicy[i].kraj,
                    Wzrost = zawodnicy[i].wzrost,
                    Waga = zawodnicy[i].waga,
                    DataUrodzenia = zawodnicy[i].data_ur
                };
            }
            return wynik;
        }

        public void Edytuj(Zawodnik z)
        {
             
        }

        public void Usun(int id)
        {
             
        }

        public void DodajNowego(Zawodnik zawodnik)
        {
             
        }

         
    }
}
