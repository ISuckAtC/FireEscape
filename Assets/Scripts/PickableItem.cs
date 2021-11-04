using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    private Rigidbody rb;
    public Rigidbody Rb => rb;
    public bool Unusable;
    public bool ParticleSystemOff;
    private ParticleSystem pS;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pS = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pS == null)
        {
            goto noerror;
        }
        if(ParticleSystemOff == true)
        {
            pS.Stop();
        }
    noerror:;
        if(Unusable == true)
        {
            gameObject.SetActive(false);
        }
    }
}
