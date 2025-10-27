using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public static class AllMonsters
{
    private static List<Monster> allMonsters = new List<Monster>();

    public static void InitAllMonsters()
    {
        allMonsters.Clear();
        allMonsters.Add(new Monster("King Skeleton", "Monster_01", DangerLevel.Grey));
        allMonsters.Add(new Monster("Red Queen", "Monster_03", DangerLevel.Grey));
        allMonsters.Add(new Monster("Dark Lord", "Monster_02", DangerLevel.Grey));
        allMonsters.Add(new Monster("Super Dark Lord", "Monster_02", DangerLevel.Grey));
    }

    public static void InitAllMonstersList(List<Monster> monsters) // pk j'ai fait cette fonction ??
    {
        foreach (Monster monster in monsters)
            allMonsters.Add(monster);
    }

    public static List<Monster> GetAllMonsters()
    {
        return allMonsters;
    }
    public static List<Monster> GetCopieAllMonsters()
    {
        List<Monster> newMonsters = allMonsters;
        return newMonsters;
    }
}
