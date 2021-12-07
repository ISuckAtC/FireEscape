using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteMusic : MonoBehaviour
{
    AudioSource musicAudioSource;
    public bool isMuted;

    void Start()
    {
        musicAudioSource = GetComponent<AudioSource>();
        isMuted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if(isMuted == false)
            {
                musicAudioSource.mute = !musicAudioSource.mute;
                isMuted = true;
                Debug.Log("Music Gone");
            }
            if(isMuted == true)
            {
                musicAudioSource.mute = musicAudioSource.mute;
                isMuted = false;
                Debug.Log("Music Back");
            }
            
        }
            
    }
}
