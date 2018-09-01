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
                new Hero("Max", 0.5),
                new Hero("AlexDarkStalker98", 1.0),
                new Hero("Gaben", 0.1)
            };
            var party = new Party(heroes);

            var narrator = new Narrator();

            var startingScene = SceneFactory.LoadDefaultStory();

            var currentScene = startingScene;

            while (currentScene.SceneType != SceneTypes.BadEnding)
            {
                narrator.Interact(currentScene);
                party.Interact(currentScene);
                if (party.AnyAlive())
                {
                    double modifier = party.GetTotalModifier();
                    var nextScene = currentScene.GetNextScene(modifier);
                    narrator.Say(
                        nextScene == currentScene.SuccessPath
                        ? currentScene.SuccessPathDescription
                        : currentScene.FailurePathDescription
                    );
                    currentScene = nextScene;
                }
                else
                {
                    narrator.Say(Narrator.AllDeadSpeech);
                    break;
                }
            }
            // create party
            // load default story-tree
            // while !death-scene && any alive
            // - narrator interact
            // - players interact
            // - narrator say success/failure description
            // - update next scene
            // Game Over!

            // so that console won't disappear
            Console.ReadKey();
        }
    }
}
