using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    private GameObject Nozzle;
    private BoxCollider BC;
    public bool Failure, inUse, doOnce, audioBool;
    public float Timer, TotalTime = 5, emptyTimer;
    public AudioClip Empty, Fluids;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Nozzle = gameObject.transform.GetChild(0).gameObject;
        Nozzle.SetActive(false);
        BC = gameObject.GetComponent<BoxCollider>();
        BC.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(doOnce == false && gameObject.activeSelf)
        {
            emptyTimer = 0;
            TotalTime = 5;
            doOnce = true;
        }
        if (TotalTime < 0)
        {
            gameObject.GetComponentInParent<PickupItem>().FailedExtinguisher = true;
            BC.enabled = false;
            Nozzle.SetActive(false);
           // audioSource.Play();
        }
        if(gameObject.GetComponentInParent<PickupItem>().FailedExtinguisher == true)
        {
            Failure = true;
        }
        if(gameObject.GetComponentInParent<PickupItem>().FailedExtinguisher == false)
        {
            Failure = false;
        }
        if (Input.GetKey(KeyCode.Mouse0) && Failure == false && TotalTime >0)
        {
            inUse = true;
            Nozzle.SetActive(true);
            BC.enabled = true;
            audioSource.clip = Fluids;
            TotalTime -= Time.deltaTime;
            if(audioBool == false)
            {
                audioSource.Play();
                audioBool = true;
            }
            
            
        }
   
        if (Input.GetKeyUp(KeyCode.Mouse0) && Failure == false)
        {
            inUse = false;
            Nozzle.SetActive(false);
            BC.enabled = false;
            audioBool = false;
            audioSource.Pause();
        }
        if(TotalTime<0 || Failure == true)
        {
            emptyTimer += Time.deltaTime;
            if(emptyTimer > 1)
            {
                audioSource.PlayOneShot(Empty, 0.5f);
                emptyTimer = 0;
            }
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
        if(other.tag == "Fire" )
        {
            Timer += Time.deltaTime;
            if(Timer >= 1)
            {
                other.gameObject.SetActive(false);
                Timer = 0;
            }
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Timer = 0;
    }
}
