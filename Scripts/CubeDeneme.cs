using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class CubeDeneme : MonoBehaviour
{
    bool acýk = false;
    void Update()
    {
        tusOku();
        hýzlandýr();
    }
    private void hýzlandýr()
    {
        if (acýk==true)
        {
            Debug.Log("Hýzlaniyorum: " + 0.1);
        }
    }
    private void tusOku()
    {
        if (Input.GetKey(KeyCode.K))
        {
            acýk = true;
        }
        else
        {
            acýk = false;
        }

    }
}
