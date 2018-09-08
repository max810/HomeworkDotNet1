using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDotNet1
{
    public static class SceneFactory
    {
        public static IScene CreateTextScene(string description)
        {
            Scene scene = new Scene()
            {
                Description = description,
                SceneType = SceneType.Text
            };

            return scene;
        }

        public static IScene CreateBadEndingScene(string description)
        {
            Scene scene = new Scene()
            {
                Description = description,
                SceneType = SceneType.BadEnding
            };

            return scene;
        }

        public static IScene CreateGoodEndingScene(string description)
        {
            Scene scene = new Scene()
            {
                Description = description,
                SceneType = SceneType.GoodEnding
            };

            return scene;
        }

        public static IScene CreateChoiceScene(string description, double successChance, string successPathDescription, string failurePathDescription)
        {
            Scene scene = new Scene()
            {
                Description = description,
                SceneType = SceneType.Choice,
                SuccessPathDescription = successPathDescription,
                FailurePathDescription = failurePathDescription,
            };

            return scene;
        }

        public static IScene LoadSampleStory()
        {
            var s0 = CreateTextScene("You and your friends wake up with a hangover in a dark cave.\n"
                + "Nobody remebers what happened.");

            var s00 = CreateChoiceScene("After a few minutes you manage to find a torch on the floor and light it.\n"
                + "You are still in a cave. You see two tonnels - left and right.",
                0.4,
                "\"Me go left.\" Who even goes right? Do such people exist?",
                "Hitler == bad. Hitler wasn't right. Right != bad. Right = good.\n"
                + "Spit on the floor and take your party to the right tonnel."
            );


            var s000 = CreateChoiceScene("There is a sphynx in the next room. Yep, so unoriginal. What does it even do here?\n"
                + "Anyway, it gives you a riddle.\n" 
                + "\"You are convicted to death. You can enter one of the following rooms:\n"
                + "1) The room full of raging fires.\n"
                + "2) The room full of assassins with loaded guns.\n"
                + "3) The room with lions who haven't eaten in years.\n"
                + "Which room is the safest?\"",
                1.1,
                "Umm... the third one? The lions are all prolly dead by now.",
                "LEEEROOOOY JEEENKINS!!!"
            );

            var s001 = CreateBadEndingScene("Well, you've chosen not the RIGHT way, bro)\n"
                + "You fall in the hidden pit trap. And die."
            );

            var s0000 = CreateTextScene("\"You are right\" - says the sphynx. And you continue your long and interesting journey.\n"
                + "Which i ain't gonna describe, I'm still not paid for this.");

            var s0001 = CreateBadEndingScene("NOPE. Just NOPE. Sphynx eats you all. Now YOU are the chicken.\n"
                + "P.S. Never let barbarians make their moves first.");

            var s00000 = CreateGoodEndingScene("Finally, after organizing a genocide of innocent goblins and cannibals, you see the light.\n"
                + "Your journey is over! Happy end!");


            s0.SuccessPathScene = s00;

            s00.SuccessPathScene = s000;
            s00.FailurePathScene = s001;

            s000.SuccessPathScene = s0000;
            s000.FailurePathScene = s0001;

            s0000.SuccessPathScene = s00000;

            return s0;
        }
    }
}
