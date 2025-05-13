using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Muistipeli__Kiitettävä_.Model
{
    public interface IPeliModel
    {
        Kortti GetKortti(int rivi, int sarake);
        bool KaikkiOsumat();
        void NaytaKortti(int rivi, int sarake);
        void PiilotaKortit(int rivi1, int sarake1, int rivi2, int sarake2);
    }
}
