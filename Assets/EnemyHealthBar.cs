using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient; //Farbverlauf für die Healthbar
    public Image fill;

    public void SetMaxHealth(int health) //Sliderlänge passt sich den maximalen Lebenswert an
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health) //Slider bewegt sich zum aktuellen Lebenswert
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
