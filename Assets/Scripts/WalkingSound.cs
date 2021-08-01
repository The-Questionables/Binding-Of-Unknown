using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour
{
    public AudioSource Step1;
    public AudioSource Step2;

    public void FirstStep()
    {
        Step1.Play();
    }
    public void SecondStep()
    {
        Step2.Play();
    }

}
