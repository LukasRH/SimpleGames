using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WumpusClicker.Interfaces;
using WumpusClicker.Models;

namespace WumpusClicker
{
    public class SoloLobby : ISoloLobby
    {
        public event Action<IMonster> DpsEvent;
        public event Action<IMonster, ulong> OnMonsterDamage;
        public event Action<IMonster, ulong> OnMonsterDeath;
        public event Action<IMonster> OnNewMonster;
        public event Action<uint> OnLevelUp;

        public SoloLobby(uint level, int mpl, IPlayer player)
        {
            Level = level;
            MPL = mpl;
            Player = player;

            GenerateMinions();
            GenerateBoss();

            _timer = new Timer(1000);
            _timer.Elapsed += Timer_Elapsed;

            _timer.Start();
        }

        public uint Level { get; private set; }
        public int MPL { get; }
        public IList<Minion> Minions { get; private set; }
        public Boss Boss { get; private set; }
        public IPlayer Player { get; }

        private IMonster _currentMonster;
        private readonly Timer _timer;


        public void PlayerAttack()
        {
            Player.Attack(_currentMonster);
        }

        private void DealAttackerDamage(IMonster monster)
        {
            long totalDamage = Player.Attackers.Sum(attacker => (long)attacker.Dps);
            _currentMonster.DoDamage((ulong)totalDamage);
        }

        private void GenerateMinions()
        {
            Minions = Enumerable.Repeat(0, MPL).Select(_ => Minion.GenerateMinion(Level)).ToList();
            foreach (var minion in Minions)
            {
                minion.OnDeath += Minion_OnDeath;
                minion.TookDamage += Minion_TookDamage;
            }

            _currentMonster = Minions.First();
        }

        private void Minion_TookDamage(IMonster minion, ulong dmg)
        {
            OnMonsterDamage?.Invoke(minion, dmg);
        }

        private void Minion_OnDeath(IMonster minion, ulong reward)
        {
            OnMonsterDeath?.Invoke(minion, reward);
            Minions.Remove((Minion) minion);

            if (Minions.Count == 0)
                _currentMonster = Boss;
            else
                _currentMonster = Minions.First();

            OnNewMonster?.Invoke(_currentMonster);
        }

        private void GenerateBoss()
        {
            Boss = Boss.GenerateMinion(Level);
            Boss.OnDeath += Boss_OnDeath;
            Boss.TookDamage += Boss_TookDamage;
        }

        private void Boss_TookDamage(IMonster boss, ulong dmg)
        {
            OnMonsterDamage?.Invoke(boss, dmg);
        }

        private void Boss_OnDeath(IMonster boss, ulong reward)
        {
            Level++;
            OnMonsterDeath?.Invoke(boss, reward);
            OnLevelUp?.Invoke(Level);
            GenerateMinions();
            GenerateBoss();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //DpsEvent?.Invoke(_currentMonster);
            DealAttackerDamage(_currentMonster);
        }
    }
}
