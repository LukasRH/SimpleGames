using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WumpusClicker.Exceptions;

namespace WumpusClicker.Interfaces
{
    /// <summary>
    /// An attacker which a <see cref="IPlayer"/> can use to deal damage to a <see cref="IMonster"/>
    /// </summary>
    public interface IAttacker : IDamageDealer
    {
        /// <summary>
        /// The damage dealt per second
        /// </summary>
        public ulong Dps { get; }
        /// <summary>
        /// The amount to increase the <see cref="Dps"/> on a upgrade 
        /// </summary>
        public ulong DpsIncrease { get; }
    }
}
