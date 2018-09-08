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
        public event EventHandler Death;
        public string Name { get; set; }

        // replace with event?
        public bool IsAlive { get; private set; } = true;

        private Random rnd = new Random();

        public void Interact(IScene scene)
        {

        }

        public void Die()
        {
            Console.WriteLine($"{Name}: Mr Player, I don't feel so good...");
            IsAlive = false;
            Death?.Invoke(this, new EventArgs());
        }

        public override string ToString()
        {
            return $"{Name}, {(IsAlive ? "Alive" : "Dead")}";
        }

        public Hero(string name)
        {
            Name = name;
        }

        
    }
}
