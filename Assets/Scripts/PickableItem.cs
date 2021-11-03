using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    private Rigidbody rb;
    public Rigidbody Rb => rb;
    public bool unusable;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(unusable == true)
        {
            gameObject.SetActive(false);
        }
    }
}
