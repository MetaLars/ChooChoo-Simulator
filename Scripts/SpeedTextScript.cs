using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedTextScript : MonoBehaviour
{
    public TrenScript trenScript;
    private TMP_Text speedText;
    void Start()
    {
        speedText=GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = Mathf.Round(trenScript.speed).ToString();
    }
}
