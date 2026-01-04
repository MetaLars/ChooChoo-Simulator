using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentRailTextScript : MonoBehaviour
{
    public TrenScript trenScript;
    private TMP_Text railText;
    void Start()
    {
        railText=GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        railText.text = trenScript.CurrentRailGetter();
    }
}
