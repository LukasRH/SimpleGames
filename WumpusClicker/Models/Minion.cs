using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WumpusClicker.Data;
using WumpusClicker.Interfaces;

namespace WumpusClicker.Models
{
    /// <summary>
    /// A smaller enemy in the game, usually defeated on the way to a <see cref="Boss"/> 
    /// </summary>
    public class Minion : IMonster
    {
        public event Action<IMonster, ulong> OnDeath;
        public event Action<IMonster, ulong> TookDamage;

        public Minion(string name, ulong health, ulong reward)
        {
            this.Name = name;
            this.Health = health;
            this.Reward = reward;
        }

        public string Name { get; }
        public ulong Health { get; private set; }
        public ulong Reward { get; }
        
        public void DoDamage(ulong dmg)
        {
            if (Health == 0)
                return;

            if (dmg >= Health)
            {
                // Monster is dead
                Health = 0;
                OnDeath?.Invoke(this, Reward);
            }
            else
            {
                // Do damage to monster
                Health -= dmg;
                TookDamage?.Invoke(this, dmg);
            }
        }

        public static Minion GenerateMinion(uint level)
        {
            var rnd = new Random();
            return new Minion(Minions.Names[rnd.Next(Minions.Names.Count)], 10 * level, 10 * level);
        }
    }
}
