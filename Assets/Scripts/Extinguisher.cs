using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    private GameObject Nozzle;
    private BoxCollider BC;
    public bool Failure, inUse;
    public float Timer, TotalTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        Nozzle = gameObject.transform.GetChild(0).gameObject;
        Nozzle.SetActive(false);
        BC = gameObject.GetComponent<BoxCollider>();
        BC.enabled = false;
        TotalTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (TotalTime < 0)
        {
            gameObject.GetComponentInParent<PickupItem>().FailedExtinguisher = true;
            BC.enabled = false;
            Nozzle.SetActive(false);
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
            TotalTime -= Time.deltaTime;
            
        }
   
        if (Input.GetKeyUp(KeyCode.Mouse0) && Failure == false)
        {
            inUse = false;
            Nozzle.SetActive(false);
            BC.enabled = false;
        }
        if(TotalTime<0 || Failure == true)
        {
            //Insert Audio for failed sounds here.
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
