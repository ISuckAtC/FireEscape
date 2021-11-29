using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireReset : MonoBehaviour
{
    private GameObject Flames;
    public float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Flames = gameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Flames.activeSelf == false)
        {
            Timer += Time.deltaTime;
            if(Timer >= 5)
            {
                Flames.SetActive(true);
                Flames.GetComponent<ParticleSystem>().Stop();
                Flames.GetComponent<ParticleSystem>().Play();
                Flames.GetComponent<AudioSource>().Stop();
                Flames.GetComponent<AudioSource>().Play();
                Flames.GetComponent<Simpleburn>().deathTimer =0;
                Timer = 0;
            }
        }
    }
}
