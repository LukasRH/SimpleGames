using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WumpusClicker.Models;

namespace WumpusClicker.Interfaces
{
    internal interface ILobby
    {
        /// <summary>
        /// Event fired when <see cref="IAttacker"/>s do damage
        /// <para>Contains the <see cref="IMonster"/> which to deal damage too</para>
        /// </summary>
        public event Action<IMonster> DpsEvent;
        /// <summary>
        /// Event fired when a <see cref="IMonster"/> take damage
        /// <para>Contains <see cref="IMonster"/> that took damage, and the <see cref="ulong"/> damage it took</para>
        /// </summary>
        public event Action<IMonster, ulong> OnMonsterDamage;
        /// <summary>
        /// Event fired when a <see cref="IMonster"/> dies
        /// <para>Contains <see cref="IMonster"/> that died, and the <see cref="ulong"/> reward</para>
        /// </summary>
        public event Action<IMonster, ulong> OnMonsterDeath;
        /// <summary>
        /// Event fired when a new <see cref="IAttacker"/> spawns
        /// <para>Contains the <see cref="IMonster"/> that spawned</para>
        /// </summary>
        public event Action<IMonster> OnNewMonster;
        /// <summary>
        /// Event fired when the lobby levels up
        /// <para>Contains the new lobby level</para>
        /// </summary>
        public event Action<uint> OnLevelUp; 

        /// <summary>
        /// The lobbies level
        /// </summary>
        public uint Level { get; }
        /// <summary>
        /// The list of minions to beat before the boos
        /// </summary>
        public IList<Minion> Minions { get; }
        /// <summary>
        /// The level boss
        /// </summary>
        public Boss Boss { get; }
    }
}
