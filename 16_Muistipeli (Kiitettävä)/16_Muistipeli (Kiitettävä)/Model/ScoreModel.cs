using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace _16_Muistipeli__Kiitettävä_.Model
{
    public class ScoreModel : IScoreModel
    {
        private readonly string filePath = "scores.json";
        private Dictionary<string, int> scores;

        public ScoreModel()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                scores = JsonConvert.DeserializeObject<Dictionary<string, int>>(json) ?? new Dictionary<string, int>();
            }
            else
            {
                scores = new Dictionary<string, int>();
            }
        }
        public void TallennaScores(string key, int score)
        {
            if (scores.ContainsKey(key))
            {
                if (key.Contains("Yksinpeli") && score < scores[key])
                    scores[key] = score;
                else if (!key.Contains("Yksinpeli") && score > scores[key])
                    scores[key] = score;
            }
            else
            {
                scores[key] = score;
            }
            string json = JsonConvert.SerializeObject(scores,Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        public Dictionary<string,int> GetScores()
        {
            return scores;
        }
    }
}
