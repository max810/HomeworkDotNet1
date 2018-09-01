using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDotNet1
{
    class Hero : IInteractiveCharacter
    {
        // to modify scene.SuccessChance
        public double Luck { get; set; }
        public string Name { get; set; }

        // replace with event?
        public bool IsAlive { get; private set; } = true;

        private Random rnd = new Random();

        public void Interact(IScene scene)
        {
            Luck += (rnd.NextDouble() - 0.5) / 2.0;

            if(IsAlive && Luck < scene.LuckNeeded / 2)
            {
                Die();
            }
        }

        private void Die()
        {
            Console.WriteLine($"{Name}: Mr Player, I don't feel so good... *Dies*");
            IsAlive = false;
        }

        public Hero(string name, double luck)
        {
            Name = name;
            Luck = luck;
        }
    }
}
