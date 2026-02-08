//using System;
//using System.Collections.Generic;
//using System.Linq;

//class CombatFunc
//{
//    public static void Attack(Monster monster, Weapon currentWeapon)
//    {
//        monster.Hp -= currentWeapon.Damage;
//        Console.WriteLine($"You attacked the {monster.Name} for {Run.currentWeapon.Damage} damage.\n");
//    }

//    public static void UseSkill(List<Monster> monsters, int skillTarget, Skill skill)
//    {
//        Monster monster = monsters[skillTarget];

//        if (skill.IsAOE == true)
//        {
//            foreach (Monster m in monsters)
//            {
//                m.Hp -= skill.Damage;
//                Console.WriteLine($"You attacked the {monster.Name} for {Run.currentWeapon.skill.Damage} damage.\n");
//            }
//        }
//        else
//        {
//            monster.Hp -= skill.Damage;
//        }
//    }

//    public static Monster GetRandomMonster()
//    {
//        Random random = new Random();
//        int index = random.Next(Run.AllMonsters.Count);

//        Monster monsterToReturn = Run.AllMonsters[index];
//        Run.AllMonsters.Remove(Run.AllMonsters[index]);

//        return monsterToReturn;
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
