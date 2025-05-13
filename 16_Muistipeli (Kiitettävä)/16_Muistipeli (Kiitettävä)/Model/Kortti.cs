using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Muistipeli__Kiitettävä_.Model
{
    public class Kortti
    {
        public string symboli {  get; set; }
        public bool OnKaannettu {  get; set; }
        public bool OnOsuma {  get; set; }
        public Kortti(string symboli)
        {
            this.symboli = symboli;
            OnKaannettu = false;
            OnOsuma = false;
        }
    }
}
