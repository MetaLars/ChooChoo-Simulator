using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverGrabInfo : MonoBehaviour
{
    public float sliderValue = 0;
    public TrenScript trenScript;

    public float LeverValue()
    {
        return sliderValue;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Slider 1"))
        {
            sliderValue = 1f;
            trenScript.speedUp = true;
        }
        if (other.CompareTag("Slider -1"))
        {
            sliderValue = -1f;
            trenScript.slowDown = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Slider 1") || other.CompareTag("Slider -1"))
        {
            sliderValue = 0;
            trenScript.speedUp = false;
            trenScript.slowDown = false;
        }
    }
}
