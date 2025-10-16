using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoggyPerseus.RunFolder
{
    internal class Boss
    {
        public string Name { get; set; } = "baseBoss";
        public float Hp { get; set; } = 30f;
        public float Damage { get; set; } = 20f;
        public string Description { get; set; } = default!;


        public static void InitAllBosses()
        {
            Run.AllBosses.Clear();

            Run.AllBosses.Add(new Boss { Name = "Bloodshade", Hp = 10, Damage = 20, Description = "A lurking nightmare, born from shadow and blood, he drains the life " +
                                                                                      "and reflect attacks of those who want to face it." });
        }
    }
}
