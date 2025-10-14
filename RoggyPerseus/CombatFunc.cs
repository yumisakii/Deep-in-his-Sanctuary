using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoggyPerseus
{
    internal class CombatFunc
    {
        public static void Attack(Monster monster, Weapon weapon)
        {
            monster.hp -= weapon.Damage;
            Console.WriteLine($"You attacked the {monster.Name} for 10 damage.\n");
        }

        public static void UseSkill(List<Monster> monsters, int skillTarget, Skill skill)
        {
            Monster monster = monsters[skillTarget];

            if (skill.IsAOE == true)
            {
                foreach (Monster m in monsters)
                {
                    m.hp -= skill.Damage;
                }
            }
            else
            {
                monster.hp -= skill.Damage;
            }
        }

        public static Monster GetRandomMonster()
        {
            Random random = new Random();
            int index = random.Next(Run.AllMonsters.Count);

            Monster monsterToReturn = Run.AllMonsters[index];
            Run.AllMonsters.Remove(Run.AllMonsters[index]);

            return monsterToReturn;
        }

        public static Weapon GetRandomWeapon()
        {
            Random random = new Random();
            int index = random.Next(Run.AllWeapons.Count);

            Weapon weaponToReturn = Run.AllWeapons[index];
            Run.AllWeapons.Remove(Run.AllWeapons[index]);

            return weaponToReturn;
        }
    }
}
