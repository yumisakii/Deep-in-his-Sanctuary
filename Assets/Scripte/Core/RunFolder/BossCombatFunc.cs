//using System;
//using System.Collections.Generic;
//using System.Linq;

//class BossCombatFunc
//{
//    public static void Attack(Boss boss, Weapon weapon)
//    {
//        boss.Hp -= weapon.Damage;
//        Console.WriteLine($"You attacked {boss.Name} for {Run.currentWeapon.Damage} damage.\n");
//    }

//    public static void UseSkill(Boss boss, Skill skill)
//    {
//        boss.Hp -= skill.Damage;
//        Console.WriteLine($"{boss.Name} took {Run.currentWeapon.skill.Damage} damage.\n");
//    }

//    public static Weapon GetRandomWeapon()
//    {
//        Random random = new Random();
//        int index = random.Next(Run.AllWeapons.Count);

//        Weapon weaponToReturn = Run.AllWeapons[index];
//        Run.AllWeapons.Remove(Run.AllWeapons[index]);

//        return weaponToReturn;
//    }
//}