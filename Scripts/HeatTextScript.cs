using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeatTextScript : MonoBehaviour
{
    public TrenScript trenScript;
    private TMP_Text heatText;
    void Start()
    {
        heatText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        heatText.text = Mathf.Round(trenScript.temperature).ToString();
    }
}
