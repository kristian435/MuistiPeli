using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _16_Muistipeli__Kiitettävä_.Model;

namespace _16_Muistipeli__Kiitettävä_.View
{
    public interface IPeliView
    {
        event EventHandler<KorttiClickEventArgs> KorttiClicked;
        void PaivitaKortti(int rivi, int sarake, string symboli, bool OnEsilla);
        void PaivitaScore(int player1Score, int player2Score);
        void PaivitaKaannokset(int kaannokset);
        void PaivitaCurrentPlayer(int currentPlayer);
        void NaytaGameOver(string message);
        void DisableLauta();
        void EnableLauta();
    }
    public class KorttiClickEventArgs : EventArgs
    {
        public int Rivi { get; }
        public int Sarake { get; }

        public KorttiClickEventArgs(int row, int col)
        {
            Rivi = row;
            Sarake = col;
        }
    }
}
