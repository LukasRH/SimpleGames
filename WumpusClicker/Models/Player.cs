using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WumpusClicker.Interfaces;

namespace WumpusClicker.Models
{
    public class Player : IPlayer
    {
        public Player(string name, ITool weapon, ulong money, IList<IAttacker> attackers)
        {
            Name = name;
            Weapon = weapon;
            Money = money;
            Attackers = attackers;
        }

        public string Name { get; }
        public ITool Weapon { get; }
        public ulong Money { get; }
        public IList<IAttacker> Attackers { get; }
        public void Attack(IMonster monster)
        {
            Weapon.DealDamageTo(monster);
        }
    }
}
