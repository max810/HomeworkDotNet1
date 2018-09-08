using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDotNet1
{
    class Narrator : IInteractiveCharacter
    {
        public event EventHandler<GameEventArgs> GameEvent;
        private static Random rnd = new Random();
        private static string[] SarcasticJokes = {
            "/Don't you hate it when someone answers their own questions? I do./",
            "/Mom? Mom, I told you not to call! I am working. Yes. Yes. Ok. Love you too. Bye.\n"
                + "...what are you giggling at?/",
            "/*Player tries to press something on the keyboard.* YOU HAVE NO POWER HERE!/"
        };

        public static string SarcasticJoke => SarcasticJokes[rnd.Next(0, SarcasticJokes.Length)];

        public static string AllDeadSpeech => "Oh Lord! Last joke I made was literally KILLING!";
        public static string BadEndingSpeech => "Nah. U all dead or cursed or whatever.";
        public static string GoodEndingSpeech => "WTF? You were supposed to die! *whispers* How did that get past QA?\n"
            + "What? We don't have QA? Well, that explains a lot.";

        public void Interact(IScene scene)
        {
            Console.WriteLine("Narrator: " + scene.Description + Environment.NewLine);
            if (rnd.Next(0, 10) > 5)
            {
                Say(SarcasticJoke);
            }

            if (scene.SceneType == SceneType.Choice)
            {
                FireGameEvent();
            }
        }

        public void Say(string speech)
        {
            if (!string.IsNullOrEmpty(speech))
            {
                Console.WriteLine("Narrator: " + speech + Environment.NewLine);
            }
        }

        public void AddParty(Party party)
        {
            foreach(var hero in party.Heroes)
            {
                hero.Death += OnHeroDeath;
            }

            party.AllDied += OnAllDied;
        }

        private void OnHeroDeath(object sender, EventArgs e)
        {
            Say($"Looks like {(sender as Hero).Name} has died.");
        }

        private void OnAllDied(object sender, EventArgs e)
        {
            Say($"I am sorry, little one, but the price was too much.\n" +
                $"The last hero was slain.");
        }

        private void FireGameEvent()
        {
            double n = rnd.NextDouble();
            var eventTypes = Game.EventProbabilites.Keys.ToArray();
            int i = rnd.Next(0, eventTypes.Length);
            var chosenType = eventTypes[i];

            if(n <= Game.EventProbabilites[chosenType])
            {
                GameEvent?.Invoke(this, new GameEventArgs(chosenType));
            }
        }
    }
}
