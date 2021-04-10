using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WumpusClicker.Exceptions;

namespace WumpusClicker.Interfaces
{
    /// <summary>
    /// Object that deals damage to a <see cref="IMonster"/>
    /// </summary>
    public interface IDamageDealer
    {
        /// <summary>
        /// The object's name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The Object's level 
        /// </summary>
        public int Level { get; }
        /// <summary>
        /// The price to upgrade the object
        /// </summary>
        public ulong Price { get; }

        /// <summary>
        /// Level up the object to the next <see cref="Level"/> by withdrawing the <see cref="Price"/> from the <paramref name="player"/>'s money
        /// </summary>
        /// <exception cref="InsufficientFundsException">Thrown when <paramref name="player"/> can not afford the upgrade</exception>
        /// <param name="player"></param>
        public void LevelUp(IPlayer player);

        /// <summary>
        /// Deal <see cref="Dmg"/> to <paramref name="monster"/>
        /// </summary>
        /// <param name="monster"></param>
        public void DealDamageTo(IMonster monster);
    }
}
