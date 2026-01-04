using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PressureTextScript : MonoBehaviour
{
    public TrenScript trenScript;
    private TMP_Text pressureText;
    void Start()
    {
        pressureText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        pressureText.text = Mathf.Round(trenScript.pressure).ToString();
    }
}
