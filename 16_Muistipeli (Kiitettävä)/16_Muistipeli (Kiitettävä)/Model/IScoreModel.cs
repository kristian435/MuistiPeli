using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Muistipeli__Kiitettävä_.Model
{
    public interface IScoreModel
    {
        void TallennaScores(string avain, int score);
        Dictionary<string, int> GetScores();
    }
}
