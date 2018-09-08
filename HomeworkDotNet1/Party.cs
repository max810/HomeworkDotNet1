using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDotNet1
{
    class Party
    {
        public event EventHandler AllDied;
        public IList<Hero> Heroes { get; set; }
        public int Money { get; set; } = 50;
        private Random rnd = new Random();

        public Party(IEnumerable<Hero> heroes)
        {
            Heroes = new List<Hero>(heroes);
        }

        public void Interact(IScene scene)
        {
            foreach (var hero in Heroes)
            {
                hero.Interact(scene);
            }
        }

        public bool AnyAlive()
        {
            return Heroes.Any(x => x.IsAlive);
        }

        public void DisplayPartyInfo()
        {
            Console.Write("Party: ");
            StringBuilder res = new StringBuilder();
            foreach (var hero in Heroes)
            {
                res.Append(hero.ToString());
                res.Append(" | ");
            }

            Console.WriteLine(res.ToString() + "\n");
        }

        public void AddNarrator(Narrator narrator)
        {
            narrator.GameEvent += OnGameEvent;
        }

        private void OnGameEvent(object sender, GameEventArgs e)
        {
            int n;
            switch (e.EventType)
            {
                case EventType.Death:
                    if (Heroes.Any(x => x.IsAlive))
                    {
                        n = rnd.Next(0, Heroes.Count);
                        for (; ; n = (n + 1) % Heroes.Count)
                        {
                            if (Heroes[n].IsAlive)
                            {
                                Heroes[n].Die();
                                break;
                            }
                        }
                    }
                    else
                    {
                        AllDied?.Invoke(this, new EventArgs());
                    }
                    break;
                case EventType.TreasureFound:
                    n = rnd.Next(10, 100);
                    Money += n;
                    Console.WriteLine($"HellYeah! Your party found some gold coins: {n}.\n");
                    break;
                case EventType.TreasureLost:
                    n = rnd.Next(Money / 4, Money / 2);
                    Money -= n;
                    Console.WriteLine($"Oopsie! One of your party members dropped a sack of coins.\n" +
                        $"Your lost {n} gold ({Money} left).\n");
                    break;
            }
        }
    }
}
