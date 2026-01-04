using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadcontrol : MonoBehaviour
{
    public TrenScript trenScript;
    public GameObject[] tasObjects;
    private GameObject activeObject;
    public float activationProbability = 0.1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector3.back*trenScript.speed*Time.deltaTime)/2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Train"))
        {
            transform.position += new Vector3(0, 0, transform.GetChild(0).GetComponent<Renderer>().bounds.size.z * 2);
            ActivateRandomObject();
        }
        
    }
    void ActivateRandomObject()
    {
        if (activeObject!=null)
        {
            activeObject.SetActive(false);
        }
        if (Random.Range(0f, 1f) <= activationProbability)
        {
            // Bir game object'i rastgele seç ve aktif hale getir
            int randomIndex = Random.Range(0, tasObjects.Length);
            if (tasObjects.Length>0)
            {
                activeObject = tasObjects[randomIndex];
                tasObjects[randomIndex].SetActive(true);
            }
        }
    }
}
