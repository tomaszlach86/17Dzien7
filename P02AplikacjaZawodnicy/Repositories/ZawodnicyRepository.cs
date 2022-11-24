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
                    Id_zawodnika = wynik[i].Id_zawodnika,
                    Id_trenera = wynik[i].Id_trenera,
                    Imie = wynik[i].Imie,
                    Nazwisko = wynik[i].Nazwisko,
                    Kraj = wynik[i].Kraj,
                    Wzrost = wynik[i].Wzrost,
                    Waga = wynik[i].Waga,
                    DataUrodzenia = wynik[i].DataUrodzenia
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
