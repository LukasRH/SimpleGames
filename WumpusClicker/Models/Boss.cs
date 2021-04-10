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
    /// A level boss, with higher health then the <see cref="Minion"/>s before it
    /// </summary>
    public class Boss : IMonster
    {
        public event Action<IMonster, ulong> OnDeath;
        public event Action<IMonster, ulong> TookDamage;

        public Boss(string name, ulong health, ulong reward)
        {
            Name = name;
            Health = health;
            Reward = reward;
        }

        public string Name { get; }
        public ulong Health { get; private set; }
        public ulong Reward { get; }
        
        public void DoDamage(ulong dmg)
        {
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

        public static Boss GenerateMinion(uint level)
        {
            var rnd = new Random();
            return new Boss(Bosses.Names[rnd.Next(Bosses.Names.Count)], 100 * level, 50 * level);
        }
    }
}
