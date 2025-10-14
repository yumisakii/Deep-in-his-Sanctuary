using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RoggyPerseus
{
    internal class ForgeRoom
    {
        public static void forgeRoom()
        {
            Dialogue(1);
            WeaponChoices();
        }

        private static void Dialogue(int step, Weapon? forgedWeapon = null)
        {
            if (step == 1)
            {
                Console.WriteLine("Bienvenue dans la forge...\n" +
                                  "Veuillez choisir 2 armes à fusionner\n");
            }

            else if (step == 2 && forgedWeapon != null)
            {
                Console.WriteLine("Très bien je te fusionne ces deux armes");

                Console.Write("Pouc");
                for (int i = 0; i < 3; i++)
                {
                    Thread.Sleep(1000);
                    Console.Write(".");
                }
                Console.WriteLine();

                Console.WriteLine("Voici ta nouvelle arme\n");

                Console.WriteLine($"Vous avez forgé l'arme {forgedWeapon.Name}");
            }  
        }

        private static void WeaponChoices()
        {
            for (int i = 0; i < Run.weapons.Count; i++)
            {
                Console.WriteLine($"{i + 1} - " + Run.weapons[i].Name);
            }

            Console.WriteLine();

            int choice1 = Run.MakeChoice(Run.weapons.Count);
            Weapon chosenWeapon1 = Run.weapons[choice1 - 1];
            Console.Write($"You choose the weapon '{chosenWeapon1.Name}' and ");

            int choice2 = Run.MakeChoice(Run.weapons.Count);
            Weapon chosenWeapon2 = Run.weapons[choice2 - 1];
            Console.WriteLine($"'{chosenWeapon2.Name}'.\n");

            FusedWeapon fusedWeapon = FuseWeapons(chosenWeapon1, chosenWeapon2);
            Console.WriteLine($"You got a new Fused Weapon : '{fusedWeapon.Name}' !");

            Run.weapons.Add(fusedWeapon);
            Run.weapons.Remove(chosenWeapon1);
            Run.weapons.Remove(chosenWeapon2);
            Weapon.SelectCurrentWeapon();
        }

        private static FusedWeapon FuseWeapons(Weapon w1, Weapon w2)
        {
            FusedWeapon fusedWeapon = new FusedWeapon {
                Name = $"{w1.Name}-{w2.Name}",
                Damage = (w1.Damage + w2.Damage)*0.75f,
                skill = new FusedSkill {
                    Damage = (w1.skill.Damage + w1.skill.Damage)*0.75f,
                    IsAOE = w1.skill.IsAOE || w2.skill.IsAOE,
                }
            };

            return fusedWeapon;
        }
    }
}
