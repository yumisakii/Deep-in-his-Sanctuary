using UnityEngine;
using System.Collections.Generic;

public static class ElementColorMap
{
    private static readonly Dictionary<ElementType, Color> colorMap = new Dictionary<ElementType, Color>
    {
        { ElementType.Fire,     new Color(1f, 0.2f, 0f) },   // Red/Orange
        { ElementType.Poison,   new Color(0.2f, 1f, 0f) },   // Toxic Green
        { ElementType.Ice,      new Color(0.3f, 0.8f, 1f) },   // Light Blue
        { ElementType.Bleed,    new Color(0.7f, 0f, 0f) },     // Dark Red
        { ElementType.Lightning,new Color(1f, 1f, 0.2f) },  // Yellow
        { ElementType.Vampirism,new Color(0.8f, 0f, 0.8f) },  // Magenta/Purple
        { ElementType.Void,     new Color(0.2f, 0f, 0.4f) },   // Dark Purple
        { ElementType.Corrode,  new Color(0.5f, 0.5f, 0.1f) },  // Murky Brown/Green
        { ElementType.Cull,     new Color(0.9f, 0.9f, 0.9f) }    // White/Silver
    };

    public static Color GetColor(ElementType type)
    {
        if (colorMap.ContainsKey(type))
        {
            return colorMap[type];
        }
        return Color.black;
    }
}