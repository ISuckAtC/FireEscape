using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text instructionsText;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
            Destroy(gameObject);
        
    }
}
