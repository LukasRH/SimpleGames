using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WumpusClicker.Exceptions;
using WumpusClicker.Interfaces;

namespace WumpusClicker.Models
{
    public class Attacker : IAttacker
    {
        public Attacker(string name, int level, ulong price, ulong dps, ulong dpsIncrease)
        {
            Name = name;
            Level = level;
            Price = price;
            Dps = dps;
            DpsIncrease = dpsIncrease;
        }

        public string Name { get; }
        public int Level { get; private set; }
        public ulong Price { get; private set; }
        public ulong Dps { get; private set; }
        public ulong DpsIncrease { get; }

        public void LevelUp(IPlayer player)
        {
            if (player.Money < Price)
                throw new InsufficientFundsException(player, this);

            Dps += DpsIncrease;
        }

        public void DealDamageTo(IMonster monster)
        {
            if (Level > 0)
                monster.DoDamage(Dps);
        }

        
    }
}
