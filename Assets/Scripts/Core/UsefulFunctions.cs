using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

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

    public static void ScaleImage(Image image, float scaleFactor)
    {
        Vector3 targetScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        image.transform.localScale = targetScale;        
    }

    public static void ResetImageScale(Image image)
    {
        image.transform.localScale = Vector3.one;
    }
}