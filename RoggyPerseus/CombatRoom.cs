using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoggyPerseus
{
    internal class CombatRoom
    {
        public static void combatRoom()
        {
            fight();
            loot();
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
                                   "2 - Use Skill\n" +
                                   "3 - Use Item\n");

                int choice = Run.MakeChoice(3);

                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Choose who to attack :");
                        for (int i = 0; i < Run.monsters.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {Run.monsters[i].Name}");
                        }

                        int attackTarget = Run.MakeChoice(3);

                        CombatFunc.Attack(Run.monsters[attackTarget - 1]);
                        break;

                    case 2:
                        Console.WriteLine($"Choose who to use skill on :");
                        for (int i = 0; i < Run.monsters.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {Run.monsters[i].Name}");
                        }

                        int skillTarget = Run.MakeChoice(3);

                        CombatFunc.UseSkill(Run.monsters, skillTarget);
                        break;

                    case 3:
                        CombatFunc.UseItem();
                        break;
                }

                for (int i = Run.monsters.Count - 1; i >= 0; i--)
                {
                    if (Run.monsters[i].hp <= 0)
                    {
                        Console.WriteLine($"You defeated {Run.monsters[i].Name}!");
                        Run.monsters.RemoveAt(i);
                    }
                }
            }
        }

        private static void loot()
        {

        }
    }
}
