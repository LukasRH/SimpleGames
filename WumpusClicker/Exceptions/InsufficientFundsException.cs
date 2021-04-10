using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WumpusClicker.Interfaces;

namespace WumpusClicker.Exceptions
{
    /// <summary>
    /// Exception thrown when a <see cref="IPlayer"/> do not have enough money to upgrade a <see cref="IAttacker"/>
    /// </summary>
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(IPlayer player, IDamageDealer obj) : base($"{player.Name} have insufficient funds to upgrade {obj.Name}: {player.Money} / {obj.Price}")
        {
        }
    }
}
