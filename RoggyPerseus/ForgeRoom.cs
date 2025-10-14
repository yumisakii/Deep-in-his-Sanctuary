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
            InitAllFusions();

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
                Console.WriteLine($"{i + 1}. " + Run.weapons[i].Name);
            }

            Console.WriteLine();

            int choice1 = Run.MakeChoice(Run.weapons.Count);
            Weapon chosenWeapon1 = Run.weapons[choice1 - 1];
            Console.Write($"Tu as choisi l'arme {chosenWeapon1.Name} et ");

            int choice2 = Run.MakeChoice(Run.weapons.Count);
            Weapon chosenWeapon2 = Run.weapons[choice2 - 1];
            Console.WriteLine($"{chosenWeapon2.Name}\n");

            Weapon? forgedWeapon = GetFusion(chosenWeapon1, chosenWeapon2);

            if (forgedWeapon != null)
                Dialogue(2, forgedWeapon);
            else
                Console.WriteLine("Erreur: Fusion non trouvée");
        }

        private static Dictionary<string, Weapon> fusions = new Dictionary<string, Weapon>();

        private static void InitAllFusions()
        {
            fusions.Clear();

            // Liste des armes de base
            var baseWeapons = Run.weapons.Where(w => w.Name == "Sword" || w.Name == "MasterSword" || w.Name == "GutsSword").ToList();

            // Fonction pour ajouter une fusion et sa version inverse
            static void AddFusion(Weapon w1, Weapon w2, string fusionName)
            {
                var fused = new Weapon { Name = fusionName, Damage = w1.Damage + w2.Damage };
                fusions[$"{w1.Name}|{w2.Name}"] = fused;
                fusions[$"{w2.Name}|{w1.Name}"] = fused; // clé inverse
            }

            // Toutes les combinaisons différentes
            AddFusion(baseWeapons[0], baseWeapons[1], "Mega MasterSword");
            AddFusion(baseWeapons[0], baseWeapons[2], "Mega GutsSword");
            AddFusion(baseWeapons[1], baseWeapons[2], "Guts MasterSword");

            // Fusions avec elles-mêmes
            foreach (var w in baseWeapons)
            {
                fusions[$"{w.Name}|{w.Name}"] = new Weapon
                {
                    Name = w.Name switch
                    {
                        "Sword" => "Big Sword",
                        "MasterSword" => "Mega MasterSword",
                        "GutsSword" => "Giga GutsSword",
                        _ => $"{w.Name}-{w.Name} Fusion"
                    },
                    Damage = w.Damage * 2
                };
            }
        }

        private static Weapon? GetFusion(Weapon w1, Weapon w2)
        {
            string key1 = $"{w1.Name}|{w2.Name}";
            string key2 = $"{w2.Name}|{w1.Name}"; // pour gérer l'ordre inverse

            if (fusions.ContainsKey(key1)) return fusions[key1];
            if (fusions.ContainsKey(key2)) return fusions[key2];

            return null;
        }
    }
}
