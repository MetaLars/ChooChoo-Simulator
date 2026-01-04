using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class SpeedoMeterScript : MonoBehaviour
{
    public TrenScript trenScript;
    public GameObject speedometerPivot;

    private float startRotationZ;

    void Start()
    {
        startRotationZ = speedometerPivot.transform.localRotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        HizArttir(trenScript.speed);
        //speedometerPivot.transform.localRotation = new Vector3(speedometerPivot.transform.localRotation.x, startRotationY + 1, speedometerPivot.transform.localRotation.z);
    }
    void HizArttir(float hiz)
    {
        // Hýz artýþýný kontrol et
        if (hiz > 0f)
        {
            // Hýz artýþýna göre Z lokal rotasyonunu güncelle
            float artis = (hiz / 20f) * 24f;
            float yeniLokalRotasyon = startRotationZ + artis;

            // Z lokal rotasyonunu güncelle
            speedometerPivot.transform.localRotation = Quaternion.Euler(-18.878f, -1.134f, yeniLokalRotasyon-30);
        }
    }
}
