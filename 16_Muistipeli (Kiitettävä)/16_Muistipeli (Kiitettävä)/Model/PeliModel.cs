using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Muistipeli__Kiitettävä_.Model
{
    public class PeliModel : IPeliModel
    {
        private static readonly List<string> elainSymbols = new List<string>
        {
            "🐶", "🐱", "🐭", "🐹", "🐰", "🦊", "🐻", "🐼", "🐨", "🦁",
            "🐯", "🐮", "🐷", "🐸", "🐵", "🐔", "🐧", "🐦"
        };

        private static readonly List<string> tyokaluSymbols = new List<string>
        {
            "🔧", "🔨", "⚖️", "🛡️", "🔩", "⚔️", "⚙️", "🗜️", "🔪", "⛓️",
            "🔫", "🛠️", "⛏️", "🔗", "🧲", "🧰", "🔬", "🔭"
        };

        private static readonly List<string> hedelmaSymbols = new List<string>
        {
            "🍎", "🍊", "🍋", "🍌", "🍉", "🍇", "🍓", "🍍", "🥭", "🍑",
            "🍒", "🥝", "🍅", "🍆", "🥑", "🥦", "🥕", "🌽"
        };
        private static readonly Dictionary<string, List<string>> themeSymbols = new Dictionary<string, List<string>>
        {
            { "Eläimet", elainSymbols },
            { "Työkalut", tyokaluSymbols },
            { "Hedelmät", hedelmaSymbols }
        };
        private Kortti[,] lauta;
        private int rivit;
        private int sarakkeet;
        private Random random;

        public PeliModel(int rivit, int sarakkeet, string teema)
        {
            this.rivit = rivit;
            this.sarakkeet = sarakkeet;
            lauta = new Kortti[rivit, sarakkeet];
            random = new Random();
            AlustaLauta(teema);
        }
        private void AlustaLauta(string teema)
        {
            int kokoKortit = rivit * sarakkeet;
            int parienmaara = kokoKortit / 2;
            List<string> selectedSymbols = themeSymbols[teema];

            List<string> symbolit = selectedSymbols.GetRange(0, parienmaara);
            List<Kortti> kortit = new List<Kortti>();
            foreach (string symboli in symbolit)
            {
                kortit.Add(new Kortti(symboli));
                kortit.Add(new Kortti(symboli));
            }
            for (int i = kortit.Count -1; i >= 0; i--)
            {
                int j = random.Next(0, i + 1);
                Kortti malli = kortit[i];
                kortit[i ]= kortit[j];
                kortit[j] = malli;
            }
            int indeksi = 0;
            for (int r = 0; r < rivit; r++)
            {
                for (int s = 0; s< sarakkeet; s++)
                {
                    lauta[r, s] = kortit[indeksi++];
                }
            }
        }
        public Kortti GetKortti(int rivi, int sarake)
        {
            return lauta[rivi, sarake];
        }

        public bool KaikkiOsumat()
        {
            foreach (Kortti kortti in lauta)
            {
                if (!kortti.OnOsuma) return false;
            }
            return true;
        }
        public void NaytaKortti(int rivi, int sarake)
        {
            lauta[rivi, sarake].OnKaannettu = true;
        }
        public void PiilotaKortit(int rivi1, int sarake1,int rivi2,int sarake2)
        {
            lauta[rivi1, sarake1].OnKaannettu = false;
            lauta[rivi2,sarake2].OnKaannettu = false;
        }
    }
}
