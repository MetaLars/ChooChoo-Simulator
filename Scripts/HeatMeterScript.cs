using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatMeterScript : MonoBehaviour
{
    public TrenScript trenScript;
    public GameObject heatPivot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HeatIncrease(trenScript.temperature);
    }
    void HeatIncrease(float heat)
    {
        // Hýz artýþýný kontrol et
        if (heat > 0f)
        {
            // Hýz artýþýna göre Z lokal rotasyonunu güncelle
            float artis = (heat / 20f) * 30f;
            float yeniLokalRotasyon = artis;

            // Z lokal rotasyonunu güncelle
            heatPivot.transform.localRotation = Quaternion.Euler(0, yeniLokalRotasyon,0);
        }
    }
}
