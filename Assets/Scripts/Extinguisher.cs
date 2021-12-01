using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    private GameObject Nozzle_Working, Nozzle_Broken;
    private BoxCollider BC;
    public bool Failure, inUse, doOnce, audioBool;
    public float Timer, TotalTime = 5, emptyTimer;
    public AudioClip Empty, Fluids;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Nozzle_Working = gameObject.transform.GetChild(0).gameObject;
        Nozzle_Broken = gameObject.transform.GetChild(1).gameObject;
        Nozzle_Working.SetActive(false);
        
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
            audioBool = false;
            audioSource.Stop();
            doOnce = true;
            Nozzle_Broken.GetComponent<ParticleSystem>().Clear();
            Nozzle_Broken.GetComponent<ParticleSystem>().Pause();
        }
        if (TotalTime < 0)
        {
            gameObject.GetComponentInParent<PickupItem>().FailedExtinguisher = true;
            BC.enabled = false;
            Nozzle_Working.SetActive(false);
            Nozzle_Broken.GetComponent<ParticleSystem>().Pause();
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
            Nozzle_Working.SetActive(true);
            BC.enabled = true;
            audioSource.clip = Fluids;
            TotalTime -= Time.deltaTime;
            Nozzle_Broken.GetComponent<ParticleSystem>().Pause();
            if (audioBool == false)
            {
                audioSource.Play();
                audioBool = true;
            }
            
            
        }
   
        if (Input.GetKeyUp(KeyCode.Mouse0) && Failure == false)
        {
            inUse = false;
            Nozzle_Working.SetActive(false);
            BC.enabled = false;
            audioBool = false;
            audioSource.Pause();
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (TotalTime < 0 || Failure == true)
            {
                Nozzle_Broken.GetComponent<ParticleSystem>().Play();
                emptyTimer += Time.deltaTime;
                if (emptyTimer > 1)
                {

                    audioSource.PlayOneShot(Empty, 0.5f);
                    emptyTimer = 0;
                }

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
