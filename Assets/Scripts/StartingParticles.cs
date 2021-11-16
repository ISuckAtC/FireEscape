using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingParticles : MonoBehaviour
{
    public ParticleSystem FP, FS, Smoke;
    public AudioSource Sound;
    private bool started;
    // Start is called before the first frame update
    void Start()
    {
        FP.Clear();
        FS.Clear();
        Smoke.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            FP.Play();
            FS.Play();
            Smoke.Play();
            started = true;
        }
    }
}
