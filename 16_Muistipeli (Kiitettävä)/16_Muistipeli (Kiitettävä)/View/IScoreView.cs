using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Muistipeli__Kiitettävä_.View
{
    public interface IScoreView
    {
        void NaytaScores(Dictionary<string, int> scores);
    }
}
