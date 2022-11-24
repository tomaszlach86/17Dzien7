using P06BibliotekaPolaczenieZBaza;
using P02AplikacjaZawodnicy.Domain;
using P02AplikacjaZawodnicy.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P02AplikacjaZawodnicy
{
    public partial class FrmStartowy : Form
    {
        public FrmSzczegoly frmSzczegoly { get; set; }
        public FrmStartowy()
        {
            InitializeComponent();
        }

        private void btnWczytaj_Click(object sender, EventArgs e)
        {
            Odswiez();
        }

        public void Odswiez()
        {
            ZawodnicyRepository zr = new ZawodnicyRepository();
            lbDane.DataSource = zr.PodajZawodnikow();
            lbDane.DisplayMember = "DaneRaportowe";
        }

        private void btnSzczegoly_Click(object sender, EventArgs e)
        {
            Zawodnik zaznaczony =
                (Zawodnik)lbDane.SelectedItem;

            if (frmSzczegoly==null)
            {
                frmSzczegoly = new FrmSzczegoly(zaznaczony, this);
                frmSzczegoly.Show();
            }
            else
                frmSzczegoly.UzupelnijFormularz(zaznaczony);       
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (frmSzczegoly == null)
            {
                frmSzczegoly = new FrmSzczegoly(this);
                frmSzczegoly.Show();
            }
        }
    }
}
