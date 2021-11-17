using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMute : MonoBehaviour
{
    public GameController GC;
  
    // Start is called before the first frame update
    void Start()
    {
       GC= gameObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            GC.Muted = !GC.Muted;
            
            
        }
        if (GC.Muted == true)
        {
            AudioListener.volume = 0;
        }
        if(GC.Muted == false)
        {
           
                AudioListener.volume = 1;
            
        }
    }
}
