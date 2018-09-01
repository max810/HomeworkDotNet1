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
                IsRandom = false,
                LuckNeeded = 0,
                SceneType = SceneTypes.Text
            };

            return scene;
        }

        public static IScene CreateBadEndingScene(string description)
        {
            Scene scene = new Scene()
            {
                Description = description,
                IsRandom = false,
                LuckNeeded = 0,
                SceneType = SceneTypes.BadEnding
            };

            return scene;
        }

        public static IScene CreateGoodEndingScene(string description)
        {
            Scene scene = new Scene()
            {
                Description = description,
                IsRandom = false,
                LuckNeeded = 0,
                SceneType = SceneTypes.GoodEnding
            };

            return scene;
        }

        public static IScene CreateChoiceScene(string description, double successChance, string successPathDescription, string failurePathDescription)
        {
            Scene scene = new Scene()
            {
                Description = description,
                IsRandom = true,
                LuckNeeded = successChance,
                SceneType = SceneTypes.Choice,
                SuccessPathDescription = successPathDescription,
                FailurePathDescription = failurePathDescription,
            };

            return scene;
        }

        public static IScene LoadSampleStory()
        {
            var s0 = CreateTextScene("You and your friends wake up with a hangover in a dark cave."
                + Environment.NewLine
                + "Nobody remebers what happened.");

            var s00 = CreateChoiceScene("After a few minutes you manage to find a torch on the floor and light it."
                + Environment.NewLine
                + "You are still in a cave. You see two tonnels - left and right.",
                0.4,
                "\"Me go left.\" Who even goes right? Do such people exist?",
                "Hitler == bad. Hitler wasn't right. Right != bad. Right = good."
                + Environment.NewLine
                + "You spit on the floor, take your friends with you and slowly proceed to the right tonnel"
            );


            var s000 = CreateChoiceScene("There is a sphynx in the next room. Yep, so unoriginal. What does it even do here?"
                + Environment.NewLine
                + "Anyway, it gives you a riddle." 
                + Environment.NewLine
                + "\"You are convicted to death. You can enter one of the following rooms:"
                + Environment.NewLine
                + "1) The room full of raging fires."
                + Environment.NewLine
                + "2) The room full of assassins with loaded guns."
                + Environment.NewLine
                + "3) The room with lions who haven't eaten in years."
                + Environment.NewLine
                + "Which room is the safest?\"",
                1.1,
                "Umm... the third one? The lions are all prolly dead by now.",
                "LEEEROOOOY JEEENKINS!!!"
            );

            var s001 = CreateBadEndingScene("Well, you've chosen not the RIGHT way, bro)"
                + Environment.NewLine
                + "You fall in the hidden pit trap. And die."
            );

            var s0000 = CreateTextScene("\"You are right\" - says the sphynx. And you continue your long and interesting journey."
                + Environment.NewLine
                + "Which i ain't gonna describe, I'm still not paid for this.");

            var s0001 = CreateBadEndingScene("NOPE. Just NOPE. Sphynx eats you all. Now YOU are the chicken."
                + Environment.NewLine
                + "P.S. Never let barbarians make their moves first.");

            var s00000 = CreateGoodEndingScene("Finally, after organizing a genocide of innocent goblins and cannibals, you see tha light."
                + Environment.NewLine
                + "Your journey is over! Happy end!");


            s0.SuccessPath = s00;

            s00.SuccessPath = s000;
            s00.FailurePath = s001;

            s000.SuccessPath = s0000;
            s000.FailurePath = s0001;

            s0000.SuccessPath = s00000;

            return s0;
        }
    }
}
