using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16_Muistipeli__Kiitettävä_.View
{
    public partial class StartForm : Form, IStartView
    {
        public event EventHandler AloitaPeli;
        public event EventHandler NaytaScores;
        public StartForm()
        {
            InitializeComponent();
            MaaritaAlusta();
        }
        private void MaaritaAlusta()
        {
            this.Size = new Size(300, 250);
            Label lblPeliMuoto = new Label { Text = "Pelimuoto:", Location = new Point(10, 10), AutoSize = true };
            ComboBox cbPeliMuoto = new ComboBox { Name = "cbPeliMuoto", Location = new Point(100, 10), Width = 150 };
            cbPeliMuoto.Items.AddRange(new[] { "Yksinpeli", "Kaksinpeli" });

            Label lblLaudanKoko = new Label { Text = "Laudan koko:", Location = new Point(10, 40), AutoSize = true };
            ComboBox cbLaudanKoko = new ComboBox { Name = "cbLaudanKoko", Location = new Point(100, 40), Width = 150 };
            cbLaudanKoko.Items.AddRange(new[] { "4x4", "6x6" });

            Label lblTeema = new Label { Text = "Teema:", Location = new Point(10, 70), AutoSize = true };
            ComboBox cbTeema = new ComboBox { Name = "cbTeema", Location = new Point(100, 70), Width = 150 };
            cbTeema.Items.AddRange(new[] { "Eläimet", "Työkalut", "Hedelmät" });

            Button btnAloita = new Button { Text = "Aloita Peli:", Location = new Point(10, 100), AutoSize = true };
            btnAloita.Click += (s, e) => AloitaPeli?.Invoke(this, EventArgs.Empty);

            Button btnNaytaScores = new Button { Text = "Näytä tulokset", Location = new Point(120, 100), Width = 100 };
            btnNaytaScores.Click += (s, e) => NaytaScores?.Invoke(this, EventArgs.Empty);
            this.Controls.AddRange(new Control[] { lblPeliMuoto, cbPeliMuoto, lblLaudanKoko, cbLaudanKoko, lblTeema, cbTeema, btnAloita, btnNaytaScores });
        }
        public string Pelimuoto => (this.Controls["cbPeliMuoto"] as ComboBox)?.SelectedItem?.ToString();
        public string LautaKoko => (this.Controls["cbLaudanKoko"] as ComboBox)?.SelectedItem?.ToString();
        public string Teema => (this.Controls["cbTeema"] as ComboBox)?.SelectedItem?.ToString();

        public void NaytaError(string message)
        {
            MessageBox.Show(message, "Virhe");
        }
        public void Nayta()
        {
            Application.Run(this);
        }
    }
}
