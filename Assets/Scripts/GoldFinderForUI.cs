using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldFinderForUI : MonoBehaviour
{
    
    public GoldPickup[] pickables;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] value = GameObject.FindGameObjectsWithTag("Valuable");
        pickables = new GoldPickup[value.Length];
        for (int i = 0; i < value.Length; i++)
        {
            pickables[i] = value[i].GetComponent<GoldPickup>();
        }
    }
}
