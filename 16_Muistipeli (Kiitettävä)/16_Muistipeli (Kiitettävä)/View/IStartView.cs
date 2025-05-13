using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Muistipeli__Kiitettävä_.View
{
    public interface IStartView
    {
        event EventHandler AloitaPeli;
        event EventHandler NaytaScores;
        string Pelimuoto {  get; }
        string LautaKoko { get; }
        string Teema {  get; }
        void NaytaError(string message);
        void Nayta();
    }
}
