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
    public partial class ScoreForm : Form, IScoreView
    {
        private ListBox lstScores;
        public ScoreForm()
        {
            InitializeComponent();
            AsetaControls();
        }
        private void AsetaControls()
        {
            this.Size = new Size(300, 400);
            lstScores = new ListBox { Location = new Point(10, 10), Size = new Size(260, 300) };
            Button btnSulje = new Button { Text = "Sulje", Location = new Point(10, 320), Width = 100 };
            btnSulje.Click += (s, e) => this.Close();
            this.Controls.Add(lstScores);
            this.Controls.Add(btnSulje);
        }
        public void NaytaScores(Dictionary<string, int> scores)
        {
            lstScores.Items.Clear();
            foreach (var score in scores)
            {
                lstScores.Items.Add($"{score.Key}: {score.Value}");
            }
        }
    }
}
