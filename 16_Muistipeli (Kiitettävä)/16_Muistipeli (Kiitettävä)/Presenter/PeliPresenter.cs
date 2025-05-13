using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _16_Muistipeli__Kiitettävä_.Model;
using _16_Muistipeli__Kiitettävä_.View;

namespace _16_Muistipeli__Kiitettävä_.Presenter
{
    public class PeliPresenter
    {
        private readonly IPeliView _view;
        private readonly IPeliModel _model;
        private readonly IScoreModel _ScoreModel;
        private readonly bool onYksinpeli;
        private readonly string teema;
        private int player1Score = 0;
        private int player2Score = 0;
        private int currentPlayer = 1;
        private int kaannokset = 0;
        private Kortti ekaKortti = null;
        private Kortti tokaKortti = null;
        private int ekaRivi = -1;
        private int ekaSarake = -1;
        private int tokaRivi = -1;
        private int tokaSarake = -1;

        public PeliPresenter(IPeliModel model, IPeliView view, bool onYksinPeli, string teema)
        {
            this._model = model;
            this._view = view;
            this.onYksinpeli = onYksinPeli;
            this.teema = teema;
            this._ScoreModel = new ScoreModel();
            view.KorttiClicked += View_KorttiClicked;
            view.PaivitaScore(player1Score, player2Score);
            if (!onYksinPeli) view.PaivitaCurrentPlayer(currentPlayer);
            if (onYksinpeli) view.PaivitaKaannokset(kaannokset);
        }
        private void View_KorttiClicked(object sender, KorttiClickEventArgs e)
        {
            int rivi = e.Rivi;
            int sarake = e.Sarake;
            Kortti kortti = _model.GetKortti(rivi, sarake);
            if (kortti.OnKaannettu || kortti.OnOsuma) 
                return;
            _model.NaytaKortti(rivi, sarake);
            _view.PaivitaKortti(rivi, sarake, kortti.symboli, true);
            kaannokset++;
            if (onYksinpeli) _view.PaivitaKaannokset(kaannokset);

            if (ekaKortti == null)
            {
                ekaKortti= kortti;
                ekaRivi = rivi;
                ekaSarake = sarake;
            }
            else if (tokaKortti == null)
            {
                tokaKortti = kortti;
                tokaRivi = rivi;
                tokaSarake= sarake;

                if (ekaKortti.symboli == tokaKortti.symboli)
                {
                    ekaKortti.OnOsuma = true;
                    tokaKortti.OnOsuma = true;
                    if (onYksinpeli)
                    {
                        player1Score++;
                        _view.PaivitaScore(player1Score, player2Score);
                    }
                    else
                    {
                        if (currentPlayer == 1)
                            player1Score++;
                        else
                            player2Score++;
                        _view.PaivitaScore(player1Score,player2Score);
                    }
                    ekaKortti = null;
                    tokaKortti = null;
                    ekaRivi = -1;
                    ekaSarake = -1;
                    tokaRivi= -1;
                    tokaSarake=-1;
                    if (_model.KaikkiOsumat())
                    {
                        if (onYksinpeli)
                        {
                            string key = $"Yksinpeli {rivi}x{sarake} {teema}";
                            _ScoreModel.TallennaScores(key, kaannokset);
                            _view.NaytaGameOver($"Peli päättyi! Käännöksiä: {kaannokset}");
                        }
                        else
                        {
                            string voittaja = player1Score > player2Score ? "Pelaaja 1" : player2Score > player1Score ? "Pelaaja 2" : "Tasapeli";
                            string key = $"Kaksinpeli {rivi}x{sarake} {teema} Pelaaja {voittaja}";
                            _ScoreModel.TallennaScores(key, voittaja == "Pelaaja 1" ? player1Score : player2Score);
                            _view.NaytaGameOver($"Peli päättyi! Voittaja: {voittaja}\nPelaaja 1: {player1Score}\nPelaaja 2: {player2Score}");
                        }
                    }
                }
                else
                {
                    _view.DisableLauta();
                    Timer timer = new Timer { Interval = 1000 };
                    timer.Tick += (s, ev) =>
                    {
                        _model.PiilotaKortit(ekaRivi,ekaSarake,tokaRivi,tokaSarake);
                        _view.PaivitaKortti(ekaRivi, ekaSarake, ekaKortti.symboli, false);
                        _view.PaivitaKortti(tokaRivi, tokaSarake, tokaKortti.symboli, false);
                        ekaKortti = null;
                        tokaKortti= null;
                        ekaRivi = -1;
                        ekaSarake = -1;
                        tokaRivi = -1;
                        tokaSarake= -1;
                        if (!onYksinpeli)
                        {
                            currentPlayer = currentPlayer == 1 ? 2 : 1;
                            _view.PaivitaCurrentPlayer(currentPlayer);
                        }
                        _view.EnableLauta();
                        timer.Stop();
                    };
                    timer.Start();
                }
            }
        }
    }
}