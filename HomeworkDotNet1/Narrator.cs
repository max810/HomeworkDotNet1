using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDotNet1
{
    class Narrator : IInteractiveCharacter
    {
        private static Random rnd = new Random();
        private static string[] SarcasticJokes = {
            "Don't you hate it when someone answers their own questions? I do.",
            "Mom? Mom, I told you not to call! I am working. Yes. Yes. Ok. Love you too. Bye. ... What are you giggling at?",
            "*Player tries to press something on the keyboard.* YOU HAVE NO POWER HERE!"
        };

        public static string SarcasticJoke => SarcasticJokes[rnd.Next(0, SarcasticJokes.Length)];

        public static string AllDeadSpeech => "Oh Lord! Last joke I made was literally KILLING!";
        public static string BadEndSpeech => "Nah. U all dead or cursed or whatever. Game over.";
        public static string GoodEndSpeech => "WTF? You were supposed to die! *whispers* How did that get past QA?"
            + Environment.NewLine 
            + "What? We don't have QA? Well, it explains a lot.";

        public void Interact(IScene scene)
        {
            Console.WriteLine("Narrator: " + scene.Description);
            if(rnd.Next(0, 10) > 5)
            {
                Say(SarcasticJoke);
            }
        }

        public void Say(string speech)
        {
            Console.WriteLine("Narrator: " + speech);
        }
    }
}
