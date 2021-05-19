using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelictChargeBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient; //Farbverlauf für die RelictCharge
    public Image fill;

    public void SetMaxRelictCharge(int relictCharge) //Sliderlänge passt sich den maximalen RelictCharge an
    {
        slider.maxValue = relictCharge;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetRelictCharge(int relictCharge) //Slider bewegt sich zum aktuellen RelictCharge
    {
        slider.value = relictCharge;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
