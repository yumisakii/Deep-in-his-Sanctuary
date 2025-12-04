using UnityEngine;
using System.Collections.Generic;

public static class ElementColorMap
{
    private static readonly Dictionary<ElementType, Color> colorMap = new Dictionary<ElementType, Color>
    {
        // --- FULL ELEMENTS ---
        { ElementType.Fire,         new Color(1f, 0.2f, 0f) },      // Red/Orange
        { ElementType.Poison,       new Color(0.2f, 1f, 0f) },      // Toxic Green
        { ElementType.Ice,          new Color(0.3f, 0.8f, 1f) },    // Light Blue
        { ElementType.Bleed,        new Color(0.7f, 0f, 0f) },      // Dark Red
        { ElementType.Lightning,    new Color(1f, 1f, 0.2f) },      // Yellow
        { ElementType.Vampirism,    new Color(0.8f, 0f, 0.8f) },    // Magenta/Purple
        { ElementType.Void,         new Color(0.2f, 0f, 0.4f) },    // Dark Purple
        { ElementType.Corrode,      new Color(0.5f, 0.5f, 0.1f) },  // Murky Brown/Green
        { ElementType.Cull,         new Color(0.9f, 0.9f, 0.9f) },  // White/Silver

        // --- SUB-ELEMENTS (Grayer / Desaturated versions) ---
        { ElementType.Ember,        new Color(0.6f, 0.35f, 0.25f) }, // Dull Rust (Fire)
        { ElementType.Toxin,        new Color(0.35f, 0.6f, 0.35f) }, // Pale Green (Poison)
        { ElementType.Frost,        new Color(0.4f, 0.65f, 0.75f) }, // Grey-Blue (Ice)
        { ElementType.Nick,         new Color(0.5f, 0.25f, 0.25f) }, // Dried Blood (Bleed)
        { ElementType.Spark,        new Color(0.7f, 0.7f, 0.35f) },  // Old Brass (Lightning)
        { ElementType.Thirst,       new Color(0.5f, 0.25f, 0.5f) },  // Faded Purple (Vampirism)
        { ElementType.Shadow,       new Color(0.3f, 0.25f, 0.4f) },  // Charcoal Purple (Void)
        { ElementType.Gnaw,         new Color(0.5f, 0.5f, 0.3f) },   // Dust (Corrode)
        { ElementType.SnipSnip,     new Color(0.6f, 0.6f, 0.6f) }    // Plain Gray (Cull)
    };

    public static Color GetColor(ElementType type)
    {
        if (colorMap.ContainsKey(type))
        {
            return colorMap[type];
        }

        return new Color(0.2f, 0.2f, 0.2f, 1f);
    }
}