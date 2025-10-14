using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoggyPerseus.RunFolder
{
    internal class CombatRoom
    {
        public static void combatRoom()
        {
            fight();
            loot();
            Weapon.SelectCurrentWeapon();
        }

        private static void fight()
        {
            Run.monsters.Clear();
            Run.monsters.Add(CombatFunc.GetRandomMonster());
            Run.monsters.Add(CombatFunc.GetRandomMonster());
            Run.monsters.Add(CombatFunc.GetRandomMonster());

            while (Run.monsters.Count > 0)
            {
                Console.WriteLine($"You're facing {Run.monsters.Count} monsters.\n" +
                                   "1 - Attack\n" +
                                   "2 - Use Skill\n");

                int choice = Run.MakeChoice(2);

                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Choose who to attack :");
                        for (int i = 0; i < Run.monsters.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {Run.monsters[i].Name}");
                        }

                        int attackTarget = Run.MakeChoice(Run.monsters.Count);

                        CombatFunc.Attack(Run.monsters[attackTarget - 1], Run.currentWeapon);
                        break;

                    case 2:
                        Console.WriteLine($"Choose who to use skill on :");
                        for (int i = 0; i < Run.monsters.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {Run.monsters[i].Name}");
                        }

                        int skillTarget = Run.MakeChoice(3);

                        CombatFunc.UseSkill(Run.monsters, skillTarget, Run.currentWeapon.skill);
                        break;
                }

                

                for (int i = Run.monsters.Count - 1; i >= 0; i--)
                {
                    if (Run.monsters[i].Hp <= 0)
                    {
                        Console.WriteLine($"You defeated {Run.monsters[i].Name}!");
                        Run.monsters.RemoveAt(i);
                    }
                }
            }
        }

        private static void loot()
        {
            Weapon weapon1 = CombatFunc.GetRandomWeapon();
            Weapon weapon2 = CombatFunc.GetRandomWeapon();
            Weapon weapon3 = CombatFunc.GetRandomWeapon();


            Console.WriteLine("You defeated all monsters !! Choose a weapon as a reward :\n" +
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
    }
}
