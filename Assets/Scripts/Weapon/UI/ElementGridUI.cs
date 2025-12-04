using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ElementGridUI : MonoBehaviour
{
    [SerializeField] private List<Image> ElementsIcons = new List<Image>();
    [SerializeField] private List<TextMeshProUGUI> ElementsText = new List<TextMeshProUGUI>();

    public void UpdateElementGrid(Weapon weapon)
    {
        if (weapon != null)
        {
            for (int i = 1; i <= 9; i++)
            {
                ElementType type = (ElementType)i;
                bool isActive = weapon.Elements.ContainsKey(type);
                int stackCount = isActive ? weapon.Elements[type] : 0;
                UpdateSpecificElement(type, isActive, stackCount);
            }

            for (int i = 10; i <= 18; i++)
            {
                ElementType type = (ElementType)i;
                bool isActive = weapon.Elements.ContainsKey(type);
                int stackCount = isActive ? weapon.Elements[type] : 0;
                if (isActive)
                {
                    UpdateSpecificElement(type, isActive, stackCount);
                }
            }
        }
        else
        {
            for (int i = 1; i <= 18; i++)
            {
                ElementType type = (ElementType)i;
                UpdateSpecificElement(type, false, 0);
            }
        }
    }


    private void UpdateSpecificElement(ElementType type, bool isActive, int stackCount)
    {
        Image imageSlot = GetImageForElement(type);
        TextMeshProUGUI stackText = imageSlot.GetComponentInChildren<TextMeshProUGUI>();
        if (isActive)
        {
            imageSlot.color = ElementColorMap.GetColor(type);
            stackText.text = IntToRoman(stackCount);
        }
        else
        {
            imageSlot.color = new Color(0.2f, 0.2f, 0.2f, 0.5f); // Dark gray
            stackText.text = "";
        }
    }

    private Image GetImageForElement(ElementType type)
    {
        for (int i = 1; i <= 18; i++)
        {
            if (i <= 9)
            {
                if ((ElementType)i == type)
                {
                    return ElementsIcons[i - 1];
                }
            }
            else if (i <= 18)
            {
                if ((ElementType)i == type)
                {
                    return ElementsIcons[i - 10];
                }
            }
        }


        for (int i = 0; i < ElementsIcons.Count; i++)
        {
            if ((ElementType)(i + 1) == type || (ElementType)(i + 10) == type) // +1 to skip 'None' and +10 for sub-elements
            {
                return ElementsIcons[i];
            }
        }

        return null;
    }

    public static string IntToRoman(int number)
    {
        if (number < 1 || number > 9)
        {
            Debug.LogError("Input number must be between 1 and 9.");
            return string.Empty;
        }

        string romanNumeral = number switch
        {
            1 => "I",
            2 => "II",
            3 => "III",
            4 => "IV",
            5 => "V",
            6 => "VI",
            7 => "VII",
            8 => "VIII",
            9 => "IX",
            _ => ""
        };

        return romanNumeral;
    }
}