using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoggyPerseus.RunFolder
{
    internal class BossRoom
    {
        public static async Task bossRoom()
        {
            await fight();
            loot();
        }

        private static async Task fight()
        {
            Run.boss = Run.AllBosses[0];

            Console.WriteLine($"{Run.boss.Name} : {Run.boss.Description}\n");

            while (Run.boss.Hp > 0)
            {
                Console.WriteLine($"You're facing {Run.boss.Name}.\n" +
                                   "1 - Attack\n" +
                                   "2 - Use Skill\n");

                int choice = UF.MakeChoice(2);

                switch (choice)
                {
                    case 1:
                        BossCombatFunc.Attack(Run.boss, Run.currentWeapon);
                        break;

                    case 2:
                        BossCombatFunc.UseSkill(Run.boss, Run.currentWeapon.skill);
                        break;
                }

                if (Run.boss.Hp <= 0)
                {
                    Console.WriteLine($"You defeated {Run.boss.Name} ! Well done !");

                    Run.playerStats.Score += 1;

                    Console.WriteLine($"Your score : {Run.playerStats.Score}\n");
                }
                else
                {
                    Run.playerStats.Hp -= Run.boss.Damage;
                    Console.WriteLine($"{Run.boss.Name} attack you for {Run.boss.Damage} damage !\n");
                    Console.WriteLine($"You have {Run.playerStats.Hp} hp left.\n");
                }

                if (Run.playerStats.Hp <= 0)
                {
                    await Run.YouDied();
                }
            }
        }

        private static void loot()
        {
            Weapon weapon1 = CombatFunc.GetRandomWeapon();
            Weapon weapon2 = CombatFunc.GetRandomWeapon();
            Weapon weapon3 = CombatFunc.GetRandomWeapon();

            Console.WriteLine("You defeated the boss !! Choose a weapon as a reward :\n" +
                              $"1 - {weapon1.Name}\n" +
                              $"2 - {weapon2.Name}\n" +
                              $"3 - {weapon3.Name}\n");

            int weaponChoosed = UF.MakeChoice(3);

            switch (weaponChoosed)
            {
                case 1:
                    Run.weapons.Add(weapon1);
                    Weapon.InitAllWeapons();
                    break;

                case 2:
                    Run.weapons.Add(weapon2);
                    Weapon.InitAllWeapons();
                    break;

                case 3:
                    Run.weapons.Add(weapon3);
                    Weapon.InitAllWeapons();
                    break;
            }
        }
    }
}
