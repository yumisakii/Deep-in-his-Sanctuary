using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public static class AllMonsters
{
    [SerializeField] private static List<Monster> allMonsters = new List<Monster>();

    public static void InitAllMonsters(List<MonsterData> dataList, int loopNumber)
    {
        allMonsters.Clear();
        foreach (MonsterData data in dataList)
        {
            allMonsters.Add(MonsterBuilder.BuildMonster(data, loopNumber));
        }
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
