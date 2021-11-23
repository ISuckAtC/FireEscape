using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingParticles : MonoBehaviour
{
    public ParticleSystem FP, FS, Smoke;
    public AudioSource Sound;
    private bool started;
    public bool isMuted;
    // Start is called before the first frame update
    void Start()
    {
        FP.Clear();
        FS.Clear();
        Smoke.Clear();
        if(isMuted == true)
        {
            Sound.enabled = false;
        }
        if(isMuted == false)
        {
            Sound.Stop();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            FP.Play();
            FS.Play();
            Smoke.Play();
            if(isMuted == false)
            {
                Sound.Play();
            }
            
            started = true;
        }
    }
}
