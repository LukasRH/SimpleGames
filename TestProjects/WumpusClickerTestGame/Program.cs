using System;
using System.Collections.Generic;
using WumpusClicker;
using WumpusClicker.Interfaces;
using WumpusClicker.Models;

namespace WumpusClickerTestGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var hammer = new Weapon("Hammer", 1, 1, 10, 1);
            var attackers = new List<IAttacker>()
            {
                new Attacker("Bob", 1, 100, 1, 5),
                new Attacker("Jens", 1, 250, 1, 50)
            };
            var player = new Player("Luke", hammer, 0, attackers);

            var lobby = new SoloLobby(1, 10, player);

            lobby.OnMonsterDamage += Monster_TookDamage;
            lobby.OnMonsterDeath += Monster_OnDeath;
            lobby.OnLevelUp += Lobby_OnLevelUp;
            lobby.OnNewMonster += Lobby_OnNewMonster;

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    lobby.PlayerAttack();
                }
            } while (keyInfo.Key != ConsoleKey.X);
        }

        private static void Lobby_OnNewMonster(IMonster obj)
        {
            Console.WriteLine($"A {obj.Name} have spawned with {obj.Health}HP");
        }

        private static void Lobby_OnLevelUp(uint obj)
        {
            Console.WriteLine($"Lobby leveled up to Level {obj}");
        }

        private static void Monster_OnDeath(IMonster monster, ulong reward)
        {
            Console.WriteLine($"{monster.Name} died!, you have been rewarded {reward} coins");
        }

        private static void Monster_TookDamage(IMonster monster, ulong dmg)
        {
            Console.WriteLine($"{monster.Name} took {dmg} damage! | Health: {monster.Health}");
        }
    }
}
