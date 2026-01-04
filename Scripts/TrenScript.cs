using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TrenScript : MonoBehaviour
{

    public AudioClip tusSesClip;
    public AudioClip kornaSesClip;
    public AudioClip anahtarSesClip;
    public AudioClip trenSesClip;
    public AudioClip trenCrashClip;

    public AudioSource trenAudioSource;
    public AudioSource trainMotorAudioSource;
    public AudioSource honkAudioSource;




    public float temperature = 0f;
    public float pressure = 0f;
    public float speed = 0f;
    public float coal=0;

    public bool speedUp = false;
    public bool slowDown = false;
    public bool lightControl = false;
    public bool horn = false;
    public bool ignition = false;
    public bool keyIn = false;
    public bool hornControl = false;
    public bool warningLight = false;
    
    public GameObject headLight;
    public GameObject warningLightObject;
    public GameObject fireSprite;
    public float ligthRotationSpeed = 5f;


    public Transform ray1;
    public Transform ray2;
    public Transform ray3;

    private Transform currentRay;
    public float coalIncreaseAmount = 10;
    public float rayGecisHizi = 10;
    private bool coroutineDevamEdiyor=false;

    void Start()
    {
        trenAudioSource = GetComponent<AudioSource>();

        if (trenAudioSource == null)
        {
            trenAudioSource = gameObject.AddComponent<AudioSource>();
        }
        currentRay = ray2;
    }

    void Update()
    {
        //ReadKey();
        SpeedUpTrain();
        SlowDownTrain();
        GetHeated();
        PressureBalance();
        RotateWarningLights();
        HonkHorn();
        TrenGidiyor();
    }

    public string CurrentRailGetter()
    {
        if (currentRay == ray1)
        {
            return "Rail-1";
        }
        else if (currentRay == ray2)
        {
            return "Rail-2";
        }
        else if (currentRay == ray3)
        {
            return "Rail-3";
        }
        else
            return "Null";
    }
    public void CheckForSwitch(int direction)
    {
        if (direction==1)
        {
            print("tren calisti 1");
            if (currentRay == ray1 && coroutineDevamEdiyor == false)
            {
                StartCoroutine(SwitchRail(ray2.position));
                currentRay = ray2;
            }

            else if (currentRay == ray2 && coroutineDevamEdiyor == false)
            {
                StartCoroutine(SwitchRail(ray3.position));
                currentRay = ray3;
            }
        }

        if (direction==-1)
        {
            print("tren calisti -1");
            if (currentRay == ray3 && coroutineDevamEdiyor==false)
            {
                StartCoroutine(SwitchRail(ray2.position));
                currentRay = ray2;
            }

            else if (currentRay == ray2 && coroutineDevamEdiyor == false)
            {
                StartCoroutine(SwitchRail(ray1.position));
                currentRay = ray1;
            }

        }

    }
    public IEnumerator SwitchRail(Vector3 hedefKonum)
    {
        coroutineDevamEdiyor = true;
        float zaman = 0f;
        Vector3 baslangicKonum = transform.position;

        while (zaman < 1f)
        {
            //print("tasımaya aclisiyor to:" + hedefKonum);
            zaman += Time.deltaTime * rayGecisHizi;
            transform.position = Vector3.Lerp(baslangicKonum, hedefKonum, zaman);
            yield return null;
        }
        coroutineDevamEdiyor = false;
    }

    public void TrenGidiyor()
    {
        if (speed > 0.1)
        {
            if (trainMotorAudioSource.clip!=trenSesClip)
            {
                trainMotorAudioSource.clip = trenSesClip;
                trainMotorAudioSource.Play();
            }
        }
        else
        {
            trainMotorAudioSource.Stop();
        }
    }

    public void IsKeyIn()
    {
        if (keyIn == true)
        {
            trenAudioSource.PlayOneShot(anahtarSesClip);
            fireSprite.SetActive(true);
        }
        if (keyIn == false)
        {
            fireSprite.SetActive(true);
        }
    }

    public void AddCoal()
    {
        coal += coalIncreaseAmount;
    }
    public void GetHeated()
    {
        if (keyIn==true)
        {
            if (coal > 0)
            {
                temperature += 0.05f;
                coal -= 0.05f;
            }
            if (coal < 0)
            {
                coal = 0;
            }
        }
        
    }
    public void PressureBalance()
    {
        if (keyIn==true)
        {
            if (temperature > pressure && temperature > 0)
            {
                temperature -= 0.0125f;
                pressure += 0.025f;
            }
            if (temperature < 0)
            {
                temperature = 0;
            }
        }
        
    }

    public void OpenIgnition()
    {
        if (ignition == false)
        {
            ignition = true;
        }
        else
        {
            if (ignition == true)
            {
                ignition = false;
            }
        }
    }

    public void OpenLight()
    {
        if (keyIn==true)
        {
            if (lightControl == false)
            {
                lightControl = true;
                headLight.SetActive(true);
                UnityEngine.Debug.Log("ısık actim");
            }
            else if (lightControl == true)
            {
                lightControl = false;
                headLight.SetActive(false);
                UnityEngine.Debug.Log("ısık kapadım");
            }
            trenAudioSource.PlayOneShot(tusSesClip);
        }
        
    }

    public void HonkHorn()
    {
        if (keyIn==true)
        {
            if (hornControl == true)
            {
                if (pressure > 0)
                {
                    pressure -= 0.1f;
                    if (honkAudioSource.clip != kornaSesClip)
                    {
                        honkAudioSource.clip = kornaSesClip;
                        honkAudioSource.Play();
                    }
                }
                else
                {
                    pressure = 0;
                }
            }
            else
            {
                honkAudioSource.clip = null;
                honkAudioSource.Stop();
            }
        }
        
    }
    public void HonkHornEnable()
    {
        hornControl = true;
    }
    public void HonkHornDisable()
    {
        hornControl = false;
    }

    private void SlowDownTrain()
    {
        if (keyIn==true)
        {
            if (slowDown == true)
            {
                if (speed > 0)
                {
                    speed -= 0.15f;
                }
                else { speed = 0; }

            }
        }
        
    }
    public void RotateWarningLights()
    {
        if (warningLight==true)
        {
            warningLightObject.transform.GetChild(0).gameObject.SetActive(true);
            warningLightObject.transform.Rotate(Vector3.up, ligthRotationSpeed * Time.deltaTime);
        }
        else
        {
            warningLightObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void SpeedUpTrain()
    {
        if (keyIn==true)
        {
            if (speedUp == true)
            {
                if (pressure > 0)
                {
                    pressure -= 0.1f;
                    speed += 0.1f;
                }

                if (pressure < 0)
                {
                    pressure = 0;
                }
            }
        }
        
    }
    private void ReadKey()
    {
        if (Input.GetKey(KeyCode.W))
        {
            speedUp = true;
        }
        else
        {
            speedUp = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            slowDown = true;
        }
        else
        {
            slowDown = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            speed = 0;
            pressure = 0;
            trenAudioSource.PlayOneShot(trenCrashClip);
        }
        if (other.CompareTag("ObstacleWarning"))
        {
            warningLight = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ObstacleWarning"))
        {
            warningLight = false;
        }
    }
}