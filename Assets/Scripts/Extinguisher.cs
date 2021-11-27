using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    private GameObject Nozzle;
    private BoxCollider BC;
    public bool Failure, inUse;
    private float Timer, TotalTime = 10;
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
