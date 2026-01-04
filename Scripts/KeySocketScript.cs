using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySocketScript : MonoBehaviour
{
    public TrenScript trenScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Key") && trenScript.keyIn==false)
        {
            trenScript.keyIn = true;
            trenScript.IsKeyIn();
            Debug.Log("icerdeyim");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            trenScript.keyIn = false;
            Debug.Log("ciktim");
        }
    }
}
