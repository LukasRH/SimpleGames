using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusClicker.Interfaces
{
    /// <summary>
    /// A monster to defeat
    /// </summary>
    public interface IMonster
    {
        /// <summary>
        /// The Monster's name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The Monster's health
        /// </summary>
        public ulong Health { get; }
        /// <summary>
        /// The reward earned by killing the monster
        /// </summary>
        public ulong Reward { get; }

        /// <summary>
        /// Event raised then the monster dies
        /// </summary>
        public event Action<IMonster, ulong> OnDeath;

        /// <summary>
        /// Event raised when the monster takes damage
        /// </summary>
        public event Action<IMonster, ulong> TookDamage;

        /// <summary>
        /// Deal the specified <paramref name="dmg"/> to the monster
        /// </summary>
        /// <param name="dmg">The damage to deal</param>
        public void DoDamage(ulong dmg);
    }
}
