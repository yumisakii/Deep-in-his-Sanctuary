using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoggyPerseus
{
    class Weapon
    {
        public string Name { get; set; } = "defaultWeapon";
        public float Damage { get; set; } = 10f;

        public Skill skill { get; set; } = new Skill();


        public static void InitAllWeapons()
        {
            Run.AllWeapons.Clear();

            Run.AllWeapons.Add(new Weapon { Name = "Fire Katana"});
            Run.AllWeapons.Add(new Weapon { Name = "Poisoned dagger"});
            Run.AllWeapons.Add(new Weapon { Name = "Rocky Axe"});
        }
    }

    class Skill
    {
        public string Name { get; set; } = "defaultSkill";
        public float Damage { get; set; } = 10f;
        public bool IsAOE { get; set; } = true;
    }
}
