using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusClicker.Interfaces
{
    /// <summary>
    /// The controllable player
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// The players name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The primary <see cref="ITool"/> that will be used to deal damage to a <see cref="IMonster"/> on hits
        /// </summary>
        public ITool Weapon { get; }
        /// <summary>
        /// The players funds
        /// </summary>
        public ulong Money { get; }
        /// <summary>
        /// The players <see cref="IAttacker"/>s
        /// </summary>
        public IList<IAttacker> Attackers { get; }

        /// <summary>
        /// Attack a monster
        /// </summary>
        /// <param name="monster">The monster to attack</param>
        public void Attack(IMonster monster);
    }
}
