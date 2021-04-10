using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WumpusClicker.Exceptions;
using WumpusClicker.Interfaces;

namespace WumpusClicker.Models
{
    public class Weapon : ITool
    {
        public Weapon(string name, ulong dmg, int level, ulong price, ulong dmgIncrease)
        {
            Name = name;
            Dmg = dmg;
            Level = level;
            Price = price;
            DmgIncrease = dmgIncrease;
        }

        public string Name { get; }
        public ulong Dmg { get; private set; }
        public int Level { get; private set; }
        public ulong Price { get; private set; }
        public ulong DmgIncrease { get; private set; }
        
        public void LevelUp(IPlayer player)
        {
            if (player.Money < Price)
                throw new InsufficientFundsException(player, this);

            Dmg += DmgIncrease;
        }

        public void DealDamageTo(IMonster monster)
        {
            monster.DoDamage(Dmg);
        }
    }
}
