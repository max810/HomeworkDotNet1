using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDotNet1
{
    class Party
    {
        public IList<Hero> Heroes { get; set; }

        public Party(IEnumerable<Hero> heroes)
        {
            Heroes = new List<Hero>(heroes);
        }

        public void Interact(IScene scene)
        {
            foreach(var hero in Heroes)
            {
                hero.Interact(scene);
            }
        }

        public double GetTotalModifier()
        {
            return Heroes.Sum(x => x.Luck / 10);
        }

        public bool AnyAlive()
        {
            return Heroes.Any(x => x.IsAlive);
        }

        public void DisplayPartyInfo()
        {
            StringBuilder res = new StringBuilder();
            foreach(var hero in Heroes)
            {
                res.AppendFormat($"{hero.Name}: ");
                if (hero.IsAlive)
                {
                    res.AppendFormat("{0:0.00}", hero.Luck);
                }
                else
                {
                    res.Append("DEAD");
                }
                res.Append(" | ");
            }

            Console.WriteLine(res.ToString());
        }
    }
}
