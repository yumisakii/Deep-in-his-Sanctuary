using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoggyPerseus
{
    internal class CombatFunc
    {
        private static List<Monster> AllMonsters = new List<Monster>();
        public static void Attack(Monster monster)
        {
            monster.hp -= 10;
            Console.WriteLine($"You attacked the {monster.Name} for 10 damage.\n");
        }

        public static void UseSkill(List<Monster> monsters, int skillTarget)
        {
            Monster monster = monsters[skillTarget];

            
        }

        public static void UseItem()
        {

        }

        public static void InitAllMonsters()
        {
            AllMonsters.Clear();
            AllMonsters.Add(new Monster { Name = "Wolf", hp = 10 });
            AllMonsters.Add(new Monster { Name = "Ork", hp = 10 });
            AllMonsters.Add(new Monster { Name = "lich", hp = 10 });
        }

        public static Monster GetRandomMonster()
        {
            Random random = new Random();
            int index = random.Next(AllMonsters.Count);

            return AllMonsters[index];
        }
    }
}
