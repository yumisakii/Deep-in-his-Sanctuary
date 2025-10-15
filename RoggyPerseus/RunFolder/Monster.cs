using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoggyPerseus.RunFolder
{
    internal class Monster
    {
        public string Name { get; set; } = "baseMonster";
        public float Hp { get; set; } = 10f;
        public float Damage { get; set; } = 10f;
        



        public static void InitAllMonsters()
        {
            Run.AllMonsters.Clear();
            // repeat 3 times for double monsters
            for (int i = 0; i < 3; i++)
            {
                Run.AllMonsters.Add(new Monster { Name = "Wolf", Hp = 10 });
                Run.AllMonsters.Add(new Monster { Name = "Ork", Hp = 10 });
                Run.AllMonsters.Add(new Monster { Name = "lich", Hp = 10 });
            }

        }
    }
}
