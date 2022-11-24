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
    public partial class FrmSzczegoly : Form
    {
        private Zawodnik zawodnik;
        private FrmStartowy fs;

        public FrmSzczegoly(Zawodnik zawodnik, FrmStartowy fs)
        {
            InitializeComponent();
            UzupelnijFormularz(zawodnik);
            this.zawodnik = zawodnik;
            this.fs = fs;
        }

        public void UzupelnijFormularz(Zawodnik zawodnik)
        {
            txtImie.Text = zawodnik.Imie;
            txtNazwisko.Text = zawodnik.Nazwisko;
            txtKrajZawodnika.Text = zawodnik.Kraj;
            txtDataUr.Text = zawodnik.DataSformatowana;
            txtWzrost.Text = zawodnik.Wzrost.ToString();
            txtWaga.Text = zawodnik.Waga.ToString();
        }

        private void FrmSzczegoly_FormClosed(object sender, FormClosedEventArgs e)
        {
            fs.frmSzczegoly = null;
        }

        private async void btnZapisz_Click(object sender, EventArgs e)
        {
            ZczytytajFormularz();

            ZawodnicyRepository zr = new ZawodnicyRepository();
            zr.Edytuj(zawodnik);
        }

        private void ZczytytajFormularz()
        {
            zawodnik.Imie = txtImie.Text;
            zawodnik.Nazwisko = txtNazwisko.Text;
            zawodnik.Kraj = txtKrajZawodnika.Text;
            
            if (string.IsNullOrEmpty(txtDataUr.Text))
                zawodnik.DataUrodzenia = null;
            else
                zawodnik.DataUrodzenia = Convert.ToDateTime(txtDataUr.Text);

            zawodnik.Waga = Convert.ToInt32(txtWaga.Text);
            zawodnik.Wzrost = Convert.ToInt32(txtWzrost.Text);
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            ZawodnicyRepository zr = new ZawodnicyRepository();

            string s = string.Format("Czy jesteś pewien, że chcesz usunać zawodnika {0} ?",
                zawodnik.ImieNazwisko);

            var d= MessageBox.Show(s, "Usuwanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d== DialogResult.Yes)
            {
                zr.Usun(zawodnik.Id_zawodnika);
                fs.Odswiez();
                this.Close();
            }

            
        }
    }
}
