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
        public float Damage { get; set; } = 0f;

        public Skill skill { get; set; } = new Skill();
    }

    class Skill
    {
        public string Name { get; set; } = "defaultSkill";
        public float Damage { get; set; } = 0f;
        public bool IsAOE { get; set; } = false;
    }
}
