using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoggyPerseus.RunFolder
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
        public static void SelectCurrentWeapon()
        {
            if (Run.weapons.Count <= 1)
            {
                Run.currentWeapon = Run.weapons[0];
                Console.WriteLine($"The '{Run.currentWeapon.Name}' has been equiped.\n");
            }
            else
            {
                Console.WriteLine("Select the weapon you want to use :\n");
                for (int i = 0; i < Run.weapons.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {Run.weapons[i].Name}");
                }

                int weaponChoosed = Run.MakeChoice(Run.weapons.Count);

                Run.currentWeapon = Run.weapons[weaponChoosed - 1];
                Console.WriteLine($"The '{Run.currentWeapon.Name}' has been equiped.\n");
            }
        }
    }

    class Skill
    {
        public string Name { get; set; } = "defaultSkill";
        public float Damage { get; set; } = 10f;
        public bool IsAOE { get; set; } = true;
    }

    class FusedWeapon : Weapon
    {
        
    }

    class FusedSkill : Skill
    {

    }
}
