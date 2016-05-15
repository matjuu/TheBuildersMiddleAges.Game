using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TheBuildersMiddleAges.Game.Core.Parser
{
    public static class CardsParser
    {
        public static Deck<Building> ParseBuildingsDeck()
        {

            var cards = new List<Building>();
            string line;

            using (var stream = new FileStream("../TheBuildersMiddleAges.Game.Core/Parser/Resources/BuildingsStats.txt", FileMode.Open))
            using (var file = new StreamReader(stream))
            {
                while ((line = file.ReadLine()) != null)
                {
                    line = Regex.Replace(line, @"(\[)|(\])|([A-Za-z])|( )", "");
                    line = Regex.Replace(line, @",,", ",");
                    string[] stats = Regex.Split(line, @",");
                    int[] parsedStats = stats.Select(int.Parse).ToArray();
                    cards.Add(new Building(parsedStats[0],
                        new Resources(parsedStats[1], parsedStats[2], parsedStats[3], parsedStats[4]),
                        new Reward(parsedStats[5], parsedStats[6])));
                }
            }
          
            return new Deck<Building>(cards);
        }

        public static Deck<Worker> ParseWorkersDeck()
        {

            var cards = new List<Worker>();
            string line;

            using (var stream = new FileStream("../TheBuildersMiddleAges.Game.Core/Parser/Resources/WorkersStats.txt", FileMode.Open))
            using (var file = new StreamReader(stream))
            {

                while ((line = file.ReadLine()) != null)
                {
                    line = Regex.Replace(line, @"(\[)|(\])|([A-Za-z])|( )", "");
                    line = Regex.Replace(line, @",,", ",");
                    string[] stats = Regex.Split(line, @",");
                    int[] parsedStats = stats.Select(int.Parse).ToArray();
                    cards.Add(new Worker(parsedStats[0], new Resources(parsedStats[1], parsedStats[2], parsedStats[3], parsedStats[4])));
                }
            }

            return new Deck<Worker>(cards);
        }
    }
}
