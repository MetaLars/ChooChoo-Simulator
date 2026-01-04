using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Autohand.Demo{
public class SliderTextChanger : MonoBehaviour
    {
        public TMP_Text text;
        public LeverGrabInfo lever;
    void Update(){
        text.text = lever.LeverValue().ToString();
    }
}
}
