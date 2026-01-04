using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureMeterScript : MonoBehaviour
{
    public TrenScript trenScript;
    public GameObject pressurePivot;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HeatIncrease(trenScript.pressure);
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
            pressurePivot.transform.localRotation = Quaternion.Euler(0, yeniLokalRotasyon, 0);
        }
    }
}
