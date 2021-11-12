using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitClearEnd : MonoBehaviour
{ public GameController GC;
    public GameObject goodText, badText;
    // Start is called before the first frame update
    void Start()
    {
        GC= GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GC.ValueablePickup == true)
        {
            goodText.SetActive(false);
            badText.SetActive(true);
        }
        if(GC.ValueablePickup == false)
        {
            goodText.SetActive(true);
            badText.SetActive(false);
        }
    }
}
