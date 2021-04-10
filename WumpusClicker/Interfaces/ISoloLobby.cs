using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusClicker.Interfaces
{
    interface ISoloLobby : ILobby
    {
        /// <summary>
        /// The <see cref="IPlayer"/> that the lobby belong too
        /// </summary>
        public IPlayer Player { get; }
        /// <summary>
        /// Have the <see cref="Player"/> attack the <see cref="IMonster"/>
        /// </summary>
        public void PlayerAttack();
    }
}
