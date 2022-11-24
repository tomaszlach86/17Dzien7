using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WstepORM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ModelBazyDataContext db = new ModelBazyDataContext();
            Zawodnik[] zawodnicy= db.Zawodnik.ToArray();

            //foreach (var z in zawodnicy)
            //    Console.WriteLine(z.imie + " "  + z.nazwisko);

            // Dodawanie danych do bazy 

            //Zawodnik z = new Zawodnik();
            //z.imie = "jan";
            //z.nazwisko = "kowalski";
            //z.kraj = "polska";
            //z.data_ur = DateTime.Now;
            //z.waga = 90;
            //z.wzrost = 190;

            //db.Zawodnik.InsertOnSubmit(z);
            //db.SubmitChanges();

            // edycja danych 
            //int szukaneId = 20;

            //Zawodnik z = db.Zawodnik.FirstOrDefault(x => x.id_zawodnika == szukaneId);
            ////select * from zawodnicy where id_zawodnika = 20
            //z.kraj = "Czechy";
            //z.waga += 20;
            //db.SubmitChanges();

            // Usuwamie 
            int szukaneId = 20;
            Zawodnik z = db.Zawodnik.FirstOrDefault(x => x.id_zawodnika == szukaneId);
            db.Zawodnik.DeleteOnSubmit(z);
            db.SubmitChanges();


            Console.ReadKey();

        }
    }
}
