using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01SlowoThis
{
    internal class Zawodnik
    {
        public string Imie
        {
            get
            {
                return imie;
            }
            set
            {
                imie = value;
            }
        }

        private string imie;
        public string Nazwisko { get; set; }



        public Zawodnik(string imie, string nazwisko)
        {
            this.imie = imie;
            this.Nazwisko = nazwisko;
        }

        public string PrzedstawSie()
        {
            return Imie + " " + Nazwisko;
        }

        public string PodajPeleneDane()
        {
            string s = "Adres Jasna";
            string r = this.PrzedstawSie() + s;
            return r;
        }

    }
}
