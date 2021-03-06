using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour
{
    public AudioSource Step1;
    public AudioSource Step2;
    private float pitch;

    [HideInInspector]
    public AudioSource[] Steps;
    [HideInInspector]
    public int ChosenStep;

    public void FirstStep()
    {
        pitch = Random.Range(0.8f, 1.2f);
        Step1.pitch = pitch;
        Step1.Play();
    }
    public void SecondStep()
    {
        pitch = Random.Range(0.8f, 1.2f);
        Step2.pitch = pitch;
        Step2.Play();
    }

    public void NewStep()
    {
        pitch = Random.Range(0.8f, 1.2f);
        Steps[ChosenStep].pitch = pitch;
        Steps[ChosenStep].Play();
    }


}