using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyDisable : MonoBehaviour
{
    public bool DisableMe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DisableMe == true)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
