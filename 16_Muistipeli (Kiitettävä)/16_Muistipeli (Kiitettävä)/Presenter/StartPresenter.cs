using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _16_Muistipeli__Kiitettävä_.Model;
using _16_Muistipeli__Kiitettävä_.View;

namespace _16_Muistipeli__Kiitettävä_.Presenter
{
    public class StartPresenter
    {
        private readonly IStartView view;
        public StartPresenter(IStartView view)
        {
            this.view = view;
            view.AloitaPeli += View_AloitaPeli;
            view.NaytaScores += View_NaytaScores;
            view.Nayta();
        }
        public void View_AloitaPeli(object sender, EventArgs e)
        {
            string peliMuoto = view.Pelimuoto;
            string alustaLauta = view.LautaKoko;
            string teema = view.Teema;
            int rivit = alustaLauta == "4x4" ? 4 : 6;
            int sarakkeet = alustaLauta == "4x4" ? 4 : 6;
            bool onYksinPeli = peliMuoto == "Yksinpeli";
            IPeliView peliView = new PeliForm(rivit,sarakkeet,onYksinPeli);
            IPeliModel peliModel = new PeliModel(rivit, sarakkeet, teema);
            new PeliPresenter(peliModel, peliView,onYksinPeli, teema);
            ((Form)peliView).Show();
        }
        private void View_NaytaScores(object sender, EventArgs e)
        {
            IScoreView scoreView = new ScoreForm();
            new ScorePresenter(scoreView);
            ((Form)scoreView).ShowDialog();
        }
    }
}
