using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Continue : MonoBehaviour
{
    public BooleanScene BS;
    public GameController GC;
    public AudioClip DeathNoise;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(DeathNoise);
        BS = GameObject.Find("GameController").GetComponent<BooleanScene>();
        GC = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && BS.Level2 == true)
        {
            SceneManager.LoadScene("Level2");
        }
        if (Input.GetKeyUp(KeyCode.Space) && BS.Level2 == false)
        {
            SceneManager.LoadScene("Level1_LightsOutP");
            GC.Valuables = 0;
        }
          
    }
}
