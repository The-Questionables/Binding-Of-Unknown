using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient; //Farbverlauf für die Manabar
    public Image fill;

    public void SetMaxMana(int mana) //Sliderlänge passt sich den maximalen Manawert an
    {
        slider.maxValue = mana;
        slider.value = mana;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetMana(int mana) //Slider bewegt sich zum aktuellen Manawert
    {
        slider.value = mana;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
