using UnityEngine;
using System.Collections.Generic;

public static class UsefulFunctions
{
    public static T GetRandomElementAndDelete<T>(List<T> list) where T : class
    {
        if (list == null || list.Count == 0)
        {
            Debug.LogError("The list is empty or null");
            return null;
        }

        int randomIndex = Random.Range(0, list.Count);
        T element = list[randomIndex];
        list.RemoveAt(randomIndex);

        return element;
    }
}