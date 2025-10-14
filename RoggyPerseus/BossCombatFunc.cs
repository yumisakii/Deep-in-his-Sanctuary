using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoggyPerseus
{
    internal class BossCombatFunc
    {
        public static void Attack(Boss boss, Weapon weapon)
        {
            boss.Hp -= weapon.Damage;
            Console.WriteLine($"You attacked {boss.Name} for 10 damage.\n");
        }

        public static void UseSkill(Boss boss, Skill skill)
        {
            boss.Hp -= skill.Damage;
            Console.WriteLine($"{boss.Name} took 10 damage.\n");
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
