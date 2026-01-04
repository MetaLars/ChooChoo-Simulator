using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SteeringLeverScript : MonoBehaviour
{

    public TrenScript trenScript;
    private XRGrabInteractable interactable;
    private Vector3 startPose;
    private bool stay = true;
    void Start()
    {
        interactable=GetComponent<XRGrabInteractable>();
        startPose = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Slider 1"))
        {
            trenScript.CheckForSwitch(1);
            print("lever calisti 1");
        }
        if (other.CompareTag("Slider -1"))
        {
            trenScript.CheckForSwitch(-1);
            print("lever calisti -1");
        }
    }
}
