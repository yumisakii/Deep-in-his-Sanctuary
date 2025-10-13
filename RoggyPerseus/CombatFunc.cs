using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoggyPerseus
{
    internal class CombatFunc
    {
        public static void Attack(Monster monster)
        {
            monster.hp -= 10;
            Console.WriteLine($"You attacked the {monster.Name} for 10 damage.\n");
        }

        public static void UseSkill()
        {

        }

        public static void UseItem()
        {

        }
    }
}
