using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class DeathScene : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip smokeDeath;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GameObject.Find("Video Player").GetComponent<VideoPlayer>();

        switch (GameData.DeathType)
        {
            case 0:
            {
                
            }
            break;

            case 1:
            {
                videoPlayer.clip = smokeDeath;
                videoPlayer.Play();
            }
            break;

            default:break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
