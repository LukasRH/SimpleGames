using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WumpusClicker.Exceptions;

namespace WumpusClicker.Interfaces
{
    /// <summary>
    /// A tool which a <see cref="IPlayer"/> can use to deal damage to a <see cref="IMonster"/>
    /// </summary>
    public interface ITool : IDamageDealer
    {
        /// <summary>
        /// The damage dealt per hit
        /// </summary>
        public ulong Dmg { get; }
        /// <summary>
        /// The amount to increase the <see cref="Dmg"/> on a upgrade 
        /// </summary>
        public ulong DmgIncrease { get; }
    }
}
