using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDotNet1
{
    class Program
    {
        static void Main(string[] args)
        {
            var heroes = new List<Hero>
            {
                new Hero("Max"),
                new Hero("AlexDarkStalker98"),
                new Hero("Gaben")
            };
            var party = new Party(heroes);
            var narrator = new Narrator();

            party.AddNarrator(narrator);
            narrator.AddParty(party);

            var startingScene = SceneFactory.LoadSampleStory();
            var currentScene = startingScene;

            Console.WriteLine(Game.WelcomeMessage);

            while(true)
            {
                bool chosenPath = true;
                narrator.Interact(currentScene);

                if(currentScene.SceneType == SceneType.Choice)
                {
                    Console.WriteLine("1) " + currentScene.SuccessPathDescription + "\n");
                    Console.WriteLine("2) " + currentScene.FailurePathDescription + "\n");
                    party.DisplayPartyInfo();

                    // переделай так,чтобы инфа о группе выводилась по-другому

                    //party.Interact(currentScene);
                    chosenPath = GetUserChoice();
                }

                try
                {
                    currentScene = currentScene.GetNextScene(chosenPath);
                }
                catch (SceneException)
                {
                    break;
                }
            }

            switch (currentScene.SceneType)
            {
                case SceneType.GoodEnding:
                    narrator.Say(Narrator.GoodEndingSpeech);
                    break;
                case SceneType.BadEnding:
                    narrator.Say(Narrator.BadEndingSpeech);
                    break;
            }

            Console.WriteLine(Game.GameOverMessage);

            // so that console won't disappear
            Console.ReadKey();
        }

        private static bool GetUserChoice()
        {
            do
            {
                Console.Write("$> ");
                string input = Console.ReadLine().Trim();
                if(int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            return true;
                        case 2:
                            return false;
                    }
                }
                Console.WriteLine("Unknown command, try one more time");
            } while (true);
        }
    }
}
