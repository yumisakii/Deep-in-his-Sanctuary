//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;

//class ForgeRoom
//{
//    public static void forgeRoom()
//    {
//        WeaponChoices();
//    }

//    private static void ForgingDialogue()
//    {
//        Console.WriteLine("Very good, I'll fuse them now !");

//        Console.Write("Pouc");
//        for (int i = 0; i < 3; i++)
//        {
//            Thread.Sleep(1000);
//            Console.Write(".");
//        }
//        Thread.Sleep(1000);
//        Console.WriteLine();

//        Console.WriteLine("Here you go !!\n");
//    }

//    private static void WeaponChoices()
//    {
//        Console.WriteLine("Welcome in the forge...\n" +
//                "Please, choose 2 weapons to fuse :\n");
//        for (int i = 0; i < Run.weapons.Count; i++)
//        {
//            Console.WriteLine($"{i + 1} - " + Run.weapons[i].Name);
//        }

//        Console.WriteLine();

//        int choice1 = UF.MakeChoice(Run.weapons.Count);
//        Weapon chosenWeapon1 = Run.weapons[choice1 - 1];
//        Console.Write($"You choose the currentWeapon '{chosenWeapon1.Name}' and ");

//        int choice2 = UF.MakeChoice(Run.weapons.Count);
//        Weapon chosenWeapon2 = Run.weapons[choice2 - 1];
//        Console.WriteLine($"'{chosenWeapon2.Name}'.\n");


//        FusedWeapon fusedWeapon = FuseWeapons(chosenWeapon1, chosenWeapon2);

//        ForgingDialogue();
//        Console.WriteLine($"You got a new Fused Weapon : '{fusedWeapon.Name}' !");

//        Run.weapons.Add(fusedWeapon);
//        Run.weapons.Remove(chosenWeapon1);
//        Run.weapons.Remove(chosenWeapon2);
//        Weapon.SelectCurrentWeapon();
//    }

//    private static FusedWeapon FuseWeapons(Weapon w1, Weapon w2)
//    {
//        FusedWeapon fusedWeapon = new FusedWeapon {
//            Name = $"{w1.Name}-{w2.Name}",
//            Damage = (w1.Damage + w2.Damage)*0.75f,
//            skill = new FusedSkill {
//                Damage = (w1.skill.Damage + w1.skill.Damage)*0.75f,
//                IsAOE = w1.skill.IsAOE || w2.skill.IsAOE,
//            }
//        };
//        return fusedWeapon;
//    }
//}
