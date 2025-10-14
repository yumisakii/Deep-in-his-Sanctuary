using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoggyPerseus
{
    internal class BossRoom
    {
        public static void bossRoom()
        {
            fight();
            loot();
            selectCurrentWeapon();
        }

        private static void fight()
        {
            Run.boss = Run.AllBosses[0];

            Console.WriteLine($"{Run.boss.Name} : {Run.boss.Description}\n");

            while (Run.boss.Hp > 0)
            {
                Console.WriteLine($"You're facing {Run.boss.Name}.\n" +
                                   "1 - Attack\n" +
                                   "2 - Use Skill\n");

                int choice = Run.MakeChoice(2);

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

            int weaponChoosed = Run.MakeChoice(3);

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

        private static void selectCurrentWeapon()
        {
            if (Run.weapons.Count <= 1)
            {
                Run.currentWeapon = Run.weapons[0];
                Console.WriteLine($"The '{Run.currentWeapon.Name}' has been equiped.\n");
            }
            else
            {
                Console.WriteLine("Select the weapon you want to use :\n");
                for (int i = 0; i < Run.weapons.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {Run.weapons[i].Name}");
                }

                int weaponChoosed = Run.MakeChoice(Run.weapons.Count);

                Run.currentWeapon = Run.weapons[weaponChoosed - 1];
                Console.WriteLine($"The '{Run.currentWeapon.Name}' has been equiped.\n");
            }
        }
    }
}
