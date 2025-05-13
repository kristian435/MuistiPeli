using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _16_Muistipeli__Kiitettävä_.View;

namespace _16_Muistipeli__Kiitettävä_
{
    public partial class PeliForm : Form, IPeliView
    {
        public event EventHandler<KorttiClickEventArgs> KorttiClicked;
        private Button[,] buttons;
        private int rivit;
        private int sarakkeet;
        private bool onYksinPeli;
        private Label lblPlayer1Score;
        private Label lblPlayer2Score;
        private Label lblCurrentPlayer;
        private Label lblKaannokset;
        public PeliForm(int rivit, int sarakkeet, bool onYksinPeli)
        {
            InitializeComponent();
            this.rivit = rivit;
            this.sarakkeet = sarakkeet;
            this.onYksinPeli = onYksinPeli;
            PeliNakyma();
            this.onYksinPeli = onYksinPeli;
        }
        private void PeliNakyma()
        {
            buttons = new Button[rivit, sarakkeet];
            this.ClientSize = new Size(sarakkeet * 100 + 200, rivit * 100 + 200);

            lblPlayer1Score = new Label
            {
                Text = onYksinPeli ? "Pisteet: 0" : "Pelaaja 1: 0",
                Location = new Point(sarakkeet * 100 +10,10),
                AutoSize = true,
            };
            lblPlayer2Score = new Label
            {
                Text = "Pelaaja 2: 0",
                Location = new Point(sarakkeet * 100 + 10, 40),
                AutoSize = true,
                Visible = !onYksinPeli
            };
            lblCurrentPlayer = new Label
            {
                Text = "Vuoro: Pelaaja 1",
                Location = new Point(sarakkeet * 100 + 10, 70),
                AutoSize = true,
                Visible = !onYksinPeli
            };
            lblKaannokset = new Label
            {
                Text = "Käännökset: 0",
                Location = new Point(sarakkeet * 100 + 10, 100),
                AutoSize = true,
                Visible = !onYksinPeli
            };
            this.Controls.Add(lblPlayer1Score);
            this.Controls.Add(lblPlayer2Score);
            this.Controls.Add(lblCurrentPlayer);
            this.Controls.Add(lblKaannokset);

            for (int r = 0; r < rivit; r++)
            {
                for (int s = 0; s < sarakkeet; s++)
                {
                    Button btn = new Button
                    {
                        Size = new Size(90, 90),
                        Location = new Point(s * 100 + 10, r * 100 + 10),
                        Tag = new Tuple<int, int>(r, s),
                        Font = new Font("Arial", 20, FontStyle.Bold)
                    };
                    btn.Click += (t, e) =>
                    {
                        var paikka = (Tuple<int, int>)btn.Tag;
                        KorttiClicked?.Invoke(this, new KorttiClickEventArgs(paikka.Item1, paikka.Item2));
                    };
                    buttons[r, s] = btn;
                    this.Controls.Add(btn);
                }
            }
        }
        public void PaivitaKortti(int rivi, int sarake, string symboli, bool onEsilla)
        {
            buttons[rivi, sarake].Text = onEsilla ? symboli : "";
        }
        public void PaivitaScore(int player1Score, int player2Score)
        {
            lblPlayer1Score.Text = $"Pelaaja 1: {player1Score}";
            lblPlayer2Score.Text = $"Pelaaja 2: {player2Score}";
        }
        public void PaivitaKaannokset(int kaannokset)
        {
            lblKaannokset.Text = $"Käännökset: {kaannokset}";
        }
        public void PaivitaCurrentPlayer(int currentPlayer)
        {
            lblCurrentPlayer.Text = $"Vuoro: pelaaja {currentPlayer}";
        }
        public void NaytaGameOver(string message)
        {
            MessageBox.Show(message, "Peli päättyi");
            this.Close();
        }
        public void DisableLauta()
        {
            this.Enabled = false;
        }
        public void EnableLauta()
        {
            this.Enabled = true;
        }
    }
}
