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
            ModelBazyDataContext db = new ModelBazyDataContext();
            ZawodnikDB zdb = db.ZawodnikDB.FirstOrDefault(x=>x.id_zawodnika==z.Id_zawodnika);

            zdb.id_trenera = z.Id_trenera;
            zdb.imie = z.Imie;
            zdb.nazwisko = z.Nazwisko;
            zdb.kraj = z.Kraj;
            zdb.data_ur = z.DataUrodzenia;
            zdb.wzrost = z.Wzrost;
            zdb.waga = z.Waga;

            db.SubmitChanges();
        }

        public void Usun(int id)
        {
            ModelBazyDataContext db = new ModelBazyDataContext();
            ZawodnikDB zdb = db.ZawodnikDB.FirstOrDefault(x => x.id_zawodnika == id);
            db.ZawodnikDB.DeleteOnSubmit(zdb);
            db.SubmitChanges();
        }

        public void DodajNowego(Zawodnik zawodnik)
        {
            ModelBazyDataContext db = new ModelBazyDataContext();

            ZawodnikDB zdb = new ZawodnikDB()
            {
                id_trenera = zawodnik.Id_trenera,
                id_zawodnika = zawodnik.Id_zawodnika,
                imie = zawodnik.Imie,
                nazwisko = zawodnik.Nazwisko,
                kraj = zawodnik.Kraj,
                waga = zawodnik.Waga,
                data_ur = zawodnik.DataUrodzenia,
                wzrost = zawodnik.Wzrost
            };
            db.ZawodnikDB.InsertOnSubmit(zdb);
            db.SubmitChanges();
        }

         
    }
}
