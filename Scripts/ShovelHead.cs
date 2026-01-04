using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelHead : MonoBehaviour
{
    private GameObject coalOnShovel;
    public TrenScript trenScript;
    private AudioSource audioSource;
    public AudioClip coalTakeSound;
    public AudioClip coalPutSound;
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
        coalOnShovel =transform.GetChild(0).gameObject;
        coalOnShovel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CoalReserve") && coalOnShovel.activeInHierarchy == false)
        {
            coalOnShovel.SetActive(true);
            audioSource.PlayOneShot(coalTakeSound);
        }
        if (other.CompareTag("TrainFurnace") && coalOnShovel.activeInHierarchy == true)
        {
            coalOnShovel.SetActive(false);
            trenScript.AddCoal();
            audioSource.PlayOneShot(coalPutSound);
            //Debug.Log("kömürattým");
        }
    }
}
