using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDotNet1
{
    static class Game
    {
        public static string WelcomeMessage => "Welcome to Don Jones owned wagons!\n"
            + "This is an interactive non-visual novel.\n"
            + "Anywhere you will be given two choices - 1) and 2)\n"
            + "To choose, simply press 1 or 2 and hit <Enter>\n"
            + "Let the battle begin!\n"
            + "(Oopsie, wrong game)\n";

        public static string GameOverMessage => "Game Over.\n" +
            "Insert coin.";

        public static IDictionary<EventType, double> EventProbabilites { get; }
            = new Dictionary<EventType, double>
            {
                {EventType.Death, 0.2},
                {EventType.TreasureFound, 0.6 },
                {EventType.TreasureLost, 0.4 }
            };
    }
}
